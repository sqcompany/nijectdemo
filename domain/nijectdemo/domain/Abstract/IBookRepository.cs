using System.Linq;
using Entities.Entities;

namespace Entities.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
