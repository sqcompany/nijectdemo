using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using domain.Entities;

namespace domain.Abstract
{
    public interface IBookRepository
    {
        IQueryable<book> Books { get; }
    }
}
