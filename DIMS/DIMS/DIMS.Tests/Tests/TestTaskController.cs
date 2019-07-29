using HIMS.BL.Interfaces;
using HIMS.Server.Controllers;
using HIMS.Server.Models;
using System;
using System.Web.Mvc;
using HIMS.BL.Services;
using HIMS.EF.DAL.Data;
using HIMS.EF.DAL.Data.Repositories;
using NUnit.Framework;

namespace HIMS.Tests.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        private TaskController taskController;
        private TaskViewModel taskViewModel;
        private ITaskService service;
        public TaskControllerTest()
        {

        }
        [SetUp]
        public void SetUp()
        {
            var iow = new EFUnitOfWork();
            service = new TaskService(iow);
            taskController = new TaskController(service);
            taskViewModel = new TaskViewModel() { TaskId = 1, DeadlineDate = new DateTime(2019, 5, 11), Description = "Some description", Name = "Some name", StartDate = new DateTime(2019, 6, 10) };

        }
        [Test]
        public void ShowTaskViewResultNotNull()
        {
            ActionResult result = taskController.Index();
            Assert.IsNotNull(result);
        }
        [Test]
        public void Get_NameViewResult_AreEqual()
        {
            ViewResult result = taskController.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }
        [Test]
        public void Get_NameViewResultFromCreate_AreEqual()
        {
            ViewResult result = taskController.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }
        [Test]
        public void ShowTaskViewResultNotNull_FromCreate()
        {
            ActionResult result = taskController.Create(taskViewModel);
            Assert.IsNotNull(result);
        }
    }
}
