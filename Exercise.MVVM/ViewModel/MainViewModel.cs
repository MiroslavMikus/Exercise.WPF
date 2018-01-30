using GalaSoft.MvvmLight;

namespace Exercise.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Test = "Some test";
            RaisePropertyChanged("Test");
        }


        private string _test;
        public string Test
        {
            get => _test;
            set => Set(ref _test, value);
        }
    }
}