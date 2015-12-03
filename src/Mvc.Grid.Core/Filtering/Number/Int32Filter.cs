using System;

namespace TCEPR.Mvc.Grid
{
    public class Int32Filter : NumberFilter
    {
        public override Object GetNumericValue()
        {
            Int32 number;
            if (Int32.TryParse(Value, out number))
                return number;

            return null;
        }
    }
}
