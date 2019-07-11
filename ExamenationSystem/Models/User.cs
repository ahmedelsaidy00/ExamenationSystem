namespace ExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_Id { get; set; }

        public int Role { get; set; }

        [Required]
        [StringLength(50)]
        public string User_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
