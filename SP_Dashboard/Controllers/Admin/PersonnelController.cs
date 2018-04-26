using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SP_Dashboard.Models;

namespace SP_Dashboard.Controllers.Admin
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        private SP_DASHBOARDEntities db = new SP_DASHBOARDEntities();
        public ActionResult Index()
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        //GET:/Personnel/Student
        public ActionResult Student()
        {
            var studentList = (from student in db.STUDENTs select student).ToList();
            return PartialView("_StudentPartial", studentList);
        }
        //GET:/Personnel/Student
        public ActionResult Staff()
        {
            var staffList = (from staff in db.STAFFs select staff).ToList();
            return PartialView("_StaffPartial", staffList);
        }
        //GET:/Personnel/Student
        public ActionResult Business()
        {
            var businessList = (from business in db.COMPANies select business).ToList();
            return PartialView("_BusinessPartial", businessList);
        }

        public ActionResult DeleteStudent(string id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT stu = db.STUDENTs.Find(id);
            if(stu == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.STUDENTs.Remove(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteStaff(string id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF staff = db.STAFFs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.STAFFs.Remove(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteBusiness(decimal? id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY com = db.COMPANies.Find(id);
            if (com == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.COMPANies.Remove(com);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        //GET:/Personnel/EditBusiness/{id}
        public ActionResult EditBusiness(decimal? id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            COMPANY com = db.COMPANies.Find(id);
            if (com == null)
            {
                return HttpNotFound();
            }
            ViewBag.COUNTRY_ID = new SelectList(db.COUNTRies, "COUNTRY_ID", "COUNTRY_NAME",com.COUNTRY_ID);
            return View(com);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST:/Personnel/EditBusiness/{id}
        public ActionResult EditBusiness([Bind(Include = "COMPANY_ID,UEN," +
            "COMPANY_NAME,COUNTRY_ID,COMPANY_ID,COMPANY_DESCRIPTION")] COMPANY com)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if(com.UEN +"" == "")
                {
                    ModelState.AddModelError("error", "Please enter company UEN");
                    valid = false;
                }
                if (com.COMPANY_NAME + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter company name");
                    valid = false;
                }
                if (valid)
                {
                    db.Entry(com).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.COUNTRY_ID = new SelectList(db.COUNTRies, "COUNTRY_ID", "COUNTRY_NAME", com.COUNTRY_ID);
            return View(com);
        }
    }
}