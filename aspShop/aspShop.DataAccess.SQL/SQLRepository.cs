using aspShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : class, IBaseProps
    {
        internal DatаContext context;
        internal DbSet<T> DbSet;
        public string Name { get; set; }

        public SQLRepository(DatаContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return DbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = Find(id);
            if (context.Entry(item).State == EntityState.Detached)
            {
                DbSet.Attach(item);
            }
            DbSet.Remove(item);
        }

        public T Find(string id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T item)
        {
            DbSet.Add(item);
        }

        public void Update(T item)
        {
            DbSet.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
