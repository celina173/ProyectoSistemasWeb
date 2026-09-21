
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebacontroladores.Models.Entities;
using pruebacontroladores.Data;

public class MovimientosController : Controller
{
    private readonly ApplicationDbContext _context;

    public MovimientosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MOVIMIENTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Movimientos.ToListAsync());
    }

    // GET: MOVIMIENTOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movimiento = await _context.Movimientos
            .FirstOrDefaultAsync(m => m.id == id);
        if (movimiento == null)
        {
            return NotFound();
        }

        return View(movimiento);
    }

    // GET: MOVIMIENTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVIMIENTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Tipo,Cantidad,Fecha,Observaciones,idProducto,Producto,idDepositoOrigen,DepositoOrigen,idDepositoDestino,DepositoDestino,idProveedor,Proveedor,idCliente,Cliente,UsuarioRegistro,id,Activo,CreatedAt,UpdatedAt")] Movimiento movimiento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movimiento);
    }

    // GET: MOVIMIENTOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movimiento = await _context.Movimientos.FindAsync(id);
        if (movimiento == null)
        {
            return NotFound();
        }
        return View(movimiento);
    }

    // POST: MOVIMIENTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Tipo,Cantidad,Fecha,Observaciones,idProducto,Producto,idDepositoOrigen,DepositoOrigen,idDepositoDestino,DepositoDestino,idProveedor,Proveedor,idCliente,Cliente,UsuarioRegistro,id,Activo,CreatedAt,UpdatedAt")] Movimiento movimiento)
    {
        if (id != movimiento.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movimiento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(movimiento.id))
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
        return View(movimiento);
    }

    // GET: MOVIMIENTOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movimiento = await _context.Movimientos
            .FirstOrDefaultAsync(m => m.id == id);
        if (movimiento == null)
        {
            return NotFound();
        }

        return View(movimiento);
    }

    // POST: MOVIMIENTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movimiento = await _context.Movimientos.FindAsync(id);
        if (movimiento != null)
        {
            _context.Movimientos.Remove(movimiento);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovimientoExists(int? id)
    {
        return _context.Movimientos.Any(e => e.id == id);
    }
}
