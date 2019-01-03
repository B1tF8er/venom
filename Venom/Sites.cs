namespace Venom
{
    using System;
    using System.Collections.Generic;

    internal static class Sites
    {
        private const string BaseUri = "http://www.{0}.net";
        private const string MetalInjection = "metalinjection";
        private const string MetalSucks = "metalsucks";
        private static readonly string MetalInjectionUri;
        private static readonly string MetalSucksUri;

        static Sites()
        {
            MetalInjectionUri = string.Format(BaseUri, MetalInjection);
            MetalSucksUri = string.Format(BaseUri, MetalSucks);
        }

        internal static IEnumerable<Uri> Uris()
        {
            yield return new Uri(CreateCategoryUri(MetalInjectionUri, "tour-dates"));
            yield return new Uri(CreateCategoryUri(MetalSucksUri, "tour-de-force"));
            yield return new Uri(CreateCategoryUri(MetalInjectionUri, "reviews"));
            yield return new Uri(CreateCategoryUri(MetalSucksUri, "reviews"));
            yield return new Uri(CreateCategoryUri(MetalInjectionUri, "video"));
            yield return new Uri(CreateCategoryUri(MetalSucksUri, "cinemetal"));
        }

        private static string CreateCategoryUri(string site, string category) => $"{site}/category/{category}";
    }
}
