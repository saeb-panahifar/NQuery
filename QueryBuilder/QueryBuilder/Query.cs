namespace QueryBuilder
{
    public class Query
    {
        public static IQueryExtender<TEntity> From<TEntity>()
            where TEntity : EntityBase
        {
            var fromQuery = new FromQuery<TEntity>();

            return new QueryExtender<TEntity>(fromQuery);
        }
    }
}
