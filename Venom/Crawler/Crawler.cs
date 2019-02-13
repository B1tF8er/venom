namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static SiteEnumerator;
    
    internal class Crawler : ICrawler
    {
        public void Crawl() => Sites().AsParallel().ForAll(Crawl);

        private void Crawl(Site site)
        {
            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().AsParallel().ForAll(parser.Parse);
        }
    }
}
