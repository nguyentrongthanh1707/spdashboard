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
    
    public partial class CONSULTANCY_PROJECT_TYPE
    {
        public CONSULTANCY_PROJECT_TYPE()
        {
            this.CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP = new HashSet<CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP>();
        }
    
        public decimal CONSULTANCY_PROJECT_TYPE_ID { get; set; }
        public string CONSULTANCY_PROJECT_TYPE_NAME { get; set; }
        public string CONSULTANCY_PROJECT_TYPE_DESCRIPTION { get; set; }
    
        public virtual ICollection<CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP> CONSULTANCY_CENTRE_PROJECT_RELATIONSHIP { get; set; }
    }
}
