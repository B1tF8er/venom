namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class MetalInjectionParser : BaseParser
    {
        internal MetalInjectionParser() : base(ToMetalInjectionArticle) {}

        protected override void ParseReviews(HtmlNode documentNode)
        {
            var reviews = GetArticles(documentNode, "article.category-reviews");

            // TODO: save to database

            return;
        }

        protected override void ParseTours(HtmlNode documentNode)
        {
            var tours = GetArticles(documentNode, "article.category-tour-dates");

            // TODO: save to database

            return;
        }

        protected override void ParseVideos(HtmlNode documentNode)
        {
            var videos = GetArticles(documentNode, "article.type-video");

            // TODO: save to database

            return;
        }

        private static Article ToMetalInjectionArticle(HtmlNode node)
        {
            var meta = node.QuerySelector(".content .meta > a");

            return new Article
            {
                Uri = node.QuerySelector("a").Attributes.FirstOrDefault().DeEntitizeValue,
                Title = node.QuerySelector(".content .title").InnerText,
                Author = new Author
                {
                    Name = meta.InnerHtml,
                    Uri = meta.Attributes.FirstOrDefault().DeEntitizeValue,
                    Date = Convert.ToDateTime(meta.ParentNode.InnerHtml.Split('|').LastOrDefault().Trim())
                },
                Category = node.QuerySelector(".content .category > a").InnerHtml
            };
        }
    }
}
