using NQuery.Filter;
using System;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class WhereClause<T> : Clause
    {
        public override string Name => "where";

        private string _whereAsString;

        public WhereClause()
        {
        }

        public WhereClause(Expression<Func<T, bool>> expression)
        {
            var queryFilter = new DbQueryFilter();
            _whereAsString = queryFilter.AsQuery(expression);
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(this.Name + " " + this._whereAsString);

            return query.ToString();
        }

    }
}
