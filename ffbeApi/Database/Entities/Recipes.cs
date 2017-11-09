using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("recipes")]
    public partial class Recipes
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("compendium_id")]
        public int? CompendiumId { get; set; }
        [Column("compendium_shown")]
        public bool? CompendiumShown { get; set; }
        [Required]
        [Column("item")]
        public string Item { get; set; }
        [Column("time")]
        public int Time { get; set; }
        [Required]
        [Column("mats", TypeName = "json")]
        public string Mats { get; set; }
        [Column("count")]
        public short Count { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
