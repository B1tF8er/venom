namespace Venom
{
    using System.Collections.Generic;
    using System.Linq;
    
    internal static class Crawler
    {
        internal static void Crawl(IEnumerable<Site> sites) =>
            sites.ToList().ForEach(Crawl);

        private static void Crawl(Site site)
        {
            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().ToList().ForEach(parser.Parse);
        }
    }
}
