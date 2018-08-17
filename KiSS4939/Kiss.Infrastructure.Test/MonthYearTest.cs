using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.Infrastructure.Test
{
    [TestClass]
    public class MonthYearTest
    {
        #region Test Methods

        [TestMethod]
        public void Test_AdditionOverOneYear()
        {
            // Arrange
            var monthYear = new MonthYear(2010, 11);

            // Act
            monthYear += 12;

            // Assert
            Assert.AreEqual(monthYear.Year, 2011);
            Assert.AreEqual(monthYear.Month, 11);
        }

        [TestMethod]
        public void Test_AdditionOverOneYearAndOneMonth()
        {
            // Arrange
            var monthYear = new MonthYear(2010, 11);

            // Act
            monthYear += 13;

            // Assert
            Assert.AreEqual(monthYear.Year, 2011);
            Assert.AreEqual(monthYear.Month, 12);
        }

        [TestMethod]
        public void Test_AdditionOverOneYearMinusOneMonth()
        {
            // Arrange
            var monthYear = new MonthYear(2010, 11);

            // Act
            monthYear += 11;

            // Assert
            Assert.AreEqual(monthYear.Year, 2011);
            Assert.AreEqual(monthYear.Month, 10);
        }

        [TestMethod]
        public void Test_AdditionOverYear()
        {
            // Arrange
            var monthYear = new MonthYear(2034, 8);

            // Act
            monthYear += 41;

            // Assert
            Assert.AreEqual(monthYear.Year, 2038);
            Assert.AreEqual(monthYear.Month, 1);
        }

        [TestMethod]
        public void Test_Addition_ToDecember()
        {
            // Arrange
            var monthYear = new MonthYear(1957, 3);

            // Act
            monthYear += 9;

            // Assert
            Assert.AreEqual(monthYear.Year, 1957);
            Assert.AreEqual(monthYear.Month, 12);
        }

        [TestMethod]
        public void Test_CurrentMonth()
        {
            // Arrange
            // Act
            var currentMonth = MonthYear.CurrentMonth;
            var today = DateTime.Today;

            // Assert
            Assert.AreEqual(currentMonth.Year, today.Year);
            Assert.AreEqual(currentMonth.Month, today.Month);
        }

        [TestMethod]
        public void Test_Decrement()
        {
            // Arrange
            var monthYear = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);

            // Act
            monthYear--;
            monthYear--;

            // Assert
            var expectedMonth = DateTime.Today.AddMonths(-2);
            Assert.AreEqual(expectedMonth.Year, monthYear.Year);
            Assert.AreEqual(expectedMonth.Month, monthYear.Month);
        }

        [TestMethod]
        public void Test_Equals()
        {
            // Arrange
            var lhs = new MonthYear(2087, 8);
            var rhs = new MonthYear(2087, 8);

            // Act
            bool equals = (lhs == rhs);

            // Assert
            Assert.AreEqual(true, equals);
        }

        [TestMethod]
        public void Test_GetMonthList()
        {
            // Arrange
            // Act
            var from = DateTime.Today.AddMonths(-57);
            var to = DateTime.Today.AddMonths(43);
            var list = MonthYear.GetMonthList(new MonthYear(from.Year, from.Month), new MonthYear(to.Year, to.Month));

            // Assert
            Assert.AreEqual(101, list.Count);
            for (var i = 0; i < 101; i++)
            {
                var expectedMonth = from.AddMonths(i);
                Assert.AreEqual(expectedMonth.Year, list[i].Year);
                Assert.AreEqual(expectedMonth.Month, list[i].Month);
            }
        }

        [TestMethod]
        public void Test_GreaterThan()
        {
            // Arrange
            var lhs = new MonthYear(2087, 8);
            var rhs = new MonthYear(1976, 8);

            // Act
            bool greaterThan = (lhs > rhs);

            // Assert
            Assert.AreEqual(true, greaterThan);
        }

        [TestMethod]
        public void Test_Increment()
        {
            // Arrange
            var my = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);

            // Act
            my++;

            // Assert
            DateTime expectedMonth = DateTime.Today.AddMonths(1);
            Assert.AreEqual(expectedMonth.Year, my.Year);
            Assert.AreEqual(expectedMonth.Month, my.Month);
        }

        [TestMethod]
        public void Test_LowerThan()
        {
            // Arrange
            var lhs = new MonthYear(2087, 8);
            var rhs = new MonthYear(1976, 8);

            // Act
            bool lowerThan = (lhs < rhs);

            // Assert
            Assert.AreEqual(false, lowerThan);
        }

        [TestMethod]
        public void Test_NotEquals()
        {
            // Arrange
            var lhs = new MonthYear(2087, 8);
            var rhs = new MonthYear(1976, 8);

            // Act
            bool notEquals = (lhs != rhs);

            // Assert
            Assert.AreEqual(true, notEquals);
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            // Arrange
            var monthYear = new MonthYear(2034, 8);

            // Act
            monthYear -= 5;

            // Assert
            Assert.AreEqual(monthYear.Year, 2034);
            Assert.AreEqual(monthYear.Month, 3);
        }

        [TestMethod]
        public void Test_SubtractionOverYear()
        {
            // Arrange
            var monthYear = new MonthYear(2034, 8);

            // Act
            monthYear -= 35;

            // Assert
            Assert.AreEqual(monthYear.Year, 2031);
            Assert.AreEqual(monthYear.Month, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InvalidMonth()
        {
            new MonthYear(2306, 13);
        }

        [TestMethod]
        public void Test_GetMonthDiff()
        {
            // Act
            var monthDiff = MonthYear.GetSpanningMonthCount(new MonthYear(2012, 4), new MonthYear(2012, 6));

            //Assert
            Assert.AreEqual(3, monthDiff);
        }

        [TestMethod]
        public void Test_GetMonthDiffOverYear()
        {
            // Act
            var monthDiff = MonthYear.GetSpanningMonthCount(new MonthYear(2012, 4), new MonthYear(2013, 2));

            //Assert
            Assert.AreEqual(11, monthDiff);
        }

        [TestMethod]
        public void Test_GetMonthDiffNegative()
        {
            // Act
            var monthDiff = MonthYear.GetSpanningMonthCount(new MonthYear(2012, 4), new MonthYear(2011, 2));

            //Assert
            Assert.AreEqual(-13, monthDiff);
        }


        #endregion
    }
}