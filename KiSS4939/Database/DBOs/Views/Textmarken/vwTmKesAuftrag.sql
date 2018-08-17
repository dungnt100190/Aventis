SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesAuftrag;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der Tabelle...
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesAuftrag;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesAuftrag
AS
  SELECT
    KesAuftragID                 = KAU.KesAuftragID,
    AuftragVom            = KAU.DatumAuftrag,
    AbklaerungDurch       = USRKA.NameVorname, -- Bearbeitung Durch
    MeldungDurchD         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 1),
    MeldungDurchF         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 2),
    MeldungDurchI         = dbo.fnGetLOVMLText(CASE WHEN KAU.IsKS=1 THEN 'KesGefaehrdungsmeldungDurchKS' ELSE 'KesGefaehrdungsmeldungDurchES' END, KAU.KesGefaehrdungsmeldungDurchCode, 3),
    AuftragDurchD         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 1),
    AuftragDurchF         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 2),
    AuftragDurchI         = dbo.fnGetLOVMLText('KesAuftragDurch', KAU.KesAuftragDurchCode, 3),          
    AbklaerungsartDE       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 1),
    AbklaerungsartFR       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 2),
    AbklaerungsartIT       = dbo.fnGetLOVMLText('KesAuftragAbklaerungsart', KAU.KesAuftragAbklaerungsartCode, 3),
    Anlass                = KAU.Anlass,
    Auftrag               = KAU.Auftrag,
    DokumentDatum         = dbo.fnDateOf(DOCDKAB.DateLastSave),
    FristBis              = KAU.DatumFrist,

    Abschluss             = KAU.AbschlussDatum,
    AbschlussgrundD       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 1),
    AbschlussgrundF       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 2),
    AbschlussgrundI       = dbo.fnGetLOVMLText('KesAuftragAbschlussgrund', KAU.KesAuftragAbschlussgrundCode, 3),          
    BeschlussRueckmeldung = dbo.fnDateOf(DOCDKAA.DateLastSave),
    BetroffenePersonen    = STUFF((SELECT DISTINCT
                                     ', ' + CONVERT(VARCHAR, PRS.Name + IsNull(' ' + PRS.Vorname, ''))
                                   FROM dbo.KesAuftrag_BaPerson KAP
                                     INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = KAP.BaPersonID
                                   WHERE KAP.KesAuftragID = KAU.KesAuftragID 
                                   FOR XML PATH('')),
                                   1, 
                                   2, 
                                   ''),

    --Klient von der Leistung --> via Standard-Textmarke, Verwandt vom Klient hier spezifisch :
    KlientKindD        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandD, '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSK.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientKindF        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandF, '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSK.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),  
    KlientKindI        = dbo.ConcDistinct(NULLIF(ISNULL(PRSK.VornameName, '') + 
                                                 ISNULL(', ' + PRSK.ZivilstandI, '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSK.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSK.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSK.AufenthaltWohnortAdrEinzOhneName,''), '')),    
    KlientVaterD       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSV.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')) ,        
    KlientVaterF       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSV.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')),  
    KlientVaterI       = dbo.ConcDistinct(NULLIF(ISNULL(PRSV.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSV.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSV.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSV.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSV.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterD      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') +
                                                 ISNULL(', ' + PRSM.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSM.HeimatortNationalitaetD, '') +
                                                 ISNULL(', wohnhaft ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterF      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSM.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', de ' + PRSM.HeimatortNationalitaetF, '') +
                                                 ISNULL(', domicile ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientMutterI      = dbo.ConcDistinct(NULLIF(ISNULL(PRSM.NameVornameOhneKomma, '') + 
                                                 ISNULL(', ' + PRSM.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSM.Geburtsdatum,104),'') +
                                                 ISNULL(', von ' + PRSM.HeimatortNationalitaetI, '') +
                                                 ISNULL(', wohnhaft ' + PRSM.AufenthaltWohnortAdrEinzOhneName,''), '')),
    KlientGeschwisterD = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandD  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    KlientGeschwisterF = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandF  , '') +
                                                 ISNULL(', naiss. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    KlientGeschwisterI = dbo.ConcDistinct(NULLIF(ISNULL(PRSG.VornameName, '') +
                                                 ISNULL(', ' + PRSG.ZivilstandI  , '') +
                                                 ISNULL(', geb. ' + CONVERT(VARCHAR, PRSG.Geburtsdatum,104),''), '')),
    -- sonstiges
    DatumHeute = dbo.fnDateOf(GETDATE())
  FROM dbo.KesAuftrag               KAU     WITH (READUNCOMMITTED)
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

  GROUP BY  KAU.KesAuftragID, KAU.DatumAuftrag, KAU.DatumFrist, KAU.IsKS, KAU.KesGefaehrdungsmeldungDurchCode, KAU.KesAuftragAbklaerungsartCode, KAU.KesAuftragDurchCode, KAU.Anlass, KAU.Auftrag, KAU.AbschlussDatum, KAU.KesAuftragAbschlussgrundCode,
            DOCDKAB.DateLastSave, DOCDKAA.DateLastSave,
            USRKA.UserID, USRKA.NameVorname

GO

