namespace Venom
{
    using Bit.Logger.Factory;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using static Constants;

    class Symbiote
    {
        static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch (Exception ex)
            {
                Environment.FailFast($"{Error.Unexpected}", ex);
            }
        }

        static void Start()
        {
            var serviceProvider = Startup.ConfigureServiceProvider();
            
            var loggerFactory = ActivatorUtilities.CreateInstance<LoggerFactory>(serviceProvider);
            loggerFactory.AddConsoleSource();

            var performance = new Performance(loggerFactory);
            var crawler = new Crawler();
            performance.Measure(crawler.Crawl);
        }
    }
}
