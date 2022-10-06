using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext>option) :base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(c => c.Book_Authors)
                .HasForeignKey(v => v.BookId);
           
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(c => c.Book_Authors)
                .HasForeignKey(v => v.AuthorId);
        }
         public DbSet<Book> Books { get; set; }
         public DbSet<Author> Authors { get; set; }
         public DbSet<Book_Author> Books_Authors { get; set; }
         public DbSet<Publisher> publishers { get; set; }
    }
}
