using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.ContextFactories.DesignTime
{
    //Фабрика для миграций. Обратите внимание, от IContextFactory не наследуется 
    internal sealed class DesignTimeContextFactory : IDesignTimeDbContextFactory<PostgreContext>
    {
        public PostgreContext CreateDbContext(string[] args) => 
            new DatabaseContextFactory().CreateContext();
    }
}