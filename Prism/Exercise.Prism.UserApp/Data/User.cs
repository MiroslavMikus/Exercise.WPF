using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.Data
{
    public class User
    {
        public User()
        {
            UpdatedAt = DateTime.Now;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
