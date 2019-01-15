namespace Venom
{
    using System.Collections.Generic;
    using System.Linq;
    using static Constants;
    
    internal class Crawler : ICrawler
    {
        public void Start() => Crawl(Sites());

        private void Crawl(IEnumerable<Site> sites) => sites.AsParallel().ForAll(Crawl);

        private void Crawl(Site site)
        {
            var parser = ParserFactory.GetParser(site.Type);
            site.Uris().AsParallel().ForAll(parser.Parse);
        }

        private IEnumerable<Site> Sites()
        {
            yield return new Site(Type.MetalInjection, MetalInjectionConstants.Paths);
            yield return new Site(Type.MetalSucks, MetalSucksConstants.Paths);
        }
    }
}
