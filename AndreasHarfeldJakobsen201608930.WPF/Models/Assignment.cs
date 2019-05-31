using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreasHarfeldJakobsen201608930.WPF.Models
{
    class Assignment
    {
        public int AssignmentId { get; set; }
        [Required] public string Costumer { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public int Duration { get; set; }
        [Required] public string Location { get; set; }
        [Required] public int ModelsNeeded { get; set; }
        [Required] public string Comment { get; set; }
        
        public List<ModelAssignment> ModelAssignments { get; set; }
        public bool Planned { get; set; }

        public Assignment()
        { 
            Planned = false;
        }
    }
}
