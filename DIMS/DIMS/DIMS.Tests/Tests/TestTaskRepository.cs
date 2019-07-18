using HIMS.EF.DAL.Data;
using HIMS.Server.Models;
using HIMS.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.Tests.Tests
{
    [TestClass]
    public class TestTaskRepository
    {
        private StubTaskRepository stubTaskRepository;
        readonly Task task;
        public TestTaskRepository()
        {
            stubTaskRepository = new StubTaskRepository();
            task = new Task();
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
        [TestMethod]
        public void Get_AllTasksFromRepository_IsNotNull()
        {
            var task = stubTaskRepository.GetAll();

            Assert.IsNotNull(task);
        }
        [TestMethod]
        public void Create_TasksFromRepository()
        {
            var expected = new Task()
            {
                DeadlineDate = new DateTime().Date,
                Description = "Description_5",
                Name = "Name_5",
                StartDate = new DateTime().Date,
                TaskId = 5,
                UserTracks = new List<UserTrack>()
            };
            stubTaskRepository.Create(expected);
            var result = stubTaskRepository.Get(5);

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void Count_TasksFromRepository()
        {
            Assert.AreEqual(2, stubTaskRepository.GetAll().Count());

        }
        [TestMethod]
        public void Delete_TasksFromRepository()
        {
            stubTaskRepository.Delete(1);

            Assert.AreEqual(null, stubTaskRepository.Get(1));

        }
        [TestMethod]
        public void Update_TasksFromRepository()
        {
            var expected = new Task()
            {
                DeadlineDate = new DateTime().Date,
                Description = "Description_4",
                Name = "Name_4",
                StartDate = new DateTime().Date,
                TaskId = 4,
                UserTracks = new List<UserTrack>()
            };
            stubTaskRepository.Create(expected);
            var t = stubTaskRepository.Get(4);
            t.Name = "OtherName_4";
            stubTaskRepository.Update(t);

            Assert.AreEqual("OtherName_4", stubTaskRepository.Get(4).Name);

        }
    }
}
