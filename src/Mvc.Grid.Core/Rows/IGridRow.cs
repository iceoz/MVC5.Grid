using System;

namespace Iceoz.Mvc.Grid
{
    public interface IGridRow
    {
        Object Model { get; }
        String CssClasses { get; set; }
    }
}
