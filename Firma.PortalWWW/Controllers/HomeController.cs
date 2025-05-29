using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Firma.PortalWWW.Models;
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;
using Firma.Interfaces.CMS;

namespace Firma.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INewsService _newsService;
    private readonly IPageService _pageService;
    public HomeController(ILogger<HomeController> logger, INewsService newsService, IPageService pageService)
    {
        _logger = logger;
        _newsService = newsService;
        _pageService = pageService;
    }

    public async Task<IActionResult> Index(int? id)
    {

        ViewBag.ModelPage = await _pageService.GetPagesByPositon();
        ViewBag.ModelNews = await _newsService.GetNewsByPosition(4);

        if (id == null)
        {
            id = 1;
        }

        var item = await _pageService.GetPage(id);

        return View(item);
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
