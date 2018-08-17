SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwSstIKAuszug;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwSstIKAuszug;
=================================================================================================*/

CREATE VIEW dbo.vwSstIKAuszug
AS
SELECT  [SstIKAuszugID],
        [BaPersonID],
        [AnforderungDatum],
        [SstIkAuszugAnforderungCode],
        [AnforderungUserID],
        [Versichertennummer],
        [JahrVon],
        [JahrBis],
        [MessageID],
        [ExportDatum],
        [ExportXML],
        [ImportDatum],
        [ImportXML],
        [ImportFehlermeldung],
        [DocumentID],
        [Deaktiviert],
        [Creator]  = IKATEMP.[Creator],
        [Created]  = IKATEMP.[Created],
        [Modifier] = IKATEMP.[Modifier],
        [Modified] = IKATEMP.[Modified],
        [SstIKAuszugTS],
        [SstIkAuszugStatusCode],
        [Bemerkung] = CASE 
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 1 THEN 'Automatische Anfrage (Grund: Genehmigung 1.Finanzplan)'
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 2 THEN 'Automatische Anfrage (Grund: WSH seit 2 Jahren) '
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 3 THEN 'Automatische Anfrage (Grund: WSH seit 5 Jahren) '
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 4
                         AND IKATEMP.SstIkAuszugStatusCode IN (1, 2, 3, 4) THEN 'Manuelle Anfrage' + ISNULL(' durch ' + USR.LogonName, '')
                        ELSE ''
                      END + 
                      CASE 
                        WHEN IKATEMP.SstIkAuszugStatusCode IN (2, 4) THEN ', bei SVA bestellt'  -- Also in case of Import-Error (Decision by Claudia Corrodi)
                        WHEN IKATEMP.SstIkAuszugStatusCode = 3 THEN ', Auszug wird erstellt'
                        ELSE ''
                      END
FROM (SELECT [SstIKAuszugID],
             [BaPersonID],
             [AnforderungDatum],
             [SstIkAuszugAnforderungCode],
             [AnforderungUserID],
             [Versichertennummer],
             [JahrVon],
             [JahrBis],
             [MessageID],
             [ExportDatum],
             [ExportXML],
             [ImportDatum],
             [ImportXML],
             [ImportFehlermeldung],
             [DocumentID],
             [Deaktiviert],
             [Creator],
             [Created],
             [Modifier],
             [Modified],
             [SstIKAuszugTS],
             [SstIkAuszugStatusCode] = CASE 
                                         WHEN Deaktiviert = 1 THEN 6   -- Deaktiviert
                                         WHEN ExportDatum IS NULL THEN 1 -- Angefordert
                                         WHEN ExportDatum > ISNULL(ImportDatum, '1900-01-01') THEN 2 -- Exportiert
                                         WHEN ImportDatum IS NOT NULL
                                          AND ImportDatum > ExportDatum
                                           THEN CASE 
                                                  WHEN ImportFehlermeldung IS NOT NULL THEN 4 -- Importiert mit Fehler
                                                  WHEN DocumentID IS NULL THEN 3 -- Importiert, PDF noch pendent
                                                  ELSE 5  -- Importiert, PDF erstellt
                                                END
                                       END
      FROM dbo.SstIKAuszug IKA WITH (READUNCOMMITTED)) IKATEMP
  LEFT JOIN dbo.XUser                                  USR  WITH (READUNCOMMITTED) ON USR.UserID = IKATEMP.AnforderungUserID;
