using System;
using System.Collections.Generic;
using Domain.Models.Boards;
using Domain.Models.Tasks;

namespace Domain.Models.Sections
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