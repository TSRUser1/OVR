namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_LeagueInParticipantInEvent
    {
        [Key]
        public int LeageInParticipantInEventID { get; set; }

        public int? LeagueID { get; set; }

        public int? TeamID { get; set; }

        public int? EventID { get; set; }

        public int? ParticipantInEventID { get; set; }

        [StringLength(100)]
        public string GroupCode { get; set; }

        public virtual T_League T_League { get; set; }
    }
}
