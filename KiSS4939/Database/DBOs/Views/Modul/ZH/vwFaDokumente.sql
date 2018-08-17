SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwFaDokumente
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwFaDokumente.sql $
  $Author: Mmarghitola $
  $Modtime: 20.09.10 18:56 $
  $Revision: 10 $
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

=================================================================================================*/

CREATE VIEW [dbo].[vwFaDokumente]
AS

SELECT [FaDokumenteID]
      ,[FaLeistungID]
      ,[Vertraulich]
      ,[DatumErstellung]
      ,[FaDokStatusCode]
      ,[StatusLetztUserID]
      ,[StatusLetztDatum]
      ,[Absender]
      ,[Absender_Freitext]
      ,[Adressat]
      ,[Adressat_Freitext]
      ,[Stichwort]
      ,[FaDokVerwendungCode]
      ,[DocumentID]
      ,[FaDokThemaCode]
      ,[BaPersonID]
      ,[VisumXTaskID]
      ,[FaDokVisumStatusCode]
      ,[VisumStatusDatum]
      ,[VisumStatusUserID]
      ,[Bemerkung]
      ,[NichtKlibuRelevant]
      ,[ErstelltUserID]
      ,[ErstelltDatum]
      ,[MutiertUserID]
      ,[MutiertDatum]
      ,[FaDokumenteTS]
      ,[MigHerkunftCode]
  FROM [dbo].[FaDokumente]
   
UNION ALL

-- Generierte IK-Auszüge mit den FaDokumenten dynamisch zusammen darstellen und zwar in allen relevanten Fällen (ohne dafür für jeden Fall ein neues FaDokument zu erzeugen)
SELECT 
	[FaDokumenteID] = -1,
	[FaLeistungID] = LEI.FaLeistungID,
	[Vertraulich] = 0,	-- Nicht vertraulich
	[DatumErstellung] = IKA.ImportDatum,
	[FaDokStatusCode] = 2,	-- FaDokStatusCode aktuell
	[StatusLetztUserID] = NULL,
	[StatusLetztDatum] = NULL,
	[Absender] = (SELECT TOP 1 BaInstitutionID FROM BaInstitution WHERE Name = 'SVA Zürich'),
	[Absender_Freitext] = NULL,
	[Adressat] = NULL,
	[Adressat_Freitext] = NULL,
	[Stichwort] = 'SVA: IK-Auszug von ' + CONVERT(varchar, IKA.JahrVon) + ' bis ' + CONVERT(varchar, IKA.JahrBis) + ' für ' + PER.NameVorname, -- Stichwort
	[FaDokVerwendungCode] = 1, -- FaDokVerwendung	Eingang
	[DocumentID] = IKA.DocumentID,
	[FaDokThemaCode] = 5, -- 5	Versicherungen und Ersatzeinkommen 
	[BaPersonID] = PER.BaPersonID,
	[VisumXTaskID] = NULL,
	[FaDokVisumStatusCode] = NULL,
	[VisumStatusDatum] = NULL,
	[VisumStatusUserID] = NULL,
	[Bemerkung] =
		CASE 
			WHEN IKA.SstIkAuszugAnforderungCode = 1 THEN 'Automatisch angeforderter IK-Auszug (Grund: Genehmigung 1.Finanzplan)'
			WHEN IKA.SstIkAuszugAnforderungCode = 2 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 2 Jahren)'
			WHEN IKA.SstIkAuszugAnforderungCode = 3 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 5 Jahren)'
			WHEN IKA.SstIkAuszugAnforderungCode = 4 THEN 'Manuell angeforderter IK-Auszug' + ISNULL(' durch ' + USR.DisplayText, '')
			ELSE ''
		END,
	[NichtKlibuRelevant] = 0,
	[ErstelltUserID] = NULL,
	[ErstelltDatum] = NULL,
	[MutiertUserID] = NULL,
	[MutiertDatum] = NULL,
	[FaDokumenteTS] = NULL,
	[MigHerkunftCode] = NULL
FROM vwSstIKAuszug IKA
	INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.BaPersonID = IKA.BaPersonID 
	LEFT JOIN dbo.vwUser USR WITH (READUNCOMMITTED) ON USR.UserID = IKA.AnforderungUserID
	INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID FROM FaLeistung WHERE FaFallID = FAP.FaFallID AND FaProzessCode = 200 ORDER BY DatumVon DESC)	-- Aktuellste aktive Fallführung
	INNER JOIN dbo.vwPersonSimple PER WITH (READUNCOMMITTED) ON PER.BaPersonID = IKA.BaPersonID
WHERE IKA.DocumentID IS NOT NULL AND IKA.Deaktiviert = 0


