using System;
using System.Linq.Expressions;

namespace NQuery
{
    public interface ISelectGroupableQuery<T>
    {
        ISelectQuery<T> GroupBy(Expression<Func<T, object>> selector);
    }
}
