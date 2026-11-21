using CRUD_Clientes.Datos;
using CRUD_Clientes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_Clientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;

        private static readonly string[] TiposDocumento = { "DNI", "Carné de extranjería", "Pasaporte", "RUC" };

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        // La consulta es pública
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _db.Cliente;
            return View(lista);
        }

        //Get Crear
        [Authorize]
        public IActionResult Crear()
        {
            CargarTiposDocumento();
            return View();
        }

        //Post Crear
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            CargarTiposDocumento();
            return View(cliente);
        }

        //Get Editar
        [Authorize]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cliente.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            CargarTiposDocumento();
            return View(obj);
        }

        //Post Editar
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Cliente.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            CargarTiposDocumento();
            return View(cliente);
        }

        //Get Eliminar
        [Authorize]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cliente.Find(Id);
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
        public IActionResult EliminarConfirmado(int Id)
        {
            var obj = _db.Cliente.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Cliente.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private void CargarTiposDocumento()
        {
            ViewBag.TiposDocumento = new SelectList(TiposDocumento);
        }
    }
}
