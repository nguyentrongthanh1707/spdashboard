using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SP_Dashboard.Models;

namespace SP_Dashboard.Controllers.Admin
{
    public class AdminController : Controller
    {
        private SP_DASHBOARDEntities db = new SP_DASHBOARDEntities();
        // GET: Admin
        public ActionResult Index()
        {
            if (UserManager.Authenticated)
            {
                if (UserManager.Authenticated)
                {
                    TempData["UserLoggedIn"]= UserManager.GetUserEmail;
                    return View();
                }
                HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null) authCookie.Expires = DateTime.Now.AddDays(-1);
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();

                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: /Admin/Login
        public ActionResult Login()
        {
            if (UserManager.Authenticated)
            {
                HttpCookie authCookie =
                    System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null) authCookie.Expires = DateTime.Now.AddDays(-1);
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
            }
            return View();
        }
        //POST: /Admin/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] // This is for output cache false
        public ActionResult Login([Bind(Include = "Email,Password")] ACCOUNT user)
        {
            if (ModelState.IsValid)
            {
                //ModelState.AddModelError("error", "Catcha Validation Success!");
                string ps = Security.EncryptSha1(Security.EncryptMd5(user.PASSWORD).ToLower());
                var login = from u in db.ACCOUNTs
                            where u.EMAIL == user.EMAIL && u.PASSWORD == ps && u.ACTIVED == true
                            select u;
                if (login.Any())
                {
                    string ss = Security.EncryptSha1(Security.EncryptMd5(login.Single().EMAIL + "#" + login.Single().PASSWORD).ToLower());
                    Session["accountDashboard"] = ss;
                    this.Session.Timeout = 60;

                    string data = Security.EncryptStringCbc(login.Single().EMAIL + ";" + login.Single().ACCOUNT_ID+ ";" + login.Single().FULLNAME, "dashboard");
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(data, false);
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    if (ticket != null)
                    {
                        var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                                                                        ticket.IssueDate, ticket.Expiration,
                                                                        ticket.IsPersistent, "");

                        //Update the authCookie's Value to use the encrypted version of newTicket. 
                        authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                    }
                    authCookie.Expires = DateTime.Now.AddMinutes(60);
                    Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", "Wrong email or password");
                    return View();
                }
                
            }

            return View();
        }
        public ActionResult Logout()
        {
            HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null) authCookie.Expires = DateTime.Now.AddDays(-1);
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
       
        
    }
}