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
        IDIMSService dimsService;
        //использовать в параметрах 1 данную
        public TaskController(IDIMSService dimsService)
        {
            this.dimsService = dimsService;
        }
        public ActionResult Index()
        {
            IEnumerable<TaskDTO> taskDtos = dimsService.GetTasks();
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
            var taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var taskResult = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);

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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TaskDTO>()).CreateMapper();
                var taskResult = mapper.Map<TaskViewModel, TaskDTO>(task);

                dimsService.CreateT(taskResult);
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

            var taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var taskResult = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);


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
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TaskDTO>()).CreateMapper();
                var taskResult = mapper.Map<TaskViewModel, TaskDTO>(task);
                dimsService.Edit(taskResult);

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
            var taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var taskResult = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);
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
            var taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var taskResult = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);

            dimsService.DeleteT(taskResult.TaskId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dimsService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}