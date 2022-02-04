using Microsoft.Win32;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Storage.Pickers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BSSPE.Classes
{
    internal class Utils
    {

        public static void setDir(string installDir)
        {
            Properties.appSettings.Default.installDir = installDir;
            Properties.appSettings.Default.Save();
        }
        
        
        // This code gets the Steam Directory that's in use, code originally developed by ModAssistant Developers and being used under the MIT license
        public static string GetSteamDir()
        {

            string SteamInstall = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)?.OpenSubKey("SOFTWARE")?.OpenSubKey("WOW6432Node")?.OpenSubKey("Valve")?.OpenSubKey("Steam")?.GetValue("InstallPath").ToString();
            if (string.IsNullOrEmpty(SteamInstall))
            {
                SteamInstall = Registry.LocalMachine.OpenSubKey("SOFTWARE")?.OpenSubKey("WOW6432Node")?.OpenSubKey("Valve")?.OpenSubKey("Steam")?.GetValue("InstallPath").ToString();
            }

            if (string.IsNullOrEmpty(SteamInstall)) return null;

            string vdf = Path.Combine(SteamInstall, @"steamapps\libraryfolders.vdf");
            if (!File.Exists(@vdf)) return null;

            Regex regex = new Regex("\\s\"(?:\\d|path)\"\\s+\"(.+)\"");
            List<string> SteamPaths = new List<string>
            {
                Path.Combine(SteamInstall, @"steamapps")
            };

            using (StreamReader reader = new StreamReader(@vdf))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        SteamPaths.Add(Path.Combine(match.Groups[1].Value.Replace(@"\\", @"\"), @"steamapps"));
                    }
                }
            }

            regex = new Regex("\\s\"installdir\"\\s+\"(.+)\"");
            foreach (string path in SteamPaths)
            {
                if (File.Exists(Path.Combine(@path, @"appmanifest_" + "620980" + ".acf")))
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(@path, @"appmanifest_" + "620980" + ".acf")))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Match match = regex.Match(line);
                            if (match.Success)
                            {
                                if (File.Exists(Path.Combine(@path, @"common", match.Groups[1].Value, "Beat Saber.exe")))
                                {
                                    setDir(Path.Combine(@path, @"common", match.Groups[1].Value).ToString());
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public async void pickDir()
        {
            FolderPicker folderPicker = new FolderPicker();

            var hwnd = WinUIEx.HwndExtensions.GetActiveWindow();

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            folderPicker.FileTypeFilter.Add("*");

            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder.Path != null)
            {
                setDir(folder.Path);
            }
            else
            {
                Properties.appSettings.Default.installDir = "";
            }
        }

        public async void checkDir(string baseDir)
        {
            if (!Directory.Exists(baseDir) && !Directory.Exists(baseDir + "\\Beat Saber_Data\\CustomLevels"))
            {
                Properties.appSettings.Default.installDir = baseDir;
                Properties.appSettings.Default.songsDir = baseDir + "\\Beat Saber_Data\\CustomLevels";
            }
            else
            {
                
            }

            Properties.appSettings.Default.Save();
        }

    }
}