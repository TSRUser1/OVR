namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ParticipantInSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_ParticipantInSchedule()
        {
            T_Result = new HashSet<T_Result>();
            T_ScoreInParticipantInSchedule = new HashSet<T_ScoreInParticipantInSchedule>();
        }

        [Key]
        public int ParticipantInScheduleID { get; set; }

        public int? StatisticID { get; set; }

        public int? ScheduleID { get; set; }

        public int? TeamID { get; set; }

        public int? ParticipantID { get; set; }

        public int? SortID { get; set; }

        [StringLength(200)]
        public string ParticipantPosition { get; set; }

        public int? ParticipantTypeID { get; set; }

        [StringLength(100)]
        public string StartList1 { get; set; }

        [StringLength(100)]
        public string StartList2 { get; set; }

        [StringLength(100)]
        public string StartList3 { get; set; }

        [StringLength(100)]
        public string StartList4 { get; set; }

        [StringLength(100)]
        public string StartList5 { get; set; }

        [StringLength(100)]
        public string StartList6 { get; set; }

        [StringLength(100)]
        public string StartList7 { get; set; }

        [StringLength(100)]
        public string StartList8 { get; set; }

        [StringLength(100)]
        public string StartList9 { get; set; }

        [StringLength(100)]
        public string StartList10 { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public virtual T_Participant T_Participant { get; set; }

        public virtual T_Schedule T_Schedule { get; set; }

        public virtual T_Statistic T_Statistic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Result> T_Result { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ScoreInParticipantInSchedule> T_ScoreInParticipantInSchedule { get; set; }
    }
}
