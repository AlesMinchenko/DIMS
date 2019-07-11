using System;
using System.Web.Mvc;
using HIMS.BL.Interfaces;
using HIMS.Server.Controllers;
using HIMS.Server.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIMS.Tests
{
    [TestClass]
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
        [TestMethod]
        public void ShowTaskViewResultNotNull()
        {
            ActionResult result = taskController.Index();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Get_NameViewResult_AreEqual()
        {
            ViewResult result = taskController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Get_NameViewResultFromCreate_AreEqual()
        {
            ViewResult result = taskController.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }
        [TestMethod]
        public void ShowTaskViewResultNotNull_FromCreate()
        {
            ActionResult result = taskController.Create(taskViewModel);
            Assert.IsNotNull(result);
        }
    }
}
