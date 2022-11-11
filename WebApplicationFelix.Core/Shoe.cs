using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationFelix.Core
{

    public class Shoe
    {
        public string picture { get; set; }
        public int id { get; set; }
        [Required, StringLength(80)]
        public string name { get; set; }
        [Required]
        public int cost { get; set; }
        [Required]
        public string color { get; set; }
        public ShoeType type { get; set; }
    }
}
