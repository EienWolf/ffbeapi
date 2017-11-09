using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("summon_boards")]
    public partial class SummonBoards
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("summon_id")]
        public short SummonId { get; set; }
        [Required]
        [Column("node", TypeName = "json")]
        public string Node { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("SummonId")]
        [InverseProperty("SummonBoards")]
        public Summons Summon { get; set; }
    }
}
