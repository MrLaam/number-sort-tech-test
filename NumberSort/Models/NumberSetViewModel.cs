using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberSort.Models
{
    public class NumberSetViewModel
    {
        public IEnumerable<NumberSet> NumberSets { get; set; }
        public NumberSortForm NumberSortForm { get; set; }

    }
}
