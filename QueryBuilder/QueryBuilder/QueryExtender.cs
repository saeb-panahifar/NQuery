using QueryBuilder.Helper;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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

        public string AsQuery() => _query.AsQuery();

        public string Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            Expression expression = selector.Body;

            var x = ((NewExpression)selector.Body).Members;
            List<string> properites = new List<string>();
            foreach (var item in x)
            {
                properites.Add(item.Name);
            }

            string p = properites.Aggregate((x1, x2) => x1 + ", " + x2);

            return _query.AsQuery(p);
        }

        public string SelectAll()
        {
            return _query.AsQuery();
        }

        public string Where(Expression<Func<TEntity, bool>> predicate)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(_query.AsQuery());
            query.AppendLine("where " + WhereHelper.GetWhereClause(predicate));
            return query.ToString();
        }

    }
}
