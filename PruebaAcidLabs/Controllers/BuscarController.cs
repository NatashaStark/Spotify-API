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
            string PathPistas = Server.MapPath("~/App_Data/ListaPistas.xml");

            if (ID != null)
            {
                // Retrieve XML document  
                string Url = "https://ws.spotify.com/lookup/1/?uri=spotify:artist:" + ID + "&extras=albumdetail";

                XmlDocument myXMLDocument = new XmlDocument();

                myXMLDocument.Load(Url);

                myXMLDocument.Save(Path);

                XMLReader readXML = new XMLReader();
                var data = readXML.RetrunListaAlbumes(Path);

                foreach (var album in data.ToList())
                {
                    var alb = new Album();

                    alb.ID = album.ID + art.ID;
                    alb.ArtistaID = album.ArtistaID;
                    alb.NombreAlbum = album.name;
                    //alb.PopularidadAlbum = album.popularity;
                    alb.Disponibilidad = album.availability;
                    alb.Año = album.released;

                    using (var dbCtx = new SpotifyContext())
                    {
                        dbCtx.Albumes.Add(alb);

                        dbCtx.SaveChanges();
                    }

                    // Retrieve XML document  
                    string UrlPista = "https://ws.spotify.com/lookup/1/?uri=spotify:album:" + album.ID + "&extras=trackdetail";

                    XmlDocument myXMLDocumentPista = new XmlDocument();

                    myXMLDocumentPista.Load(UrlPista);

                    myXMLDocumentPista.Save(PathPistas);

                    XMLReader readXMLPista = new XMLReader();
                    var dataPista = readXMLPista.RetrunListaPistas(PathPistas);

                    foreach (var track in dataPista.ToList())
                    {
                        var tra = new Pista();

                        tra.ID = track.ID + alb.ID;
                        tra.AlbumID = alb.ID;
                        tra.NombrePista = track.name;
                        tra.Popularidad = track.popularity;
                        tra.Duracion = track.length;
                        tra.NumeroPista = Convert.ToInt32(track.tracknumber);

                        using (var dbCtxPista = new SpotifyContext())
                        {
                            dbCtxPista.Pistas.Add(tra);

                            dbCtxPista.SaveChanges();
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }

    }
}