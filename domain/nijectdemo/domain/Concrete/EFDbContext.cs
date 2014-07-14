using System.Data.Entity;
using Entities.Entities;

namespace Entities.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
