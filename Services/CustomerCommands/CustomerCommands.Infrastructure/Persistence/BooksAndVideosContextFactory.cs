using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CustomerCommands.Infrastructure.Persistence
{
    public class BooksAndVideosContextFactory : IDesignTimeDbContextFactory<BooksAndVideosContext>
    {
        public BooksAndVideosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksAndVideosContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=BooksAndVideosDb;User Id=sa;Password=ImI12345678;Encrypt=False;");

            return new BooksAndVideosContext(optionsBuilder.Options);
        }
    }
}
