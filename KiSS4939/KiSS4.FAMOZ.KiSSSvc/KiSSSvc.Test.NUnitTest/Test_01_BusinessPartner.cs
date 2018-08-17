using System;
using NUnit.Framework;
//using KiSSSvc.SAP.PSCD.BusinessPartner;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
//using KiSSSvc.Common.Settings;

namespace KiSSSvc.Test.UnitTest
{
	/// <summary>
	/// Summary description for Test_01_BusinessPartner.
	/// </summary>
	[TestFixture]
	public class Test_01_BusinessPartner
	{
		public Test_01_BusinessPartner()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[TestFixtureSetUp]
		public void Init()
		{
			Console.Out.WriteLine("Test_01_BusinessPartner: Init");
			WebServiceHelperMethods.GetSettings().PSCDUseMock = true;
			//WebServiceHelper.GetSettings().Proxy = "http://localhost:81";
		}

		[Test]
		public void BusinessPartner_00_CreateBusinessPartner()
		{
			Stammdaten bps = new Stammdaten();
			//bps.CreateAndSubmitBusinessPartnerPerson(1, new UserInfo(-1, ""));//"Quasimodo", "Meyer", new DateTime( 1930, 7, 7 ), "Gloecknerstrasse", 333, "f", 1003, "Lausanne", "CH", Language.DE, "AAA333", BU_BPCATEGORY.NatuerlichePerson, BU_BPKIND.Person, BU_BPGROUP.Personen, AD_TITLE.Frau, Language.DE );
		}

		[Test]
		public void BusinessPartner_01_CreateBusinessPartnerWithSpecialChars()
		{
			Stammdaten bps = new Stammdaten();
			//bps.CreateAndSubmitBusinessPartnerPerson(1, new UserInfo(-1, ""));//"Françoise", "Müller", new DateTime(1940, 8, 8), "Rue du Rhône", 444, "z", 1204, "Genève", "CH", Language.FR, "AAA444", BU_BPCATEGORY.NatuerlichePerson, BU_BPKIND.Person, BU_BPGROUP.Personen, AD_TITLE.Frau, Language.FR);
		}
	}
}
