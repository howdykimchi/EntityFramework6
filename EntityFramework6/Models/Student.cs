using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("age")]
        public int Age { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }
    }
}
