using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKinver.Models;

namespace MVCKinver.Controllers
{ 
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private KinverEntities db = new KinverEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var products = db.Products.Include(p => p.Genre).Include(p => p.Producer);
            return View(products.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", product.ProducerId);
            return View(product);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", product.ProducerId);
            return View(product);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "Name", product.ProducerId);
            return View(product);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}