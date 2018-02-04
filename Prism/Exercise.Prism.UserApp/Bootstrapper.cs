using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using Exercise.Prism.User.Views;
using Exercise.Prism.User.Data.Repository;

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

            Container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<UserDetail>(nameof(UserDetail));
        }
    }
}
