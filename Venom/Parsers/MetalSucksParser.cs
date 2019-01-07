namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;

    internal class MetalSucksParser : BaseParser
    {
        internal MetalSucksParser() : base(ToMetalInjectionArticle) {}

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
            var videos = GetArticles(documentNode, "article.video");

            // TODO: save to database

            return;
        }

        private static Article ToMetalInjectionArticle(HtmlNode node)
        {
            return new Article();
        }
    }
}
