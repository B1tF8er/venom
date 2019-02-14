namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Crawler : ICrawler
    {
        private readonly IEnumerable<Site> sites;

        public Crawler() => sites = new Sites();

        public void Crawl() => sites.AsParallel().ForAll(Crawl);

        private void Crawl(Site site)
        {
            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().AsParallel().ForAll(parser.Parse);
        }
    }
}
