IF EXISTS(SELECT TOP 1 1 FROM SYSOBJECTS WHERE name LIKE 'XDocument' AND xtype LIKE 'V')
BEGIN
  DROP VIEW dbo.XDocument
END
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
  $Author: Lloreggia $
  $Modtime: 23.12.09 17:06 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this view, if XDocument is located in a different DB
  -
  ATTENTION: - KISS4_BSS_MasterDev_DOC.dbo.XDocument have to be modified für different customers !!!
             - Do not insert this view if table XDocument already exists on same database !!!
  -
  RETURNS: all fields of table XDocument.
  -
  TEST:    SELECT * from dbo.XDocument
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
 * 
 * 13    23.12.09 17:06 Lloreggia
 * Übernahme der Änderungen aus dem Branch 4.1.48
 * 
 * 12    13.11.09 15:38 Lloreggia
 * Updated to latest version (DB creation script working)
 * 
 * 11    2.09.09 7:55 Nweber
 * #4932: Dokumenten DB-Name mit {DBName}_DOC ersetzen für das neue
 * Release-Tool
 * 
 * 10    25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 9     18.06.09 15:23 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 8     18.06.09 14:00 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 7     17.06.09 17:03 Cjaeggi
 * #2499: Gleichzeitige Bearbeitung von Dokumenten
=================================================================================================*/

CREATE VIEW [dbo].[XDocument]
AS 

SELECT 
  DocumentID, DateCreation, UserID_Creator,
  FileBinary, DocFormatCode, FileExtension, DocReadOnly, DocTemplateID, XDocumentTS, 
  UserID_LastRead, DateLastRead, UserID_LastSave, DateLastSave, 
  DocTypeCode, DocTemplateName, 
  CheckOut_UserID, CheckOut_Date, CheckOut_Filename, CheckOut_Machine
FROM {DocDBName}.dbo.XDocument
--@@TODO ???

GO
