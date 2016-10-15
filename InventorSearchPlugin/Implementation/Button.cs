using Inventor;
using InventorSearchPlugin.Global;
using InventorSearchPlugin.Helpers;
using InventorSearchPlugin.Infrastructure;

namespace InventorSearchPlugin.Implementation
{
    public class Button : IButton
    {
        public ButtonDefinition CreateButton(string displayName, string internalName, ButtonIcons buttonIcons)
        {
            ButtonDefinition buttonDefinition = AddInGlobal.InventorApp.CommandManager.ControlDefinitions.AddButtonDefinition(
                displayName, internalName, CommandTypesEnum.kEditMaskCmdType, "{" + AddInGlobal.ClassId + "}",
                null, null, buttonIcons.iconStandard, buttonIcons.iconLarge);
            buttonDefinition.AutoAddToGUI();
            AddInGlobal.panel = RibbonContainer.CreateRibbonPanel("ZeroDoc", "id_TabTools", "Search 3D Models", displayName, buttonDefinition);
            AddInGlobal.panel.Visible = true;
            buttonDefinition.Enabled = true;
            return buttonDefinition;
        }
    }
}