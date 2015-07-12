using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;  

namespace PruebaAcidLabs.Controllers
{
    public class BuscarController : Controller
    {
        // GET: Buscar
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Buscar()
        //{

        //    return View();
        //}

        public ActionResult Buscar()
        {
            string Nombre = "";

            // Retrieve XML document  
            XmlTextReader reader = new XmlTextReader("http://ws.spotify.com/search/1/artist?q=" + Nombre);

            XMLReader readXML = new XMLReader();

            var data = readXML.RetrunListOfProducts();

            return View(data.ToList());
        }
    }
}