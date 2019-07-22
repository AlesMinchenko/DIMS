using HIMS.BL.Interfaces;
using HIMS.Server.Controllers;
using HIMS.Server.Models;
using System;
using System.Web.Mvc;
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
            taskController = new TaskController(service);
            taskViewModel = new TaskViewModel();

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
