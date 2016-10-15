using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorSearchPlugin.Entries
{
    [Table("Models", Schema = "public")]
    public class Model
    {
        [Key]
        public int Id { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string DetailName { get; set; }
        public string ModelLocation { get; set; }
    }
}