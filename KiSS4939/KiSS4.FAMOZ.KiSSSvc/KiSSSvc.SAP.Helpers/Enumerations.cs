using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.Helpers
{
	[CodeFormat(4)]
	public enum AD_TITLE
	{
		Frau = 1,
		Herr = 2,
		Firma = 3,
		HerrUndFrau = 4
	}

	[CodeFormat(1)]
	public enum BU_BPCATEGORY
	{
		/// <summary>0001</summary>
		NatuerlichePerson = 1,

		/// <summary>0002</summary>
		Organisation = 2,

		/// <summary>0003</summary>
		Gruppe = 3
	}

	[CodeFormat(2)]
	public enum BU_BPGROUP
	{
		/// <summary>10</summary>
		Personen = 10,

		/// <summary>16</summary>
		BehördlicheDebitoren = 16,

		/// <summary>50</summary>
		Organisationen = 50
	}

	[CodeFormat(4)]
	public enum BU_BPTYPE
	{
		/// <summary>0001</summary>
		Personen = 1,

		/// <summary>0002</summary>
		Organisationen = 2,

		/// <summary>0003</summary>
		BehördlicheDebitoren = 3
	}

	[CodeFormat(2)]
	public enum BU_CTRACCTYPE
	{
		/// <summary>01</summary>
		Personen = 1,

		/// <summary>02</summary>
		Organisationen = 2,

		/// <summary>03</summary>
		BehördlicheDebitoren = 3
	}

	[CodeFormat(4)]
	public enum BU_GROUP
	{
		Person = 2
	}
	[CodeFormat(4)]
	public enum BU_BPKIND
	{
		Person = 1
	}

	[CodeFormat(1)]
	public enum BU_SEX
	{
		Weiblich = 1,
		Männlich = 2
	}
//   ALBV= Alimentenbevorschussung
//ALVM= Alimentenvermittlung
//KKBB= Kleinkinderbetreuungsbeiträge
//WSH1= Wirtschaftliche Hilfe

	//[CodeFormatText]
	//public enum Language
	//{
	//    /// <summary>Deutsch</summary>
	//    DE,

	//    /// <summary>Englisch</summary>
	//    EN,

	//    /// <summary>Französisch</summary>
	//    FR,

	//    /// <summary>Italienisch</summary>
	//    IT,	

	//    /// <summary>Serbisch</summary>
	//    SR,

	//    /// <summary>Chinesisch</summary>
	//    ZH,

	//    /// <summary>Thailändisch</summary>
	//    TH,

	//    /// <summary>Koreanisch</summary>
	//    KO,

	//    /// <summary>Rumänisch</summary>
	//    RO,

	//    /// <summary>Slowenisch</summary>
	//    SL,

	//    /// <summary>Kroatisch</summary>
	//    HR,	

	//    /// <summary>Malaysisch</summary>
	//    MS,

	//    /// <summary>Ukrainisch</summary>
	//    UK,

	//    /// <summary>Estnisch</summary>
	//    ET,

	//   /// <summary>Arabisch</summary>
	//    AR,

	//    /// <summary>Hebräisch</summary>
	//    HE,

	//    /// <summary>Tschechisch</summary>
	//    CS,

	//    /// <summary>Griechisch</summary>
	//    EL,

	//    /// <summary>Ungarisch</summary>
	//    HU,

	//    /// <summary>Japanisch</summary>
	//    JA,

	//    /// <summary>Dänisch</summary>
	//    DA,

	//    /// <summary>Polnisch</summary>
	//    PL,

	//    /// <summary>Chinesisch trad.</summary>
	//    ZF,

	//    /// <summary>Niederländisch</summary>
	//    NL,

	//    /// <summary>Norwegisch</summary>
	//    NO,

	//    /// <summary>Portugiesisch</summary>
	//    PT,

	//    /// <summary>Slowakisch</summary>
	//    SK,

	//    /// <summary>Russisch</summary>
	//    RU,

	//    /// <summary>Spanisch</summary>
	//    ES,

	//    /// <summary>Türkisch</summary>
	//    TR,

	//    /// <summary>Finnisch</summary>
	//    FI,

	//    /// <summary>Schwedisch</summary>
	//    SV,

	//    /// <summary>Bulgarisch</summary>
	//    BG,

	//    /// <summary>Litauisch</summary>
	//    LT,

	//    /// <summary>Lettisch</summary>
	//    LV,

	//    /// <summary>Kundenreserve</summary>
	//    Z1,	

	//    /// <summary>Afrikaans</summary>
	//    AF,

	//    /// <summary>Isländisch</summary>
	//    IS,

	//    /// <summary>Katalanisch</summary>
	//    CA,

	//    /// <summary>Serbisch(latein)</summary>
	//    SH,

	//    /// <summary>Indonesisch</summary>
	//    ID	
	//}

	[CodeFormatText]
	public enum Language
	{
		/// <summary>Deutsch</summary>
		DE,

		/// <summary>Englisch</summary>
		EN,

		/// <summary>Französisch</summary>
		FR,

		/// <summary>Italienisch</summary>
		IT,

		/// <summary>Serbisch</summary>
		SR,

		/// <summary>Chinesisch</summary>
		ZH,

		/// <summary>Thailändisch</summary>
		TH,

		/// <summary>Koreanisch</summary>
		KO,

		/// <summary>Rumänisch</summary>
		RO,

		/// <summary>Slowenisch</summary>
		SL,

		/// <summary>Kroatisch</summary>
		HR,

		/// <summary>Malaysisch</summary>
		MS,

		/// <summary>Ukrainisch</summary>
		UK,

		/// <summary>Estnisch</summary>
		ET,

		/// <summary>Arabisch</summary>
		AR,

		/// <summary>Hebräisch</summary>
		HE,

		/// <summary>Tschechisch</summary>
		CS,

		/// <summary>Griechisch</summary>
		EL,

		/// <summary>Ungarisch</summary>
		HU,

		/// <summary>Japanisch</summary>
		JA,

		/// <summary>Dänisch</summary>
		DA,

		/// <summary>Polnisch</summary>
		PL,

		/// <summary>Chinesisch trad.</summary>
		ZF,

		/// <summary>Niederländisch</summary>
		NL,

		/// <summary>Norwegisch</summary>
		NO,

		/// <summary>Portugiesisch</summary>
		PT,

		/// <summary>Slowakisch</summary>
		SK,

		/// <summary>Russisch</summary>
		RU,

		/// <summary>Spanisch</summary>
		ES,

		/// <summary>Türkisch</summary>
		TR,

		/// <summary>Finnisch</summary>
		FI,

		/// <summary>Schwedisch</summary>
		SV,

		/// <summary>Bulgarisch</summary>
		BG,

		/// <summary>Litauisch</summary>
		LT,

		/// <summary>Lettisch</summary>
		LV,

		/// <summary>Kundenreserve</summary>
		Z1,

		/// <summary>Afrikaans</summary>
		AF,

		/// <summary>Isländisch</summary>
		IS,

		/// <summary>Katalanisch</summary>
		CA,

		/// <summary>Serbisch(latein)</summary>
		SH,

		/// <summary>Indonesisch</summary>
		ID
	}

	[CodeFormatText]
	public enum Country
	{
		/// <summary>Andorra</summary>
		AD,

		/// <summary>Vereinigte Arabische Emirate</summary>
		AE,

		/// <summary>Afghanistan</summary>
		AF,

		/// <summary>Antigua/Barbuda</summary>
		AG,

		/// <summary>Anguilla</summary>
		AI,

		/// <summary>Albanien</summary>
		AL,

		/// <summary>Armenien</summary>
		AM,

		/// <summary>Niederl.Antill.</summary>
		AN,

		/// <summary>Angola</summary>
		AO,

		/// <summary>Antarktis</summary>
		AQ,

		/// <summary>Argentinien</summary>
		AR,

		/// <summary>Samoa, Amerikan</summary>
		AS,

		/// <summary>Österreich</summary>
		AT,

		/// <summary>Australien</summary>
		AU,

		/// <summary>Aruba</summary>
		AW,

		/// <summary>Aserbaidschan</summary>
		AZ,

		/// <summary>Bangladesch</summary>
		BD,

		/// <summary>Belgien</summary>
		BE,

		/// <summary>Burkina-Faso</summary>
		BF,

		/// <summary>Bulgarien</summary>
		BG,

		/// <summary>Bahrain</summary>
		BH,

		/// <summary>Burundi</summary>
		BI,

		/// <summary>Benin</summary>
		BJ,

		/// <summary>Blue</summary>
		BL,

		/// <summary>Bermuda</summary>
		BM,

		/// <summary>Brunei Drussal.</summary>
		BN,

		/// <summary>Bolivien</summary>
		BO,

		/// <summary>Brasilien</summary>
		BR,

		/// <summary>Bahamas</summary>
		BS,

		/// <summary>Bhutan</summary>
		BT,

		/// <summary>Bouvet Inseln</summary>
		BV,

		/// <summary>Botsuana</summary>
		BW,

		/// <summary>Weissrussland</summary>
		BY,

		/// <summary>Belize</summary>
		BZ,

		/// <summary>Kanada</summary>
		CA,

		/// <summary>Kokosinseln</summary>
		CC,

		/// <summary>Republik Kongo</summary>
		CD,

		/// <summary>Zentralaf. Rep.</summary>
		CF,

		/// <summary>Kongo</summary>
		CG,

		/// <summary>Schweiz</summary>
		CH,

		/// <summary>Elfenbeinküste</summary>
		CI,

		/// <summary>Cookinseln</summary>
		CK,

		/// <summary>Chile</summary>
		CL,

		/// <summary>Kamerun</summary>
		CM,

		/// <summary>China</summary>
		CN,

		/// <summary>Kolumbien</summary>
		CO,

		/// <summary>Costa Rica</summary>
		CR,

		/// <summary>Serbien/Monten.</summary>
		CS,

		/// <summary>Kuba</summary>
		CU,

		/// <summary>Kap Verde</summary>
		CV,

		/// <summary>Weihnachtsinsel</summary>
		CX,

		/// <summary>Zypern</summary>
		CY,

		/// <summary>Tschechische Republik</summary>
		CZ,

		/// <summary>Deutschland</summary>
		DE,

		/// <summary>Dschibuti</summary>
		DJ,

		/// <summary>Dänemark</summary>
		DK,

		/// <summary>Dominica</summary>
		DM,

		/// <summary>Dominik. Republik</summary>
		DO,

		/// <summary>Algerien</summary>
		DZ,

		/// <summary>Ecuador</summary>
		EC,

		/// <summary>Estland</summary>
		EE,

		/// <summary>Ägypten</summary>
		EG,

		/// <summary>West Sahara</summary>
		EH,

		/// <summary>Eritrea</summary>
		ER,

		/// <summary>Spanien</summary>
		ES,

		/// <summary>Äthiopien</summary>
		ET,

		/// <summary>Europäische Union</summary>
		EU,

		/// <summary>Finnland</summary>
		FI,

		/// <summary>Fidschi</summary>
		FJ,

		/// <summary>Falklandinseln</summary>
		FK,

		/// <summary>Mikronesien</summary>
		FM,

		/// <summary>Färöer</summary>
		FO,

		/// <summary>Frankreich</summary>
		FR,

		/// <summary>Gabun</summary>
		GA,

		/// <summary>Verein. Königr.</summary>
		GB,

		/// <summary>Grenada</summary>
		GD,

		/// <summary>Georgien</summary>
		GE,

		/// <summary>Französ.Guayana</summary>
		GF,

		/// <summary>Ghana</summary>
		GH,

		/// <summary>Gibraltar</summary>
		GI,

		/// <summary>Grönland</summary>
		GL,

		/// <summary>Gambia</summary>
		GM,

		/// <summary>Guinea</summary>
		GN,

		/// <summary>Guadeloupe</summary>
		GP,

		/// <summary>Äquatorialguine</summary>
		GQ,

		/// <summary>Griechenland</summary>
		GR,

		/// <summary>S. Sandwich Ins</summary>
		GS,

		/// <summary>Guatemala</summary>
		GT,

		/// <summary>Guam</summary>
		GU,

		/// <summary>Guinea-Bissau</summary>
		GW
	}
}
