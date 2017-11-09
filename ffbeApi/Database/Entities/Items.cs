using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("items")]
    public partial class Items
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Column("compendium_id")]
        public int CompendiumId { get; set; }
        [Column("compendium_shown")]
        public bool CompendiumShown { get; set; }
        [Column("usable_in_combat")]
        public bool UsableInCombat { get; set; }
        [Column("usable_in_exploration")]
        public bool UsableInExploration { get; set; }
        [Required]
        [Column("flags", TypeName = "json")]
        public string Flags { get; set; }
        [Column("carry_limit")]
        public int CarryLimit { get; set; }
        [Column("stack_size")]
        public int StackSize { get; set; }
        [Column("price_buy")]
        public int PriceBuy { get; set; }
        [Column("price_sell")]
        public int PriceSell { get; set; }
        [Required]
        [Column("effects", TypeName = "json")]
        public string Effects { get; set; }
        [Required]
        [Column("effects_raw", TypeName = "json")]
        public string EffectsRaw { get; set; }
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
