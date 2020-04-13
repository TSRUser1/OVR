namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Email
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Email()
        {
            T_EmailAttachment = new HashSet<T_EmailAttachment>();
        }

        [Key]
        public int EmailID { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailSubject { get; set; }

        [Required]
        public string ReceiverEmail { get; set; }

        public string ReceiverEmail_CC { get; set; }

        public string ReceiverEmail_BCC { get; set; }

        public string EmailContent { get; set; }

        public int? EmailStatus { get; set; }

        public int? AttemptCount { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_EmailAttachment> T_EmailAttachment { get; set; }
    }
}
