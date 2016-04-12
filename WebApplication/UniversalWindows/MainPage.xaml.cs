using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore_CampusDish.Common;
using Microsoft.Advertising.WinRT.UI;
using PersonModel = UniversalWindows.Model.PersonModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
              
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var loadExistingData = await loadData();
            var peopleList = new List<PersonModel>();
            var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);
            var person = new PersonModel(Name.Text, Email.Text, Phone.Text);
            if (loadExistingData != null)
            {                
                loadExistingData.Add(person);
                storageHelper.SaveASync(loadExistingData, @"Richard2.txt");
            }
            else
            {
                peopleList.Add(person);
                storageHelper.SaveASync(peopleList, @"Richard2.txt");
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
    }
}
