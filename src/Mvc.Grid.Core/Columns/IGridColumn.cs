using System;
using System.Linq.Expressions;
using System.Web;

namespace TCEPR.Mvc.Grid
{
    public interface IGridColumn : IFilterableColumn, ISortableColumn
    {
        String Name { get; set; }
        String Title { get; set; }
        String Format { get; set; }
        String CssClasses { get; set; }
        Boolean IsEncoded { get; set; }
        String GroupTitle { get; set; }
        String Tooltip { get; set; }
        String GroupTooltip { get; set; }
        String StyleInline { get; set; }
        Boolean IsVisible { get; set; }        

        IHtmlString ValueFor(IGridRow row);
        String CssClassesFor(IGridRow row);
        String StyleInlineFor(IGridRow row);

        Boolean IsMinified { get; set; }
    }

    public interface IGridColumn<T> : IFilterableColumn<T>, ISortableColumn<T>, IGridColumn
    {
        IGrid<T> Grid { get; }
        LambdaExpression Expression { get; }

        IGridColumn<T> RenderedAs(Func<T, Object> value);

        IGridColumn<T> MultiFilterable(Boolean isMultiple);
        IGridColumn<T> Filterable(Boolean isFilterable);
        IGridColumn<T> FilteredAs(String filterName);

        IGridColumn<T> InitialSort(GridSortOrder order);
        IGridColumn<T> InitialSort(GridSortOrder order, bool executeSort);
        IGridColumn<T> FirstSort(GridSortOrder order);
        IGridColumn<T> FirstSort(GridSortOrder order, bool executeSort);
        IGridColumn<T> Sortable(Boolean isSortable);

        IGridColumn<T> Encoded(Boolean isEncoded);
        IGridColumn<T> Formatted(String format);
        IGridColumn<T> Css(String cssClasses);
        IGridColumn<T> Css(Func<T, Object> cssClasses);
        IGridColumn<T> Titled(String title);
        IGridColumn<T> Named(String name);
        IGridColumn<T> GroupTitled(String groupTitle);
        IGridColumn<T> Tooltiped(String tooltip);
        IGridColumn<T> GroupTooltiped(String tooltip);
        IGridColumn<T> InlineStyled(String styleInline);
        IGridColumn<T> InlineStyled(Func<T, Object> styleInline);
        IGridColumn<T> Visible(bool isVisible);
        IGridColumn<T> Minified(bool isMinified);
    }
}
