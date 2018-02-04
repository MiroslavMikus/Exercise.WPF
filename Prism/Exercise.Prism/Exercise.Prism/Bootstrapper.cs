using Exercise.Prism.Views;
using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Exercise.Prism
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

            Container.RegisterTypeForNavigation<ViewA>("ViewA");
            Container.RegisterTypeForNavigation<ViewB>("ViewB");
        }
    }
}
