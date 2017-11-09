using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("equipment")]
    public partial class Equipment
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("compendium_id")]
        public int CompendiumId { get; set; }
        [Column("compendium_shown")]
        public bool CompendiumShown { get; set; }
        [Column("rarity")]
        public short Rarity { get; set; }
        [Column("type_id")]
        public short TypeId { get; set; }
        [Column("slot_id")]
        public short SlotId { get; set; }
        [Column("is_twohanded")]
        public bool IsTwohanded { get; set; }
        [Required]
        [Column("dmg_variance", TypeName = "json")]
        public string DmgVariance { get; set; }
        [Column("accuracy")]
        public short Accuracy { get; set; }
        [Column("requirement_type")]
        public string RequirementType { get; set; }
        [Column("requirement_id")]
        public int? RequirementId { get; set; }
        [Required]
        [Column("skills", TypeName = "json")]
        public string Skills { get; set; }
        [Required]
        [Column("effects", TypeName = "json")]
        public string Effects { get; set; }
        [Required]
        [Column("stats", TypeName = "json")]
        public string Stats { get; set; }
        [Column("price_buy")]
        public int PriceBuy { get; set; }
        [Column("price_sell")]
        public int PriceSell { get; set; }
        [Column("icon")]
        public string Icon { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("SlotId")]
        [InverseProperty("Equipment")]
        public EquipmentSlots Slot { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("Equipment")]
        public EquipmentTypes Type { get; set; }

        [NotMapped]
        public int[] SkillsList
        {
            get
            {
                int[] skillsList = new int[] { 0 };
                try
                {
                    skillsList = JsonConvert.DeserializeObject<int[]>(Skills);
                    if (skillsList is null)
                    {
                        skillsList = new int[] { 0 };
                    }
                }
                catch (Exception)
                {
                    skillsList = new int[] { 0 };                    
                }
                return skillsList;
            }
        }

        [NotMapped]
        public Dictionary<string, string> StringNames
        {
            get
            {
                if (Strings is null)
                {
                    return null;
                }
                var dictonary = new Dictionary<string, string>();
                StringEquipment stringsObject;
                try
                {
                    stringsObject = JsonConvert.DeserializeObject<StringEquipment>(Strings);
                }
                catch (Exception)
                {
                    dictonary.Add("en", Name);
                    return dictonary;
                }

                if (stringsObject.Names is null)
                {
                    dictonary.Add("en", Name);
                }
                else
                {
                    dictonary.Add("en", stringsObject.Names[0]);
                    if (stringsObject.Names.Length == 6)
                    {
                        dictonary.Add("es", stringsObject.Names[5]);
                    }
                }

                return dictonary;
            }
        }


        public struct StringEquipment
        {
            [JsonProperty("name")]
            public string[] Names { get; set; }

            [JsonProperty("desc_short")]
            public string[] descShort { get; set; }

            [JsonProperty("desc_long")]
            public string[] descLong { get; set; }
        }
    }
}
