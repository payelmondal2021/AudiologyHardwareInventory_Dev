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
    public class BrandOperations:IBrand
    {
        private readonly IRepository<Brand> _brandRepository;
        public BrandOperations(IRepository<Brand> brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public void InsertBrand(Brand brand)
        {
            _brandRepository.Create(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _brandRepository.Delete(brand);
        }

        public IEnumerable<Brand> DisplayBrand()
        {
            return _brandRepository.Select();
        }
    }
}
