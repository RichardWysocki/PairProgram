using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using UniversalWindows.Model;

namespace UniversalWindows.Common
{
    public class ApplicationUtilities
    {
        public static void CloseApplication()
        {
            Application.Current.Exit();
        }

        public static async Task<List<PersonModel>> GetSavedUsers()
        {
            var peopleList = new List<PersonModel>();
            var storage = new StorageHelper<List<PersonModel>>(StorageType.Local);
            peopleList = await storage.LoadASync("Settings.xml");
            return peopleList;
        }

    }
}
