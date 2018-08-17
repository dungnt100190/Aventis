SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgUpdateVerkehrskontoName
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Umbenennung der ZKB Verkehrskonti nach dem Muster 'Verkehrskonto ZKB 1100-XXXX.XXX"
            Zu jeder Periode muss ein BaZahlweg erfasst sein mit dem Typ 'Verkehrskonto'
            In diesem Zahlweg ist die ZKB-KontoNummer hinterlegt: 1100-XXXX.XXX
            Diese KtoNr wird mit dieser sp automatisch in den Kontonamen des Kontokorrentkontos des zu
            einer Periode gehörenden Kontasnplans eingearbeitet, normelrweise KontoNr 1040.
            Die Umbenennung erfolgt nur, wenn die Bank des Zahlwegs tatsächlich die ZKB ist.

    @KgPeriodeID: Periode mit dem Kontokorrentkonto, welches umbenannt werden soll
                  Falls null: alle Perioden (für die Nachmigration)
  -
  RETURNS: Nichts 
  -
=================================================================================================
  TEST:    EXEC dbo.spKgUpdateVerkehrskontoName    -- update der Verkehrskonti in allen Kontoplänen
=================================================================================================*/
CREATE PROCEDURE dbo.spKgUpdateVerkehrskontoName
 (@KgPeriodeID int = NULL)
AS BEGIN

   UPDATE KTO
   SET    KontoName = ART.Text + ' ZKB ' + ZAH.BankKontoNummer
   FROM   KgPeriode PER
          INNER JOIN KgKonto       KTO ON KTO.KgPeriodeID = PER.KgPeriodeID
          INNER JOIN BaZahlungsweg ZAH ON ZAH.BaZahlungswegID = PER.BaZahlungswegID AND
                                          ZAH.BankKontoNummer IS NOT NULL
          INNER JOIN BaBank        BNK ON BNK.BaBankID = ZAH.BaBankID AND
                                          BNK.Name = 'Zürcher Kantonalbank'
          INNER JOIN XLOVCode      ART ON ART.LOVName = 'BaKontoart' AND ART.Code = ISNULL(ZAH.BaKontoartCode,4) -- default Verkehrskonto
    WHERE PER.KgPeriodeID = ISNULL(@KgPeriodeID,PER.KgPeriodeID) AND
          KgKontoartCode = 1 -- Kontokorrentkonto
END

