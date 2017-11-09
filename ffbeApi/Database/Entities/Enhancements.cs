using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("enhancements")]
    public partial class Enhancements
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("skill_id_old")]
        public int SkillIdOld { get; set; }
        [Column("skill_id_new")]
        public int SkillIdNew { get; set; }
        [Required]
        [Column("cost", TypeName = "json")]
        public string Cost { get; set; }
        [Required]
        [Column("units", TypeName = "json")]
        public string Units { get; set; }
        [Required]
        [Column("strings", TypeName = "json")]
        public string Strings { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
