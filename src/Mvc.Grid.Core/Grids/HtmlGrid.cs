using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace TCEPR.Mvc.Grid
{
    public class HtmlGrid<T> : IHtmlGrid<T>
    {
        public IGrid<T> Grid { get; set; }
        public HtmlHelper Html { get; set; }
        public String PartialViewName { get; set; }
        public string PartialViewNameMinified { get; set; }

        public HtmlGrid(HtmlHelper html, IGrid<T> grid)
        {
            grid.Query = grid.Query ?? new NameValueCollection(html.ViewContext.HttpContext.Request.QueryString);
            grid.HttpContext = grid.HttpContext ?? html.ViewContext.HttpContext;
            PartialViewName = "MvcGrid/_Grid";
            PartialViewNameMinified = "MvcGrid/_GridMinified";
            Html = html;
            Grid = grid;
        }

        public virtual IHtmlGrid<T> Build(Action<IGridColumns<T>> builder)
        {
            builder(Grid.Columns);

            return this;
        }
        public virtual IHtmlGrid<T> ProcessWith(IGridProcessor<T> processor)
        {
            Grid.Processors.Add(processor);

            return this;
        }

        public virtual IHtmlGrid<T> Filterable(Boolean isFilterable)
        {
            foreach (IGridColumn column in Grid.Columns)
                if (column.IsFilterable == null)
                    column.IsFilterable = isFilterable;

            return this;
        }
        public virtual IHtmlGrid<T> MultiFilterable()
        {
            foreach (IGridColumn column in Grid.Columns)
                if (column.IsMultiFilterable == null)
                    column.IsMultiFilterable = true;

            return this;
        }
        public virtual IHtmlGrid<T> Filterable()
        {
            return Filterable(true);
        }

        public virtual IHtmlGrid<T> Sortable(Boolean isSortable)
        {
            foreach (IGridColumn column in Grid.Columns)
                if (column.IsSortable == null)
                    column.IsSortable = isSortable;

            return this;
        }
        public virtual IHtmlGrid<T> Sortable()
        {
            return Sortable(true);
        }

        public virtual IHtmlGrid<T> RowCss(Func<T, String> cssClasses)
        {
            Grid.Rows.CssClasses = cssClasses;

            return this;
        }
        public virtual IHtmlGrid<T> Css(String cssClasses)
        {
            Grid.CssClasses = cssClasses;

            return this;
        }
        public IHtmlGrid<T> ColumnEmpty(string text)
        {
            Grid.ColumnEmptyText = text;

            return this;
        }
        public virtual IHtmlGrid<T> Empty(String text)
        {
            Grid.EmptyText = text;

            return this;
        }
        public virtual IHtmlGrid<T> Named(String name)
        {
            Grid.Name = name;

            return this;
        }
        public virtual IHtmlGrid<T> Pageable(Action<IGridPager<T>> builder)
        {
            Grid.Pager = Grid.Pager ?? new GridPager<T>(Grid);
            builder(Grid.Pager);

            if (!Grid.Processors.Contains(Grid.Pager))
                Grid.Processors.Add(Grid.Pager);

            return this;
        }
        public virtual IHtmlGrid<T> Pageable()
        {
            return Pageable(builder => { });
        }

        public virtual String ToHtmlString()
        {
            return Html.Partial(Grid.IsMinified ? PartialViewNameMinified : PartialViewName, Grid).ToHtmlString();
        }
        public IHtmlGrid<T> AjaxUrl(String actionName, String controllerName)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName, controllerName);

            return this;
        }
        public IHtmlGrid<T> AjaxUrl(String actionName)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName);

            return this;
        }
        public IHtmlGrid<T> AjaxUrl(string controllerName, string actionName, RouteValueDictionary routeValues)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName, controllerName, routeValues);

            return this;
        }
        public IHtmlGrid<T> AjaxUrl(string controllerName, string actionName, object routeValues)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName, controllerName, routeValues);

            return this;
        }
        public IHtmlGrid<T> AjaxUrl(string actionName, RouteValueDictionary routeValues)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName, routeValues);

            return this;
        }
        public IHtmlGrid<T> AjaxUrl(string actionName, object routeValues)
        {
            Grid.AjaxUrl = new UrlHelper(Html.ViewContext.RequestContext).Action(actionName, routeValues);

            return this;
        }

        public IHtmlGrid<T> LoadingText(string text)
        {
            Grid.LoadingText = text;

            return this;
        }

        public IHtmlGrid<T> LoadingGif(string url)
        {
            Grid.LoadingGif = new UrlHelper(Html.ViewContext.RequestContext).Content(url);

            return this;
        }


        public IHtmlGrid<T> SkipGridProcess(bool skipProcess)
        {
            Grid.SkipProcess = skipProcess;

            return this;
        }


        public IHtmlGrid<T> SkipGridProcess(bool skipProcess, int totalRows)
        {
            Grid.SkipProcess = skipProcess;

            if (Grid.Pager != null)
                Grid.Pager.TotalRows = totalRows;

            return this;
        }        
    }
}
