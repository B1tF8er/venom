namespace Venom
{
    using Microsoft.EntityFrameworkCore;
    using static Constants.Sqlite;

    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(ConnectionString);
    }
}
