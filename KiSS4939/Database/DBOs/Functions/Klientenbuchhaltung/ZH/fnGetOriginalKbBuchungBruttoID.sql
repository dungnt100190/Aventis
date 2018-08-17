SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetOriginalKbBuchungBruttoID
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Falls die übergebene @KbBuchungBruttoID eine NEU- oder STO-Buchung ist, 
           gibt diese Funktion die KbBuchungBruttoID der Originalbuchung zurück, und zwar unabhängig, wie tief die Umbuchungs- resp. Storno-Hierarchie ist
           Falls die übergebene @KbBuchungBruttoID keine NEU- oder STO-Buchung ist, wird einfach diese @KbBuchungBruttoID zurückgegeben.
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    Select * from KbBuchungBrutto where StorniertKbBuchungBruttoID is not null
           Select dbo.fnGetOriginalKbBuchungBruttoID(1036705)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetOriginalKbBuchungBruttoID
(
  @KbBuchungBruttoID int
)
RETURNS int
AS
BEGIN
  DECLARE @OriginalKbBuchungBruttoID int
  DECLARE @OriginalKbBuchungBruttoIDTemp int

  -- Wichtige Überprüfung: nachfolgend würde bei einer ungültigen ID eine Endlosschleife ausgelöst
  IF NOT EXISTS (SELECT KbBuchungBruttoID FROM KbBuchungBrutto WHERE KbBuchungBruttoID = @KbBuchungBruttoID) BEGIN
    RETURN NULL
  END

  SET @OriginalKbBuchungBruttoIDTemp = @KbBuchungBruttoID

  WHILE @OriginalKbBuchungBruttoIDTemp IS NOT NULL BEGIN
    SET @OriginalKbBuchungBruttoID = @OriginalKbBuchungBruttoIDTemp
	SELECT @OriginalKbBuchungBruttoIDTemp = COALESCE(StorniertKbBuchungBruttoID, NeuBuchungVonKbBuchungBruttoID) FROM KbBuchungBrutto WHERE KbBuchungBruttoID = @OriginalKbBuchungBruttoID
  END
  
  RETURN @OriginalKbBuchungBruttoID

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO