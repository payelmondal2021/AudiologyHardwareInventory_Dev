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
    public class HardwareTypeOperationsTest
    {
        public IHardwareType _hardwareTypeOperations = null;
        private IRepository<HardwareType> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<HardwareType>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _hardwareTypeOperations = null;
        }
        public IHardwareType HardwareTypeOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HardwareType> hardwareTypeRepository = new GenericRepository<HardwareType>();
            IHardwareType hardwareTypeOperations = new HardwareTypeOperations(hardwareTypeRepository);
            return hardwareTypeOperations;
        }
        //[Test]
        //public void When_InsertHardwareType_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new HardwareType() { HardwareName = "HardWreName2", Description = "Working for AU" };
        //    _hardwareTypeOperations = HardwareTypeOperationsInstance();
        //    _hardwareTypeOperations.InsertHardwareType(dataToInsert);
        //}

        [Test]
        public void When_InsertHardwareType_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.InsertHardwareType(Arg.Any<HardwareType>());
        }
        [Test]
        public void When_InsertHardwareType_Called_Then_Create_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() { HardwareName = "Unittest_HardWreName1", Description = "Working for AU" };
            //_fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.InsertHardwareType(hardwareType);
            _fakeRepository.Received(1).Create(hardwareType);
        }

        //[Test]
        //public void When_UpdateHardwareType_Called_Then_Data_Updated()
        //{S
        //    var dataToInsert = new HardwareType() { HardwareTypeId = 1, HardwareName = "Updated_data", Description = "Working for AU" };
        //    _hardwareTypeOperations = HardwareTypeOperationsInstance();
        //    _hardwareTypeOperations.UpdateHardwareType(dataToInsert);
        //}
        [Test]
        public void When_UpdateHardwareType_Called_Then_Update_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() {HardwareTypeId = 1,HardwareName = "Update_HardWreName1", Description = "Working for AU" };
            //_fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.UpdateHardwareType(hardwareType);
            _fakeRepository.Received(1).Update(hardwareType);
        }
        
        [Test]
        public void When_DeleteHardwareType_Called_Then_Delete_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() { HardwareTypeId = 1, HardwareName = "Delete_HardWreName1", Description = "Working for AU" };
           // _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.DeleteHardwareType(hardwareType);
            _fakeRepository.Received(1).Delete(hardwareType);
        }
        [Test]
        public void When_DisplayHardwareType_Called_Then_Select_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() { HardwareTypeId = 1, HardwareName = "Delete_HardWreName1", Description = "Working for AU" };
           // _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.DisplayHardwareType();
            _fakeRepository.Received(1).Select();
        }

        [Test]
        public void When_DisplayHardwareType_Called_Then_Check_ReturnType()
        {
            var hardwareType = new HardwareType() { HardwareTypeId = 1, HardwareName = "UnitTestData4", Description = "Description" };
            List<HardwareType> hardwareTypeList = new List<HardwareType>();
            hardwareTypeList.Add(hardwareType);
            IEnumerable<HardwareType> item = hardwareTypeList;
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository);
            _hardwareTypeOperations.DisplayHardwareType().Returns(item);
            Assert.That(_hardwareTypeOperations.DisplayHardwareType(), Is.EqualTo(item));
        }
    }
}
