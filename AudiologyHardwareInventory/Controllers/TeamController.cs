
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

namespace AudiologyHardwareInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeam _team;


        public TeamController(ILogger<TeamController> logger,ITeam team)
        {
            _logger = logger;
            this._team = team;
        }
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            var chipSet = _team.DisplayTeamStatus();
            return chipSet;
        }

        [HttpPost]
        //[Route("save/{team}")]
        public void Post([FromBody] Team team)
        {
            var maxId = _team.DisplayTeamStatus().Max(a => a.TeamId);
            team.TeamId = maxId + 1;
             _team.InsertNewTeam(team);
        }

        [HttpPost]
        [Route("Update")]
        public void Update([FromBody] Team team)
        {
            _team.UpdateTeam(team);
        }
        
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] Team team)
        {
            _team.DeleteTeam(team);
        }
    }
}
