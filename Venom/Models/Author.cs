namespace Venom
{
    using System;

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime Date { get; set; }

        public static bool operator ==(Author left, Author right) =>
            left.Equals(right);

        public static bool operator !=(Author left, Author right) =>
            !left.Equals(right);

        public override bool Equals(object obj) =>
            Equals(obj as Author);

        private bool Equals(Author other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                this.Uri == other.Uri &&
                this.Date == other.Date;
        }
        
        public override int GetHashCode()
        {
            var hashCode = 175704;
            var hashProduct = -1521134295;

            hashCode = hashCode * hashProduct + Name.GetHashCode();
            hashCode = hashCode * hashProduct + Uri.GetHashCode();
            hashCode = hashCode * hashProduct + Date.GetHashCode();

            return hashCode;
        }

        public override string ToString() => $"Name: {Name}, Uri: {Uri}, Date: {Date}";
    }    
}
