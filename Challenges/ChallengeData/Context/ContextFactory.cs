namespace ChallengeData.Context
{
    public class ContextFactory : IContextFactory
    {
        public IDataContext CreateContext()
        {
            return new DataContext();
        }
    }
}
