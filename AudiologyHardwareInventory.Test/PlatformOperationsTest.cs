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
    public class PlatformOperationsTest
    {
        public IPlatform _platformOperations = null;
        private IRepository<Platform> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Platform>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _platformOperations = null;
        }

        public IPlatform PlatformOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Platform> platformRepository = new GenericRepository<Platform>();
            IPlatform platformOperations = new PlatformOperations(platformRepository);
            return platformOperations;
        }
        [Test]
        public void When_InsertPlatform_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Platform() { PlatformName = "PlatformName", Description = "Working for AU" };
            _platformOperations = PlatformOperationsInstance();
            _platformOperations.InsertPlatform(dataToInsert);
        }

        [Test]
        public void When_InsertPlatform_Called_Then_Check_Argument_Type()
        {
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.InsertPlatform(Arg.Any<Platform>());
        }
        [Test]
        public void When_InsertPlatform_Called_Then_Create_Function_Received_Call_Once()
        {
            var platform = new Platform() { PlatformName = "UnitTest_PlatformName", Description = "UnitTest_Working for AU" };
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.InsertPlatform(platform);
            _fakeRepository.Received(1).Create(platform);
        }

        //[Test]
        //public void When_UpdatePlatform_Called_Then_Data_Updated()
        //{
        //    var platform = new Platform() { PlatformId = 1, PlatformName = "updated_PlatformName", Description = "Working for AU" };
        //    _platformOperations = PlatformOperationsInstance();
        //    _platformOperations.UpdatePlatform(platform);
        //}

        [Test]
        public void When_UpdatePlatform_Called_Then_Update_Function_Received_Call_Once()
        {
            var platform = new Platform() {PlatformId = 1,PlatformName = "UnitTest_updated_PlatformName", Description = "UnitTest_Working for AU" };
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.UpdatePlatform(platform);
            _fakeRepository.Received(1).Update(platform);
        }

        [Test]
        public void When_DeletePlatform_Called_Then_Delete_Function_Received_Call_Once()
        {
            var platform = new Platform() { PlatformId = 1, PlatformName = "updated_PlatformName", Description = "Working for AU" };
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.DeletePlatform(platform);
            _fakeRepository.Received(1).Delete(platform);
        }

        [Test]
        public void When_DisplayPlatform_Called_Then_Select_Function_Received_Call_Once()
        {
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.DisplayPlatform();
            _fakeRepository.Received(1).Select();
        }

        [Test]
        public void When_DisplayPlatForm_Called_Then_Check_ReturnType()
        {
            var Platform = new Platform() { PlatformId = 1, PlatformName = "UnitTestData4", Description = "Description" };
            List<Platform> platformList = new List<Platform>();
            platformList.Add(Platform);
            IEnumerable<Platform> item = platformList;
            _platformOperations = new PlatformOperations(_fakeRepository);
            _platformOperations.DisplayPlatform().Returns(item);
            Assert.That(_platformOperations.DisplayPlatform(), Is.EqualTo(item));
        }
    }
}
