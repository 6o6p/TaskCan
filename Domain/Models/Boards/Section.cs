using System;
using System.Collections.Generic;
using Domain.Models.Boards.Tasks;

namespace Domain.Models.Boards
{
    public sealed class Section
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BoardId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public Board Board { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}