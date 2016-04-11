using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.ViewManagement;
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
            this.InitializeComponent();
        }

        
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var peopleList = new List<PersonModel>();
            if (true)
            {
                var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
                //var peopleList = test.LoadASync(@"Richard1.txt").Result;

                var person = new PersonModel(Name.Text, Email.Text, Phone.Text);
                peopleList.Add(person);

                //var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
                test.SaveASync(peopleList, @"Richard2.txt");
            }

        }

        private void AdControl_OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
        }

        private void OnloadedComplete(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                loadData();
            }
        }

        private async void loadData()
        {
            var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
            List<PersonModel> peopleList; 
                //foreach (var VARIABLE in peopleList.Result)

                try
                {
                    var peopleList1 = test.LoadASync(@"Richard2.txt");
                }
                catch (Exception ex)
                {
                    peopleList = null;
                }
            //{
            //    //
            //    Debug.WriteLine("An exception of type " + "Hello" + " was encountered while attempting to roll back the transaction.");
            //}
        }
    }
}
