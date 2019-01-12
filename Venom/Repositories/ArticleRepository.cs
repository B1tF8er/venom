namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ArticleRepository : IArticleRepository
    {
        public async void AddAsync(IEnumerable<Article> articles)
        {
            using (var context = new Context())
            {
                articles = articles.Where(ArticleIsNew(context));

                if (articles.Any())
                {
                    await context.Articles.AddRangeAsync(articles);
                    await context.SaveChangesAsync();
                }
            }
        }

        private Func<Article, bool> ArticleIsNew(Context context) =>
            article => !context.Authors.AsEnumerable().Any(author => author == article.Author);
    }
}