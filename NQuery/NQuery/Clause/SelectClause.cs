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
            var arguments = ((NewExpression)selector.Body).Arguments;

            List<string> properyName = new List<string>();

            foreach (Expression item in arguments)
            {
                if (item is MethodCallExpression)
                {
                    var method = ((MethodCallExpression)item).Method;
                    var argument = ((MemberExpression)((MethodCallExpression)item).Arguments.First());

                    var columnMap = Attribute.GetCustomAttribute(selector.Parameters[0].Type.GetProperty(argument.Member.Name), typeof(ColumnMap));

                    var name = columnMap != null ? ((ColumnMap)columnMap).Name : argument.Member.Name;

                    object[] _stringMethodParams = new object[] { name };
                    var invokeName = method.Invoke(null, _stringMethodParams).ToString();

                    properyName.Add(invokeName);

                }
                else if (item is MemberExpression)
                {
                    var x = ((MemberExpression)item).Member;
                    var columnMap = Attribute.GetCustomAttribute(selector.Parameters[0].Type.GetProperty(x.Name), typeof(ColumnMap));

                    var name = columnMap != null ? ((ColumnMap)columnMap).Name : x.Name;

                    properyName.Add(name);
                }

            }

            _columns = properyName.Aggregate((s1, s2) => s1 + ", " + s2);
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
