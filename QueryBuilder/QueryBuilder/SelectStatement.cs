using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QueryBuilder
{
    public class SelectStatement<T> : Statement
    {

        private SelectClause<T> selectClause;
        private FromClause<T> fromClause;

        public SelectStatement()
        {
            fromClause = new FromClause<T>();
        }

        public Statement SelectAll()
        {
            selectClause = new SelectClause<T>();
            return this;
        }
        public Statement Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            Expression expression = selector.Body;

            var members = ((NewExpression)selector.Body).Members;
            List<string> properites = new List<string>();
            foreach (var member in members)
            {
                properites.Add(member.Name);
            }

            string columns = properites.Aggregate((x1, x2) => x1 + ", " + x2);
            selectClause = new SelectClause<T>(columns);

            return this;
        }
        public override string ToString()
        {
            StringBuilder query = new StringBuilder();
            query.Append(selectClause.ToString());
            query.AppendLine(fromClause.ToString());
            return query.ToString();
        }
    }
}
