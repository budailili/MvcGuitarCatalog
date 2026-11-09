using System.ComponentModel.DataAnnotations;

namespace MvcGuitarCatalog.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? ModelName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? PickupType { get; set; }
        public decimal Price { get; set; }
    }
}