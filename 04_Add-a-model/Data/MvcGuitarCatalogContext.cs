using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGuitarCatalog.Models;

namespace MvcGuitarCatalog.Data
{
    public class MvcGuitarCatalogContext : DbContext
    {
        public MvcGuitarCatalogContext(DbContextOptions<MvcGuitarCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<MvcGuitarCatalog.Models.Guitar> Guitar { get; set; } = default!;
    }
}