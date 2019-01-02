namespace Venom
{
    using HtmlAgilityPack;
    using System;
    
    internal class Crawler
    {
        internal void Crawl()
        {
            foreach (var uri in Sites.Uris())
                Crawl(uri);
        }

        private void Crawl(Uri uri)
        {
            var html = GetHtml(uri);
            
            Parse(html);
        }

        private HtmlDocument GetHtml(Uri uri)
        {
            var web = new HtmlWeb();
            var html = web.Load(uri);

            return html;
        }

        private void Parse(HtmlDocument html)
        {
            // TODO: convert to local model then save to DB
        }
    }
}
