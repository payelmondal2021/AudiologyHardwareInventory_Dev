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
    public class MobileModelsOperations:IMobileModels
    {
        private readonly IRepository<MobileModels> _mobileModelRepository;
        public MobileModelsOperations(IRepository<MobileModels> mobileModelRepository)
        {
            this._mobileModelRepository = mobileModelRepository;
        }

        public void InsertMobileModels(MobileModels mobileModels)
        {
            _mobileModelRepository.Create(mobileModels);
        }
        public void UpdateMobileModels(MobileModels mobileModels)
        {
            _mobileModelRepository.Update(mobileModels);
        }
        public void DeleteMobileModels(MobileModels mobileModels)
        {
            _mobileModelRepository.Delete(mobileModels);
        }
        public IEnumerable<MobileModels> DisplayMobileModels()
        {
           return _mobileModelRepository.Select();
        }
    }
}
