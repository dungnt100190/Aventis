SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBgGetDokumente
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnBgGetDokumente.sql $
  $Author: Mmarghitola $
  $Modtime: 2.09.10 14:02 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt Informationen zu allen Dokumenten zurück, die mit einer bestimmten Position,
  deren Budget oder deren Finanzplan verknüpft sind.
  -
  RETURNS: Informationen zu den gefundenen Dokumenten
  -
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnBgGetDokumente.sql $
 * 
 * 1     2.09.10 14:04 Mmarghitola
 * #6587: Indexe anpassen, SQL optimieren
=================================================================================================*/

CREATE FUNCTION dbo.fnBgGetDokumente
(
  @BgPositionID int
)
RETURNS TABLE 
AS
RETURN 
(
  SELECT BDO.BgDokumentID,
      BgFinanzplanID = NULL,
      BgBudgetID = NULL,
      BDO.BgPositionID,
      BDO.BgDokumentTypCode,
      BDO.DocumentID,
      BDO.Stichwort,
      BDO.BgDocumentTS,
      DOC.DateCreation,
      DOC.UserID_Creator,
      DOC.DateLastSave,
      DOC.UserID_LastSave,
      DOC.FileBinary,
      DOC.DocFormatCode,
      DOC.FileExtension
  FROM dbo.BgDokument BDO
      LEFT JOIN dbo.XDocument   DOC WITH (READUNCOMMITTED) ON DOC.DocumentID = BDO.DocumentID  
  WHERE BDO.BgPositionID = @BgPositionID
  UNION ALL
  SELECT BDO.BgDokumentID,
      BgFinanzplanID = NULL,
      BDO.BgBudgetID,
      BgPositionID = NULL,
      BDO.BgDokumentTypCode,
      BDO.DocumentID,
      BDO.Stichwort,
      BDO.BgDocumentTS,
      DOC.DateCreation,
      DOC.UserID_Creator,
      DOC.DateLastSave,
      DOC.UserID_LastSave,
      DOC.FileBinary,
      DOC.DocFormatCode,
      DOC.FileExtension  
  FROM   dbo.BgPosition POS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgDokument BDO ON BDO.BgBudgetID = POS.BgBudgetID
      LEFT JOIN dbo.XDocument   DOC WITH (READUNCOMMITTED) ON DOC.DocumentID = BDO.DocumentID
  WHERE  POS.BgPositionID = @BgPositionID  
  UNION ALL
  SELECT BDO.BgDokumentID,
      BDO.BgFinanzplanID,
      BgBudgetID = NULL,
      BgPositionID = NULL,
      BDO.BgDokumentTypCode,
      BDO.DocumentID,
      BDO.Stichwort,
      BDO.BgDocumentTS,
      DOC.DateCreation,
      DOC.UserID_Creator,
      DOC.DateLastSave,
      DOC.UserID_LastSave,
      DOC.FileBinary,
      DOC.DocFormatCode,
      DOC.FileExtension  
  FROM   dbo.BgPosition POS WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget   BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
      INNER JOIN dbo.BgDokument BDO ON BDO.BgFinanzplanID = BDG.BgFinanzplanID  
      LEFT JOIN dbo.XDocument   DOC WITH (READUNCOMMITTED) ON DOC.DocumentID = BDO.DocumentID  
  WHERE  POS.BgPositionID = @BgPositionID
  UNION ALL
  SELECT BDO.BgDokumentID,
      BgFinanzplanID = NULL,
      BgBudgetID = NULL,
      BDO.BgPositionID,
      BDO.BgDokumentTypCode,
      BDO.DocumentID,
      BDO.Stichwort,
      BDO.BgDocumentTS,
      DOC.DateCreation,
      DOC.UserID_Creator,
      DOC.DateLastSave,
      DOC.UserID_LastSave,
      DOC.FileBinary,
      DOC.DocFormatCode,
      DOC.FileExtension  
  FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgDokument BDO WITH (READUNCOMMITTED) ON BDO.BgPositionID = POS.BgPositionID_CopyOf
    LEFT JOIN dbo.XDocument   DOC WITH (READUNCOMMITTED) ON DOC.DocumentID = BDO.DocumentID  
  WHERE POS.BgPositionID = @BgPositionID


)
GO
