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
    public class UserTrackService : IUserTrackService
    {
        IUnitOfWork Database { get; set; }


        public UserTrackService(IUnitOfWork database)
        {
            Database = database;
        }

        #region Mappers
        private UserTrackDTO Mapper(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrack, UserTrackDTO>()).CreateMapper();
            return mapper.Map<UserTrack, UserTrackDTO>(Database.UserTracks.Get(id.Value));
        }
        private UserTrack MapperForCRUD(UserTrackDTO userTrackDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrackDTO, UserTrack>()).CreateMapper();
            return mapper.Map<UserTrackDTO, UserTrack>(userTrackDTO);
        }
        #endregion

        public IEnumerable<UserTrackDTO> GetUserTracks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTrack, UserTrackDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserTrack>, List<UserTrackDTO>>(Database.UserTracks.GetAll());
        }
        public UserTrackDTO GetUserTrack(int? id)
        {
            if (id == 0)
                throw new ValidationException("The ID does not exist", "");
            return Mapper(id);

        }
        public void Create(UserTrackDTO userTrack)
        {
            if (userTrack == null)
                throw new ValidationException("The ID does not exist", "");
            var userTrackResult = MapperForCRUD(userTrack);
            Database.UserTracks.Create(userTrackResult);
            Database.Save();
        }
        public void Edit(UserTrackDTO userTrack)
        {
            if (userTrack == null)
                throw new ValidationException("The ID does not exists", "");
            var userTrackResult = MapperForCRUD(userTrack);
            Database.UserTracks.Update(userTrackResult);
            Database.Save();
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("The ID does not exist", "");
            Database.UserTracks.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
