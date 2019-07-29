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
    public class TaskTrackService: ITaskTrackService
    {
        IUnitOfWork Database { get; set; }


        public TaskTrackService(IUnitOfWork database)
        {
            Database = database;
        }
        #region Mappers
        private TaskTrackDTO MapperGetTaskTracks(int? id)
        {
            return Mapper.Map<TaskTrack, TaskTrackDTO>(Database.TaskTracks.Get(id.Value));

        }
        private TaskTrack MapperForCRUD(TaskTrackDTO taskTrackDTO)
        {
            return Mapper.Map<TaskTrackDTO, TaskTrack>(taskTrackDTO);

        }
        #endregion

        public IEnumerable<TaskTrackDTO> GetTaskTracks()
        {
            return Mapper.Map<IEnumerable<TaskTrack>, List<TaskTrackDTO>>(Database.TaskTracks.GetAll());
        }
        public TaskTrackDTO GetTaskTrack(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            return MapperGetTaskTracks(id);

        }
        public void Create(TaskTrackDTO taskTrack)
        {
            if (taskTrack == null)
                throw new ValidationException("The ID does not exist", "");
            var taskTrackResult = MapperForCRUD(taskTrack);
            Database.TaskTracks.Create(taskTrackResult);
            Database.Save();
        }
        public void Edit(TaskTrackDTO taskTrack)
        {
            if (taskTrack == null)
                throw new ValidationException("The ID does not exist", "");
            var taskTrackResult = MapperForCRUD(taskTrack);
            Database.TaskTracks.Update(taskTrackResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            Database.TaskTracks.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
