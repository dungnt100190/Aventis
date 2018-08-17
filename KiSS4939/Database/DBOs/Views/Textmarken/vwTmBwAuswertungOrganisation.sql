SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBwAuswertungOrganisation;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View for Bookmarks in BwAuswertungOrganisation
  -
  RETURNS: Data used for bookmarks of given table
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmBwAuswertungOrganisation;
=================================================================================================*/

CREATE VIEW dbo.vwTmBwAuswertungOrganisation
AS
SELECT 
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  BwAuswertungOrganisationID = BAO.BwAuswertungOrganisationID,
  FaLeistungID               = BAO.FaLeistungID,
  BwEinsatzvereinbarungID    = ESV.BwEinsatzvereinbarungID,
  
  -----------------------------------------------------------------------------
  -- Other data
  -----------------------------------------------------------------------------
  TypD                  = dbo.fnGetLOVMLText('BwTyp', ESV.BwTypCode, 1),
  TypF                  = dbo.fnGetLOVMLText('BwTyp', ESV.BwTypCode, 2),
  TypI                  = dbo.fnGetLOVMLText('BwTyp', ESV.BwTypCode, 3),
  
  ZustaendigBW          = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
  
  ErstellungEV          = CONVERT(VARCHAR, ESV.ErstellungEV, 104),
  AuswertungAm          = CONVERT(VARCHAR, BAO.AuswertungAm, 104),
  
  Ziele                 = ESV.Ziele,
  ZieleNORTF            = ESV.Ziele,
  
  ZieleErreichtD        = dbo.fnGetLOVMLText('FaJaNeinTeilweise', BAO.ZieleErreicht, 1),
  ZieleErreichtF        = dbo.fnGetLOVMLText('FaJaNeinTeilweise', BAO.ZieleErreicht, 2),
  ZieleErreichtI        = dbo.fnGetLOVMLText('FaJaNeinTeilweise', BAO.ZieleErreicht, 3),
  
  ZieleBegruendung      = BAO.ZieleBegruendung,
  ZieleBegruendungNORTF = BAO.ZieleBegruendung,
  
  KostenHELBVerfuegungD = dbo.fnGetLOVMLText('JaNein', CASE WHEN PRS.HilfslosenEntschaedigungCode IN (4, 5) THEN 1 ELSE 0 END, 1),
  KostenHELBVerfuegungF = dbo.fnGetLOVMLText('JaNein', CASE WHEN PRS.HilfslosenEntschaedigungCode IN (4, 5) THEN 1 ELSE 0 END, 2),
  KostenHELBVerfuegungI = dbo.fnGetLOVMLText('JaNein', CASE WHEN PRS.HilfslosenEntschaedigungCode IN (4, 5) THEN 1 ELSE 0 END, 3),

  KostenELEmpfaengerD   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenELEmpfaenger, 0), 1),
  KostenELEmpfaengerF   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenELEmpfaenger, 0), 2),
  KostenELEmpfaengerI   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenELEmpfaenger, 0), 3),

  KostenBeitragKantonD   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragKanton, 0), 1),
  KostenBeitragKantonF   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragKanton, 0), 2),
  KostenBeitragKantonI   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragKanton, 0), 3),
  
  KostenBeitragPID   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragPI, 0), 1),
  KostenBeitragPIF   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragPI, 0), 2),
  KostenBeitragPII   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBeitragPI, 0), 3),

  KostenWeitereBeitraegeD   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenWeitereBeitraege, 0), 1),
  KostenWeitereBeitraegeF   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenWeitereBeitraege, 0), 2),
  KostenWeitereBeitraegeI   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenWeitereBeitraege, 0), 3),
  
  KostenBSVBeitragD     = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBSVBeitrag, 0), 1),
  KostenBSVBeitragF     = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBSVBeitrag, 0), 2),
  KostenBSVBeitragI     = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenBSVBeitrag, 0), 3),

  KostenSelbstzahlerD   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenSelbstzahler, 0), 1),
  KostenSelbstzahlerF   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenSelbstzahler, 0), 2),
  KostenSelbstzahlerI   = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.KostenSelbstzahler, 0), 3),
  
  AbwesenheitKlient     = CONVERT(INT, ROUND(BAO.AbwesenheitKlient, 0)),
  
  IstBefristetD         = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.LeistungIstBefristet, 0), 1),
  IstBefristetF         = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.LeistungIstBefristet, 0), 2),
  IstBefristetI         = dbo.fnGetLOVMLText('JaNein', ISNULL(BAO.LeistungIstBefristet, 0), 3),
  
  IstUnbefristetD       = dbo.fnGetLOVMLText('JaNein', ISNULL(CASE BAO.LeistungIstBefristet WHEN 1 THEN 0 ELSE 1 END, 0), 1),
  IstUnbefristetF       = dbo.fnGetLOVMLText('JaNein', ISNULL(CASE BAO.LeistungIstBefristet WHEN 1 THEN 0 ELSE 1 END, 0), 2),
  IstUnbefristetI       = dbo.fnGetLOVMLText('JaNein', ISNULL(CASE BAO.LeistungIstBefristet WHEN 1 THEN 0 ELSE 1 END, 0), 3),
  
  BefristetBis          = CONVERT(VARCHAR, BAO.BefristetBis, 104),
  
  EintrittVonD          = dbo.fnGetLOVMLText('BwEintrittVon', BAO.BwEintrittVonCode, 1),
  EintrittVonF          = dbo.fnGetLOVMLText('BwEintrittVon', BAO.BwEintrittVonCode, 2),
  EintrittVonI          = dbo.fnGetLOVMLText('BwEintrittVon', BAO.BwEintrittVonCode, 3),

  AustrittNachD         = dbo.fnGetLOVMLText('BwAustrittNach', BAO.BwAustrittNachCode, 1),
  AustrittNachF         = dbo.fnGetLOVMLText('BwAustrittNach', BAO.BwAustrittNachCode, 2),
  AustrittNachI         = dbo.fnGetLOVMLText('BwAustrittNach', BAO.BwAustrittNachCode, 3),
  
  Vereinbarungen        = BAO.Vereinbarungen,
  
  -----------------------------------------------------------------------------
  -- Checkboxes (Attention: Length!!)
  -----------------------------------------------------------------------------
  Befr                  = BAO.LeistungIstBefristet,
  UnBefr                = CONVERT(BIT, CASE BAO.LeistungIstBefristet WHEN 1 THEN 0 ELSE 1 END),
  Helb                  = CONVERT(BIT, CASE WHEN PRS.HilfslosenEntschaedigungCode IS NOT NULL THEN 1 ELSE 0 END),
  ELEmpf                = BAO.KostenELEmpfaenger,  
  BtrgKntn              = BAO.KostenBeitragKanton,
  BtrgPI                = BAO.KostenBeitragPI,
  WtrBtrg               = BAO.KostenWeitereBeitraege,
  SelZah                = BAO.KostenSelbstzahler,
  Bsv                   = BAO.KostenBSVBeitrag

FROM dbo.BwAuswertungOrganisation     BAO WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung           LEI WITH (READUNCOMMITTED) ON BAO.FaLeistungID = LEI.FaLeistungID
  INNER JOIN dbo.BaPerson             PRS WITH (READUNCOMMITTED) ON LEI.BaPersonID = PRS.BaPersonID
  LEFT JOIN dbo.BwEinsatzvereinbarung ESV WITH (READUNCOMMITTED) ON LEI.FaLeistungID = ESV.FaLeistungID
GO