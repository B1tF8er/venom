namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    internal abstract class Parser : IParser
    {
        private readonly Func<HtmlNode, Article> toArticle;

        internal Parser(Func<HtmlNode, Article> toArticle) =>
            this.toArticle = toArticle ?? throw new ArgumentNullException(nameof(toArticle));

        public void Parse(HtmlDocument html, Uri uri)
        {
            if (html is null)
                throw new ArgumentNullException(nameof(html));

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
            var articles = GetArticles(documentNode, selector);

            using (var context = new Context()) 
            {
                var dbAuthors = context.Authors.AsEnumerable();

                foreach (var article in articles)
                {
                    var dbAuthor = dbAuthors.FirstOrDefault(a => a == article.Author);

                    if (dbAuthor is null)
                        await context.Articles.AddRangeAsync(article);
                }

                context.SaveChanges();
            }
        }

        private IEnumerable<Article> GetArticles(HtmlNode documentNode, string selector) =>
            documentNode.QuerySelectorAll(selector).Select(toArticle);
    }
}
