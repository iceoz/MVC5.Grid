using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCEPR.Mvc.Grid
{
    public class GridColumnMinified
    {
        public string CssClasses { get; set; }
        public string StyleInline { get; set; }
        public int Rowspan { get; set; }
        public string Value { get; set; }
        public bool Visible { get; set; }
        public bool IsMinified { get; set; }
    }
}
