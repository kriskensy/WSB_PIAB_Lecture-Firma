using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Intranet.Models.CMS;
using Firma.Intranet.Models.Shop;

namespace Firma.Intranet.Data
{
    public class FirmaIntranetContext : DbContext
    {
        public FirmaIntranetContext (DbContextOptions<FirmaIntranetContext> options)
            : base(options)
        {
        }

        public DbSet<Firma.Intranet.Models.CMS.News> News { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.CMS.Page> Page { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Shop.TypeOf> TypeOf { get; set; } = default!;
        public DbSet<Firma.Intranet.Models.Shop.Goods> Goods { get; set; } = default!;
    }
}
