using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Prism.User.Data;

namespace Exercise.Prism.User.ViewModels
{
    public class UserViewModel : BindableBase
    {
        public UserViewModel(Data.User user)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Age = user.Age;
            UpdatedAt = user.UpdatedAt;
        }

        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        private string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }

        private string _secondName;
        public string SecondName { get => _secondName; set => SetProperty(ref _secondName, value); }

        private int _age;
        public int Age { get => _age; set => SetProperty(ref _age, value); }

        private DateTime _updatedAt;
        public DateTime UpdatedAt { get => _updatedAt; set => SetProperty(ref _updatedAt, value); }
    }
}
