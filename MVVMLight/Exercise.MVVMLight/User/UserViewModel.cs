using Exercise.MVVMLight.Data;

namespace Exercise.MVVMLight.User

{
    public class UserViewModel : ValidObservableObject<UserViewModel>
    {
        public UserViewModel() : base(UserValidator.Singleton.Value, ViewModelState.Valid) { }

        private string _firstName;
        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }

        private string _secondName;
        public string SecondName { get => _secondName; set => Set(ref _secondName, value); }

        private int _age;
        public int Age { get => _age; set => Set(ref _age, value); }
    }
}
