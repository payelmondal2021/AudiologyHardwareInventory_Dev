using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IMobileModels
    {
        void InsertMobileModels(MobileModels mobileModels);
        void UpdateMobileModels(MobileModels mobileModels);
        void DeleteMobileModels(MobileModels mobileModels);
        IEnumerable<MobileModels> DisplayMobileModels();
    }
}
