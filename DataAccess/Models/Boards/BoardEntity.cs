using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Sections;
using DataAccess.Models.Sprints;
using DataAccess.Models.Teams;

namespace DataAccess.Models.Boards
{
    [Table("Boards")]
    internal sealed class BoardEntity : Entity
    {
        [ForeignKey(nameof(Owner))]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public UserEntity Owner { get; set; }
        public ICollection<SprintEntity> Sprints { get; set; }
        public ICollection<SectionEntity> Sections { get; set; }
    }
}