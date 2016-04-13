using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Advertising.WinRT.UI;
using UniversalWindows.Common;
using PersonModel = UniversalWindows.Model.PersonModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
              
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var person = new PersonModel(Name.Text, Email.Text, Phone.Text);

            if (ValidatePerson(person))
            { 
                var loadExistingData = await loadData();
                var peopleList = new List<PersonModel>();
                var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);
                
                if (loadExistingData != null)
                {                
                    loadExistingData.Add(person);
                    storageHelper.SaveASync(loadExistingData, "Settings");
                }
                else
                {
                    peopleList.Add(person);
                    storageHelper.SaveASync(peopleList, "Settings");
                }
            }
        }

        private void AdControl_OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
        }

        private async void OnloadedComplete(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                await loadData();
            }
        }

        private async Task<List<PersonModel>> loadData()
        {
            var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
            List<PersonModel> peopleList;
            try
            {
                peopleList = await test.LoadASync(@"Settings.xml");
            }
            catch (Exception)
            {
                peopleList = null;
            }

            return peopleList;
        }

        private void NavToManagement_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementPage));
        }

        private bool ValidatePerson(PersonModel person)
        {
            ClearErrorMessage();
            return ValidateAllFieldsComplete(person) && ValidateEmail(person.Email) && IsPhone(person.Phone);
        }

        private bool ValidateAllFieldsComplete(PersonModel person)
        {
            var validateName = person.Email.Length > 0 & person.Name.Length > 0 & person.Phone.Length > 0;
            if (validateName)
                return true;
            ErrorText.Text = "Please Complete all fields...";
            return false;
        }

        private bool ValidateEmail(string personEmail)
        {
            string email = personEmail;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            ErrorText.Text = "Please Enter a Valid Email Address...";
            return false;
            //if (match.Success)
            //    lbl_message.Text = email + " is Valid Email Address";
            //else
            //    lbl_message.Text = email + " is Invalid Email Address";
        }

        private bool IsPhone(string strPhone)
        {
            var objPhonePattern = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            var validatePhone = objPhonePattern.IsMatch(strPhone);
            if (validatePhone)
                return true;
            ErrorText.Text = "Please Enter a Valid Phone #...";
            return false;
        }

        public void ClearErrorMessage()
        {
            ErrorText.Text = "";
        }

    }
}
