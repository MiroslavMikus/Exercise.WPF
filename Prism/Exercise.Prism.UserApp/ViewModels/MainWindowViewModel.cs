using Exercise.Prism.User.Data.Repository;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IUserRepository _userRepository;

        public MainWindowViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            var users = _userRepository.GetAll().Select(a => new UserViewModel(a));

            Users = new ObservableCollection<UserViewModel>(users);
        }
        public ObservableCollection<UserViewModel> Users { get; set; }
    }
}
