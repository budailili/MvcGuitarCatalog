using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGuitarCatalog.Models
{
    public class Guitar
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string? Brand { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "Model Name")]
        public string? ModelName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Pickup Type")]
        public string? PickupType { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]{3}-[0-9]{5}$", ErrorMessage = "Format must be: ABC-12345")]
        [StringLength(9)]
        [Required]
        [Display(Name = "Serial Number")]
        public string? SerialNumber { get; set; }
    }
}