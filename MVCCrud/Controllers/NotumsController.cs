using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCrud.Models.Notas;

namespace MVCCrud.Controllers
{
    public class NotumsController : Controller
    {
        private readonly NotasContext _context;

        public NotumsController(NotasContext context)
        {
            _context = context;
        }

        // GET: Notums
        public async Task<IActionResult> Index()
        {
              return View(await _context.Nota.ToListAsync());
        }

        // GET: Notums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // GET: Notums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Carnet,Nombre,NSistematico,N1parcial,N2parcial,EConvo1,EConvo2")] Notum notum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notum);
        }

        // GET: Notums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota.FindAsync(id);
            if (notum == null)
            {
                return NotFound();
            }
            return View(notum);
        }

        // POST: Notums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Carnet,Nombre,NSistematico,N1parcial,N2parcial,EConvo1,EConvo2")] Notum notum)
        {
            if (id != notum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotumExists(notum.Id))
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
            return View(notum);
        }

        // GET: Notums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // POST: Notums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'NotasContext.Nota'  is null.");
            }
            var notum = await _context.Nota.FindAsync(id);
            if (notum != null)
            {
                _context.Nota.Remove(notum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotumExists(int id)
        {
          return _context.Nota.Any(e => e.Id == id);
        }
    }
}
