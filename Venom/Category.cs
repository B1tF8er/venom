namespace Venom
{
    using System;
    
    internal class Category
    {
        internal Type Type { get; }
        internal Uri Uri { get; }

        internal Category(Type type, string site, string category)
        {
            Type = type;
            Uri = new Uri(CreateCategoryUri(site, category));
        }

        private string CreateCategoryUri(string site, string category) => $"{site}/{category}";
    }
}
