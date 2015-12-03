﻿using System;
using System.Linq;
using Xunit;

namespace TCEPR.Mvc.Grid.Tests.Unit
{
    public class GridTests
    {
        #region Property: IGrid.Columns

        [Fact]
        public void IGridColumns_ReturnsColumns()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            IGridColumns actual = ((IGrid)grid).Columns;
            IGridColumns expected = grid.Columns;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Property: IGrid.Rows

        [Fact]
        public void IGridRows_ReturnsRows()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            IGridRows actual = ((IGrid)grid).Rows;
            IGridRows expected = grid.Rows;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Property: IGrid.Pager

        [Fact]
        public void IGridPager_ReturnsPager()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            IGridPager actual = ((IGrid)grid).Pager;
            IGridPager expected = grid.Pager;

            Assert.Same(expected, actual);
        }

        #endregion

        #region Constructor: Grid(IEnumerable<T> source)

        [Fact]
        public void Grid_CreatesEmptyProcessorsList()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            Assert.Empty(grid.Processors);
        }

        [Fact]
        public void Grid_SetsSource()
        {
            IQueryable<GridModel> expected = new GridModel[2].AsQueryable();
            IQueryable<GridModel> actual = new Grid<GridModel>(expected).Source;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Grid_SetsName()
        {
            String actual = new Grid<GridModel>(new GridModel[0]).Name;
            String expected = "Grid";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Grid_CreatesColumns()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            GridColumns<GridModel> actual = grid.Columns as GridColumns<GridModel>;
            GridColumns<GridModel> expected = new GridColumns<GridModel>(grid);

            Assert.Equal(expected, actual);
            Assert.Same(expected.Grid, actual.Grid);
        }

        [Fact]
        public void Grid_CreatesRows()
        {
            Grid<GridModel> grid = new Grid<GridModel>(new GridModel[0]);

            GridRows<GridModel> actual = grid.Rows as GridRows<GridModel>;
            GridRows<GridModel> expected = new GridRows<GridModel>(grid);

            Assert.Equal(expected, actual);
            Assert.Same(expected.Grid, actual.Grid);
        }

        #endregion
    }
}
