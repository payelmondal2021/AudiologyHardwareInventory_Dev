using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Facade
{
    public class ChipSetFacade
    {
        private readonly IChipSet _chipSet;
        public ChipSetFacade(IChipSet _chipSet)
        {
            this._chipSet = _chipSet;
        }
        public  ChipSet GenerateChipsetId(ChipSet chipset)
        {
            if (_chipSet.DisplayChipSet().Count() != 0)
            {
                var maxId = _chipSet.DisplayChipSet().Max(a => a.ChipSetId);
                chipset.ChipSetId = maxId + 1;
                return chipset;
            }
            else
                return chipset;
        }

    }
}
