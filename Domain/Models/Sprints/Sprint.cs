using System;
using System.Collections.Generic;
using Domain.Models.Boards;
using Domain.Models.Tasks;

namespace Domain.Models.Sprints
{
    public sealed class Sprint
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BoardId { get; set; }

        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }

        public Board Board { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}