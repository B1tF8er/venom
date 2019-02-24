namespace Venom
{
    using Bit.Logger;
    using Bit.Logger.Contract;
    using Microsoft.Extensions.DependencyInjection;

    internal static class Startup
    {
        private static ServiceCollection services;

        private static ServiceProvider serviceProvider;

        internal static void Start()
        {
            Build();
            RunCrawler();
        }

        private static void Build()
        {
            AddServices();
            serviceProvider = services.BuildServiceProvider();
        }

        private static void AddServices()
        {
            services = new ServiceCollection();
            services.AddSingleton<ILogger, Logger>();
        }

        private static void RunCrawler()
        {
            var logger = serviceProvider.GetService<ILogger>();
            logger.AddConsoleSource();

            var performance = new Performance(logger);
            var crawler = new Crawler();
            performance.Measure(Data.For(crawler.Crawl));
        }
    }
}
