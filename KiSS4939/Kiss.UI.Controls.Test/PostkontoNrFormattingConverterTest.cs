using System.Windows.Data;

using Kiss.UI.Controls.Converter;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.UI.Controls.Test
{
    [TestClass]
    public class PostkontoNrFormattingConverterTest
    {
        [TestMethod]
        public void TestPostkontoUnformatiert_ConvertSingle()
        {
            // Arrange
            IValueConverter valueConverter = new PostkontoNrFormattingConverter();

            // Tests
            string unformattiert_nopadding = "503183160";
            string unformattiert_padding1 = "500103842";
            string unformattiert_padding2 = "500018783";
            string unformattiert_padding3 = "500002557";
            string unformattiert_padding4 = "500000698";
            string unformattiert_padding5 = "800000022";

            string unformattiert_teilnehmer5stellig = "47612";

            string expected_nopadding = "50-318316-0";
            string expected_padding1 = "50-10384-2";
            string expected_padding2 = "50-1878-3";
            string expected_padding3 = "50-255-7";
            string expected_padding4 = "50-69-8";
            string expected_padding5 = "80-2-2";

            string expected_teilnehmer5stellig = "47612";

            var result = valueConverter.Convert(unformattiert_nopadding, typeof(string), null, null);
            Assert.AreEqual(expected_nopadding, result);

            result = valueConverter.Convert(unformattiert_padding1, typeof(string), null, null);
            Assert.AreEqual(expected_padding1, result);

            result = valueConverter.Convert(unformattiert_padding2, typeof(string), null, null);
            Assert.AreEqual(expected_padding2, result);

            result = valueConverter.Convert(unformattiert_padding3, typeof(string), null, null);
            Assert.AreEqual(expected_padding3, result);

            result = valueConverter.Convert(unformattiert_padding4, typeof(string), null, null);
            Assert.AreEqual(expected_padding4, result);

            result = valueConverter.Convert(unformattiert_padding5, typeof(string), null, null);
            Assert.AreEqual(expected_padding5, result);

            result = valueConverter.Convert(unformattiert_teilnehmer5stellig, typeof(string), null, null);
            Assert.AreEqual(expected_teilnehmer5stellig, result);
        }

        [TestMethod]
        public void TestPostkontoUnformatiert_ConvertBackSingle()
        {
            // Arrange
            IValueConverter valueConverter = new PostkontoNrFormattingConverter();

            // Tests
            string formattiert_nopadding = "50-318316-0";
            string formattiert_padding1 = "50-10384-2";
            string formattiert_padding2 = "50-1878-3";
            string formattiert_padding3 = "50-255-7";
            string formattiert_padding4 = "50-69-8";
            string formattiert_padding5 = "80-2-2";

            string formattiert_teilnehmer5stellig = "47612";

            string expected_nopadding = "503183160";
            string expected_padding1 = "500103842";
            string expected_padding2 = "500018783";
            string expected_padding3 = "500002557";
            string expected_padding4 = "500000698";
            string expected_padding5 = "800000022";

            string expected_teilnehmer5stellig = "47612";

            var result = valueConverter.ConvertBack(formattiert_nopadding, typeof(string), null, null);
            Assert.AreEqual(expected_nopadding, result);

            result = valueConverter.ConvertBack(formattiert_padding1, typeof(string), null, null);
            Assert.AreEqual(expected_padding1, result);

            result = valueConverter.ConvertBack(formattiert_padding2, typeof(string), null, null);
            Assert.AreEqual(expected_padding2, result);

            result = valueConverter.ConvertBack(formattiert_padding3, typeof(string), null, null);
            Assert.AreEqual(expected_padding3, result);

            result = valueConverter.ConvertBack(formattiert_padding4, typeof(string), null, null);
            Assert.AreEqual(expected_padding4, result);

            result = valueConverter.ConvertBack(formattiert_padding5, typeof(string), null, null);
            Assert.AreEqual(expected_padding5, result);

            result = valueConverter.ConvertBack(formattiert_teilnehmer5stellig, typeof(string), null, null);
            Assert.AreEqual(expected_teilnehmer5stellig, result);
        }

        [TestMethod]
        public void TestPostkontoUnformatiert_ConvertMulti_OnlyPostkonto()
        {
            // Arrange
            IMultiValueConverter valueConverter = new PostkontoNrFormattingConverter();

            // Tests
            string unformattiert_nopadding = "503183160";
            string unformattiert_padding1 = "500103842";
            string unformattiert_padding2 = "500018783";
            string unformattiert_padding3 = "500002557";
            string unformattiert_padding4 = "500000698";
            string unformattiert_padding5 = "800000022";

            string unformattiert_teilnehmer5stellig = "47612";

            string expected_nopadding = "50-318316-0";
            string expected_padding1 = "50-10384-2";
            string expected_padding2 = "50-1878-3";
            string expected_padding3 = "50-255-7";
            string expected_padding4 = "50-69-8";
            string expected_padding5 = "80-2-2";

            string expected_teilnehmer5stellig = "47612";

            var result = valueConverter.Convert(new object[]{ unformattiert_nopadding, null }, typeof(string), null, null);
            Assert.AreEqual(expected_nopadding, result);

            result = valueConverter.Convert(new object[]{ unformattiert_padding1, null }, typeof(string), null, null);
            Assert.AreEqual(expected_padding1, result);

            result = valueConverter.Convert(new object[]{ unformattiert_padding2, null }, typeof(string), null, null);
            Assert.AreEqual(expected_padding2, result);

            result = valueConverter.Convert(new object[]{ unformattiert_padding3, null }, typeof(string), null, null);
            Assert.AreEqual(expected_padding3, result);

            result = valueConverter.Convert(new object[]{ unformattiert_padding4, null }, typeof(string), null, null);
            Assert.AreEqual(expected_padding4, result);

            result = valueConverter.Convert(new object[]{ unformattiert_padding5, null }, typeof(string), null, null);
            Assert.AreEqual(expected_padding5, result);

            result = valueConverter.Convert(new object[] { unformattiert_teilnehmer5stellig, null }, typeof(string), null, null);
            Assert.AreEqual(expected_teilnehmer5stellig, result);
        }

        [TestMethod]
        public void TestPostkontoUnformatiert_ConvertMulti_OnlyBankkonto()
        {
            // Arrange
            IMultiValueConverter valueConverter = new PostkontoNrFormattingConverter();

            // Tests
            string unformattiert_bank1 = "01.430.597.250";
            string unformattiert_bank2 = "0120328/003.000.001";
            string unformattiert_bank3 = "0202-100897.40M";

            var result = valueConverter.Convert(new object[] { null, unformattiert_bank1, null }, typeof(string), null, null);
            Assert.AreEqual(unformattiert_bank1, result); //resultat soll unverändert sein

            result = valueConverter.Convert(new object[] { unformattiert_bank2, null }, typeof(string), null, null);
            Assert.AreEqual(unformattiert_bank2, result); //resultat soll unverändert sein

            result = valueConverter.Convert(new object[] { unformattiert_bank3, null }, typeof(string), null, null);
            Assert.AreEqual(unformattiert_bank3, result); //resultat soll unverändert sein
        }

        [TestMethod]
        public void TestPostkontoUnformatiert_ConvertMulti_PostkontoAndBankkonto()
        {
            // Arrange
            IMultiValueConverter valueConverter = new PostkontoNrFormattingConverter();

            // Tests
            string unformattiert_nopadding = "503183160";
            string unformattiert_padding1 = "500103842";
            string unformattiert_padding2 = "500018783";
            string unformattiert_padding3 = "500002557";
            string unformattiert_padding4 = "500000698";
            string unformattiert_padding5 = "800000022";

            string unformattiert_teilnehmer5stellig = "47612";

            string unformattiert_bank1 = "01.430.597.250";
            string unformattiert_bank2 = "0120328/003.000.001";
            string unformattiert_bank3 = "0202-100897.40M";

            string expected_nopadding = "50-318316-0";
            string expected_padding1 = "50-10384-2";
            string expected_padding2 = "50-1878-3";
            string expected_padding3 = "50-255-7";
            string expected_padding4 = "50-69-8";
            string expected_padding5 = "80-2-2";

            string expected_teilnehmer5stellig = "47612";

            var result = valueConverter.Convert(new object[] { unformattiert_nopadding, unformattiert_bank1 }, typeof(string), null, null);
            Assert.AreEqual(expected_nopadding, result);

            result = valueConverter.Convert(new object[] { unformattiert_padding1, unformattiert_bank2 }, typeof(string), null, null);
            Assert.AreEqual(expected_padding1, result);

            result = valueConverter.Convert(new object[] { unformattiert_padding2, unformattiert_bank3 }, typeof(string), null, null);
            Assert.AreEqual(expected_padding2, result);

            result = valueConverter.Convert(new object[] { unformattiert_padding3, unformattiert_bank1 }, typeof(string), null, null);
            Assert.AreEqual(expected_padding3, result);

            result = valueConverter.Convert(new object[] { unformattiert_padding4, unformattiert_bank2 }, typeof(string), null, null);
            Assert.AreEqual(expected_padding4, result);

            result = valueConverter.Convert(new object[] { unformattiert_padding5, unformattiert_bank3 }, typeof(string), null, null);
            Assert.AreEqual(expected_padding5, result);

            result = valueConverter.Convert(new object[] { unformattiert_teilnehmer5stellig, unformattiert_bank1 }, typeof(string), null, null);
            Assert.AreEqual(expected_teilnehmer5stellig, result);
        }

    }
}