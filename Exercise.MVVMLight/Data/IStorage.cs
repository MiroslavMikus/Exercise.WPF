using System.Collections.Generic;

namespace Exercise.MVVMLight.Data
{
    public interface IStorage
    {
        IEnumerable<User> GetUsers();
    }
}
