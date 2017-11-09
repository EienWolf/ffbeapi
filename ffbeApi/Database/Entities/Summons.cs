using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("summons")]
    public partial class Summons
    {
        public Summons()
        {
            SummonBoards = new HashSet<SummonBoards>();
        }

        [Column("id")]
        public short Id { get; set; }
        [Required]
        [Column("names", TypeName = "json")]
        public string Names { get; set; }
        [Required]
        [Column("image")]
        public string Image { get; set; }
        [Required]
        [Column("icon")]
        public string Icon { get; set; }
        [Required]
        [Column("skill", TypeName = "json")]
        public string Skill { get; set; }
        [Required]
        [Column("color", TypeName = "json")]
        public string Color { get; set; }
        [Required]
        [Column("entries", TypeName = "json")]
        public string Entries { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Summon")]
        public ICollection<SummonBoards> SummonBoards { get; set; }
    }
}
