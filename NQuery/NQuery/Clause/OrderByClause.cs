using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class OrderByClause<T> : Clause
    {
        public override string Name => "order by ";

        private string _columns;

        public OrderByClause(Expression<Func<T, object>> selector)
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
