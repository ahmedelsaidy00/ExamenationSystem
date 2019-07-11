namespace ExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            Exam_Questions = new HashSet<Exam_Questions>();
            StdsAnswers = new HashSet<StdsAnswer>();
        }

        [Key]
        public int Ex_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ex_Name { get; set; }

        public int? Time { get; set; }

        public int? Sub_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Questions> Exam_Questions { get; set; }

        public virtual Subject Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StdsAnswer> StdsAnswers { get; set; }
    }
}
