﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace NonFactors.Mvc.Grid
{
    public class DateTimeFilter<TModel> : BaseGridFilter<TModel> where TModel : class
    {
        public override IQueryable<TModel> Process(IQueryable<TModel> items)
        {
            Object value = GetDateValue();
            if (value == null) return items;

            Expression<Func<TModel, Boolean>> filter = GetFilterExpression(value);
            if (filter == null) return items;

            return items.Where(filter);
        }

        private Expression<Func<TModel, Boolean>> GetFilterExpression(Object value)
        {
            switch (Type)
            {
                case "Equals":
                    return ToLambda(Expression.Equal(GetNullSafeExpression(), Expression.Constant(value)));
                case "LessThan":
                    return ToLambda(Expression.LessThan(GetNullSafeExpression(), Expression.Constant(value)));
                case "GreaterThan":
                    return ToLambda(Expression.GreaterThan(GetNullSafeExpression(), Expression.Constant(value)));
                case "LessThanOrEqual":
                    return ToLambda(Expression.LessThanOrEqual(GetNullSafeExpression(), Expression.Constant(value)));
                case "GreaterThanOrEqual":
                    return ToLambda(Expression.GreaterThanOrEqual(GetNullSafeExpression(), Expression.Constant(value)));
            }

            return null;
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
