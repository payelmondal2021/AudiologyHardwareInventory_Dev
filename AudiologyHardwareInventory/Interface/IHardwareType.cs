using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IHardwareType
    {
        void InsertHardwareType(HardwareType hardwareType);
        void UpdateHardwareType(HardwareType hardwareType);
        void DeleteHardwareType(HardwareType hardwareType);
        IEnumerable<HardwareType> DisplayHardwareType();
    }
}
