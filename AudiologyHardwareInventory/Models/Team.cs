using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Team
    {
            [Key]
            public int TeamId { get; set; }
            public string TeamName { get; set; }
            public string Description { get; set; }

            public string TeamMembers{get; set; }

    }
}
