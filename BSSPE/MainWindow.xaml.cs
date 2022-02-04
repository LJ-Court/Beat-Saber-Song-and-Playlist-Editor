using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Windows.Storage.Pickers;
using Microsoft.UI.Xaml.Navigation;
using System;
using Steamworks;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private AppId_t[] m_AppList;
        private string appDir;
        
        public MainWindow()
        {
            this.InitializeComponent();
            Classes.Utils.GetSteamDir();


            this.Title = "Beat Saber Song and Playlist Manager";
            contentFrame.Navigate(typeof(SongsPage));
            
        }

        private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(Settings));
            }
            else
            {
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
            
        }

        public async void selectDirectory()
        {

            FolderPicker folderPicker = new FolderPicker();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            folderPicker.FileTypeFilter.Add("*");

            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder.Path != null)
            {
                Properties.appSettings.Default.installDir = folder.Path;
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "songPage":
                    contentFrame.Navigate(typeof(SongsPage));
                    break;
                case "changeInstallDirectory":
                    selectDirectory();
                    break;
            }
        }

        private void nvSample_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in nvSample.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "songPage")
                {
                    nvSample.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
