using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using Exercise.Prism.User.Views;

namespace Exercise.Prism.User
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
