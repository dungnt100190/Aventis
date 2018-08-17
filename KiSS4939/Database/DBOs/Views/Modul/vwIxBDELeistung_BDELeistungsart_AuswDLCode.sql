SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwIxBDELeistung_BDELeistungsart_AuswDLCode;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET ANSI_PADDING ON;
GO
SET ANSI_WARNINGS ON;
GO
SET CONCAT_NULL_YIELDS_NULL ON;
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ARITHABORT ON;
GO

/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Indexed view to improve performance of BDELeistung with INNER JOIN on BDELeistungsart.
           Usage for example in dbo.fnFaIsPersonClientByRule
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode;
=================================================================================================*/

CREATE VIEW dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode WITH SCHEMABINDING
AS
SELECT
  -- BDELeistung
  BaPersonID             = LEI.BaPersonID,
  Datum                  = LEI.Datum,
  DauerSUM               = SUM(ISNULL(LEI.Dauer, 0.0)),
  
  -- BDELeistungsart
  AuswDienstleistungCode = BLA.AuswDienstleistungCode,
  cBig                   = COUNT_BIG(*)
FROM dbo.BDELeistung             LEI
  INNER JOIN dbo.BDELeistungsart BLA ON BLA.BDELeistungsartID = LEI.BDELeistungsartID
GROUP BY LEI.BaPersonID, LEI.Datum, BLA.AuswDienstleistungCode;
GO

-------------------------------------------------------------------------------
-- create indexes
-------------------------------------------------------------------------------
CREATE UNIQUE CLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO

CREATE NONCLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_DauerSUM_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [DauerSUM] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO