namespace Venom
{
    using System;
    using System.Collections.Generic;

    internal static class Sites
    {
        private const string BaseUri = "http://www.{0}.net";
        private static readonly string MetalInjection;
        private static readonly string MetalSucks;

        static Sites()
        {
            MetalInjection = string.Format(BaseUri, "metalinjection");
            MetalSucks = string.Format(BaseUri, "metalsucks");
        }

        internal static IEnumerable<Uri> Uris()
        {
            yield return new Uri(CreateMIUri("tour-dates"));
            yield return new Uri(CreateMSUri("tour-de-force"));
            yield return new Uri(CreateMIUri("reviews"));
            yield return new Uri(CreateMSUri("reviews"));
            yield return new Uri(CreateMIUri("video"));
            yield return new Uri(CreateMSUri("cinemetal"));
        }

        private static string CreateMIUri(string category) => $"{MetalInjection}/category/{category}";
        private static string CreateMSUri(string category) => $"{MetalSucks}/category/{category}";
    }
}