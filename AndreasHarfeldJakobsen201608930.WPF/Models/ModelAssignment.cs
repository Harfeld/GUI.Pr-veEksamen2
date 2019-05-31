using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreasHarfeldJakobsen201608930.WPF.Models
{
    class ModelAssignment
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
