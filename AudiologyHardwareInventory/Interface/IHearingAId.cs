using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IHearingAId
    {
        void InsertHearingAId(HearingAId hearingAId);
        void UpdateHearingAId(HearingAId hearingAId);
        void DeleteHearingAId(HearingAId hearingAId);
        IEnumerable<HearingAId> DisplayHearingAId();
        int GetHearingAIdCount();
    }
}
