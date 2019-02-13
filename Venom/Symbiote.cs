namespace Venom
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using static Performance;

    class Symbiote
    {
        static void Main(string[] args)
        {
            try
            {
                nameof(Start).Measure(Start);
            }
            catch (Exception ex)
            {
                Environment.FailFast("An unexpected error occurred.", ex);
            }
        }

        static void Start()
        {
            var serviceProvider = Startup.ConfigureServiceProvider();
            var crawler = serviceProvider.GetService<ICrawler>();

            crawler.Crawl();
        }
    }
}
