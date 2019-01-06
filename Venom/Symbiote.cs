namespace Venom
{
    using System;
    using System.Collections.Generic;
    
    class Symbiote
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler();
            crawler.Crawl(Sites());
        }

        static IEnumerable<Site> Sites()
        {
            yield return new Site(Type.MetalInjection);
            yield return new Site(Type.MetalSucks);
        }
    }
}
