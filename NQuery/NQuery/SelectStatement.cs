using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class SelectStatement<T> : Statement, ISelectStatement
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
        public ISelectStatement Select<TResult>(Expression<Func<T, TResult>> selector)
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

        public Statement Top(int number, bool percent)
        {
            selectClause.Top(number, percent);
            return this;
        }

        public Statement Top(int number)
        {
            selectClause.Top(number, false);
            return this;
        }
    }
}
