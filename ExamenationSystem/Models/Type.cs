namespace ExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            Questions = new HashSet<Question>();
        }

        [Key]
        [StringLength(5)]
        public string Type_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MCQ { get; set; }

        public bool? True_False { get; set; }

        [MaxLength(100)]
        public byte[] Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
