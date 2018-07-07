using Exercise.MVVMLight.User;
using System.Collections.Generic;

namespace Exercise.MVVMLight.Data
{
    public interface IStorage
    {
        IEnumerable<UserViewModel> GetUsers();
    }
}
