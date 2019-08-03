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
    public class UserTaskService : IUserTaskService
    {
        IUnitOfWork Database { get; set; }


        public UserTaskService(IUnitOfWork database)
        {
            Database = database;
        }

        #region Mappers
        private UserTaskDTO MapperGetUserTask(int? id)
        {
            return Mapper.Map<UserTask, UserTaskDTO>(Database.UserTasks.Get(id.Value));
        }
        private UserTask MapperForCRUD(UserTaskDTO userTaskDTO)
        {
            return Mapper.Map<UserTaskDTO, UserTask>(userTaskDTO);
        }
        #endregion

        public IEnumerable<UserTaskDTO> GetUserTasks()
        {
            return Mapper.Map<IEnumerable<UserTask>, List<UserTaskDTO>>(Database.UserTasks.GetAll());
        }
        public UserTaskDTO GetUserTask(int? id)
        {
            if (id == 0)
                throw new ValidationException("The ID does not exist", "");
            return MapperGetUserTask(id);

        }
        public void Create(UserTaskDTO userTask)
        {
            if (userTask == null)
                throw new ValidationException("The ID does not exist", "");
            var userTaskResult = MapperForCRUD(userTask);
            Database.UserTasks.Create(userTaskResult);
            Database.Save();
        }
        public void Edit(UserTaskDTO userTask)
        {
            if (userTask == null)
                throw new ValidationException("The ID does not exists", "");
            var userTaskResult = MapperForCRUD(userTask);
            Database.UserTasks.Update(userTaskResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            Database.UserTasks.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
