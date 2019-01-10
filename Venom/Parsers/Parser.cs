namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Parser : IParser
    {
        private readonly Func<HtmlNode, Article> toArticle;

        internal Parser(Func<HtmlNode, Article> toArticle) =>
            this.toArticle = toArticle ?? throw new ArgumentNullException(nameof(toArticle));

        public void Parse(HtmlDocument html, Uri uri)
        {
            var documentNode = html.DocumentNode;

            if (uri.IsReviewCategory())
                ParseReviews(documentNode);
            else if (uri.IsTourCategory())
                ParseTours(documentNode);
            else if (uri.IsVideoCategory())
                ParseVideos(documentNode);
        }

        protected abstract void ParseReviews(HtmlNode documentNode);

        protected abstract void ParseTours(HtmlNode documentNode);

        protected abstract void ParseVideos(HtmlNode documentNode);

        private protected async void SaveArticles(HtmlNode documentNode, string selector)
        {
            using (var context = new Context()) 
            {
                await context.Articles.AddRangeAsync(GetArticles(documentNode, selector));
                context.SaveChanges();
            }
        }

        private IEnumerable<Article> GetArticles(HtmlNode documentNode, string selector) =>
            documentNode.QuerySelectorAll(selector).Select(toArticle);
    }
}
