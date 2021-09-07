using System;
using System.Collections;
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
    public class ChipSetOperationsTest
    {
        public IChipSet _chipSet = null;
        private IRepository<ChipSet> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private ChipSetOperations _chipSetOperations = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<ChipSet>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _chipSetOperations = null;
        }

        public IChipSet ChipSetOperationsInstance()
        {
            IRepository<ChipSet> chipSetRepository = new GenericRepository<ChipSet>();
            IChipSet chipSetOperations = new ChipSetOperations(chipSetRepository);
            return chipSetOperations;
        }
        //[Test]
        //public void When_InsertChipSet_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
        //    _chipSet = ChipSetOperationsInstance();
        //    _chipSet.InsertChipSet(dataToInsert);
        //}

        [Test]
        public void When_InsertChipSet_Called_Then_Check_Argument_Type()
        {
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.InsertChipSet(Arg.Any<ChipSet>());
        }
        [Test]
        public void When_InsertChipSet_Called_Then_Create_Function_Received_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetName = "UnitTestData", Description = "Description" };
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.InsertChipSet(chipSet);
            _fakeRepository.Received(1).Create(chipSet);
        }
        //[Test]
        //public void When_UpdateChipSet_Called_Then_Data_Updated_In_Database()
        //{
        //    var dataToUpdate = new ChipSet() { ChipSetId = 4, ChipSetName = "UpdatedChipSet", Description = "UpdatedDescription" };
        //    _chipSet = ChipSetOperationsInstance();
        //    _chipSet.UpdateChipSet(dataToUpdate);
        //}

        [Test]
        public void When_UpdateChipSet_Called_Then_Update_Method_Receive_Call_Once()
        {
            var chipSet = new ChipSet() {ChipSetId = 2,ChipSetName = "UnitTestData2", Description = "Description" };
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.UpdateChipSet(chipSet);
            _fakeRepository.Received(1).Update(chipSet);
        }

        [Test]
        public void When_DeleteChipSet_Called_Then_Delete_Method_Receive_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetId = 1, ChipSetName = "UnitTestData3", Description = "Description" };
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.DeleteChipSet(chipSet);
            _fakeRepository.Received(1).Delete(chipSet);
        }

        [Test]
        public void When_DisplayChipSet_Called_Then_Select_Method_Receive_Call_Once()
        {
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.DisplayChipSet();
            _fakeRepository.Received(1).Select();
        }

        [Test]
        public void When_DisplayChipSet_Called_Then_Check_ReturnType()
        {
            //test
            var chipSet = new ChipSet() { ChipSetId = 1, ChipSetName = "UnitTestData4", Description = "Description" };
            List<ChipSet> chipSetList = new List<ChipSet>();
            chipSetList.Add(chipSet);
            IEnumerable<ChipSet> item = chipSetList;
            _chipSetOperations = new ChipSetOperations(_fakeRepository);
            _chipSetOperations.DisplayChipSet().Returns(item);
            Assert.That(_chipSetOperations.DisplayChipSet(), Is.EqualTo(item));
        }
    }
}
