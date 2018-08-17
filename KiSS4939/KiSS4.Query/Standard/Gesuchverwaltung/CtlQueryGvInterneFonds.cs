using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryGvInterneFonds : CtlQueryGvFondsBase
    {
        public CtlQueryGvInterneFonds()
        {
            InitializeComponent();

            kissSearch.SelectParameters = new object[]
            {
                false, // 1) ExternInterner Fonds (false = interne Fonds)
                Session.User.LanguageCode // 2) Sprachcode des Benutzers
            };
        }
    }
}