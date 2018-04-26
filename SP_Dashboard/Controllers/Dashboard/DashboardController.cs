using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SP_Dashboard.Models;
using Newtonsoft.Json;

namespace SP_Dashboard.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private SP_DASHBOARDEntities db = new SP_DASHBOARDEntities();
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Dashboard/ConsultancyCenter
        public ActionResult ConsultancyCenter()
        {

            return View();
        }
        // GET: /Dashboard/Internship
        public ActionResult Internship()
        {

            return View();
        }
        // GET: /Dashboard/OverseasInternship
        public ActionResult OverseasInternship()
        {

            return View();
        }
        // GET: /Dashboard/GLP
        public ActionResult GLP()
        {
            var noOfStudents = from u in db.GLP_PROGRAMME select new {x=u.START_DATE,y=u.NO_OF_STUDENTS };
          
            return Json(noOfStudents.ToList());
        }
        // GET: /Dashboard/Entrepreuneurship
        public ActionResult Entrepreuneurship()
        {

            return View();
        }

    }
}