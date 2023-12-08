using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using WinUIEx;
using System.Collections.Generic;
using System.IO;
using Windows.Storage.Pickers;
using System.Linq;
using WinRT;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Microsoft.WindowsAPICodePack.Dialogs;
using Windows.Foundation.Collections;
using Windows.Storage;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BSSPE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();

            var hwnd = WinUIEx.HwndExtensions.GetActiveWindow();

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

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
    }
}
