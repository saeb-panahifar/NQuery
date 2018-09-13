using System;
using System.Linq.Expressions;

namespace NQuery
{
    public interface ISelectOrderableQuery<T> : ISelectQuery<T>
    {
        ISelectQuery<T> OrderBy(Expression<Func<T, object>> selector);
    }
}
