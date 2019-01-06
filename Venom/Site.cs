namespace Venom
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Site
    {
        private const string BaseUri = "http://www.{0}.net";
        private readonly Type type;
        private readonly string siteUri;

        internal Site(Type type)
        {
            this.type = type;
            siteUri = string.Format(BaseUri, type);
        }

        internal IEnumerable<Category> Categories()
        {
            if (type == Type.MetalInjection)
            {
                yield return new Category(type, siteUri, "tour-dates");
                yield return new Category(type, siteUri, "reviews");
                yield return new Category(type, siteUri, "video");
            }
            else if (type == Type.MetalSucks)
            {
                yield return new Category(type, siteUri, "tour-de-force");
                yield return new Category(type, siteUri, "reviews");
                yield return new Category(type, siteUri, "cinemetal");
            }
        }
    }
}