using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniversalWindows.Common;
using UniversalWindows.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindows
{
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class ManagementPage : Page
    {
        List<PersonModel> _savedUsers = new List<PersonModel>();

        public ManagementPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TemplatePage));
        }

        private async void SaveUserListButton_Click(object sender, RoutedEventArgs e)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
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
                var contents = ApplicationUtilities.GetExtractReportData();

                await Windows.Storage.FileIO.WriteTextAsync(file, await contents);
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
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

        private async void clearListButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to clear the List?");
            dialog.Title = "Continue?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                ApplicationUtilities.ClearList();
                textBlock.Text = "Your List has been cleared. ";
                return;
            }
            textBlock.Text = "";
        }

        private async void WinnerButton_Click(object sender, RoutedEventArgs e)
        {
            var savedUsers = await ApplicationUtilities.GetSavedUsers();
            if (savedUsers == null || savedUsers.Count == 0)
                return;

            Random x = new Random();            
            int winner = x.Next(1,savedUsers.Count+1);
            winnerTextMessage.Text = "And the Winner is..." + Environment.NewLine + savedUsers[winner-1].Name  + Environment.NewLine + savedUsers[winner-1].Email;


        }

        private async void Exitbutton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to Exit TradeShow Wonder?");
            dialog.Title = "Continue?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                ApplicationUtilities.CloseApplication();
            }
            
        }

        private void templatePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TemplatePage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _savedUsers = await ApplicationUtilities.GetSavedUsers();
            textBlock.Text = "Current Users: " + _savedUsers?.Count ?? "0";
        }
    }
}
