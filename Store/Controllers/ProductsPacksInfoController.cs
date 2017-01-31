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
    public class ProductsPacksInfoController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: ProductsPacksInfo
        public ActionResult Index()
        {
            var productsPackInfo = db.ProductsPackInfo.Include(p => p.packType).Include(p => p.product);
            return View(productsPackInfo.ToList());
        }

        // GET: ProductsPacksInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPackInfo productPackInfo = db.ProductsPackInfo.Find(id);
            if (productPackInfo == null)
            {
                return HttpNotFound();
            }
            return View(productPackInfo);
        }

        // GET: ProductsPacksInfo/Create
        public ActionResult Create()
        {
            ViewBag.PackTypeID = new SelectList(db.PackTypes, "ID", "name");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name");
            return View();
        }

        // POST: ProductsPacksInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,PackTypeID,quantity")] ProductPackInfo productPackInfo)
        {
            if (ModelState.IsValid)
            {
                db.ProductsPackInfo.Add(productPackInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackTypeID = new SelectList(db.PackTypes, "ID", "name", productPackInfo.PackTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", productPackInfo.ProductID);
            return View(productPackInfo);
        }

        // GET: ProductsPacksInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPackInfo productPackInfo = db.ProductsPackInfo.Find(id);
            if (productPackInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackTypeID = new SelectList(db.PackTypes, "ID", "name", productPackInfo.PackTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", productPackInfo.ProductID);
            return View(productPackInfo);
        }

        // POST: ProductsPacksInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,PackTypeID,quantity")] ProductPackInfo productPackInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productPackInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackTypeID = new SelectList(db.PackTypes, "ID", "name", productPackInfo.PackTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", productPackInfo.ProductID);
            return View(productPackInfo);
        }

        // GET: ProductsPacksInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPackInfo productPackInfo = db.ProductsPackInfo.Find(id);
            if (productPackInfo == null)
            {
                return HttpNotFound();
            }
            return View(productPackInfo);
        }

        // POST: ProductsPacksInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductPackInfo productPackInfo = db.ProductsPackInfo.Find(id);
            db.ProductsPackInfo.Remove(productPackInfo);
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
