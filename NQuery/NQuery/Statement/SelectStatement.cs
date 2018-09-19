using System;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class SelectStatement<T> : Statement,
        ISelectableQuery<T>,
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

        public ISelectQuery<T> SelectAll()
        {
            selectClause = new SelectClause<T>();

            return this;
        }
        public ISelectQuery<T> Select(Expression<Func<T, object>> selector)
        {

            selectClause = new SelectClause<T>(selector);

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
