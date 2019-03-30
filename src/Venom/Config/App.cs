namespace Venom
{
    using Bit.Logger;
    using Bit.Logger.Contract;
    using Microsoft.Extensions.DependencyInjection;

    internal static class App
    {
        private static ServiceCollection services;

        private static ServiceProvider serviceProvider;

        internal static void Start()
        {
            AddServices();
            Build();
            Run();            
        }

        private static void AddServices()
        {
            services = new ServiceCollection();

            ILogger logger = new Logger()
                .AddConsoleSource();

            services.AddSingleton(logger);
            services.AddTransient<Performance>();
            services.AddTransient<Crawler>();
        }

        private static void Build() =>
            serviceProvider = services.BuildServiceProvider();

        private static void Run()
        {
            var performance = serviceProvider.GetService<Performance>();
            var crawler = serviceProvider.GetService<Crawler>();
            performance.Measure(Data.For(crawler.Crawl));
        }
    }
}
