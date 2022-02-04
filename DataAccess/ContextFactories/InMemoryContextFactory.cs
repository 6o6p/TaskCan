using Microsoft.EntityFrameworkCore;

namespace DataAccess.ContextFactories
{
    internal class InMemoryContextFactory : IContextFactory
    {
        public PostgreContext CreateContext()
        { 
            var optionsBuilder = new DbContextOptionsBuilder<PostgreContext>();
            optionsBuilder.UseInMemoryDatabase("test");
            return new PostgreContext(optionsBuilder.Options);
        }
    }
}