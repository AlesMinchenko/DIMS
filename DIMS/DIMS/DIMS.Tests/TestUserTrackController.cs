using System;
using System.Web.Mvc;
using HIMS.BL.Interfaces;
using HIMS.Server.Controllers;
using HIMS.Server.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HIMS.Tests
{
    [TestClass]
    public class TestUserTrackController
    {
        UserTrackController userTrackController = null;
        UserTrackViewModel userTrackView = null;
        IDIMSService serv;

        public TestUserTrackController()
        {
            userTrackController = new UserTrackController(serv);
            userTrackView = new UserTrackViewModel();
        }
        [TestMethod]
        public void UserTrackViewResultNotNull()
        {
            ViewResult result = userTrackController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexViewNameEqualIndexCshtmlName()
        {
            ViewResult result = userTrackController.Create() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void IndexStringInViewbag()
        {
            ViewResult result = userTrackController.Create() as ViewResult;

            Assert.AreEqual("MessageForTest", result.ViewBag.MessageForTest);
        }
    }
}
