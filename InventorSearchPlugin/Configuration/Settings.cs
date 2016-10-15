using System;
using System.IO;
using System.Windows.Forms;
using InvAddIn.UI;
using InventorSearchPlugin.Entries;
using Newtonsoft.Json;

namespace InventorSearchPlugin.Configuration
{
    public static class Settings
    {
        public static string SaveInFolder { get; set; }
        public static string LoadFromFolder { get; set; }
        public static string Host { get; set; }
        public static string Port { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static string DbName { get; set; }

        public static void InitSettings()
        {
            if (
                File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            "Search3DModelSettings.json"))
            {
                using (StreamReader settings =
                        File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                        "Search3DModelSettings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    SaveSettings loadSettings = (SaveSettings)serializer.Deserialize(settings, typeof(SaveSettings));

                    Settings.SaveInFolder = loadSettings.SaveInFolderPathsList[0];
                    Settings.Host = loadSettings.Host;
                    Settings.Port = loadSettings.Port;
                    Settings.User = loadSettings.User;
                    Settings.Password = loadSettings.Password;
                    Settings.DbName = loadSettings.DbName;
                }
            }
            else
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.Show();
            }
        }
    }
}