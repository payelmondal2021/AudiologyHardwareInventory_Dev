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
    public class HardwareTypeOperations:IHardwareType
    {
        private readonly IRepository<HardwareType> _hardwareTypeRepository;
        public HardwareTypeOperations(IRepository<HardwareType> hardwareTypeRepository)
        {
            this._hardwareTypeRepository = hardwareTypeRepository;
        }
        public void InsertHardwareType(HardwareType hardwareType)
        {
            _hardwareTypeRepository.Create(hardwareType);
        }
        public void UpdateHardwareType(HardwareType hardwareType)
        {
            _hardwareTypeRepository.Update(hardwareType);
        }
        public void DeleteHardwareType(HardwareType hardwareType)
        {
            _hardwareTypeRepository.Delete(hardwareType);
        }
        public IEnumerable<HardwareType> DisplayHardwareType()
        {
           return _hardwareTypeRepository.Select();
        }

    }
}
