using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Delete(T entity);
        void Update(T entity);

    }
}
