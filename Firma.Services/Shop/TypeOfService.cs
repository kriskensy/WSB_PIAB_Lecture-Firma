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
    public class TypeOfService : BaseService, ITypeOfService
    {
        public TypeOfService(FirmaContext context) 
            : base(context)
        {
        }

        //to jest funkcja, ktora pobiera wszystkie rodzaje z DB
        public async Task<IList<TypeOf>> GetTypeOfs()
        {
            var types = await _context.TypeOf.ToListAsync();

            return types;
        }
    }
}
