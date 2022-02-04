using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Boards;
using DataAccess.Models.Tasks;

namespace DataAccess.Models.Sprints
{
    [Table("Sprints")]
    internal sealed class SprintEntity : Entity
    {
        [ForeignKey(nameof(Board))]
        public Guid BoardId { get; set; }

        [Required]
        public DateTime Starts { get; set; }

        [Required]
        public DateTime Ends { get; set; }

        public BoardEntity Board { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}