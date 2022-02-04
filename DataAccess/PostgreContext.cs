using DataAccess.Models.Boards;
using DataAccess.Models.Sections;
using DataAccess.Models.Sprints;
using DataAccess.Models.Tasks;
using DataAccess.Models.Teams;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    internal sealed class PostgreContext : DbContext
    {
        public DbSet<BoardEntity> Boards { get; set; }
        public DbSet<SectionEntity> Sections { get; set; }
        public DbSet<SprintEntity> Sprints { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        
        public PostgreContext(DbContextOptions<PostgreContext> options): base(options)
        {
        }
    }
}