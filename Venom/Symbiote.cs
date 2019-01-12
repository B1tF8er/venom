namespace Venom
{
    using System;
    using System.Collections.Generic;
    using static Constants;
    
    class Symbiote
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler();
            crawler.Crawl(Sites());
        }

        static IEnumerable<Site> Sites()
        {
            yield return new Site(Type.MetalInjection, MetalInjectionConstants.Paths);
            yield return new Site(Type.MetalSucks, MetalSucksConstants.Paths);
        }
    }
}
