using Exercise.MVVMLight.User;
using System.Collections.Generic;

namespace Exercise.MVVMLight.Data
{
    public class FakeStorage : IStorage
    {
        public IEnumerable<UserViewModel> GetUsers()
        {
            return new List<UserViewModel>()
            {
                new UserViewModel
                {
                    FirstName  = "Miroslav",
                    SecondName = "Mikus",
                    Age = 25
                },
                new UserViewModel
                {
                    FirstName = "Nertil",
                    SecondName = "Porci",
                    Age = 24
                },
                new UserViewModel
                {
                    FirstName = "Mohamad",
                    SecondName = "Sawas",
                    Age = 30
                }
            };
        }
    }
}
