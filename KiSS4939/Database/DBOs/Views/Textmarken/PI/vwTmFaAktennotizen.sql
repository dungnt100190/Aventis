SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaAktennotizen;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmFaAktennotizen.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:59 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaAktennotizen
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 30 * FROM dbo.vwTmFaAktennotizen WHERE FaAktennotizenID = 64410
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmFaAktennotizen.sql $
 * 
 * 3     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 2     2.12.08 13:58 Cjaeggi
 * Changed LOV name
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmFaAktennotizen
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  FAN.FaAktennotizenID,
  FAN.BaPersonID,
  FAN.UserID,

  -----------------------------------------------------------------------------
  -- Others
  -----------------------------------------------------------------------------
  Autor = REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', ''),
  Datum = CONVERT(varchar, FAN.Datum, 104),

  KontaktartD = dbo.fnGetLOVMLText('FaKontaktart', FAN.KontaktArtCode, 1),
  KontaktartF = dbo.fnGetLOVMLText('FaKontaktart', FAN.KontaktArtCode, 2),
  KontaktartI = dbo.fnGetLOVMLText('FaKontaktart', FAN.KontaktArtCode, 3),

  DienstleistungD = dbo.fnGetLOVMLText('FaModulDienstleistungen', FAN.DienstleistungCode, 1),
  DienstleistungF = dbo.fnGetLOVMLText('FaModulDienstleistungen', FAN.DienstleistungCode, 2),
  DienstleistungI = dbo.fnGetLOVMLText('FaModulDienstleistungen', FAN.DienstleistungCode, 3),

  FAN.Stichworte,
  InhaltMITFMT = FAN.Inhalt,

  BeteiligtePersonenInstitutionenEinz = dbo.fnFaSplitBeteiligtePersonen(FAN.BeteiligtePersonen, 0, 1),
  BeteiligtePersonenInstitutionenMehrz = dbo.fnFaSplitBeteiligtePersonen(FAN.BeteiligtePersonen, 1, 1),

  ThemenD	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAN.ThemenCodes, NULL, 1),
  ThemenF	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAN.ThemenCodes, NULL, 2),
  ThemenI	= dbo.fnLOVMLColumnListe('FaLebensbereich', FAN.ThemenCodes, NULL, 3)

FROM dbo.FaAktennotizen FAN WITH(READUNCOMMITTED)
  INNER JOIN dbo.XUser USR WITH(READUNCOMMITTED) ON USR.UserID = FAN.UserID
GO