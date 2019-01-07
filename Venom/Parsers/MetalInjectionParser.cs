namespace Venom
{
    using HtmlAgilityPack;
    using Fizzler.Systems.HtmlAgilityPack;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class MetalInjectionParser : IParser
    {
        internal MetalInjectionParser()
        {
        }

        public void Parse(HtmlDocument html, Uri uri)
        {
            if (uri.IsReviewCategory())
                ParseReviews(html);
            else if (uri.IsTourCategory())
                ParseTours(html);
            else if (uri.IsVideoCategory())
                ParseVideos(html);
        }

        private void ParseReviews(HtmlDocument html)
        {
            var reviews = GetArticles(html.DocumentNode, "category-reviews");

            // TODO: save to database

            return;
        }

        private void ParseTours(HtmlDocument html)
        {
            var tours = GetArticles(html.DocumentNode, "category-tour-dates");

            // TODO: save to database

            return;
        }

        private void ParseVideos(HtmlDocument html)
        {
            var videos = GetArticles(html.DocumentNode, "video");

            // TODO: save to database

            return;
        }

        private IEnumerable<Article> GetArticles(HtmlNode documentNode, string category) =>
            documentNode.QuerySelectorAll($"article.{category}").Select(ToArticle);

        private Func<HtmlNode, Article> ToArticle = node => {
            var meta = node.QuerySelector(".content .meta > a");

            return new Article {
                Uri = node.QuerySelector("a").Attributes.FirstOrDefault().DeEntitizeValue,
                Title = node.QuerySelector(".content .title").InnerText,
                Author = new Author {
                    Name = meta.InnerHtml,
                    Uri = meta.Attributes.FirstOrDefault().DeEntitizeValue,
                    Date = Convert.ToDateTime(meta.ParentNode.InnerHtml.Split('|').LastOrDefault().Trim())
                },
                Category = node.QuerySelector(".content .category > a").InnerHtml
            };
        };
    }
}
