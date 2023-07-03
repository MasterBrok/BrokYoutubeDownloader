using BrokYoutubeDownloader.Windows;
using System.Windows;

namespace BrokYoutubeDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            _ = new wMeessageBox(e.Exception.Message).ShowDialog();
        }
    }
}
