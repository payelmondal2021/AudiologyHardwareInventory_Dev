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
    public class MobileOperationsTest
    {
        public IMobile _mobileOperations = null;
        private IRepository<Mobile> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private IMobile _fakeMobile = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Mobile>>();
            _fakeMobile= Substitute.For<IMobile>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _mobileOperations = null;
        }


        public IMobile MobileOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Mobile> mobileRepository = new GenericRepository<Mobile>();
            IMobile mobileOperations = new MobileOperations(mobileRepository);
            return mobileOperations;
        }
        //[Test]
        //public void When_InsertMobile_Called_Then_Data_Inserted()
        //{
        //    var mobile = new Mobile() { BrandId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
        //    _mobileOperations = MobileOperationsInstance();
        //    _mobileOperations.InsertMobile(mobile);
        //}

        [Test]
        public void When_InsertMobile_Called_Then_Check_Argument_Type()
        {
            _mobileOperations = new MobileOperations(_fakeRepository);
            _mobileOperations.InsertMobile(Arg.Any<Mobile>());
        }
        [Test]
        public void When_InsertMobile_Function_Called_Then_Create_Function_Received_Call_Once()
        {
            var mobile = new Mobile() { BrandId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "20", TeamId = 1 };
            var mobileOperations = new MobileOperations(_fakeRepository);
            mobileOperations.InsertMobile(mobile);
            _fakeRepository.Received(1).Create(mobile);
        }
        
        //[Test]
        //public void When_UpdateMobile_Called_Then_Data_Updated()
        //{
        //    var mobile = new Mobile() { Id = 1, BrandId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
        //    _mobileOperations = MobileOperationsInstance();
        //    _mobileOperations.UpdateMobile(mobile);
        //}

        [Test]
        public void When_UpdateMobile_Function_Called_Then_Update_Function_Received_Call_Once()
        {
            var mobile = new Mobile() {Id = 1,BrandId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
            _mobileOperations = new MobileOperations(_fakeRepository);
            _mobileOperations.UpdateMobile(mobile);
            _fakeRepository.Received(1).Update(mobile);
        }

        [Test]
        public void When_DeleteMobile_Function_Called_Then_Delete_Function_Received_Call_Once()
        {
            var mobile = new Mobile() { Id = 1, BrandId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
            _mobileOperations = new MobileOperations(_fakeRepository);
            _mobileOperations.DeleteMobile(mobile);
            _fakeRepository.Received(1).Delete(mobile);
        }

        [Test]
        public void When_DisplayMobile_Function_Called_Then_Select_Function_Received_Call_Once()
        {
            _mobileOperations = new MobileOperations(_fakeRepository);
            _mobileOperations.DisplayMobile();
            _fakeRepository.Received(1).Select();
        }
        [Test]
        public void When_DisplayMobile_Called_Then_Check_ReturnType()
        {
            var image = new Mobile() { Id = 1, MobileDeviceName = "MobileURL" };
            List<Mobile> mobileList = new List<Mobile>();
            mobileList.Add(image);
            IEnumerable<Mobile> item = mobileList;
            _mobileOperations = new MobileOperations(_fakeRepository);
            _mobileOperations.DisplayMobile().Returns(item);
            Assert.That(_mobileOperations.DisplayMobile(), Is.EqualTo(item));
        }

        [Test]
        public void When_GetMobileCount_Called_Then_Check_ReturnType()
        {
            _mobileOperations = new MobileOperations(_fakeRepository);
            _fakeMobile.GetMobileCount().Returns(1);
            Assert.AreEqual(_fakeMobile.GetMobileCount(), 1);
        }

    }
}
