using Autofac;
using Exercise.MVVMLight.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Exercise.MVVMLight.ViewModel
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>();

            builder.RegisterType<FakeStorage>().As<IStorage>();

            ViewModelContainer = builder.Build();
        }

        public IContainer ViewModelContainer;

        public MainViewModel Main
        {
            get
            {
                return ViewModelContainer.Resolve<MainViewModel>();
            }
        }
    }
}