
using System;

using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test
{
    [TestClass]
    public class EnumExtensionsTest
    {
        [TestMethod]
        public void TestEnumLocalization()
        {
            // Act
            var localizedString = FaZeitachseDTOType.Falluebergabe.ToStringLocalized();

            // Assert
            Assert.AreEqual(Properties.Resources.FaZeitachseDTOType_Falluebergabe, localizedString);
        }

        [TestMethod]
        public void TestLookupDictionary()
        {
            // Act
            var dict = EnumExtensions.GetLookupDirectory<FaZeitachseDTOType>();

            // Assert
            Assert.AreEqual(Enum.GetValues(typeof(FaZeitachseDTOType)).Length, dict.Count);
            Assert.AreEqual(Properties.Resources.FaZeitachseDTOType_PendenzenOffen, dict[FaZeitachseDTOType.PendenzenOffen]);
            Assert.AreEqual(Properties.Resources.FaZeitachseDTOType_PendenzenErledigt, dict[FaZeitachseDTOType.PendenzenErledigt]);
            Assert.AreEqual(Properties.Resources.FaZeitachseDTOType_Korrespondenz, dict[FaZeitachseDTOType.Korrespondenz]);
            Assert.AreEqual(Properties.Resources.FaZeitachseDTOType_Falluebergabe, dict[FaZeitachseDTOType.Falluebergabe]);
        }
    }
}
