using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using domain.Entities;

namespace domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<book> Books { get; set; }
    }
}
