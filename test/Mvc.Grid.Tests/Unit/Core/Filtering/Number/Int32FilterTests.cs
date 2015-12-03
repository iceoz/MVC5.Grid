﻿using System;
using Xunit;

namespace TCEPR.Mvc.Grid.Tests.Unit
{
    public class Int32FilterTests
    {
        #region Method: GetNumericValue()

        [Fact]
        public void GetNumericValue_ParsesValue()
        {
            Int32Filter filter = new Int32Filter();
            filter.Value = "-2147483648";

            Object actual = filter.GetNumericValue();
            Int32 expected = -2147483648;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_OnNotValidValueReturnsNull()
        {
            Int32Filter filter = new Int32Filter();
            filter.Value = "1a";

            Assert.Null(filter.GetNumericValue());
        }

        #endregion
    }
}
