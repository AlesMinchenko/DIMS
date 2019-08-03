using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using HIMS.Server.Models;

namespace HIMS.Server.Controllers
{
    public class UserTaskController : Controller
    {
        IUserTaskService userTaskService;
        ITaskService taskService;
        IUserTrackService userTrackService;
        ITaskStateService taskStateService;
        public UserTaskController(IUserTaskService userTaskService, ITaskService taskService, IUserTrackService userTrackService, ITaskStateService taskStateService)
        {
            this.userTaskService = userTaskService;
            this.taskService = taskService;
            this.userTrackService = userTrackService;
            this.taskStateService = taskStateService;
        }

        #region Mappers
        private UserTaskDTO MapperGetUserTasks(UserTaskViewModel userTaskViewModel)
        {
            return Mapper.Map<UserTaskViewModel, UserTaskDTO>(userTaskViewModel);

        }
        private UserTaskViewModel MapperForCRUD(UserTaskDTO userTaskDTO)
        {
            return Mapper.Map<UserTaskDTO, UserTaskViewModel>(userTaskDTO);

        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<UserTaskDTO> userTaskDTOs = userTaskService.GetUserTasks();
            var userTasks = Mapper.Map<IEnumerable<UserTaskDTO>, List<UserTaskViewModel>>(userTaskDTOs);
            return View("Index", userTasks);
        }
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userTaskDTOs = userTaskService.GetUserTask(id);
            var userTaskResult = MapperForCRUD(userTaskDTOs);

            if (userTaskResult == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", userTaskResult);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TaskId = new SelectList(taskService.GetTasks(), "TaskId", "Name");
            ViewBag.UserId = new SelectList(userTrackService.GetUserTracks(), "UserId", "TaskName");
            ViewBag.StateId = new SelectList(taskStateService.GetTaskStates(), "StateId", "StateName");

            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserTaskViewModel userTask)
        {
            if (ModelState.IsValid)
            {
                var taskResult = MapperGetUserTasks(userTask);

                userTaskService.Create(taskResult);
                return RedirectToAction("Index");
            }

            return View(userTask);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userTaskDTO = userTaskService.GetUserTask(id);
            var userTaskResult = MapperForCRUD(userTaskDTO);

            if (userTaskResult == null)
            {
                return HttpNotFound();
            }
            return View("Edit", userTaskResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserTaskViewModel userTask)
        {
            if (ModelState.IsValid)
            {
                var userTaskResult = MapperGetUserTasks(userTask);
                userTaskService.Edit(userTaskResult);

                return RedirectToAction("Index");
            }
            return View(userTask);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userTaskDTO = userTaskService.GetUserTask(id);
            var userTaskResult = MapperForCRUD(userTaskDTO);
            if (userTaskResult == null)
            {
                return HttpNotFound();
            }
            return View(userTaskResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userTaskDTO = userTaskService.GetUserTask(id);
            var userTaskResult = MapperForCRUD(userTaskDTO);

            userTaskService.Delete(userTaskResult.UserTaskId);
            return RedirectToAction("Index");
        }
    }
}
