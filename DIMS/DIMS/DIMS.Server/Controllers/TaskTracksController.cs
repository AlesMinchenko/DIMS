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
    public class TaskTrackController : Controller
    {
        ITaskTrackService taskTrackService;
        public TaskTrackController(ITaskTrackService taskTrackService)
        {
            this.taskTrackService = taskTrackService;
        }

        #region Mappers
        private TaskTrackDTO MapperGetTasks(TaskTrackViewModel taskTrackViewModel)
        {
            return Mapper.Map<TaskTrackViewModel, TaskTrackDTO>(taskTrackViewModel);

        }
        private TaskTrackViewModel MapperForCRUD(TaskTrackDTO taskTrackDTO)
        {
            return Mapper.Map<TaskTrackDTO, TaskTrackViewModel>(taskTrackDTO);

        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<TaskTrackDTO> taskTrackDTOs = taskTrackService.GetTaskTracks();
            var taskTracks = Mapper.Map<IEnumerable<TaskTrackDTO>, List<TaskTrackViewModel>>(taskTrackDTOs);
            return View("Index", taskTracks);
        }
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskTrackDTO = taskTrackService.GetTaskTrack(id);
            var taskTrackResult = MapperForCRUD(taskTrackDTO);

            if (taskTrackResult == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", taskTrackResult);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskTrackViewModel taskTrack)
        {
            if (ModelState.IsValid)
            {
                var taskTrackResult = MapperGetTasks(taskTrack);

                taskTrackService.Create(taskTrackResult);
                return RedirectToAction("Index");
            }

            return View(taskTrack);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var taskTrackDtos = taskTrackService.GetTaskTrack(id);
            var taskTrackResult = MapperForCRUD(taskTrackDtos);

            if (taskTrackResult == null)
            {
                return HttpNotFound();
            }
            return View("Edit", taskTrackResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskTrackViewModel taskTrack)
        {
            if (ModelState.IsValid)
            {
                var taskTrackResult = MapperGetTasks(taskTrack);
                taskTrackService.Edit(taskTrackResult);

                return RedirectToAction("Index");
            }
            return View(taskTrack);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskTrackDtos = taskTrackService.GetTaskTrack(id);
            var taskTrackResult = MapperForCRUD(taskTrackDtos);
            if (taskTrackResult == null)
            {
                return HttpNotFound();
            }
            return View(taskTrackResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taskTrackDtos = taskTrackService.GetTaskTrack(id);
            var taskTrackResult = MapperForCRUD(taskTrackDtos);

            taskTrackService.Delete(taskTrackResult.TaskTrackId);
            return RedirectToAction("Index");
        }
    }
}
