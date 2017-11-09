using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("sexes")]
    public partial class Sexes
    {
        public Sexes()
        {
            Units = new HashSet<Units>();
        }

        [Column("id")]
        public short Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Sex")]
        public ICollection<Units> Units { get; set; }
    }
}
