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
    public class MLUserRolesController : Controller
    {
        private MaerskLineEntities4 db = new MaerskLineEntities4();

        // GET: MLUserRoles
        public ActionResult Index()
        {
            return View(db.MLUserRoles.ToList());
        }

        // GET: MLUserRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MLUserRole mLUserRole = db.MLUserRoles.Find(id);
            if (mLUserRole == null)
            {
                return HttpNotFound();
            }
            return View(mLUserRole);
        }

        // GET: MLUserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MLUserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Role")] MLUserRole mLUserRole)
        {
            if (ModelState.IsValid)
            {
                db.MLUserRoles.Add(mLUserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mLUserRole);
        }

        // GET: MLUserRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MLUserRole mLUserRole = db.MLUserRoles.Find(id);
            if (mLUserRole == null)
            {
                return HttpNotFound();
            }
            return View(mLUserRole);
        }

        // POST: MLUserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Role")] MLUserRole mLUserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mLUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mLUserRole);
        }

        // GET: MLUserRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MLUserRole mLUserRole = db.MLUserRoles.Find(id);
            if (mLUserRole == null)
            {
                return HttpNotFound();
            }
            return View(mLUserRole);
        }

        // POST: MLUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MLUserRole mLUserRole = db.MLUserRoles.Find(id);
            db.MLUserRoles.Remove(mLUserRole);
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
