namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Reference
    {
        [Key]
        public int ReferenceID { get; set; }

        public int ReferenceInternalID { get; set; }

        public int ReferenceCategoryID { get; set; }

        [StringLength(200)]
        public string ReferenceName { get; set; }

        [StringLength(100)]
        public string ReferenceCode { get; set; }

        public string ReferenceDescription { get; set; }

        public string ReferenceContent { get; set; }

        public int? LanguageID { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }

        public virtual T_ReferenceCategory T_ReferenceCategory { get; set; }
    }
}
