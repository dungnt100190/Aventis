SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmArbeit
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmArbeit.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmArbeit.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmArbeit]
AS

SELECT
  BaPersonID,
  InstitutionName = I.Name,
  ArbeitgeberEinzeilig = CASE
    WHEN A.BaInstitutionID IS NULL THEN replace(CONVERT(varchar(500), A.Adresse),char(13) + char(10) ,', ')
    ELSE I.Name + IsNull(', ' + I.Adresse, '')
  END,
  Arbeitgeber = CASE
    WHEN A.BaInstitutionID IS NULL THEN CAST(A.Adresse AS varchar)
    ELSE I.Name
  END,
  Pensum = CONVERT(varchar, A.Pensum) + '%',
  Seit = CONVERT(varchar, A.DatumVon, 104),
  VonBis = CONVERT(varchar, A.DatumVon, 104) + ' - ' + CONVERT(varchar, A.DatumBis, 104),
  DatumVon = A.DatumVon,
  DatumBis = A.DatumBis
FROM dbo.BaArbeit A WITH (READUNCOMMITTED)
	LEFT OUTER JOIN dbo.vwInstitution I ON I.BaInstitutionID = A.BaInstitutionID

GO
GRANT SELECT ON [dbo].[vwTmArbeit] TO [tools_access]