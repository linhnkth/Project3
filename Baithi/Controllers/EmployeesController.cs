﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baithi.Data;
using Baithi.Models;

namespace Baithi.Controllers
{
    public class EmployeesController : Controller
    {
        private BaithiContext db = new BaithiContext();

        // GET: Employees
        public ActionResult Index()
        {
            try
            {
                return View(db.Employees.ToList());
            }
            catch
            {
                return View("~View/Share/Error.cshtml");
            }
        
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch 
            {
                return View("~View/Share/Error.cshtml");

            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,Department,Salary")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View("~View/Share/Error.cshtml");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch
            {
                return View("~View/Share/Error.cshtml");

            }
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,Department,Salary")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);

            }
            catch
            {
                return View("~View/Share/Error.cshtml");

            }
        }
        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch
            {
                return View("~View/Share/Error.cshtml");

            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
