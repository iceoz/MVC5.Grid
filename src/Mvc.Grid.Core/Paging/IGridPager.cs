﻿using System;

namespace Iceoz.Mvc.Grid
{
    public interface IGridPager
    {
        Int32 TotalRows { get; }
        Int32 TotalPages { get; }
        Int32 CurrentPage { get; }
        Int32 InitialPage { get; set; }
        Int32 FirstDisplayPage { get; }
        Int32 RowsPerPage { get; set; }
        Int32 PagesToDisplay { get; set; }

        String CssClasses { get; set; }
        String PartialViewName { get; set; }
    }

    public interface IGridPager<T> : IGridProcessor<T>, IGridPager
    {
        IGrid<T> Grid { get; }
    }
}
