using System.Collections.Generic;

namespace Exercise.Prism.User.Data.Repository
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        void Delete(T entity);
        void Update(T entity);
    }
}
