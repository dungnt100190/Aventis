SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject ExpLOV
GO
/*===============================================================================================
  $Revision: 4$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE  PROCEDURE [dbo].[ExpLOV]
 (@CodeGruppe varchar(200))
AS

SELECT GRP.CodeGruppeText,INH.CodeElement,INH.CodeText1,
       Alpha = CASE WHEN APH.CodeGruppe IS NOT NULL THEN 'x' ELSE '' END
FROM ExportDB..CODE_CodeGruppe GRP
     INNER JOIN ExportDB..CODE_CodeInhalt INH on INH.CodeGruppe = GRP.CodeGruppe AND
                                                 INH.Herkunft IS NULL
     LEFT  JOIN ExportDB..CODE_CodeInhalt APH on APH.CodeGruppe = INH.CodeGruppe AND
                                                 APH.Herkunft = 'ALPHA' AND
                                                 upper(LTrim(replace(APH.CodeText1,char(160),' '))) = upper(INH.CodeText1)
WHERE Upper(GRP.CodeGruppeText) like '%' + Upper(@CodeGruppe) + '%'

UNION ALL

SELECT GRP.CodeGruppeText + ' (Alpha)' ,APH.CodeElement,APH.CodeText1,
       Alpha = 'unbenutzt'
FROM ExportDB..CODE_CodeGruppe GRP
     INNER JOIN ExportDB..CODE_CodeInhalt APH on APH.CodeGruppe = GRP.CodeGruppe AND
                                                 APH.Herkunft = 'ALPHA'
     LEFT  JOIN ExportDB..CODE_CodeInhalt INH on INH.CodeGruppe = GRP.CodeGruppe AND
                                                 INH.Herkunft IS NULL AND
                                                 INH.CodeText1 = APH.CodeText1
WHERE Upper(GRP.CodeGruppeText) like '%' + Upper(@CodeGruppe) + '%' AND
      INH.CodeGruppe IS NULL

ORDER BY 1,2
