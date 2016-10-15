using System.Drawing;
using System.Windows.Forms;

namespace InventorSearchPlugin.Helpers
{
    public class ImageConvertor : AxHost
    {
        public ImageConvertor() 
            : base("")
        {
            
        }
        public static stdole.IPictureDisp ConvertImageToIPictureDisp(Image image)
        {
            if (null == image) return null;
            return GetIPictureDispFromPicture(image) as stdole.IPictureDisp;
        }
    }
}