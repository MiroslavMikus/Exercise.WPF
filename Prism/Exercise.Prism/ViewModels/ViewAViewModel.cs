using Exercise.PrismBasic.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace Exercise.PrismBasic.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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

            _eventAggregator.GetEvent<UpdateEvent>().Publish(UpdatedTime.ToString());
        }

        private readonly IEventAggregator _eventAggregator;

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
