using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.Data.Repository
{
    public abstract class InMemoryRepository<T> : IRepository<T>
    {
        public InMemoryRepository(List<T> data)
        {
            memory = data;
        }

        protected List<T> memory;

        public void Delete(T entity)
        {
            memory.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return memory;
        }

        public abstract void Update(T entity);
        public abstract T Create(T entity);
    }
}
