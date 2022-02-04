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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BSSPE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongsPage : Page
    {
        private string dirPath = "D:\\SteamLibrary\\steamapps\\common\\Beat Saber\\Beat Saber_Data\\CustomLevels";
        private List<string> songsList;


        public SongsPage()
        {
            this.InitializeComponent();
            generateSong();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            generateSong();
        }

        private void generateSong()
        {
            songsList = new List<string>();
            songList.MenuItems.Clear();
            //songListText.Text = "";
            string songName = "";
            var dirs = Directory.GetDirectories(Properties.appSettings.Default.installDir + "\\Beat Saber_Data\\CustomLevels");
            foreach (string dir in dirs)
            {
                // read info file
                var json = File.ReadAllText(dir + "\\info.dat");
                SongProperties info = JsonConvert.DeserializeObject<SongProperties>((string)json);
                // songListText.Text += info._songName + "\n";

                

                // create menu item for song
                NavigationViewItem navigationViewItem = new NavigationViewItem();
                navigationViewItem.Tag = dir;
                navigationViewItem.Name = info._songName;
                navigationViewItem.Content = info._songName;
                
                // add info._songName to songList
                songName = info._songName.ToString();
                songsList.Append(songName);

                songList.MenuItems.Add(navigationViewItem);

            }    
        }

        private void songList_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            loadSong(item as NavigationViewItem);
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
            //var imageDir = (dir + "\\" + info._coverImageFilename).ToString();
            //BitmapImage bitmapImage = new BitmapImage(new Uri(imageDir));
            //coverImage.Source = bitmapImage;
            songAuthor.Text = "Song Author: " + info._songAuthorName;
            levelAuthor.Text = "Level Author: " + info._levelAuthorName;
            beatsPerMinute.Text = "Beats Per Minute: " + info._beatsPerMinute.ToString();
            environmentName.Text = "Environment Name: " + info._environmentName;
        }
    }
}
