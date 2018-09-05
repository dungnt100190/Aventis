using System;
using System.Collections.Generic;
using System.Linq;
using Kiss4Web.Infrastructure;
using Shouldly;

namespace Kiss4Web.TestInfrastructure
{
    public static class ShouldExtensionMethods
    {
        public static void ShouldBePartially<T>(this IList<T> actualList,
                                                     IList<T> expectedList,
                                                     IEnumerable<string> propertyNamesToCompare)
        {
            actualList.Count.ShouldBe(expectedList.Count);
            propertyNamesToCompare = propertyNamesToCompare.Select(pn => pn.NormalizeAsKey()).ToList();
            var propertiesToCheck = typeof(T).GetProperties().Where(prp => propertyNamesToCompare.Contains(prp.Name.NormalizeAsKey())).ToList();
            for (var i = 0; i < actualList.Count; i++)
            {
                var actual = actualList[i];
                var expected = expectedList[i];

                foreach (var property in propertiesToCheck)
                {
                    var actualValue = property.GetValue(actual);
                    var expectedValue = property.GetValue(expected);

                    actualValue.ShouldBe(expectedValue, $"{property.Name} should be {expectedValue}, but was {actualValue}");
                }
            }
        }

        /// <summary>
        /// SQL Server stores datetime with a precision of 3-4ms, it uses .xx0, .xx3, .xx4 <see cref="https://docs.microsoft.com/en-us/sql/t-sql/data-types/datetime-transact-sql#rounding-of-datetime-fractional-second-precision"/>
        /// Assertion must respect this
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public static void ShouldBeWithSqlDateTimePrecision(this DateTime actual, DateTime expected)
        {
            actual.ShouldBe(expected, TimeSpan.FromMilliseconds(5));
        }
    }
}