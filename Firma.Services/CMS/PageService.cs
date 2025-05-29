using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.Interfaces.CMS;
using Firma.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.CMS
{
    public class PageService : BaseService, IPageService
    {
        public PageService(FirmaContext context) 
            : base(context)
        {
        }

        //ta funkcja pobiera strone o danym id
        public async Task<Page?> GetPage(int? id)
        {
            var page = await _context.Page.FindAsync(id);

            return page;
        }

        //ta funkcja pobiera z DB wszystkie strony posortowane wzgledem pozycji
        public async Task<IList<Page>> GetPagesByPositon()
        {
            var pages = await _context.Page.OrderBy(p => p.Position).ToListAsync();

            return pages;
        }
    }
}
