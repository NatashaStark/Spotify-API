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

            if(Nombre != null){
                // Retrieve XML document  
                string Url = "http://ws.spotify.com/search/1/artist?q=" + Nombre;

                XmlDocument myXMLDocument = new XmlDocument();

                myXMLDocument.Load(Url);

                myXMLDocument.Save(Path);
            }

            XMLReader readXML = new XMLReader();
            var data = readXML.RetrunListaArtistas(Path);
            
            return View(data.ToList()); 
        }

        public ActionResult Guardar(string ID, string name, string popularity)
        {
            var art = new Artista();

            art.ID = ID;
            art.NombreArtista = name;
            art.PopularidadArtista = popularity;

            using (var dbCtx = new SpotifyContext())
            {
                dbCtx.Artistas.Add(art);

                dbCtx.SaveChanges();
            }

            //buscando albumes
            string Path = Server.MapPath("~/App_Data/ListaAlbumes.xml");

            if (ID != null)
            {
                // Retrieve XML document  
                string Url = "https://ws.spotify.com/lookup/1/?uri=spotify:artist:" + ID + "&extras=album";

                XmlDocument myXMLDocument = new XmlDocument();

                myXMLDocument.Load(Url);

                myXMLDocument.Save(Path);

                XMLReader readXML = new XMLReader();
                var data = readXML.RetrunListaAlbumes(Path);

                foreach (var album in data.ToList())
                {
                    var alb = new Album();

                    alb.ID = album.ArtistaID + album.ID;
                    alb.ArtistaID = album.ArtistaID;
                    alb.NombreAlbum = album.name;
                    //alb.PopularidadAlbum = album.popularity;
                    alb.Disponibilidad = album.availability;

                    using (var dbCtx = new SpotifyContext())
                    {
                        dbCtx.Albumes.Add(alb);

                        dbCtx.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");
        }

    }
}