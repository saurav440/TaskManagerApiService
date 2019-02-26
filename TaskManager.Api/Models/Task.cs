using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Api.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string ParentTask { get; set; }
        public int? ParentId { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}