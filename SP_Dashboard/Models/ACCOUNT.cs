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
    
    public partial class ACCOUNT
    {
        public ACCOUNT()
        {
            this.ACCOUNT_DASHBOARD_RELATIONSHIP = new HashSet<ACCOUNT_DASHBOARD_RELATIONSHIP>();
            this.ACCOUNT_FUNCTION_RELATIONSHIP = new HashSet<ACCOUNT_FUNCTION_RELATIONSHIP>();
        }
    
        public decimal ACCOUNT_ID { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public decimal ROLE_ID { get; set; }
        public Nullable<bool> ACTIVED { get; set; }
    
        public virtual ICollection<ACCOUNT_DASHBOARD_RELATIONSHIP> ACCOUNT_DASHBOARD_RELATIONSHIP { get; set; }
        public virtual ICollection<ACCOUNT_FUNCTION_RELATIONSHIP> ACCOUNT_FUNCTION_RELATIONSHIP { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
