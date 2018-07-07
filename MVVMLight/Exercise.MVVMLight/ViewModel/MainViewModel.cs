using Exercise.MVVMLight.Data;
using Exercise.MVVMLight.User;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Exercise.MVVMLight.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IStorage storage)
        {
            var fakeData = storage.GetUsers();

            AssignCommands();

            Users = new ObservableCollection<UserViewModel>(fakeData);
        }

        public ObservableCollection<UserViewModel> Users { get; set; }

        public ICommand Delete { get;  private set; }
        public ICommand Create { get;  private set; }

        private void AssignCommands()
        {
            Delete = new RelayCommand<UserViewModel>(a => Users.Remove(a));

            Create = new RelayCommand(() => Users.Add(new UserViewModel { FirstName = "" }));
        }
    }
}