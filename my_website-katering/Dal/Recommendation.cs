//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recommendation
    {
        public int idCustomer { get; set; }
        public Nullable<System.DateTime> dateR { get; set; }
        public string textR { get; set; }
        public int idRecommendations { get; set; }
        public Nullable<bool> isDisplay { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
