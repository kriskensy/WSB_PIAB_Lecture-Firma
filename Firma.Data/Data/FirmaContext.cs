using Firma.Data.Data.CMS;
using Firma.Data.Data.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; } = default!;
        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<TypeOf> TypeOf { get; set; } = default!;
        public DbSet<Goods> Goods { get; set; } = default!;
    }
}
