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
    
    public partial class ACCOUNT_DASHBOARD_RELATIONSHIP
    {
        public decimal ACCOUNT_ID { get; set; }
        public decimal DASHBOARD_TYPE_ID { get; set; }
        public Nullable<bool> ACTIVED { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual DASHBOARD_TYPE DASHBOARD_TYPE { get; set; }
    }
}