﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Advertising.WinRT.UI;
using UniversalWindows.Common;
using PersonModel = UniversalWindows.Model.PersonModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
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
            var validation = new PersonBusiness();
            var validate = validation.ValidatePerson(person);

            if (validate.isValid)
            {
                var loadExistingData = await ApplicationUtilities.GetSavedUsers();                
                var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);

                if (loadExistingData == null)
                {
                    var peopleList = new List<PersonModel> {person};
                    storageHelper.SaveASync(peopleList, "Settings");
                }
                else
                {
                    loadExistingData.Add(person);
                    storageHelper.SaveASync(loadExistingData, "Settings");
                }
            }
            else
                ErrorText.Text = validate.errorMessage;
        }

        private void AdControl_OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
        }

        private void OnloadedComplete(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
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

        public void ClearErrorMessage()
        {
            ErrorText.Text = "";
        }

    }
}
