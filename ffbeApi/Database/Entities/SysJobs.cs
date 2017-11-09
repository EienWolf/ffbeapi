using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("sys_jobs")]
    public partial class SysJobs
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("queue")]
        public string Queue { get; set; }
        [Required]
        [Column("payload")]
        public string Payload { get; set; }
        [Column("attempts")]
        public short Attempts { get; set; }
        [Column("reserved_at")]
        public int? ReservedAt { get; set; }
        [Column("available_at")]
        public int AvailableAt { get; set; }
        [Column("created_at")]
        public int CreatedAt { get; set; }
    }
}
