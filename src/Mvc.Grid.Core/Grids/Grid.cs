using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace TCEPR.Mvc.Grid
{
    public class Grid<T> : IGrid<T> where T : class
    {
        public String Name { get; set; }
        public String EmptyText { get; set; }
        public string ColumnEmptyText { get; set; }
        public String CssClasses { get; set; }
        public String AjaxUrl { get; set; }

        public string LoadingText { get; set; }
        public string LoadingGif { get; set; }
        public bool SkipProcess { get; set; }
        public bool IsMinified { get; set; }
        public string TagMinified { get; private set; }

        public IQueryable<T> Source { get; set; }
        public NameValueCollection Query { get; set; }
        public HttpContextBase HttpContext { get; set; }
        public IList<IGridProcessor<T>> Processors { get; set; }

        public IGridColumns<T> Columns { get; set; }
        IGridColumns IGrid.Columns { get { return Columns; } }

        public IGridRows<T> Rows { get; set; }
        IGridRows IGrid.Rows { get { return Rows; } }

        public IGridPager<T> Pager { get; set; }
        IGridPager IGrid.Pager { get { return Pager; } }

        public Grid(IEnumerable<T> source)
        {
            Processors = new List<IGridProcessor<T>>();
            Source = source.AsQueryable();

            Name = "Grid";

            TagMinified = "<<compress>>";

            Columns = new GridColumns<T>(this);
            Rows = new GridRows<T>(this);
        }
    }
}
