using System;
using System.Collections.Generic;

namespace TCEPR.Mvc.Grid
{
    public interface IGridPager
    {
        Int32 TotalRows { get; set; }
        Int32 TotalPages { get; }
        Int32 CurrentPage { get; }
        Int32 InitialPage { get; set; }
        Int32 FirstDisplayPage { get; }
        Int32 CurrentRowsPerPage { get; }
        Int32 RowsPerPage { get; set; }
        Int32 PagesToDisplay { get; set; }
        IList<Int32> RowsPerPageOptions { get; set; }
        Boolean ShowPageTextInput { get; set; }

        String CssClasses { get; set; }
        String PartialViewName { get; set; }

        dynamic GridSource { get; set; }
    }

    public interface IGridPager<T> : IGridProcessor<T>, IGridPager
    {
        IGrid<T> Grid { get; }
    }
}
