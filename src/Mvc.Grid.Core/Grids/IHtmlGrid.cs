﻿using System;
using System.Web;

namespace TCEPR.Mvc.Grid
{
    public interface IHtmlGrid<T> : IHtmlString
    {
        IGrid<T> Grid { get; }
        String PartialViewName { get; set; }
        
        IHtmlGrid<T> Build(Action<IGridColumns<T>> builder);
        IHtmlGrid<T> ProcessWith(IGridProcessor<T> processor);

        IHtmlGrid<T> Filterable(Boolean isFilterable);
        IHtmlGrid<T> MultiFilterable();
        IHtmlGrid<T> Filterable();

        IHtmlGrid<T> Sortable(Boolean isSortable);
        IHtmlGrid<T> Sortable();

        IHtmlGrid<T> RowCss(Func<T, String> cssClasses);
        IHtmlGrid<T> Css(String cssClasses);
        IHtmlGrid<T> ColumnEmpty(String text);
        IHtmlGrid<T> Empty(String text);        
        IHtmlGrid<T> Named(String name);

        IHtmlGrid<T> Pageable(Action<IGridPager<T>> builder);
        IHtmlGrid<T> Pageable();

        IHtmlGrid<T> AjaxUrl(String controllerName, String actionName, object routeValues);
        IHtmlGrid<T> AjaxUrl(String controllerName, String actionName);
        IHtmlGrid<T> AjaxUrl(String actionName, object routeValues);        
        IHtmlGrid<T> AjaxUrl(String actionName);

        IHtmlGrid<T> LoadingText(String html);
        IHtmlGrid<T> LoadingGif(String url);
    }
}
