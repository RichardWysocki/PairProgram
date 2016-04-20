using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class TemplatePage : Page
    {
        public TemplatePage()
        {
            InitializeComponent();
        }

        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private void AdControl_OnErrorOccurred(object sender, Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
        {

        }
    }
}
