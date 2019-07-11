namespace ExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Instructor")]
    public partial class Instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instructor()
        {
            Subjects = new HashSet<Subject>();
        }

        [Key]
        public int Inst_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Inst_Name { get; set; }

        public int Inst_Age { get; set; }

        [StringLength(50)]
        public string Inst_Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Inst_Phone { get; set; }

        public int User_Id { get; set; }

        public int Admin_Id { get; set; }

        public int? Track_Id { get; set; }

        public virtual Track Track { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
