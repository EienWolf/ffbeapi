using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("limitbursts")]
    public partial class Limitbursts
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("cost")]
        public short Cost { get; set; }
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
        [Column("damage_type")]
        public string DamageType { get; set; }
        [Required]
        [Column("element_inflict", TypeName = "json")]
        public string ElementInflict { get; set; }
        [Column("levels")]
        public short Levels { get; set; }
        [Required]
        [Column("min_level", TypeName = "json")]
        public string MinLevel { get; set; }
        [Required]
        [Column("max_level", TypeName = "json")]
        public string MaxLevel { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
