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
    
    public partial class ACCOUNT_FUNCTION_RELATIONSHIP
    {
        public decimal ACCOUNT_ID { get; set; }
        public decimal FUCNTION_ID { get; set; }
        public Nullable<bool> ACTIVED { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual FUNCTION FUNCTION { get; set; }
    }
}