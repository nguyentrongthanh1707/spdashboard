//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SP_Dashboard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP
    {
        public CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP()
        {
            this.CONSULTANCE_PROJECT_STAFF_RELATIONSHIP = new HashSet<CONSULTANCE_PROJECT_STAFF_RELATIONSHIP>();
            this.CONSULTANCE_PROJECT_STUDENT_RELATIONSHIP = new HashSet<CONSULTANCE_PROJECT_STUDENT_RELATIONSHIP>();
        }
    
        public decimal PROJECT_ID { get; set; }
        public string PROJECT_REFERENCE { get; set; }
        public string PROJECT_TITLE { get; set; }
        public decimal CONSULTANCY_PROJECT_TYPE_ID { get; set; }
        public decimal CONSULTANCY_CENTRE_ID { get; set; }
        public decimal COMPANY_ID { get; set; }
        public string CONTACT_PERSON { get; set; }
        public Nullable<System.DateTime> PROJECT_ACCEPTANCE_DATE { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public Nullable<decimal> OVERSEAS_COUNTRY_ID { get; set; }
        public Nullable<int> NO_OF_STAFFS { get; set; }
        public Nullable<int> NO_OF_STUDENTS { get; set; }
        public Nullable<decimal> REVENUE { get; set; }
        public Nullable<decimal> CONSUMABLES_COST { get; set; }
        public Nullable<decimal> FACILITY_COST { get; set; }
        public Nullable<decimal> INSURANCE_COST { get; set; }
        public Nullable<decimal> CENTRE_COST { get; set; }
        public Nullable<System.DateTime> PROJECT_COMPLETTION_DATE { get; set; }
        public decimal PROJECT_STATUS_ID { get; set; }
        public decimal DASHBOARD_TYPE_ID { get; set; }
    
        public virtual COMPANY COMPANY { get; set; }
        public virtual ICollection<CONSULTANCE_PROJECT_STAFF_RELATIONSHIP> CONSULTANCE_PROJECT_STAFF_RELATIONSHIP { get; set; }
        public virtual ICollection<CONSULTANCE_PROJECT_STUDENT_RELATIONSHIP> CONSULTANCE_PROJECT_STUDENT_RELATIONSHIP { get; set; }
        public virtual CONSULTANCY_CENTRE CONSULTANCY_CENTRE { get; set; }
        public virtual CONSULTANCY_PROJECT_TYPE CONSULTANCY_PROJECT_TYPE { get; set; }
        public virtual DASHBOARD_TYPE DASHBOARD_TYPE { get; set; }
        public virtual PROJECT_STATUS PROJECT_STATUS { get; set; }
        public virtual EXTERNAL_CONSULTANCT_PROJECT_RELATIONSHIP EXTERNAL_CONSULTANCT_PROJECT_RELATIONSHIP { get; set; }
    }
}
