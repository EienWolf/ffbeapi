using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("sys_migrations")]
    public partial class SysMigrations
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("migration")]
        public string Migration { get; set; }
        [Column("batch")]
        public int Batch { get; set; }
    }
}
