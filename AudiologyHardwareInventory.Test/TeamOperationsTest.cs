using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using AudiologyHardwareInventory;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class TeamOperationsTest
    {
        public ITeam _teamOperationsInstance = null;
        private IRepository<Team> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private TeamOperations _teamOperations = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Team>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _teamOperations = null;
        }

        public  ITeam TeamOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Team> teamRepository = new GenericRepository<Team>();
            ITeam teamOperations = new TeamOperations(teamRepository);
            return teamOperations;
        }

        //[Test]
        //public void When_InsertNewTeam_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new Team() { TeamName = "NewTeam", Description = "Working with Siemens Technology" };
        //    _teamOperationsInstance = TeamOperationsInstance();
        //    _teamOperationsInstance.InsertNewTeam(dataToInsert);
        //}

        [Test]
        public void When_InsertNewTeam_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.InsertNewTeam(Arg.Any<Team>());
        }
        [Test]
        public void When_InsertNewTeam_Called_Then_Create_Function_Received_Call_Once()
        {
            var team = new Team() { TeamName = "Team2", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.InsertNewTeam(team);
            _fakeRepository.Received().Create(team);
        }

        //[Test]
        //public void When_UpdateTeam_Called_Then_Data_Updated()
        //{
        //    var team = new Team() {TeamId = 1,TeamName = "updated_Team2", Description = "Working for AU" };
        //    _teamOperationsInstance = TeamOperationsInstance();
        //    _teamOperationsInstance.UpdateTeam(team);
        //}

        [Test]
        public void When_UpdateTeam_Called_Then_Update_Function_Received_Call_Once()
        {
            var team = new Team() {TeamId = 1,TeamName = "Updated_Team2", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.UpdateTeam(team);
            _fakeRepository.Received().Update(team);
        }

        [Test]
        public void When_DeleteTeam_Called_Then_Delete_Function_Received_Call_Once()
        {
            var team = new Team() { TeamId = 1, TeamName = "Updated_Team2", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.DeleteTeam(team);
            _fakeRepository.Received().Delete(team);
        }

        [Test]
        public void When_DisplayTeamStatus_Called_Then_Select_Function_Received_Call_Once()
        {
            var team = new Team() { TeamId = 1, TeamName = "Updated_Team2", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.DisplayTeamStatus();
            _fakeRepository.Received().Select();
        }

        [Test]
        public void When_DisplayTeamStatus_Called_Then_Check_ReturnType()
        {
            var team = new Team() { TeamId = 1, TeamName = "UnitTestData4", Description = "Description" };
            List<Team> teamList = new List<Team>();
            teamList.Add(team);
            IEnumerable<Team> item = teamList;
            _teamOperations = new TeamOperations(_fakeRepository);
            _teamOperations.DisplayTeamStatus().Returns(item);
            Assert.That(_teamOperations.DisplayTeamStatus(), Is.EqualTo(item));
        }

    }
}
