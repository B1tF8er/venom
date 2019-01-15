namespace Venom
{
    using Microsoft.Extensions.DependencyInjection;

    internal static class Startup
    {
        internal static ServiceProvider ConfigureServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICrawler, Crawler>();
        }
    }
}
