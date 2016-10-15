using System;
using System.Windows.Forms;
using InvAddIn.UI;
using Inventor;
using InventorSearchPlugin.Configuration;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Global;
using InventorSearchPlugin.Helpers;
using InventorSearchPlugin.Implementation;
using InventorSearchPlugin.Infrastructure;
using File = System.IO.File;

namespace InventorSearchPlugin.ButtonActions
{
    public class ButtonActions
    {
        private AddFromFolderForm addFromFolderFolderForm = null;
        private SearchModelsForm searchModelsForm = null;
        private SettingsForm settingsForm = null;

        private IRepository modelRepository = null;

        public void AddButtonDefinitionOnExecute(NameValueMap context)
        {
            if (String.IsNullOrEmpty(Settings.SaveInFolder))
            {
                MessageBox.Show("Please set path where you want save model!", "Settings");
                Settings.InitSettings();
            }
            else
            {
                modelRepository = new ModelRepository(new ModelContext());

                PartDocument partDocument = AddInGlobal.InventorApp.ActiveDocument as PartDocument;
                GetModelProperties modelProperties = new GetModelProperties();
                modelProperties.GetProperty(partDocument);

                string activeDocumentName = AddInGlobal.InventorApp.ActiveEditDocument.DisplayName;
                
                if (File.Exists(activeDocumentName))
                {
                    AddInGlobal.InventorApp.ActiveEditDocument.Save();
                    
                    var updateModel = new Model
                    {
                        Width = modelProperties.GetProperty(partDocument).Width,
                        Height = modelProperties.GetProperty(partDocument).Height,
                        Length = modelProperties.GetProperty(partDocument).Length,
                        DetailName = modelProperties.GetProperty(partDocument).DetailName,
                        ModelLocation = modelProperties.GetProperty(partDocument).ModelLocation
                    };

                    try
                    {
                        modelRepository.UpdateModel(updateModel);
                        modelRepository.Save();
                    }
                    catch (InvalidOperationException exception)
                    {
                        MessageBox.Show("Method call is invalid update for the object current state: " + exception,
                            "Add Singe Model - WARNING");
                    }
                    
                    MessageBox.Show("Model was seccessfully updated", "Add Single Model");
                }
                else
                {
                    string saveName = Settings.SaveInFolder + "\\" + modelProperties.GetProperty(partDocument).DetailName + ".ipt";

                    var model = new Model
                    {
                        Width = modelProperties.GetProperty(partDocument).Width,
                        Height = modelProperties.GetProperty(partDocument).Height,
                        Length = modelProperties.GetProperty(partDocument).Length,
                        DetailName = modelProperties.GetProperty(partDocument).DetailName,
                        ModelLocation = saveName
                    };

                    try
                    {
                        modelRepository.AddModel(model);
                        modelRepository.Save();
                    }
                    catch (InvalidOperationException exception)
                    {
                        MessageBox.Show("Method call is invalid insert for the object current state: " + exception,
                            "Add Singe Model - WARNING");
                    }

                    AddInGlobal.InventorApp.ActiveDocument.DisplayName = modelProperties.GetProperty(partDocument).DetailName;
                    AddInGlobal.InventorApp.ActiveDocument.SaveAs(saveName, true);
                    MessageBox.Show("Datail was successfully saved", "Add Single Model");
                }
            }
        }

        public void AddFromFolderButtonDefinitionOnExecute(NameValueMap context)
        {
            addFromFolderFolderForm = new AddFromFolderForm();
            addFromFolderFolderForm.ShowDialog();
        }

        public void SearchButtonDefinitionOnExecute(NameValueMap context)
        {
            searchModelsForm = new SearchModelsForm();
            searchModelsForm.ShowDialog();
        }

        public void SettingsButtonDefinitionOnExecute(NameValueMap context)
        {
            settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}