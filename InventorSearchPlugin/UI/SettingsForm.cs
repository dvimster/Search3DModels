using System;
using System.IO;
using System.Windows.Forms;
using InventorSearchPlugin.Configuration;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Helpers;
using Newtonsoft.Json;

namespace InvAddIn.UI
{
    public partial class SettingsForm : Form
    {
        private FolderBrowserDialog folderBrowserDialog = null;

        public SettingsForm()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Host = hostTextBox.Text;
            Settings.Port = portTextBox.Text;
            Settings.User = userTextBox.Text;
            Settings.Password = passwordTextBox.Text;
            Settings.DbName = dbNameTextBox.Text;

            if (Validator.Validate(Settings.Host, Settings.Port, Settings.User, Settings.Password, Settings.DbName))
            {
                SaveSettings saveSettings = new SaveSettings();

                saveSettings.SaveInFolderPathsList.Add(Settings.SaveInFolder);
                saveSettings.Host = Settings.Host;
                saveSettings.Port = Settings.Port;
                saveSettings.User = Settings.User;
                saveSettings.Password = Settings.Password;
                saveSettings.DbName = Settings.DbName;

                try
                {
                    using (StreamWriter settingsFile = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "Search3DModelSettings.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(settingsFile, saveSettings);
                    }
                }
                catch (UnauthorizedAccessException exception)
                {
                    MessageBox.Show("You have not access to copy files: " + exception, "Settings - WARNING");
                }
                catch (DirectoryNotFoundException exception)
                {
                    MessageBox.Show("Directory cannot be found: " + exception, "Settings - WARNING");
                }
                catch (FileNotFoundException exception)
                {
                    MessageBox.Show("File does not exist on disk: " + exception, "Settings - WARNING");
                }

                MessageBox.Show("All settings was saved", "Settings");
            }

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            Settings.SaveInFolder = folderBrowserDialog.SelectedPath;
            locationComboBox.Items.Add(Settings.SaveInFolder);
            locationComboBox.SelectedItem = Settings.SaveInFolder;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
        }

        private void LoadSettingsFromFile()
        {
            try
            {
                using (StreamReader settingsFile =
                    File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                  "Search3DModelSettings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    SaveSettings loadSettings = (SaveSettings)serializer.Deserialize(settingsFile, typeof(SaveSettings));

                    Settings.SaveInFolder = loadSettings.SaveInFolderPathsList[0];
                    locationComboBox.Text = Settings.SaveInFolder;

                    Settings.Host = loadSettings.Host;
                    hostTextBox.Text = Settings.Host;

                    Settings.Port = loadSettings.Port;
                    portTextBox.Text = Settings.Port;

                    Settings.User = loadSettings.User;
                    userTextBox.Text = Settings.User;

                    Settings.Password = loadSettings.Password;
                    passwordTextBox.Text = Settings.Password;

                    Settings.DbName = loadSettings.DbName;
                    dbNameTextBox.Text = Settings.DbName;
                }
            }
            catch (FileNotFoundException)
            {
                // ignore
            }

        }
    }
}
