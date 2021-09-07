using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Mobile
    {
        [Key]
        public int Id { get; set; }
        public string MobileDeviceName { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string OSVersion { get; set; }
        [ForeignKey("ChipSet")]
        public int ChipSetId { get; set; }
        public ChipSet ChipSet { get; set; }
        public string ProcessorArchitecture { get; set; }
        public string DisplayInInches { get; set; }
        public int SupportedProtocol { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string Resolution { get; set; }
        //[ForeignKey("Images")]
        //public int ImageUrlId { get; set; }
        //public Images Images { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }



    }
}
