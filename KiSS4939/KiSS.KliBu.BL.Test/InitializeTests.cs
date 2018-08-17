using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS4.DB;

namespace KiSS.KliBu.BL.Test
{
    [TestClass]
    public class InitializeTests
    {
        #region Methods

        #region Public Static Methods

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Session.Close();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Setup session (für DBUtil-Methoden)

            var env = new Env(".: KiSS_BSS_Test (bisrv1029/schinti) :.", EnvType.Dev, "server=sql2014.diartislocal.local\\sql2014;initial catalog=KiSS_BSS_Test;user id=kiss3;password=kiss2012;");

            // do login with given values
            Session.Open(env, "diag_admin", "");

            // check if success
            Assert.IsTrue(Session.Active, "Unable to connect to the DB.");
        }

        #endregion

        #endregion
    }
}