using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreasHarfeldJakobsen201608930.WPF.Models
{
    class Model
    {
        public int ModelId { get; set; }
        [Required] public string Name { get; set; }
        [MaxLength(11)]
        [Required] public int Phone { get; set; }
        [Required] public string Address { get; set; }
        [Required] public int Height { get; set; }
        [Required] public int Weight { get; set; }
        [Required] public string HairColor { get; set; }
        [Required] public string Comment { get; set; }

        public List<ModelAssignment> ModelAssignments { get; set; }
    }
}
