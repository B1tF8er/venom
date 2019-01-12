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

        protected override void ParseReviews(HtmlNode documentNode) => SaveArticles(documentNode, ReviewsSelector);

        protected override void ParseTours(HtmlNode documentNode) => SaveArticles(documentNode, ToursSelector);

        protected override void ParseVideos(HtmlNode documentNode) => SaveArticles(documentNode, VideosSelector);

        private static Article ToMetalInjectionArticle(HtmlNode node)
        {
            var author = node.QuerySelector(AuthorSelector);
            var date = author.ParentNode.InnerHtml.Split('|').LastOrDefault().Trim();

            return new Article
            {
                Uri = node.QuerySelector(UriSelector).Attributes.FirstOrDefault().DeEntitizeValue,
                Title = node.QuerySelector(TilteSelector).InnerText,
                Author = new Author
                {
                    Name = author.InnerHtml,
                    Uri = author.Attributes.FirstOrDefault().DeEntitizeValue,
                    Date = Convert.ToDateTime(Convert.ToDateTime(date).ToString("yyyy-MM-dd"))
                },
                Category = node.QuerySelector(CategorySelector).InnerHtml
            };
        }
    }
}
