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
    public class PistaController : Controller
    {
        private SpotifyContext db = new SpotifyContext();

        // GET: Pista
        public ActionResult Index(string id)
        {
            //return View(db.Pistas.ToList());

            var query = from p in db.Pistas
                        where p.AlbumID == id
                        orderby p.NumeroPista ascending
                        select p;
            return View(query.Include(a => a.Album).ToList());
        }

        // GET: Pista/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // GET: Pista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AlbumID,NombrePista,NumeroPista,Duracion,Popularidad")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                db.Pistas.Add(pista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pista);
        }

        // GET: Pista/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: Pista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AlbumID,NombrePista,NumeroPista,Duracion,Popularidad")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pista);
        }

        // GET: Pista/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = db.Pistas.Find(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: Pista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pista pista = db.Pistas.Find(id);
            db.Pistas.Remove(pista);
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
