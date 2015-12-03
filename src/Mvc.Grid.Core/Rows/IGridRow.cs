using System;

namespace TCEPR.Mvc.Grid
{
    public interface IGridRow
    {
        Object Model { get; }
        String CssClasses { get; set; }
    }
}
