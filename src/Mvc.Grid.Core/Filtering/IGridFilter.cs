﻿using System;
using System.Linq.Expressions;

namespace Iceoz.Mvc.Grid
{
    public interface IGridFilter
    {
        String Type { get; set; }
        String Value { get; set; }

        Expression Apply(Expression expression);
    }
}
