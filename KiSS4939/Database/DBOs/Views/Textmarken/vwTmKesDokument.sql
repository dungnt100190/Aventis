SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesDokument;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der Tabelle...
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesDokument;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesDokument
AS
  SELECT
    -- Dokument Teil --
    KesAuftragID                  = KED.KesAuftragID,
    KesDokumentID                 = KED.KesDokumentID,
    VerfasserInUserID             = KED.[UserID],
    VerfasserFrauHerr             = USR.FrauHerr,
    VerfasserFrauHerrn            = USR.FrauHerrn,
    VerfasserNameVorname          = USR.NameVorname,
    VerfasserNameVornameOhneKomma = USR.NameVornameOhneKomma,
    VerfasserVornameName          = USR.VornameName,
    VerfasserAbteilungEMail       = USR.AbteilungEMail,
    VerfasserAbteilungFax         = USR.AbteilungFax,
    VerfasserAbteilungName        = USR.AbteilungName,
    VerfasserAbteilungTelefon     = USR.AbteilungTelefon,
    VerfasserNachname             = USR.Nachname,
    VerfasserVorname              = USR.Vorname,
    VerfasserKuerzel              = USR.Kuerzel,
    VerfasserTelephon             = USR.Telephon,
    VerfasserEMail                = USR.EMail,
    --Verfasser via Standard-Textmarke: vwTmUser, existiert aber nur für "Aktuell eingeloggter Benutzer", deshalb integriert in diese View
    Stichwort                     = KED.[Stichwort],
    ResultatD                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 1),
    ResultatF                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 2),
    ResultatI                     = dbo.fnGetLOVMLText('KesDokumentResultat', KED.KesDokumentResultatCode, 3),
    ArtDE                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 1),
    ArtFR                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 2),
    ArtIT                          = dbo.fnGetLOVMLText('KesDokumentArt', KED.KesDokumentArtCode, 3), 
    VersandDatum                  = dbo.fnDateOf(DOCV.DateLastSave),
    -- sonstiges
    DatumHeute = dbo.fnDateOf(GETDATE())
  FROM dbo.KesDokument              KED     WITH (READUNCOMMITTED)
    LEFT JOIN dbo.XDocument         DOCD    WITH (READUNCOMMITTED) ON DOCD.DocumentID = KED.XDocumentID_Dokument
    LEFT JOIN dbo.XDocument         DOCV    WITH (READUNCOMMITTED) ON DOCV.DocumentID = KED.XDocumentID_Versand  
    LEFT JOIN dbo.vwTmUser          USR     ON KED.UserID = USR.UserID
    LEFT JOIN dbo.KesAuftrag        KAU     WITH (READUNCOMMITTED) ON KAU.KesAuftragID = KED.KesAuftragID
    LEFT JOIN dbo.FaLeistung        LEI     WITH (READUNCOMMITTED) ON LEI.FaLeistungID = KAU.FaLeistungID
    LEFT JOIN dbo.vwTmUser          USRKA   ON USRKA.UserID = KAU.UserID  
    LEFT JOIN dbo.XDocument         DOCDKAB WITH (READUNCOMMITTED) ON DOCDKAB.DocumentID = KAU.DocumentID_BeschlussRueckmeldung
    LEFT JOIN dbo.XDocument         DOCDKAA WITH (READUNCOMMITTED) ON DOCDKAA.DocumentID = KAU.DocumentID_Auftrag     
    -- Kind
    LEFT JOIN dbo.BaPerson_Relation PREK    WITH (READUNCOMMITTED) ON PREK.BaPersonID_1 = LEI.BaPersonID 
                                                                  AND PREK.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind , 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSK    WITH (READUNCOMMITTED) ON PRSK.BaPersonID = PREK.BaPersonID_2
    -- Vater
    LEFT JOIN dbo.BaPerson_Relation PREV    WITH (READUNCOMMITTED) ON PREV.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREV.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSV    WITH (READUNCOMMITTED) ON PRSV.BaPersonID = PREV.BaPersonID_1 
                                                                  AND (PRSV.GeschlechtCode = 1 OR PRSV.GeschlechtCode IS NULL)  
    -- Mutter
    LEFT JOIN dbo.BaPerson_Relation PREM    WITH (READUNCOMMITTED) ON PREM.BaPersonID_2 = LEI.BaPersonID 
                                                                  AND PREM.BaRelationID in (1,5,6,7) -- BaRelationID = 1 --> Eltern:Kind, 5 = Adoptiveltern : Adoptivkind, 6 = Pflegeltern : Pflegkind, 7 = Stiefeltern : Stiefkind  
    LEFT JOIN dbo.vwTmPerson        PRSM    WITH (READUNCOMMITTED) ON PRSM.BaPersonID = PREM.BaPersonID_1 
                                                                  AND PRSM.GeschlechtCode = 2 
    -- Geschwister
    LEFT JOIN dbo.BaPerson_Relation PREG    WITH (READUNCOMMITTED) ON (PREG.BaPersonID_1 = LEI.BaPersonID OR PREG.BaPersonID_2 = LEI.BaPersonID) 
                                                                  AND PREG.BaRelationID = 2 -- BaRelationID = 2 --> Geschwister
    LEFT JOIN dbo.vwTmPerson        PRSG    WITH (READUNCOMMITTED) ON (PRSG.BaPersonID = PREG.BaPersonID_1 AND PREG.BaPersonID_1 != LEI.BaPersonID)
                                                                   OR (PRSG.BaPersonID = PREG.BaPersonID_2 AND PREG.BaPersonID_2 != LEI.BaPersonID)

  GROUP BY  KED.KesAuftragID, KED.KesDokumentID, KED.UserID, KED.[Stichwort], KED.KesDokumentResultatCode, KED.KesDokumentArtCode, KED.[XDocumentID_Dokument], KED.[XDocumentID_Versand], KED.[KesDokumentTypCode],
            DOCD.DateLastSave, DOCV.DateLastSave,
            USR.FrauHerr, USR.FrauHerrn, USR.NameVorname, USR.NameVornameOhneKomma, USR.VornameName, USR.AbteilungEMail, USR.AbteilungFax, USR.AbteilungName, USR.AbteilungTelefon, USR.Nachname, USR.Vorname,  USR.Kuerzel, USR.Telephon,  USR.EMail,
            KAU.KesAuftragID, KAU.DatumAuftrag, KAU.DatumFrist, KAU.IsKS, KAU.KesGefaehrdungsmeldungDurchCode, KAU.KesAuftragAbklaerungsartCode, KAU.KesAuftragDurchCode, KAU.Anlass, KAU.Auftrag, KAU.AbschlussDatum, KAU.KesAuftragAbschlussgrundCode,
            DOCDKAB.DateLastSave, DOCDKAA.DateLastSave,            
            USRKA.UserID, USRKA.NameVorname

GO

