using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }

        //para enviar una cadena de caracteres
        public string mensaje()
        {
            return "ejemplo de mensaje simple";
        }

        //para realizar una condicion o un mensaje simple
        public ActionResult mensaje2()
        {
            return Content("mensaje content");
        }

        public ActionResult mensaje3()
        {
            return View("vista"); //sirve para llamar a una vista solo asignas dentro de los () el nombre del .cshtml 
        }

        //enviado con viewdata
        public ActionResult libro1()
        {
            Libro book = new Libro();
            book.codigo = 10;
            book.nombre = "Marco";
            book.precio = 500;
            ViewData["milibro"] = book;
            return View();
        }

        //realizado 
        public ActionResult libro2()
        {
            Libro book = new Libro();
            book.codigo = 16;
            book.nombre = "Roci";
            book.precio = 1500;
            return View(book);
        }

        public ActionResult Agregar() 
        {
            return View("View1");
        }

	}
}