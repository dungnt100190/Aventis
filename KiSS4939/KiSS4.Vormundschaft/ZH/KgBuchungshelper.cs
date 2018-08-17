using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KiSS4.DB;

namespace KiSS4.Vormundschaft.ZH
{
    class KgBuchungshelper
    {
        //TODO für 6015, R4.2.33
        //

        /// <summary>
        /// Passt (falls genügend Berechtigungen vorhanden sind) das Buchungsdatum an, und dies auch auf dem Ausgleich.
        /// Fachlicher Hintergrund: z.T. stimmt von Kiss erwartete Ausführungsdatum nicht mit dem Ausführungsdatum der Bank
        /// überein. Liegen die beiden Daten in unterschiedlichen Perioden, so muss für einen korrekten Abschluss das 
        /// Datum anpassbar sein.
        /// </summary>
        /// <param name="kgPositionID">ID der betroffenen Budgetposition</param>
        /// <param name="kgBuchungIDs">Liste der BuchungsIDs der anzupassenden Buchungen</param>
        /// <param name="neuesBuchungsDatum">Das neue Datum oder null, falls Datum bleiben soll</param>
        internal static void buchungsDatumAnpassen(int kgPositionID, IEnumerable<int> kgBuchungIDs, DateTime neuesBuchungsDatum)
        {
            // TODO: Validierungen, z.B. Rechte und Testen
            var kgBuchungIDsClause = "1 = 1"; // Dummy clause
            if (kgBuchungIDs != null)
            {
                var ids = string.Join(",", kgBuchungIDs);
                if (string.IsNullOrEmpty(ids))
                {
                    ids = "NULL"; // führt zu 'BUC.KgBuchungID IN (NULL)', was sprechender ist als z.B. '1 = 0'
                }
                kgBuchungIDsClause = string.Format("BUC.KgBuchungID IN ({0})", ids);
            }
            // HACK: string.Format() ist leider nötig wegen int[]. Der string würde zu '1,2,3' normalisiert
            DBUtil.ExecSQLThrowingException(string.Format(@"
                    DECLARE @KgPeriodeID int
                    SELECT @KgPeriodeID = PER.KgPeriodeID
                    FROM KgPosition        POS
                      INNER JOIN KgBudget  BUD ON BUD.KgBudgetID = POS.KgBudgetID
                      INNER JOIN KgPeriode PER ON PER.FaLeistungID = BUD.FaLeistungID AND {0} BETWEEN PER.PeriodeVon AND PER.PeriodeBis
                    WHERE POS.KgPositionID = {1}
                    
                    UPDATE BUC
                    SET ValutaDatum = {0},
                        BuchungsDatum = {0},
                        KgPeriodeID = @KgPeriodeID
                    FROM KgBuchung BUC
                    WHERE BUC.KgPositionID = {1} AND ({2})

                    UPDATE AGB
                    SET ValutaDatum = {0},
                        BuchungsDatum = {0},
                        KgPeriodeID = @KgPeriodeID
                    FROM KgBuchung             AGB -- Ausgleichsbuchung
                      INNER JOIN KgOpAusgleich OPA ON OPA.AusgleichBuchungID = AGB.KgBuchungID
                      INNER JOIN KgBuchung     BUC ON BUC.KgBuchungID = OPA.OpBuchungID
                    WHERE BUC.KgPositionID = {1} AND {2}", "{0}", "{1}", kgBuchungIDsClause),
                neuesBuchungsDatum,
                kgPositionID
            );
        }

        internal static void buchungstextAnpassen(int kgPositionID, int? kgBuchungID, string buchungsText)
        {
            if (!DBUtil.IsEmpty(buchungsText))
            {
                DBUtil.ExecuteScalarSQLThrowingException(@"
                  UPDATE KgBuchung
                  SET Text           = {1}
                  WHERE KgPositionID = {0} AND ({2} IS NULL OR KgBuchungID = {2})

                  UPDATE AZB
                  SET Text          = {1}
                  FROM dbo.KgBuchung             BUC
                    INNER JOIN dbo.KgOpAusgleich AUG ON AUG.OpBuchungID = BUC.KgBuchungID
                    INNER JOIN dbo.KgBuchung     AZB ON AZB.KgBuchungID = AusgleichBuchungID
                  WHERE BUC.KgPositionID = {0} AND ({2} IS NULL OR BUC.KgBuchungID = {2})",
                    kgPositionID,
                    buchungsText,
                    kgBuchungID);
            }
        }

        internal static void kontoAnpassen(int kgPositionID, int? kgBuchungID, string kontoNrSoll, string kontoNrHaben)
        {
            if (!DBUtil.IsEmpty(kontoNrSoll) || !DBUtil.IsEmpty(kontoNrHaben))
            {
                DBUtil.ExecuteScalarSQLThrowingException(@"
                  UPDATE KgBuchung
                  SET SollKtoNr     = IsNull({1},SollKtoNr),
                      HabenKtoNr    = IsNull({2},HabenKtoNr)
                  WHERE KgPositionID = {0}  AND ({3} IS NULL OR KgBuchungID = {3})",
                    kgPositionID,
                    kontoNrSoll,
                    kontoNrHaben,
                    kgBuchungID);
            }
        }

        internal static void debitorAnpassen(int kgPositionID, int? baInstitutionID)
        {
            if (baInstitutionID.HasValue)
            {
                DBUtil.ExecuteScalarSQLThrowingException(@"
                  UPDATE KgPosition
                  SET BaInstitutionID = {1}
                  WHERE KgPositionID = {0}

                  UPDATE KgBuchung
                  SET BaInstitutionID = {1}
                  WHERE KgPositionID = {0}",
                    kgPositionID,
                    baInstitutionID.Value);
            }
        }

        internal static void CalculateSaldo(System.Data.DataRowCollection rows, string columnNameHaben, string columnNameSoll, string columnNameSaldo)
        {
            decimal saldo = Decimal.Zero;
            for (int t = rows.Count - 1; t >= 0; t--)
            {
                System.Data.DataRow row = rows[t];
                if (row.RowState != System.Data.DataRowState.Deleted)
                {
                    saldo += (decimal)row[columnNameSoll] - (decimal)row[columnNameHaben];
                    if (row[columnNameHaben].Equals(decimal.Zero))
                    {
                        row[columnNameHaben] = DBNull.Value;
                    }
                    if (row[columnNameSoll].Equals(decimal.Zero))
                    {
                        row[columnNameSoll] = DBNull.Value;
                    }
                    row[columnNameSaldo] = saldo;
                    row.AcceptChanges();
                }
            }
        }
    }
}
