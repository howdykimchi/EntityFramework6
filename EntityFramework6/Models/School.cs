using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Models
{
    [Table("school")]
    public class School
    {
        [Column("id")]
        [Key] // key
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR")]
        [Required] // not null
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        //The attribute that includes the "virtual" keyword is designated as a virtual attribute.
        //use the lazy loading functionality supported by Entity Framework.
        public virtual ICollection<Class>? Classes { get; set; }
    }
}