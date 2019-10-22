using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class LibroController : Controller
    {
        //
        // GET: /Libro/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult lista()
        {
            var lis = new List<Libro>();
            lis = Libro.Catalogo();
            return View(lis);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Libro l)
        {
            if (ModelState.IsValid)
            {
                Libro b = new Libro();
                b.codigo = l.codigo;
                b.nombre = l.nombre;
                b.precio = l.precio;
                b.grabar();
                //return Content(l.nombre + " Grabado ok");
                return RedirectToAction("lista");
            }
            else
                return View();
        }

        public ActionResult editar(int id)
        {
            Libro l = new Libro();
            l.codigo = id;
            l.leer();
            return View(l);
        }

        [HttpPost]
        public ActionResult editar(Libro l)
        {
            if (ModelState.IsValid)
            {
                Libro b = new Libro();
                b.codigo = l.codigo;
                b.nombre = l.nombre;
                b.precio = l.precio;
                b.actualizar();
                //return Content(l.nombre + " Grabado ok");
                return RedirectToAction("lista");
            }
            else
                return View();
        }

        public ActionResult eliminar(int id)
        {
            Libro l = new Libro();
            l.codigo = id;
            l.leer();
            return View(l);
        }

        [HttpPost, ActionName("eliminar")]
        public ActionResult eliminarConfirmado(int id)
        {
            Libro l = new Libro();
            l.codigo = id;
            l.eliminar();
            return RedirectToAction("lista");
        }
    }
}

	