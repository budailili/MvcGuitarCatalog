using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGuitarCatalog.Data;
using System;
using System.Linq;

namespace MvcGuitarCatalog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcGuitarCatalogContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcGuitarCatalogContext>>()))
            {
                if (context.Guitar.Any())
                {
                    return;   // DB has been seeded
                }

                context.Guitar.AddRange(
                    new Guitar
                    {
                        Brand = "Ibanez",
                        ModelName = "GRG121DX",
                        ReleaseDate = DateTime.Parse("2015-01-15"),
                        PickupType = "Humbucker",
                        Price = 249.99M
                    },
                    new Guitar
                    {
                        Brand = "PRS",
                        ModelName = "SE McCarty 594 Singlecut",
                        ReleaseDate = DateTime.Parse("2023-03-10"),
                        PickupType = "Humbucker",
                        Price = 949.00M
                    },
                    new Guitar
                    {
                        Brand = "ESP LTD",
                        ModelName = "EC-1000",
                        ReleaseDate = DateTime.Parse("2018-06-20"),
                        PickupType = "Active",
                        Price = 1099.00M
                    },
                    new Guitar
                    {
                        Brand = "Fender",
                        ModelName = "Player Telecaster",
                        ReleaseDate = DateTime.Parse("2018-07-01"),
                        PickupType = "Single-Coil",
                        Price = 799.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}