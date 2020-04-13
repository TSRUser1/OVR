namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_FileInEvent
    {
        [Key]
        public int EventFileID { get; set; }

        public int FileID { get; set; }

        public int EventID { get; set; }

        public int FileGroupID { get; set; }

        public int IsActive { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public bool IsLinkedToSport { get; set; }

        public virtual T_Event T_Event { get; set; }

        public virtual T_File T_File { get; set; }
    }
}
