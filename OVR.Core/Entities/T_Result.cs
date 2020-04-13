namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Result
    {
        [Key]
        public int ResultID { get; set; }

        public int ParticipantInScheduleID { get; set; }

        [StringLength(50)]
        public string BreakRecord { get; set; }

        public int? MedalID { get; set; }

        public int? ResultPosition { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual T_ParticipantInSchedule T_ParticipantInSchedule { get; set; }
    }
}
