using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmManagementSystemMVC.Models;

namespace FilmManagementSystemMVC.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        private FMSEntities db = new FMSEntities();

        public ActionResult Index()
        {
            var films = db.Films.Include(f => f.Actor).Include(f => f.Category).Include(f => f.Language);
            return View(films.ToList());
        }

        public ActionResult Index2(List<Film> p)
        {
            return View(p);
        }

        [HttpPost]
        public ActionResult SearchIndex(FormCollection formCollection)
        {
            string searchBox = formCollection["searchBox"];
            string searchText = formCollection["searchText"];
            if (searchBox == "Default")
            {
                return View("Index",db.Films.ToList());
            }
            if (searchBox == "Title")
            {
                return View("Index", db.Films.Where(x => x.Title.ToString() == searchText));

            }

            else if (searchBox == "Rating")
            {
                decimal d = Convert.ToDecimal(searchText);
                return View("Index", db.Films.Where(x => x.Rating ==d ));

            }
            else if (searchBox == "Language")
            {
                return View("Index",  db.Films.Where(x => x.Language.Name == searchText));

            }
            else if (searchBox == "Genre")
            {

                return View("Index", db.Films.Where(x => x.Category.Name == searchText));
            }
            else if (searchBox == "Actor")
            {

                return View("Index", db.Films.Where(x => x.Actor.FirstName == searchText));

            }
            else
            {
                return RedirectToAction("Index", "Films");
            }
            
        }

        public ActionResult Details(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmID,Description,Title,ReleaseYear,RentalDuration,ReplacementCost,LanguageId,Length,Rating,ActorId,CategoryId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", film.ActorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", film.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Name", film.LanguageId);
            return View(film);
        }

        public ActionResult Edit(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", film.ActorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", film.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Name", film.LanguageId);
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmID,Description,Title,ReleaseYear,RentalDuration,ReplacementCost,LanguageId,Length,Rating,ActorId,CategoryId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", film.ActorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", film.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Name", film.LanguageId);
            return View(film);
        }

        public ActionResult Delete(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
