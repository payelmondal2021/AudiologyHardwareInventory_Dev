using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class HearingAIdOperations:IHearingAId
    {
        private readonly IRepository<HearingAId> _hearingAIdRepository;
        public HearingAIdOperations(IRepository<HearingAId> hearingAIdRepository)
        {
            this._hearingAIdRepository = hearingAIdRepository;
        }
        
        public void InsertHearingAId(HearingAId hearingAId)
        {
            _hearingAIdRepository.Create(hearingAId);
        }
        public void UpdateHearingAId(HearingAId hearingAId)
        {
            _hearingAIdRepository.Update(hearingAId);
        }
        public void DeleteHearingAId(HearingAId hearingAId)
        {
            _hearingAIdRepository.Delete(hearingAId);
        }
        public IEnumerable<HearingAId> DisplayHearingAId()
        {
          return  _hearingAIdRepository.Select();
        }
        public int GetHearingAIdCount()
        {
            return _hearingAIdRepository.Select().Count();
        }
    }
}
