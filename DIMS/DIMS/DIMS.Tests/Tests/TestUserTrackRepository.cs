using HIMS.EF.DAL.Data;
using HIMS.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Tests
{
    [TestClass]
    public class TestUserTrackRepository
    {
        private StubUserTrackRepository stubUserTrackRepository;
        private UserTrack userTrack;
        public TestUserTrackRepository()
        {
            stubUserTrackRepository = new StubUserTrackRepository();
            userTrack = new UserTrack();
        }
        [TestMethod]
        public void Get_UserTrackFromRepository_IsNotNull()
        {
            var task = stubUserTrackRepository.Get(1);
            Assert.IsNotNull(task);
        }
        [TestMethod]
        public void Get_UserTrackFromRepository_IsNull()
        {
            var task = stubUserTrackRepository.Get(11);
            Assert.IsNull(task);
        }
        [TestMethod]
        public void GetDate_UserTrackFromRepository_AreEqual()
        {
            var task = stubUserTrackRepository.Get(1);
            var date = new DateTime(2019, 11, 12);
            Assert.AreEqual(date.Date, task.TrackDate);
        }
        [TestMethod]
        public void GetDate_UserTrackFromRepository_AreNotEqual()
        {
            var task = stubUserTrackRepository.Get(1);
            var date = new DateTime(1019, 11, 12);
            Assert.AreNotEqual(date.Date, task.TrackDate);
        }
        [TestMethod]
        public void Get_AllUserTrackFromRepository()
        {

            Assert.IsNotNull(stubUserTrackRepository.GetAll());
        }
        [TestMethod]
        public void Create_UserTrackFromRepository_IsNotNull()
        {
            var result = new UserTrack()
            {
                UserId = 3,
                Task = new EF.DAL.Data.Task(),
                TaskId = 1,
                TaskName = "Foo",
                TaskTrack = new TaskTrack(),
                TaskTrackId = 1,
                TrackDate = new DateTime(),
                TrackNote = "SomeNote"
            };
            stubUserTrackRepository.Create(result);



            Assert.IsNotNull(stubUserTrackRepository.Get(3));
        }

        [TestMethod]
        public void UpDate_UserTrackFromRepository_AreEqual()
        {
            var userTrackUpDate = stubUserTrackRepository.Get(1);
            userTrackUpDate.TaskName = "FooName";
            stubUserTrackRepository.Update(userTrackUpDate);

            Assert.AreEqual("FooName", stubUserTrackRepository.Get(1).TaskName);
        }
        [TestMethod]
        public void UpDate_UserTrackFromRepository_AreNotEqual()
        {
            var userTrackUpDate = stubUserTrackRepository.Get(1);
            userTrackUpDate.TaskName = "FooName_1";
            stubUserTrackRepository.Update(userTrackUpDate);

            Assert.AreNotEqual("FooName_2", stubUserTrackRepository.Get(1).TaskName);
        }
        [TestMethod]
        public void Delete_UserTrackFromRepository()
        {
            stubUserTrackRepository.Delete(1);

            Assert.IsNull(stubUserTrackRepository.Get(1));
        }
        [TestMethod]
        public void Delete_UserTrackFromRepository_IsNotNull()
        {
            stubUserTrackRepository.Delete(1);

            Assert.IsNotNull(stubUserTrackRepository.Get(2));
        }
        [TestMethod]
        public void CountItem_UserTrackFromRepository_AreEqual()
        {
            var stubUserTrackForTest = new UserTrack()
            {
                UserId = 4,
                Task = new EF.DAL.Data.Task(),
                TaskId = 3,
                TaskName = "FooTaskName",
                TaskTrack = new TaskTrack(),
                TaskTrackId = 5,
                TrackDate = new DateTime().Date,
                TrackNote = "FooSomeNote"
            };
            stubUserTrackRepository.Create(stubUserTrackForTest);

            Assert.AreEqual(3, stubUserTrackRepository.GetAll().Count());
        }
        [TestMethod]
        public void CountItem_UserTrackFromRepository_AreNotEqual()
        {
            var stubUserTrackForTest = new UserTrack()
            {
                UserId = 4,
                Task = new EF.DAL.Data.Task(),
                TaskId = 3,
                TaskName = "FooTaskName",
                TaskTrack = new TaskTrack(),
                TaskTrackId = 5,
                TrackDate = new DateTime().Date,
                TrackNote = "FooSomeNote"
            };
            stubUserTrackRepository.Create(stubUserTrackForTest);

            Assert.AreNotEqual(2, stubUserTrackRepository.GetAll().Count());
        }
    }
}
