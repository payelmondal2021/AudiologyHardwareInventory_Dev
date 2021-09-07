using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class TeamOperations : ITeam
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamOperations(IRepository<Team> teamRepository)
        {
            this._teamRepository = teamRepository;
        }
        public IEnumerable<Team> DisplayTeamStatus()
        {
            ////To Add Data
            return _teamRepository.Select();
        }

        public void InsertNewTeam(Team teamDetails)
        {
            _teamRepository.Create(teamDetails);
        }
        public void UpdateTeam(Team teamDetails)
        {
            // _hardwareInventoryContext.Entry(teamDetails).State = EntityState.Modified;
           // _hardwareInventoryContext.Update(teamDetails);
            _teamRepository.Update(teamDetails);
        }
        public void DeleteTeam(Team teamDetails)
        {
            _teamRepository.Delete(teamDetails);
        }
    }
}
