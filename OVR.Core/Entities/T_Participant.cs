namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Participant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Participant()
        {
            T_ParticipantInEvent = new HashSet<T_ParticipantInEvent>();
            T_ParticipantInSchedule = new HashSet<T_ParticipantInSchedule>();
        }

        [Key]
        public int ParticipantID { get; set; }

        [StringLength(100)]
        public string AccreditationNumber { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string FamilyName { get; set; }

        public int? GenderID { get; set; }

        public int? CountryID { get; set; }

        [StringLength(50)]
        public string PassportNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        [StringLength(100)]
        public string GivenName { get; set; }

        [StringLength(100)]
        public string IPCNo { get; set; }

        public string CardPhotoPath { get; set; }

        public int? MainCategoryId { get; set; }

        public string CardPhotoPathThumbnail { get; set; }

        public string CardPhotoPathExternal { get; set; }

        public virtual T_Country T_Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipantInEvent> T_ParticipantInEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipantInSchedule> T_ParticipantInSchedule { get; set; }
    }
}
