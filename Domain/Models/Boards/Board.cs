using System;
using System.Collections.Generic;
using Domain.Models.Teams;

namespace Domain.Models.Boards
{
    public sealed class Board
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        //TODO teams
        public User Owner { get; set; }
        
        public ICollection<Sprint> Sprints { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}