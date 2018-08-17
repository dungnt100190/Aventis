SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spBFSPendenzen_Check;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sostat/spBFSPendenzen_Check.sql $
  $Author: Rhesterberg $
  $Modtime: 23.08.10 11:58 $
  $Revision: 16 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    EXECUTE dbo.spBFSPendenzen_Check 2009;
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sostat/spBFSPendenzen_Check.sql $
 * 
 * 16    23.08.10 11:59 Rhesterberg
 * #6352 Sostat-Ablieferung ohne KliBu
 * 
 * 15    23.07.10 7:47 Cjaeggi
 * #4167: Tabs to spaces
 * 
 * 14    13.07.10 9:35 Rhesterberg
 * #6208: Stichtag-Regel bei Dossiergenerierung überprüfen
 * 
 * 13    7.07.10 9:28 Cjaeggi
 * #4167: Fixed failing pendenzen-job items, moved vwPerson to prevent
 * failure due to changed BaAdresse structure
 * 
 * 12    11.01.10 17:41 Ckaeser
 * 
 * 11    3.11.09 23:15 Rstahel
 * 
 * 10    25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 9     26.05.09 11:54 Ckaeser
 * Kosmetik
 * 
 * 8     17.02.09 9:42 Ckaeser
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE [dbo].[spBFSPendenzen_Check]
(
	@Erhebungsjahr INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Einstellung aus XConfig holen, ob Sozialdiesnt eine Klientenbuchhaltung im KISS führt:	
	DECLARE @HatKlientenBuchhaltung BIT
	DECLARE @DatumKonfiguration DATETIME
	SET @DatumKonfiguration = dbo.fnDateSerial(@Erhebungsjahr, 12, 31)
	SELECT @HatKlientenBuchhaltung = CONVERT(BIT, CASE
		WHEN CONVERT(VARCHAR, dbo.fnXConfig('System\KliBu\KliBuSys', @DatumKonfiguration)) = 'Integriert' 
			THEN 1 
		ELSE 0
	END)

  
	SELECT DISTINCT
		TaskSenderCode   = 5,      -- DbScript
		TaskReceiverCode = 1,      -- Person
		TaskTypeCode     = 14,     -- Kontrolle
		TaskStatusCode   = 1,      -- Pendent
		CreateDate       = LEI.DatumVon,
		StartDate        = NULL,
		ExpirationDate   = DateAdd(WEEK, 6, LEI.DatumVon),
		Subject          = 'Anfangszustand Sostat erfassen',
		TaskDescription  = 'Anfangszustand im Fall erfassen  - Sostat Felder',
		FaLeistungID     = LEI.FaLeistungID,
		FaFallID         = LEI.FaFallID,
		BaPersonID       = LEI.BaPersonID,
		SenderID         = LEI.UserID,
		ReceiverID       = LEI.UserID
	FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
	INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
	WHERE 1 = 1
		-- AND PRS.Testperson = 0
		AND PRS.Fiktiv = 0
		AND (LEI.ModulID = 3 OR (LEI.ModulID = 4 AND LEI.FaProzessCode = 401)) -- Alimente
		AND @Erhebungsjahr BETWEEN YEAR(LEI.DatumVon) AND ISNULL(YEAR(LEI.DatumBis), 9999)
		AND YEAR(LEI.DatumVon) >= ISNULL(dbo.fnXConfig('System\Sostat\AnfangszustandAb', GETDATE()), 2009)
		AND (LEI.DatumBis IS NULL OR NOT EXISTS (
			SELECT TOP 1 1 FROM dbo.FaLeistung SLEI WITH (READUNCOMMITTED)
			WHERE (SLEI.ModulID = 3 OR (SLEI.ModulID = 4 AND SLEI.FaProzessCode = 401))
				AND SLEI.BaPersonID = LEI.BaPersonID
				AND @Erhebungsjahr BETWEEN YEAR(SLEI.DatumVon) 
					AND ISNULL(YEAR(SLEI.DatumBis), @Erhebungsjahr)
				AND SLEI.FaLeistungID <> LEI.FaLeistungID
				AND LEI.DatumBis < SLEI.DatumVon
				AND DATEDIFF(MONTH, LEI.DatumBis, SLEI.DatumVon) < 6
		))
    
	    -- und es gibt eine Zahlung zu der Leistung
		-- Neue Anforderung vom BFS:
		-- Werden einem Klienten nur die Krankenkassenprämien bezahlt gilt dies gemäss BFS nicht als Sozialhilfe 
		-- und soll bei der Ablieferung der SOSTAT-Daten nicht berücksichtigt werden
		-- (siehe auch NewsletterD.pdf im Ticket 6208).
		AND EXISTS (
			SELECT TOP 1 1 FROM dbo.KbBuchung BUC WITH (READUNCOMMITTED)
			LEFT JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = BUC.BgBudgetID
			LEFT JOIN dbo.BgFinanzplan BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BDG.BgFinanzplanID
			LEFT JOIN dbo.BgPosition POS WITH (READUNCOMMITTED) ON POS.BgBudgetID = BDG.BgBudgetID
			LEFT JOIN dbo.BgPositionsArt POA WITH (READUNCOMMITTED) ON POA.BgPositionsArtID = POS.BgPositionsArtID
			
			WHERE (
					-- wenn KLIBU vorhanden nur solche mit gültiger BelegNr oder 
					-- wenn keine KLIBU vorhanden nur solche mit Status verbucht:
					(@HatKlientenBuchhaltung = 1 AND BUC.BelegNr IS NOT NULL) OR 
					(@HatKlientenBuchhaltung = 0 AND BUC.KbBuchungStatusCode = 13)
				)
			    -- Buchungsdatum innerhalb 6 Monaten:
				AND dbo.fnDateOf(BUC.BelegDatum) >= DATEADD(MONTH, -6, GETDATE())   
				-- nur Buchungen aus Inkasso und Sozialhilfe berücksichtigen:
				AND (BUC.FaLeistungID = LEI.FaLeistungID OR BFP.FaLeistungID = LEI.FaLeistungID)                         
				-- med. Grundversorgung nicht relevant:
				AND POA.BgGruppeCode NOT IN (3202)                                  
		)
    
		-- und Pendenz nicht bereits erfasst ist
		AND NOT EXISTS (
			SELECT TOP 1 1 FROM dbo.XTask TSK WITH (READUNCOMMITTED)
			WHERE TSK.FaFallID = LEI.FaFallID
				AND TSK.BaPersonID = LEI.BaPersonID
				AND TSK.TaskSenderCode = 5
		)
END


