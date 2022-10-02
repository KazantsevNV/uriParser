using Clasess;
using Clasess.ViewModels;
using System.Windows;

namespace URIParserProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UriParserWindow : Window
    {
        public UriParserWindow()
        {
            InitializeComponent();
            var parser = new Parser();
            DataContext = new UriParserViewModel(parser);
        }
    }
}
