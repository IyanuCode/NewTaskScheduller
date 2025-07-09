using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTaskScheduller.Models
{
    public class ScheduledTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}