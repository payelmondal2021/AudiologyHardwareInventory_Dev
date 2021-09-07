using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class HearingAId
    {
        [Key]
        public int Id { get; set; }
        public string HearingAidName { get; set; }
        public string SerialNumber { get; set; }

        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        public string Status { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string FirmwareVersion { get; set; }
        public string Side { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public Team Team { get; set; }
        [ForeignKey("Platform")]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }

        //[ForeignKey("Images")]
        //public int ImageUrlId { get; set; }
        //public Images Images { get; set; }
    }

}
