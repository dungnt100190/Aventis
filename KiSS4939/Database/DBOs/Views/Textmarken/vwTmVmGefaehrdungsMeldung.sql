SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmVmGefaehrdungsMeldung;
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle VmGefaehrdungsMeldung.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmVmGefaehrdungsMeldung;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW dbo.vwTmVmGefaehrdungsMeldung
AS
SELECT
  GMD.VmGefaehrdungsMeldungID,
  GMD.FaLeistungID,
  DatumEingang = CONVERT(VARCHAR(10), GMD.DatumEingang, 104), 
  Kontaktveranlasser = lovGF.Text, 
  GefaehrdungNSB = dbo.fnLOVTextListe('VmGefaehrdungNSB', GMD.VmGefaehrdungNSBCodes),
  Themen = dbo.fnLOVTextListe('FaThema', GMD.FaThemaCodes), 
  GMD.Ausgangslage, 
  GMD.Auflagen, 
  GMD.Ueberpruefung, 
  GMD.Konsequenzen, 
  AuflageDatum  = CONVERT(VARCHAR(10), GMD.AuflageDatum, 104)
FROM dbo.VmGefaehrdungsMeldung GMD WITH (READUNCOMMITTED)
LEFT JOIN dbo.XLovCode lovGF ON lovGF.LOVName = 'FaKontaktveranlasser' and lovGF.Code = GMD.FaKontaktveranlasserCode
;
GO
