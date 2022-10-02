using System.Windows;

namespace URIParserProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            UriParserWindow window = new UriParserWindow();
            window.Show();
        }
    }
}
