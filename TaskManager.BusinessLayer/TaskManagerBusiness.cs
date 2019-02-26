using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entity;
using TaskManager.DataLayer;

namespace TaskManager.BusinessLayer
{
    public class TaskManagerBusiness
    {
        public List<Task> GetAllTask()
        {
            using (TaskContext dbcontext = new TaskContext())
            {
               return dbcontext.Tasks.ToList();
            }
        }

        public Task GetTaskById(int taskId)
        {
            using (TaskContext dbcontext = new TaskContext())
            {
                return dbcontext.Tasks.Find(taskId);
            }
        }

        public void AddTask(Task task)
        {
            using (TaskContext dbcontext = new TaskContext())
            {
                dbcontext.Tasks.Add(task);
                dbcontext.SaveChanges();
            }
        }
        public void UpdateTask(Task task)
        {
            using (TaskContext dbcontext = new TaskContext())
            {
                var context = dbcontext.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
                context.ParentId = task.ParentId;
                context.StartDate = task.StartDate;
                context.EndDate = task.EndDate;
                context.Priority = task.Priority;

                dbcontext.SaveChanges();
            }
        }

        public List<Task> EndTask(int taskId)
        {
            using (TaskContext dbcontext = new TaskContext())
            {
                var context = dbcontext.Tasks.Find(taskId);
                context.EndDate = DateTime.Now;
                context.Status = true;

                dbcontext.SaveChanges();

                return dbcontext.Tasks.ToList();
            }
        }

        public List<Task> DeleteTask(int id)
        {
            using (TaskContext dbcontext = new TaskContext())
            {
                var task = dbcontext.Tasks
                                    .Where(s => s.TaskId == id)
                                    .FirstOrDefault();

                dbcontext.Entry(task).State = System.Data.Entity.EntityState.Deleted;
                dbcontext.SaveChanges();

                return dbcontext.Tasks.ToList();
            }

        }
    }
}
