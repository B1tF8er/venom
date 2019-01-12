namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Crawler
    {
        internal void Crawl(IEnumerable<Site> sites) =>
            sites.ToList().ForEach(site => Crawl(site.Type, site.Uris()));

        private void Crawl(Type type, IEnumerable<Uri> uris)
        {
            var parser = ParserFactory.GetParser(type);
            uris.ToList().ForEach(uri => parser.Parse(uri));
        }
    }
}
