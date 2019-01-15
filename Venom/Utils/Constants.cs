namespace Venom
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class Constants
    {
        internal static class MetalInjectionConstants
        {
            internal static readonly IEnumerable<string> Paths = new List<string>
            {
                "category/reviews",
                "category/tour-dates",
                "channels/music-videos"
            };
            internal const string ReviewsSelector = "article.category-reviews";
            internal const string ToursSelector = "article.category-tour-dates";
            internal const string VideosSelector = "article.type-video";
            internal const string AuthorSelector = ".content .meta > a";
            internal const string UriSelector = "a";
            internal const string TilteSelector = ".content .title";
            internal const string CategorySelector = ".content .category > a";
        }

        internal static class MetalSucksConstants
        {
            internal static readonly IEnumerable<string> Paths = new List<string>
            {
                "category/reviews",
                "category/tour-de-force",
                "category/cinemetal"
            };
            internal const string ReviewsSelector = "article[itemtype='http://schema.org/Review']";
            internal const string ToursSelector = "article[itemtype='http://schema.org/NewsArticle']";
            internal const string VideosSelector = "article[itemtype='http://schema.org/VideoObject']";
            internal const string AuthorSelector = ".content-block .author > a";
            internal const string UriSelector = "span[itemprop='url'] a.full-cover";
            internal const string TilteSelector = ".post-title a";
            internal const string TimeSelector = "time";
            internal const string CategorySelector = "span[itemprop='url'] a.category-tag";
        }

        internal static class SqliteConstants
        {
            internal const string ConnectionString = "Data Source=venom.db";
        }
    }
}