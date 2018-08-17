using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.Integration.DataAccess.DTO;
using KiSS.DBScheme;
using KiSS4.DB;

namespace Kiss.Integration.DataAccess.Reporting
{
    public class KlientenlisteReport
    {
        public IEnumerable<BaPersonDTO> GetKlientenliste(string name, string vorname)
        {
            var query = DBUtil.OpenSQL(@"
                SELECT
                  PRS.Titel,
                  PRS.BaPersonID,
                  PRS.Name,
                  PRS.Vorname,
                  PRS.Geburtsdatum,
                  PRS.Sterbedatum,
                  PRS.EMail,
                  PRS.Nationalitaet,
                  PRS.WohnsitzOrt,
                  PRS.WohnsitzPLZ,
                  PRS.WohnsitzStrasseHausNr,
                  PRS.MobilTel,
                  PRS.Telefon_P,
                  PRS.Versichertennummer,
                  Geschlecht = dbo.fnLOVText('Geschlecht', PRS.GeschlechtCode),
                  Zivilstand = dbo.fnLOVText('Zivilstand', PRS.ZivilstandCode)
                FROM dbo.vwPerson PRS
                WHERE ({0} IS NULL OR PRS.Name LIKE '%' + {0} + '%')
                  AND ({1} IS NULL OR PRS.Vorname LIKE '%' + {1} + '%')
                ORDER BY PRS.Name, PRS.Vorname;",
                name,
                vorname);

            return query.DataTable.Select().Select(
                row => new BaPersonDTO
                {
                    Titel = row[DBO.vwPerson.Titel] as string,
                    BaPersonID = (int)row[DBO.vwPerson.BaPersonID],
                    Geburtsdatum = row[DBO.vwPerson.Geburtsdatum] as DateTime?,
                    Sterbedatum = row[DBO.vwPerson.Sterbedatum] as DateTime?,
                    Geschlecht = row["Geschlecht"] as string,
                    Name = row[DBO.vwPerson.Name] as string,
                    Vorname = row[DBO.vwPerson.Vorname] as string,
                    Email = row[DBO.vwPerson.EMail] as string,
                    Nationalitaet = row[DBO.vwPerson.Nationalitaet] as string,
                    Ort = row[DBO.vwPerson.WohnsitzOrt] as string,
                    Plz = row[DBO.vwPerson.WohnsitzPLZ] as string,
                    Strasse = row[DBO.vwPerson.WohnsitzStrasseHausNr] as string,
                    TelefonMobil = row[DBO.vwPerson.MobilTel] as string,
                    TelefonPrivat = row[DBO.vwPerson.Telefon_P] as string,
                    Versichertennummer = row[DBO.vwPerson.Versichertennummer] as string,
                    Zivilstand = row["Zivilstand"] as string
                });
        }
    }
}