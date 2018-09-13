using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class SelectStatement<T> : Statement, 
        ISelectQuery<T>,
        ISelectFilterQuery<T>,
        ISelectOrderableQuery<T>,
        ISelectGroupableQuery<T>
    {
        private SelectClause<T> selectClause;

        private readonly FromClause<T> fromClause;

        private WhereClause<T> whereClause;

        private GroupByClause<T> groupByClause;

        private OrderByClause<T> orderByClause;

        public SelectStatement()
        {
            fromClause = new FromClause<T>();
        }

        public ISelectFilterQuery<T> SelectAll()
        {
            selectClause = new SelectClause<T>();

            return this;
        }
        public ISelectFilterQuery<T> Select<TResult>(Expression<Func<T, TResult>> selector)
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

            query.Append(orderByClause?.ToString());

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


        public ISelectOrderableQuery<T> GroupBy(Expression<Func<T, object>> selector)
        {
            groupByClause = new GroupByClause<T>(selector);

            return this;
        }

        public ISelectGroupableQuery<T> Where(Expression<Func<T, bool>> expression)
        {
            whereClause = new WhereClause<T>(expression);

            return this;
        }

        public ISelectQuery<T> OrderBy(Expression<Func<T, object>> selector)
        {
            orderByClause = new OrderByClause<T>(selector);

            return this;
        }

    }
}
