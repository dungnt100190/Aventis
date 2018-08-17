SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmZielvereinbarung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmZielvereinbarung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
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
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmZielvereinbarung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmZielvereinbarung]
AS

SELECT
	FaZielvereinbarungID,
	Thema,
	Ziel1,
	Ziel2,
	Ziel3,
	Handlungsschritt1Wer,
	Handlungsschritt1Was,
	Handlungsschritt1Wann = CONVERT(varchar, Handlungsschritt1Wann, 104),
	Handlungsschritt2Wer,
	Handlungsschritt2Was,
	Handlungsschritt2Wann = CONVERT(varchar, Handlungsschritt2Wann, 104),
	Handlungsschritt3Wer,
	Handlungsschritt3Was,
	Handlungsschritt3Wann = CONVERT(varchar, Handlungsschritt3Wann, 104),
	AuftragAnKlient1Was,
	AuftragAnKlient1Wann = CONVERT(varchar, AuftragAnKlient1Wann, 104),
    AuftragAnKlient2Was,
	AuftragAnKlient2Wann = CONVERT(varchar, AuftragAnKlient2Wann, 104),
	VorgeseheneGespraeche = GespraecheGeplant,
	AuswertungGeplant = CONVERT(varchar, DatumAuswertungGeplant, 104),
	SituationThema = dbo.fnLOVText('FaZielSituationAuswertung', SituationAuswertungCode),
	Zielauswertung1 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel1AuswertungCode),
	Zielauswertung2 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel2AuswertungCode),
	Zielauswertung3 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel3AuswertungCode),
	Durchgef1 = CONVERT(bit, IsNull(Handlungsschritt1Durchgefuehrt, 0)),
	Hilfreich1 = CONVERT(bit, IsNull(Handlungsschritt1Hilfreich, 0)),
	Durchgef2 = CONVERT(bit, IsNull(Handlungsschritt2Durchgefuehrt, 0)),
	Hilfreich2 = CONVERT(bit, IsNull(Handlungsschritt2Hilfreich, 0)),
	Durchgef3 = CONVERT(bit, IsNull(Handlungsschritt3Durchgefuehrt, 0)),
	Hilfreich3 = CONVERT(bit, IsNull(Handlungsschritt3Hilfreich, 0)),
	AuftragErledigt1 = CONVERT(bit, IsNull(AuftragAnKlient1Erledigt, 0)),
	AuftragHilfreich1 = CONVERT(bit, IsNull(AuftragAnKlient1Hilfreich, 0)),
	AuftragErledigt2 = CONVERT(bit, IsNull(AuftragAnKlient2Erledigt, 0)),
	AuftragHilfreich2 = CONVERT(bit, IsNull(AuftragAnKlient2Hilfreich, 0)),
	DurchgefGespraeche = GespraecheDurchgefuehrt,
	AuswertungDurchgef = CONVERT(varchar, DatumAuswertungDurchgefuehrt, 104)
FROM dbo.FaZielvereinbarung  WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmZielvereinbarung] TO [tools_access]