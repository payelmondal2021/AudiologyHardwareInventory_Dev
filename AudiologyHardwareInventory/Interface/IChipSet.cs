using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IChipSet
    {
        void InsertChipSet(ChipSet chipSet);
        void UpdateChipSet(ChipSet chipSet);
        void DeleteChipSet(ChipSet chipSet);
        IEnumerable<ChipSet> DisplayChipSet();
    }
}
