using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Demo.Helper;
using Demo.Helper.External;

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

        public ActionResult Buscar(string Nombre)
        {
            string Path = Server.MapPath("~/App_Data/ListaArtistas.xml");
            // Retrieve XML document  
            string Url = "http://ws.spotify.com/search/1/artist?q=" + Nombre;

            XmlDocument myXMLDocument = new XmlDocument();

            myXMLDocument.Load(Url);

            myXMLDocument.Save(Path);

            XMLReader readXML = new XMLReader();
            var data = readXML.RetrunListaArtistas(Path);

            return View(data.ToList()); 
        }

    }
}