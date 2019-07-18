using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Infrastructure;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;

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
        private TaskDTO MapperGetTasks(int? id)
        {
            return Mapper.Map<Task, TaskDTO>(Database.Tasks.Get(id.Value));

        }
        private Task MapperForCRUD(TaskDTO taskDTO)
        {
            return Mapper.Map<TaskDTO, Task>(taskDTO);

        }
        #endregion

        public IEnumerable<TaskDTO> GetTasks()
        {
            return Mapper.Map<IEnumerable<Task>, List<TaskDTO>>(Database.Tasks.GetAll());
        }
        public TaskDTO GetTask(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            return MapperGetTasks(id);

        }
        public void Create(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("The ID does not exist", "");
            var taskResult = MapperForCRUD(task);
            Database.Tasks.Create(taskResult);
            Database.Save();
        }
        public void Edit(TaskDTO task)
        {
            if (task == null)
                throw new ValidationException("The ID does not exist", "");
            var taskResult = MapperForCRUD(task);
            Database.Tasks.Update(taskResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            Database.Tasks.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
