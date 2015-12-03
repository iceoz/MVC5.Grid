﻿using System;
using System.Linq.Expressions;

namespace TCEPR.Mvc.Grid
{
    public class DateTimeFilter : BaseGridFilter
    {
        public override Expression Apply(Expression expression)
        {
            Object value = GetDateValue();
            if (value == null) return null;

            switch (Type)
            {
                case "Equals":
                    return Expression.Equal(expression, Expression.Constant(value, expression.Type));
                case "LessThan":
                    return Expression.LessThan(expression, Expression.Constant(value, expression.Type));
                case "GreaterThan":
                    return Expression.GreaterThan(expression, Expression.Constant(value, expression.Type));
                case "LessThanOrEqual":
                    return Expression.LessThanOrEqual(expression, Expression.Constant(value, expression.Type));
                case "GreaterThanOrEqual":
                    return Expression.GreaterThanOrEqual(expression, Expression.Constant(value, expression.Type));
                default:
                    return null;
            }
        }

        private Object GetDateValue()
        {
            DateTime date;
            if (DateTime.TryParse(Value, out date))
                return date;

            return null;
        }
    }
}
