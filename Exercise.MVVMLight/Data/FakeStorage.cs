using System.Collections.Generic;

namespace Exercise.MVVMLight.Data
{
    public class FakeStorage : IStorage
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User
                {
                    FirstName  = "Miroslav",
                    SecondName = "Mikus",
                    Age = 25
                },
                new User
                {
                    FirstName = "Nertil",
                    SecondName = "Porci",
                    Age = 24
                },
                new User
                {
                    FirstName = "Mohamad",
                    SecondName = "Sawas",
                    Age = 30
                }
            };
        }
    }
}
