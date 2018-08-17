SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKaGetKandidaten
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
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spKaGetKandidaten
 (@EinsatzplatzID int,
  @ZustaendigKaID int)
AS BEGIN
  SET NOCOUNT ON

DECLARE @tmp TABLE (
  ID             int identity,
  BaPersonID	 int,
  FaLeistungID   int,
  BrancheCodes   varchar(100),
  LehrberufCode  int,
  GeschlechtCode int,
  ProgrammCode   int,
  ZustaendigKA   int,
  FuehrerAusw	 int,
  DeutschM		 int,
  DeutschS		 int,
  PCKenntnisse	 int
  primary key (ID))

-- Insert all data from Vermittlung Profil in TMP-table
INSERT @tmp
SELECT LEI.BaPersonID,
	   PRO.FaLeistungID,
       PRO.BrancheCodes,
       PRO.LehrberufCode,
       PRS.GeschlechtCode,
	   LOV.Code,
	   LEI.UserID,
	   PRO.FuehrerausweisCode,
	   PRO.DeutschMuendlichCode,
	   PRO.DeutschSchriftlichCode,
	   PRO.PCKenntnisseCode
FROM   dbo.KaVermittlungProfil PRO WITH (READUNCOMMITTED) 
	LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = PRO.FaLeistungID
	LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
	LEFT JOIN dbo.XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.Value3 = LEI.FaProzessCode AND LOV.LOVName = 'KaVermittlungProgramm'
AND LEI.DatumBis IS NULL

-- Only show persons with an open "Einsatz"
DELETE FROM @tmp WHERE FaLeistungID IN (
				SELECT VOR.FaLeistungID
				FROM dbo.KaVermittlungEinsatz EIN WITH (READUNCOMMITTED) 
					INNER JOIN dbo.KaVermittlungVorschlag VOR WITH (READUNCOMMITTED) ON VOR.KaVermittlungVorschlagID = EIN.KaVermittlungVorschlagID
				WHERE EIN.Abschluss IS NOT NULL)

-- Delete persons from SI, which have checkbox "vermittelt" checked!
DELETE FROM @tmp WHERE FaLeistungID IN (
				SELECT VSI.FaLeistungID
				FROM dbo.KaVermittlungSI VSI WITH (READUNCOMMITTED) 
				WHERE VSI.Vermittelt = 1)

-- Set the ProgrammCode
DECLARE @sProgCode INT
DECLARE @sGeschlCode INT
DECLARE @sLehrberufCode INT
DECLARE @sBrancheCode INT

SELECT	@sProgCode = IsNull(KaProgrammCode, -1),
		@sGeschlCode = IsNull(GeschlechtCode, 1),
		@sLehrberufCode = IsNull(LehrberufCode, -1),
		@sBrancheCode = IsNull(BrancheCode, -1)
FROM dbo.KaEinsatzplatz WITH (READUNCOMMITTED) 
WHERE KaEinsatzplatzID = @EinsatzplatzID

SET @sGeschlCode = @sGeschlCode - 1

IF (@sProgCode = 1 OR @sProgCode = 2) BEGIN
	-- Only keep data matching with Lehrberuf	
	SELECT	Name = PRS.Name,
		Vorname = PRS.Vorname,
		NameVorname = PRS.NameVorname,
		Geschlecht = dbo.fnLOVText('Geschlecht', T.GeschlechtCode),
		Fuehrerausweis = T.FuehrerAusw,
		DeutschMuendlich = T.DeutschM,
		DeutschSchriftlich = T.DeutschS,
		PCKenntnisse = T.PCKenntnisse,
		T.FaLeistungID,
		T.BaPersonID,
		Branchen = dbo.fnLOVTextListe('KaBranche', T.BrancheCodes),
		ProgrammCode
	FROM	@tmp T
		LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = T.BaPersonID
	WHERE	T.LehrberufCode = @sLehrberufCode
	AND		T.ProgrammCode = @sProgCode
	AND		(@sGeschlCode = 0 OR T.GeschlechtCode = @sGeschlCode)
	AND		(@ZustaendigKaID IS NULL OR T.ZustaendigKA = @ZustaendigKaID)
	ORDER BY NameVorname ASC


END ELSE IF (@sProgCode = 3 OR @sProgCode = 4 OR @sProgCode = 5) BEGIN
	-- Only keep data matching with Branche	
	SELECT	Name = PRS.Name,
		Vorname = PRS.Vorname,
		NameVorname = PRS.NameVorname,
		Geschlecht = dbo.fnLOVText('Geschlecht', T.GeschlechtCode),
		Fuehrerausweis = T.FuehrerAusw,
		DeutschMuendlich = T.DeutschM,
		DeutschSchriftlich = T.DeutschS,
		PCKenntnisse = T.PCKenntnisse,
		T.FaLeistungID,
		T.BaPersonID,
		Branchen = dbo.fnLOVTextListe('KaBranche', T.BrancheCodes),
		ProgrammCode
	FROM	@tmp T
		LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = T.BaPersonID
	WHERE	(',' + T.BrancheCodes + ',' like '%,' + CONVERT(varchar, @sBrancheCode) + ',%')
	AND		T.ProgrammCode = @sProgCode
	AND		(@sGeschlCode = 0 OR T.GeschlechtCode = @sGeschlCode)
	AND		(@ZustaendigKaID IS NULL OR T.ZustaendigKA = @ZustaendigKaID)
	ORDER BY NameVorname ASC
END ELSE BEGIN
	SELECT	Name = PRS.Name,
		Vorname = PRS.Vorname,
		NameVorname = PRS.NameVorname,
		Geschlecht = dbo.fnLOVText('Geschlecht', T.GeschlechtCode),
		Fuehrerausweis = T.FuehrerAusw,
		DeutschMuendlich = T.DeutschM,
		DeutschSchriftlich = T.DeutschS,
		PCKenntnisse = T.PCKenntnisse,
		T.FaLeistungID,
		T.BaPersonID,
		Branchen = dbo.fnLOVTextListe('KaBranche', T.BrancheCodes),
		ProgrammCode
	FROM	@tmp T
		LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = T.BaPersonID
	ORDER BY NameVorname ASC
END

END
GO