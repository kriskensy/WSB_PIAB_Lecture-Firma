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
    public class TypeOfController : Controller
    {
        private readonly FirmaContext _context;

        public TypeOfController(FirmaContext context)
        {
            _context = context;
        }

        // GET: TypeOf
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOf.ToListAsync());
        }

        // GET: TypeOf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOf = await _context.TypeOf
                .FirstOrDefaultAsync(m => m.IdTypeOf == id);
            if (typeOf == null)
            {
                return NotFound();
            }

            return View(typeOf);
        }

        // GET: TypeOf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeOf,Name,Description")] TypeOf typeOf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOf);
        }

        // GET: TypeOf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOf = await _context.TypeOf.FindAsync(id);
            if (typeOf == null)
            {
                return NotFound();
            }
            return View(typeOf);
        }

        // POST: TypeOf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypeOf,Name,Description")] TypeOf typeOf)
        {
            if (id != typeOf.IdTypeOf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfExists(typeOf.IdTypeOf))
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
            return View(typeOf);
        }

        // GET: TypeOf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOf = await _context.TypeOf
                .FirstOrDefaultAsync(m => m.IdTypeOf == id);
            if (typeOf == null)
            {
                return NotFound();
            }

            return View(typeOf);
        }

        // POST: TypeOf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOf = await _context.TypeOf.FindAsync(id);
            if (typeOf != null)
            {
                _context.TypeOf.Remove(typeOf);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfExists(int id)
        {
            return _context.TypeOf.Any(e => e.IdTypeOf == id);
        }
    }
}
