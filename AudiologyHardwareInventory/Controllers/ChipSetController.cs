
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;
using AudiologyHardwareInventory.Interface;
using System.Net.Http;
using AudiologyHardwareInventory.Facade;

namespace AudiologyHardwareInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipSetController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IChipSet _chipSet;
       

        public ChipSetController(ILogger<TeamController> logger, IChipSet _chipSet)
        {
            _logger = logger;
            this._chipSet = _chipSet;
        }

        [HttpGet]
        public IEnumerable<ChipSet> Get()
        {
            var chipSet = _chipSet.DisplayChipSet();
            return chipSet;
        }

        [HttpPost]
        [Route("Create")]
        public void CreateChipSet([FromBody] ChipSet chipset)
        {
            //if (_chipSet.DisplayChipSet().Count() != 0)
            //{
            //    var maxId = _chipSet.DisplayChipSet().Max(a => a.ChipSetId);
            //    chipset.ChipSetId = maxId + 1;
            //}

            _chipSet.InsertChipSet(chipset);
        }

        [HttpPost]
        [Route("Update")]
        public void UpdateChipSet([FromBody] ChipSet chipset)
        {
            _chipSet.UpdateChipSet(chipset);
           // return Json("Done");
        }

        [HttpPost]
        [Route("Delete")]
        public void DeleteChipSet([FromBody] ChipSet chipSet)
        {
            _chipSet.DeleteChipSet(chipSet);
        }



    }
}
