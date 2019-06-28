using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Infrastructure;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIMS.BL.Services
{
    public class DIMSService : IDIMSService
    {
        EF.DAL.Data.IUnitOfWork Database { get; set; }


        public DIMSService(EF.DAL.Data.IUnitOfWork unit)
        {
            Database = unit;
        }

        public IEnumerable<UserTrackDTO> GetUserTracks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrack, UserTrackDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserTrack>, List<UserTrackDTO>>(Database.UserTracks.GetAll());
        }
        public UserTrackDTO GetUserTrack(int? id)
        {
            if (id == 0)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrack, UserTrackDTO>()).CreateMapper();
            return mapper.Map<UserTrack, UserTrackDTO>(Database.UserTracks.Get(id.Value));

        }
        public void CreateU(UserTrackDTO userTrack)
        {
            if (userTrack == null)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrack>()).CreateMapper();
            var _userTrack = mapper.Map<UserTrackDTO, UserTrack>(userTrack);
            Database.UserTracks.Create(_userTrack);
            Database.Save();
        }
        public void Edit(UserTrackDTO userTrack)
        {
            if (userTrack == null)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrack>()).CreateMapper();
            var _userTrack = mapper.Map<UserTrackDTO, UserTrack>(userTrack);
            Database.UserTracks.Update(_userTrack);
            Database.Save();
        }
        public void DeleteU(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id класса", "");
            Database.UserTracks.Delete(id.Value);
            Database.Save();
        }


        public IEnumerable<TaskDTO> GetTasks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Task>, List<TaskDTO>>(Database.Tasks.GetAll());
        }
        public TaskDTO GetTask(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            return mapper.Map<Task, TaskDTO>(Database.Tasks.Get(id.Value));

        }
        public void CreateT(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var _task = mapper.Map<TaskDTO, Task>(task);
            Database.Tasks.Create(_task);
            Database.Save();
        }
        public void Edit(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("Не установлено id класса", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var _task = mapper.Map<TaskDTO, Task>(task);
            Database.Tasks.Update(_task);
            Database.Save();
        }
        public void DeleteT(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id класса", "");
            Database.Tasks.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
