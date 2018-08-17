using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS.Common.Test
{
    [TestClass]
    public class FormattedMessageTest
    {
        #region Test Methods

        /// <remarks>eigentlich sollte der Logger geprüft werden</remarks>
        [TestMethod]
        public void Test_NonExistingPlaceholderShouldBeIgnored()
        {
            const string msgText = "hello {bla}!";
            FormattedMessage msg = new FormattedMessage(msgText).Replace("gugus", 123);
            string s = msg;
            Assert.AreEqual(msgText, s);
        }

        [TestMethod]
        public void Test_ReplacePlaceholder()
        {
            const string msgText = "hello {bla}!";
            FormattedMessage msg = new FormattedMessage(msgText).Replace("bla", "world");
            string s = msg;
            Assert.AreEqual("hello world!", s);
        }

        [TestMethod]
        public void Test_ReplaceThePropertyName()
        {
            string msgText = string.Format("the {{{0}}} is wrong", FormattedMessage.PropertyName);
            FormattedMessage msg = new FormattedMessage(msgText).SetPropertyName("age");
            string s = msg;
            Assert.AreEqual("the age is wrong", s);
        }

        #endregion
    }
}