﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Iceoz.Mvc.Grid
{
    public class Grid<T> : IGrid<T> where T : class
    {
        public String Name { get; set; }
        public String EmptyText { get; set; }
        public string ColumnEmptyText { get; set; }
        public String CssClasses { get; set; }

        private String _AjaxUrl { get; set; }
        public String AjaxUrl
        {
            get
            {
                return _AjaxUrl;
            }
            set
            {
                _AjaxUrl = value;
                IsAjaxUrlSetted = !(String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value));
            }
        }
        public bool IsAjaxUrlSetted { get; private set; }

        public string LoadingText { get; set; }
        public string LoadingIconUrl { get; set; }

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

            Columns = new GridColumns<T>(this);
            Rows = new GridRows<T>(this);
        }        
    }
}
