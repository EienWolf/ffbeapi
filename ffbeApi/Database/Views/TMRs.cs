using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ffbeApi.Database.Views
{
    public class TMRs
    {
        [Key]
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? TMRID { get; set; }
        public string TMRType { get; set; }
        public string TMRName { get; set; }
        public string TMRStrings { get; set; }
        public string Skills { get; set; }
    }
}
