﻿using System;
using System.Collections.Generic;
using Domain.Models.Boards;
using Domain.Models.Sections;
using Domain.Models.Sprints;
using Domain.Models.Teams;

namespace Domain.Models.Tasks
{
    public sealed class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SectionId { get; set; }
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