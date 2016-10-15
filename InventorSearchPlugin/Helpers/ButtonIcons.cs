using System.Drawing;

namespace InventorSearchPlugin.Helpers
{
    public class ButtonIcons
    {
        public readonly stdole.IPictureDisp iconStandard;
        public readonly stdole.IPictureDisp iconLarge;

        public ButtonIcons(Image pictureStandard, Image pictureLarge)
        {
            iconStandard = ImageConvertor.ConvertImageToIPictureDisp(pictureStandard);
            iconLarge = ImageConvertor.ConvertImageToIPictureDisp(pictureLarge);
        }
    }
}