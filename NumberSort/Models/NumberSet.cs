using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumberSort.Models
{
    public class NumberSet
    {
        [Key]
        public int Id { get; set; }
        public string SortedList { get; set; }
        public string SortOrder { get; set; }
        public Decimal SortTime { get; set; }
    }
}
