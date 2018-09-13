using System.Text;
using System.Linq;
using NQuery.DataAnnotations;

namespace NQuery
{
    public class FromClause<T> : Clause
    {
        public override string Name => "from";

        public FromClause()
        {

        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();

            query.Append(this.Name + " ");

            query.AppendLine(this.TableNameAsString());

            return query.ToString();
        }

        private string TableNameAsString()
        {
            var attributes = typeof(T).GetCustomAttributes(false);

            var tableMap = attributes.FirstOrDefault(attr => attr.GetType() == typeof(TableMap));

            return tableMap != null ? ((TableMap)tableMap).Name : typeof(T).Name;
        }
    }
}
