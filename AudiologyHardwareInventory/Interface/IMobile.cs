using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IMobile
    {
        void InsertMobile(Mobile mobile);
        void UpdateMobile(Mobile mobile);
        void DeleteMobile(Mobile mobile);
        IEnumerable<Mobile> DisplayMobile();
        int GetMobileCount();
    }
}
