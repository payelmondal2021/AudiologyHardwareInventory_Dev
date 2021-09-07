using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface ITeam
    {
        IEnumerable<Team> DisplayTeamStatus();
        void InsertNewTeam(Team team);
        void UpdateTeam(Team teamDetails);
        void DeleteTeam(Team teamDetails);

    }
}
