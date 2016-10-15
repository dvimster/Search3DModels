using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Inventor;
using InventorSearchPlugin.Configuration;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Global;
using InventorSearchPlugin.Helpers;
using InventorSearchPlugin.Implementation;
using InventorSearchPlugin.Infrastructure;
using File = System.IO.File;
using Path = System.IO.Path;

namespace InvAddIn.UI
{
    public partial class AddFromFolderForm : Form
    {
        private FolderBrowserDialog folderBrowserDialog = null;
        private IList<string> filesList = new List<string>();
        private IRepository modelRepository = null;

        public AddFromFolderForm()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }

        private void PlaceFileNameToDataGrid(IList<string> files)
        {
            foreach (var file in files)
            {
                modelDataGridView.Rows.Add(file);
                filesList.Add(file);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            filesList.Clear();

            modelDataGridView.Rows.Clear();
            folderBrowserDialog.ShowDialog();

            Settings.LoadFromFolder = folderBrowserDialog.SelectedPath;

            locationComboBox.Items.Add(Settings.LoadFromFolder);
            locationComboBox.SelectedItem = Settings.LoadFromFolder;

            if (!String.IsNullOrEmpty(Settings.LoadFromFolder))
            {
                LoadFiles();
            }
        }

        private void LoadFiles()
        {
            string[] files = Directory.GetFiles(locationComboBox.Text, "*.ipt", SearchOption.AllDirectories);
            PlaceFileNameToDataGrid(files);
            addToDatabaseButton.Enabled = true;
        }

        private void addToDatabaseButton_Click(object sender, EventArgs e)
        {
            Settings.InitSettings();

            if (String.IsNullOrEmpty(Settings.SaveInFolder))
            {
                MessageBox.Show("Please set path where you want save model!", "Settings");
            }
            else
            {
                modelRepository = new ModelRepository(new ModelContext());

                GetModelProperties modelProperties = new GetModelProperties();

                foreach (var file in filesList)
                {
                    PartDocument partDocument = AddInGlobal.InventorApp.Documents.Add(DocumentTypeEnum.kPartDocumentObject, file, false) as PartDocument;

                    modelProperties.GetProperty(partDocument);

                    string modelLocationPach = Path.GetFullPath(file);

                    string pathToSave = Settings.SaveInFolder;

                    CopyToFolder(modelLocationPach, pathToSave, modelProperties, partDocument);

                    var model = new Model
                    {
                        Width = modelProperties.GetProperty(partDocument).Width,
                        Height = modelProperties.GetProperty(partDocument).Height,
                        Length = modelProperties.GetProperty(partDocument).Length,
                        DetailName = modelProperties.GetProperty(partDocument).DetailName,
                        ModelLocation = MakeModelLocationPath(pathToSave, modelProperties, partDocument)
                    };

                    modelRepository.AddModel(model);
                }

                try
                {
                    modelRepository.Save();
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show("Passed invalid object in current state: " + exception, "Add Models from Folder - WARNING");
                }

                AddInGlobal.InventorApp.Documents.CloseAll(true);
                MessageBox.Show(String.Format("Successfully added {0} models", filesList.Count), "Add Models from Folder");
            }

        }

        private string MakeModelLocationPath(string pathToSave, GetModelProperties modelProperties, PartDocument partDocument)
        {
            string makePath = String.Format("{0}\\{1}.ipt", pathToSave, modelProperties.GetProperty(partDocument).DetailName);
            return makePath;
        }

        private void CopyToFolder(string modelLocationPach, string pathToSave,
            GetModelProperties modelProperties, PartDocument partDocument)
        {
            string currentLocation = modelLocationPach; 
            string destLocation = String.Format("{0}\\{1}.ipt", pathToSave, modelProperties.GetProperty(partDocument).DetailName);

            try
            {
                File.Copy(currentLocation, destLocation);
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show("You have not access to copy files: " + exception, "Add Models from Folder - WARNING");
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show("Directory cannot be found: " + exception, "Add Models from Folder - WARNING");
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("File does not exist on disk: " + exception, "Add Models from Folder - WARNING");
            }
        }

        private void AddFromFolderForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.LoadFromFolder))
            {
                locationComboBox.Text = Settings.LoadFromFolder;
                LoadFiles();
            }
        }
    }
}
