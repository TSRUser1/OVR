namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_StartListName
    {
        [Key]
        public int StartListNameID { get; set; }

        public int? ScheduleID { get; set; }

        [StringLength(100)]
        public string StartlistName1 { get; set; }

        [StringLength(100)]
        public string StartlistName2 { get; set; }

        [StringLength(100)]
        public string StartlistName3 { get; set; }

        [StringLength(100)]
        public string StartlistName4 { get; set; }

        [StringLength(100)]
        public string StartlistName5 { get; set; }

        [StringLength(100)]
        public string StartlistName6 { get; set; }

        [StringLength(100)]
        public string StartlistName7 { get; set; }

        [StringLength(100)]
        public string StartlistName8 { get; set; }

        [StringLength(100)]
        public string StartlistName9 { get; set; }

        [StringLength(100)]
        public string StartlistName10 { get; set; }

        public int IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public virtual T_Schedule T_Schedule { get; set; }
    }
}
