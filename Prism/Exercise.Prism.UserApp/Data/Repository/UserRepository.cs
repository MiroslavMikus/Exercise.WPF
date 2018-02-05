using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.Data.Repository
{
    public class UserRepository : InMemoryRepository<User>, IUserRepository
    {
        public UserRepository() : base(FakeUserList)
        {

        }
        public override void Update(User entity)
        {
            var userToRemove = memory.First(a => a.UserId == entity.UserId);

            memory.Remove(userToRemove);

            memory.Add(entity);
        }

        public override User Create(User entity)
        {
            if (memory.Any())
            {
                var lastId = memory.Max(a => a.UserId);

                entity.UserId = ++lastId;
            }
            else
            {
                entity.UserId = 1;
            }

            memory.Add(entity);

            return entity;
        }

        public override IEnumerable<User> GetAll()
        {
            return base.GetAll().OrderBy(a => a.UserId);
        }

        private static List<User> FakeUserList = new List<User>
        {
            new User
            {
                UserId = 1,
                FirstName = "Miroslav",
                SecondName = "Mikus",
                Age = 20,
            },
            new User
            {
                UserId = 2,
                FirstName = "John",
                SecondName = "Smith",
                Age = 34,
            },new User
            {
                UserId = 3,
                FirstName = "James",
                SecondName = "Brown",
                Age = 23,
            },new User
            {
                UserId = 4,
                FirstName = "Beatrice",
                SecondName = "Wolf",
                Age = 42,
            },
        };
    }
}
