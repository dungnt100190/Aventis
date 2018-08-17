namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XDocument"/> entity at build time.
    /// </summary>
    internal class XDocumentBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XDocument
            {
                FaDokumentAblage = new FaDokumentAblage[] { },
                FaDokumente = new FaDokumente[] { },
                FaWeisung = new FaWeisung[] { },
                FaWeisung_Mahnung1 = new FaWeisung[] { },
                FaWeisung_Mahnung2 = new FaWeisung[] { },
                FaWeisung_Mahnung3 = new FaWeisung[] { },
                FaWeisung_Verfuegung = new FaWeisung[] { }
            };
        }
    }
}