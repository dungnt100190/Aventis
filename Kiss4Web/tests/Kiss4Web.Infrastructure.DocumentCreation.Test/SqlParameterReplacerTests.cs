using Shouldly;
using Xunit;

namespace Kiss4Web.Infrastructure.DocumentCreation.Test
{
    public class SqlParameterReplacerTests
    {
        [Fact]
        public void ReplaceParameters()
        {
            // Arrange
            var replacer = new SqlParameterReplacer();

            // Act
            var result = replacer.ReformatParametersFromKissToDapper("SELECT <TableColumn> FROM dbo.vwTmFaAktennotizen WHERE FaAktennotizID = {FaAktennotizID}");

            // Assert
            result.parameterNames.ShouldBe(new[] { "FaAktennotizID" });
            result.sql.ShouldBe("SELECT <TableColumn> FROM dbo.vwTmFaAktennotizen WHERE FaAktennotizID = @FaAktennotizID");
        }
    }
}