using System;
using System.Runtime.InteropServices;
using Inventor;
using Attribute = System.Attribute;

namespace InventorSearchPlugin.Global
{
    public static class AddInGlobal
    {
        public static Inventor.Application InventorApp;
        private static string _mClassId;
        public static RibbonPanel panel;

        public static string ClassId
        {
            get
            {
                if (!string.IsNullOrEmpty(_mClassId))
                    return _mClassId = "c9dbb858-694a-4a0c-ba1c-0d06eb52616b";
                throw new Exception("The addin server class id hasn't been gotten yet!");
            }

        }

        public static void GetAddinClassId(Type t)
        {
            var guidAtt = (GuidAttribute)Attribute.GetCustomAttribute(t, typeof(GuidAttribute));
            _mClassId = "{" + guidAtt.Value + "}";
        }
    
    }
}