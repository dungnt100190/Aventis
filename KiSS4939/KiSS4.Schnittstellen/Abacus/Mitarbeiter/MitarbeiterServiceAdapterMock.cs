using System;
using System.Collections.Generic;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    /// <summary>
    /// Mockomplementation mit echten Daten.
    ///
    ///
    /// </summary>
    public class MitarbeiterServiceAdapterMock
    {
        /// <summary>
        /// Mock von Mitarbeiternummer 2520 und 8850 vom Geschäftsbereich 71.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="jahr"></param>
        /// <param name="monat"></param>
        /// <param name="mitarbeiterNrs"></param>
        /// <param name="mitarbeiterNrsExisting"></param>
        /// <param name="geschaeftsbereich"></param>
        /// <returns></returns>
        public IList<MitarbeiterDTO> GetMitarbeiterDaten(string username, string pwd, int jahr, int monat, IList<int> mitarbeiterNrs, IList<int> mitarbeiterNrsExisting, int geschaeftsbereich)
        {
            IList<MitarbeiterDTO> result = new List<MitarbeiterDTO>();

            var dto = new MitarbeiterDTO();

            dto.MitarbeiterNummer = 2517;
            dto.StichJahr = jahr;
            dto.StichMonat = monat;
            dto.GeburtsDatum = new DateTime(1977, 07, 09);
            dto.Geschlecht = "M";
            dto.LanguageCodeString = "D";
            dto.LohnTyp = "S";
            dto.PlzArbeitsort = 6000;
            dto.EintrittsDatum = new DateTime(1998, 6, 15);
            //dto.AustrittsDatum = new DateTime(2013,4,4);
            dto.Name = "Abegglen";
            dto.VorName = "Thomas";
            dto.TelefonNrPrivat = "03112345678";
            dto.TelefonNrGesch = "0316332693";
            dto.TelefonNrMobil = "0792676617";
            dto.FaxNr = "03112345679";
            dto.EMail = "thomas.abegglen@diartis.ch";
            dto.Kostenstelle = 1;
            dto.Kostentraeger = 82301;
            dto.StundenAnsatz1 = 27.2f;

            dto.StrasseUndNummer = "Hauptstrasse 1";
            dto.PostfachUndNr = "Postfach 5";
            dto.Plz = "8049";
            dto.Ort = "Zürich";
            dto.Land = "CH";

            dto.Januar = 158;
            dto.Februar = 158;
            dto.Maerz = 158;
            dto.April = 158;
            dto.Mai = 158;
            dto.Juni = 158;
            dto.Juli = 158;
            dto.August = 158;
            dto.September = 158;
            dto.Oktober = 158;
            dto.November = 158;
            dto.Dezember = 158;

            dto.FibuKonto = 41003;

            dto.PlzArbeitsort = 6000;

            result.Add(dto);

            //2. Mitarbeiter
            dto = new MitarbeiterDTO();

            dto.MitarbeiterNummer = 8850;
            dto.StichJahr = jahr;
            dto.StichMonat = monat;
            dto.GeburtsDatum = new DateTime(1961, 05, 13);
            dto.Geschlecht = "M";
            dto.LanguageCodeString = "D";
            dto.LohnTyp = "S";
            dto.PlzArbeitsort = 6000;
            dto.EintrittsDatum = new DateTime(1998, 6, 15);
            //dto.AustrittsDatum = new DateTime(2013, 4, 4);
            dto.Name = "Meier";
            dto.VorName = "Fritz";
            dto.TelefonNrPrivat = "0313125874";
            dto.TelefonNrGesch = "0313125874";
            dto.TelefonNrMobil = "0786547896";
            dto.FaxNr = "0313125874";
            dto.EMail = "sdf@dfsd.ch";
            dto.Kostenstelle = 1;
            dto.Kostentraeger = 82301;
            dto.StundenAnsatz1 = 27.2f;

            dto.StrasseUndNummer = "Hauptstrasse 20";
            //dto.PostfachUndNr = "Postfach 457";
            dto.Plz = "3000";
            dto.Ort = "Bern";

            dto.Januar = 158;
            dto.Februar = 158;
            dto.Maerz = 158;
            dto.April = 158;
            dto.Mai = 158;
            dto.Juni = 158;
            dto.Juli = 158;
            dto.August = 158;
            dto.September = 158;
            dto.Oktober = 158;
            dto.November = 158;
            dto.Dezember = 158;

            dto.FibuKonto = 41003;

            dto.PlzArbeitsort = 6000;

            result.Add(dto);

            return result;
        }

        public IList<MitarbeiterDTO> GetMitarbeiterWaadt()
        {
            const string stmt = @"
SELECT
  MitarbeiterNummer = USR.MitarbeiterNr,
  StichJahr = YEAR(GETDATE()),
  StichMonat = MONTH(GETDATE()),
  Geburtsdatum = USR.Geburtstag,
  Geschlecht = USR.GenderCode, --TODO: M/F statt numerischer code
  LanguageCodeString = USR.LanguageCode, --TODO: D/F/I/E statt numerischer code
  LohnTyp = USR.LohnTypCode, --TODO: M/S statt numerischer code
  PlzArbeitsort = ORG.AdressePLZ,
  USR.Eintrittsdatum,
  USR.Austrittsdatum,
  Name = USR.Lastname,
  Vorname = USR.Firstname,
  TelefonNrPrivat = USR.PhonePrivat,
  TelefonNrGesch = USR.PhoneOffice,
  TelefonNrMobil = USR.PhoneMobile,
  FaxNr = USR.Fax,
  Email = USR.Email,
  Kostenstelle = ORG.Kostenstelle,
  Kostentraeger = USR.Kostentraeger,
  Januar    = STD.JanuarStd,
  Februar   = STD.FebruarStd,
  Maerz     = STD.MaerzStd,
  April     = STD.AprilStd,
  Mai       = STD.MaiStd,
  Juni      = STD.JuniStd,
  Juli      = STD.JuliStd,
  August    = STD.AugustStd,
  September = STD.SeptemberStd,
  Oktober   = STD.OktoberStd,
  November  = STD.NovemberStd,
  Dezember  = STD.DezemberStd,
  FibuKonto = 0, --TODO: woher kommt dieses Feld?

  AusbezahlteUeberstunden = dbo.fnBDEGetAusbezahlteUeberstunden(USR.UserID, GetDate(), 1),
  Beschaeftigungsgrad = dbo.fnBDEGetPensumPercent(USR.UserID, GetDate()),
  FerienAnspruchAnzahlStunden = dbo.fnBDEGetFerienAnspruch(USR.UserID, GetDate(), 1),
  FerienKuerzungAnzahlStunden = dbo.fnBDEGetFerienZugabenKuerzungen(USR.UserID, GetDate(), 1),
  Funktion = USR.RoleTitleCode, --TODO: string statt numerischer code
  Geschaeftsbereich = ORG.Mandantennummer,
  GueltigkeitsDatumAusbezahlteUeberstunden = GetDate(),
  GueltigkeitsDatumBeschaeftigungsgradAenderung = GetDate(),
  GueltigkeitsDatumFerienanspruchProJahr = GetDate(),
  GueltigkeitsDatumSollStundenProTag = GetDate(),
  Land = ADR.BaLandID,
  Ort = ADR.Ort,
  PLZ = ADR.PLZ,
  PlzArbeitsortSollarbeitszeit = ADR.PLZ,
  Qualifikation = USR.QualificationTitleCode,
  SollStundenProTag = dbo.fnBDEGetSollProTag(USR.UserID, GetDate()),
  StrasseUndNummer = ADR.Strasse,
  PostfachUndNummer = ADR.Postfach,
  PostfachOhneNr = ADR.PostfachOhneNr,
  StrasseZusatz = ADR.Zusatz,
  Stundenansatz1 = USA.Lohnart1,
  Stundenansatz2 = USA.Lohnart2,
  Stundenansatz3 = USA.Lohnart3,
  Stundenansatz4 = USA.Lohnart4,
  Stundenansatz11 = USA.Lohnart11,
  Stundenansatz12 = USA.Lohnart12,
  Stundenansatz13 = USA.Lohnart13,
  Stundenansatz14 = USA.Lohnart14,
  Stundenansatz15 = USA.Lohnart15,
  Stundenansatz16 = USA.Lohnart16,
  TotalJahr = 0

FROM dbo.XUser                              USR
  LEFT JOIN dbo.XUserStundenansatz          USA ON USA.UserID = USR.UserID
  LEFT JOIN dbo.BDESollStundenProJahr_XUser STD ON STD.UserID = USR.UserID AND STD.Jahr = 2009 --wir haben nur fürs 2009 Daten
  LEFT JOIN dbo.XOrgUnit_User               OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2 --2:mitglied
  LEFT JOIN dbo.XOrgUnit                    ORG ON ORG.OrgUnitID = OUU.OrgUnitID
  LEFT JOIN dbo.BaAdresse                   ADR ON ADR.UserID = USR.UserID
WHERE dbo.fnOrgUnitHierarchyValue(ORG.OrgUnitID, 'mndnr') = 231 --231: Waadt
  AND ((USR.Austrittsdatum IS NULL) OR (USR.Austrittsdatum >= dbo.fnDateSerial(Year(GetDate()), Month(GetDate()), 1)))
ORDER BY USR.MitarbeiterNr
            ";
            SqlQuery qry = DBUtil.OpenSQL(stmt);

            IList<MitarbeiterDTO> result = new List<MitarbeiterDTO>();

            while (qry.Next())
            {
                result.Add(new MitarbeiterDTO
                {
                    April = (float)Utils.ConvertToDouble(qry["April"]),
                    August = (float)Utils.ConvertToDouble(qry["August"]),
                    AusbezahlteUeberstunden = (float)Utils.ConvertToDouble(qry["AusbezahlteUeberstunden"]),
                    AustrittsDatum = Utils.ConvertToDateTime(qry["AustrittsDatum"]),
                    BeschaeftigungsGrad = (float)Utils.ConvertToDouble(qry["BeschaeftigungsGrad"]),
                    Dezember = (float)Utils.ConvertToDouble(qry["Dezember"]),
                    EintrittsDatum = Utils.ConvertToDateTime(qry["EintrittsDatum"]),
                    EMail = Utils.ConvertToString(qry["EMail"]),
                    FaxNr = Utils.ConvertToString(qry["FaxNr"]),
                    Februar = (float)Utils.ConvertToDouble(qry["Februar"]),
                    FerienAnspruchAnzahlStunden = (float)Utils.ConvertToDouble(qry["FerienAnspruchAnzahlStunden"]),
                    FerienKuerzungAnzahlStunden = (float)Utils.ConvertToDouble(qry["FerienKuerzungAnzahlStunden"]),
                    FibuKonto = Utils.ConvertToInt(qry["FibuKonto"]),
                    Funktion = Utils.ConvertToInt(qry["Funktion"]),
                    GeburtsDatum = Utils.ConvertToDateTime(qry["GeburtsDatum"]),
                    Geschaeftsbereich = Utils.ConvertToInt(qry["Geschaeftsbereich"]),
                    Geschlecht = Utils.ConvertToString(qry["Geschlecht"]),
                    GueltigkeitsDatumAusbezahlteUeberstunden = Utils.ConvertToDateTime(qry["GueltigkeitsDatumAusbezahlteUeberstunden"]),
                    GueltigkeitsDatumBeschaeftigungsgradAenderung = Utils.ConvertToDateTime(qry["GueltigkeitsDatumBeschaeftigungsgradAenderung"]),
                    GueltigkeitsDatumFerienanspruchProJahr = Utils.ConvertToDateTime(qry["GueltigkeitsDatumFerienanspruchProJahr"]),
                    GueltigkeitsDatumSollStundenProTag = Utils.ConvertToDateTime(qry["GueltigkeitsDatumSollStundenProTag"]),
                    Januar = (float)Utils.ConvertToDouble(qry["Januar"]),
                    Juli = (float)Utils.ConvertToDouble(qry["Juli"]),
                    Juni = (float)Utils.ConvertToDouble(qry["Juni"]),
                    Kostenstelle = Utils.ConvertToInt(qry["Kostenstelle"]),
                    Kostentraeger = Utils.ConvertToInt(qry["Kostentraeger"]),
                    Land = Utils.ConvertToString(qry["Land"]),
                    LanguageCodeString = Utils.ConvertToString(qry["LanguageCodeString"]),
                    LohnTyp = Utils.ConvertToString(qry["LohnTyp"]),
                    Maerz = (float)Utils.ConvertToDouble(qry["Maerz"]),
                    Mai = (float)Utils.ConvertToDouble(qry["Mai"]),
                    MitarbeiterNummer = Utils.ConvertToString(qry["MitarbeiterNummer"]) != string.Empty ? Int32.Parse(Utils.ConvertToString(qry["MitarbeiterNummer"])) : 0,
                    Name = Utils.ConvertToString(qry["Name"]),
                    November = (float)Utils.ConvertToDouble(qry["November"]),
                    Oktober = (float)Utils.ConvertToDouble(qry["Oktober"]),
                    Ort = Utils.ConvertToString(qry["Ort"]),
                    Plz = Utils.ConvertToString(qry["Plz"]),
                    PlzArbeitsort = Utils.ConvertToInt(qry["PlzArbeitsort"]),
                    PlzArbeitsortSollarbeitszeit = Utils.ConvertToInt(qry["PlzArbeitsortSollarbeitszeit"]),
                    Qualifikation = Utils.ConvertToInt(qry["Qualifikation"]),
                    September = (float)Utils.ConvertToDouble(qry["September"]),
                    SollStundenProTag = (float)Utils.ConvertToDouble(qry["SollStundenProTag"]),
                    StichJahr = Utils.ConvertToInt(qry["StichJahr"]),
                    StichMonat = Utils.ConvertToInt(qry["StichMonat"]),
                    StrasseUndNummer = Utils.ConvertToString(qry["StrasseUndNummer"]),
                    PostfachUndNr = Utils.ConvertToString(qry["PostfachUndNummer"]),
                    StrasseZusatz = Utils.ConvertToString(qry["StrasseZusatz"]),
                    StundenAnsatz1 = (float)Utils.ConvertToDouble(qry["Stundenansatz1"]),
                    StundenAnsatz2 = (float)Utils.ConvertToDouble(qry["Stundenansatz2"]),
                    StundenAnsatz3 = (float)Utils.ConvertToDouble(qry["Stundenansatz3"]),
                    StundenAnsatz4 = (float)Utils.ConvertToDouble(qry["Stundenansatz4"]),
                    StundenAnsatz11 = (float)Utils.ConvertToDouble(qry["Stundenansatz11"]),
                    StundenAnsatz12 = (float)Utils.ConvertToDouble(qry["Stundenansatz12"]),
                    StundenAnsatz13 = (float)Utils.ConvertToDouble(qry["Stundenansatz13"]),
                    StundenAnsatz14 = (float)Utils.ConvertToDouble(qry["Stundenansatz14"]),
                    StundenAnsatz15 = (float)Utils.ConvertToDouble(qry["Stundenansatz15"]),
                    StundenAnsatz16 = (float)Utils.ConvertToDouble(qry["Stundenansatz16"]),
                    TelefonNrGesch = Utils.ConvertToString(qry["TelefonNrGesch"]),
                    TelefonNrMobil = Utils.ConvertToString(qry["TelefonNrMobil"]),
                    TelefonNrPrivat = Utils.ConvertToString(qry["TelefonNrPrivat"]),
                    TotalJahr = Utils.ConvertToInt(qry["TotalJahr"]),
                    VorName = Utils.ConvertToString(qry["VorName"])
                });
            }

            return result;
        }
    }
}

/*
<DataSet Info="Now:23.01.2009 13:50:31">
    <DataTable Name="Table1">
        <Row>
            <Col Nr="0" AbaName="EMPL_NR" Type="System.Decimal">1427</Col>
            <Col Nr="1" AbaName="LPE_YEAR" Type="System.Decimal">2005</Col>
            <Col Nr="2" AbaName="LPE_MONTH" Type="System.Decimal">1</Col>
            <Col Nr="3" AbaName="EMPL_ID" Type="System.String">BERWERT MATHILDE</Col>
            <Col Nr="4" AbaName="BADGE_ID" Type="System.String">121611         </Col>
            <Col Nr="5" AbaName="BIRTHDAY" Type="System.DateTime">13.05.1961 00:00:00</Col>
            <Col Nr="6" AbaName="SEX" Type="System.String">F</Col>
            <Col Nr="7" AbaName="LANGUAGE_CODE" Type="System.String">D</Col>
            <Col Nr="8" AbaName="TYPE" Type="System.String">S</Col>
            <Col Nr="9" AbaName="NATIONAL_1" Type="System.Decimal">6000</Col>
            <Col Nr="10" AbaName="DATE_IN" Type="System.DateTime">15.06.1998 00:00:00</Col>
            <Col Nr="11" AbaName="DATE_OUT" Type="System.DBNull"></Col>
            <Col Nr="12" AbaName="NAME" Type="System.String">Berwert                                           </Col>
            <Col Nr="13" AbaName="VORNAME" Type="System.String">Mathilde                      </Col>
            <Col Nr="14" AbaName="TEL" Type="System.String">                    </Col>
            <Col Nr="15" AbaName="TEL2" Type="System.String">                    </Col>
            <Col Nr="16" AbaName="TELEX" Type="System.String">                    </Col>
            <Col Nr="17" AbaName="TELEFAX" Type="System.String">                    </Col>
            <Col Nr="18" AbaName="EMAIL" Type="System.String">  </Col>
            <Col Nr="19" AbaName="CCENTER_1" Type="System.Decimal">425</Col>
            <Col Nr="20" AbaName="PROJECT_1" Type="System.Decimal">82301</Col>
            <Col Nr="21" AbaName="GB" Type="System.Decimal">121</Col>
            <Col Nr="22" AbaName="ACCOUNT_F1" Type="System.Decimal">0</Col>
            <Col Nr="23" AbaName="ACCOUNT_A1" Type="System.Decimal">41003</Col>
            <Col Nr="24" AbaName="MUTATION_DATE" Type="System.DateTime">13.01.2009 00:00:00</Col>
            <Col Nr="25" AbaName="USER" Type="System.Decimal">2</Col>
            <Col Nr="26" AbaName="MONTH" Type="System.Decimal">1</Col>
            <Col Nr="27" AbaName="AMOUNT_3" Type="System.Decimal">0.0000</Col>
            <Col Nr="28" AbaName="AMOUNT_7" Type="System.Decimal">0.0000</Col>
            <Col Nr="29" AbaName="AMOUNT_11" Type="System.Decimal">27.2000</Col>
            <Col Nr="30" AbaName="AMOUNT_12" Type="System.Decimal">0.0000</Col>
            <Col Nr="31" AbaName="AMOUNT_13" Type="System.Decimal">0.0000</Col>
            <Col Nr="32" AbaName="AMOUNT_17" Type="System.Decimal">0.0000</Col>
            <Col Nr="33" AbaName="AMOUNT_70" Type="System.Decimal">0.0000</Col>
            <Col Nr="34" AbaName="AMOUNT_71" Type="System.Decimal">0.0000</Col>
            <Col Nr="35" AbaName="AMOUNT_72" Type="System.Decimal">0.0000</Col>
            <Col Nr="36" AbaName="AMOUNT_73" Type="System.Decimal">0.0000</Col>
            <Col Nr="37" AbaName="AMOUNT_74" Type="System.Decimal">0.0000</Col>
            <Col Nr="38" AbaName="AMOUNT_75" Type="System.Decimal">0.0000</Col>
            <Col Nr="39" AbaName="AMOUNT_76" Type="System.Decimal">0.0000</Col>
            <Col Nr="40" AbaName="AMOUNT_77" Type="System.Decimal">0.0000</Col>
            <Col Nr="41" AbaName="TABLE" Type="System.Decimal">602</Col>
            <Col Nr="42" AbaName="YEAR" Type="System.Decimal">2009</Col>
            <Col Nr="43" AbaName="VALUE_1" Type="System.Decimal">168.00</Col>
            <Col Nr="44" AbaName="VALUE_2" Type="System.Decimal">159.60</Col>
            <Col Nr="45" AbaName="VALUE_3" Type="System.Decimal">184.80</Col>
            <Col Nr="46" AbaName="VALUE_4" Type="System.Decimal">168.00</Col>
            <Col Nr="47" AbaName="VALUE_5" Type="System.Decimal">168.00</Col>
            <Col Nr="48" AbaName="VALUE_6" Type="System.Decimal">168.00</Col>
            <Col Nr="49" AbaName="VALUE_7" Type="System.Decimal">193.20</Col>
            <Col Nr="50" AbaName="VALUE_8" Type="System.Decimal">176.40</Col>
            <Col Nr="51" AbaName="VALUE_9" Type="System.Decimal">184.80</Col>
            <Col Nr="52" AbaName="VALUE_10" Type="System.Decimal">176.40</Col>
            <Col Nr="53" AbaName="VALUE_11" Type="System.Decimal">176.40</Col>
            <Col Nr="54" AbaName="VALUE_12" Type="System.Decimal">159.60</Col>
            <Col Nr="55" AbaName="VALUE_13" Type="System.Decimal">2083.20</Col>
            <Col Nr="56" AbaName="VALUE_14" Type="System.Decimal">6000.00</Col>
        </Row>
    </DataTable>
</DataSet>
*/