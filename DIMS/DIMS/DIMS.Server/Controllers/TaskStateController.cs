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
    public class TaskStateController : Controller
    {
        private ITaskStateService taskStateService;
        public TaskStateController(ITaskStateService taskStateService)
        {
            this.taskStateService = taskStateService;
        }
        #region Mappers
        private TaskStateDTO MapperGetTaskState(TaskStateViewModel taskStateViewModel)
        {
            return Mapper.Map<TaskStateViewModel, TaskStateDTO>(taskStateViewModel);

        }
        private TaskStateViewModel MapperForCRUD(TaskStateDTO taskStateDTO)
        {
            return Mapper.Map<TaskStateDTO, TaskStateViewModel>(taskStateDTO);

        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<TaskStateDTO> taskStateDTOs = taskStateService.GetTaskStates();
            var taskStates = Mapper.Map<IEnumerable<TaskStateDTO>, List<TaskStateViewModel>>(taskStateDTOs);
            return View("Index", taskStates);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskStateDTOs = taskStateService.GetTaskState(id);
            var taskStateResult = MapperForCRUD(taskStateDTOs);

            if (taskStateResult == null)
            {
                return HttpNotFound();
            }
            return View(taskStateResult);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName")] TaskStateViewModel taskState)
        {
            if (ModelState.IsValid)
            {
                var taskStateResult = MapperGetTaskState(taskState);

                taskStateService.Create(taskStateResult);
                return RedirectToAction("Index");
            }

            return View(taskState);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var taskStateDTO = taskStateService.GetTaskState(id);
            var taskStateResult = MapperForCRUD(taskStateDTO);

            if (taskStateResult == null)
            {
                return HttpNotFound();
            }
            return View(taskStateResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName")] TaskStateViewModel taskState)
        {
            if (ModelState.IsValid)
            {
                var taskStateResult = MapperGetTaskState(taskState);
                taskStateService.Edit(taskStateResult);
                return RedirectToAction("Index");
            }
            return View(taskState);
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskStateDTO = taskStateService.GetTaskState(id);
            var taskStateResult = MapperForCRUD(taskStateDTO);
            if (taskStateResult == null)
            {
                return HttpNotFound();
            }
            return View(taskStateResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taskStateDTO = taskStateService.GetTaskState(id);
            var taskStateResult = MapperForCRUD(taskStateDTO);

            taskStateService.Delete(taskStateResult.StateId);
            return RedirectToAction("Index");
        }
    }
}
