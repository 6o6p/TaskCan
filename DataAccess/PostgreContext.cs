using DataAccess.Models.Boards;
using DataAccess.Models.Boards.Tasks;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgrepass");
    }
}