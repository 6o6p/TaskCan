using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    internal sealed class DesignContextFactory : IDesignTimeDbContextFactory<PostgreContext>
    {
        public PostgreContext CreateDbContext(string[] args)
        {
            return new PostgreContext();
        }
    }
}