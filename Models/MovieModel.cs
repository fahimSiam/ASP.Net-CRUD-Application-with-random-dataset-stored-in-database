using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Models
{
    public class MovieModel
    {
        [DisplayName("Movie Id")]
        public int Id { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        public decimal Rating { get; set; }
        public string Genre { get; set; }

    }
}
