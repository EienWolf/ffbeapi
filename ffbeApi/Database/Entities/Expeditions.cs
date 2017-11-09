using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("expeditions")]
    public partial class Expeditions
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("type")]
        public short Type { get; set; }
        [Column("cost")]
        public int Cost { get; set; }
        [Required]
        [Column("rank")]
        public string Rank { get; set; }
        [Column("difficulty")]
        public int Difficulty { get; set; }
        [Column("duration")]
        public int Duration { get; set; }
        [Column("units")]
        public short Units { get; set; }
        [Required]
        [Column("required", TypeName = "json")]
        public string Required { get; set; }
        [Column("next_id")]
        public int? NextId { get; set; }
        [Required]
        [Column("reward", TypeName = "json")]
        public string Reward { get; set; }
        [Column("relics")]
        public short Relics { get; set; }
        [Required]
        [Column("exp_levels", TypeName = "json")]
        public string ExpLevels { get; set; }
        [Required]
        [Column("unit_bonus", TypeName = "json")]
        public string UnitBonus { get; set; }
        [Column("unit_bonus_max")]
        public short UnitBonusMax { get; set; }
        [Required]
        [Column("item_bonus", TypeName = "json")]
        public string ItemBonus { get; set; }
        [Required]
        [Column("stat_bonus", TypeName = "json")]
        public string StatBonus { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
