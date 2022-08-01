namespace API1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [Key]
        public long Stud_ID { get; set; }

        public long Stud_Age { get; set; }

        [Required]
        [StringLength(250)]
        public string Stud_Name { get; set; }

        public long Dep_ID { get; set; }

        public virtual Department Department { get; set; }
    }
}
