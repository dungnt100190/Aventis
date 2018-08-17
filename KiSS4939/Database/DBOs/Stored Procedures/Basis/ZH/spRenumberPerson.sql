SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spRenumberPerson
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spRenumberPerson (@BaPersonID int)
AS

  DECLARE @BaPersonIDNew int

  -- nächste "identity" ID suchen
  SELECT @BaPersonIDNew = MAX(BaPersonID) + 1
  FROM BaPerson
  WHERE BaPersonID < 499000
  -- select 'BaPersonIDNew = ' + convert(varchar,@BaPersonIDNew)

  -- Kopie der Person auf die neue ID erzeugen
  SET identity_insert BaPerson on
  INSERT BaPerson
  (BaPersonID,StatusPersonCode,Titel,Name,FruehererName,Vorname,Vorname2,Geburtsdatum,Sterbedatum,
   AHVNummer,Versichertennummer,NNummer,BFFNummer,ZIPNr,KantonaleReferenznummer,
   GeschlechtCode,ZivilstandCode,ZivilstandDatum,HeimatgemeindeCode,HeimatgemeindeCodes,NationalitaetCode,
   ReligionCode,AuslaenderStatusCode,AuslaenderStatusGueltigBis,Telefon_P,Telefon_G,MobilTel1,MobilTel2,EMail,
   SprachCode,Unterstuetzt,Fiktiv,Bemerkung,EinwohnerregisterAktiv,DeutschVerstehenCode,WichtigerHinweisCode,
   ZuzugKtPLZ,ZuzugKtOrtCode,ZuzugKtOrt,ZuzugKtKanton,ZuzugKtLandCode,ZuzugKtDatum,ZuzugKtSeitGeburt,ZuzugGdePLZ,
   ZuzugGdeOrtCode,ZuzugGdeOrt,ZuzugGdeKanton,ZuzugGdeLandCode,ZuzugGdeDatum,ZuzugGdeSeitGeburt,
   UntWohnsitzPLZ,UntWohnsitzOrt,UntWohnsitzKanton,UntWohnsitzLandCode,
   WegzugPLZ,WegzugOrtCode,WegzugOrt,WegzugKanton,WegzugLandCode,WegzugDatum,
   WohnsitzWieBaPersonID,AufenthaltWieBaInstitutionID,ErwerbssituationCode,
   GrundTeilzeitarbeit1Code,GrundTeilzeitarbeit2Code,ErwerbsBrancheCode,ErlernterBerufCode,
   BerufCode,HoechsteAusbildungCode,AbgebrocheneAusbildungCode,ArbeitSpezFaehigkeiten,VerID,KbKostenstelleID,
   InCHSeit,InCHSeitGeburt,PUAnzahlVerlustscheine,PUKrankenkasse,PraemienuebernahmeVon,PraemienuebernahmeBis,
   PersonOhneLeistung,HCMCFluechtling,StellensuchendCode,ResoNr,NEAnmeldung,Creator,Created,Modifier,Modified)
  SELECT
   @BaPersonIDNew,StatusPersonCode,Titel,Name,FruehererName,Vorname,Vorname2,Geburtsdatum,Sterbedatum,
   AHVNummer,Versichertennummer,NNummer,BFFNummer,ZIPNr,KantonaleReferenznummer,
   GeschlechtCode,ZivilstandCode,ZivilstandDatum,HeimatgemeindeCode,HeimatgemeindeCodes,NationalitaetCode,
   ReligionCode,AuslaenderStatusCode,AuslaenderStatusGueltigBis,Telefon_P,Telefon_G,MobilTel1,MobilTel2,EMail,
   SprachCode,Unterstuetzt,Fiktiv,Bemerkung,EinwohnerregisterAktiv,DeutschVerstehenCode,WichtigerHinweisCode,
   ZuzugKtPLZ,ZuzugKtOrtCode,ZuzugKtOrt,ZuzugKtKanton,ZuzugKtLandCode,ZuzugKtDatum,ZuzugKtSeitGeburt,ZuzugGdePLZ,
   ZuzugGdeOrtCode,ZuzugGdeOrt,ZuzugGdeKanton,ZuzugGdeLandCode,ZuzugGdeDatum,ZuzugGdeSeitGeburt,
   UntWohnsitzPLZ,UntWohnsitzOrt,UntWohnsitzKanton,UntWohnsitzLandCode,
   WegzugPLZ,WegzugOrtCode,WegzugOrt,WegzugKanton,WegzugLandCode,WegzugDatum,
   WohnsitzWieBaPersonID,AufenthaltWieBaInstitutionID,ErwerbssituationCode,
   GrundTeilzeitarbeit1Code,GrundTeilzeitarbeit2Code,ErwerbsBrancheCode,ErlernterBerufCode,
   BerufCode,HoechsteAusbildungCode,AbgebrocheneAusbildungCode,ArbeitSpezFaehigkeiten,VerID,KbKostenstelleID,
   InCHSeit,InCHSeitGeburt,PUAnzahlVerlustscheine,PUKrankenkasse,PraemienuebernahmeVon,PraemienuebernahmeBis,
   PersonOhneLeistung,HCMCFluechtling,StellensuchendCode,ResoNr,NEAnmeldung,Creator,Created,Modifier,Modified
  FROM BaPerson
  WHERE BaPersonID = @BaPersonID
  SET identity_insert BaPerson off

  -- Umhängen aller Referenzen auf die alte Person
  EXEC dbo.spXRowMerge 'BaPerson', @BaPersonIDNew, @BaPersonID

  -- Spezialfall BaPerson_Relation: kein FK auf BaPersonID_2
  UPDATE dbo.BaPerson_Relation
  SET    BaPersonID_2 = @BaPersonIDNew
  WHERE  BaPersonID_2 = @BaPersonID

  -- Anzeigen der neuen Person
  SELECT * FROM BaPerson WHERE BaPersonID = @BaPersonIDNew
