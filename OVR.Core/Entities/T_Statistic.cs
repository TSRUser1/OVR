namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Statistic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Statistic()
        {
            T_ParticipantInSchedule = new HashSet<T_ParticipantInSchedule>();
        }

        [Key]
        public int StatisticID { get; set; }

        [StringLength(100)]
        public string Statistic1 { get; set; }

        [StringLength(100)]
        public string Statistic2 { get; set; }

        [StringLength(100)]
        public string Statistic3 { get; set; }

        [StringLength(100)]
        public string Statistic4 { get; set; }

        [StringLength(100)]
        public string Statistic5 { get; set; }

        [StringLength(100)]
        public string Statistic6 { get; set; }

        [StringLength(100)]
        public string Statistic7 { get; set; }

        [StringLength(100)]
        public string Statistic8 { get; set; }

        [StringLength(100)]
        public string Statistic9 { get; set; }

        [StringLength(100)]
        public string Statistic10 { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ParticipantInSchedule> T_ParticipantInSchedule { get; set; }
    }
}
