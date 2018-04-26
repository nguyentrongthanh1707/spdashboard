using SP_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SP_Dashboard.Controllers.Admin
{
    public class ProjectController : Controller
    {
        // GET: /Project
        private SP_DASHBOARDEntities db = new SP_DASHBOARDEntities();
        public ActionResult Index()
        {

            if (!UserManager.Authenticated)
            {
                return RedirectToAction("Login", "Admin");
            }
            //Take only the dashboard type have projects
            var dashboardProjectList = (from d in db.DASHBOARD_TYPE
                                        where d.DASHBOARD_TYPE_ID == 1 || d.DASHBOARD_TYPE_ID == 2 || d.DASHBOARD_TYPE_ID == 3
                                        select d).ToList();
            ViewBag.DashboardList = new SelectList(dashboardProjectList, "DASHBOARD_TYPE_ID", "DASHBOARD_TYPE_NAME");
            return View();
        }
        //GET:/Project/LoadPartialConsultancy
        public ActionResult LoadPartialConsultancy()
        {
            var query = (from i in db.CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP
                         join j in db.CONSULTANCY_PROJECT_TYPE on i.CONSULTANCY_PROJECT_TYPE_ID equals j.CONSULTANCY_PROJECT_TYPE_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join sta in db.PROJECT_STATUS on i.PROJECT_STATUS_ID equals sta.PROJECT_STATUS_ID
                         join con in db.CONSULTANCY_CENTRE on i.CONSULTANCY_CENTRE_ID equals con.CONSULTANCY_CENTRE_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         where i.DASHBOARD_TYPE_ID == 1
                         select new
                         {
                             i.PROJECT_ID,
                             i.PROJECT_REFERENCE,
                             i.PROJECT_TITLE,
                             j.CONSULTANCY_PROJECT_TYPE_NAME,
                             con.CONSULTANCY_CENTRE_NAME, //con.UEN,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.CONTACT_PERSON,
                             sta.PROJECT_STATUS_NAME,
                             i.DASHBOARD_TYPE_ID
                         })
                             .ToList();
            //UEN of Company or consultancy centre??
            var model = new List<ConsultancyCentre>();
            for (int i = 0; i < query.Count(); i++)
            {
                var item = query[i];
                var consultancyModel = new ConsultancyCentre()
                {
                    PROJECT_ID = item.PROJECT_ID,
                    PROJECT_REFERENCE = item.PROJECT_REFERENCE,
                    PROJECT_TITLE = item.PROJECT_TITLE,
                    CONSULTANCY_PROJECT_TYPE_NAME = item.CONSULTANCY_PROJECT_TYPE_NAME,
                    CONSULTANCY_CENTRE_NAME = item.CONSULTANCY_CENTRE_NAME,
                    UEN = item.UEN,
                    COMPANY_NAME = item.COMPANY_NAME,
                    CONTACT_PERSON = item.CONTACT_PERSON,
                    PROJECT_STATUS_NAME = item.PROJECT_STATUS_NAME,
                    DASHBOARD_TYPE_ID = item.DASHBOARD_TYPE_ID
                };
                model.Add(consultancyModel);
            }
            return PartialView("_ConsultancyManagementPartial", model);
        }
        //GET:/Project/LoadPartialInternship
        public ActionResult LoadPartialInternship()
        {
            var query = (from i in db.INTERNSHIP_PROJECT
                         join j in db.INTERNSHIP_PROJECT_TYPE on i.INTERNSHIP_PROJECT_TYPE_ID equals j.INTERNSHIP_PROJECT_TYPE_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join c in db.COUNTRies on i.COUNTRY_ID equals c.COUNTRY_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         where i.DASHBOARD_TYPE_ID == 2
                         select new
                         {
                             i.INTERNSHIP_ID,
                             i.INTERNSHIP_REFERENCE,
                             j.INTERNSHIP_PROJECT_TYPE_NAME,
                             c.COUNTRY_NAME,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.CONTACT_PERSON,
                             i.DASHBOARD_TYPE_ID
                         })
                             .ToList();
            var model = new List<Internship>();
            for (int i = 0; i < query.Count(); i++)
            {
                var item = query[i];
                var internshipModel = new Internship()
                {
                    INTERNSHIP_ID = item.INTERNSHIP_ID,
                    INTERNSHIP_REFERENCE = item.INTERNSHIP_REFERENCE,
                    INTERNSHIP_PROJECT_TYPE_NAME = item.INTERNSHIP_PROJECT_TYPE_NAME,
                    COUNTRY_NAME = item.COUNTRY_NAME,
                    COMPANY_NAME = item.COMPANY_NAME,
                    UEN = item.UEN,
                    CONTACT_PERSON = item.CONTACT_PERSON,
                    DASHBOARD_TYPE_ID = item.DASHBOARD_TYPE_ID
                };
                model.Add(internshipModel);
            }
            return PartialView("_InternshipManagementPartial", model);
        }
        //GET:/Project/LoadPartialInternshipOverseas
        public ActionResult LoadPartialInternshipOverseas()
        {
            var query = (from i in db.INTERNSHIP_PROJECT_FOR_OVERSEAS
                         join j in db.INTERNSHIP_PROJECT_TYPE on i.INTERNSHIP_PROJECT_TYPE_ID equals j.INTERNSHIP_PROJECT_TYPE_ID
                         join area in db.PROJECT_AREA on i.PROJECT_AREA_ID equals area.PROJECT_AREA_ID
                         join sta in db.PROJECT_STATUS on i.PROJECT_STATUS_ID equals sta.PROJECT_STATUS_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join c in db.COUNTRies on i.COUNTRY_ID equals c.COUNTRY_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         where i.DASHBOARD_TYPE_ID == 3
                         select new
                         {
                             i.PROJECT_ID,
                             i.PROJECT_REFERENCE,
                             j.INTERNSHIP_PROJECT_TYPE_NAME,
                             area.PROJECT_AREA_NAME,
                             c.COUNTRY_NAME,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.PROJECT_SUPERVISOR, /*i. START_DATE, i.END_DATE,*/
                             sta.PROJECT_STATUS_NAME,
                             i.DASHBOARD_TYPE_ID
                         })
                            .ToList();
            var model = new List<OverseasInternship>();
            for (int i = 0; i < query.Count(); i++)
            {
                var item = query[i];
                var overseasModel = new OverseasInternship()
                {
                    PROJECT_ID = item.PROJECT_ID,
                    PROJECT_REFERENCE = item.PROJECT_REFERENCE,
                    INTERNSHIP_PROJECT_TYPE_NAME = item.INTERNSHIP_PROJECT_TYPE_NAME,
                    PROJECT_AREA_NAME = item.PROJECT_AREA_NAME,
                    COUNTRY_NAME = item.COUNTRY_NAME,
                    COMPANY_NAME = item.COMPANY_NAME,
                    UEN = item.UEN,
                    PROJECT_SUPERVISOR = item.PROJECT_SUPERVISOR,
                    //START_DATE = item.START_DATE,
                    //END_DATE = item.END_DATE,
                    PROJECT_STATUS_NAME = item.PROJECT_STATUS_NAME,
                    DASHBOARD_TYPE_ID = item.DASHBOARD_TYPE_ID
                };
                model.Add(overseasModel);
            }
            return PartialView("_OverseasInternshipManagementPartial", model);
        }

        //GET: /Project/Details/{DashboardId}{projectId}
        public ActionResult Details(decimal? DashboardId, decimal? projectId)
        {
            if (DashboardId + "" == "" || projectId + "" == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!ValidInput.validDecimal(projectId + "") || !ValidInput.validDecimal(DashboardId + ""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.DashboardId = DashboardId;
            if (DashboardId == 1)
            {
                ConsultancyCentre proj = GetConsultancyProjDetails(projectId);
                ViewBag.ConsultancyProject = proj;
                return View(proj);
            }
            if (DashboardId == 2)
            {
                Internship proj = GetInternshipProjDetails(projectId);
                ViewBag.InternshipProject = proj;
                return View(proj);
            }
            if (DashboardId == 3)
            {
                OverseasInternship proj = GetOverseasInternshipProjDetails(projectId);
               
                ViewBag.OverseasInternshipProject = proj;
                return View(proj);
            }
            return View();

        }
        //Get: /Project/EditConsultancyProj/{projectId}
        public ActionResult EditConsultancyProj(decimal? projectId)
        {

            if (projectId + "" == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!ValidInput.validDecimal(projectId + ""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultancyCentre proj = GetConsultancyProjDetails(projectId);
            if (proj == null)
            {
                return HttpNotFound();
            }
            ViewBag.CONSULTANCY_PROJECT_TYPE_ID = new SelectList(
                db.CONSULTANCY_PROJECT_TYPE, "CONSULTANCY_PROJECT_TYPE_ID", "CONSULTANCY_PROJECT_TYPE_NAME", proj.CONSULTANCY_PROJECT_TYPE_ID);
            ViewBag.CONSULTANCY_CENTRE_ID = new SelectList(
                db.CONSULTANCY_CENTRE, "CONSULTANCY_CENTRE_ID", "CONSULTANCY_CENTRE_NAME", proj.CONSULTANCY_CENTRE_ID);
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", proj.COMPANY_ID);
            ViewBag.OVERSEAS_COUNTRY_ID = new SelectList(db.COUNTRies, "COUNTRY_ID", "COUNTRY_NAME", proj.OVERSEAS_COUNTRY_ID);
            ViewBag.PROJECT_STATUS_ID = new SelectList(
                db.PROJECT_STATUS, "PROJECT_STATUS_ID", "PROJECT_STATUS_NAME", proj.PROJECT_STATUS_ID);
            return View(proj);
            
        }
        //POST: /Project/Edit/{DashboardId}{projectId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConsultancyProj([Bind(Include =
            "PROJECT_ID,PROJECT_REFERENCE,PROJECT_TITLE,CONSULTANCY_PROJECT_TYPE_ID,CONSULTANCY_CENTRE_ID," +
            "COMPANY_ID,CONTACT_PERSON,PROJECT_ACCEPTANCE_DATE,START_DATE,END_DATE,NO_OF_STAFFS," +
            "NO_OF_STUDENTS,REVENUE,CONSUMABLES_COST,FACILITY_COST,INSURANCE_COST,CENTRE_COST,PROJECT_COMPLETTION_DATE," +
            "PROJECT_STATUS_ID")] ConsultancyCentre con)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if(con.PROJECT_REFERENCE + "" =="")
                {
                    ModelState.AddModelError("error", "Please enter project reference");
                    valid = false;
                }
                if (con.PROJECT_TITLE + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter project title");
                    valid = false;
                }
                if (valid)
                {
                    CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP proj = db.CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP.Find(con.PROJECT_ID);
                    proj.PROJECT_REFERENCE = con.PROJECT_REFERENCE;
                    proj.PROJECT_TITLE = con.PROJECT_TITLE;
                    proj.CONSULTANCY_PROJECT_TYPE_ID = con.CONSULTANCY_PROJECT_TYPE_ID;
                    proj.CONSULTANCY_CENTRE_ID = con.CONSULTANCY_CENTRE_ID;
                    proj.COMPANY_ID = con.COMPANY_ID;
                    proj.CONTACT_PERSON = con.CONTACT_PERSON;
                    proj.PROJECT_ACCEPTANCE_DATE = con.PROJECT_ACCEPTANCE_DATE;
                    proj.START_DATE = con.START_DATE;
                    proj.END_DATE = con.END_DATE;
                    proj.NO_OF_STAFFS = con.NO_OF_STAFFS;
                    proj.NO_OF_STUDENTS = con.NO_OF_STUDENTS;
                    proj.REVENUE = con.REVENUE;
                    proj.CONSUMABLES_COST = con.CONSUMABLES_COST;
                    proj.FACILITY_COST = con.FACILITY_COST;
                    proj.INSURANCE_COST = con.INSURANCE_COST;
                    proj.PROJECT_COMPLETTION_DATE = con.PROJECT_COMPLETTION_DATE;
                    proj.PROJECT_STATUS_ID = con.PROJECT_STATUS_ID;
                    TempData["alertMessage"] = "Save successfully!";
                    db.SaveChanges();
                    return RedirectToAction("Details",new {dashboardId= proj.DASHBOARD_TYPE_ID, projectId = proj.PROJECT_ID });
                }
            }
            return View(con);
        }

        //GET: /Project/EditInternshipProj/{projectId}
        public ActionResult EditInternshipProj(decimal? projectId)
        {
            if (projectId + "" == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!ValidInput.validDecimal(projectId + ""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship proj = GetInternshipProjDetails(projectId);
            if (proj == null)
            {
                return HttpNotFound();
            }
            ViewBag.InternshipProject = proj;
            ViewBag.INTERNSHIP_PROJECT_TYPE_ID = new SelectList(
               db.INTERNSHIP_PROJECT_TYPE, "INTERNSHIP_PROJECT_TYPE_ID", "INTERNSHIP_PROJECT_TYPE_NAME", proj.INTERNSHIP_PROJECT_TYPE_ID);
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", proj.COMPANY_ID);
            ViewBag.COUNTRY_ID = new SelectList(db.COUNTRies, "COUNTRY_ID", "COUNTRY_NAME", proj.COUNTRY_ID);
            return View(proj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInternshipProj([Bind(Include = "INTERNSHIP_ID,INTERNSHIP_REFERENCE," +
            "INTERNSHIP_PROJECT_TYPE_ID,COUNTRY_ID,COMPANY_ID,CONTACT_PERSON,SCORE")] Internship i)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if (i.INTERNSHIP_REFERENCE + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter project reference");
                    valid = false;
                }
                if (valid)
                {
                    INTERNSHIP_PROJECT proj = db.INTERNSHIP_PROJECT.Find(i.INTERNSHIP_ID);
                    proj.INTERNSHIP_REFERENCE = i.INTERNSHIP_REFERENCE;
                    proj.INTERNSHIP_PROJECT_TYPE_ID = i.INTERNSHIP_PROJECT_TYPE_ID;
                    proj.COUNTRY_ID = i.COUNTRY_ID;
                    proj.COMPANY_ID = i.COMPANY_ID;
                    proj.CONTACT_PERSON = i.CONTACT_PERSON;
                    proj.SCORE = i.SCORE;
                    //proj.NO_OF_STUDENTS = i.NO_OF_STUDENTS;
                    //proj.COST_TO_SP = i.COST_TO_SP;
                    TempData["alertMessage"] = "Save successfully!";
                    db.SaveChanges();
                    return RedirectToAction("Details", new { dashboardId = proj.DASHBOARD_TYPE_ID, projectId = proj.INTERNSHIP_ID });
                }
            }
            return View(i);
        }

        //GET: /Project/EditOverseasInternshipProj/{projectId}
        public ActionResult EditOverseasInternshipProj(decimal? projectId)
        {
            if (projectId + "" == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!ValidInput.validDecimal(projectId + ""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverseasInternship proj = GetOverseasInternshipProjDetails(projectId);
            if (proj == null)
            {
                return HttpNotFound();
            }
            ViewBag.INTERNSHIP_PROJECT_TYPE_ID = new SelectList(
               db.INTERNSHIP_PROJECT_TYPE, "INTERNSHIP_PROJECT_TYPE_ID", "INTERNSHIP_PROJECT_TYPE_NAME", proj.INTERNSHIP_PROJECT_TYPE_ID);
            ViewBag.PROJECT_AREA_ID = new SelectList(
                db.PROJECT_AREA, "PROJECT_AREA_ID", "PROJECT_AREA_NAME", proj.PROJECT_AREA_ID);
            ViewBag.COUNTRY_ID = new SelectList(db.COUNTRies, "COUNTRY_ID", "COUNTRY_NAME", proj.COUNTRY_ID);
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", proj.COMPANY_ID);
            ViewBag.PROJECT_STATUS_ID = new SelectList(
                db.PROJECT_STATUS, "PROJECT_STATUS_ID", "PROJECT_STATUS_NAME", proj.PROJECT_STATUS_ID);
            return View(proj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOverseasInternshipProj([Bind(Include = "PROJECT_ID,PROJECT_REFERENCE," +
            "INTERNSHIP_PROJECT_TYPE_ID,PROJECT_AREA_ID,COUNTRY_ID,COMPANY_ID,PROJECT_SUPERVISOR,PROJECT_ACCEPTANCE_DATE," +
            "START_DATE,END_DATE,REVENUE,EXPENSES,PROJECT_STATUS_ID")] OverseasInternship i)
        {
            if (ModelState.IsValid)
            {
                bool valid = true;
                if (i.PROJECT_REFERENCE + "" == "")
                {
                    ModelState.AddModelError("error", "Please enter project reference");
                    valid = false;
                }
                if (valid)
                {
                    INTERNSHIP_PROJECT_FOR_OVERSEAS proj = db.INTERNSHIP_PROJECT_FOR_OVERSEAS.Find(i.PROJECT_ID);
                    proj.PROJECT_REFERENCE = i.PROJECT_REFERENCE;
                    proj.PROJECT_AREA_ID = i.PROJECT_AREA_ID;
                    proj.INTERNSHIP_PROJECT_TYPE_ID = i.INTERNSHIP_PROJECT_TYPE_ID;
                    proj.COUNTRY_ID = i.COUNTRY_ID;
                    proj.COMPANY_ID = i.COMPANY_ID;
                    proj.PROJECT_SUPERVISOR = i.PROJECT_SUPERVISOR;
                    proj.PROJECT_ACCEPTANCE_DATE = i.PROJECT_ACCEPTANCE_DATE;
                    proj.START_DATE = i.START_DATE;
                    proj.END_DATE = i.END_DATE;
                    proj.REVENUE = i.REVENUE;
                    proj.EXPENSES = i.EXPENSES;
                    proj.PROJECT_STATUS_ID = i.PROJECT_STATUS_ID;
                    TempData["alertMessage"] = "Save successfully!";
                    db.SaveChanges();
                    return RedirectToAction("Details", new { dashboardId = proj.DASHBOARD_TYPE_ID, projectId = proj.PROJECT_ID });
                }
            }
            return View(i);
        }
        #region Get project details functions
        private OverseasInternship GetOverseasInternshipProjDetails(decimal? projectId)
        {
            var query = (from i in db.INTERNSHIP_PROJECT_FOR_OVERSEAS
                         join j in db.INTERNSHIP_PROJECT_TYPE on i.INTERNSHIP_PROJECT_TYPE_ID equals j.INTERNSHIP_PROJECT_TYPE_ID
                         join area in db.PROJECT_AREA on i.PROJECT_AREA_ID equals area.PROJECT_AREA_ID
                         join sta in db.PROJECT_STATUS on i.PROJECT_STATUS_ID equals sta.PROJECT_STATUS_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join c in db.COUNTRies on i.COUNTRY_ID equals c.COUNTRY_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         where i.DASHBOARD_TYPE_ID == 3 && i.PROJECT_ID == projectId
                         select new
                         {
                             i.PROJECT_ID,
                             i.PROJECT_REFERENCE,
                             j.INTERNSHIP_PROJECT_TYPE_ID,
                             j.INTERNSHIP_PROJECT_TYPE_NAME,
                             area.PROJECT_AREA_ID,
                             area.PROJECT_AREA_NAME,
                             c.COUNTRY_ID,
                             c.COUNTRY_NAME,
                             com.COMPANY_ID,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.PROJECT_SUPERVISOR,
                             i.PROJECT_ACCEPTANCE_DATE,
                             i.START_DATE,
                             i.END_DATE,
                             i.REVENUE,
                             i.EXPENSES,
                             sta.PROJECT_STATUS_ID,
                             sta.PROJECT_STATUS_NAME,
                             i.DASHBOARD_TYPE_ID
                         }).FirstOrDefault();
            var proj = new OverseasInternship()
            {
                PROJECT_ID = query.PROJECT_ID,
                PROJECT_REFERENCE = query.PROJECT_REFERENCE,
                INTERNSHIP_PROJECT_TYPE_ID = query.INTERNSHIP_PROJECT_TYPE_ID,
                INTERNSHIP_PROJECT_TYPE_NAME = query.INTERNSHIP_PROJECT_TYPE_NAME,
                PROJECT_AREA_ID = query.PROJECT_AREA_ID,
                PROJECT_AREA_NAME= query.PROJECT_AREA_NAME,
                COUNTRY_ID = query.COUNTRY_ID,
                COUNTRY_NAME = query.COUNTRY_NAME,
                COMPANY_ID = query.COMPANY_ID,
                COMPANY_NAME = query.COMPANY_NAME,
                UEN = query.UEN,
                PROJECT_SUPERVISOR = query.PROJECT_SUPERVISOR,
                PROJECT_ACCEPTANCE_DATE = query.PROJECT_ACCEPTANCE_DATE,
                START_DATE = query.START_DATE,
                END_DATE = query.END_DATE,
                REVENUE = query.REVENUE,
                EXPENSES = query.EXPENSES,
                PROJECT_STATUS_ID = query.PROJECT_STATUS_ID,
                PROJECT_STATUS_NAME = query.PROJECT_STATUS_NAME,
                DASHBOARD_TYPE_ID = query.DASHBOARD_TYPE_ID
            };
            return proj;
        }

        private Internship GetInternshipProjDetails(decimal? projectId)
        {
            var query = (from i in db.INTERNSHIP_PROJECT
                         join j in db.INTERNSHIP_PROJECT_TYPE on i.INTERNSHIP_PROJECT_TYPE_ID equals j.INTERNSHIP_PROJECT_TYPE_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join c in db.COUNTRies on i.COUNTRY_ID equals c.COUNTRY_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         where i.DASHBOARD_TYPE_ID == 2 && i.INTERNSHIP_ID == projectId
                         select new
                         {
                             i.INTERNSHIP_ID,
                             i.INTERNSHIP_REFERENCE,
                             j.INTERNSHIP_PROJECT_TYPE_ID,
                             j.INTERNSHIP_PROJECT_TYPE_NAME,
                             c.COUNTRY_ID,
                             c.COUNTRY_NAME,
                             com.COMPANY_ID,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.CONTACT_PERSON,
                             i.SCORE,
                             i.DASHBOARD_TYPE_ID
                         }).FirstOrDefault();
            var proj = new Internship()
            {
                INTERNSHIP_ID = query.INTERNSHIP_ID,
                INTERNSHIP_REFERENCE = query.INTERNSHIP_REFERENCE,
                INTERNSHIP_PROJECT_TYPE_ID = query.INTERNSHIP_PROJECT_TYPE_ID,
                INTERNSHIP_PROJECT_TYPE_NAME = query.INTERNSHIP_PROJECT_TYPE_NAME,
                COUNTRY_ID = query.COUNTRY_ID,
                COUNTRY_NAME = query.COUNTRY_NAME,
                COMPANY_ID = query.COMPANY_ID,
                COMPANY_NAME = query.COMPANY_NAME,
                UEN = query.UEN,
                CONTACT_PERSON = query.CONTACT_PERSON,
                SCORE = query.SCORE,
                DASHBOARD_TYPE_ID = query.DASHBOARD_TYPE_ID
            };
            return proj;
        }

        private ConsultancyCentre GetConsultancyProjDetails(decimal? projectId)
        {
            var query = (from i in db.CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP
                         join j in db.CONSULTANCY_PROJECT_TYPE on i.CONSULTANCY_PROJECT_TYPE_ID equals j.CONSULTANCY_PROJECT_TYPE_ID
                         join d in db.DASHBOARD_TYPE on i.DASHBOARD_TYPE_ID equals d.DASHBOARD_TYPE_ID
                         join sta in db.PROJECT_STATUS on i.PROJECT_STATUS_ID equals sta.PROJECT_STATUS_ID
                         join con in db.CONSULTANCY_CENTRE on i.CONSULTANCY_CENTRE_ID equals con.CONSULTANCY_CENTRE_ID
                         join com in db.COMPANies on i.COMPANY_ID equals com.COMPANY_ID
                         join cou in db.COUNTRies on i.OVERSEAS_COUNTRY_ID equals cou.COUNTRY_ID
                         where i.DASHBOARD_TYPE_ID == 1 && i.PROJECT_ID == projectId
                         select new
                         {
                             i.PROJECT_ID,
                             i.PROJECT_REFERENCE,
                             i.PROJECT_TITLE,
                             j.CONSULTANCY_PROJECT_TYPE_ID,
                             j.CONSULTANCY_PROJECT_TYPE_NAME,
                             con.CONSULTANCY_CENTRE_ID,
                             con.CONSULTANCY_CENTRE_NAME, //con.UEN,
                             com.COMPANY_ID,
                             com.COMPANY_NAME,
                             com.UEN,
                             i.CONTACT_PERSON,
                             i.PROJECT_ACCEPTANCE_DATE,
                             i.START_DATE,
                             i.END_DATE,
                             i.OVERSEAS_COUNTRY_ID,
                             cou.COUNTRY_NAME,
                             i.NO_OF_STAFFS,
                             i.NO_OF_STUDENTS,
                             i.REVENUE,
                             i.CONSUMABLES_COST,
                             i.FACILITY_COST,
                             i.INSURANCE_COST,
                             i.CENTRE_COST,
                             i.PROJECT_COMPLETTION_DATE,
                             sta.PROJECT_STATUS_ID,
                             sta.PROJECT_STATUS_NAME,
                             i.DASHBOARD_TYPE_ID
                         }).FirstOrDefault();
            var proj = new ConsultancyCentre()
            {
                PROJECT_ID = query.PROJECT_ID,
                PROJECT_REFERENCE = query.PROJECT_REFERENCE,
                PROJECT_TITLE = query.PROJECT_TITLE,
                CONSULTANCY_PROJECT_TYPE_NAME = query.CONSULTANCY_PROJECT_TYPE_NAME,
                CONSULTANCY_CENTRE_NAME = query.CONSULTANCY_CENTRE_NAME,
                UEN = query.UEN,
                COMPANY_NAME = query.COMPANY_NAME,
                CONTACT_PERSON = query.CONTACT_PERSON,
                PROJECT_ACCEPTANCE_DATE = query.PROJECT_ACCEPTANCE_DATE,
                START_DATE = query.START_DATE,
                END_DATE = query.END_DATE,
                COUNTRY_NAME =query.COUNTRY_NAME,
                NO_OF_STAFFS = query.NO_OF_STAFFS,
                NO_OF_STUDENTS = query.NO_OF_STUDENTS,
                REVENUE = query.REVENUE,
                CONSUMABLES_COST = query.CONSUMABLES_COST,
                FACILITY_COST = query.FACILITY_COST,
                INSURANCE_COST = query.INSURANCE_COST,
                CENTRE_COST = query.CENTRE_COST,
                PROJECT_COMPLETTION_DATE = query.PROJECT_COMPLETTION_DATE,
                PROJECT_STATUS_NAME = query.PROJECT_STATUS_NAME,
                DASHBOARD_TYPE_ID = query.DASHBOARD_TYPE_ID
            };
            return proj;
        }
        #endregion
    }
}