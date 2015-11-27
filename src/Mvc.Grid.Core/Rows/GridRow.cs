using System;

namespace Iceoz.Mvc.Grid
{
    public class GridRow : IGridRow
    {
        public Object Model { get; set; }
        public String CssClasses { get; set; }

        public GridRow(Object model)
        {
            Model = model;
        }
    }
}
