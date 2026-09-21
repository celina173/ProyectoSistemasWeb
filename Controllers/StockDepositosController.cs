
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebacontroladores.Models.Entities;
using pruebacontroladores.Data;

public class StockDepositosController : Controller
{
    private readonly ApplicationDbContext _context;

    public StockDepositosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: STOCKDEPOSITOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.StockDepositos.ToListAsync());
    }

    // GET: STOCKDEPOSITOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stockdeposito = await _context.StockDepositos
            .FirstOrDefaultAsync(m => m.id == id);
        if (stockdeposito == null)
        {
            return NotFound();
        }

        return View(stockdeposito);
    }

    // GET: STOCKDEPOSITOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STOCKDEPOSITOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("idProducto,Producto,idDeposito,Deposito,Cantidad,id,Activo,CreatedAt,UpdatedAt")] StockDeposito stockdeposito)
    {
        if (ModelState.IsValid)
        {
            _context.Add(stockdeposito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(stockdeposito);
    }

    // GET: STOCKDEPOSITOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stockdeposito = await _context.StockDepositos.FindAsync(id);
        if (stockdeposito == null)
        {
            return NotFound();
        }
        return View(stockdeposito);
    }

    // POST: STOCKDEPOSITOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("idProducto,Producto,idDeposito,Deposito,Cantidad,id,Activo,CreatedAt,UpdatedAt")] StockDeposito stockdeposito)
    {
        if (id != stockdeposito.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(stockdeposito);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockDepositoExists(stockdeposito.id))
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
        return View(stockdeposito);
    }

    // GET: STOCKDEPOSITOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stockdeposito = await _context.StockDepositos
            .FirstOrDefaultAsync(m => m.id == id);
        if (stockdeposito == null)
        {
            return NotFound();
        }

        return View(stockdeposito);
    }

    // POST: STOCKDEPOSITOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var stockdeposito = await _context.StockDepositos.FindAsync(id);
        if (stockdeposito != null)
        {
            _context.StockDepositos.Remove(stockdeposito);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StockDepositoExists(int? id)
    {
        return _context.StockDepositos.Any(e => e.id == id);
    }
}
