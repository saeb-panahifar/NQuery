using System;
using System.Linq.Expressions;

namespace NQuery
{
    public interface ISelectFilterQuery<T> : ISelectQuery<T>
    {
        ISelectGroupableQuery<T> Where(Expression<Func<T, bool>> expression);
    }
}
