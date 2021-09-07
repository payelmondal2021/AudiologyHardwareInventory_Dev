using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class MobileModels
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}
