using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniversalWindows.Common;
using UniversalWindows.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagementPage : Page
    {
        public ManagementPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Task<string> contents;
                contents = GetData();

                await Windows.Storage.FileIO.WriteTextAsync(file, await contents);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    textBlock.Text = "File " + file.Name + " was saved.";
                }
                else
                {
                    textBlock.Text = "File " + file.Name + " couldn't be saved.";
                }
            }
            else
            {
                textBlock.Text = "Operation cancelled.";
            }


        }

        public string WriteData(List<PersonModel> savedUsers)
        {
            string writeText = "";
            if (savedUsers == null)
                return writeText;
            foreach (var model in savedUsers)
                writeText = writeText + PrintPersonModel(model);
            return writeText;
        }

        public async Task<string> GetData()
        {
            string writeText = "";
            var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
            var loadExistingData = await test.LoadASync("Settings.xml");
            if (loadExistingData == null)
                return writeText;
            foreach (var model in loadExistingData)
                writeText = writeText + PrintPersonModel(model);

            return writeText;
        }

        public async Task<List<PersonModel>> GetSavedUsers()
        {
            var peopleList = new List<PersonModel>();
            var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
            peopleList = await test.LoadASync("Settings.xml");
            return peopleList;
        }

        private static string PrintPersonModel(PersonModel model)
        {
            return (model.Name + "," + model.Email + "," + model.Phone + Environment.NewLine);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ClearList();
        }

        public static void ClearList()
        {
            var peopleList = new List<PersonModel>();
            var storageHelper = new StorageHelper<List<PersonModel>>(StorageType.Local);
            storageHelper.SaveASync(peopleList, "Settings");
        }

        private async void WinnerButton_Click(object sender, RoutedEventArgs e)
        {
            var savedUsers = await GetSavedUsers();
            if (savedUsers.Count == 0)
                return;

            Random x = new Random();            
            int winner = x.Next(1,savedUsers.Count);
            winnerTextMessage.Text = "And the Winner is..." + savedUsers[winner-1].Name  + " " + savedUsers[winner-1].Email;


        }
    }
}
