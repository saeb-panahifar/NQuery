using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class SelectStatement<T> : Statement, ISelectQuery<T>
    {
        private SelectClause<T> selectClause;

        private readonly FromClause<T> fromClause;

        private WhereClause<T> whereClause;

        private GroupByClause<T, object> groupByClause;

        public SelectStatement()
        {
            fromClause = new FromClause<T>();
        }

        public ISelectQuery<T> SelectAll()
        {
            selectClause = new SelectClause<T>();

            return this;
        }
        public ISelectQuery<T> Select<TResult>(Expression<Func<T, TResult>> selector)
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

            query.Append(selectClause?.ToString());

            query.Append(fromClause?.ToString());

            query.Append(whereClause?.ToString());

            query.Append(groupByClause?.ToString());

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

        public ISelectQuery<T> Distinct()
        {
            selectClause.Distinct();

            return this;
        }

        public ISelectGroupableQuery<T> Where(Expression<Func<T, bool>> expression)
        {
            whereClause = new WhereClause<T>(expression);

            return this;
        }

        public ISelectQuery<T> GroupBy(Expression<Func<T, object>> selector)
        {
            groupByClause = new GroupByClause<T, object>(selector);

            return this;
        }
    }
}
