using System;
using KiSSSvc.SAP.Helpers;

//using KiSSSvc.SAP.PSCD.BusinessPartner;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.ZKBDokumente;
using NUnit.Framework;

//using KiSSSvc.Common.Settings;

namespace KiSSSvc.Test.UnitTest
{
    /// <summary>
    /// Summary description for Test_03_ZKBDokumente.
    /// </summary>
    [TestFixture]
    public class Test_03_ZKBDokumente
    {
        public Test_03_ZKBDokumente()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [Test]
        public void ImportiereZKBDokumente()
        {
            ZKBDokumente.ZKBDokumente.ImportiereZKBDokumente(null);
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Console.Out.WriteLine("Test_03_ZKBDokumente: Init");
            WebServiceHelperMethods.GetSettings().PSCDUseMock = true;
            //WebServiceHelper.GetSettings().Proxy = "http://localhost:81";
        }
    }
}