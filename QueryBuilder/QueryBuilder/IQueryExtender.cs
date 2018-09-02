using System;
using System.Linq.Expressions;

namespace QueryBuilder
{
    public interface IQueryExtender<TEntity>
        where TEntity : EntityBase
    {
        string Where(Expression<Func<TEntity, bool>> predicate);
    }
}
