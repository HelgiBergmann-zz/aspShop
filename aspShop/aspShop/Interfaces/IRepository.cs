using System.Linq;
using aspShop.Interfaces;

namespace aspShop.Interfaces
{
    public interface IRepository<T>
    {
        string Name { get; set; }

        IQueryable<T> Collection();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T item);
        void Update(T item);
    }
}