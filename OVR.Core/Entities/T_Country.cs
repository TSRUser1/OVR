namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Country()
        {
            T_Participant = new HashSet<T_Participant>();
            T_ParticipatingCountry = new HashSet<T_ParticipatingCountry>();
        }

        [Key]
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        [StringLength(100)]
        public string CountryNameShort { get; set; }

        [StringLength(10)]
        public string ISOCode2 { get; set; }

        [StringLength(10)]
        public string ISOCode3 { get; set; }

        public string FlagImageFilePath { get; set; }

        public string IconFilePath { get; set; }

        public string SmallIconFilePath { get; set; }

        public int? RegionID { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Participant> T_Participant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipatingCountry> T_ParticipatingCountry { get; set; }
    }
}
