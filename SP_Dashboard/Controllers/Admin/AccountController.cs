using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SP_Dashboard.Models;

namespace SP_Dashboard.Controllers.Admin
{
    
    public class AccountController : Controller
    {
        private SP_DASHBOARDEntities db = new SP_DASHBOARDEntities();

        //GET:/Account/
        public ActionResult Index()
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            var accounts = from u in db.ACCOUNTs
                        join y in db.ROLES on u.ROLE_ID equals y.ROLE_ID
                        select u;
            return View(accounts.ToList());
        }
        //GET: /Account/Create
        public ActionResult Create()
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.RoleID = new SelectList(db.ROLES, "ROLE_ID", "ROLE_NAME");
            return View();
        }
        //POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Account_ID,Email,Password,ConfirmPassword,RoleID")] RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if (user.Email + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter email address");
                    valid = false;
                }
                if (user.Password + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter password");
                    valid = false;
                }
                var checkExist = db.ACCOUNTs.Where(m => m.EMAIL == user.Email).ToList();
                if (checkExist.Any())
                {
                    ModelState.AddModelError("error", "Email existed. Please use another email.");
                    valid = false;
                }
                if (valid)
                {
                    ACCOUNT acc = new ACCOUNT();
                    var maxID = db.ACCOUNTs.Max(u => u.ACCOUNT_ID);
                    acc.ACCOUNT_ID = maxID + 1;
                    acc.EMAIL = user.Email;
                    string ps = Security.EncryptSha1(Security.EncryptMd5(user.Password).ToLower());
                    acc.PASSWORD = ps;
                    acc.ROLE_ID = user.RoleID;
                    acc.ACTIVED = false;
                    db.ACCOUNTs.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.RoleID = new SelectList(db.ROLES, "ROLE_ID", "ROLE_NAME", user.RoleID);
            return View(user);
        }

        //GET:/Account/Edit/id
        public ActionResult Edit(decimal? id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if ((id + "").Trim() == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!ValidInput.validDecimal(id + ""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT acc = db.ACCOUNTs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLE_ID = new SelectList(db.ROLES, "ROLE_ID", "ROLE_NAME", acc.ROLE_ID);
            return View(acc);
        }
        //POST:/Account/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACCOUNT_ID,EMAIL,PASSWORD,ROLE_ID,ACTIVED")] ACCOUNT acc)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if(acc.EMAIL + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter email address");
                    valid = false;
                }
                if (acc.PASSWORD + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter password");
                    valid = false;
                }
                if (acc.ROLE_ID + "" == "")
                {
                    ModelState.AddModelError("error", "Please select role");
                    valid = false;
                }
                if (valid)
                {
                    db.Entry(acc).State = EntityState.Modified;
                    if (Request.Form["AllowChangePass"] == "on" ? true : false)
                    {
                        string ps = Security.EncryptSha1(Security.EncryptMd5(acc.PASSWORD).ToLower());
                        acc.PASSWORD = ps;
                        db.Entry(acc).Property("PASSWORD").IsModified = true;
                    }
                    else
                    {
                        db.Entry(acc).Property("PASSWORD").IsModified = false;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ROLE_ID = new SelectList(db.ROLES, "ROLE_ID", "ROLE_NAME", acc.ROLE_ID);
            return View(acc);
        }

        //GET: /Account/Delete/id
        
        public ActionResult Delete(decimal? id)
        {
            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT acc = db.ACCOUNTs.Find(id);
            db.ACCOUNTs.Remove(acc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}