namespace Venom
{
    using HtmlAgilityPack;
    using System;

    internal class Parser
    {
        private readonly Type type;
        private readonly Uri uri;

        internal Parser(Type type, Uri uri)
        {
            this.type = type;
            this.uri = uri;
        }

        internal void Parse(HtmlDocument html)
        {
            if (uri.PathAndQuery.Contains("tour"))
                ParseTours(html);
            if (uri.PathAndQuery.Contains("review"))
                ParseReviews(html);
            if (uri.PathAndQuery.Contains("video") || uri.PathAndQuery.Contains("cine"))
                ParseVideos(html);
        }

        private void ParseTours(HtmlDocument html)
        {
            var articles = html.DocumentNode.SelectNodes("//article");

            if (type == Type.MetalInjection)
            {

            }
            else if (type == Type.MetalSucks)
            {

            }

            // TODO: convert to local model then save to DB
        }

        private void ParseReviews(HtmlDocument html)
        {
            var articles = html.DocumentNode.SelectNodes("//article");

            if (type == Type.MetalInjection)
            {

            }
            else if (type == Type.MetalSucks)
            {
                
            }

            // TODO: convert to local model then save to DB
        }

        private void ParseVideos(HtmlDocument html)
        {
            var articles = html.DocumentNode.SelectNodes("//article");

            if (type == Type.MetalInjection)
            {

            }
            else if (type == Type.MetalSucks)
            {
                
            }

            // TODO: convert to local model then save to DB
        }
    }
}