namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_League
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_League()
        {
            T_LeagueInParticipantInEvent = new HashSet<T_LeagueInParticipantInEvent>();
        }

        [Key]
        public int LeagueID { get; set; }

        public int? Rank { get; set; }

        [StringLength(100)]
        public string League1 { get; set; }

        [StringLength(100)]
        public string League2 { get; set; }

        [StringLength(100)]
        public string League3 { get; set; }

        [StringLength(100)]
        public string League4 { get; set; }

        [StringLength(100)]
        public string League5 { get; set; }

        [StringLength(100)]
        public string League6 { get; set; }

        [StringLength(100)]
        public string League7 { get; set; }

        [StringLength(100)]
        public string League8 { get; set; }

        [StringLength(100)]
        public string League9 { get; set; }

        [StringLength(100)]
        public string League10 { get; set; }

        [StringLength(100)]
        public string League11 { get; set; }

        [StringLength(100)]
        public string League12 { get; set; }

        [StringLength(100)]
        public string League13 { get; set; }

        [StringLength(100)]
        public string League14 { get; set; }

        [StringLength(100)]
        public string League15 { get; set; }

        [StringLength(100)]
        public string League16 { get; set; }

        [StringLength(100)]
        public string League17 { get; set; }

        [StringLength(100)]
        public string League18 { get; set; }

        [StringLength(100)]
        public string League19 { get; set; }

        [StringLength(100)]
        public string League20 { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        [StringLength(50)]
        public string GroupCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_LeagueInParticipantInEvent> T_LeagueInParticipantInEvent { get; set; }
    }
}
