using System;

namespace Kiss.Infrastructure.Utils
{
    public static class ScaleHelper
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Calculates the width for one day on a scale.
        /// </summary>
        /// <param name="canvasWidth">Width of the whole scale.</param>
        /// <param name="rangeBegin">The minimum date.</param>
        /// <param name="rangeEnd">The maximum date.</param>
        public static double CalculateDayWidth(double canvasWidth, DateTime rangeBegin, DateTime rangeEnd)
        {
            return CalculateDayWidth(canvasWidth, new TimePeriod(rangeBegin, rangeEnd));
        }

        /// <summary>
        /// Calculates the width for one day on a scale.
        /// </summary>
        /// <param name="canvasWidth">Width of the whole scale.</param>
        /// <param name="range">The range of dates that cover the canvasWidth</param>
        public static double CalculateDayWidth(double canvasWidth, TimePeriod range)
        {
            var scaleTimeSpan = range.To - range.From;

            if (scaleTimeSpan.TotalDays <= 0)
            {
                return canvasWidth;
            }

            return canvasWidth / scaleTimeSpan.TotalDays;
        }


        /// <summary>
        /// Converts a date to the pixel offset to the beginning of the scale.
        /// </summary>
        /// <param name="date">Date to convert.</param>
        /// <param name="startDate">The minimum visible date.</param>
        /// <param name="dayWidth">The width of one day (Use <see cref="CalculateDayWidth"/>).</param>
        /// <returns>Offset to startDate</returns>
        public static double GetPixelOffset(DateTime date, DateTime startDate, double dayWidth)
        {
            var dayOffset = date - startDate;
            return dayOffset.TotalDays * dayWidth;
        }

        /// <summary>
        /// Converts a date to the pixel offset to the beginning of the scale.
        /// </summary>
        /// <param name="date">Date to convert.</param>
        /// <param name="startDate">The minimum visible date.</param>
        /// <param name="dayWidth">The width of one day (Use <see cref="CalculateDayWidth"/>).</param>
        /// <returns>Offset to startDate</returns>
        public static DateTime GetDateByOffset(double offset, TimePeriod totalRange, double canvasWidth)
        {
            var dayWidth = CalculateDayWidth(canvasWidth, totalRange);
            if (dayWidth < double.Epsilon)
            {
                return totalRange.From;
            }
            return totalRange.From.AddDays(offset / dayWidth);
        }
        #endregion

        #endregion
    }
}