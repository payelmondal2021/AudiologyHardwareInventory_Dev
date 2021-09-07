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
    public class BrandOperationsTest
    {
        public IBrand _brandOperations = null;
        private IRepository<Brand> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Brand>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _brandOperations = null;
        }
        
        public IBrand BrandOperationsInstance()
        {
            IRepository<Brand> brandRepository = new GenericRepository<Brand>();
            IBrand brandOperations = new BrandOperations(brandRepository);
            return brandOperations;
        }
        //[Test]
        //public void When_InsertBrand_Called_Then_Data_Inserted()
        //{
        //    var brand = new Brand() { BrandName = "test", LogoUrl = "URL", Description = "Working for AU", BrandType = "Mobile" };
        //    _brandOperations = BrandOperationsInstance();
        //    _brandOperations.InsertBrand(brand);
        //}

        [Test]
        public void When_InsertBrand_Called_Then_Check_Argument_Type()
        {
            _brandOperations = new BrandOperations(_fakeRepository);
            _brandOperations.InsertBrand(Arg.Any<Brand>());
        }
        [Test]
        public void When_InsertBrand_Called_Then_Create_Function_Received_Call_Once()
        {
            var brand = new Brand() { BrandName = "test", LogoUrl = "URL", Description = "Working for AU",BrandType="Mobile" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _brandOperations = new BrandOperations(_fakeRepository);
            _brandOperations.InsertBrand(brand);
            _fakeRepository.Received().Create(brand);
        }
        //[Test]
        //public void When_UpdateManufacturer_Called_Then_Data_Updated()
        //{
        //    var dataToUpdate = new Manufacturer() {ManufacturerId = 1,ManufacturerName = "Updated_ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
        //    _manufacturerOperations = ManufactureOperationsInstance();
        //    _manufacturerOperations.UpdateManufacturer(dataToUpdate);
        //}
        [Test]
        public void When_UpdateBrand_Called_Then_Update_Function_Received_Call_Once()
        {
            var brand = new Brand() {BrandId=1 ,BrandName = "test", LogoUrl = "URL", Description = "Working for AU", BrandType = "Mobile" };
            _brandOperations = new BrandOperations(_fakeRepository);
            _brandOperations.UpdateBrand(brand);
            _fakeRepository.Received().Update(brand);
        }

        [Test]
        public void When_DeleteBrand_Called_Then_Delete_Function_Received_Call_Once()
        {
            var brand = new Brand() { BrandId = 1, BrandName = "test", LogoUrl = "URL", Description = "Working for AU", BrandType = "Mobile" };
            _brandOperations = new BrandOperations(_fakeRepository);
            _brandOperations.DeleteBrand(brand);
            _fakeRepository.Received().Delete(brand);
        }

        [Test]
        public void When_DisplayBrand_Called_Then_Display_Function_Received_Call_Once()
        {
            _brandOperations = new BrandOperations(_fakeRepository);
            _brandOperations.DisplayBrand();
            _fakeRepository.Received().Select();
        }
    }
}
