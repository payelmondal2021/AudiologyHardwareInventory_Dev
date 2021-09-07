using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IImages
    {
        void InsertImages(Images hearingAId);
        void UpdateImages(Images images);
        void DeleteImages(Images images);
        IEnumerable<Images> DisplayImages();
    }
}
