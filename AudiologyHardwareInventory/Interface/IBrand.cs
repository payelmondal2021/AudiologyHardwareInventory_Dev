using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IBrand
    {
        void InsertBrand(Brand manufacturer);
        void UpdateBrand(Brand manufacturer);
        void DeleteBrand(Brand manufacturer);
        IEnumerable<Brand> DisplayBrand();
    }
}
