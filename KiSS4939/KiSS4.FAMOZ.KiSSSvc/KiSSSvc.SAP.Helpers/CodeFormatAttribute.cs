using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.Helpers
{
    /// <summary>
    /// An attribute to specify the format of an enumeration to be passed
    /// to SAP. Used by SAPHelper.
    /// </summary>
    public class CodeFormatAttribute : Attribute
    {
        private string _formattingString;

        public string FormattingString
        {
            get { return _formattingString; }
            set { _formattingString = value; }
        }
        public CodeFormatAttribute(uint numberOfDecimal)
        {
            _formattingString = "D" + numberOfDecimal;
        }
        public CodeFormatAttribute(string formattingString)
        {
            _formattingString = formattingString;
        }
    }
}
