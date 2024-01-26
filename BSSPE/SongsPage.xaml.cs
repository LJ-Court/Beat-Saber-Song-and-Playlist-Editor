using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Steamworks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
using Windows.Storage.Pickers;
using System.IO.Compression;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BSSPE
{
    /// <summary>
    /// This page is used to display information relating to each song
    /// </summary>
    public sealed partial class SongsPage : Page
    {
        private string dirPath = "D:\\SteamLibrary\\steamapps\\common\\Beat Saber\\Beat Saber_Data\\CustomLevels";
        private List<string> songsList;
        private utilityFiles utilityFiles = new utilityFiles();


        public SongsPage()
        {
            this.InitializeComponent();
            generateSong();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            generateSong();
        }

        public async void selectDirectory()
        {

            FolderPicker folderPicker = new FolderPicker();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            folderPicker.FileTypeFilter.Add("*");

            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                if (folder.Path != null)
                {
                    Debug.WriteLine(folder.Path);
                    Properties.appSettings.Default.installDir = folder.Path;
                }
                else
                {
                    ;
                }
            }

        }

        private void generateSong()
        {
            songList.MenuItems.Clear();
            if (Properties.appSettings.Default.installDir == "")
            {
                ContentDialog dialog = new ContentDialog();

                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                dialog.XamlRoot = this.XamlRoot;
                dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                dialog.Title = "No Beat Saber Folder found";
                dialog.PrimaryButtonText = "Select Folder";
                dialog.CloseButtonText = "Quit";
                dialog.DefaultButton = ContentDialogButton.Primary;

                dialog.PrimaryButtonClick += (d, e) => selectDirectory();
            }
            else
            {
                songsList = new List<string>();
                //songListText.Text = "";
                var dirs = Directory.GetDirectories(Properties.appSettings.Default.installDir + "\\Beat Saber_Data\\CustomLevels");
                if (dirs == null)
                {
                    ;
                }
                else
                {
                    foreach (string dir in dirs)
                    {
                        NavigationViewItem navItem = newSong(dir);
                        songList.MenuItems.Add(navItem);

                    }
                }
            }    
        }

        private NavigationViewItem newSong(string dir)
        {
            string songName;
            // read info file
            var json = File.ReadAllText(dir + "\\info.dat");
            SongProperties info = JsonConvert.DeserializeObject<SongProperties>((string)json);
            // songListText.Text += info._songName + "\n";
            // output each song name to console
            Debug.WriteLine($"{info._songName}");

            // create menu item for song
            NavigationViewItem navigationViewItem = new NavigationViewItem();
            navigationViewItem.Tag = dir;
            navigationViewItem.Name = info._songName;
            navigationViewItem.Content = info._songName;

            // add info._songName to songList
            songName = info._songName.ToString();
            songsList.Append(songName);

            return navigationViewItem;
        }

        private void songList_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            switch (item.Tag)
            {
                default:
                    {
                        ;
                        loadSong(item as NavigationViewItem);
                        break;
                    }
            }
        }

        private void loadSong(NavigationViewItem item)
        {
            var json = File.ReadAllText(item.Tag + "\\info.dat");
            SongProperties info = JsonConvert.DeserializeObject<SongProperties>((string)json);

            createFrame(item.Tag.ToString(), info);
        }

        private void createFrame(string dir, SongProperties info)
        {
            songName.Text = info._songName;
            songAuthor.Text = "Song Author: " + info._songAuthorName;
            levelAuthor.Text = "Level Author: " + info._levelAuthorName;
            beatsPerMinute.Text = "Beats Per Minute: " + info._beatsPerMinute.ToString();
            environmentName.Text = "Environment Name: " + info._environmentName;
            levelImage.Source = new BitmapImage(new Uri(dir + "\\" + info._coverImageFilename));
        }

        public async void addSong(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Adding new song");
            var openPicker = new FileOpenPicker();

            // Get the current window's HWND by passing in the Window object
            var hwnd = WinUIEx.HwndExtensions.GetActiveWindow();

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hwnd);

            // Set options for your file picker
            openPicker.FileTypeFilter.Add(".zip");

            // Open the picker for the user to pick a file
            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var songDir = (Properties.appSettings.Default.installDir + "\\Beat Saber_Data\\CustomLevels\\" + file.Name);
                ZipFile.ExtractToDirectory(file.Path, songDir);
                NavigationViewItem navItem = newSong(songDir);
                songList.MenuItems.Add(navItem);
            }

        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
