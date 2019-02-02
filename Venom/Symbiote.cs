namespace Venom
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    
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
                Console.WriteLine(ex);
                Environment.FailFast("An unexpected error occurred.", ex);
            }
        }

        static void Start()
        {
            var serviceProvider = Startup.ConfigureServiceProvider();
            var crawler = serviceProvider.GetService<ICrawler>();

            crawler.Start();
        }
    }
}
