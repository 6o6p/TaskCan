using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Boards.Tasks;

namespace DataAccess.Models.Boards
{
    [Table("Sections")]
    internal sealed class SectionEntity : Entity 
    {
        [ForeignKey(nameof(Board))]
        public Guid BoardId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public BoardEntity Board { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}