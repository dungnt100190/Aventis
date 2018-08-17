SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaTransfer;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen der Textmarke
  -
  RETURNS: Alle Datensätze von der Tabelle KaTransfer
=================================================================================================
  TEST:    SELECT TOP 10 <Columns> FROM dbo.vwTmKaTransfer;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaTransfer
AS
SELECT
  KAT.KaTransferID,
  KAT.FaLeistungID,
  KAT.TelErstkontaktDat,
  KAT.DatumVG,
  KAT.AllgZiele,
  KAT.Bewerbungsstrategie,
  KAT.MuendAufforderungDat1,
  KAT.MuendAufforderungDat2,
  KAT.MuendAufforderungBem1,
  KAT.MuendAufforderungBem2,
  KAT.AustrittDat,
  KAT.AustrittGrund,
  KAT.AustrittCode,
  KAT.AustrittBem
FROM dbo.KaTransfer KAT WITH (READUNCOMMITTED);
GO
