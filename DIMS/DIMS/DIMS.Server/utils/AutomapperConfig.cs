using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Models;
using HIMS.EF.DAL.Data;
using HIMS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.utils
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Sample, SampleDTO>();
                cfg.CreateMap<SampleDTO, Sample>();
                cfg.CreateMap<SampleViewModel, SampleDTO>();
                cfg.CreateMap<Task, TaskDTO>();
                cfg.CreateMap<TaskDTO, Task>();
                cfg.CreateMap<TaskViewModel, TaskDTO>();
                cfg.CreateMap<TaskDTO, TaskViewModel>();
                cfg.CreateMap<UserTrack, UserTrackDTO>();
                cfg.CreateMap<UserTrackDTO, UserTrack>();
                cfg.CreateMap<UserTrackViewModel, UserTrackDTO>();
                cfg.CreateMap<UserTrackDTO, UserTrackViewModel>();
                cfg.CreateMap<TaskTrack, TaskTrackDTO>();
                cfg.CreateMap<TaskTrackDTO, TaskTrack>();
                cfg.CreateMap<TaskTrackViewModel, TaskTrackDTO>();
                cfg.CreateMap<TaskTrackDTO, TaskTrackViewModel>();

            });
        }
    }
}