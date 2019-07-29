using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HIMS.Server.Controllers
{
    public class TaskController : Controller
    {
        ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        #region Mappers
        private TaskDTO MapperGetTasks(TaskViewModel taskViewModel)
        {
            return Mapper.Map<TaskViewModel, TaskDTO>(taskViewModel);

        }
        private TaskViewModel MapperForCRUD(TaskDTO taskDTO)
        {
            return Mapper.Map<TaskDTO, TaskViewModel>(taskDTO);

        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<TaskDTO> taskDtos = taskService.GetTasks();
            var tasks = Mapper.Map<IEnumerable<TaskDTO>, List<TaskViewModel>>(taskDtos);
            return View("Index", tasks);
        }
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskDtos = taskService.GetTask(id);
            var taskResult = MapperForCRUD(taskDtos);

            if (taskResult == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", taskResult);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var taskResult = MapperGetTasks(task);

                taskService.Create(taskResult);
                return RedirectToAction("Index");
            }

            return View(task);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var taskDtos = taskService.GetTask(id);
            var taskResult = MapperForCRUD(taskDtos);

            if (taskResult == null)
            {
                return HttpNotFound();
            }
            return View("Edit", taskResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var taskResult = MapperGetTasks(task);
                taskService.Edit(taskResult);

                return RedirectToAction("Index");
            }
            return View(task);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskDtos = taskService.GetTask(id);
            var taskResult = MapperForCRUD(taskDtos);
            if (taskResult == null)
            {
                return HttpNotFound();
            }
            return View(taskResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taskDtos = taskService.GetTask(id);
            var taskResult = MapperForCRUD(taskDtos);

            taskService.Delete(taskResult.TaskId);
            return RedirectToAction("Index");
        }
    }
}