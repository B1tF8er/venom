namespace Venom
{
    using System;

    internal static class UriExtensions
    {
        internal static bool IsTourCategory(this Uri uri) =>
            uri.PathAndQuery.Contains("tour");
        internal static bool IsReviewCategory(this Uri uri) =>
            uri.PathAndQuery.Contains("review");
        internal static bool IsVideoCategory(this Uri uri) =>
            uri.PathAndQuery.Contains("video") || uri.PathAndQuery.Contains("cine");
    }
}
