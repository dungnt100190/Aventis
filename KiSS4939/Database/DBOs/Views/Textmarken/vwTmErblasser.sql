SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmErblasser
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/vwTmErblasser.sql $
  $Author: Ckaeser $
  $Modtime: 25.06.09 12:53 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Views/vwTmErblasser.sql $
 * 
 * 2     25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 1     11.09.08 14:52 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE VIEW dbo.vwTmErblasser
AS

SELECT FaLeistungID = ERB.FaLeistungID,
       AHVNr        = ERB.AHVNummer,
       DerDes       = CASE
                        WHEN ERB.Anrede LIKE '%frau%' THEN 'r'
                        WHEN ERB.Anrede LIKE '%herr%' THEN 's'
                      END,
       DerDesBesch  = CASE
                        WHEN ERB.Anrede like '%frau%' THEN 'r'
                        WHEN ERB.Anrede like '%herr%' THEN 's'
                      END,

       DieDer       = CASE
                        WHEN ERB.Anrede LIKE '%frau%' THEN 'die'
                        WHEN ERB.Anrede LIKE '%herr%' THEN 'der'
                        ELSE 'die/der'
                      END,
       DieDerBesch  = CASE
                        WHEN ERB.Anrede like '%frau%' THEN 'die'
                        WHEN ERB.Anrede like '%herr%' THEN 'der'
                        ELSE 'die/der'
                      END,

       Todesdatum                   = CONVERT(VARCHAR, ERB.Todesdatum, 104),
       TodesdatumBesch              = CONVERT(VARCHAR, ERB.Todesdatum, 104),
       TodesdatumOderBereich        = ISNULL(ERB.TodesDatumText, CONVERT(VARCHAR, ERB.Todesdatum,104)),
       Todesort                     = ERB.TodesOrt,

       ErblasserAdresseEinzeln      = ERB.Strasse + ISNULL(', ' + ERB.Ort, ''),
       ErblasserAdresseEinzelnBesch = ERB.Strasse + ISNULL(', ' + ERB.Ort, ''),
       ErblasserAnrede              = ERB.Anrede,
       ErblasserAnredeBesch         = ERB.Anrede,
       ErblasserElternnamen         = ERB.Elternnamen,
       ErblasserElternnamenBesch    = ERB.Elternnamen,
       ErblasserFamilienNamen       = ERB.FamilienNamen,
       ErblasserFamilienNamenBesch  = ERB.FamilienNamen,
       ErblasserGeburtsdatum        = CONVERT(VARCHAR, Geburtsdatum, 104),
       ErblasserGeburtsdatumBesch   = CONVERT(VARCHAR, Geburtsdatum, 104),
       ErblasserHeimatorte          = ERB.Heimatorte,
       ErblasserHeimatorteBesch     = ERB.Heimatorte,
       ErblasserVornamen            = ERB.Vornamen,
       ErblasserVornamenBesch       = ERB.Vornamen,
       ErblasserZivilstand          = ZIV.Text,
       ErblasserZivilstandBesch     = ERB.Zivilstand,
       lasserLasserin               = CASE
                                        WHEN ERB.Anrede LIKE '%frau%' THEN 'Erblasserin'
                                        WHEN ERB.Anrede LIKE '%herr%' THEN 'Erblasser'
                                      END,

       ErblasserInfo1      = ISNULL(ERB.Anrede + ' ', '') +
                             ISNULL(ERB.FamilienNamen + ' ', '') +
                             ISNULL(ERB.Vornamen, '') +
                             ISNULL(', ' + ERB.Elternnamen, '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + Heimatorte, '') +
                             ISNULL(', wohnhaft gewesen in ' + ERB.Ort + ISNULL(', ' + ERB.Strasse, ''), '') +
                             ISNULL(', mit Aufenthalt in ' + ERB.Aufenthalt, ''),
       ErblasserInfo2      = ISNULL('am ' + CONVERT(VARCHAR, ERB.TodesDatum, 104), '') +
                             ISNULL(' in ' + ERB.TodesOrt, '') + ' verstorbenen' +
                             ISNULL(' ' + ERB.Vornamen, '') +
                             ISNULL(' ' + ERB.FamilienNamen, '') +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', wohnhaft gewesen in ' + ERB.Ort + ISNULL(', ' + ERB.Strasse, ''), ''),
       ErblasserInfo3      = (ERB.Elternnamen + '') +
                             ISNULL(', ' + ERB.Zivilstand, ISNULL(', ' + ZIV.Text, '')) +
                             ISNULL(', geboren am ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', ' + ERB.Strasse, '') +
                             ISNULL(', ' + ERB.Ort, '') +
                             ISNULL(', Aufenthalt: ' + ERB.Aufenthalt, ''),
       ErblasserInfo4      = ISNULL(ERB.Anrede + ' ', '') +
                             ISNULL(ERB.FamilienNamen + ' ', '') +
                             ISNULL(ERB.Vornamen, '') +
                             ISNULL(', geb. ' + CONVERT(VARCHAR, ERB.Geburtsdatum), '') +
                             ISNULL(', ' + ERB.Heimatorte, '') +
                             ISNULL(', wohnhaft gewesen ' + ISNULL(ERB.Strasse + ', ', ''), '') + ERB.Ort

FROM dbo.VmErblasser     ERB WITH (READUNCOMMITTED) 
  LEFT JOIN dbo.XLOVCode ZIV WITH (READUNCOMMITTED) ON ZIV.LOVName = 'VmErbeZivilstand'
                                                   AND ZIV.Code = ERB.ZivilstandCode;

GO