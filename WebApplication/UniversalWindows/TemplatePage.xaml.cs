using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Microsoft.Advertising.WinRT.UI;
using UniversalWindows.Common;
using UniversalWindows.Model;

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClearErrorMessage();
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel(firstNameTextBox.Text, emailAddressTextBox.Text, PhoneNumberTextBox.Text);
            var validation = new PersonBusiness();
            var validate = validation.ValidatePerson(person);

            if (validate.isValid)
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
                ErrorMessageTextBlock.Text = validate.errorMessage;
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
    }
}
