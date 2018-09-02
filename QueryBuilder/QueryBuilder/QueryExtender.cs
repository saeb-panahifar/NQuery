using QueryBuilder.Helper;
using System;
using System.Linq.Expressions;
using System.Text;

namespace QueryBuilder
{
    public class QueryExtender<TEntity> : IQueryExtender<TEntity>
        where TEntity : EntityBase
    {
        private readonly ISqlQuery<TEntity> _query;
        public QueryExtender(ISqlQuery<TEntity> query)
        {
            _query = query;
        }

        public string Where(Expression<Func<TEntity, bool>> predicate)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(_query.AsQuery());
            query.AppendLine("where " + WhereHelper.GetWhereClause<TEntity>(predicate));
            return query.ToString();
        }

    }
}
