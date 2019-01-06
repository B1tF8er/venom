namespace Venom
{
    using HtmlAgilityPack;
    
    public interface IParser
    {
        void ParseReviews(HtmlDocument html);
        void ParseTours(HtmlDocument html);
        void ParseVideos(HtmlDocument html);
    }
}
