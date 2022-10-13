using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiClean.Models;
using ApiClean.Datos;

namespace ApiClean.Controllers
{
    //sp_getById(@id)
    //sp_getAll
    //exec clean.dbo.sp_getTop
    //sp_getTotal
    //sp_getExistencias
    //sp_getLess
    public class ProductoesController : Controller
    {
        private readonly cleanContext _context;
        StoredDatos data = new StoredDatos();

        public ProductoesController(cleanContext context)
        {
            _context = context;
        }

        // GET: Productoes
        [HttpGet]
        [Route("Productos")]
        public async Task<IActionResult> Index()
        {
            //YA jala
            var lista = data.getAll();
            return Json(lista);
        }
        [HttpGet]
        [Route("Algo/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            //NOJALA
            var lista = data.getById(id);
            return Json(lista);
        }
        [HttpGet]
        [Route("Top")]
        public async Task<IActionResult> Top()
        {
            //YA JALA
            var lista = data.getTop();
            return Json(lista);
        }
        public async Task<IActionResult> Total()
        {
            //Tambien jala
            var lista = data.getTotal();
            return Json(lista);
        }
        public async Task<IActionResult> Existencias()
        {
            //Si jala
            var lista = data.getExistencias();
            return Json(lista);
        }
        public async Task<IActionResult> Less()
        {
            //Si jala
            var lista = data.getLess();
            return Json(lista);
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Idproductos == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproductos,Titulo,Descripcion,PrecioUnitario,Existencias")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idproductos,Titulo,Descripcion,PrecioUnitario,Existencias")] Producto producto)
        {
            if (id != producto.Idproductos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Idproductos))
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
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Idproductos == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'cleanContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return _context.Productos.Any(e => e.Idproductos == id);
        }
    }
}
