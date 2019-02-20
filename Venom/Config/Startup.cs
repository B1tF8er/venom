namespace Venom
{
    using Bit.Logger.Contract;
    using Bit.Logger.Factory;
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
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
        }

        private static void RunCrawler()
        {
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddConsoleSource();

            var performance = new Performance(loggerFactory);
            var crawler = new Crawler();
            performance.Measure(crawler.Crawl, nameof(Crawler), nameof(crawler.Crawl));
        }
    }
}
