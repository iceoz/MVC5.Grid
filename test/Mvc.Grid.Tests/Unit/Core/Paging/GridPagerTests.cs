﻿using NSubstitute;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Extensions;

namespace TCEPR.Mvc.Grid.Tests.Unit
{
    public class GridPagerTests
    {
        private GridPager<GridModel> pager;
        private IGrid<GridModel> grid;

        public GridPagerTests()
        {
            grid = Substitute.For<IGrid<GridModel>>();
            grid.Query = new NameValueCollection();
            grid.Name = "Grid";

            pager = new GridPager<GridModel>(grid);
        }

        #region Property: FirstDisplayPage

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 3)]
        [InlineData(1, 4, 4)]
        [InlineData(1, 5, 5)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(2, 4, 4)]
        [InlineData(2, 5, 4)]
        [InlineData(3, 1, 1)]
        [InlineData(3, 2, 1)]
        [InlineData(3, 3, 2)]
        [InlineData(3, 4, 3)]
        [InlineData(3, 5, 3)]
        [InlineData(4, 1, 1)]
        [InlineData(4, 2, 1)]
        [InlineData(4, 3, 2)]
        [InlineData(4, 4, 2)]
        [InlineData(4, 5, 2)]
        [InlineData(5, 1, 1)]
        [InlineData(5, 2, 1)]
        [InlineData(5, 3, 1)]
        [InlineData(5, 4, 1)]
        [InlineData(5, 5, 1)]
        [InlineData(6, 1, 1)]
        [InlineData(6, 2, 1)]
        [InlineData(6, 3, 1)]
        [InlineData(6, 4, 1)]
        [InlineData(6, 5, 1)]
        public void FirstDisplayPage_GetsFirstDisplayPage(Int32 pagesToDisplay, Int32 currentPage, Int32 expected)
        {
            pager.Grid.Query = HttpUtility.ParseQueryString("Grid-Page=" + currentPage);
            pager.PagesToDisplay = pagesToDisplay;
            pager.RowsPerPage = 1;
            pager.TotalRows = 5;

            Int32 actual = pager.FirstDisplayPage;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Property: CurrentPage

        [Theory]
        [InlineData("Grid-Page=", 2, 2)]
        [InlineData("Grid-Page=3", 5, 3)]
        public void CurrentPage_DoesNotChangeCurrentPageAfterFirstGet(String query, Int32 initialPage, Int32 expected)
        {
            pager.Grid.Query = HttpUtility.ParseQueryString(query);
            pager.InitialPage = initialPage;
            pager.TotalRows = 500;

            Int32 value = pager.CurrentPage;

            pager.Grid.Query = HttpUtility.ParseQueryString("Grid-Page=5");

            Int32 actual = pager.CurrentPage;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", 3)]
        [InlineData("Grid-Page=", 3)]
        [InlineData("Grid-Page=2a", 3)]
        public void CurrentPage_OnInvalidQueryPageUsesInitialPage(String query, Int32 initialPage)
        {
            pager.Grid.Query = HttpUtility.ParseQueryString(query);
            pager.InitialPage = initialPage;
            pager.TotalRows = 500;

            Int32 actual = pager.CurrentPage;
            Int32 expected = initialPage;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrentPage_OnGreaterThanTotalPagesReturnsTotalPages()
        {
            pager.Grid.Query = HttpUtility.ParseQueryString("Grid-Page=5");
            pager.TotalRows = 4 * pager.RowsPerPage;

            Int32 actual = pager.CurrentPage;
            Int32 expected = 4;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Grid-Page=0")]
        [InlineData("Grid-Page=-1")]
        public void CurrentPage_OnLessOrEqualToZeroQueryPageReturnsOne(String query)
        {
            pager.Grid.Query = HttpUtility.ParseQueryString(query);
            pager.InitialPage = 5;

            Int32 actual = pager.CurrentPage;
            Int32 expected = 1;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CurrentPage_OnLessOrEqualToZeroInitialPageReturnsOne(Int32 initialPage)
        {
            pager.Grid.Query = new NameValueCollection();
            pager.InitialPage = initialPage;

            Int32 actual = pager.CurrentPage;
            Int32 expected = 1;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Property: TotalPages

        [Theory]
        [InlineData(0, 20, 0)]
        [InlineData(1, 20, 1)]
        [InlineData(19, 20, 1)]
        [InlineData(20, 20, 1)]
        [InlineData(21, 20, 2)]
        [InlineData(39, 20, 2)]
        [InlineData(40, 20, 2)]
        [InlineData(41, 20, 3)]
        public void TotalPages_GetsTotalPages(Int32 totalRows, Int32 rowsPerPage, Int32 expected)
        {
            GridPager<GridModel> pager = new GridPager<GridModel>(grid);
            pager.RowsPerPage = rowsPerPage;
            pager.TotalRows = totalRows;

            Int32 actual = pager.TotalPages;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Constructor: GridPager(IGrid<T> grid)

        [Fact]
        public void GridPager_SetsGrid()
        {
            IGrid actual = new GridPager<GridModel>(grid).Grid;
            IGrid expected = grid;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void GridPager_SetsInitialPage()
        {
            Int32 actual = new GridPager<GridModel>(grid).InitialPage;
            Int32 expected = 1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GridPager_SetsRowsPerPage()
        {
            Int32 actual = new GridPager<GridModel>(grid).RowsPerPage;
            Int32 expected = 20;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GridPager_SetsPagesToDisplay()
        {
            Int32 actual = new GridPager<GridModel>(grid).PagesToDisplay;
            Int32 expected = 5;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GridPager_SetsDefaultPartialViewName()
        {
            String actual = new GridPager<GridModel>(grid).PartialViewName;
            String expected = "MvcGrid/_Pager";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GridPager_SetsProcessorTypeAsPostProcessor()
        {
            GridProcessorType actual = new GridPager<GridModel>(grid).ProcessorType;
            GridProcessorType expected = GridProcessorType.Post;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Method: Process(IQueryable<T> items)

        [Fact]
        public void Process_SetsTotalRows()
        {
            pager.Process(new GridModel[100].AsQueryable());

            Int32 actual = pager.TotalRows;
            Int32 expected = 100;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Process_ReturnsPagedItems()
        {
            IQueryable<GridModel> items = new[] { new GridModel(), new GridModel(), new GridModel() }.AsQueryable();
            pager.Grid.Query = HttpUtility.ParseQueryString("Grid-Page=2");
            pager.RowsPerPage = 1;

            IEnumerable expected = items.Skip(1).Take(1);
            IEnumerable actual = pager.Process(items);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
