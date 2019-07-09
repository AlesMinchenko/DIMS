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
        IDIMSService dimsService;
        public UserTrackController(IDIMSService dimsService)
        {
            this.dimsService = dimsService;
        }
        public ActionResult Index()
        {
            IEnumerable<UserTrackDTO> userTrackDtos = dimsService.GetUserTracks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            var userTracks = mapper.Map<IEnumerable<UserTrackDTO>, List<UserTrackViewModel>>(userTrackDtos);
            return View(userTracks);
        }

        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userTrackDtos = dimsService.GetUserTrack(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            var userTracksResult = mapper.Map<UserTrackDTO, UserTrackViewModel>(userTrackDtos);

            if (userTracksResult == null)
            {
                return HttpNotFound();
            }
            return View(userTracksResult);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserTrackViewModel userTrack)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackViewModel, UserTrackDTO>()).CreateMapper();
                var userTrackResult = mapper.Map<UserTrackViewModel, UserTrackDTO>(userTrack);

                dimsService.CreateU(userTrackResult);
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

            var userTrackDtos = dimsService.GetUserTrack(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            var _userTrackDtos = mapper.Map<UserTrackDTO, UserTrackViewModel>(userTrackDtos);


            if (_userTrackDtos == null)
            {
                return HttpNotFound();
            }
            return View(_userTrackDtos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserTrackViewModel userTrack)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackViewModel, UserTrackDTO>()).CreateMapper();
                var _userTrack = mapper.Map<UserTrackViewModel, UserTrackDTO>(userTrack);
                dimsService.Edit(_userTrack);

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
            var userTrackDtos = dimsService.GetUserTrack(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            var _userTrackDtos = mapper.Map<UserTrackDTO, UserTrackViewModel>(userTrackDtos);
            if (_userTrackDtos == null)
            {
                return HttpNotFound();
            }
            return View(_userTrackDtos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userTrackDtos = dimsService.GetUserTrack(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrackViewModel>()).CreateMapper();
            var _userTrackDtos = mapper.Map<UserTrackDTO, UserTrackViewModel>(userTrackDtos);

            dimsService.DeleteU(userTrackDtos.UserId);
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