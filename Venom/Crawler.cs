namespace Venom
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class Crawler
    {
        internal void Crawl(IEnumerable<Site> sites)
        {
            var categories = sites.SelectMany(s => s.Categories());

            foreach (var category in categories)
                Crawl(category.Type, category.Uri);
        }

        private void Crawl(Type type, Uri uri)
        {
            var parser = ParserFactory.GetParser(type);

            if (uri.IsTourCategory())
                parser.ParseTours(GetHtml(uri));

            if (uri.IsReviewCategory())
                parser.ParseReviews(GetHtml(uri));
    
            if (uri.IsVideoCategory())
                parser.ParseVideos(GetHtml(uri));
        }
        
        private HtmlDocument GetHtml(Uri uri)
        {
            var web = new HtmlWeb();
            var html = web.Load(uri);

            return html;
        }
    }
}
