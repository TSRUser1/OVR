namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Module()
        {
            T_ModuleInRole = new HashSet<T_ModuleInRole>();
        }

        [Key]
        public int ModuleID { get; set; }

        [StringLength(200)]
        public string ModuleName { get; set; }

        [StringLength(200)]
        public string PageName { get; set; }

        [StringLength(200)]
        public string FunctionName { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ModuleInRole> T_ModuleInRole { get; set; }
    }
}
