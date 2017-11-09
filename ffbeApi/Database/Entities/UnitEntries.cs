using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("unit_entries")]
    public partial class UnitEntries
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("unit_id")]
        public int UnitId { get; set; }
        [Column("compendium_id")]
        public int CompendiumId { get; set; }
        [Column("rarity")]
        public short Rarity { get; set; }
        [Column("growth_pattern")]
        public short GrowthPattern { get; set; }
        [Required]
        [Column("stats", TypeName = "json")]
        public string Stats { get; set; }
        [Column("limitburst_id")]
        public int? LimitburstId { get; set; }
        [Column("attack_count")]
        public short AttackCount { get; set; }
        [Required]
        [Column("attack_frames", TypeName = "json")]
        public string AttackFrames { get; set; }
        [Required]
        [Column("effect_frames", TypeName = "json")]
        public string EffectFrames { get; set; }
        [Column("max_lb_drop")]
        public short MaxLbDrop { get; set; }
        [Column("ability_slots")]
        public short AbilitySlots { get; set; }
        [Required]
        [Column("magic_affinity", TypeName = "json")]
        public string MagicAffinity { get; set; }
        [Required]
        [Column("element_resist", TypeName = "json")]
        public string ElementResist { get; set; }
        [Required]
        [Column("status_resist", TypeName = "json")]
        public string StatusResist { get; set; }
        [Column("physical_resist")]
        public short PhysicalResist { get; set; }
        [Column("magical_resist")]
        public short MagicalResist { get; set; }
        [Column("awakening_gil")]
        public int? AwakeningGil { get; set; }
        [Column("awakening_materials", TypeName = "json")]
        public string AwakeningMaterials { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("UnitId")]
        [InverseProperty("UnitEntries")]
        public Units Unit { get; set; }
    }
}
