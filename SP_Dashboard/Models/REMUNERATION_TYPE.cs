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
    
    public partial class REMUNERATION_TYPE
    {
        public REMUNERATION_TYPE()
        {
            this.MENTOR_DETAIL = new HashSet<MENTOR_DETAIL>();
        }
    
        public decimal REMUNERATION_TYPE_ID { get; set; }
        public string REMUNERATION_TYPE_NAME { get; set; }
        public string REMUNERATION_TYPE_DESCRIPTION { get; set; }
    
        public virtual ICollection<MENTOR_DETAIL> MENTOR_DETAIL { get; set; }
    }
}