using System;
using System.Collections.Generic;
using System.Linq;

namespace TCEPR.Mvc.Grid
{
    public class GridPager<T> : IGridPager<T>
    {
        public IGrid<T> Grid { get; set; }

        public Int32 TotalRows { get; set; }
        public Int32 InitialPage { get; set; }
        public Int32 RowsPerPage { get; set; }
        public Int32 PagesToDisplay { get; set; }
        public Boolean ShowPageTextInput { get; set; }

        public virtual Int32 TotalPages
        {
            get
            {
                return (Int32)(Math.Ceiling(TotalRows / (Double)CurrentRowsPerPage));
            }
        }
        public virtual Int32 CurrentPage
        {
            get
            {
                if (CurrentPageIsSet)
                    return CurrentPageValue;

                String key = Grid.Name + "-Page";
                String value = Grid.Query[key];
                Int32 page;

                if (Int32.TryParse(value, out page))
                    CurrentPageValue = page;
                else
                    CurrentPageValue = InitialPage;

                CurrentPageValue = CurrentPageValue > TotalPages ? TotalPages : CurrentPageValue;
                CurrentPageValue = CurrentPageValue <= 0 ? 1 : CurrentPageValue;
                CurrentPageIsSet = true;

                return CurrentPageValue;
            }
        }

        public virtual Int32 CurrentRowsPerPage
        {
            get
            {
                if (CurrentRowsPerPageIsSet)
                    return CurrentRowsPerPageValue;
                                
                String key = Grid.Name + "-RowsPerPage";
                String value = Grid.Query[key];
                Int32 rowsPerPage;

                if (Int32.TryParse(value, out rowsPerPage))
                    CurrentRowsPerPageValue = rowsPerPage;
                else
                    CurrentRowsPerPageValue = RowsPerPage;

                CurrentRowsPerPageIsSet = true;

                if (RowsPerPageOptions.Count == 0)
                {
                    if (CurrentRowsPerPageValue == RowsPerPage)
                        RowsPerPageOptions = new List<Int32>() { CurrentRowsPerPageValue };
                    else
                        RowsPerPageOptions = new List<Int32>() { CurrentRowsPerPageValue, RowsPerPage };
                }
                
                if (!RowsPerPageOptions.Contains(CurrentRowsPerPageValue))
                {
                    RowsPerPageOptions.Add(CurrentRowsPerPageValue);                    
                }

                if (!RowsPerPageOptions.Contains(RowsPerPage))
                {
                    RowsPerPageOptions.Add(RowsPerPage);
                }

                RowsPerPageOptions = RowsPerPageOptions.OrderBy(x => x).ToList();

                return CurrentRowsPerPageValue;
            }
        }

        public virtual Int32 FirstDisplayPage
        {
            get
            {
                Int32 middlePage = (PagesToDisplay / 2) + (PagesToDisplay % 2);
                if (CurrentPage < middlePage)
                    return 1;

                if (CurrentPage - middlePage + PagesToDisplay > TotalPages)
                    return Math.Max(TotalPages - PagesToDisplay + 1, 1);

                return CurrentPage - middlePage + 1;
            }
        }
        private Int32 CurrentPageValue { get; set; }
        private Boolean CurrentPageIsSet { get; set; }

        private Int32 CurrentRowsPerPageValue { get; set; }
        private Boolean CurrentRowsPerPageIsSet { get; set; }

        public String CssClasses { get; set; }
        public String PartialViewName { get; set; }
        public GridProcessorType ProcessorType { get; set; }

        public dynamic GridSource { get; set; }
        

        public GridPager(IGrid<T> grid)
        {
            Grid = grid;
            GridSource = Grid.Source;
            InitialPage = 1;
            RowsPerPage = 20;
            PagesToDisplay = 5;
            PartialViewName = "MvcGrid/_Pager";
            ProcessorType = GridProcessorType.Post;
            RowsPerPageOptions = new List<Int32>();
        }

        public virtual IQueryable<T> Process(IQueryable<T> items)
        {
            if(Grid.SkipProcess)
                return items;

            TotalRows = items.Count();

            return items.Skip((CurrentPage - 1) * CurrentRowsPerPage).Take(CurrentRowsPerPage);
        }

        public IList<int> RowsPerPageOptions { get; set; }
    }
}
