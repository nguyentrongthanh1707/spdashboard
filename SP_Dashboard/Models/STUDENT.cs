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
    
    public partial class STUDENT
    {
        public STUDENT()
        {
            this.INTERNSHIP_PROJECT_FOR_OVERSEAS_STUDENT_RELATIONSHIP = new HashSet<INTERNSHIP_PROJECT_FOR_OVERSEAS_STUDENT_RELATIONSHIP>();
            this.INTERNSHIP_PROJECT_STUDENT_RELATIONSHIP = new HashSet<INTERNSHIP_PROJECT_STUDENT_RELATIONSHIP>();
            this.STUDENT_DETAIL_ELEARNING_LOCAL = new HashSet<STUDENT_DETAIL_ELEARNING_LOCAL>();
        }
    
        public string STUDENT_ID_NUMBER { get; set; }
        public string STUDENT_FIRST_NAME { get; set; }
        public string STUDENT_MIDDLE_NAME { get; set; }
        public string STUDENT_LAST_NAME { get; set; }
        public string STUDENT_DESCRIPTION { get; set; }
    
        public virtual ICollection<INTERNSHIP_PROJECT_FOR_OVERSEAS_STUDENT_RELATIONSHIP> INTERNSHIP_PROJECT_FOR_OVERSEAS_STUDENT_RELATIONSHIP { get; set; }
        public virtual ICollection<INTERNSHIP_PROJECT_STUDENT_RELATIONSHIP> INTERNSHIP_PROJECT_STUDENT_RELATIONSHIP { get; set; }
        public virtual ICollection<STUDENT_DETAIL_ELEARNING_LOCAL> STUDENT_DETAIL_ELEARNING_LOCAL { get; set; }
    }
}
