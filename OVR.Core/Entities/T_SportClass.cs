namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_SportClass
    {
        [Key]
        public int SportClassID { get; set; }

        public int? SportID { get; set; }

        [StringLength(20)]
        public string SportClassCode { get; set; }

        [StringLength(100)]
        public string SportClassGroupCode { get; set; }

        public int? ExternalSportClassID { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual T_Sport T_Sport { get; set; }
    }
}
