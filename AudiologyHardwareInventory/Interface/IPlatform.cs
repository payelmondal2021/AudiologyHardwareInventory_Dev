using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IPlatform
    {
        void InsertPlatform(Platform platform);
        void UpdatePlatform(Platform platform);
        void DeletePlatform(Platform platform);
        IEnumerable<Platform> DisplayPlatform();
    }
}
