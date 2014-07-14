using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class EntityRepository<TContext, TObject> : IRepository<TObject>
        where TContext : DbContext
        where TObject : class
    {
        // ReSharper disable InconsistentNaming
        protected TContext context;
        // ReSharper restore InconsistentNaming
        // ReSharper disable InconsistentNaming
        protected DbSet<TObject> dbSet;
        // ReSharper restore InconsistentNaming
        protected bool IsOwnContext = false;

        /// <summary>
        /// Gets the data context object.
        /// </summary>
        protected virtual TContext Context { get { return context; } }
        /// <summary>
        /// Gets the current DbSet object.
        /// </summary>
        protected virtual DbSet<TObject> DbSet { get { return dbSet; } }

        /// <summary>
        /// Dispose the class.
        /// </summary>
        public void Dispose()
        {
            if ((IsOwnContext) && (Context != null))
                Context.Dispose();
            GC.SuppressFinalize(this);
        }
        public virtual IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public virtual bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual int Count(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject TObject)
        {
            var newEntry = DbSet.Add(TObject);
            if (IsOwnContext)
                Context.SaveChanges();
            return newEntry;
        }

        public virtual void Delete(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Remove(TObject);
            if (IsOwnContext)
                Context.SaveChanges();

        }

        public virtual int Delete(Expression<Func<TObject, bool>> predicate)
        {
            var objects = DbSet.Where(predicate).ToList();
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return IsOwnContext ? Context.SaveChanges() : objects.Count();
        }

        public virtual TObject Update(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (IsOwnContext)
                Context.SaveChanges();
            return TObject;
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public int Submit()
        {
            return Context.SaveChanges();
        }
    }
}
