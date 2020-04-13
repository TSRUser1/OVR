namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Referee
    {
        [Key]
        public int RefereeID { get; set; }

        public int ScheduleID { get; set; }

        [StringLength(200)]
        public string RefereeName1 { get; set; }

        [StringLength(100)]
        public string RefereeTitle1 { get; set; }

        [StringLength(200)]
        public string RefereeName2 { get; set; }

        [StringLength(100)]
        public string RefereeTitle2 { get; set; }

        [StringLength(200)]
        public string RefereeName3 { get; set; }

        [StringLength(100)]
        public string RefereeTitle3 { get; set; }

        [StringLength(200)]
        public string RefereeName4 { get; set; }

        [StringLength(100)]
        public string RefereeTitle4 { get; set; }

        [StringLength(200)]
        public string RefereeName5 { get; set; }

        [StringLength(100)]
        public string RefereeTitle5 { get; set; }

        [StringLength(200)]
        public string RefereeName6 { get; set; }

        [StringLength(100)]
        public string RefereeTitle6 { get; set; }

        [StringLength(200)]
        public string RefereeName7 { get; set; }

        [StringLength(100)]
        public string RefereeTitle7 { get; set; }

        [StringLength(200)]
        public string RefereeName8 { get; set; }

        [StringLength(100)]
        public string RefereeTitle8 { get; set; }

        [StringLength(200)]
        public string RefereeName9 { get; set; }

        [StringLength(100)]
        public string RefereeTitle9 { get; set; }

        [StringLength(200)]
        public string RefereeName10 { get; set; }

        [StringLength(100)]
        public string RefereeTitle10 { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual T_Schedule T_Schedule { get; set; }
    }
}
