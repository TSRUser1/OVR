namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ScoreInParticipantInSchedule
    {
        [Key]
        [Column(Order = 0)]
        public int ScoreInParticipantInScheduleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScoreID { get; set; }

        public int? ParticipantInScheduleID { get; set; }

        public int? TeamID { get; set; }

        public virtual T_ParticipantInSchedule T_ParticipantInSchedule { get; set; }

        public virtual T_Score T_Score { get; set; }
    }
}
