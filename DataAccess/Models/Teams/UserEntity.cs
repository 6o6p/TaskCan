using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Teams
{
    [Table("Users")]
    internal sealed class UserEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}