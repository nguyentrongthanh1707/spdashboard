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
    
    public partial class FUNCTION
    {
        public FUNCTION()
        {
            this.ACCOUNT_FUNCTION_RELATIONSHIP = new HashSet<ACCOUNT_FUNCTION_RELATIONSHIP>();
        }
    
        public decimal FUNCTION_ID { get; set; }
        public string FUNCTION_NAME { get; set; }
        public string FUNCTION_FORM_URL { get; set; }
        public decimal MODULE_ID { get; set; }
    
        public virtual ICollection<ACCOUNT_FUNCTION_RELATIONSHIP> ACCOUNT_FUNCTION_RELATIONSHIP { get; set; }
        public virtual MODULE MODULE { get; set; }
    }
}
