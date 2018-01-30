namespace Exercise.MVVM.Data
{
    public class User : ValidObservableObject<User>
    {
        public User():base(UserValidator.Singleton.Value){}

        private string _firstName;
        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }

        private string _secondName;
        public string SecondName { get => _secondName; set => Set(ref _secondName, value); }

        private int _age;
        public int Age { get => _age; set => Set(ref _age , value); }
    }
}
