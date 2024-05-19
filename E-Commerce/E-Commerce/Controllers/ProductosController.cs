using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Data;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class ProductosController : Controller
    {
        private readonly EcommerceContext _context;

        public ProductosController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Productos.Include(p => p.IdcategoriaNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Idproductos == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproductos,Nombreproducto,Marca,Cantidadstock,Precio,Idcategoria,Descripcion,Descuento")] Productos productos, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await imagen.CopyToAsync(ms);
                        productos.Imagen = ms.ToArray();
                    }
                }

                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", productos.Idcategoria);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            // Cargar las categorías para el dropdownlist
            ViewBag.Categorias = new SelectList(_context.Categoria, "Idcategoria", "Nombrecategoria", producto.Idcategoria);

            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idproductos,Nombreproducto,Marca,Cantidadstock,Precio,Idcategoria,Descripcion,Descuento")] Productos producto, IFormFile imagen)
        {
            if (id != producto.Idproductos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si se proporcionó una nueva imagen
                    if (imagen != null && imagen.Length > 0)
                    {
                        // Si hay una nueva imagen, actualizarla
                        using (var ms = new MemoryStream())
                        {
                            await imagen.CopyToAsync(ms);
                            producto.Imagen = ms.ToArray();
                        }
                    }

                    // Si no se proporcionó una nueva imagen, omitir la actualización

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(producto.Idproductos))
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

            // Recargar las categorías para el dropdownlist en caso de que haya un error de validación
            ViewBag.Categorias = new SelectList(_context.Categoria, "Idcategoria", "Nombrecategoria", producto.Idcategoria);

            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Idproductos == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'EcommerceContext.Productos'  is null.");
            }
            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return (_context.Productos?.Any(e => e.Idproductos == id)).GetValueOrDefault();
        }

        public IActionResult ObtenerImagen(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Idproductos == id);
            if (producto == null || producto.Imagen == null)
            {
                return NotFound();
            }

            // Log data for debugging
            Console.WriteLine($"Producto ID: {producto.Idproductos}, Imagen Length: {producto.Imagen.Length}");

            return File(producto.Imagen, "image/png"); // Ajusta el tipo MIME si es necesario
        }
    
    }
}
