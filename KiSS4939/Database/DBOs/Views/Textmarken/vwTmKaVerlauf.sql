SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaVerlauf;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen der Textmarke
  -
  RETURNS: Alle Datensätze von der Tabelle KaVerlauf
=================================================================================================
  TEST:    SELECT TOP 10 <Columns> FROM dbo.vwTmKaVerlauf;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaVerlauf
AS
SELECT
  KaVerlaufID,
  FaLeistungID,
  Autor         = USR.NameVorname,
  Datum         = Datum,
  Kontaktart    = dbo.fnLOVText('KaAllgemKontaktart', KaAllgemKontaktartCode),
  Kontaktperson = Kontaktperson,
  Stichwort     = Stichwort,
  Thema         = dbo.fnLOVTextListe('KaAllgemThema', KaAllgemThemaCodes),
  InhaltRTF     = InhaltRTF,
  InhaltNORTF   = InhaltRTF,
  SichtbarSD    = SichtbarSDFlag
FROM dbo.KaVerlauf            KAV WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwUserSimple USR WITH (READUNCOMMITTED) ON USR.UserID = KAV.UserID;
GO
