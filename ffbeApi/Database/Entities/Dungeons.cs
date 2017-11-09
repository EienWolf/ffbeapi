using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("dungeons")]
    public partial class Dungeons
    {
        public Dungeons()
        {
            Missions = new HashSet<Missions>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("region_id")]
        public short? RegionId { get; set; }
        [Column("subregion_id")]
        public int? SubregionId { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("position", TypeName = "json")]
        public string Position { get; set; }
        [Column("icon_id")]
        public string IconId { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Dungeons")]
        public Regions Region { get; set; }
        [ForeignKey("SubregionId")]
        [InverseProperty("Dungeons")]
        public Subregions Subregion { get; set; }
        [InverseProperty("Dungeon")]
        public ICollection<Missions> Missions { get; set; }
    }
}
