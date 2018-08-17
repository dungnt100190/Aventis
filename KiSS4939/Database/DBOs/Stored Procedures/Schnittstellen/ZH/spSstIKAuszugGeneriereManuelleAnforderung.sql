SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstIKAuszugGeneriereManuelleAnforderung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spSstIKAuszugGeneriereManuelleAnforderung.sql $
  $Author: Rstahel $
  $Modtime: 26.06.10 17:03 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
	This method requests IK-Auszüge depending on the specified AnforderungsCode
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spSstIKAuszugGeneriereManuelleAnforderung.sql $
 * 
 * 3     26.06.10 17:05 Rstahel
 * #5820: Diverse Anpassungen und Bugfixes
 * 
 * 2     3.05.10 20:14 Rstahel
 * #5820: SP angepasst
 * 
 * 1     26.04.10 11:01 Rstahel
=================================================================================================*/

CREATE PROCEDURE dbo.spSstIKAuszugGeneriereManuelleAnforderung
(
	@BaPersonID int,
	@JahrVon int,
	@UserID int
)
AS 
BEGIN
INSERT INTO SstIKAuszug
(
	BaPersonID,
	SstIkAuszugAnforderungCode,
	AnforderungUserID,
	Versichertennummer,
	JahrVon,
	JahrBis,
	Creator,
	Modifier
)
	SELECT DISTINCT
		BaPersonID = PER.BaPersonID,
		SstIkAuszugAnforderungCode = 4,
		AnforderungUserID = @UserID,
		Versichertennummer = ISNULL(PER.Versichertennummer, ''),
		JahrVon = @JahrVon,
		JahrBis = YEAR(GetDate()),			-- ...bis heute an
		Creator = dbo.fnGetDBRowCreatorModifier(@UserID),
		Modifier = dbo.fnGetDBRowCreatorModifier(@UserID)
	FROM BaPerson PER
	LEFT  JOIN vwSstIKAuszug IKA WITH (READUNCOMMITTED) ON IKA.BaPersonID = PER.BaPersonID AND IKA.SstIKAuszugAnforderungCode = 4 AND IKA.SstIkAuszugStatusCode IN (1, 2, 3, 4) -- Prüfe, ob es nicht schon einen pendenten Eintrag für eine automatischen Anforderung von diesem Typ gibt
	WHERE IKA.SstIKAuszugID IS NULL -- Es gibt noch keine automatische Anforderung von diesem Typ
	AND PER.BaPersonID = @BaPersonID
END
GO