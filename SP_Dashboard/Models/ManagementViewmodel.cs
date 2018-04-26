using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SP_Dashboard.Models
{
    public class Internship
    {
        public decimal INTERNSHIP_ID { get; set; }
        [Display(Name = "Internship reference")]
        public string INTERNSHIP_REFERENCE { get; set; }
        [Display(Name = "Internship type")]
        public decimal INTERNSHIP_PROJECT_TYPE_ID { get; set; }
        [Display(Name = "Internship type")]
        public string INTERNSHIP_PROJECT_TYPE_NAME { get; set; }

        public string INTERNSHIP_PROJECT_TYPE_DESCRIPTION { get; set; }
        [Display(Name = "Country")]
        public decimal COUNTRY_ID { get; set; }
        [Display(Name = "Country")]
        public string COUNTRY_NAME { get; set; }
        [Display(Name = "Company")]
        public decimal COMPANY_ID { get; set; }

        public string UEN { get; set; }
        [Display(Name = "Company")]
        public string COMPANY_NAME { get; set; }
        [Display(Name = "Contact person")]
        public string CONTACT_PERSON { get; set; }
        [Display(Name = "Score")]
        public Nullable<decimal> SCORE { get; set; }
        [Display(Name = "No of students")]
        public Nullable<int> NO_OF_STUDENTS { get; set; }
        [Display(Name = "Cost to SP")]
        public Nullable<decimal> COST_TO_SP { get; set; }

        public decimal DASHBOARD_TYPE_ID { get; set; }
    }
    public class InternshipViewmodel
    {
        public List<Internship> Internship { get; set; }
    }
    public class OverseasInternship
    {
        public decimal PROJECT_ID { get; set; }
        [Display(Name = "Project reference")]
        public string PROJECT_REFERENCE { get; set; }
        [Display(Name = "Project type")]
        public decimal INTERNSHIP_PROJECT_TYPE_ID { get; set; }
        [Display(Name = "Project type")]
        public string INTERNSHIP_PROJECT_TYPE_NAME { get; set; }
        [Display(Name = "Project area")]
        public decimal PROJECT_AREA_ID { get; set; }
        [Display(Name = "Project area")]
        public string PROJECT_AREA_NAME { get; set; }
        [Display(Name = "Country")]
        public decimal COUNTRY_ID { get; set; }
        [Display(Name = "Country")]
        public string COUNTRY_NAME { get; set; }
        [Display(Name = "Company")]
        public decimal COMPANY_ID { get; set; }

        public string UEN { get; set; }
        [Display(Name = "Company")]
        public string COMPANY_NAME { get; set; }
        [Display(Name = "Project supervisor")]
        public string PROJECT_SUPERVISOR { get; set; }
        [Display(Name = "Project acceptance date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> PROJECT_ACCEPTANCE_DATE { get; set; }
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> START_DATE { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> END_DATE { get; set; }
        [Display(Name = "Revenue")]
        public Nullable<decimal> REVENUE { get; set; }
        [Display(Name = "Expenses")]
        public Nullable<decimal> EXPENSES { get; set; }
        [Display(Name = "Project status")]
        public decimal PROJECT_STATUS_ID { get; set; }
        [Display(Name = "Project status")]
        public string PROJECT_STATUS_NAME { get; set; }

        public decimal DASHBOARD_TYPE_ID { get; set; }
    }
    public class OverseasInternshipViewmodel
    {
        public List<OverseasInternship> OverseasInternship { get; set; }
    }

    public class ConsultancyCentre
    {
        public decimal PROJECT_ID { get; set; }
        [Display(Name = "Project reference")]
        public string PROJECT_REFERENCE { get; set; }
        [Display(Name = "Project title")]
        public string PROJECT_TITLE { get; set; }
        [Display(Name = "Project type")]
        [Required]
        public decimal CONSULTANCY_PROJECT_TYPE_ID { get; set; }
        [Display(Name = "Project type")]
        public string CONSULTANCY_PROJECT_TYPE_NAME { get; set; }
        [Display(Name = "Consultancy centre")]
        [Required]
        public decimal CONSULTANCY_CENTRE_ID { get; set; }
        [Display(Name = "Consultancy centre")]
        public string CONSULTANCY_CENTRE_NAME { get; set; }
        public string UEN { get; set; }
        [Required]
        [Display(Name = "Company")]
        public decimal COMPANY_ID { get; set; }
        [Display(Name = "Company")]
        public string COMPANY_NAME { get; set; }
        [Display(Name = "Contact person")]
        public string CONTACT_PERSON { get; set; }
        [Display(Name = "Project acceptance date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> PROJECT_ACCEPTANCE_DATE { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> START_DATE { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> END_DATE { get; set; }
        [Display(Name = "Overseas country")]
        public Nullable<decimal> OVERSEAS_COUNTRY_ID { get; set; }
 
        public string COUNTRY_NAME { get; set; }
     
        [Display(Name = "No of staffs")]
        public Nullable<int> NO_OF_STAFFS { get; set; }
        [Display(Name = "No of students")]
        public Nullable<int> NO_OF_STUDENTS { get; set; }
        [Display(Name = "Revenue")]
        public Nullable<decimal> REVENUE { get; set; }
        [Display(Name = "Consumables cost")]
        public Nullable<decimal> CONSUMABLES_COST { get; set; }
        [Display(Name = "Facility cost")]
        public Nullable<decimal> FACILITY_COST { get; set; }
        [Display(Name = "Insurance cost")]
        public Nullable<decimal> INSURANCE_COST { get; set; }
        [Display(Name = "Centre cost")]
        public Nullable<decimal> CENTRE_COST { get; set; }
        [Display(Name = "Project Complettion Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> PROJECT_COMPLETTION_DATE { get; set; }
        [Display(Name = "Project status")]
        [Required]
        public decimal PROJECT_STATUS_ID { get; set; }
        [Display(Name = "Project status")]
        public string PROJECT_STATUS_NAME { get; set; }

        public decimal DASHBOARD_TYPE_ID { get; set; }
       
    }
    public class ConsultancyCentreViewmodel
    {
        public List<ConsultancyCentre> ConsultancyCentre { get; set; }
    }
}