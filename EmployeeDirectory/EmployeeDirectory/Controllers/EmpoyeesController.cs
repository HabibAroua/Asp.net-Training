using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Controllers
{
    public class EmpoyeesController : Controller
    {
        private EmployeeDirectoryContext db = new EmployeeDirectoryContext();

        // GET: Empoyees
        public ActionResult Index()
        {
            return View(db.Empoyees.ToList());
        }

        // GET: Empoyees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empoyee empoyee = db.Empoyees.Find(id);
            if (empoyee == null)
            {
                return HttpNotFound();
            }
            return View(empoyee);
        }

        // GET: Empoyees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empoyees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fullname,Departement")] Empoyee empoyee)
        {
            if (ModelState.IsValid)
            {
                db.Empoyees.Add(empoyee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empoyee);
        }

        // GET: Empoyees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empoyee empoyee = db.Empoyees.Find(id);
            if (empoyee == null)
            {
                return HttpNotFound();
            }
            return View(empoyee);
        }

        // POST: Empoyees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fullname,Departement")] Empoyee empoyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empoyee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empoyee);
        }

        // GET: Empoyees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empoyee empoyee = db.Empoyees.Find(id);
            if (empoyee == null)
            {
                return HttpNotFound();
            }
            return View(empoyee);
        }

        // POST: Empoyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empoyee empoyee = db.Empoyees.Find(id);
            db.Empoyees.Remove(empoyee);
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
