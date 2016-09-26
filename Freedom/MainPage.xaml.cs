using Freedom.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Freedom
{
    public sealed partial class MainPage : Page
    {
        public RSShelperClass helperRSS = new RSShelperClass();
        public MainPage()
        {
            this.InitializeComponent();
            helperRSS.Go(ref FeedTemplate, "http://www.azatutyun.am/api/ztvv_eioty");
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultSplit.IsPaneOpen = !DefaultSplit.IsPaneOpen;
        }
    }
}
