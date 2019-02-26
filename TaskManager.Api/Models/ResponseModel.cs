using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Api.Models
{
    public class ResponseModel
    {
        public List<TaskDetail> TasksList { get; set; }
        public TaskDetail Task { get; set; }
    }
}