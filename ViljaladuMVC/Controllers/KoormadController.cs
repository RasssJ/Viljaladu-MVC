#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViljaladuMVC.Data;
using ViljaladuMVC.Models;

namespace ViljaladuMVC.Controllers
{
    public class KoormadController : Controller
    {
        private readonly ViljaladuDbContext _context;

        public KoormadController(ViljaladuDbContext context)
        {
            _context = context;
        }

        // GET: Koormad
        public async Task<IActionResult> Index(string autoNr)
        {
            if (autoNr != null)
                return View("KoikSoidud", await _context.Koormad.Where(m => m.AutoNumber == autoNr && m.LahkumisMass != 0).ToListAsync());
            return View("KoikSoidud", await _context.Koormad.Where(m => m.LahkumisMass != 0).ToListAsync());
        }

        // GET: Koormad/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutoNumber,SisenemisMass,LahkumisMass")] Koorma koorma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(koorma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lahkumismassita");
            }
            return View(koorma);
        }

        // GET: Koormad/Lahkumismassita/5
        public async Task<IActionResult> Lahkumismassita()
        {
            var koorma = await _context.Koormad.Where(m => m.LahkumisMass == 0).ToListAsync();
            
            if (koorma == null)
            {
                return NotFound();
            }

            return View(koorma);
        }

        // GET: Koormad/LisaLahkumismass/5
        public async Task<IActionResult> LisaLahkumismass(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koorma = await _context.Koormad.FindAsync(id);
            if (koorma == null)
            {
                return NotFound();
            }
            return View(koorma);
        }

        // POST: Koormad/LisaLahkumismass/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LisaLahkumismass(int id, [Bind("Id,AutoNumber,SisenemisMass,LahkumisMass")] Koorma koorma)
        {
            if (id != koorma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(koorma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoormaExists(koorma.Id))
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
            return View(koorma);
        }

        private bool KoormaExists(int id)
        {
            return _context.Koormad.Any(e => e.Id == id);
        }
    }
}
