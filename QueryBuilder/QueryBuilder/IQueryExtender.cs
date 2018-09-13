using System;
using System.Linq.Expressions;

namespace QueryBuilder
{
    public interface IQueryExtender<TEntity> : IQuery
        where TEntity : EntityBase
    {
        string Where(Expression<Func<TEntity, bool>> predicate);
        string Select<TResult>(Expression<Func<TEntity, TResult>> selector);
        string SelectAll();
    }
}
