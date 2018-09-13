using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public interface ISqlQuery<TEntity>
    {
        string AsQuery();
        string AsQuery(string properites);
    }
}
