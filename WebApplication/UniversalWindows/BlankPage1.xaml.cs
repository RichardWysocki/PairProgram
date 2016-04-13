using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UniversalWindows.Common;
using UniversalWindows.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
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
                    this.textBlock.Text = "File " + file.Name + " was saved.";
                }
                else
                {
                    this.textBlock.Text = "File " + file.Name + " couldn't be saved.";
                }
            }
            else
            {
                this.textBlock.Text = "Operation cancelled.";
            }


        }

        public async Task<string> GetData()
        {
            string writeText = "";
            var test = new StorageHelper<List<PersonModel>>(StorageType.Local);
            var loadExistingData = await test.LoadASync("Settings.xml");
            if (loadExistingData == null)
                return writeText;

            writeText = loadExistingData.Aggregate(writeText, (current, item) => current + (item.Name + Environment.NewLine));

            return writeText;
        }

    }
}
