using Microsoft.EntityFrameworkCore;

namespace kpz_ex.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
      : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Data Source=DESKTOP-913P33T\\IHORTY;Initial Catalog=db_ex;Integrated Security=True;TrustServerCertificate=True;Encrypt=false");

        public DbSet<Book> Books { get; set;}

    }
}
