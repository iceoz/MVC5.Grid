using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TCEPR.Mvc.Grid
{
    public abstract class BaseGridColumn<T, TValue> : IGridColumn<T>
    {
        public String Name { get; set; }
        public String Title { get; set; }
        public String Format { get; set; }
        public String CssClasses { get; set; }
        public Boolean IsEncoded { get; set; }
        public String GroupTitle { get; set; }
        public String Tooltip { get; set; }
        public String GroupTooltip { get; set; }
        public String StyleInline { get; set; }
        public Boolean IsVisible { get; set; }
        public Boolean IsMinified { get; set; }

        public Boolean? IsSortable { get; set; }
        public GridSortOrder? FirstSortOrder { get; set; }
        public GridSortOrder? InitialSortOrder { get; set; }
        public virtual GridSortOrder? SortOrder { get; set; }

        public String FilterName { get; set; }
        public Boolean? IsFilterable { get; set; }
        public Boolean? IsMultiFilterable { get; set; }
        public virtual IGridColumnFilter<T> Filter { get; set; }
        IGridColumnFilter IFilterableColumn.Filter { get { return Filter; } }

        public IGrid<T> Grid { get; set; }
        public Func<T, Object> RenderValue { get; set; }
        public Func<T, Object> CssClassesValue { get; set; }
        public Func<T, Object> StyleInlineValue { get; set; }
        public GridProcessorType ProcessorType { get; set; }
        public Func<T, TValue> ExpressionValue { get; set; }
        public Expression<Func<T, TValue>> Expression { get; set; }
        LambdaExpression IGridColumn<T>.Expression { get { return Expression; } }

        public virtual IGridColumn<T> RenderedAs(Func<T, Object> value)
        {
            RenderValue = value;

            return this;
        }

        public virtual IGridColumn<T> MultiFilterable(Boolean isMultiple)
        {
            IsMultiFilterable = isMultiple;

            return this;
        }
        public virtual IGridColumn<T> Filterable(Boolean isFilterable)
        {
            IsFilterable = isFilterable;

            return this;
        }
        public virtual IGridColumn<T> FilteredAs(String filterName)
        {
            FilterName = filterName;

            return this;
        }

        public virtual IGridColumn<T> InitialSort(GridSortOrder order)
        {
            InitialSortOrder = order;

            return this;
        }

        public virtual IGridColumn<T> InitialSort(GridSortOrder order, bool executeSort)
        {
            if (executeSort)
            {
                InitialSortOrder = order;
            }

            return this;
        }

        public virtual IGridColumn<T> FirstSort(GridSortOrder order)
        {
            FirstSortOrder = order;

            return this;
        }

        public virtual IGridColumn<T> FirstSort(GridSortOrder order, bool executeSort)
        {
            if (executeSort)
            {
                FirstSortOrder = order;
            }

            return this;
        }

        public virtual IGridColumn<T> Sortable(Boolean isSortable)
        {
            IsSortable = isSortable;

            return this;
        }

        public virtual IGridColumn<T> Encoded(Boolean isEncoded)
        {
            IsEncoded = isEncoded;

            return this;
        }
        public virtual IGridColumn<T> Formatted(String format)
        {
            Format = format;

            return this;
        }
        public virtual IGridColumn<T> Css(String cssClasses)
        {
            CssClasses = cssClasses;

            return this;
        }
        public virtual IGridColumn<T> Css(Func<T, Object> cssClasses)
        {
            CssClassesValue = cssClasses;

            return this;
        }
        public virtual IGridColumn<T> Titled(String title)
        {
            Title = title;

            return this;
        }
        public virtual IGridColumn<T> Named(String name)
        {
            Name = name;

            return this;
        }

        public abstract IQueryable<T> Process(IQueryable<T> items);
        public abstract IHtmlString ValueFor(IGridRow row);
        public abstract String CssClassesFor(IGridRow row);
        public abstract String StyleInlineFor(IGridRow row);


        public virtual IGridColumn<T> GroupTitled(string groupTitle)
        {
            GroupTitle = groupTitle;

            return this;
        }


        public virtual IGridColumn<T> Tooltiped(string tooltip)
        {
            Tooltip = tooltip;

            return this;
        }

        public virtual IGridColumn<T> InlineStyled(string styleInline)
        {
            StyleInline = styleInline;

            return this;
        }

        public virtual IGridColumn<T> InlineStyled(Func<T, Object> styleInline)
        {
            StyleInlineValue = styleInline;

            return this;
        }

        public virtual IGridColumn<T> Visible(bool isVisible)
        {
            IsVisible = isVisible;

            return this;
        }

        public virtual IGridColumn<T> GroupTooltiped(string tooltip)
        {
            GroupTooltip = tooltip;

            return this;
        }


        public virtual IGridColumn<T> Minified(bool isMinified)
        {
            IsMinified = isMinified;
            Grid.IsMinified = true;

            return this;
        }
        
    }
}
