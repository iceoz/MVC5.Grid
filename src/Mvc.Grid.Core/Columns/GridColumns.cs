﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TCEPR.Mvc.Grid
{
    public class GridColumns<T> : List<IGridColumn>, IGridColumns<T> where T : class
    {
        public IGrid<T> Grid { get; set; }

        public GridColumns(IGrid<T> grid)
        {
            Grid = grid;
        }

        public virtual IGridColumn<T> Add<TValue>(Expression<Func<T, TValue>> expression)
        {
            IGridColumn<T> column = new GridColumn<T, TValue>(Grid, expression);
            Grid.Processors.Add(column);
            Add(column);

            return column;
        }
        public virtual IGridColumn<T> Insert<TValue>(Int32 index, Expression<Func<T, TValue>> expression)
        {
            IGridColumn<T> column = new GridColumn<T, TValue>(Grid, expression);
            Grid.Processors.Add(column);
            Insert(index, column);

            return column;
        }
    }
}
