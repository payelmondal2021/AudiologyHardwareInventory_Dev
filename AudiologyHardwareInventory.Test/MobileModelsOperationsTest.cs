using System;
using System.Collections.Generic;
using System.Text;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using NSubstitute;
using NUnit.Framework;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class MobileModelsOperationsTest
    {
        public IMobileModels _mobileModelsOperations = null;
        private IRepository<MobileModels> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<MobileModels>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _mobileModelsOperations = null;
        }


        public IMobileModels MobileModelsOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<MobileModels> mobileModelsRepository = new GenericRepository<MobileModels>();
            IMobileModels mobileModelsOperations = new MobileModelsOperations(mobileModelsRepository);
            return mobileModelsOperations;
        }
        //[Test]
        //public void When_InsertMobileModels_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
        //    _mobileModelsOperations = MobileModelsOperationsInstance();
        //    _mobileModelsOperations.InsertMobileModels(dataToInsert);
        //}

        [Test]
        public void When_InsertMobileModels_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileModelsOperations = new MobileModelsOperations(_fakeRepository);
            _mobileModelsOperations.InsertMobileModels(Arg.Any<MobileModels>());
        }

        [Test]
        public void When_InsertMobileModels_Called_Then_Create_Function_Received_Call_Once()
        {
            var mobileModel = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileModelsOperations = new MobileModelsOperations(_fakeRepository);
            _mobileModelsOperations.InsertMobileModels(mobileModel);
            _fakeRepository.Received(1).Create(mobileModel);
        }

        //[Test]
        //public void When_UpdateMobileModels_Called_Then_Data_Updated()
        //{
        //    var dataToUpdate = new MobileModels() {ModelId = 1,ModelName = "Updated_MobileModels", Description = "Description" };
        //    _mobileModelsOperations = MobileModelsOperationsInstance();
        //    _mobileModelsOperations.UpdateMobileModels(dataToUpdate);
        //}

        [Test]
        public void When_UpdateMobileModels_Called_Then_Update_Function_Received_Call_Once()
        {
            var mobileModel = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileModelsOperations = new MobileModelsOperations(_fakeRepository);
            _mobileModelsOperations.UpdateMobileModels(mobileModel);
            _fakeRepository.Received(1).Update(mobileModel);
        }

        [Test]
        public void When_DeleteMobileModels_Called_Then_Delete_Function_Received_Call_Once()
        {
            var mobileModel = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileModelsOperations = new MobileModelsOperations(_fakeRepository);
            _mobileModelsOperations.DeleteMobileModels(mobileModel);
            _fakeRepository.Received(1).Delete(mobileModel);
        }

        [Test]
        public void When_DisplayMobileModels_Called_Then_Select_Function_Received_Call_Once()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileModelsOperations = new MobileModelsOperations(_fakeRepository);
            _mobileModelsOperations.DisplayMobileModels();
            _fakeRepository.Received(1).Select();
        }
    }
}
