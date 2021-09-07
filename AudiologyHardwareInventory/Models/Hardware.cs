using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Hardware
    {
        [Key]
        public int HardwareId { get; set; }
        public string HardwareName { get; set; }
        public Images Images { get; set; }
    }
}
