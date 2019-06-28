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
        public TaskController(IDIMSService serv)
        {
            dimsService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<TaskDTO> taskDtos = dimsService.GetTasks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var tasks = mapper.Map<IEnumerable<TaskDTO>, List<TaskViewModel>>(taskDtos);
            return View(tasks);
        }

        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var __taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var taskDtos = mapper.Map<TaskDTO, TaskViewModel>(__taskDtos);

            if (taskDtos == null)
            {
                return HttpNotFound();
            }
            return View(taskDtos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TaskDTO>()).CreateMapper();
                var _task = mapper.Map<TaskViewModel, TaskDTO>(task);

                dimsService.CreateT(_task);
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
            var _taskDtos = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);


            if (_taskDtos == null)
            {
                return HttpNotFound();
            }
            return View(_taskDtos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskViewModel, TaskDTO>()).CreateMapper();
                var _taskDtos = mapper.Map<TaskViewModel, TaskDTO>(task);
                dimsService.Edit(_taskDtos);

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
            var _taskDtos = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);
            if (_taskDtos == null)
            {
                return HttpNotFound();
            }
            return View(_taskDtos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var taskDtos = dimsService.GetTask(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskViewModel>()).CreateMapper();
            var _taskDtos = mapper.Map<TaskDTO, TaskViewModel>(taskDtos);

            dimsService.DeleteT(_taskDtos.TaskId);
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