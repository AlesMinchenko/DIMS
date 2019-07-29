using HIMS.BL.Interfaces;
using HIMS.BL.Services;
using HIMS.EF.DAL.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.utils
{
    public class DependencesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ITaskService>().To<TaskService>();
            Bind<IUserTrackService>().To<UserTrackService>();
            Bind<ITaskTrackService>().To<TaskTrackService>();
        }
    }
}