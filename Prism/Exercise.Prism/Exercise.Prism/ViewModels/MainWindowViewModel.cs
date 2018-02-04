using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Exercise.Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {

            Update = new DelegateCommand(ExecuteUpdate, CanUpdate)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => SecondName);
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(SecondName) &&
                   !String.IsNullOrEmpty(FirstName);
        }

        private void ExecuteUpdate()
        {
            UpdatedTime = DateTime.Now;
        }

        public DelegateCommand Update { get; private set; }

        private string _firstName = "John";
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _secondName;
        public string SecondName
        {
            get { return _secondName; }
            set { SetProperty(ref _secondName, value); }
        }

        private DateTime _dateTime;

        public DateTime UpdatedTime
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }

    }
}
