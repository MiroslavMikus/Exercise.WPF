using Prism.Mvvm;
using System;

namespace Exercise.Prism.User.ViewModels
{
    public class UserViewModel : BindableBase
    {
        public UserViewModel(Data.User user)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
        }

        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        private string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }
    }
}
