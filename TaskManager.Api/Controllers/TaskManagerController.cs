using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    public class TaskManagerController : ApiController
    {
       // string startdate = DateTime.Now.ToString("MM/dd/yyyy");
        List<TaskDetail> taskList = new List<TaskDetail>()
        {
                new TaskDetail{TaskId ="1",TaskName = "Task1",ParentId="",Status=true, ParentTask= "",Priority = 1,StartDate =DateTime.Now ,EndDate = DateTime.Now.AddDays(5)},
                new TaskDetail{TaskId ="2",TaskName = "Task2",ParentId="1",Status=false, ParentTask= "Task1",Priority = 7,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(10)},
                new TaskDetail{TaskId="3",TaskName = "Task3",ParentId="1",Status=true, ParentTask= "Task1",Priority = 4,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(4)},
                new TaskDetail{TaskId ="4",TaskName = "Task4",ParentId="1",Status=true, ParentTask= "Task1",Priority = 3,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(14)},
                new TaskDetail{TaskId ="5",TaskName = "Task5",ParentId="2",Status=true, ParentTask= "Task2",Priority = 4,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(12)},
                new TaskDetail{TaskId ="6",TaskName = "Task6",ParentId="1",Status=true, ParentTask= "Task1",Priority = 5,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(5)},
                new TaskDetail{TaskId="7",TaskName = "Task7", ParentId="5",Status=true, ParentTask= "Task5",Priority = 1,StartDate = DateTime.Now,EndDate = DateTime.Now.AddDays(2)},
        };
        // GET: api/TaskManager
        [Route("api/GetAll")]
        public List<TaskDetail> Get()
        {  
            return taskList;
        }

        // GET: api/TaskManager/5
        [Route("api/GetTask/{id}")]
        [HttpGet]
        public ResponseModel Get(int id)
        {
            ResponseModel response = new ResponseModel();
            var taskDetails = taskList.Where(x => Convert.ToInt32(x.TaskId) == id).FirstOrDefault();

            response.TasksList = taskList;
            response.Task = taskDetails;
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
        [Route("api/UpdateTask")]
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
        [Route("api/DeleteTask/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
             return "Task has been deleted successfully.";
        }
    }
}
