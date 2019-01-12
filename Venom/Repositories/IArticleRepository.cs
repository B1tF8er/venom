namespace Venom
{
    using System.Collections.Generic;
    
    public interface IArticleRepository
    {
        void AddAsync(IEnumerable<Article> articles);
    }
}
