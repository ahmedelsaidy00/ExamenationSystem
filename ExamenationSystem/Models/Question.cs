namespace ExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Exam_Questions = new HashSet<Exam_Questions>();
            StdsAnswers = new HashSet<StdsAnswer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Que_Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(5)]
        public string Type { get; set; }

        public string Answers_Options { get; set; }

        public string Correct_Answers { get; set; }

        [StringLength(20)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Questions> Exam_Questions { get; set; }

        public virtual Type Type1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StdsAnswer> StdsAnswers { get; set; }
    }
}
