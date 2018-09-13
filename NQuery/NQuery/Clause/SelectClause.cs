using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NQuery
{
    public class SelectClause<T> : Clause
    {
        public override string Name => "select";

        private string _columns;

        private string _top;

        private string _distinct;

        public SelectClause()
        {
            _columns = ColumnAsString();
        }

        public SelectClause(string columns)
        {
            _columns = columns;
        }

        private string ColumnAsString()
        {
            var properties = typeof(T).GetProperties();

            List<string> properyName = new List<string>();

            foreach (var item in properties)
            {
                properyName.Add(item.Name);
            }

            return properyName.Aggregate((s1, s2) => s1 + ", " + s2);
        }

        public void Top(int number, bool percent)
        {
            _top = "top (" + number + ")" + (percent == true ? " percent " : "");
        }

        public void Distinct()
        {
            _distinct = "distinct";
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();

            query.Append(this.Name + " " + _distinct + " " + _top + " ");

            query.AppendLine(this._columns);

            return query.ToString();
        }
    }

}
