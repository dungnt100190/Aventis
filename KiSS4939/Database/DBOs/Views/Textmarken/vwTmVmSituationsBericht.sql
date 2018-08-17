SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmSituationsBericht;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmSituationsBericht.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmSituationsBericht;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmSituationsBericht
AS
SELECT
  BER.VmSituationsBerichtID, 
  BER.FaLeistungID, 
  AntragDatum = CONVERT(VARCHAR(10), BER.AntragDatum, 104), 
  TypSHAntrag = lovAN.Text, 
  Themen = dbo.fnLOVTextListe('FaThema', BER.FaThemaCodes), 
  BerichtFinanzen = dbo.fnXConvertRTF2Text(BER.BerichtFinanzen), 
  ZielPrognose = dbo.fnXConvertRTF2Text(BER.ZielPrognose), 
  AntragText = dbo.fnXConvertRTF2Text(BER.AntragText), 
  Autor = USR.VornameName
FROM dbo.VmSituationsBericht BER WITH (READUNCOMMITTED)
LEFT JOIN dbo.vwUser USR ON USR.UserID = BER.UserID
LEFT JOIN dbo.XLovCode lovAN ON lovAN.LOVName = 'VMTypSHAntrag' and lovAN.Code = BER.VMTypSHAntragCode
;
GO
