namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EmailAttachment
    {
        [Key]
        public int EmailAttachmentID { get; set; }

        public string EmailAttachmentLocation { get; set; }

        public int? EmailAttachmentType { get; set; }

        public int? EmailID { get; set; }

        [StringLength(100)]
        public string EmailAttachmentGUID { get; set; }

        public virtual T_Email T_Email { get; set; }
    }
}
