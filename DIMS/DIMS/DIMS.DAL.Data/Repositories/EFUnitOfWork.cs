﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DIMSContext db;
        private TaskRepository taskRepository;
        private UserTrackRepository userTrackRepository;
        private SampleRepository sampleRepository;
        private TaskTrackRepository taskTrackRepository;
        private UserTaskRepository userTaskRepository;
        private TaskStateRepository taskStateRepository;

        public EFUnitOfWork()
        {
            db = new DIMSContext();
        }
        public IRepository<TaskTrack> TaskTracks
        {
            get
            {
                if (taskTrackRepository == null)
                    taskTrackRepository = new TaskTrackRepository(db);
                return taskTrackRepository;
            }
        }
        public IRepository<Task> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }
        public IRepository<UserTrack> UserTracks
        {
            get
            {
                if (userTrackRepository == null)
                    userTrackRepository = new UserTrackRepository(db);
                return userTrackRepository;
            }
        }
        public IRepository<UserTask> UserTasks
        {
            get
            {
                if (userTaskRepository == null)
                    userTaskRepository = new UserTaskRepository(db);
                return userTaskRepository;
            }
        }
        public IRepository<TaskState> TaskStates
        {
            get
            {
                if (taskStateRepository == null)
                    taskStateRepository = new TaskStateRepository(db);
                return taskStateRepository;
            }
        }
        public IRepository<Sample> Samples
        {
            get
            {
                if (sampleRepository == null)
                    sampleRepository = new SampleRepository(db);
                return sampleRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
