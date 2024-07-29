using bs_data.Entities;
using bs_data.Views;
using Microsoft.EntityFrameworkCore;

namespace bs_data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<PriceTable> PriceTable { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<BookSubject> BookSubject { get; set; }
        public DbSet<BookPriceTable> BookPriceTable { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookCode, ba.AuthorCode });
            modelBuilder.Entity<BookSubject>().HasKey(ba => new { ba.BookCode, ba.SubjectCode });
            modelBuilder.Entity<BookPriceTable>().HasKey(ba => new { ba.BookCode, ba.PriceTableCode });

            modelBuilder.Entity<BookView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("BookView");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
