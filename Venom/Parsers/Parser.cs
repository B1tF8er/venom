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

        private readonly IArticleRepository articleRepository;

        internal Parser(Func<HtmlNode, Article> toArticle, IArticleRepository articleRepository)
        {
            this.toArticle = toArticle ?? throw new ArgumentNullException(nameof(toArticle));
            this.articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));;
        }

        public void Parse(Uri uri)
        {
            var html = GetHtml(uri);
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

        private HtmlDocument GetHtml(Uri uri)
        {
            var web = new HtmlWeb();
            var html = web.Load(uri);

            return html;
        }

        private protected void SaveArticles(HtmlNode documentNode, string selector) =>
            articleRepository.AddAsync(GetArticles(documentNode, selector)); 

        private IEnumerable<Article> GetArticles(HtmlNode documentNode, string selector) =>
            documentNode.QuerySelectorAll(selector).Select(toArticle);
    }
}
