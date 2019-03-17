namespace Venom
{
    public class Article
    {
        public int Id { get; set; }

        public string Uri { get; set; }
        
        public string Title { get; set; }
        
        public string Category { get; set; }
        
        public Author Author { get; set; }


        public override string ToString() => $"Uri: {Uri}, Title: {Title}, Category: {Category}, Author: [{Author}]";
    }
}
