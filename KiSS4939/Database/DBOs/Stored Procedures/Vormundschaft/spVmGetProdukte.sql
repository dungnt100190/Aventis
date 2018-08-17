SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spVmGetProdukte
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spVmGetProdukte.sql $
  $Author: Lgreulich $
  $Modtime: 3.12.09 9:05 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  This is only used in Mbuchsee!
    @Param01: .
  -
  RETURNS: .
  -
  TEST:    EXEC dbo.spVmGetProdukte
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spVmGetProdukte.sql $
 * 
 * 1     3.12.09 9:06 Lgreulich
 * 

=================================================================================================*/

CREATE PROCEDURE dbo.spVmGetProdukte
(
  @onlyPendente BIT, 
  @SAR INT, 
  @Stichtag DATETIME
)
AS 
BEGIN
  /*
  * Produkte sind nicht aus einer LOV-Liste oder ähnlichem. 
  */
  DECLARE @Data TABLE(
    UserID      INT,
    Produkt     INT,
    BaPersonID INT,
    FaleistungID    INT
  )

  /*
  * Regel 1 + 2 VM/PRIMA
  */

  IF @onlyPendente = 1
    BEGIN
    INSERT INTO @Data
    SELECT UserID = FAL.UserID,
         Produkt = CASE WHEN ERN.VmPrimaID IS NOT NULL THEN 2
                        ELSE 1
                   END,
         BaPersonID = FAL.BaPersonID,
         FaleistungID = FAL.FaleistungID
    FROM Faleistung FAL
         LEFT  JOIN VmMassnahme MSN ON MSN.FaleistungID = FAL.FaleistungID
                              AND MSN.VmMassnahmeID = (SELECT TOP 1 VmMassnahmeID  -- letzte Massnahme
                                                       FROM   VmMassnahme
                                                       WHERE  FaleistungID = FAL.FaleistungID
                                                       ORDER BY DatumVon DESC)
         LEFT JOIN VmErnennung ERN ON ERN.VmMassnahmeID = MSN.VmMassnahmeID
                             AND ERN.VmErnennungID = (SELECT TOP 1 VmErnennungID -- letzte Ernennung
                                                      FROM   VmErnennung
                                                      WHERE  VmMassnahmeID = MSN.VmMassnahmeID
                                                      ORDER BY Ernennung DESC)
    WHERE FAL.ModulID = 5
    AND FAL.FaProzessCode = 501
    AND (FAL.DatumBis > IsNull(@Stichtag, GETDATE()) OR FAL.DatumBis IS NULL)
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND (MSN.DatumBis > IsNull(@Stichtag, GETDATE()) OR MSN.DatumBis IS NULL)
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)
    AND exists  (select VmBerichtID from VmBericht
		  where  FaleistungID = FAL.FaleistungID and
        	         Erstellung is null)  -- pendente Berichterstellung
  END ELSE BEGIN
    INSERT INTO @Data
    SELECT UserID = FAL.UserID,
         Produkt = CASE WHEN ERN.VmPrimaID IS NOT NULL THEN 2
                        ELSE 1 
                   END,
         BaPersonID = FAL.BaPersonID,
         FaleistungID = FAL.FaleistungID
    FROM Faleistung FAL
         LEFT  JOIN VmMassnahme MSN ON MSN.FaleistungID = FAL.FaleistungID
                              AND MSN.VmMassnahmeID = (SELECT TOP 1 VmMassnahmeID  -- letzte Massnahme
                                                       FROM   VmMassnahme
                                                       WHERE  FaleistungID = FAL.FaleistungID
                                                       ORDER BY DatumVon DESC)
         LEFT JOIN VmErnennung ERN ON ERN.VmMassnahmeID = MSN.VmMassnahmeID
                             AND ERN.VmErnennungID = (SELECT TOP 1 VmErnennungID -- letzte Ernennung
                                                      FROM   VmErnennung
                                                      WHERE  VmMassnahmeID = MSN.VmMassnahmeID
                                                      ORDER BY Ernennung DESC)
    WHERE FAL.ModulID = 5
    AND FAL.FaProzessCode = 501
    AND (FAL.DatumBis > IsNull(@Stichtag, GETDATE()) OR FAL.DatumBis IS NULL)
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND (MSN.DatumBis > IsNull(@Stichtag, GETDATE()) OR MSN.DatumBis IS NULL)
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)
  END

  /*
  * Regel 3 VM Abklärungen
  */
  DECLARE @FaIntAnmeldungDatum int
  DECLARE @FaIntAnlassVM       int

  exec spGetDynaFldIDfromTextmarke 'FaIntAnlassVM',  @FaIntAnlassVM out
  exec spGetDynaFldIDfromTextmarke 'FaIntAnmeldungDatum',  @FaIntAnmeldungDatum out

  INSERT INTO @Data
  SELECT UserID      = FAL.UserID,
         Produkt     = 3,
         BaPersonID = FAL.BaPersonID,
         FaleistungID    = FAL.FaleistungID
  FROM DynaValue     AMD
  INNER JOIN FaPhase PHS ON PHS.FaPhaseID = AMD.FaPhaseID
  INNER JOIN Faleistung  FAL ON FAL.FaleistungID  = PHS.FaleistungID
  INNER JOIN XUser   USR ON USR.UserID    = FAL.UserID
  LEFT  JOIN DynaValue AVA ON AVA.DynaFieldID = @FaIntAnlassVM
                          AND AVA.FaPhaseID   = AMD.FaPhaseID
                          AND AVA.GridRowID   = AMD.GridRowID
  WHERE AMD.DynaFieldID = @FaIntAnmeldungDatum
    AND CONVERT(DATETIME, AMD.Value) < IsNull(@Stichtag, GETDATE())
    AND isNull(PHS.DatumBis, '99990101') > IsNull(@Stichtag, GETDATE())
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND (AVA.Value IN (1,2,5,6))
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)

  /*
  * Regel 4 Vaterschaftsabklärung: Neu und Aberkennungsklage
  */
  INSERT INTO @Data
  SELECT UserID      = FAL.UserID,
         Produkt     = 4,
         BaPersonID = FAL.BaPersonID,
         FaleistungID    = FAL.FaleistungID
  FROM Faleistung              FAL
    INNER  JOIN VmVaterschaft VTR ON FAL.FaleistungID = VTR.FaleistungID
  WHERE FAL.ModulID = 5                                --Vormundschaft
    AND FAL.FaProzessCode = 502                            --Vaterschaftsabklärung
    AND isNull(FAL.DatumBis, '99990101') > IsNull(@Stichtag, GETDATE())
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND (VTR.UHVDatum < IsNull(@Stichtag, GETDATE()) OR VTR.SorgerechtVereinbDatum < IsNull(@Stichtag, GETDATE()))
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)

  /*
  * Regel 5,6,7,9,10,12,14 
  * Frage: Was ist mit Null-Werten oder Wert 8 in VmAuftragCode?
  */
  INSERT INTO @Data
  SELECT UserID      = FAL.UserID,
         Produkt     = CASE WHEN FAL.VmAuftragCode = 1 THEN 10
                            WHEN FAL.VmAuftragCode = 2 THEN 11
                            WHEN FAL.VmAuftragCode = 3 THEN 7
                            WHEN FAL.VmAuftragCode = 4 THEN 5
                            WHEN FAL.VmAuftragCode = 5 THEN 6
                            WHEN FAL.VmAuftragCode = 6 THEN 9
                            WHEN FAL.VmAuftragCode = 7 THEN 9
                            /*
						    WHEN FAL.VmAuftragCode = 9 THEN 'andere'
                            WHEN FAL.VmAuftragCode IS NULL THEN  'VM-Auftrag: Kein Auftrag gewählt'
						    */
                       END,
         BaPersonID = FAL.BaPersonID,
         FaleistungID    = FAL.FaleistungID
  FROM Faleistung FAL
  WHERE FAL.ModulID = 5                                --VM
    AND FAL.FaProzessCode = 505                            --VM Auftrag
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND isNull(FAL.DatumBis, '99990101') > IsNull(@Stichtag, GETDATE()) -- Vm-Auftrag nicht abgeschlossen
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)

  /*
  * Regel 8 psB
  */
  DECLARE @FaAusstattungVerBeginn    INT
  EXEC spGetDynaFldIDfromTextmarke 'FaAusstattungVerBeginn',    @FaAusstattungVerBeginn out

  INSERT INTO @Data
  SELECT UserID      = FAL.UserID,
         Produkt     = 8,
         BaPersonID = FAL.BaPersonID,
         FaleistungID    = FAL.FaleistungID
  FROM   Faleistung FAL
    INNER JOIN FaPhase PHS ON PHS.FaleistungID = FAL.FaleistungID
                          AND isNull(PHS.DatumBis, '99990101') > IsNull(@Stichtag, GETDATE()) -- Phase nicht abgeschlossen
    INNER JOIN DynaValue VER ON VER.DynaFieldID IN (@FaAusstattungVerBeginn)
                          AND VER.FaPhaseID   = PHS.FaPhaseID
                          AND CONVERT(DATETIME, VER.Value) < IsNull(@Stichtag, GETDATE())     -- Vertrag vor Stichtag
  WHERE FAL.ModulID = 2 --Fallführung
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                         -- Eröffnung vor Stichtag
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)

  /*
  * Regel 13 Erbschaft
  */
  INSERT INTO @Data
  SELECT UserID      = FAL.UserID,
         Produkt     = 12,
         BaPersonID = FAL.BaPersonID,
         FaleistungID    = FAL.FaleistungID
  FROM   Faleistung FAL
  WHERE FAL.ModulID = 5                            --Vormundschaftsmodul
    AND FAL.FaProzessCode = 503                        --Erbschaft
    AND FAL.DatumVon < IsNull(@Stichtag, GETDATE())                     -- Eröffnung vor Stichtag
    AND isNull(FAL.DatumBis, '99990101') > IsNull(@Stichtag, GETDATE()) -- Vm-Auftrag nicht abgeschlossen
    AND FAL.UserID = IsNull(@SAR, FAL.UserID)


  SELECT * 
  FROM @Data
    
END
GO
 