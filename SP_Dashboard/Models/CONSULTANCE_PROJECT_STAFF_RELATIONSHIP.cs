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
    
    public partial class CONSULTANCE_PROJECT_STAFF_RELATIONSHIP
    {
        public decimal PROJECT_ID { get; set; }
        public string STAFF_ID_NUMBER { get; set; }
        public decimal SCHOOL_ID { get; set; }
        public Nullable<decimal> MAN_HOURS { get; set; }
        public Nullable<decimal> COST { get; set; }
    
        public virtual CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}