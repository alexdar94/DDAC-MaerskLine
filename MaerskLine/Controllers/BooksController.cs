using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private MaerskLineEntities4 db = new MaerskLineEntities4();
        private static Book mBook;
        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Customer).Include(b => b.Cargo).Include(b => b.Ship).Include(b => b.Warehouse);
            ViewBag.Role = db.MLUserRoles.Find(User.Identity.Name).Role;
            return View(books.ToList());
        }

        public ActionResult Cargo()
        {
            var books = db.Books.Include(b => b.Customer).Include(b => b.Cargo).Include(b => b.Ship).Include(b => b.Warehouse);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.CargoID = new SelectList(db.Cargoes, "CargoID", "CargoName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,CustomerID,CargoID,ShipID,WarehouseID")] Book book)
        {
            // Go to confirm booking
            return RedirectToAction("Confirm", "Books", book);
        }

        public ActionResult Confirm(Book book)
        {
            mBook = book;
            book.Customer = db.Customers.Find(book.CustomerID);
            book.Cargo = db.Cargoes.Find(book.CargoID);
            book.Ship = db.Ships.Find(book.ShipID);
            book.Warehouse = db.Warehouses.Find(book.WarehouseID);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);

        }

        public ActionResult Save()
        {
            if (ModelState.IsValid)
            {
                db.Cargoes.Attach(mBook.Cargo);
                db.Customers.Attach(mBook.Customer);
                db.Ships.Attach(mBook.Ship);
                db.Warehouses.Attach(mBook.Warehouse);
                db.Books.Add(mBook);
                db.SaveChanges();

                Cargo cargo = db.Cargoes.Find(mBook.CargoID);
                cargo.CargoStatus = "Move To WareHouse";
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ViewSchedule", "Ships");
            }

            //ViewBag.Customer = new SelectList(db.Customers, "CustomerID", "Name", mBook.Customer);
            //ViewBag.CargoID = new SelectList(db.Cargoes, "CargoID", "CargoName");
            //ViewBag.Ship = new SelectList(db.Ships, "ShipID", "ShipName", mBook.Ship);
            //ViewBag.Warehouse = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", mBook.Warehouse);

            return View();
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", book.CustomerID);
            ViewBag.CargoID = new SelectList(db.Cargoes, "CargoID", "CargoName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", book.ShipID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", book.WarehouseID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,CustomerID,CargoID,ShipID,WarehouseID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", book.CustomerID);
            ViewBag.CargoID = new SelectList(db.Cargoes, "CargoID", "CargoName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", book.ShipID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", book.WarehouseID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
