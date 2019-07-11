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
        private TaskDTO Mapper(TaskViewModel taskViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TaskDTO>()).CreateMapper();
            return mapper.Map<TaskViewModel, TaskDTO>(taskViewModel);

        }
        private TaskViewModel MapperForCRUD(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            return mapper.Map<TaskDTO, TaskViewModel>(taskDTO);

        }
        #endregion
        public ActionResult Index()
        {
            IEnumerable<TaskDTO> taskDtos = taskService.GetTasks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var tasks = mapper.Map<IEnumerable<TaskDTO>, List<TaskViewModel>>(taskDtos);
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
            return View(taskResult);
        }

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
                var taskResult = Mapper(task);

                taskService.Create(taskResult);
                return RedirectToAction("Index");
            }

            return View(task);
        }

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
            return View(taskResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var taskResult = Mapper(task);
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
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