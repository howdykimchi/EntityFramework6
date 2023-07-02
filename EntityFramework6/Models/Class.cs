using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Models
{
    [Table("class")]
    public class Class
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("school_id")]
        public int SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School? School { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}

