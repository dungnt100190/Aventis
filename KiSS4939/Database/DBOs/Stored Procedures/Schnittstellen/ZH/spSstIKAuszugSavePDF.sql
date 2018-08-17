SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstIKAuszugSavePDF
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spSstIKAuszugSavePDF.sql $
  $Author: Rstahel $
  $Modtime: 28.07.10 23:19 $
  $Revision: 6 $
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
  $Log:
 * 
=================================================================================================*/


CREATE PROCEDURE [dbo].[spSstIKAuszugSavePDF]
(
  @IKAuszugID   int,
  @FileBinary	image
)
AS
BEGIN

  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

	DECLARE @ImportDate datetime
	DECLARE @DocID int

	SELECT @ImportDate = ImportDatum FROM SstIKAuszug WHERE SstIKAuszugID = @IKAuszugID

	SELECT @ImportDate

	INSERT INTO XDocument (DateCreation, FileBinary, DocFormatCode, FileExtension, DocReadonly) 
	VALUES
	(
		@ImportDate, 
		@FileBinary, 
		3,	-- DocFormatCode = PDF
		'.pdf', 
		1		-- Readonly
	)

	SET @DocID = SCOPE_IDENTITY() 
	
	UPDATE SstIKAuszug SET DocumentID = @DocID WHERE SstIKAuszugID = @IKAuszugID
	
	-- Pendenzen erstellen

	-- Erstelle Pendenz für aktuellste W-Leistung, in der die Person des Auszugs unterstützt ist (falls vorhanden)
	-- aktuellste W-Leistung: Zuerst nicht abgeschlossene W-Leistung, falls keine nicht abgeschlossene W-Leistung existiert Fallback auf zuletzt eröffnete W-Leistung

	INSERT INTO XTask
	(TaskTypeCode, TaskStatusCode, Subject, TaskDescription, SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode, FaFallID, FaLeistungID, BaPersonID)
		SELECT TOP 1
			1, -- TaskTypeCode = Überprüfung
			1, -- TaskStatusCode = Pendent
			'SVA IK-Auszug von ' + CONVERT(varchar, IKA.JahrVon) + ' bis ' + CONVERT(varchar, IKA.JahrBis),
			CASE 
				WHEN IKA.SstIkAuszugAnforderungCode = 1 THEN 'Der angeforderte IK-Auszug (Automatische Anfrage, Grund: Genehmigung 1.Finanzplan)'
				WHEN IKA.SstIkAuszugAnforderungCode = 2 THEN 'Der angeforderte IK-Auszug (Automatische Anfrage, Grund: WSH seit 2 Jahren)'
				WHEN IKA.SstIkAuszugAnforderungCode = 3 THEN 'Der angeforderte IK-Auszug (Automatische Anfrage, Grund: WSH seit 5 Jahren)'
				WHEN IKA.SstIkAuszugAnforderungCode = 4 THEN 'Der manuell angeforderte IK-Auszug'
				ELSE 'Der angeforderte IK-Auszug'
			END + ' ist von der SVA eingetroffen und ab sofort unter dem Thema „Versicherungen und Ersatzeinkommen“ der Dokumentenablage verfügbar.',
			IKA.AnforderungUserID,
			1, -- TaskSenderCode = Person
			LEI.UserID,
			1, -- TaskReceiverCode = Person
			LEI.FaFallID,
			LEI.FaLeistungID,
			IKA.BaPersonID
		FROM vwSstIKAuszug IKA
		INNER JOIN BgFinanzplan_BaPerson FPP ON FPP.BaPersonID = IKA.BaPersonID 
		INNER JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = FPP.BgFinanzplanID
		INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = FIP.FaLeistungID AND LEI.FaProzessCode = 300
		WHERE SstIKAuszugID = @IKAuszugID 
		ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN 1 ELSE 0 END DESC,LEI.DatumVon DESC
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
