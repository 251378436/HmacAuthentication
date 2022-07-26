using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Server;
using Server.Auth;
using Server.DependencyInjection;
using Server.Middlewares;
using Server.ModlesBinders;
using Server.OpenTelemetry;
using Server.Validators;
using System.Reflection;
using System.Text.Json;
using Prometheus;
using Server.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddOpenTelemetry();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new CarModelBinderProvider());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = Constants.Auth.HmacSha256OrJwtBearer;
                o.DefaultAuthenticateScheme = Constants.Auth.HmacSha256OrJwtBearer;
                o.DefaultChallengeScheme = Constants.Auth.HmacSha256OrJwtBearer;
            })
          .AddPolicyScheme(Constants.Auth.HmacSha256OrJwtBearer, Constants.Auth.HmacSha256OrJwtBearer, options =>
          {
              options.ForwardDefaultSelector = context =>
              {
                  var headerScheme = context.Request.Headers.Authorization.ToString()?.ToLower().Split(' ')[0] ?? Constants.Auth.JwtBearer;
                  return headerScheme;
              };
          })
          .AddJwtBearer(Constants.Auth.JwtBearer, options =>
          {
              options.Authority = $"https://{builder.Configuration["Auth0Settings:Domain"]}/";
              options.Audience = builder.Configuration["Auth0Settings:Audience"];

              options.Events = new JwtBearerEvents
              {
                  OnTokenValidated = context =>
                  {
                      Console.WriteLine("*****************");
                      Console.WriteLine("Step 2: JwtBearer");
                      Console.WriteLine("*****************");
                      return Task.CompletedTask;
                  },

                  OnChallenge = context =>
                  {
                      context.Response.OnStarting(async () =>
                      {
                          await context.Response.WriteAsync(
                              JsonSerializer.Serialize("You are not authorized!")
                          );
                      });

                      return Task.CompletedTask;
                  }
              };
          })
    .AddScheme<AuthenticationSchemeOptions, CustomTokenAuthHandler>(Constants.Auth.HmacSha256, options => { })
    .AddScheme<AuthenticationSchemeOptions, CustomTokenAuthHandler2>(Constants.Auth.HmacSha2562, options => { })
    .AddScheme<AuthenticationSchemeOptions, DefaultAuthHandler>("", options => { });

builder.Services.AddCustomDependencyInjection();
builder.Services.AddValidatorsFromAssemblyContaining<CarModelValidator>();

builder.Services.AddSingleton<ITokenCache, TokenCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseRequestBefore();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").AllowAnonymous();
    endpoints.MapMetrics().AllowAnonymous();

    EventCounterAdapter.StartListening();
    MeterAdapter.StartListening();

    endpoints.MapControllers();
});

app.UseRequestAfter();

app.Run();