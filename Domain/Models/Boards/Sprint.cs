using System;
using System.Collections.Generic;
using Domain.Models.Boards.Tasks;

namespace Domain.Models.Boards
{
    public sealed class Sprint
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }

        public Board Board { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}