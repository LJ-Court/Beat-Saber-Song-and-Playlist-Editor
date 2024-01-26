using System;
using System.Collections.Generic;
using Windows.Storage.Pickers;
using System.Text;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using System.Net;
using System.Net.Http;
using BSSPE.Classes;


namespace BSSPE
{
    internal class utilityFiles
    {

        public async Task addSong() { 
            FileOpenPicker filePicker = new FileOpenPicker();
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            filePicker.FileTypeFilter.Add(".zip");

            var songFile = await filePicker.PickSingleFileAsync();
            if (songFile != null ) { 
                ZipFile.ExtractToDirectory(songFile.Path, (Properties.appSettings.Default.installDir + "\\Beat Saber_Data\\CustomLevels\\" + songFile.Name));
            }
        }

        public async void downloadSong(string downloadString)
        {
            var httpClient = new HttpClient();
            var songFile = await httpClient.GetAsync(downloadString);
        }

        

    }
}
