namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Schedule()
        {
            T_ParticipantInSchedule = new HashSet<T_ParticipantInSchedule>();
            T_Referee = new HashSet<T_Referee>();
            T_ScoreName = new HashSet<T_ScoreName>();
            T_StartListName = new HashSet<T_StartListName>();
            T_StatisticName = new HashSet<T_StatisticName>();
        }

        [Key]
        public int ScheduleID { get; set; }

        public int EventID { get; set; }

        [StringLength(200)]
        public string ScheduleName { get; set; }

        public DateTime? ScheduleDateTime { get; set; }

        public int? ExternalScheduleID { get; set; }

        [StringLength(100)]
        public string ExternalScheduleCode { get; set; }

        [StringLength(200)]
        public string RoundName { get; set; }

        public string Venue { get; set; }

        public int? MatchNumber { get; set; }

        public int? CompetitionStage { get; set; }

        public int? TotalParticipant { get; set; }

        public int? PlayFormatID { get; set; }

        [StringLength(100)]
        public string GroupCode { get; set; }

        public string ScheduleFooterNote { get; set; }

        public string StartListFooter { get; set; }

        public string Remark { get; set; }

        public bool? IsPublishStartList { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public string Location { get; set; }

        public int? StatusCodeID { get; set; }

        public bool? HeadToHead { get; set; }

        public int? IsMedalGame { get; set; }

        public bool? IsOfficial { get; set; }

        public bool? IsPublishSchedule { get; set; }

        public bool? IsGenerateLeagueSummary { get; set; }

        public virtual T_Event T_Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipantInSchedule> T_ParticipantInSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Referee> T_Referee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ScoreName> T_ScoreName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_StartListName> T_StartListName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_StatisticName> T_StatisticName { get; set; }
    }
}
