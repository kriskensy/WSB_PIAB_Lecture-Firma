using Firma.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.CMS
{
    public interface INewsService
    {
        //ta funkcja bedzie zwracala howMany aktualnosci posortowanych wzgledem pozycji
        Task<IList<News>> GetNewsByPosition(int howMany);
        //ta funkcja zwraca aktualnosc o danym id podanym jako parametr
        Task<News?> GetNews(int idNews);
    }
}
