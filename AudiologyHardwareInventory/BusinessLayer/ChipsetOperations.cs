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
    public class ChipSetOperations: IChipSet
    {
        private readonly IRepository<ChipSet> _chipSRepository;
       // private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public ChipSetOperations(IRepository<ChipSet> chipSetRepository)
        {
            //this._hardwareInventoryContext = DBConnection.CreateHardwareInventoryContext();
            this._chipSRepository = chipSetRepository;
            //this._hardwareInventoryContext = hardwareInventoryContext;
        }

        public void InsertChipSet(ChipSet chipSet)
        {
            _chipSRepository.Create(chipSet);
        }
        public void UpdateChipSet(ChipSet chipSet)
        {
            _chipSRepository.Update(chipSet);
        }
        public void DeleteChipSet(ChipSet chipSet)
        {
            _chipSRepository.Delete(chipSet);
        }
        public IEnumerable<ChipSet> DisplayChipSet()
        {
          return  _chipSRepository.Select();
        }
    }
}
