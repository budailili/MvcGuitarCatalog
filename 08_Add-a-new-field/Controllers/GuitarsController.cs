using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGuitarCatalog.Data;
using MvcGuitarCatalog.Models;

namespace MvcGuitarCatalog.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly MvcGuitarCatalogContext _context;

        public GuitarsController(MvcGuitarCatalogContext context)
        {
            _context = context;
        }

        // GET: Guitars
        public async Task<IActionResult> Index(string guitarPickup, string searchString)
        {
            if (_context.Guitar == null)
            {
                return Problem("Entity set 'MvcGuitarCatalogContext.Guitar' is null.");
            }

            IQueryable<string> pickupQuery = from g in _context.Guitar
                                             orderby g.PickupType
                                             select g.PickupType;

            var guitars = from g in _context.Guitar
                          select g;

            if (!string.IsNullOrEmpty(searchString))
            {
                guitars = guitars.Where(s => s.Brand!.ToUpper().Contains(searchString.ToUpper())
                                          || s.ModelName!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(guitarPickup))
            {
                guitars = guitars.Where(x => x.PickupType == guitarPickup);
            }

            var guitarPickupVM = new GuitarPickupViewModel
            {
                PickupTypes = new SelectList(await pickupQuery.Distinct().ToListAsync()),
                Guitars = await guitars.ToListAsync()
            };

            return View(guitarPickupVM);
        }

        // GET: Guitars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // GET: Guitars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,ModelName,ReleaseDate,PickupType,Price,SerialNumber")] Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guitar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guitar);
        }

        // GET: Guitars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }
            return View(guitar);
        }

        // POST: Guitars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,ModelName,ReleaseDate,PickupType,Price,SerialNumber")] Guitar guitar)
        {
            if (id != guitar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guitar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuitarExists(guitar.Id))
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
            return View(guitar);
        }

        // GET: Guitars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar == null)
            {
                return NotFound();
            }

            return View(guitar);
        }

        // POST: Guitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guitar = await _context.Guitar.FindAsync(id);
            if (guitar != null)
            {
                _context.Guitar.Remove(guitar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitar.Any(e => e.Id == id);
        }
    }
}