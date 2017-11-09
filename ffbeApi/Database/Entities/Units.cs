using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("units")]
    public partial class Units
    {
        public Units()
        {
            UnitEntries = new HashSet<UnitEntries>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("rarity_min")]
        public short RarityMin { get; set; }
        [Column("rarity_max")]
        public short RarityMax { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("names", TypeName = "json")]
        public string Names { get; set; }
        [Column("game_id")]
        public int GameId { get; set; }
        [Column("job_id")]
        public int JobId { get; set; }
        [Column("sex_id")]
        public short SexId { get; set; }
        [Column("tribe_id")]
        public short TribeId { get; set; }
        [Column("is_summonable")]
        public bool IsSummonable { get; set; }
        [Column("TMR_type")]
        public string TmrType { get; set; }
        [Column("TMR_id")]
        public int? TmrId { get; set; }
        [Required]
        [Column("equip", TypeName = "json")]
        public string Equip { get; set; }
        [Column("skills", TypeName = "json")]
        public string SkillsJson { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("GameId")]
        [InverseProperty("Units")]
        public Games Game { get; set; }
        [ForeignKey("JobId")]
        [InverseProperty("Units")]
        public Jobs Job { get; set; }
        [ForeignKey("SexId")]
        [InverseProperty("Units")]
        public Sexes Sex { get; set; }
        [ForeignKey(nameof(TmrId))]
        //[InverseProperty("Units")]
        public Equipment TMEquip { get; set; }
        [ForeignKey(nameof(TmrId))]
        //[InverseProperty("Units")]
        public Materias TMMateria { get; set; }
        [InverseProperty("Unit")]
        public ICollection<UnitEntries> UnitEntries { get; set; }

        [NotMapped]
        public Skill[] Skills
        {
            get
            {
                if (SkillsJson is null)
                {
                    return null;
                }
                return JsonConvert.DeserializeObject<Skill[]>(SkillsJson);
            }
            set
            {
                SkillsJson = JsonConvert.SerializeObject(value);
            }
        }

      
        public struct Skill
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("level")]
            public long Level { get; set; }

            [JsonProperty("rarity")]
            public long Rarity { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }
     
    }
}
