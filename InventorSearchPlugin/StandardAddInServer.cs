using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using InvAddIn.Properties;
using InvAddIn.UI;
using Inventor;
using InventorSearchPlugin.Configuration;
using InventorSearchPlugin.Entries;
using InventorSearchPlugin.Global;
using InventorSearchPlugin.Helpers;
using InventorSearchPlugin.Infrastructure;
using Newtonsoft.Json;
using Button = InventorSearchPlugin.Implementation.Button;
using Environment = System.Environment;
using File = System.IO.File;

namespace InventorSearchPlugin
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("c9dbb858-694a-4a0c-ba1c-0d06eb52616b")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {
        private ButtonDefinition addButtonDefinition = null;
        private ButtonDefinition addFromFolderButtonDefinition = null;
        private ButtonDefinition searchButtonDefinition = null;
        private ButtonDefinition settingsButtonDefinition = null;

        private ButtonIcons addIcon = null;
        private ButtonIcons addFromFolderIcon = null;
        private ButtonIcons searchIcon = null;
        private ButtonIcons settingsIcon = null;

        public StandardAddInServer()
        {
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            AddInGlobal.InventorApp = addInSiteObject.Application;
            AddInGlobal.GetAddinClassId(GetType());

            IButton button = new Button();
            var action = new ButtonActions.ButtonActions();

            addIcon = new ButtonIcons(Resources.add_16x16, Resources.add_32x32);
            addButtonDefinition = button.CreateButton("Add", "Add", addIcon);
            addButtonDefinition.OnExecute += action.AddButtonDefinitionOnExecute;

            addFromFolderIcon = new ButtonIcons(Resources.folder_add_16x16, Resources.folder_add_32x32);
            addFromFolderButtonDefinition = button.CreateButton("Add Folder", "Add Folder", addFromFolderIcon);
            addFromFolderButtonDefinition.OnExecute += action.AddFromFolderButtonDefinitionOnExecute;

            searchIcon = new ButtonIcons(Resources.icon_search_16x16, Resources.icon_search_32x32);
            searchButtonDefinition = button.CreateButton("Search", "Search", searchIcon);
            searchButtonDefinition.OnExecute += action.SearchButtonDefinitionOnExecute;

            settingsIcon = new ButtonIcons(Resources.setting_16x16, Resources.setting_32x32);
            settingsButtonDefinition = button.CreateButton("Settings", "Settings", settingsIcon);
            settingsButtonDefinition.OnExecute += action.SettingsButtonDefinitionOnExecute;
        }

        

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated

            // TODO: Add ApplicationAddInServer.Deactivate implementation
            // Release objects.

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }

        #endregion
    }
}
