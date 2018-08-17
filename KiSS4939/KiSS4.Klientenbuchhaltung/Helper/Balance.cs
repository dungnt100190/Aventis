using System;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    ///
    /// </summary>
    public static class Balance
    {
        /// <summary>
        ///
        /// </summary>
        public static void AktualisiereBuchungsStatus(
            Int32 kbBuchungId,
            Int32 buchungStatus)
        {
            System.Diagnostics.Debug.WriteLine(
                "AktualisiereBuchungsStatus (" + kbBuchungId.ToString() + ", " + buchungStatus.ToString() + ")");

            DBUtil.ExecuteScalarSQL(@"
                UPDATE KbBuchung 
                    SET KbBuchungStatusCode = {0}
                WHERE KbBuchungID = {1}",
                buchungStatus,
                kbBuchungId);
        }

        /// <summary>
        ///
        /// </summary>
        public static void AktualisiereTransferStatus(
            Int32 kbBuchungId,
            Int32 kbZahlungslaufId,
            Int32 kbTransferStatusCode)
        {
            System.Diagnostics.Debug.WriteLine(
                "AktualisiereTransferStatus (" + kbBuchungId.ToString() + ", " + kbZahlungslaufId.ToString() + ", " + kbTransferStatusCode.ToString() + ")");

            DBUtil.ExecuteScalarSQL(@"
                UPDATE KbTransfer 
                    SET KbTransferStatusCode = {0}
                WHERE KbBuchungID = {1}
                  AND KbZahlungslaufID = {2}",
                kbTransferStatusCode,
                kbBuchungId,
                kbZahlungslaufId);
        }

        /// <summary>
        ///
        /// </summary>
        public static Int32 ErstelleAusgleichEintrag(
            Int32 buchungId,
            Int32 ausgleichBuchungId,
            Decimal betrag)
        {
            System.Diagnostics.Debug.WriteLine(
                "ErstelleAusgleichEintrag (" + buchungId.ToString() + ", " + ausgleichBuchungId.ToString() + ", " + betrag.ToString() + ")");

            String ausgleich = DBUtil.ExecuteScalarSQL(@"
                INSERT INTO KbOpAusgleich (
                    OpBuchungID,
                    AusgleichBuchungID,
                    Betrag)
                    VALUES ({0}, {1}, {2})
                SELECT SCOPE_IDENTITY()",
                buchungId,
                ausgleichBuchungId,
                betrag).ToString();

            Int32 ausgleichId = Int32.Parse(ausgleich);
            System.Diagnostics.Debug.WriteLine("ErstelleAusgleichEintrag: " + ausgleichId.ToString());
            return ausgleichId;
        }

        /// <summary>
        ///
        /// </summary>
        public static Int32 ErstelleAusgleichsBuchung(
            Decimal betrag,
            String sollKtoNr,
            String habenKtoNr,
            Int32 kbPeriodeID,
            DateTime belegDatum)
        {
            System.Diagnostics.Debug.WriteLine(
                "ErstelleAusgleichsBuchung (" + betrag.ToString() + ", " + sollKtoNr + ", " + habenKtoNr + ")");

            Int32 belegNr = Utils.ConvertToInt(
                                DBUtil.ExecuteScalarSQLThrowingException(@"exec dbo.spKbGetBelegNr {0}, {1}, {2}",
                                kbPeriodeID,
                                7, // KbBelegkreis	7	Zahlungslauf
                                DBNull.Value)); // Konto is null

            int? kbBelegKreisId = KliBuUtil.GetKbBelegKreisId(kbPeriodeID, 7);

            System.Diagnostics.Debug.WriteLine("BelegNummer = " + belegNr.ToString());

            String ausgleichBuchung = DBUtil.ExecuteScalarSQL(@"
                INSERT INTO KbBuchung (
                    BelegDatum,
                    ErstelltDatum,
                    KbBuchungTypCode,
                    KbPeriodeID,
                    KbBuchungStatusCode,
                    Betrag,
                    SollKtoNr,
                    HabenKtoNr,
                    Text,
                    BelegNr,
                    KbBelegKreisID,
                    ErstelltUserID)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})
                SELECT SCOPE_IDENTITY()",
                belegDatum,
                DateTime.Now,
                4,
                kbPeriodeID,
                6,
                betrag,
                sollKtoNr,
                habenKtoNr,
                "Ausgleichsbuchung",
                belegNr,
                kbBelegKreisId,
                Session.User.UserID).ToString();

            Int32 ausgleichBuchungId = Int32.Parse(ausgleichBuchung);
            System.Diagnostics.Debug.WriteLine("ErstelleAusgleichsBuchung :" + ausgleichBuchungId.ToString() + " erstellt");
            return ausgleichBuchungId;
        }
    }
}