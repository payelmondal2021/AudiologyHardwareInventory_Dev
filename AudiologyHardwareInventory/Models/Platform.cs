using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string Description { get; set; }
    }
}
