using System;
using HIMS.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIMS.Tests
{
    [TestClass]
    public class TestUserTrackRepository
    {
        private StubUserTrackRepository stubUserTrackRepository = null;
        public TestUserTrackRepository()
        {
            stubUserTrackRepository = new StubUserTrackRepository();
        }
        [TestMethod]
        public void Get_UserTrackFromRepository_IsNotNull()
        {
            var task = stubUserTrackRepository.Get(1);
            Assert.IsNotNull(task);
        }
        [TestMethod]
        public void Get_TrackDateFromRepository_AreEqual()
        {
            var task = stubUserTrackRepository.Get(1);
            var date = new DateTime(2019, 11, 12);
            Assert.AreEqual(date.Date, task.TrackDate);
        }
    }
}
