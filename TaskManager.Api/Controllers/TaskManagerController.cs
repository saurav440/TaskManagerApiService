using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TaskManager.Api.Models;
using TaskManager.BusinessLayer;
using TaskManager.Entity;

namespace TaskManager.Api.Controllers
{
    public class TaskManagerController : ApiController
    {
        TaskManagerBusiness businessObj = new TaskManagerBusiness();
       
        // GET: api/TaskManager
        [Route("api/GetAll")]
        public List<TaskDetail> GetAll()
        {
            return BuildTaskList(businessObj.GetAllTask());
        }

        // GET: api/TaskManager/5
        [Route("api/GetTask/{id}")]
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
        [Route("api/AddTask")]
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

        [Route("api/EndTask/{id}")]
        [HttpGet]
        public string EndTask(int id)
        {
            return "Task has been ended successfully.";
        }
        // DELETE: api/TaskManager/5
        [Route("api/Delete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
             return "Task has been deleted successfully.";
        }

        private List<TaskDetail> BuildTaskList(List<Task> taskResp)
        {
            List<TaskDetail> tasks = new List<TaskDetail>();
            tasks = taskResp.Select(x => new TaskDetail
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
