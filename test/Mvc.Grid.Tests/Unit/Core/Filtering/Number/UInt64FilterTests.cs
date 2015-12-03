﻿using System;
using Xunit;

namespace TCEPR.Mvc.Grid.Tests.Unit
{
    public class UInt64FilterTests
    {
        #region Method: GetNumericValue()

        [Fact]
        public void GetNumericValue_ParsesValue()
        {
            UInt64Filter filter = new UInt64Filter();
            filter.Value = "18446744073709551615";

            Object actual = filter.GetNumericValue();
            UInt64 expected = 18446744073709551615;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_OnNotValidValueReturnsNull()
        {
            UInt64Filter filter = new UInt64Filter();
            filter.Value = "-1";

            Assert.Null(filter.GetNumericValue());
        }

        #endregion
    }
}
