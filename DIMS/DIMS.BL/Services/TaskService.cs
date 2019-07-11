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
    public class TaskService : ITaskService
    {
        IUnitOfWork Database { get; set; }


        public TaskService(IUnitOfWork database)
        {
            Database = database;
        }
        #region Mappers
        private TaskDTO Mapper(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            return mapper.Map<Task, TaskDTO>(Database.Tasks.Get(id.Value));

        }
        private Task MapperForCRUD(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            return mapper.Map<TaskDTO, Task>(taskDTO);

        }
        #endregion

        public IEnumerable<TaskDTO> GetTasks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Task>, List<TaskDTO>>(Database.Tasks.GetAll());
        }
        public TaskDTO GetTask(int? id)
        {
            if (id == null)
                throw new ValidationException("Don't installed id of class", "");
            return Mapper(id);

        }
        public void Create(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("Don't installed id of class", "");
            var taskResult = MapperForCRUD(task);
            Database.Tasks.Create(taskResult);
            Database.Save();
        }
        public void Edit(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("Don't installed id of class", "");
            var taskResult = MapperForCRUD(task);
            Database.Tasks.Update(taskResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("Don't installed id of class", "");
            Database.Tasks.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
