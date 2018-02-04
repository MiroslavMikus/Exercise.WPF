using Exercise.Prism.User.Data.Repository;
using Exercise.Prism.User.Events;
using Exercise.Prism.User.ViewModels.Validation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels
{
    public class UserDetailViewModel : ValidBindableBase<UserDetailViewModel>, INavigationAware
    {
        private readonly IEventAggregator _eventAggregator;

        public UserDetailViewModel(IUserRepository userRepository,
                                   IRegionNavigationService navigationContext,
                                   IEventAggregator eventAggregator)
            : base(UserDetailValidation.Singleton.Value)
        {
            _userRepository = userRepository;

            _eventAggregator = eventAggregator;

            Save = new DelegateCommand(SaveCommand, () => IsValid)
                .ObservesProperty(()=> FirstName)
                .ObservesProperty(()=> SecondName)
                .ObservesProperty(()=> Age);
        }

        public DelegateCommand Save { get; private set; }
        private void SaveCommand()
        {
            
            _eventAggregator.GetEvent<EditClosed>().Publish(true);
        }

        #region Properties
        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        private string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }

        private string _secondName;
        public string SecondName { get => _secondName; set => SetProperty(ref _secondName, value); }

        private int _age;
        public int Age { get => _age; set => SetProperty(ref _age, value); }

        private DateTime _updatedAt;
        private readonly IUserRepository _userRepository;

        public DateTime UpdatedAt { get => _updatedAt; set => SetProperty(ref _updatedAt, value); }
        #endregion

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var userId = (int)navigationContext.Parameters["id"];

            var user = _userRepository.GetAll().First(a => a.UserId == userId);

            Id = user.UserId;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Age = user.Age;
            UpdatedAt = user.UpdatedAt;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion
    }
}
