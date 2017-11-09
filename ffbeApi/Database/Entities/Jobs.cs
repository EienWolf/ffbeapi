using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("jobs")]
    public partial class Jobs
    {
        public Jobs()
        {
            Units = new HashSet<Units>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Job")]
        public ICollection<Units> Units { get; set; }
    }
}
