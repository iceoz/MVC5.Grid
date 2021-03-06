﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace TCEPR.Mvc.Grid
{
    public interface IGrid
    {
        String Name { get; set; }
        String EmptyText { get; set; }
        String ColumnEmptyText { get; set; }
        String CssClasses { get; set; }
        String AjaxUrl { get; set; }
        Boolean SkipProcess { get; set; }
        Boolean IsMinified { get; set; }
        String TagMinified { get; }

        String LoadingText { get; set; }
        String LoadingGif { get; set; }

        NameValueCollection Query { get; set; }
        HttpContextBase HttpContext { get; set; }

        IGridColumns Columns { get; }

        IGridRows Rows { get; }

        IGridPager Pager { get; }
    }

    public interface IGrid<T> : IGrid
    {
        IList<IGridProcessor<T>> Processors { get; set; }
        IQueryable<T> Source { get; set; }

        new IGridColumns<T> Columns { get; }
        new IGridRows<T> Rows { get; }

        new IGridPager<T> Pager { get; set; }
    }
}
