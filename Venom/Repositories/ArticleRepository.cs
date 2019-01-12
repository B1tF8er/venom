namespace Venom
{
    using System.Collections.Generic;
    using System.Linq;

    internal class ArticleRepository : IArticleRepository
    {
        public async void AddAsync(IEnumerable<Article> articles)
        {
            using (var context = new Context()) 
            {
                articles = articles
                    .Where(article => 
                        !context.Authors.AsEnumerable().Any(author => author == article.Author)
                    );

                if (articles.Any())
                {
                    await context.Articles.AddRangeAsync(articles);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}