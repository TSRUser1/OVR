namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Team
    {
        [Key]
        public int TeamID { get; set; }

        [StringLength(100)]
        public string TeamName { get; set; }

        public int EventID { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public virtual T_Event T_Event { get; set; }
    }
}
