using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaAcidLabs.DAL;
using PruebaAcidLabs.Models;

namespace PruebaAcidLabs.Controllers
{
    public class AlbumController : Controller
    {
        private SpotifyContext db = new SpotifyContext();

        // GET: Album
        public ActionResult Index(string id)
        {
            //var albumes = db.Albumes.Include(a => a.Artista);

            using (var db = new SpotifyContext())
            {
                var query = from p in db.Albumes
                            where p.ArtistaID == id
                            select p;
                return View(query.Include(a => a.Artista).ToList());
            }
        }

        // GET: Album/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albumes.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "NombreArtista");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArtistaID,NombreAlbum,PopularidadAlbum,Disponibilidad")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albumes.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "NombreArtista", album.ArtistaID);
            return View(album);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albumes.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "NombreArtista", album.ArtistaID);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArtistaID,NombreAlbum,PopularidadAlbum,Disponibilidad")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ID", "NombreArtista", album.ArtistaID);
            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albumes.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Album album = db.Albumes.Find(id);
            db.Albumes.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
