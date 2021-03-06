﻿using System;
using System.Linq.Expressions;

namespace TCEPR.Mvc.Grid
{
    public abstract class BaseGridFilter : IGridFilter
    {
        public String Type { get; set; }
        public String Value { get; set; }

        public abstract Expression Apply(Expression expression);
    }
}
