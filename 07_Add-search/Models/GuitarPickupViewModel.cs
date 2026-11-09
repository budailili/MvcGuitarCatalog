using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcGuitarCatalog.Models
{
    public class GuitarPickupViewModel
    {
        public List<Guitar>? Guitars { get; set; }
        public SelectList? PickupTypes { get; set; }
        public string? GuitarPickup { get; set; }
        public string? SearchString { get; set; }
    }
}