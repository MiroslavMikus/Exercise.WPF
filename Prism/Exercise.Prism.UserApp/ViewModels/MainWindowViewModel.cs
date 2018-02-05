using Exercise.Prism.User.Data;
using Exercise.Prism.User.Data.Repository;
using Exercise.Prism.User.Events;
using Exercise.Prism.User.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
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
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public MainWindowViewModel(IUserRepository userRepository,
                                   IRegionManager regionManager,
                                   IEventAggregator eventAggregator)
        {
            _userRepository = userRepository;

            _eventAggregator = eventAggregator;

            _regionManager = regionManager;

            CreateCommands();

            LoadData();

            IsEditing = false;

            eventAggregator.GetEvent<EditClosed>().Subscribe(CloseEdit);
        }


        #region Data
        private void LoadData()
        {
            var users = _userRepository.GetAll().Select(a => new UserViewModel(a));
            Users = new ObservableCollection<UserViewModel>(users);
            RaisePropertyChanged("Users");
        }
        public ObservableCollection<UserViewModel> Users { get; set; }
        #endregion

        #region ICommand
        private void CreateCommands()
        {
            Create = new DelegateCommand(CreateUser, CanEdit)
                            .ObservesProperty(() => IsEditing);

            Edit = new DelegateCommand<int?>(EditUser, a => CanEdit())
                .ObservesProperty(() => IsEditing);

            Delete = new DelegateCommand<int?>(DeleteUser, a => CanEdit())
                .ObservesProperty(() => IsEditing);
        }


        private bool CanEdit()
        {
            return !IsEditing;
        }

        public DelegateCommand<int?> Edit { get; private set; }
        private void EditUser(int? userId)
        {
            var parameters = new NavigationParameters();

            parameters.Add("id", userId);
            // swap view
            _regionManager.RequestNavigate("ContentRegion", nameof(UserDetail), parameters);

            IsEditing = true;
        }

        public DelegateCommand Create { get; private set; }
        private void CreateUser()
        {
            var newUser = new Data.User { FirstName = "" };

            newUser = _userRepository.Create(newUser);

            Users.Add(new UserViewModel(newUser));

            EditUser(newUser.UserId);
        }

        public DelegateCommand<int?> Delete { get; private set; }
        private void DeleteUser(int? Id)
        {
            var user = _userRepository.GetAll().Where(a => a.UserId == Id).First();

            _userRepository.Delete(user);

            LoadData();
        }

        #endregion

        #region States
        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }
        private void CloseEdit(bool obj)
        {
            IsEditing = false;
            LoadData();
        }
        #endregion
    }
}
