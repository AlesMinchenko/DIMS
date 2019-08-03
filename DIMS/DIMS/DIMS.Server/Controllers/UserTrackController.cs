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
    public class UserTrackController : Controller
    {
        IUserTrackService userTrackService;
        ITaskService taskService;
        ITaskTrackService taskTrackService;
        public UserTrackController(IUserTrackService userTrackService, ITaskService taskService, ITaskTrackService taskTrackService)
        {
            this.userTrackService = userTrackService;
            this.taskService = taskService;
            this.taskTrackService = taskTrackService;
        }

        #region Mappers
        private UserTrackDTO MapperGetUserTrack(UserTrackViewModel userTrackViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackViewModel, UserTrackDTO>()).CreateMapper();
            return mapper.Map<UserTrackViewModel, UserTrackDTO>(userTrackViewModel);

        }
        private UserTrackViewModel MapperForCRUD(UserTrackDTO userTrackDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            return mapper.Map<UserTrackDTO, UserTrackViewModel>(userTrackDTO);

        }
        #endregion

        public ActionResult Index()
        {
            IEnumerable<UserTrackDTO> userTrackDtos = userTrackService.GetUserTracks();
            var userTracks = Mapper.Map<IEnumerable<UserTrackDTO>, List<UserTrackViewModel>>(userTrackDtos);
            return View(userTracks);
        }

        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userTrackDtos = userTrackService.GetUserTrack(id);
            var userTracksResult = MapperForCRUD(userTrackDtos);

            if (userTracksResult == null)
            {
                return HttpNotFound();
            }
            return View(userTracksResult);
        }

        public ActionResult Create()
        {
            ViewBag.tasks = new SelectList(taskService.GetTasks(), "TaskId", "Name");
            ViewBag.taskTrack = new SelectList(taskTrackService.GetTaskTracks(), "TaskTrackId", "TrackNote");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserTrackViewModel userTrack)
        {
            if (ModelState.IsValid)
            {
                var userTrackResult = MapperGetUserTrack(userTrack);

                userTrackService.Create(userTrackResult);
                return RedirectToAction("Index");
            }

            return View(userTrack);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userTrackDtos = userTrackService.GetUserTrack(id);
            var userTrackResult = MapperForCRUD(userTrackDtos);
            ViewBag.TaskId = new SelectList(taskService.GetTasks(), "TaskId", "Name");
            ViewBag.TaskTrackId = new SelectList(taskTrackService.GetTaskTracks(), "TaskTrackId", "TrackNote");


            if (userTrackResult == null)
            {
                return HttpNotFound();
            }
            return View(userTrackResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserTrackViewModel userTrack)
        {
            if (ModelState.IsValid)
            {
                var userTrackResult = MapperGetUserTrack(userTrack);
                userTrackService.Edit(userTrackResult);

                return RedirectToAction("Index");
            }
            return View(userTrack);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userTrackDtos = userTrackService.GetUserTrack(id);
            var userTrackResult = MapperForCRUD(userTrackDtos);
            if (userTrackResult == null)
            {
                return HttpNotFound();
            }
            return View(userTrackResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userTrackDtos = userTrackService.GetUserTrack(id);
            var userTrackResult = MapperForCRUD(userTrackDtos);

            userTrackService.Delete(userTrackResult.UserId);
            return RedirectToAction("Index");
        }
    }
}