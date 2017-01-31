using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop2.DAL;
using Shop2.Models;

namespace Shop2.Controllers
{
    public class PacksTypesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: PacksTypes
        public ActionResult Index()
        {
            return View(db.PackTypes.ToList());
        }

        // GET: PacksTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // GET: PacksTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacksTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name")] PackType packType)
        {
            if (ModelState.IsValid)
            {
                db.PackTypes.Add(packType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packType);
        }

        // GET: PacksTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // POST: PacksTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name")] PackType packType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packType);
        }

        // GET: PacksTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackType packType = db.PackTypes.Find(id);
            if (packType == null)
            {
                return HttpNotFound();
            }
            return View(packType);
        }

        // POST: PacksTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackType packType = db.PackTypes.Find(id);
            db.PackTypes.Remove(packType);
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
