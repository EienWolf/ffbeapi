using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("missions")]
    public partial class Missions
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("dungeon_id")]
        public int DungeonId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Column("wave_count")]
        public short WaveCount { get; set; }
        [Required]
        [Column("cost_type")]
        public string CostType { get; set; }
        [Column("cost")]
        public short Cost { get; set; }
        [Required]
        [Column("flags", TypeName = "json")]
        public string Flags { get; set; }
        [Required]
        [Column("reward", TypeName = "json")]
        public string Reward { get; set; }
        [Column("gil")]
        public int Gil { get; set; }
        [Column("exp")]
        public int Exp { get; set; }
        [Required]
        [Column("challenges", TypeName = "json")]
        public string Challenges { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("DungeonId")]
        [InverseProperty("Missions")]
        public Dungeons Dungeon { get; set; }
    }
}
