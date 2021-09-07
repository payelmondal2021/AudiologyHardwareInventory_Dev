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
    public class ImagesOperations : IImages
    {
        private readonly IRepository<Images> _imagesRepository;
        public ImagesOperations(IRepository<Images> imagesRepositoryRepository)
        {
            this._imagesRepository = imagesRepositoryRepository;
        }
        public void InsertImages(Images images)
        {
            _imagesRepository.Create(images);
        }
        public void UpdateImages(Images images)
        {
            _imagesRepository.Update(images);
        }
        public void DeleteImages(Images images)
        {
            _imagesRepository.Delete(images);
        }
        public IEnumerable<Images> DisplayImages()
        {
           return _imagesRepository.Select();
        }
    }
}
