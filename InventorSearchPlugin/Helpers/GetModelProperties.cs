using System;
using Inventor;
using InventorSearchPlugin.Entries;

namespace InventorSearchPlugin.Helpers
{
    public class GetModelProperties
    {
        public Model GetProperty(PartDocument partDocument)
        {
            Box rangeBox = partDocument.ComponentDefinition.RangeBox;

            double x = Math.Round(Math.Abs(rangeBox.MaxPoint.X - rangeBox.MinPoint.X), 2);
            double y = Math.Round(Math.Abs(rangeBox.MaxPoint.Y - rangeBox.MinPoint.Y), 2);
            double z = Math.Round(Math.Abs(rangeBox.MaxPoint.Z - rangeBox.MinPoint.Z), 2);

            x.ToString().Replace(',', '.');
            y.ToString().Replace(',', '.');
            z.ToString().Replace(',', '.');

            double[] arr = new double[] {x, y, z};

            Array.Sort(arr);
            Array.Reverse(arr);

            var model = new Model
            {
                Length = arr[0],
                Height = arr[1],
                Width = arr[2],
                DetailName = partDocument.InternalName
            };

            return model;
        }
    }
}