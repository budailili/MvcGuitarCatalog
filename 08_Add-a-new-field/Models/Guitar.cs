using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGuitarCatalog.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string? Brand { get; set; }

        [Display(Name = "Model Name")]
        public string? ModelName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Pickup Type")]
        public string? PickupType { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Serial Number")]
        public string? SerialNumber { get; set; }
    }
}