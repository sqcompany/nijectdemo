using System.Linq;
using Entities.Abstract;
using Entities.Entities;

namespace Entities.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IQueryable<Book> Books
        {
            get { return _context.Books; }
        }
    }
}
