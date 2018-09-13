﻿using System;
using System.Linq.Expressions;
using System.Text;

namespace NQuery
{
    public class WhereClause<T> : Clause
    {
        public override string Name => "where";

        private string _whereAsString;

        public WhereClause()
        {
        }

        public WhereClause(Expression<Func<T, bool>> expression)
        {
            _whereAsString = GetValueAsString(expression.Body);
        }

        private string GetValueAsString(Expression expression)
        {
            var value = "";
            var equalty = "";
            var left = GetLeftNode(expression);
            var right = GetRightNode(expression);
            if (expression.NodeType == ExpressionType.Equal)
            {
                equalty = "=";
            }
            if (expression.NodeType == ExpressionType.AndAlso)
            {
                equalty = "AND";
            }
            if (expression.NodeType == ExpressionType.OrElse)
            {
                equalty = "OR";
            }
            if (expression.NodeType == ExpressionType.NotEqual)
            {
                equalty = "<>";
            }
            if (expression.NodeType == ExpressionType.GreaterThan)
            {
                equalty = ">";
            }
            if (expression.NodeType == ExpressionType.LessThan)
            {
                equalty = "<";
            }
            if (left is MemberExpression)
            {
                var leftMem = left as MemberExpression;

                value = string.Format("({0}{1}'{2}')", leftMem.Member.Name, equalty, "{0}");
            }
            if (right is ConstantExpression)
            {
                var rightConst = right as ConstantExpression;
                value = string.Format(value, rightConst.Value);
            }
            if (right is MemberExpression)
            {
                var rightMem = right as MemberExpression;
                var rightConst = rightMem.Expression as ConstantExpression;
                var member = rightMem.Member.DeclaringType;
                var type = rightMem.Member.MemberType;
                var val = member.GetField(rightMem.Member.Name).GetValue(rightConst.Value);
                value = string.Format(value, val);
            }
            if (value == "")
            {
                var leftVal = GetValueAsString(left);
                var rigthVal = GetValueAsString(right);
                value = string.Format("({0} {1} {2})", leftVal, equalty, rigthVal);
            }
            return value;
        }

        private static Expression GetLeftNode(Expression expression)
        {
            dynamic exp = expression;
            return ((Expression)exp.Left);
        }

        private static Expression GetRightNode(Expression expression)
        {
            dynamic exp = expression;
            return ((Expression)exp.Right);
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(this.Name + " " + this._whereAsString);

            return query.ToString();
        }

    }
}
