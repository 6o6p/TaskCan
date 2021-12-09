using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Teams;
using Domain.Models.Boards.Tasks;

namespace DataAccess.Models.Boards.Tasks
{
    [Table("Tasks")]
    internal sealed class TaskEntity : Entity
    {
        [ForeignKey(nameof(Section))]
        public Guid SectionId { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName = "text")]
        public TaskType Type { get; set; }
        
        [Column(TypeName = "text")]
        public TaskPriority Priority { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Until { get; set; } 

        public SectionEntity Section { get; set; }
        public ICollection<SprintEntity> Sprint { get; set; }
        public ICollection<UserEntity> Assignees { get; set; }
    }
}