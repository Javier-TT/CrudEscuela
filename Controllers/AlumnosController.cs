using CrudEscuela.Data;
using CrudEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrudEscuela.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index(string nombre, string apellido, bool? estado)
        {
            // Obtener todos los alumnos
            var alumnos = from alumno in _context.Alumno
                          join grados in _context.grados on alumno.GradoId equals grados.Id
                          where alumno.Eliminado != false
                         
                          select new AlumnoViewModel
                          {
                              IdAlumno = alumno.Id,
                              NombreAlumno = alumno.Nombre,
                              ApellidosAlumno = alumno.Apellidos,
                              EstatusAlumno = alumno.Estatus,
                              FechadeAltaAlumno = alumno.FechadeAlta,
                              EstadoAlumno = alumno.Estado,
                              SemestreGrado = grados.Semestre,
                              EliminadoAlumno = alumno.Eliminado
                          };

            // Aplicar los filtros
            if (!string.IsNullOrEmpty(nombre))
            {
                alumnos = alumnos.Where(a => !a.NombreAlumno.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                alumnos = alumnos.Where(a => !a.ApellidosAlumno.Contains(apellido));
            }

            if (estado.HasValue)
            {
                alumnos = alumnos.Where(a => !!a.EstadoAlumno == estado.Value);
            }

            var alumnoList = alumnos.ToList();
            return View(alumnoList);
        }



        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumno.Add(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El Alumno se ha Registrado con exito";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if(id == null  || id == 0)
            {
               return NotFound();
            }

            // Obtener Alumno
            var alumno = _context.Alumno.Find(id);   

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        //Http post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumno.Update(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El Alumno se ha Actualizado correctamente";
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

            // Obtener Alumno
            var alumno = _context.Alumno.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }


        [HttpPost]
        public IActionResult Toggle(int id)
        {
       
            var alumno = _context.Alumno.Find(id);
            if (alumno != null)
            {
                alumno.Estado = !alumno.Estado;
                //_context.SaveChanges();
            }

            return Ok(); 
        }

        //Http Get Eliminar
        public IActionResult Eliminar(int id)
        {
            var alumno = _context.Alumno.FirstOrDefault(a => a.Id == id);
            if (alumno != null)
            {
                alumno.Eliminado = false; // Marcar como eliminado
                _context.SaveChanges();
            }



            TempData["mensaje"] = "El alumno se ha eliminado correctamente";
            return RedirectToAction("Index");
        }

    }
}
