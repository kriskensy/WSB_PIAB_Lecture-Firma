using Firma.Data.Data;
using Firma.Data.Data.Shop;
using Firma.Interfaces.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class ShopController : Controller
    {

        private readonly IGoodService _goodService;
        public ShopController(IGoodService goodService) 
        {
            _goodService = goodService;
        }

        public async Task<IActionResult> Index(int? id)
        {

            if(id == null)
            {
                id = 1;
            }

            var goodsOfAGivenType = await _goodService.GetGoodsOfAGivenType(id.Value);

            return View(goodsOfAGivenType);
        }

        public async Task<IActionResult> Details (int id)
        {
            return View(await _goodService.GetGood(id));
        }
    }
}
