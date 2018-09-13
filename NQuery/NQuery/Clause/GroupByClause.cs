using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace NQuery
{
    public class GroupByClause<T, TResult> : Clause
    {
        public override string Name => "order by ";

        private string _columns;

        public GroupByClause(Expression<Func<T, TResult>> selector)
        {
            Expression expression = selector.Body;

            var members = ((NewExpression)selector.Body).Members;

            List<string> properites = new List<string>();

            foreach (var member in members)
            {
                properites.Add(member.Name);
            }

            _columns = properites.Aggregate((x1, x2) => x1 + ", " + x2);

        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();

            query.Append(this.Name);

            query.AppendLine(this._columns);

            return query.ToString();
        }

    }
}
