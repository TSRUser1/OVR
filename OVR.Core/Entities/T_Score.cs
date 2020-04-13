namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Score
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Score()
        {
            T_ScoreInParticipantInSchedule = new HashSet<T_ScoreInParticipantInSchedule>();
        }

        [Key]
        public int ScoreID { get; set; }

        [StringLength(100)]
        public string Score1 { get; set; }

        [StringLength(100)]
        public string Score2 { get; set; }

        [StringLength(100)]
        public string Score3 { get; set; }

        [StringLength(100)]
        public string Score4 { get; set; }

        [StringLength(100)]
        public string Score5 { get; set; }

        [StringLength(100)]
        public string Score6 { get; set; }

        [StringLength(100)]
        public string Score7 { get; set; }

        [StringLength(100)]
        public string Score8 { get; set; }

        [StringLength(100)]
        public string Score9 { get; set; }

        [StringLength(100)]
        public string Score10 { get; set; }

        [StringLength(100)]
        public string Score11 { get; set; }

        [StringLength(100)]
        public string Score12 { get; set; }

        [StringLength(100)]
        public string Score13 { get; set; }

        [StringLength(100)]
        public string Score14 { get; set; }

        [StringLength(100)]
        public string Score15 { get; set; }

        [StringLength(100)]
        public string Score16 { get; set; }

        [StringLength(100)]
        public string Score17 { get; set; }

        [StringLength(100)]
        public string Score18 { get; set; }

        [StringLength(100)]
        public string Score19 { get; set; }

        [StringLength(100)]
        public string Score20 { get; set; }

        [StringLength(100)]
        public string ScoreFinal { get; set; }

        [StringLength(50)]
        public string BreakRecord { get; set; }

        public int? MedalID { get; set; }

        public int? ResultPosition { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ScoreInParticipantInSchedule> T_ScoreInParticipantInSchedule { get; set; }
    }
}
