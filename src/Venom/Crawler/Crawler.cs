namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Crawler : ICrawler
    {
        public void Crawl() => new Sites().AsParallel().ForAll(Crawl);

        private void Crawl(Site site)
        {
            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().AsParallel().ForAll(parser.Parse);
        }
    }
}
