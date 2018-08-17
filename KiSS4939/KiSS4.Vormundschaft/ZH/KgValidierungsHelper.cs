using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KiSS4.DB;

namespace KiSS4.Vormundschaft.ZH
{
    class KgValidierungsHelper
    {
        private readonly static string ERROR_MSG_VERKEHRSKONTO_UNGUELTIG = "Achtung: ZKB-DataLink ist nicht mehr aktiv. Zahlung kann nicht ausgeführt werden";

        /// <summary>
        /// Gibt den Standard-Fehlertext bei einem ungültigen Verkehrskonto zurück
        /// </summary>
        public static string ErrorMsg_Verkehrskonto_ungueltig
        {
            get { return KgValidierungsHelper.ERROR_MSG_VERKEHRSKONTO_UNGUELTIG; }
        } 


        /// <summary>
        /// Validiert bei einer Auszahlung im Modul K das aktuelle Verkehrskonto
        /// </summary>
        /// <param name="faLeistungID">Die ID der Leistung dessen Verkehrskonto überprüft werden soll</param>
        /// <param name="ausfuehrungsDatum">Das voraussichtliche Zahlungsdatum</param>
        /// <returns>True falls kein gültiges Verkehrskonto gefunden wird</returns>
        public static bool KgCheckVerkehrskonto(int faLeistungID, DateTime ausfuehrungsDatum)
        {
            SqlQuery qryBaZahlwegCheck = new SqlQuery();
            qryBaZahlwegCheck.SelectStatement = @"
                DECLARE @BuchungDatum datetime, @FaLeistungID int
                SELECT @BuchungDatum = {0}, @FaLeistungID = {1}
                SELECT BAZ.BaZahlungswegID
                FROM dbo.KgPeriode PER
                  INNER JOIN BaZahlungsweg BAZ ON BAZ.BaZahlungswegID = PER.BaZahlungswegID
                WHERE  FaLeistungID = @FaLeistungID AND
                  KgPeriodeStatusCode = 1 AND
                  @BuchungDatum BETWEEN PER.PeriodeVon AND DateAdd(s,-1,DateAdd(d,1,PER.PeriodeBis)) AND
                  (@BuchungDatum BETWEEN BAZ.DatumVon AND BAZ.DatumBis
                    OR @BuchungDatum >= BAZ.DatumVon AND BAZ.DatumBis IS NULL)";

            qryBaZahlwegCheck.Fill(ausfuehrungsDatum, faLeistungID);
            return !(qryBaZahlwegCheck.Count as int? >= 1);
        }

        public static void KgCheckVerkehrskontoThrowsException(int faLeistungID, DateTime ausführungsDatum)
        {
            if (KgCheckVerkehrskonto(faLeistungID, ausführungsDatum))
            {
                throw new KissInfoException(ERROR_MSG_VERKEHRSKONTO_UNGUELTIG);
            }
        }
    }
}
