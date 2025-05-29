using Firma.Data.Data;
using Firma.Data.Data.Shop;
using Firma.Interfaces.Shop;
using Firma.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.Shop
{
    public class GoodService : BaseService, IGoodService
    {
        public GoodService(FirmaContext context) 
            : base(context)
        {
        }

        //to jest funkcja, ktora zwraca towar o danym id
        public async Task<Goods?> GetGood(int idGood)
        {
            var good = await _context.Goods.Where(g => g.IdGoods == idGood). FirstOrDefaultAsync();

            return good;
        }

        //to jest funkcja, ktora zwraca towary danego rodzaje
        public async Task<IList<Goods>> GetGoodsOfAGivenType(int idTypeOf)
        {
            var goodsOfAGivenType = await _context.Goods.Where(g => g.IdTypeOf == idTypeOf).ToListAsync();

            return goodsOfAGivenType;
        }
    }
}
