using HIMS.EF.DAL.Data;
using HIMS.Server.Models;
using HIMS.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.Tests.Tests
{
    [TestFixture]
    public class TestTaskRepository
    {
        private StubTaskRepository stubTaskRepository;
        private Task task;
        [SetUp]
        public void SetUp()
        {
            stubTaskRepository = new StubTaskRepository();
            task = new Task();
        }
        [Test]
        public void Get_TaskFromRepository_IsNotNull()
        {
            var task = stubTaskRepository.Get(1);
            Assert.IsNotNull(task);
        }
        [Test]
        public void Get_TaskFromRepository_IsNull()
        {
            var task = stubTaskRepository.Get(5);
            Assert.IsNull(task);
        }
        [Test]
        public void Get_TaskNameFromRepository_AreEqual()
        {
            var task = stubTaskRepository.Get(3);

            Assert.AreEqual("Name12", task.Name);
        }
        [Test]
        public void Get_TaskNameFromRepository_AreNotEqual()
        {
            var task = stubTaskRepository.Get(3);

            Assert.AreNotEqual("SomeName", task.Name);
        }
        [Test]
        public void Get_AllTasksFromRepository_IsNotNull()
        {
            var task = stubTaskRepository.GetAll();

            Assert.IsNotNull(task);
        }
        [Test]
        public void Get_AllTasksFromRepository_IsNull()
        {
            var task = stubTaskRepository.GetAll();

            Assert.IsNull(task);
        }
        [Test]
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
        [Test]
        public void Count_TasksFromRepository_AreEqual()
        {
            Assert.AreEqual(2, stubTaskRepository.GetAll().Count());

        }
        [Test]
        public void Count_TasksFromRepository_AreNotEqual()
        {
            Assert.AreNotEqual(3, stubTaskRepository.GetAll().Count());

        }
        [Test]
        public void Delete_TasksFromRepository_AreEqual()
        {
            stubTaskRepository.Delete(1);

            Assert.AreEqual(null, stubTaskRepository.Get(1));

        }
        [Test]
        public void Delete_TasksFromRepository_AreNotEqual()
        {
            stubTaskRepository.Delete(2);

            Assert.AreNotEqual(null, stubTaskRepository.Get(1));

        }
        [Test]
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
