using System;
using HIMS.EF.DAL.Data;
using HIMS.Tests.StubForRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIMS.Tests
{
    [TestClass]
    public class TestTaskRepository
    {
        private StubTaskRepository stubTaskRepository;
        public TestTaskRepository()
        {
            stubTaskRepository = new StubTaskRepository();
        }
        [TestMethod]
        public void Get_TaskFromRepository_IsNotNull()
        {
            var task = stubTaskRepository.Get(1);
            Assert.IsNotNull(task);
        }
        [TestMethod]
        public void Get_TaskNameFromRepository()
        {
            var task = stubTaskRepository.Get(1);
            Assert.AreEqual(task.Name, "Alex");
        }
        [TestMethod]
        public void Get_TypeTaskFromRepository()
        {
            var task = stubTaskRepository.Get(2);
            Assert.AreNotSame(new Task(), task);
        }
        [TestMethod]
        public void Get_TaskFromRepository_IsNull()
        {
            var task = stubTaskRepository.Get(4);
            Assert.IsNull( task);
        }
    }
}
