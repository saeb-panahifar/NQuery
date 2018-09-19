using System;
using System.Linq.Expressions;

namespace NQuery
{
    public interface ISelectableQuery<T>
    {
        ISelectQuery<T> SelectAll();
        ISelectQuery<T> Select(Expression<Func<T, object>> selector);
    }
}
