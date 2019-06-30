using System;
using HIMS.BL.Interfaces;
using HIMS.Server.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using HIMS.Server.Models;

namespace HIMS.Tests
{
    [TestClass]
    public class TestTaskController
    {
        TaskController taskController = null;
        TaskViewModel taskView = null;
        IDIMSService serv;

        public TestTaskController()
        {
            taskController = new TaskController(serv);
            taskView = new TaskViewModel();
        }
        [TestMethod]
        public void TaskViewResultNotNull()
        {
            ViewResult result = taskController.Create(taskView) as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexViewNameEqualIndexCshtmlName()
        {
            ViewResult result = taskController.Create() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void IndexStringInViewbag()
        {
            ViewResult result = taskController.Create() as ViewResult;

            Assert.AreEqual("MessageForTest", result.ViewBag.MessageForTest);
        }
    }
}
