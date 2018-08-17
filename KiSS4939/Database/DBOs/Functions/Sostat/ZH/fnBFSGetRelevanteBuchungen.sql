SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSGetRelevanteBuchungen;
GO

/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
    Gibt eine Tabelle mit allen für BFS relevanten Auszahlungen (Nettobelege) zurück
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  RETURNS: .
=================================================================================================
  TEST:    
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, NULL, 173681, NULL, NULL, 1)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, NULL, 173681, NULL, NULL, 0)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, 7884, 173681, NULL, NULL, 0)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, 7884, 173681, NULL, NULL, 0)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, 7884, 173681, NULL, 69, 0)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, 7884, 173681, '1,2', 69, 0)
  SELECT * FROM fnBFSGetRelevanteBuchungen(2012, 7884, 173681, '3,4', 69, 0)  
=================================================================================================*/
CREATE FUNCTION dbo.fnBFSGetRelevanteBuchungen
(
  @Erhebungsjahr                        INT = NULL,
  @UserID                               INT = NULL,
  @BaPersonID                           INT = NULL,
  @LeistungsartCodes                    VARCHAR(200) = NULL, -- kommagetrennte Liste von Leistungsart-Codes
  @OrgUnitID                            INT = NULL,
  @InklBuchungenVorErhebungsjahr        BIT = 1
)
RETURNS @OUTPUT TABLE 
(
  FaProzessCode   INT,
  BaPersonID      INT, -- Antraggsteller
  Ausgleichsdatum DATETIME,
  FaLeistungID    INT   -- nicht eindeutig, daher max(FaLeistungID)
  PRIMARY KEY (FaProzessCode, BaPersonID, Ausgleichsdatum, FaLeistungID)
)
AS
BEGIN

  SET @LeistungsartCodes = ',' + ISNULL(@LeistungsartCodes, '1,2,23,25') + ',';
  SET @LeistungsartCodes = ',' + @LeistungsartCodes + ',';
  SET @InklBuchungenVorErhebungsjahr = ISNULL(@InklBuchungenVorErhebungsjahr, 1);

  IF (@Erhebungsjahr IS NULL)
  BEGIN
    SET @Erhebungsjahr = CONVERT(int, dbo.fnXConfig('System\Sostat\Erhebungsjahr', GETDATE()));
  END;
  
  DECLARE @DatumVon DATETIME; -- 31.07. von Vorjahr oder NULL, falls @InklBuchungenVorErhebungsjahr = 1
  DECLARE @DatumBis DATETIME; -- 31.12. vom Erhebungsjahr
  
  SET @DatumVon = CASE
                    WHEN @InklBuchungenVorErhebungsjahr = 1 THEN NULL
                    ELSE dbo.fnDateSerial(@Erhebungsjahr - 1, 7, 1)
                  END;   
  SET @DatumBis = dbo.fnDateSerial(@Erhebungsjahr, 12, 31);
 
  INSERT INTO @OUTPUT
    SELECT
      FaProzessCode,
      BaPersonID,
      Ausgleichsdatum,
      FaLeistungID
    FROM dbo.fnGetRelevanteBuchungen(@DatumVon, @DatumBis, @UserID, @BaPersonID, @LeistungsartCodes, @OrgUnitID);
 
  RETURN;
END;
