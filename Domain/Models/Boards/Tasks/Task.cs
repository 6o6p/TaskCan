using System;
using System.Collections.Generic;
using Domain.Models.Teams;

namespace Domain.Models.Boards.Tasks
{
    public sealed class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        
        public TaskType Type { get; set; }
        public TaskPriority Priority { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Until { get; set; } 

        public Section Section { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
        
        public ICollection<User> Assignees { get; set; }
    }
}