SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
EXECUTE dbo.spDropObject fnGetBaBankUpdated
GO

/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnGetBaBankUpdated.sql $
  $Author: Mmarghitola $
  $Modtime: 31.05.10 10:15 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This functions gets all the update-history from BaBank which is in the XLog table
    @Source    The source name to search
    @Message   The message text to search
  -
  RETURNS: The table with the updated bank informations.
  -
  TEST:    SELECT * FROM dbo.fnGetBaBankUpdated('KiSS.KliBu.UI.DlgBankenabgleich', 'updated bank infos')
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnGetBaBankUpdated.sql $
 * 
 * 5     31.05.10 10:16 Mmarghitola
 * ungültiges Zeichen aus Kommentar entfernt
 * 
 * 4     30.05.10 22:02 Rstahel
 * #5012: Änderungen für BaBank.HauptsitzBCL, das neu als VARCHAR(15) und
 * nicht mehr als INT definiert ist
 * 
 * 3     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 2     28.11.09 11:24 Nweber
 * #4644: Beschreibung angepasst
 * 
 * 1     27.11.09 16:25 Nweber
 * #4644: dispatcher und Funktionen um die Bankenstamm-History anzuzeigen.
 * 
 * 1     26.11.09 14:34 Nweber
 * #4644: Funktionen um die aktualisierte Banken anzuzeigen.
 * 
=================================================================================================*/

CREATE FUNCTION dbo.fnGetBaBankUpdated
(
  @Source VARCHAR(MAX),
  @Message VARCHAR(MAX)
)
RETURNS @Bank TABLE (
  Datum DATETIME,
  BaBankID	INT,
  [Name]	VARCHAR(70),
  Strasse	VARCHAR(50),
  PLZ	VARCHAR(10),
  Ort	VARCHAR(50),
  ClearingNr	VARCHAR(15),
  FilialeNr	INT,
  HauptsitzBCL	VARCHAR(15),
  PCKontoNr	VARCHAR(50),
  GueltigAb	DATETIME,
  Land	VARCHAR(2),
  ClearingNrNeu	VARCHAR(15))

BEGIN

  DECLARE @Delimiter CHAR
  SET @Delimiter = '#'

  INSERT INTO @Bank
  SELECT  Datum = XLG.Created,
          BaBankID      = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 1),
          [Name]        = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 2),
          Strasse       = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 3),
          PLZ           = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 4),
          Ort           = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 5),
          ClearingNr    = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 6),
          FilialeNr     = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 7),
          HauptsitzBCL  = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 8),
          PCKontoNr     = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 9),
          GueltigAb     = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 10),
          Land          = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 11),
          ClearingNrNeu = dbo.fnGetTextAtPosition(XLG.Comment, @Delimiter, 12)

  FROM  XLog XLG
  WHERE XLG.Source = @Source
    AND XLG.Message = @Message

  -- done
  RETURN
END
 