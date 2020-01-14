using aspShop.Interfaces;
using aspShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace aspShop.DataAccess.InMemory
{

    public class MemoryRepository<T> : IRepository<T> where T : IBaseProps
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        public string Name { get; set; }
        public MemoryRepository()
        {
            Name = typeof(T).Name;
            items = cache[Name] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[Name] = items;
        }

        public void Insert(T item)
        {
            items.Add(item);
        }

        public void Update(T item)
        {
            var itemToUpdate = items.FirstOrDefault(i => i.Id == item.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate = item;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public T Find(string id)
        {
            var item = items.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                items.Remove(item);
            }
            else
            {
                throw new Exception("Product not found");
            }

        }
    }
}
