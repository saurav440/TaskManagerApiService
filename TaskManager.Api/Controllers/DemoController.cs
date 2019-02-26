using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Api.Models;
using TaskManager.BusinessLayer;

namespace TaskManager.Api.Controllers
{
    public class DemoController : ApiController
    {
        TaskManagerBusiness businessObj = new TaskManagerBusiness();

        // GET: api/TaskManager
        [Route("api/GetAll1")]
        public List<Task> GetAll()
        {  
            return BuildTaskList(businessObj.GetAllTask());
        }

        // GET: api/TaskManager/5
        [Route("api/GetTask1/{id}")]
        [HttpGet]
        public ResponseModel Get(int id)
        {
            ResponseModel response = new ResponseModel();
           // var taskDetails = taskList.Where(x => Convert.ToInt32(x.TaskId) == id).FirstOrDefault();

          //  response.TasksList = taskList;
          //  response.Task = taskDetails;
            return response;

        }

        // POST: api/TaskManager
        [Route("api/AddTask1")]
        [HttpPost]
        public void Post(TaskDetail request)
        {
        }

        // PUT: api/TaskManager/5
        [HttpPut]
        [Route("api/Update")]
        public string Put(TaskDetail item)
        {
            return "Task has been Updated successfully.";
        }

        [Route("api/End/{id}")]
        [HttpGet]
        public string EndTask(int id)
        {
            return "Task has been ended successfully.";
        }
        // DELETE: api/TaskManager/5
        [Route("api/DeleteTask1/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            return "Task has been deleted successfully.";
        }

        private List<Task> BuildTaskList(List<Entity.Task> taskResp)
        {
            List<Task> tasks = new List<Task>();
            tasks = taskResp.Select(x => new Task
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                ParentId = x.ParentId,
                ParentTask = "",
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Priority = x.Priority,
                Status = x.Status
            }).ToList();

            return tasks;
        }
    }
}
