namespace Venom
{
    using System;
    using System.Collections.Generic;

    internal class Site
    {
        private const string BaseUri = "http://www.{0}.net";
        internal Type Type { get; }
        private readonly IEnumerable<string> paths;
        private readonly string siteUri;

        internal Site(Type type, IEnumerable<string> paths)
        {
            Type = type;
            this.paths = paths;

            siteUri = string.Format(BaseUri, type);
        }

        internal IEnumerable<Uri> Uris()
        {
            foreach (var path in paths)
                yield return new Uri($"{siteUri}/{path}");
        }
    }
}
