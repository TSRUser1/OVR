namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_StatisticName
    {
        [Key]
        public int StatisticNameID { get; set; }

        [StringLength(100)]
        public string StatisticName1 { get; set; }

        [StringLength(100)]
        public string StatisticName2 { get; set; }

        [StringLength(100)]
        public string StatisticName3 { get; set; }

        [StringLength(100)]
        public string StatisticName4 { get; set; }

        [StringLength(100)]
        public string StatisticName5 { get; set; }

        [StringLength(100)]
        public string StatisticName6 { get; set; }

        [StringLength(100)]
        public string StatisticName7 { get; set; }

        [StringLength(100)]
        public string StatisticName8 { get; set; }

        [StringLength(100)]
        public string StatisticName9 { get; set; }

        [StringLength(100)]
        public string StatisticName10 { get; set; }

        public int? ScheduleID { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual T_Schedule T_Schedule { get; set; }
    }
}
