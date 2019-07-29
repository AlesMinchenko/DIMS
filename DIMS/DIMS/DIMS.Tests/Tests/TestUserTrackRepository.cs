using HIMS.EF.DAL.Data;
using HIMS.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Tests
{
    [TestFixture]
    public class TestUserTrackRepository
    {
        private StubUserTrackRepository stubUserTrackRepository;
        private UserTrack userTrack;

        [SetUp]
        public void SetUp()
        {
            stubUserTrackRepository = new StubUserTrackRepository();
            userTrack = new UserTrack();

        }
        [Test]
        public void Get_UserTrackFromRepository_IsNotNull()
        {
            var task = stubUserTrackRepository.Get(1);
            Assert.IsNotNull(task);
        }
        [Test]
        public void Get_UserTrackFromRepository_IsNull()
        {
            var task = stubUserTrackRepository.Get(11);
            Assert.IsNull(task);
        }
        [Test]
        public void GetDate_UserTrackFromRepository_AreEqual()
        {
            var task = stubUserTrackRepository.Get(1);
            var date = new DateTime(2019, 11, 12);
            Assert.AreEqual(date.Date, task.TrackDate);
        }
        [Test]
        public void GetDate_UserTrackFromRepository_AreNotEqual()
        {
            var task = stubUserTrackRepository.Get(1);
            var date = new DateTime(1019, 11, 12);
            Assert.AreNotEqual(date.Date, task.TrackDate);
        }
        [Test]
        public void Get_AllUserTrackFromRepository()
        {

            Assert.IsNotNull(stubUserTrackRepository.GetAll());
        }
        [Test]
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

        [Test]
        public void UpDate_UserTrackFromRepository_AreEqual()
        {
            var userTrackUpDate = stubUserTrackRepository.Get(1);
            userTrackUpDate.TaskName = "FooName";
            stubUserTrackRepository.Update(userTrackUpDate);

            Assert.AreEqual("FooName", stubUserTrackRepository.Get(1).TaskName);
        }
        [Test]
        public void UpDate_UserTrackFromRepository_AreNotEqual()
        {
            var userTrackUpDate = stubUserTrackRepository.Get(1);
            userTrackUpDate.TaskName = "FooName_1";
            stubUserTrackRepository.Update(userTrackUpDate);

            Assert.AreNotEqual("FooName_2", stubUserTrackRepository.Get(1).TaskName);
        }
        [Test]
        public void Delete_UserTrackFromRepository()
        {
            stubUserTrackRepository.Delete(1);

            Assert.IsNull(stubUserTrackRepository.Get(1));
        }
        [Test]
        public void Delete_UserTrackFromRepository_IsNotNull()
        {
            stubUserTrackRepository.Delete(1);

            Assert.IsNotNull(stubUserTrackRepository.Get(2));
        }
        [Test]
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
        [Test]
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
