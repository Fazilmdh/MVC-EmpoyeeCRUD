using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using EmployeeMVCCRUD.Models;
using System.Data.Entity;

namespace EmployeeMVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        
        // GET: Employee
        public ActionResult Index()
        {
            using(dbconnections db = new dbconnections())
            {
                return View(db.EMPLOYEEs.ToList());
            }      
        }


        public ActionResult Details(int id)
        {
            using (dbconnections db = new dbconnections())
            {
                return View(db.EMPLOYEEs.Where(x => x.ID == id).FirstOrDefault());
            }              

        }


        // Get: Employee/Create
        public ActionResult Create()
        {
            return View();

        }

        // Post: Employee/Create
        [HttpPost]
        public ActionResult Create(EMPLOYEE emp)
        {
            try
            {
                using (dbconnections db = new dbconnections())
                {

                    db.EMPLOYEEs.Add(emp);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Saved Successfully";
                }
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }


        // Get: Employee/Edit/5
        public ActionResult Edit(int id)
        {

            using (dbconnections db = new dbconnections())
            {
                return View(db.EMPLOYEEs.Where(x => x.ID == id).FirstOrDefault());
            }
        }


        // Post: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EMPLOYEE emp)
        {
            try
            {
                using (dbconnections db = new dbconnections())
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Updated Successfully";
                }
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // Get: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (dbconnections db = new dbconnections())
            {
                return View(db.EMPLOYEEs.Where(x => x.ID == id).FirstOrDefault());
            }

            
        }

        // Post: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EMPLOYEE emp)
        {
            try
            {
                using (dbconnections db = new dbconnections())
                {
                    emp = db.EMPLOYEEs.Where(x => x.ID == id).FirstOrDefault();
                    db.EMPLOYEEs.Remove(emp);
                    db.SaveChanges();

                    TempData["SuccessMessage"] = "Deleted Successfully";
                }
                return RedirectToAction("Index");

            }

            catch
            {
                return View();
            }


            
        }

    }
}