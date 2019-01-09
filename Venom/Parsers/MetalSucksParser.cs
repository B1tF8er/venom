namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Linq;

    internal class MetalSucksParser : BaseParser
    {
        internal MetalSucksParser() : base(ToMetalSucksArticle) {}

        protected override void ParseReviews(HtmlNode documentNode)
        {
            var reviews = GetArticles(documentNode, "article[itemtype='http://schema.org/Review']");

            // TODO: save to database

            return;
        }

        protected override void ParseTours(HtmlNode documentNode)
        {
            var tours = GetArticles(documentNode, "article[itemtype='http://schema.org/NewsArticle']");

            // TODO: save to database

            return;
        }

        protected override void ParseVideos(HtmlNode documentNode)
        {
            var videos = GetArticles(documentNode, "article[itemtype='http://schema.org/VideoObject']");

            // TODO: save to database

            return;
        }

        private static Article ToMetalSucksArticle(HtmlNode node)
        {
            var meta = node.QuerySelector(".content-block .author > a");

            return new Article
            {
                Uri = node.QuerySelector("span[itemprop='url'] a.full-cover").Attributes.FirstOrDefault().DeEntitizeValue,
                Title = node.QuerySelector(".post-title a").InnerText,
                Author = new Author
                {
                    Name = meta.InnerHtml,
                    Uri = meta.Attributes.FirstOrDefault().DeEntitizeValue,
                    Date = Convert.ToDateTime(meta.ParentNode.ParentNode.QuerySelector("time").Attributes[1].DeEntitizeValue)
                },
                Category = node.QuerySelector("span[itemprop='url'] a.category-tag").InnerHtml
            };
        }
    }
}
