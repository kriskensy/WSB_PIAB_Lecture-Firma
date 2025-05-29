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
    public class NewsService : BaseService, INewsService
    {
        public NewsService(FirmaContext context) 
            : base(context) //tu jest wywolany konstrukto bazowy z BaseService, który ustawia context
        {
        }

        //ta funkcja zwraca aktualnosc o danym id podanym jako parametr
        public async Task<News?> GetNews(int idNews)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.IdNews==idNews);
            return news;
        }
        //ta funkcja bedzie zwracala howMany aktualnosci posortowanych wzgledem pozycji
        public async Task<IList<News>> GetNewsByPosition(int howMany)
        {
            var news = await _context.News //pobieram aktualnosci z DB
                .OrderByDescending(n => n.Position) //sortuje wzgledem pozycji
                .Take(howMany) //pobieram tylko tyle ile dostaje jako parametr
                .ToListAsync();

            return news;
        }
    }
}
