namespace Venom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Site
    {
        private const string BaseUri = "http://www.{0}.net";
        internal Type Type { get; }
        private readonly IEnumerable<string> paths;
        private readonly string siteUri;

        internal Site(Type type, IEnumerable<string> paths)
        {
            Type = type;
            this.paths = paths?.Where(p => !string.IsNullOrEmpty(p) || !string.IsNullOrWhiteSpace(p)) ?? Enumerable.Empty<string>();;
            siteUri = string.Format(BaseUri, type);
        }

        internal IEnumerable<Uri> Uris()
        {
            foreach (var path in paths)
                yield return new Uri($"{siteUri}/{path}");
        }

        public override string ToString() =>
            $"{Type} - Paths: {paths.Select(p => $"[{p}]").Aggregate((a, b) => $"{a}, {b}")}";
    }
}
