namespace Venom
{
    using Bit.Logger.Contract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Crawler : ICrawler
    {
        private readonly ILogger logger;

        public Crawler(ILogger logger) => this.logger = logger;

        public void Crawl() => new Sites().AsParallel().ForAll(Crawl);

        private void Crawl(Site site)
        {
            logger.Information($"{site}");

            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().AsParallel().ForAll(parser.Parse);
        }
    }
}
