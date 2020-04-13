namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Sport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Sport()
        {
            T_Event = new HashSet<T_Event>();
            T_SportClass = new HashSet<T_SportClass>();
        }

        [Key]
        public int SportID { get; set; }

        public int? ExternalSportID { get; set; }

        [StringLength(100)]
        public string ExternalSportCode { get; set; }

        [StringLength(200)]
        public string SportName { get; set; }

        [StringLength(100)]
        public string SportCode { get; set; }

        public string ImageFilePath { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public bool? HasRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Event> T_Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_SportClass> T_SportClass { get; set; }
    }
}
