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
    public class MobileOperations:IMobile
    {
        private readonly IRepository<Mobile> _mobileRepository;
        public MobileOperations(IRepository<Mobile> mobileRepository)
        {
            this._mobileRepository = mobileRepository;
        }

        public void InsertMobile(Mobile mobile)
        {
            _mobileRepository.Create(mobile);
        }
        public void UpdateMobile(Mobile mobile)
        {
            _mobileRepository.Update(mobile);
        }
        public void DeleteMobile(Mobile mobile)
        {
            _mobileRepository.Delete(mobile);
        }
        public IEnumerable<Mobile> DisplayMobile()
        {
          return  _mobileRepository.Select();
        }
        public int GetMobileCount()
        {
            return _mobileRepository.Select().Count();
        }
    }
}
