using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffbeApi.Database.Entities
{
    [Table("mogking")]
    public partial class Mogking
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("currency_item")]
        public string CurrencyItem { get; set; }
        [Required]
        [Column("reward_name")]
        public string RewardName { get; set; }
        [Required]
        [Column("reward_type")]
        public string RewardType { get; set; }
        [Column("reward_id")]
        public long RewardId { get; set; }
        [Column("currency_price")]
        public int CurrencyPrice { get; set; }
        [Column("amount")]
        public int Amount { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
