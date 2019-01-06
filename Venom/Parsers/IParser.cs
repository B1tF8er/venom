namespace Venom
{
    using HtmlAgilityPack;
    using System;
    
    public interface IParser
    {
        void Parse(HtmlDocument html, Uri uri);
    }
}
