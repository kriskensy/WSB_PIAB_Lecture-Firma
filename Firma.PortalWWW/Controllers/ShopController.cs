using Firma.Data.Data;
using Firma.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        //to jest pole odpowiedzialne za DB
        private readonly FirmaContext _context;
        public ShopController(FirmaContext context) 
        {
            _context = context;
        }

        //to jest funkcja, ktora dostarczy danych widokowi "Index"
        //bedzie on wyswietlal wszystkie towary rodzaju o danym id (id rodzaju podane jako parametr)
        public async Task<IActionResult> Index(int? id)//id rodzaju towarow, ktore maja byc wyswietlane
        {
            //pobieramy z DB wszystkie rodzaje towarow
            //i zapisujemy je do ViewBag, ktory przeniesie je z kontrolera do widoku
            ViewBag.ModelTypeOf = await _context.TypeOf.ToListAsync();
            //id bedzie wypelniany przy kazdym kliknieciu na rodzaj w sklepie
            //ale przy pierwszym wejsciu do sklepu bedzie pusty i wtedy decydujemy, ze wsywietlamy towaru docelowo promowane

            if(id == null)
            {
                id = 1;
            }

            //z DB pobieramy towary o danym IdTypeOf (czyli towaru danego rodzaju)
            var goodsOfAGivenType = await _context.Goods.Where(g => g.IdTypeOf == id).ToListAsync();

            //towary danego rodzaju przekazujemy do widoku
            return View(goodsOfAGivenType);
        }
    }
}
