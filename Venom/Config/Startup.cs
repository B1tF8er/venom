namespace Venom
{
    using Bit.Logger.Contract;
    using Bit.Logger.Factory;
    using Microsoft.Extensions.DependencyInjection;

    internal static class Startup
    {
        private static readonly ServiceCollection services;

        static Startup() => services = new ServiceCollection();

        internal static ServiceProvider ConfigureServiceProvider() => services.AddServices().BuildServiceProvider();

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            return services;
        }
    }
}
