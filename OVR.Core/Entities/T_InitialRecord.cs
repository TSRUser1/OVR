namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_InitialRecord
    {
        [Key]
        public int HistoryRecordID { get; set; }

        public int? EventID { get; set; }

        public int? SportClassID { get; set; }

        [StringLength(20)]
        public string SportClassCode { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string FamilyName { get; set; }

        [StringLength(100)]
        public string GivenName { get; set; }

        public int? ParticipantCountryID { get; set; }

        public string ParticipantCountryName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        public string Result { get; set; }

        [StringLength(100)]
        public string OffSet { get; set; }

        [StringLength(100)]
        public string TimeMillisecond { get; set; }

        [StringLength(100)]
        public string Record { get; set; }

        public DateTime? Date { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }
    }
}
