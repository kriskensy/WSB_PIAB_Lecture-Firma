using Firma.Data.Data.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.Shop
{
    public interface ITypeOfService
    {
        Task<IList<TypeOf>> GetTypeOfs();
    }
}
