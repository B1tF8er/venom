namespace Venom
{
    using Microsoft.Extensions.DependencyInjection;

    internal static class Startup
    {
        private static readonly ServiceCollection services;

        static Startup() => services = new ServiceCollection();

        internal static ServiceProvider ConfigureServiceProvider() => services.Configure().BuildServiceProvider();

        private static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddSingleton<ICrawler, Crawler>();

            return services;
        }
    }
}
