 SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spKbBuchung_StornoCheckAndCreateKbBuchungStornoEntry]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spKbBuchung_StornoCheckAndCreateKbBuchungStornoEntry]
GO
/*===============================================================================================
  $Revision: 7 $
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
CREATE PROCEDURE dbo.spKbBuchung_StornoCheckAndCreateKbBuchungStornoEntry
(
	@KbBuchungID		int
)
AS BEGIN
	-- Prüfe, ob es schon einen Eintrag gibt
	DECLARE @Count int

	SELECT @Count = count(KbBuchungID)
	FROM KbBuchungStorno
	WHERE KbBuchungID = @KbBuchungID

	IF @Count = 0 BEGIN
		-- Nein, d.h. wir schauen, ob es schon einen abhängigen Netto-Beleg gibt, der einen KbBuchungStorno-Eintrag hat. Wenn ja, kopieren wir den
			SELECT @Count = count(KbBuchungID)
			FROM KbBuchungStorno
			WHERE KbBuchungID IN (SELECT * FROM dbo.fnGetAllDependendNettoBelegIDs(@KbBuchungID))

			IF @Count > 0 BEGIN
				-- Ok, mind. einen solchen Eintrag gibts, d.h. wir nehmen den ersten und kopieren ihn
				INSERT INTO KbBuchungStorno
				(KbBuchungID, StornierungVermerktUserID, StornierungVermerktDatum)
				(SELECT TOP 1 @KbBuchungID, StornierungVermerktUserID, StornierungVermerktDatum
				 FROM KbBuchungStorno WHERE
					KbBuchungID IN (SELECT * FROM dbo.fnGetAllDependendNettoBelegIDs(@KbBuchungID)))
			END
	END
END
