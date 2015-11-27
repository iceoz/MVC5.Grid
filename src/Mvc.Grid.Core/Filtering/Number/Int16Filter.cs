using System;

namespace Iceoz.Mvc.Grid
{
    public class Int16Filter : NumberFilter
    {
        public override Object GetNumericValue()
        {
            Int16 number;
            if (Int16.TryParse(Value, out number))
                return number;

            return null;
        }
    }
}
