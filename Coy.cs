//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coy()
        {
            this.P2OEntry = new HashSet<P2OEntry>();
        }
    
        public int ID { get; set; }
        public string CoyName { get; set; }
        public int UnitID { get; set; }
    
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<P2OEntry> P2OEntry { get; set; }
    }
}
