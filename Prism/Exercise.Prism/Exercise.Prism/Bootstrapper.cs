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
    }
}
