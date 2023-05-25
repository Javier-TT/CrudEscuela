using CrudEscuela.Data;
using CrudEscuela.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Controllers
{
    public class GradosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradosController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Grado> listGrados = _context.grados;
            return View(listGrados);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grado grado)
        {
            if (ModelState.IsValid)
            {
                _context.grados.Add(grado);
                _context.SaveChanges();

                TempData["mensaje"] = "El Grado se ha Registrado con exito";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Obtener Grado
            var grado = _context.grados.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        //Http post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Grado grado)
        {
            if (ModelState.IsValid)
            {
                _context.grados.Update(grado);
                _context.SaveChanges();

                TempData["mensaje"] = "El grado se ha Actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Obtener grado
            var grado = _context.grados.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            return View(grado);
        }

        //Http post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGrado(int? id)
        {
            //Obtener el Alumnno por id
            var grado = _context.grados.Find(id);

            if (grado == null)
            {
                return NotFound();
            }

            _context.grados.Remove(grado);
            _context.SaveChanges();

            TempData["mensaje"] = "El grado se ha Eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
