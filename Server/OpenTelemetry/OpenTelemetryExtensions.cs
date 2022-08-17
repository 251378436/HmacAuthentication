using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Server.OpenTelemetry
{
    public static class OpenTelemetryExtensions
    {
        public static IServiceCollection AddOpenTelemetry(this IServiceCollection services)
        {
            // Define some important constants and the activity source
            var serviceName = "MyCompany.MyProduct.MyService";
            var serviceVersion = "1.0.0";

            // Configure important OpenTelemetry settings, the console exporter, and instrumentation library
            services.AddOpenTelemetryTracing(b =>
            {
                b
                .AddConsoleExporter()
                .AddSource(serviceName)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation();
            });

            return services;
        }
    }
}
