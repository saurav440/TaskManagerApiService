using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entity
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public int? ParentId { get; set; }
        [Column(TypeName ="varchar")]
        public string TaskName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; }
    }
}
