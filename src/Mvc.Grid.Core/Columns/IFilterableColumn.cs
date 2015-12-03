using System;

namespace TCEPR.Mvc.Grid
{
    public interface IFilterableColumn
    {
        String FilterName { get; set; }
        IGridColumnFilter Filter { get; }
        Boolean? IsFilterable { get; set; }
        Boolean? IsMultiFilterable { get; set; }
    }
    public interface IFilterableColumn<T> : IFilterableColumn, IGridProcessor<T>
    {
        new IGridColumnFilter<T> Filter { get; set; }
    }
}
