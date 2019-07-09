using System;
using HIMS.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIMS.Tests
{
    [TestClass]
    public class TestTaskRepository
    {
        private StubTaskRepository stubTaskRepository = null;

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
        public void Get_TaskNameFromRepository_AreEqual()
        {
            var task = stubTaskRepository.Get(3);

            Assert.AreEqual("Name12", task.Name);
        }
    }
}
