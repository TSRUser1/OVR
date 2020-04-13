namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Event()
        {
            T_FileInEvent = new HashSet<T_FileInEvent>();
            T_ParticipantInEvent = new HashSet<T_ParticipantInEvent>();
            T_Schedule = new HashSet<T_Schedule>();
            T_Team = new HashSet<T_Team>();
        }

        [Key]
        public int EventID { get; set; }

        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(100)]
        public string EventCode { get; set; }

        public int SportID { get; set; }

        public int? GenderID { get; set; }

        public int? PlayFormatID { get; set; }

        public int? EventTypeID { get; set; }

        public int? ExternalEventID { get; set; }

        [StringLength(100)]
        public string ExternalEventCode { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public string EventFooterNote { get; set; }

        public bool? IsTogleHtmlMode { get; set; }

        public bool? IsShowResult { get; set; }

        public bool? IsShowMedal { get; set; }

        public bool? IsShowAthelete { get; set; }

        public bool? IsShowReport { get; set; }

        public bool? IsShowRecord { get; set; }

        public bool? IsShowSummary { get; set; }

        public virtual T_Sport T_Sport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_FileInEvent> T_FileInEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipantInEvent> T_ParticipantInEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Schedule> T_Schedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Team> T_Team { get; set; }
    }
}
