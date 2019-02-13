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
            Guard(paths);

            Type = type;
            this.paths = paths;

            siteUri = string.Format(BaseUri, type);
        }

        private void Guard(IEnumerable<string> paths)
        {
            if (paths is null)
                throw new ArgumentNullException(nameof(paths));
            if (!paths.Any())
                throw new ArgumentNullException(nameof(paths));
        }

        internal IEnumerable<Uri> Uris()
        {
            foreach (var path in paths)
                yield return new Uri($"{siteUri}/{path}");
        }
    }
}
