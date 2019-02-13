namespace Venom
{
    using Fizzler.Systems.HtmlAgilityPack;
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Parser : IParser
    {
        private HtmlDocument html;

        private readonly Func<HtmlNode, Article> toArticle;

        private readonly IArticleRepository articleRepository;

        internal Parser(Func<HtmlNode, Article> toArticle, IArticleRepository articleRepository)
        {
            this.toArticle = toArticle ?? throw new ArgumentNullException(nameof(toArticle));
            this.articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
        }

        public void Parse(Uri uri)
        {
            GetHtml(uri);

            if (uri.IsReviewCategory())
                ParseReviews();
            else if (uri.IsTourCategory())
                ParseTours();
            else if (uri.IsVideoCategory())
                ParseVideos();
        }

        protected abstract void ParseReviews();

        protected abstract void ParseTours();

        protected abstract void ParseVideos();

        private void GetHtml(Uri uri)
        {
            var web = new HtmlWeb();
            html = web.Load(uri);
        }

        private protected void SaveArticles(string selector) =>
            articleRepository.AddAsync(GetArticles(selector));

        private IEnumerable<Article> GetArticles(string selector) =>
            html.DocumentNode.QuerySelectorAll(selector).Select(toArticle);
    }
}
