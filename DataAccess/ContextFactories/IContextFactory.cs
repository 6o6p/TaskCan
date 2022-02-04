namespace DataAccess.ContextFactories
{
    internal interface IContextFactory
    {
        PostgreContext CreateContext();
    }
}