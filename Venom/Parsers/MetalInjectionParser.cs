namespace Venom
{
    using HtmlAgilityPack;
    using System;

    internal class MetalInjectionParser : IParser
    {
        internal MetalInjectionParser()
        {
        }

        public void Parse(HtmlDocument html, Uri uri)
        {
            if (uri.IsTourCategory())
                ParseTours(html);
            else if (uri.IsReviewCategory())
                ParseReviews(html);
            else if (uri.IsVideoCategory())
                ParseVideos(html);
        }

        private void ParseReviews(HtmlDocument html)
        {
            return;
        }

        private void ParseTours(HtmlDocument html)
        {
            return;
        }

        private void ParseVideos(HtmlDocument html)
        {
            return;
        }
    }
}
