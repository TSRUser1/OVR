namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ScoreName
    {
        [Key]
        public int ScoreNameID { get; set; }

        [StringLength(100)]
        public string ScoreName1 { get; set; }

        [Required]
        [StringLength(100)]
        public string ScoreName2 { get; set; }

        [StringLength(100)]
        public string ScoreName3 { get; set; }

        [StringLength(100)]
        public string ScoreName4 { get; set; }

        [StringLength(100)]
        public string ScoreName5 { get; set; }

        [StringLength(100)]
        public string ScoreName6 { get; set; }

        [StringLength(100)]
        public string ScoreName7 { get; set; }

        [StringLength(100)]
        public string ScoreName8 { get; set; }

        [StringLength(100)]
        public string ScoreName9 { get; set; }

        [StringLength(100)]
        public string ScoreName10 { get; set; }

        [StringLength(100)]
        public string ScoreName11 { get; set; }

        [StringLength(100)]
        public string ScoreName12 { get; set; }

        [StringLength(100)]
        public string ScoreName13 { get; set; }

        [StringLength(100)]
        public string ScoreName14 { get; set; }

        [StringLength(100)]
        public string ScoreName15 { get; set; }

        [StringLength(100)]
        public string ScoreName16 { get; set; }

        [StringLength(100)]
        public string ScoreName17 { get; set; }

        [StringLength(100)]
        public string ScoreName18 { get; set; }

        [StringLength(100)]
        public string ScoreName19 { get; set; }

        [StringLength(100)]
        public string ScoreName20 { get; set; }

        [StringLength(100)]
        public string ScoreNameFinal { get; set; }

        public int? ScheduleID { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsVisible1 { get; set; }

        public bool? IsVisible2 { get; set; }

        public bool? IsVisible3 { get; set; }

        public bool? IsVisible4 { get; set; }

        public bool? IsVisible5 { get; set; }

        public bool? IsVisible6 { get; set; }

        public bool? IsVisible7 { get; set; }

        public bool? IsVisible8 { get; set; }

        public bool? IsVisible9 { get; set; }

        public bool? IsVisible10 { get; set; }

        public bool? IsVisible11 { get; set; }

        public bool? IsVisible12 { get; set; }

        public bool? IsVisible13 { get; set; }

        public bool? IsVisible14 { get; set; }

        public bool? IsVisible15 { get; set; }

        public bool? IsVisible16 { get; set; }

        public bool? IsVisible17 { get; set; }

        public bool? IsVisible18 { get; set; }

        public bool? IsVisible19 { get; set; }

        public bool? IsVisible20 { get; set; }

        public virtual T_Schedule T_Schedule { get; set; }
    }
}
