namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Linq;
    using static Constants.MetalSucks;

    internal class MetalSucksParser : Parser
    {
        private static readonly IArticleRepository articleRepository =  new ArticleRepository();

        internal MetalSucksParser() : base(ToMetalSucksArticle, articleRepository) {}

        protected override void ParseReviews() => SaveArticles(ReviewsSelector);

        protected override void ParseTours() => SaveArticles(ToursSelector);

        protected override void ParseVideos() => SaveArticles(VideosSelector);

        private static Article ToMetalSucksArticle(HtmlNode node)
        {
            var author = node.QuerySelector(AuthorSelector);
            var date = author.ParentNode.ParentNode.QuerySelector(TimeSelector).Attributes[1].DeEntitizeValue;

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
