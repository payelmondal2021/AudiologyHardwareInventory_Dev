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
    public class PlatformOperations : IPlatform
    {
        private readonly IRepository<Platform> _platformRepository;

        public PlatformOperations(IRepository<Platform> platformRepository)
        {
            this._platformRepository = platformRepository;
        }
        public void InsertPlatform(Platform platform)
        {
            _platformRepository.Create(platform);
        }
        public void UpdatePlatform(Platform platform)
        {
            _platformRepository.Update(platform);
        }
        public void DeletePlatform(Platform platform)
        {
            _platformRepository.Delete(platform);
        }
        public IEnumerable<Platform> DisplayPlatform()
        {
          return  _platformRepository.Select();
        }
    }
}
