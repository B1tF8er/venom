namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Linq;
    using static Constants.MetalSucksConstants;

    internal class MetalSucksParser : Parser
    {
        internal MetalSucksParser() : base(ToMetalSucksArticle) {}

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

        private static Article ToMetalSucksArticle(HtmlNode node)
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
                    Date = Convert.ToDateTime(author.ParentNode.ParentNode.QuerySelector(TimeSelector).Attributes[1].DeEntitizeValue)
                },
                Category = node.QuerySelector(CategorySelector).InnerHtml
            };
        }
    }
}
