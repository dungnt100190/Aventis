SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnAyPersonEinAustritt
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnAyPersonEinAustritt.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 9:47 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnAyPersonEinAustritt.sql $
 * 
 * 2     24.06.09 16:16 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnAyPersonEinAustritt
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE FUNCTION dbo.fnAyPersonEinAustritt()
  RETURNS @PersonEinAustritt TABLE (
   FaLeistungID          int,
   BaPersonID       int,
   Eintritt          datetime,
   Austritt          datetime,
   EinGrundCode      int,
   AusGrundCode      int
)
AS BEGIN
  DECLARE @AyEinAustrittDatumFldID int
  DECLARE @AyEinAustrittEinAusFldID int
  DECLARE @AyEinAustrittPersonenFldID int
  DECLARE @AyEinAustrittGrundFldID int

  SET     @AyEinAustrittDatumFldID = (SELECT DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE FieldName = 'AyEinAustrittDatum')
  SET     @AyEinAustrittEinAusFldID = (SELECT DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE FieldName = 'AyEinAustrittEinAus')
  SET     @AyEinAustrittPersonenFldID = (SELECT DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE FieldName = 'AyEinAustrittPersonen')
  SET     @AyEinAustrittGrundFldID = (SELECT DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE FieldName = 'AyEinAustrittGrund')

  DECLARE @EinAustritte TABLE(
     FaLeistungID          int,
     Datum             datetime,
     Typ               int,
     Personen          varchar(200),
     GrundCode         int,
     KommaIdx          int
  )

  DECLARE @PersonAustritt TABLE(
     FaLeistungID          int,
     BaPersonID       int,
     Austritt          datetime,
     AusGrundCode      int
  )


  INSERT INTO @EinAustritte
  SELECT FAL.FaLeistungID,
         CONVERT(datetime, DAT.Value),
         CONVERT(int, EIN.Value),
         CONVERT(varchar(200), PER.Value),
         CONVERT(int, GRU.Value),
         0
  FROM   dbo.FaLeistung FAL WITH (READUNCOMMITTED) 
         INNER JOIN dbo.DynaValue DAT WITH (READUNCOMMITTED) ON DAT.FaLeistungID = FAL.FaLeistungID AND
                                     DAT.DynaFieldID = @AyEinAustrittDatumFldID
         INNER JOIN dbo.DynaValue EIN WITH (READUNCOMMITTED) ON EIN.FaLeistungID = FAL.FaLeistungID AND
                                     EIN.DynaFieldID = @AyEinAustrittEinAusFldId AND
                                     EIN.GridRowID = DAT.GridRowID
         INNER JOIN dbo.DynaValue PER WITH (READUNCOMMITTED) ON PER.FaLeistungID = FAL.FaLeistungID AND
                                     PER.DynaFieldID = @AyEinAustrittPersonenFldID AND
                                     PER.GridRowID = DAT.GridRowID
         INNER JOIN dbo.DynaValue GRU WITH (READUNCOMMITTED) ON GRU.FaLeistungID = FAL.FaLeistungID AND
                                     GRU.DynaFieldID = @AyEinAustrittGrundFldID AND
                                     GRU.GridRowID = DAT.GridRowID

  -- Eintritte
  WHILE EXISTS (SELECT 1 FROM @EinAustritte WHERE Typ = 1 AND Personen IS NOT NULL) BEGIN

    UPDATE @EinAustritte
    SET    KommaIdx = charindex(',',Personen)
    WHERE  Typ = 1 AND
           Personen IS NOT NULL

    INSERT @PersonEinAustritt
    SELECT EA.FaLeistungID,
           BaPersonID  = CONVERT(int,SubString(EA.Personen,1,CASE WHEN KommaIdx = 0 THEN 99 ELSE KommaIdx-1 END)),
           Eintritt     = EA.Datum,
           Austritt     = NULL,
           EinGrundCode = EA.GrundCode,
           AusGrundCode = NULL
    FROM   @EinAustritte EA
    WHERE  Typ = 1 AND
           Personen IS NOT NULL

    UPDATE @EinAustritte
    SET    Personen = CASE WHEN KommaIdx = 0 THEN NULL ELSE SubString(Personen,KommaIdx+1,99) END
    WHERE  Typ = 1 AND
           Personen IS NOT NULL
  END

  -- Austritte
  WHILE EXISTS (SELECT 1 FROM @EinAustritte WHERE Typ = 2 AND Personen IS NOT NULL) BEGIN

    UPDATE @EinAustritte
    SET    KommaIdx = charindex(',',Personen)
    WHERE  Typ = 2 AND
           Personen IS NOT NULL

    INSERT @PersonAustritt
    SELECT EA.FaLeistungID,
           BaPersonID  = CONVERT(int,SubString(EA.Personen,1,CASE WHEN KommaIdx = 0 THEN 99 ELSE KommaIdx-1 END)),
           Austritt     = EA.Datum,
           AusGrundCode = EA.GrundCode
    FROM   @EinAustritte EA
    WHERE  Typ = 2 AND
           Personen IS NOT NULL

    UPDATE @EinAustritte
    SET    Personen = CASE WHEN KommaIdx = 0 THEN NULL ELSE SubString(Personen,KommaIdx+1,99) END
    WHERE  Typ = 2 AND
           Personen IS NOT NULL

  END

  -- Austritte in @PersonEinAustritt eintragen
  UPDATE PEA
  SET    Austritt     = AUS.Austritt,
         AusGrundCode = AUS.AusGrundCode
  FROM   @PersonAustritt AUS
         INNER JOIN @PersonEinAustritt PEA on PEA.FaLeistungID = AUS.FaLeistungID AND
                                              PEA.BaPersonID = AUS.BaPersonID AND
                                              PEA.Eintritt = (SELECT TOP 1 Eintritt
                                                              FROM   @PersonEinAustritt
                                                              WHERE  FaLeistungID = AUS.FaLeistungID AND
                                                                     BaPersonID = AUS.BaPersonID AND
                                                                     Eintritt <= AUS.Austritt
                                                              ORDER BY Eintritt DESC)
  RETURN
END
GO