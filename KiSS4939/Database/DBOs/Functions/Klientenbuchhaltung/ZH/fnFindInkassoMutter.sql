SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnFindInkassoMutter
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnFindInkassoMutter
 (@FaLeistungID int,
  @Datum        datetime = NULL)
 RETURNS int
AS
BEGIN
  DECLARE @BaPersonID_Mutter int,
          @BaPersonID_Vater  int,
          @FaProzessCode     int,
          @BaPersonID_JuengsterGlaeubiger int,
          @BaPersonID_AeltesterGlaeubiger int

  SELECT @FaProzessCode    = FaProzessCode,
         @BaPersonID_Vater = BaPersonID
  FROM   FaLeistung
  WHERE  FaLeistungID = @FaLeistungID

  -- Bei KKBB ist die Mutter die Leistungsträgerin
  IF @FaProzessCode = 407 /*KKBB*/
    RETURN @BaPersonID_Vater

  SELECT @BaPersonID_Mutter = BaPersonID
  FROM   IkRechtstitel
  WHERE  FaLeistungID = @FaLeistungID
  ORDER BY BaPersonID DESC -- damit NULL am Schluss kommt

  IF @BaPersonID_Mutter IS NOT NULL
    RETURN @BaPersonID_Mutter

  SELECT TOP 1 @BaPersonID_JuengsterGlaeubiger = IKG.BaPersonID
  FROM   IkRechtstitel      RET
    INNER JOIN IkGlaeubiger IKG ON IKG.IkRechtstitelID = RET.IkRechtstitelID
    INNER JOIN BaPerson     PRS ON PRS.BaPersonID      = IKG.BaPersonID
  WHERE RET.FaLeistungID = @FaLeistungID
  ORDER BY PRS.Geburtsdatum DESC

  SELECT TOP 1 @BaPersonID_Mutter = BaPersonID_1
  FROM BaPerson_Relation
  WHERE @BaPersonID_JuengsterGlaeubiger = BaPersonID_2 AND
        BaRelationID IN (1, /*Eltern : Kind*/
                         6, /*Pflegeltern : Pflegekind*/
                         7) /*Stiefeltern : Stiefkind*/ AND
        BaPersonID_1 <> @BaPersonID_Vater
  ORDER BY BaRelationID ASC

  IF @BaPersonID_Mutter IS NOT NULL
    RETURN @BaPersonID_Mutter

  -- Spezialfälle: Gläubigerin ist volljährig, Mutter ist nicht im Klientensystem
  -- Rückgabe der ältesten Gläubigerin
  SELECT TOP 1 @BaPersonID_AeltesterGlaeubiger = IKG.BaPersonID
  FROM   IkRechtstitel      RET
    INNER JOIN IkGlaeubiger IKG ON IKG.IkRechtstitelID = RET.IkRechtstitelID
    INNER JOIN BaPerson     PRS ON PRS.BaPersonID      = IKG.BaPersonID
  WHERE RET.FaLeistungID = @FaLeistungID
  ORDER BY PRS.Geburtsdatum ASC

  RETURN @BaPersonID_AeltesterGlaeubiger

END

