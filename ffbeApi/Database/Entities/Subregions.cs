using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("subregions")]
    public partial class Subregions
    {
        public Subregions()
        {
            Dungeons = new HashSet<Dungeons>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Subregion")]
        public ICollection<Dungeons> Dungeons { get; set; }
    }
}
