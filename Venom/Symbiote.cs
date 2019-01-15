namespace Venom
{
    using Microsoft.Extensions.DependencyInjection;
    
    class Symbiote
    {
        static void Main(string[] args)
        {
            var serviceProvider = Startup.ConfigureServiceProvider();
            var crawler = serviceProvider.GetService<ICrawler>();

            crawler.Start();
        }
    }
}
