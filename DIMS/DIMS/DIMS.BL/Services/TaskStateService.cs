using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Infrastructure;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Services
{
    public class TaskStateService:ITaskStateService
    {
        IUnitOfWork Database { get; set; }


        public TaskStateService(IUnitOfWork database)
        {
            Database = database;
        }
        #region Mappers
        private TaskStateDTO MapperGetTaskStates(int? id)
        {
            return Mapper.Map<TaskState, TaskStateDTO>(Database.TaskStates.Get(id.Value));

        }
        private TaskState MapperForCRUD(TaskStateDTO taskStatesDTO)
        {
            return Mapper.Map<TaskStateDTO, TaskState>(taskStatesDTO);

        }
        #endregion

        public IEnumerable<TaskStateDTO> GetTaskStates()
        {
            return Mapper.Map<IEnumerable<TaskState>, List<TaskStateDTO>>(Database.TaskStates.GetAll());
        }
        public TaskStateDTO GetTaskState(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            return MapperGetTaskStates(id);

        }
        public void Create(TaskStateDTO taskState)
        {
            if (taskState == null)
                throw new ValidationException("The ID does not exist", "");
            var taskStateResult = MapperForCRUD(taskState);
            Database.TaskStates.Create(taskStateResult);
            Database.Save();
        }
        public void Edit(TaskStateDTO taskState)
        {
            if (taskState == null)
                throw new ValidationException("The ID does not exist", "");
            var taskStateResult = MapperForCRUD(taskState);
            Database.TaskStates.Update(taskStateResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            Database.TaskStates.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
