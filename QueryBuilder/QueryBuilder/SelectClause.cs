using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryBuilder
{
    public class SelectClause<T> : Clause
    {
        public override string Name => "select";
        private string _columns;

        public SelectClause()
        {
            _columns = ColumnAsString();
        }

        public SelectClause(string columns)
        {
            _columns = columns;
        }

        public string ColumnAsString()
        {
            var properties = typeof(T).GetProperties();

            List<string> properyName = new List<string>();

            foreach (var item in properties)
            {
                properyName.Add(item.Name);
            }

            return properyName.Aggregate((s1, s2) => s1 + ", " + s2);
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();
            query.Append(this.Name + " ");
            query.AppendLine(this._columns);

            return query.ToString();
        }
    }

    public class Column
    {

    }
}
