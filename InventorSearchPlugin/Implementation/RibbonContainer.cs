using System.Linq;
using Inventor;
using InventorSearchPlugin.Global;

namespace InventorSearchPlugin.Implementation
{
    public static class RibbonContainer
    {
        public static RibbonPanel CreateRibbonPanel(string buttonPlace, string idTabTools, string panelName, string displayName, ButtonDefinition buttonDefinition)
        {
            string classId = "{" + AddInGlobal.ClassId + "}";
            Ribbon ribbon = AddInGlobal.InventorApp.UserInterfaceManager.Ribbons[buttonPlace];
            Inventor.RibbonTab ribbonTab = ribbon.RibbonTabs[idTabTools];
            Inventor.RibbonPanel ribbonPanel = ribbonTab.RibbonPanels.OfType<Inventor.RibbonPanel>()
                .SingleOrDefault(rp => rp.InternalName == panelName)
                                               ?? ribbonTab.RibbonPanels.Add(
                                                   "Search 3D Models", "Search 3D Models", classId);
            ribbonPanel.CommandControls.AddButton(buttonDefinition, true);
            return ribbonPanel;
        }
    }
}