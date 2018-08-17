SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaSituationsbeschreibung;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaSitutionsbeschreibung
  -
  RETURNS: Bookmarks for FaSitutionsbeschreibung
  -
  TEST:    SELECT TOP 30 * FROM dbo.vwTmFaSituationsbeschreibung
=================================================================================================*/

CREATE VIEW dbo.vwTmFaSituationsbeschreibung
AS
SELECT
  -- from BaPerson
  VPR.*,
  
  -- from FaSituationsbeschreibung
  FAS.FaSituationsbeschreibungID,
  
  UebersichtAnliegenNORTF               = FAS.UebersichtBeschreibung,
  UebersichtThemenNORTF                 = FAS.UebersichtThemen,
  UebersichtStellenNORTF                = FAS.UebersichtStellen,
  UebersichtBemerkungenNORTF            = FAS.UebersichtBemerkungen,
  UebersichtCMUeberpruefenD             = dbo.fnGetYesNoMLText(FAS.UebersichtCMUeberpruefen, 1, 0),
  UebersichtCMUeberpruefenF             = dbo.fnGetYesNoMLText(FAS.UebersichtCMUeberpruefen, 2, 0),
  UebersichtCMUeberpruefenI             = dbo.fnGetYesNoMLText(FAS.UebersichtCMUeberpruefen, 3, 0),
  UebersichtDatumMerkblatt              = CONVERT(VARCHAR(10), FAS.UebersichtDatumMerkblatt, 104),

  LebensbereicheArbeitAusbildungNORTF   = FAS.LebensbereicheArbeitAusbildung,
  LebensbereicheTagesstrukturNORTF      = FAS.LebensbereicheTagesstruktur,
  LebensbereicheFinanzenNORTF           = FAS.LebensbereicheFinanzen,
  LebensbereicheGesundheitNORTF         = FAS.LebensbereicheGesundheit,
  LebensbereicheSozialeKontakteNORTF    = FAS.LebensbereicheSozialeKontakte,
  LebensbereicheSituationKinderNORTF    = FAS.LebensbereicheSituationKinder,
  LebensbereicheFreizeitNORTF           = FAS.LebensbereicheFreizeit,
  LebensbereicheWohnenNORTF             = FAS.LebensbereicheWohnen,
  LebensbereicheLebensplanNORTF         = FAS.LebensbereicheLebensplan,
  LebensbereicheSozialversicherungNORTF = FAS.LebensbereicheSozialversicherung,
  
  RessourcenPersoenlichNORTF            = FAS.RessourcenPersoenlich,
  RessourcenSozialNORTF                 = FAS.RessourcenSozial,
  RessourcenMateriellNORTF              = FAS.RessourcenMateriell,
  RessourcenInstitutionellNORTF         = FAS.RessourcenInstitutionell,
  
  SichtweisenSANORTF                    = FAS.SichtweisenSA,
  SichtweisenFachstellenNORTF           = FAS.SichtweisenFachstellen,
  SichtweisenKlientNORTF                = FAS.SichtweisenKlient,
  SichtweisenBemerkungenNORTF           = FAS.SichtweisenBemerkungen,
  
  FAS.LetzteAenderung
  
FROM dbo.FaSituationsbeschreibung FAS WITH(READUNCOMMITTED)
  INNER JOIN dbo.vwTmBaPerson VPR WITH(READUNCOMMITTED) ON VPR.BaPersonID = FAS.BaPersonID
GO