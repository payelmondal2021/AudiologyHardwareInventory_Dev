using System;
using System.Collections.Generic;
using System.Text;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class HearingAIdOperationsTest
    {
        public IHearingAId _hearingAIdOperations = null;
        private IRepository<HearingAId> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private IHearingAId _fakehearingAId = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<HearingAId>>();
            _fakehearingAId=Substitute.For<IHearingAId>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _hearingAIdOperations = null;
        }

        public IHearingAId HearingAIdOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HearingAId> hearingAIdRepository = new GenericRepository<HearingAId>();
            IHearingAId hearingAIdOperations = new HearingAIdOperations(hearingAIdRepository);
            return hearingAIdOperations;

        }
        //[Test]
        //public void When_InsertHearingAId_Called_Then_Data_Inserted()
        //{
        //    var hearingAId = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU", Status = "Working", BrandId = 1, TeamId = 1, PlatformId = 1 };
        //    _hearingAIdOperations = HearingAIdOperationsInstance();
        //    _hearingAIdOperations.InsertHearingAId(hearingAId);
        //}

        [Test]
        public void When_InsertHearingAId_Called_Then_Check_Argument_Type()
        {
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.InsertHearingAId(Arg.Any<HearingAId>());
        }

        [Test]
        public void When_InsertHearingAId_Called_Then_Create_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU", Status = "Working", BrandId = 1, TeamId = 1, PlatformId = 1 };
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.InsertHearingAId(hearingAId);
            _fakeRepository.Received(1).Create(hearingAId);
        }
        //[Test]
        //public void When_UpdateHearingAId_Called_Then_Data_Updated()
        //{
        //    var dataToInsert = new HearingAId() {HearingAidId = 1,HearingAidName = "HearingAidName", Side="test",SerialNumber = "A12", Description = "Working for AU", Status = "Working", ManufacturerId = 1, TeamId = 1, PlatformId = 1 };
        //    _hearingAIdOperations = HearingAIdOperationsInstance();
        //    _hearingAIdOperations.UpdateHearingAId(dataToInsert);
        //}
        [Test]
        public void When_UpdateHearingAId_Called_Then_Update_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { Id = 1, HearingAidName = "HearingAidName", Side = "test", SerialNumber = "A12", Description = "Working for AU", Status = "Working", BrandId = 1, TeamId = 1, PlatformId = 1 };
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.UpdateHearingAId(hearingAId);
            _fakeRepository.Received(1).Update(hearingAId);
        }

        [Test]
        public void When_DeleteHearingAId_Called_Then_Update_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { Id = 1, HearingAidName = "UpdatedData", Side = "test", SerialNumber = "A12", Description = "Working for AU", Status = "Working", BrandId = 1, TeamId = 1, PlatformId = 1 };
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.DeleteHearingAId(hearingAId);
            _fakeRepository.Received(1).Delete(hearingAId);
        }

        [Test]
        public void When_DisplayHearingAId_Called_Then_Select_Function_Received_Call_Once()
        {
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.DisplayHearingAId();
            _fakeRepository.Received(1).Select();
        }
        [Test]
        public void When_DisplayHardwareType_Called_Then_Check_ReturnType()
        {
            var hearingAId = new HearingAId() { Id = 1, HearingAidName = "UpdatedData", Side = "test", SerialNumber = "A12", Description = "Working for AU", Status = "Working", BrandId = 1, TeamId = 1, PlatformId = 1 };
            List<HearingAId> hearingAIdList = new List<HearingAId>();
            hearingAIdList.Add(hearingAId);
            IEnumerable<HearingAId> item = hearingAIdList;
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _hearingAIdOperations.DisplayHearingAId().Returns(item);
            Assert.That(_hearingAIdOperations.DisplayHearingAId(), Is.EqualTo(item));
        }

        [Test]
        public void When_GetHearingAIdCount_Called_Then_Check_ReturnType()
        {
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository);
            _fakehearingAId.GetHearingAIdCount().Returns(1);
            Assert.AreEqual(_fakehearingAId.GetHearingAIdCount(), 1);
        }
    }
}
