using NQuery.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NQuery
{
    public delegate IEnumerable<T> PropertyFetch<T>();

    public class SelectClause<T> : Clause
    {
        public override string Name => "select";

        private string _columns;

        private string _top;

        private string _distinct;

        public SelectClause()
        {
            _columns = ColumnNamesAsString(typeof(T).GetProperties());
        }

        public SelectClause(Expression<Func<T, object>> selector)
        {
            Expression expression = selector.Body;

            var members = ((NewExpression)selector.Body).Members;

            List<string> properyName = new List<string>();

            foreach (MemberInfo item in members)
            {
                var columnMap = Attribute.GetCustomAttribute(selector.Parameters[0].Type.GetProperty(item.Name), typeof(ColumnMap));

                var name = columnMap != null ? ((ColumnMap)columnMap).Name : item.Name;

                properyName.Add(name);
            }

            _columns= properyName.Aggregate((s1, s2) => s1 + ", " + s2);
        }

        private string ColumnNamesAsString(MemberInfo[] properites)
        {
            List<string> properyName = new List<string>();

            foreach (MemberInfo item in properites)
            {
                var columnMap = item.GetCustomAttribute<ColumnMap>();

                var name = columnMap != null ? (columnMap).Name : item.Name;

                properyName.Add(name);
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
