using Inventor;
using InventorSearchPlugin.Helpers;

namespace InventorSearchPlugin.Infrastructure
{
    public interface IButton
    {
        ButtonDefinition CreateButton(string displayName, string internalName, ButtonIcons buttonIcons);
    }
}