using Exercise.MVVM.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Exercise.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IStorage storage)
        {
            var fakeData = storage.GetUsers();

            AssignCommands();

            Users = new ObservableCollection<User>(fakeData);
        }

        public ObservableCollection<User> Users { get; set; }

        public ICommand Delete { get;  private set; }
        public ICommand Create { get;  private set; }

        private void AssignCommands()
        {
            Delete = new RelayCommand<User>(a => Users.Remove(a));

            Create = new RelayCommand(() => Users.Add(new User { FirstName = "" }));
        }
    }
}