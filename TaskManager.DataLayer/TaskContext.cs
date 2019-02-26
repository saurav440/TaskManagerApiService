using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TaskManager.Entity;

namespace TaskManager.DataLayer
{
    public class TaskContext:DbContext
    {
        public TaskContext():base("TaskManagementDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TaskContext>());
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
