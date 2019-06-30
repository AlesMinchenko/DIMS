using HIMS.Tests.StubForRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests
{
    [TestClass]
    public class UserTrackRepository
    {
        private StubUserTrackRepository userTrack;
        public UserTrackRepository()
        {
            userTrack = new StubUserTrackRepository();
        }
        [TestMethod]
        public void Get_UserTrackFromRepository_IsNotNull()
        {
            var user = userTrack.Get(1);
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void Get_UserTrackNameFromRepository()
        {
            var task = userTrack.Get(1);
            Assert.AreEqual(task.TaskName, "Name1");
        }
        [TestMethod]
        public void Get_TypeUserTrackFromRepository()
        {
            var task = userTrack.Get(2);
            Assert.AreNotSame(new UserTrackRepository(), task);
        }
        [TestMethod]
        public void Get_UserTrackFromRepository_IsNull()
        {
            var task = userTrack.Get(4);
            Assert.IsNull(task);
        }
    }
}
