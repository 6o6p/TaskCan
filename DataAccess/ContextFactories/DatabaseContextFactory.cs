using Microsoft.EntityFrameworkCore;

namespace DataAccess.ContextFactories
{
    internal class DatabaseContextFactory : IContextFactory
    {
        public PostgreContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=sudo");
            return new PostgreContext(optionsBuilder.Options);
        }
    }
}