
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebacontroladores.Models.Entities;
using pruebacontroladores.Data;

public class DepositosController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepositosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DEPOSITOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Depositos.ToListAsync());
    }

    // GET: DEPOSITOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deposito = await _context.Depositos
            .FirstOrDefaultAsync(m => m.id == id);
        if (deposito == null)
        {
            return NotFound();
        }

        return View(deposito);
    }

    // GET: DEPOSITOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEPOSITOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nombre,Ubicacion,Stocks,MovimientosOrigen,MovimientosDestino,id,Activo,CreatedAt,UpdatedAt")] Deposito deposito)
    {
        if (ModelState.IsValid)
        {
            _context.Add(deposito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(deposito);
    }

    // GET: DEPOSITOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deposito = await _context.Depositos.FindAsync(id);
        if (deposito == null)
        {
            return NotFound();
        }
        return View(deposito);
    }

    // POST: DEPOSITOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Nombre,Ubicacion,Stocks,MovimientosOrigen,MovimientosDestino,id,Activo,CreatedAt,UpdatedAt")] Deposito deposito)
    {
        if (id != deposito.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(deposito);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(deposito.id))
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
        return View(deposito);
    }

    // GET: DEPOSITOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var deposito = await _context.Depositos
            .FirstOrDefaultAsync(m => m.id == id);
        if (deposito == null)
        {
            return NotFound();
        }

        return View(deposito);
    }

    // POST: DEPOSITOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var deposito = await _context.Depositos.FindAsync(id);
        if (deposito != null)
        {
            _context.Depositos.Remove(deposito);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepositoExists(int? id)
    {
        return _context.Depositos.Any(e => e.id == id);
    }
}
