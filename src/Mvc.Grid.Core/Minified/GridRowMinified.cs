using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCEPR.Mvc.Grid
{
    public class GridRowMinified
    {
        public string CssClasses { get; set; }
        public string Name { get; set; }
        public int DataIndex { get; set; }
        public int DataColor { get; set; }
        public IList<GridColumnMinified> Columns { get; set; }
    }
}
