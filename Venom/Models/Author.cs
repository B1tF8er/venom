namespace Venom
{
    using System;

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => $"Name: {Name}, Uri: {Uri}, Date: {Date}";
    }    
}
