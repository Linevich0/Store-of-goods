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
    public class AddProductsInfoController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AddProductsInfo
        public ActionResult Index()
        {
            var addProductsInfo = db.AddProductsInfo.Include(a => a.product);
            return View(addProductsInfo.ToList());
        }

        // GET: AddProductsInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddProductInfo addProductInfo = db.AddProductsInfo.Find(id);
            if (addProductInfo == null)
            {
                return HttpNotFound();
            }
            return View(addProductInfo);
        }

        // GET: AddProductsInfo/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name");
            return View();
        }

        // POST: AddProductsInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,price,date")] AddProductInfo addProductInfo)
        {
            if (ModelState.IsValid)
            {
                db.AddProductsInfo.Add(addProductInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", addProductInfo.ProductID);
            return View(addProductInfo);
        }

        // GET: AddProductsInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddProductInfo addProductInfo = db.AddProductsInfo.Find(id);
            if (addProductInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", addProductInfo.ProductID);
            return View(addProductInfo);
        }

        // POST: AddProductsInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,price,date")] AddProductInfo addProductInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addProductInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", addProductInfo.ProductID);
            return View(addProductInfo);
        }

        // GET: AddProductsInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddProductInfo addProductInfo = db.AddProductsInfo.Find(id);
            if (addProductInfo == null)
            {
                return HttpNotFound();
            }
            return View(addProductInfo);
        }

        // POST: AddProductsInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddProductInfo addProductInfo = db.AddProductsInfo.Find(id);
            db.AddProductsInfo.Remove(addProductInfo);
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
