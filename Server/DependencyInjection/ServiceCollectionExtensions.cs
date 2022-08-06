namespace Server.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ITransit1, Transit1>();
            services.AddTransient<ITransit2, Transit2>();

            services.AddScoped<IScoped1, Scoped1>();
            services.AddScoped<IScoped2, Scoped2>();
            
            services.AddSingleton<ISingleton1, Singleton1>();
            services.AddSingleton<ISingleton2, Singleton2>();
            return services;
        }
    }
}
