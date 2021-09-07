using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Brand
    {
             [Key]
            public int BrandId { get; set; }
            public string BrandName { get; set; }
            public string LogoUrl { get; set; }
            public string Description { get; set; }
            public string BrandType { get; set; }

    }
}
