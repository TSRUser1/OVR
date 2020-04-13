namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ModuleInRole
    {
        [Key]
        public int ModuleInRoleID { get; set; }

        public int? ModuleID { get; set; }

        public int? RoleID { get; set; }

        public bool? IsReadWrite { get; set; }

        public bool? IsReadOnly { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public virtual T_Module T_Module { get; set; }

        public virtual T_Role T_Role { get; set; }
    }
}
