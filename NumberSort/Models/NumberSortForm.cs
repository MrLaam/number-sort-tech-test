using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumberSort.Models
{
    public class NumberSortForm
    {
        [Required(ErrorMessage = "Error: Please enter a set of numbers")]
        [RegularExpression(@"^(-\d|\d)(,| |\d| -\d|,-\d)*$", ErrorMessage = "Error: Must only enter numbers separated by single commas or spaces")]
        public string unsortedList { get; set; }
        public string sortOrder { get; set; }
    }
}
