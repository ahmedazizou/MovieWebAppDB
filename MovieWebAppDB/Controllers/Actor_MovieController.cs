using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieWebAppDB.Models;

namespace MovieWebAppDB.Controllers
{
    public class Actor_MovieController : Controller
    {
        private MovieWebAppDBContext db = new MovieWebAppDBContext();

        // GET: Actor_Movie
        public ActionResult Index()
        {
            var actors_Movies = db.Actors_Movies.Include(a => a.Actor).Include(a => a.Movie);
            return View(actors_Movies.ToList());
        }

        // GET: Actor_Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor_Movie actor_Movie = db.Actors_Movies.Find(id);
            if (actor_Movie == null)
            {
                return HttpNotFound();
            }
            return View(actor_Movie);
        }

        // GET: Actor_Movie/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name");
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Ratings");
            return View();
        }

        // POST: Actor_Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieId,ActorId")] Actor_Movie actor_Movie)
        {
            if (ModelState.IsValid)
            {
                db.Actors_Movies.Add(actor_Movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", actor_Movie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Ratings", actor_Movie.MovieId);
            return View(actor_Movie);
        }

        // GET: Actor_Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor_Movie actor_Movie = db.Actors_Movies.Find(id);
            if (actor_Movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", actor_Movie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Ratings", actor_Movie.MovieId);
            return View(actor_Movie);
        }

        // POST: Actor_Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieId,ActorId")] Actor_Movie actor_Movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor_Movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", actor_Movie.ActorId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Ratings", actor_Movie.MovieId);
            return View(actor_Movie);
        }

        // GET: Actor_Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor_Movie actor_Movie = db.Actors_Movies.Find(id);
            if (actor_Movie == null)
            {
                return HttpNotFound();
            }
            return View(actor_Movie);
        }

        // POST: Actor_Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor_Movie actor_Movie = db.Actors_Movies.Find(id);
            db.Actors_Movies.Remove(actor_Movie);
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
