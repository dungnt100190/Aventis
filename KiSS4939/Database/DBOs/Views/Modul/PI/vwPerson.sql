SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPerson;
GO
/*===============================================================================================
  $Revision:22 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get details for person
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
  -
  RETURNS: Data from BaPerson with some additional columns
=================================================================================================
  TEST:    SELECT TOP 30 * FROM dbo.vwPerson
=================================================================================================*/

CREATE VIEW dbo.vwPerson WITH SCHEMABINDING
AS
SELECT PRS.BaPersonID,
       PRS.Titel,
       PRS.Name,
       PRS.Vorname,
       PRS.FruehererName,
       PRS.Geburtsdatum,
       PRS.Sterbedatum,
--       PRS.AHVNummer,
       PRS.VersichertenNummer,
       PRS.HaushaltVersicherungsNummer,
       PRS.GeschlechtCode,
       PRS.ZivilstandCode,
       PRS.NationalitaetCode,
       PRS.HeimatgemeindeBaGemeindeID,
       PRS.HauptBehinderungsartCode,
       PRS.Behinderungsart2Code,
       PRS.BSVBehinderungsartCode,
       PRS.Mehrfachbehinderung,
       PRS.SprachCode,
       PRS.KorrespondenzSpracheCode,
       PRS.InCHSeit,
       PRS.InCHSeitGeburt,
       PRS.AuslaenderStatusCode,
       PRS.AusbildungCode,
       PRS.ErwerbssituationCode,
       PRS.VormundMassnahmenCode,
       PRS.VormundPI,
       PRS.IVBerechtigungAnfangsStatusCode,
       PRS.IVBerechtigungErsterEntscheidCode,
       PRS.IVBerechtigungErsterEntscheidAb,
       PRS.IVBerechtigungZweiterEntscheidCode,
       PRS.IVBerechtigungZweiterEntscheidAb,
       PRS.WichtigerHinweis,
       PRS.Bemerkung,
       PRS.Telefon_P,
       PRS.Telefon_G,
       PRS.MobilTel,
       PRS.ZeigeTelPrivat,
       PRS.ZeigeTelGeschaeft,
       PRS.ZeigeTelMobil,
       PRS.Fax,
       PRS.EMail,
       PRS.KontoFuehrung,
       PRS.DebitorNr,
       PRS.DebitorUpdate,
       PRS.WohnstatusCode,
       PRS.MietdepotPI,
       PRS.EigenerMietvertrag,
       PRS.BemerkungenAdresse,
       PRS.RentenstufeCode,
       PRS.IVGrad,
       PRS.HilfslosenEntschaedigungCode,
       PRS.HELBAnmeldung,
       PRS.HELBEntscheid,
       PRS.HELBEntscheidCode,
       PRS.HELBAb,
       PRS.IntensivPflegeZuschlagCode,
       PRS.IVTaggeld,
       PRS.BeruflicheMassnahmeIV,
       PRS.MedizinischeMassnahmeIV,
       PRS.IVHilfsmittel,
       PRS.Assistenzbeitrag,
       PRS.IvVerfuegteAssistenzberatung,
       PRS.ErgaenzungsLeistungen,
       PRS.Sozialhilfe,
       PRS.BVGRente,
       PRS.UVGRente,
       PRS.UVGTaggeld,
       PRS.ALK,
       PRS.KTG,
       PRS.WittwenWittwerWaisenrente,
       PRS.AndereSVLeistungen,
       PRS.LaufendeVollmachtErlaubnis,
       PRS.BemerkungenSV,
       PRS.Unterstuetzt,
       PRS.ZeigeDetails,
       PRS.Fiktiv,
       PRS.KeinSerienbrief,
       PRS.visdat36Area,
       PRS.visdat36ID,
       PRS.ZuzugKtDatum,
       PRS.ManuelleAnrede,
       PRS.Anrede,
       PRS.Briefanrede,
       PRS.Creator,
       PRS.Created,
       PRS.Modifier,
       PRS.Modified,
       PRS.VerID,
       PRS.BaPersonTS, 
       
       ------------------------------------------------------------------------
       -- combined columns
       ------------------------------------------------------------------------
       NameVorname             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname), 
       VornameName             = ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
       [Alter]                 = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())), 
       Nationalitaet           = dbo.fnLandMLText(PRS.NationalitaetCode, 1),
       Heimatort               = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
       --
       Wohnsitz                = dbo.fnGetAdressText(PRS.BaPersonID, 1, 0),
       WohnsitzZusatz          = ADRW.Zusatz, 
       WohnsitzAdressZusatz    = ADRW.Zusatz,   -- obsolete
       WohnsitzStrasse         = ADRW.Strasse,
       WohnsitzHausNr          = ADRW.HausNr,
       WohnsitzPostfach        = ADRW.Postfach,
       WohnsitzPostfachOhneNr  = ADRW.PostfachOhneNr,
       WohnsitzStrasseHausNr   = ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, ''),
       WohnsitzPLZ             = ADRW.PLZ,
       WohnsitzOrt             = ADRW.Ort,
       WohnsitzOrtschaftCode   = ADRW.OrtschaftCode, 
       WohnsitzBezirk          = ADRW.Bezirk,
       WohnsitzKanton          = ADRW.Kanton,
       WohnsitzPLZOrt          = dbo.fnGetAdressText(PRS.BaPersonID, 0, 0), 
       WohnsitzBaLandID        = ADRW.BaLandID,
       WohnsitzLand            = dbo.fnLandMLText(ADRW.BaLandID, 1),
       WohnsitzMehrzeilig      = '', -- to enable vwKreditor
       --
       Aufenthalt              = dbo.fnGetAdressText(PRS.BaPersonID, 1, 1),
       AufenthaltZusatz        = ADRA.Zusatz, 
       AufenthaltAdressZusatz  = ADRA.Zusatz,   -- obsolete
       AufenthaltStrasse       = ADRA.Strasse,
       AufenthaltHausNr        = ADRA.HausNr,
       AufenthaltStrasseHausNr = ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, ''),
       AufenthaltPLZ           = ADRA.PLZ,
       AufenthaltOrt           = ADRA.Ort,
       AufenthaltOrtschaftCode = ADRA.OrtschaftCode,
       AufenthaltPLZOrt        = dbo.fnGetAdressText(PRS.BaPersonID, 0, 1), 
       AufenthaltBaLandID      = ADRA.BaLandID,
       AufenthaltLand          = dbo.fnLandMLText(ADRA.BaLandID, 1)
FROM dbo.BaPerson                PRS  WITH(READUNCOMMITTED)
  -- heimatort
  LEFT OUTER JOIN dbo.BaGemeinde GDE  WITH(READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  
    -- wohnsitz
  LEFT JOIN dbo.BaAdresse        ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
  
  -- aufenthalt
  LEFT JOIN dbo.BaAdresse        ADRA WITH (READUNCOMMITTED) ON ADRA.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 2, NULL);
GO