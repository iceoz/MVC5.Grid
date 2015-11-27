﻿using NSubstitute;
using System;
using Xunit;

namespace Iceoz.Mvc.Grid.Tests.Unit
{
    public class BaseGridColumnTests
    {
        private BaseGridColumn<GridModel, String> column;

        public BaseGridColumnTests()
        {
            column = Substitute.ForPartsOf<BaseGridColumn<GridModel, String>>();
        }

        #region Property: IGridColumn<T>.Expression

        [Fact]
        public void IGridColumnExpression_ReturnsExpression()
        {
            IGridColumn<GridModel> gridColumn = column;

            Object actual = gridColumn.Expression;
            Object expected = column.Expression;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Property: IFilterableColumn.Filter

        [Fact]
        public void IFilterableColumnFilter_ReturnsFilter()
        {
            IFilterableColumn filterableColumn = column;

            Object actual = filterableColumn.Filter;
            Object expected = column.Filter;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: RenderedAs(Func<T, Object> value)

        [Fact]
        public void RenderedAs_SetsRenderValue()
        {
            Func<GridModel, Object> expected = (model) => model.Name;
            Func<GridModel, Object> actual = (column.RenderedAs(expected) as BaseGridColumn<GridModel, String>).RenderValue;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void RenderedAs_ReturnsSameColumn()
        {
            IGridColumn actual = column.RenderedAs(model => model.Name);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: MultiFilterable(Boolean isMultiple)

        [Fact]
        public void MultiFilterable_SetsIsMultiFilterable()
        {
            Boolean? actual = column.MultiFilterable(true).IsMultiFilterable;
            Boolean? expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiFilterable_ReturnsSameGrid()
        {
            IGridColumn actual = column.MultiFilterable(true);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Filterable(Boolean isFilterable)

        [Fact]
        public void Filterable_SetsIsFilterable()
        {
            Boolean? actual = column.Filterable(true).IsFilterable;
            Boolean? expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Filterable_ReturnsSameGrid()
        {
            IGridColumn actual = column.Filterable(true);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: FilteredAs(String filterName)

        [Fact]
        public void FilteredAs_SetsFilterName()
        {
            String actual = column.FilteredAs("Numeric").FilterName;
            String expected = "Numeric";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilteredAs_ReturnsSameGrid()
        {
            IGridColumn actual = column.FilteredAs("Numeric");
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: InitialSort(GridSortOrder order)

        [Fact]
        public void InitialSort_SetsInitialSortOrder()
        {
            GridSortOrder? actual = column.InitialSort(GridSortOrder.Desc).InitialSortOrder;
            GridSortOrder? expected = GridSortOrder.Desc;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitialSort_ReturnsSameGrid()
        {
            IGridColumn actual = column.InitialSort(GridSortOrder.Desc);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: FirstSort(GridSortOrder order)

        [Fact]
        public void FirstSort_SetsFirstSortOrder()
        {
            GridSortOrder? actual = column.FirstSort(GridSortOrder.Desc).FirstSortOrder;
            GridSortOrder? expected = GridSortOrder.Desc;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstSort_ReturnsSameGrid()
        {
            IGridColumn actual = column.FirstSort(GridSortOrder.Desc);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Sortable(Boolean isSortable)

        [Fact]
        public void Sortable_SetsIsSortable()
        {
            Boolean? actual = column.Sortable(true).IsSortable;
            Boolean? expected = true;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sortable_ReturnsSameGrid()
        {
            IGridColumn actual = column.Sortable(true);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Encoded(Boolean isEncoded)

        [Fact]
        public void Encoded_SetsIsEncoded()
        {
            Assert.True(column.Encoded(true).IsEncoded);
        }

        [Fact]
        public void Encoded_ReturnsSameGrid()
        {
            IGridColumn actual = column.Encoded(true);
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Formatted(String format)

        [Fact]
        public void Formatted_SetsFormat()
        {
            String actual = column.Formatted("Format").Format;
            String expected = "Format";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Formatted_ReturnsSameGrid()
        {
            IGridColumn actual = column.Formatted("Format");
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Css(String cssClasses)

        [Fact]
        public void Css_SetsCssClasses()
        {
            String actual = column.Css("column-class").CssClasses;
            String expected = "column-class";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Css_ReturnsSameGrid()
        {
            IGridColumn actual = column.Css("column-class");
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Titled(String title)

        [Fact]
        public void Titled_SetsTitle()
        {
            String actual = column.Titled("Title").Title;
            String expected = "Title";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Titled_ReturnsSameGrid()
        {
            IGridColumn actual = column.Titled("Title");
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Method: Named(String name)

        [Fact]
        public void Named_SetsName()
        {
            String actual = column.Named("Name").Name;
            String expected = "Name";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Named_ReturnsSameGrid()
        {
            IGridColumn actual = column.Named("Name");
            IGridColumn expected = column;

            Assert.Same(expected, actual);
        }

        #endregion
    }
}
