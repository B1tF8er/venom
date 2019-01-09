namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Linq;
    using static Constants.MetalInjectionConstants;

    internal class MetalInjectionParser : Parser
    {
        internal MetalInjectionParser() : base(ToMetalInjectionArticle) {}

        protected override void ParseReviews(HtmlNode documentNode)
        {
            var reviews = GetArticles(documentNode, ReviewsSelector);

            // TODO: save to database

            return;
        }

        protected override void ParseTours(HtmlNode documentNode)
        {
            var tours = GetArticles(documentNode, ToursSelector);

            // TODO: save to database

            return;
        }

        protected override void ParseVideos(HtmlNode documentNode)
        {
            var videos = GetArticles(documentNode, VideosSelector);

            // TODO: save to database

            return;
        }

        private static Article ToMetalInjectionArticle(HtmlNode node)
        {
            var author = node.QuerySelector(AuthorSelector);

            return new Article
            {
                Uri = node.QuerySelector(UriSelector).Attributes.FirstOrDefault().DeEntitizeValue,
                Title = node.QuerySelector(TilteSelector).InnerText,
                Author = new Author
                {
                    Name = author.InnerHtml,
                    Uri = author.Attributes.FirstOrDefault().DeEntitizeValue,
                    Date = Convert.ToDateTime(author.ParentNode.InnerHtml.Split('|').LastOrDefault().Trim())
                },
                Category = node.QuerySelector(CategorySelector).InnerHtml
            };
        }
    }
}
