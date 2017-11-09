using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("skills")]
    public partial class Skills
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("usable_in_exploration")]
        public bool? UsableInExploration { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("compendium_id")]
        public int CompendiumId { get; set; }
        [Column("rarity")]
        public short Rarity { get; set; }
        [Column("magic_type")]
        public string MagicType { get; set; }
        [Column("mp_cost")]
        public short MpCost { get; set; }
        [Column("is_sealable")]
        public bool? IsSealable { get; set; }
        [Column("is_reflectable")]
        public bool? IsReflectable { get; set; }
        [Required]
        [Column("attack_count", TypeName = "json")]
        public string AttackCount { get; set; }
        [Required]
        [Column("attack_frames", TypeName = "json")]
        public string AttackFrames { get; set; }
        [Required]
        [Column("effect_frames", TypeName = "json")]
        public string EffectFrames { get; set; }
        [Column("move_type")]
        public short MoveType { get; set; }
        [Required]
        [Column("effect_type", TypeName = "json")]
        public string EffectType { get; set; }
        [Required]
        [Column("attack_type")]
        public string AttackType { get; set; }
        [Required]
        [Column("element_inflict", TypeName = "json")]
        public string ElementInflict { get; set; }
        [Required]
        [Column("effects", TypeName = "json")]
        public string Effects { get; set; }
        [Required]
        [Column("effects_raw", TypeName = "json")]
        public string EffectsRaw { get; set; }
        [Column("unit_restriction", TypeName = "json")]
        public string UnitRestriction { get; set; }
        [Required]
        [Column("icon")]
        public string Icon { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
