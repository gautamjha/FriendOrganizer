using Autofac;
using FriendOrganizer.UI.Startup;
using System.Windows;


namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstraper();
            var conatiner = bootstrapper.Bootstrap();
            var mainwindow = conatiner.Resolve<MainWindow>();
            mainwindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled exception " + e.Exception.InnerException);
            e.Handled = true;

        }
    }
}
