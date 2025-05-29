using Firma.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.CMS
{
    public interface IPageService
    {
        Task<IList<Page>> GetPagesByPositon();
        Task<Page?> GetPage(int? id);
    }
}
