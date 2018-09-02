namespace QueryBuilder
{
    public class Query
    {
        public static string From<TEntity>()
            where TEntity : EntityBase
        {
            var fromQuery = new FromQuery<TEntity>();

            return fromQuery.AsQuery();
        }
    }
}
