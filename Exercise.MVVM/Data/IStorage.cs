using System.Collections.Generic;

namespace Exercise.MVVM.Data
{
    public interface IStorage
    {
        IEnumerable<User> GetUsers();
    }
}
