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
using PruebaAcidLabs.DAL;
using PruebaAcidLabs.Models;

namespace PruebaAcidLabs.Controllers
{
    public class BuscarController : Controller
    {
        private SpotifyContext db = new SpotifyContext();

        // GET: Buscar
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Guardar(string name, string popularity)
        {
            var art = new Artista();

            art.NombreArtista = name;
            art.PopularidadArtista = popularity;

            using (var dbCtx = new SpotifyContext())
            {
                dbCtx.Artistas.Add(art);

                dbCtx.SaveChanges();
            }

            return null;
        }

    }
}