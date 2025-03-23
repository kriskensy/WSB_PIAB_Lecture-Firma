using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class GoodsController : Controller
    {
        private readonly FirmaContext _context;

        public GoodsController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            var firmaIntranetContext = _context.Goods.Include(g => g.TypeOf);
            return View(await firmaIntranetContext.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .Include(g => g.TypeOf)
                .FirstOrDefaultAsync(m => m.IdGoods == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            ViewData["IdTypeOf"] = new SelectList(_context.TypeOf, "IdTypeOf", "Name");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGoods,Code,Name,Price,FotoURL,Description,IdTypeOf")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTypeOf"] = new SelectList(_context.TypeOf, "IdTypeOf", "Name", goods.IdTypeOf);
            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }
            ViewData["IdTypeOf"] = new SelectList(_context.TypeOf, "IdTypeOf", "Name", goods.IdTypeOf);
            return View(goods);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGoods,Code,Name,Price,FotoURL,Description,IdTypeOf")] Goods goods)
        {
            if (id != goods.IdGoods)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsExists(goods.IdGoods))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTypeOf"] = new SelectList(_context.TypeOf, "IdTypeOf", "Name", goods.IdTypeOf);
            return View(goods);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .Include(g => g.TypeOf)
                .FirstOrDefaultAsync(m => m.IdGoods == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            if (goods != null)
            {
                _context.Goods.Remove(goods);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsExists(int id)
        {
            return _context.Goods.Any(e => e.IdGoods == id);
        }
    }
}
