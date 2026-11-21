using CRUD_validaciones.Datos;
using CRUD_validaciones.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_validaciones.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.Categoria;
            return View(lista);
        }

        //Get Crear
        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        //Post Crear
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        //Get Editar
        [Authorize]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Editar
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria.Update(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        //Get Eliminar
        [Authorize]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Eliminar
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }
            _db.Categoria.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
