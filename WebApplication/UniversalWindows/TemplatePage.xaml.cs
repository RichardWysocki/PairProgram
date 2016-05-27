using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Advertising.WinRT.UI;
using universalwindows.library.Common;
using universalwindows.library.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class TemplatePage : Page
    {
        AppModel _SavedAppSettings = new AppModel();

        public TemplatePage()
        {
            InitializeComponent();
        }

        private void AdControl_OnErrorOccurred(object sender, AdErrorEventArgs e)
        {

        }

        private void PhoneNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void emailAddressTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private void firstNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        public void ClearUserEntry()
        {
            firstNameTextBox.Text = "";
            emailAddressTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
        }

        public void ClearErrorMessage()
        {
            ErrorMessageTextBlock.Text = "";
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
            saveButton.Focus(FocusState.Keyboard);
            _SavedAppSettings = await ApplicationUtilities.GetAppSettings();
            if (_SavedAppSettings != null && _SavedAppSettings.CompanyImage.Length > 0)
            {
                Uri uri = new Uri(@"ms-appdata:///local/" + _SavedAppSettings.CompanyImage, UriKind.Absolute);
                BitmapSource bSource = new BitmapImage(uri);
                var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.DecodePixelHeight = 300;
                    bitmapImage.DecodePixelWidth = 300;
                    await bitmapImage.SetSourceAsync(fileStream);
                    CompanyImage.Source = bitmapImage;
                }
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                //CompanyImage.Source = file;

            }
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel(firstNameTextBox.Text, emailAddressTextBox.Text, PhoneNumberTextBox.Text);
            var validation = new PersonBusiness();
            var validate = validation.ValidatePerson(person);

            if (validate.IsValid)
            {
                var loadExistingData = await ApplicationUtilities.GetSavedUsers();
                var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);

                if (loadExistingData == null)
                {
                    var peopleList = new List<PersonModel> { person };
                    storageHelper.SaveASync(peopleList, "Settings");
                }
                else
                {
                    loadExistingData.Add(person);
                    storageHelper.SaveASync(loadExistingData, "Settings");
                }
                ErrorMessageTextBlock.Text = "Saved...";
                ClearUserEntry();
            }
            else
            {
                ErrorMessageTextBlock.Text = validate.ErrorMessage;
            }
            saveButton.Focus(FocusState.Keyboard);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void CompanyImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
