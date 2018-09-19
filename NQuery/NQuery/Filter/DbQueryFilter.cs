using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace NQuery.Filter
{
    public class DbQueryFilter : ExpressionVisitor
    {
        private readonly Dictionary<ExpressionType, string> _logicalOperators;

        private readonly Dictionary<Type, Func<object, string>> _typeConverters;

        private readonly StringBuilder _queryStringBuilder;

        public DbQueryFilter()
        {
            _queryStringBuilder = new StringBuilder();

            _logicalOperators = new Dictionary<ExpressionType, string>
            {
                [ExpressionType.AndAlso] = "and",
                [ExpressionType.OrElse] = "or",
                [ExpressionType.LessThan] = "<",
                [ExpressionType.LessThanOrEqual] = "<=",
                [ExpressionType.LessThan] = "<",
                [ExpressionType.Equal] = "=",
                [ExpressionType.NotEqual] = "<>",
                [ExpressionType.GreaterThan] = ">",
                [ExpressionType.GreaterThanOrEqual] = ">="
            };

            _typeConverters = new Dictionary<Type, Func<object, string>>
            {
                [typeof(string)] = x => $"'{x}'",
                [typeof(DateTime)] = x => $"datetime'{((DateTime)x).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}'",
                [typeof(bool)] = x => x.ToString().ToLower()
            };

        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var argument = node.Arguments.FirstOrDefault();

            var value = argument?.ToString();
            string name = string.Empty;

            if (node.Object.NodeType == ExpressionType.MemberAccess)
            {
                name = ((MemberExpression)(node.Object)).Member.Name;
            }

            switch (node.Method.Name.ToLower())
            {
                case "startswith":
                    _queryStringBuilder.Append($"( {name} like N'{value.Replace("\"", "")}%' )");
                    break;
                case "endswith":
                    _queryStringBuilder.Append($"( {name} like N'%{value.Replace("\"", "")}' )");
                    break;
                case "contains":
                    _queryStringBuilder.Append($"( {name} like N'%{value.Replace("\"", "")}%' )");
                    break;
                case "tolower":
                    _queryStringBuilder.Append($"{node.Object.ToString().ToLower()}");
                    break;
                case "toupper":
                    _queryStringBuilder.Append($"{node.Object.ToString().ToUpper()}");
                    break;
                default:
                    break;
            }

            return node;
        }


        public string AsQuery(LambdaExpression predicate)
        {
            Visit(predicate.Body);

            var query = _queryStringBuilder.ToString();

            _queryStringBuilder.Clear();

            return query;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            _queryStringBuilder.Append("(");

            Visit(node.Left);

            _queryStringBuilder.Append($" {_logicalOperators[node.NodeType]} ");

            Visit(node.Right);

            _queryStringBuilder.Append(")");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _queryStringBuilder.Append(node.Member.Name);

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _queryStringBuilder.Append(GetValue(node.Value));

            return node;
        }

        private string GetValue(object input)
        {
            var type = input.GetType();

            if (_typeConverters.ContainsKey(type))
                return _typeConverters[type](input);
            else
                return input.ToString();

        }
    }

}
