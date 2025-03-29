using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Firma.PortalWWW.Models;
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //to jest pola odpowiedzialne za dzialanie na DB
    private readonly FirmaContext _context;
    public HomeController(ILogger<HomeController> logger, FirmaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int? id)//jako parametr funkcja dostaje parametr strony, ktora kliknieto
    {
        ////ten ViewBag wysyla wszystkie strony do widoku Links
        //ViewBag.ModelPage =
        //    (
        //        from page in _context.Page //dla kazdej strony z DB context stron
        //        orderby page.Position //posortowanej wzgledem pozycji
        //        select page //pobiera strone
        //    ).ToList();

        ViewBag.ModelPage = await _context.Page.OrderBy(p => p.Position).ToListAsync(); //inny sposob tego co wyzej

        ////ten ViewBag wysyla wszystkie atkualnosci z DB do widoku News
        //ViewBag.ModelNews =
        //    (
        //        from news in _context.News
        //        orderby news.Position descending
        //        select news
        //    ).Take(4).ToList(); //funkcja Take pobiera tylko (4) pierwsze

        ViewBag.ModelNews = await _context.News.OrderBy(n => n.Position).Take(4).ToListAsync();

        if(id == null)//id jest null przy pierwszym uruchomieniu i wtedy wyswietlana jest strona o id=1
        {
            id = 1;
        }
        //asynchornicznie odnajduje w DB strone o danym id
        var item = await _context.Page.FindAsync(id);
        //odnaleziona strona o danym id przekazujemy do widoku do wyswietlenia

        return View(item);//jak funkcja nazywa sie index to strone tez przekazujemy do widoku o nazwie index
    }

    public IActionResult OpisFirmy()
    {
        return View();
    }

    public IActionResult HistoriaFirmy()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
