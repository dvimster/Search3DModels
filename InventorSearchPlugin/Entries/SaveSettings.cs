using System.Collections.Generic;

namespace InventorSearchPlugin.Entries
{
    public class SaveSettings
    {
        public IList<string> SaveInFolderPathsList { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DbName { get; set; }

        public SaveSettings()
        {
            SaveInFolderPathsList = new List<string>();
        }
    }
}