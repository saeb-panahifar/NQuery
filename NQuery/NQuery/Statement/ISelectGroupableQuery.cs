using System;
using System.Linq.Expressions;

namespace NQuery
{
    public interface ISelectGroupableQuery<T> : ISelectOrderableQuery<T>
    {
        ISelectOrderableQuery<T> GroupBy(Expression<Func<T, object>> selector);
    }
}
