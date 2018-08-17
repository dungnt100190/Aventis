
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/17/2014 11:20:17
-- Generated from EDMX file: C:\Projects\KiSS\KiSS\Kiss.Edmx\KiSS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KiSS_Standard_Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BaAdresse_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaAdresse] DROP CONSTRAINT [FK_BaAdresse_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_BaAdresse_BaInstitution_PlatzierungInstID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaAdresse] DROP CONSTRAINT [FK_BaAdresse_BaInstitution_PlatzierungInstID];
GO
IF OBJECT_ID(N'[dbo].[FK_BaAdresse_BaLand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaAdresse] DROP CONSTRAINT [FK_BaAdresse_BaLand];
GO
IF OBJECT_ID(N'[dbo].[FK_BaAdresse_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaAdresse] DROP CONSTRAINT [FK_BaAdresse_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_BaAdresse_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaAdresse] DROP CONSTRAINT [FK_BaAdresse_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_BaBank_BaLand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaBank] DROP CONSTRAINT [FK_BaBank_BaLand];
GO
IF OBJECT_ID(N'[dbo].[FK_BaGesundheit_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaGesundheit] DROP CONSTRAINT [FK_BaGesundheit_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_BaGesundheit_BaInstitution_KVG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaGesundheit] DROP CONSTRAINT [FK_BaGesundheit_BaInstitution_KVG];
GO
IF OBJECT_ID(N'[dbo].[FK_BaGesundheit_BaInstitution_VVG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaGesundheit] DROP CONSTRAINT [FK_BaGesundheit_BaInstitution_VVG];
GO
IF OBJECT_ID(N'[dbo].[FK_BaGesundheit_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaGesundheit] DROP CONSTRAINT [FK_BaGesundheit_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_BaInstitution_XOrgUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaInstitution] DROP CONSTRAINT [FK_BaInstitution_XOrgUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaGemeinde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaGemeinde];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaGemeinde_HeimatgemeindeCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaGemeinde_HeimatgemeindeCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaInstitution_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson_BaInstitution] DROP CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaInstitution_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson_BaInstitution] DROP CONSTRAINT [FK_BaPerson_BaInstitution_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaLand_NationalitaetCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaLand_NationalitaetCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaLand_UntWohnsitzLandCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaLand_UntWohnsitzLandCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaLand_WegzugLandCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaLand_WegzugLandCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaLand_ZuzugGdeLandCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaLand_ZuzugGdeLandCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_BaLand_ZuzugKtLandCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson] DROP CONSTRAINT [FK_BaPerson_BaLand_ZuzugKtLandCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_Relation_BaPerson1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson_Relation] DROP CONSTRAINT [FK_BaPerson_Relation_BaPerson1];
GO
IF OBJECT_ID(N'[dbo].[FK_BaPerson_Relation_BaPerson2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaPerson_Relation] DROP CONSTRAINT [FK_BaPerson_Relation_BaPerson2];
GO
IF OBJECT_ID(N'[dbo].[FK_BaZahlungsweg_BaBank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaZahlungsweg] DROP CONSTRAINT [FK_BaZahlungsweg_BaBank];
GO
IF OBJECT_ID(N'[dbo].[FK_BaZahlungsweg_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaZahlungsweg] DROP CONSTRAINT [FK_BaZahlungsweg_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_BaZahlungsweg_BaLand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaZahlungsweg] DROP CONSTRAINT [FK_BaZahlungsweg_BaLand];
GO
IF OBJECT_ID(N'[dbo].[FK_BaZahlungsweg_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BaZahlungsweg] DROP CONSTRAINT [FK_BaZahlungsweg_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_BDEPensum_XUser_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BDEPensum_XUser] DROP CONSTRAINT [FK_BDEPensum_XUser_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_BDESollStundenProJahr_XUser_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BDESollStundenProJahr_XUser] DROP CONSTRAINT [FK_BDESollStundenProJahr_XUser_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaAktennotizen_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaAktennotizen] DROP CONSTRAINT [FK_FaAktennotizen_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaAktennotizen_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaAktennotizen] DROP CONSTRAINT [FK_FaAktennotizen_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_BaInstitution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage] DROP CONSTRAINT [FK_FaDokumentAblage_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage] DROP CONSTRAINT [FK_FaDokumentAblage_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_BaPerson_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage_BaPerson] DROP CONSTRAINT [FK_FaDokumentAblage_BaPerson_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_BaPerson_FaDokumentAblage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage_BaPerson] DROP CONSTRAINT [FK_FaDokumentAblage_BaPerson_FaDokumentAblage];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage] DROP CONSTRAINT [FK_FaDokumentAblage_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumentAblage_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumentAblage] DROP CONSTRAINT [FK_FaDokumentAblage_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_BaInstitution_Adressat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_BaInstitution_Adressat];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_BaPerson_Adressat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_BaPerson_Adressat];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_BaPerson_LT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_BaPerson_LT];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_XUser_Absender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_XUser_Absender];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_XUser_EkVisumUserID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_XUser_EkVisumUserID];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_XUser_VisiertDurchID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_XUser_VisiertDurchID];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_XUser_VisumBeantragtBeiID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtBeiID];
GO
IF OBJECT_ID(N'[dbo].[FK_FaDokumente_XUser_VisumBeantragtDurchID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaDokumente] DROP CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtDurchID];
GO
IF OBJECT_ID(N'[dbo].[FK_FaKategorisierung_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaKategorisierung] DROP CONSTRAINT [FK_FaKategorisierung_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaKategorisierung_FaKategorisierungEksProdukt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaKategorisierung] DROP CONSTRAINT [FK_FaKategorisierung_FaKategorisierungEksProdukt];
GO
IF OBJECT_ID(N'[dbo].[FK_FaKategorisierung_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaKategorisierung] DROP CONSTRAINT [FK_FaKategorisierung_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaKategorisierungEksProdukt_XOrgUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaKategorisierungEksProdukt] DROP CONSTRAINT [FK_FaKategorisierungEksProdukt_XOrgUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistung_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistung] DROP CONSTRAINT [FK_FaLeistung_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistung_SachbearbeiterID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistung] DROP CONSTRAINT [FK_FaLeistung_SachbearbeiterID];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistung_SchuldnerBaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistung] DROP CONSTRAINT [FK_FaLeistung_SchuldnerBaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistung_XModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistung] DROP CONSTRAINT [FK_FaLeistung_XModul];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistung_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistung] DROP CONSTRAINT [FK_FaLeistung_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungArchiv_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungArchiv] DROP CONSTRAINT [FK_FaLeistungArchiv_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungArchiv_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungArchiv] DROP CONSTRAINT [FK_FaLeistungArchiv_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungArchiv_XUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungArchiv] DROP CONSTRAINT [FK_FaLeistungArchiv_XUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungUserHist_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungUserHist] DROP CONSTRAINT [FK_FaLeistungUserHist_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungUserHist_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungUserHist] DROP CONSTRAINT [FK_FaLeistungUserHist_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungZugriff_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungZugriff] DROP CONSTRAINT [FK_FaLeistungZugriff_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaLeistungZugriff_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaLeistungZugriff] DROP CONSTRAINT [FK_FaLeistungZugriff_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaPhase_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaPhase] DROP CONSTRAINT [FK_FaPhase_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaPhase_FsDienstleistungspaket_Bedarf]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaPhase] DROP CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Bedarf];
GO
IF OBJECT_ID(N'[dbo].[FK_FaPhase_FsDienstleistungspaket_Zugewiesen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaPhase] DROP CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Zugewiesen];
GO
IF OBJECT_ID(N'[dbo].[FK_FaPhase_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaPhase] DROP CONSTRAINT [FK_FaPhase_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_BaPerson_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung_BaPerson] DROP CONSTRAINT [FK_FaWeisung_BaPerson_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_BaPerson_FaWeisung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung_BaPerson] DROP CONSTRAINT [FK_FaWeisung_BaPerson_FaWeisung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung] DROP CONSTRAINT [FK_FaWeisung_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_XTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung] DROP CONSTRAINT [FK_FaWeisung_XTask];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_XUser_Creator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung] DROP CONSTRAINT [FK_FaWeisung_XUser_Creator];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_XUser_VerantwortlichRD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung] DROP CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichRD];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisung_XUser_VerantwortlichSAR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisung] DROP CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichSAR];
GO
IF OBJECT_ID(N'[dbo].[FK_FaWeisungProtokoll_FaWeisung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FaWeisungProtokoll] DROP CONSTRAINT [FK_FaWeisungProtokoll_FaWeisung];
GO
IF OBJECT_ID(N'[dbo].[FK_FBBUCHUN_REFERENCE_FBPERIOD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FbBuchung] DROP CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBPERIOD];
GO
IF OBJECT_ID(N'[dbo].[FK_FbBuchung_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FbBuchung] DROP CONSTRAINT [FK_FbBuchung_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FbKonto_FbPeriode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FbKonto] DROP CONSTRAINT [FK_FbKonto_FbPeriode];
GO
IF OBJECT_ID(N'[dbo].[FK_FbPeriode_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FbPeriode] DROP CONSTRAINT [FK_FbPeriode_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] DROP CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung];
GO
IF OBJECT_ID(N'[dbo].[FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] DROP CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket];
GO
IF OBJECT_ID(N'[dbo].[FK_FsReduktion_BDELeistungsart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FsReduktion] DROP CONSTRAINT [FK_FsReduktion_BDELeistungsart];
GO
IF OBJECT_ID(N'[dbo].[FK_FsReduktionMitarbeiter_FsReduktion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FsReduktionMitarbeiter] DROP CONSTRAINT [FK_FsReduktionMitarbeiter_FsReduktion];
GO
IF OBJECT_ID(N'[dbo].[FK_FsReduktionMitarbeiter_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FsReduktionMitarbeiter] DROP CONSTRAINT [FK_FsReduktionMitarbeiter_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_KesAuftrag_BaPerson_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesAuftrag_BaPerson] DROP CONSTRAINT [FK_KesAuftrag_BaPerson_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_KesAuftrag_BaPerson_KesAuftrag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesAuftrag_BaPerson] DROP CONSTRAINT [FK_KesAuftrag_BaPerson_KesAuftrag];
GO
IF OBJECT_ID(N'[dbo].[FK_KesAuftrag_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesAuftrag] DROP CONSTRAINT [FK_KesAuftrag_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_KesAuftrag_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesAuftrag] DROP CONSTRAINT [FK_KesAuftrag_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_KesDokument_BaInstitution_Adressat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesDokument] DROP CONSTRAINT [FK_KesDokument_BaInstitution_Adressat];
GO
IF OBJECT_ID(N'[dbo].[FK_KesDokument_BaPerson_Adressat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesDokument] DROP CONSTRAINT [FK_KesDokument_BaPerson_Adressat];
GO
IF OBJECT_ID(N'[dbo].[FK_KesDokument_KesAuftrag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesDokument] DROP CONSTRAINT [FK_KesDokument_KesAuftrag];
GO
IF OBJECT_ID(N'[dbo].[FK_KesDokument_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesDokument] DROP CONSTRAINT [FK_KesDokument_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMandatsfuehrendePerson_KesMassnahme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMandatsfuehrendePerson] DROP CONSTRAINT [FK_KesMandatsfuehrendePerson_KesMassnahme];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMandatsfuehrendePerson_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMandatsfuehrendePerson] DROP CONSTRAINT [FK_KesMandatsfuehrendePerson_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMassnahme_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMassnahme] DROP CONSTRAINT [FK_KesMassnahme_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMassnahme_KesArtikel_KesArtikel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMassnahme_KesArtikel] DROP CONSTRAINT [FK_KesMassnahme_KesArtikel_KesArtikel];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMassnahme_KesArtikel_KesMassnahme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMassnahme_KesArtikel] DROP CONSTRAINT [FK_KesMassnahme_KesArtikel_KesMassnahme];
GO
IF OBJECT_ID(N'[dbo].[FK_KesMassnahmeBericht_KesMassnahme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesMassnahmeBericht] DROP CONSTRAINT [FK_KesMassnahmeBericht_KesMassnahme];
GO
IF OBJECT_ID(N'[dbo].[FK_KesPraevention_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesPraevention] DROP CONSTRAINT [FK_KesPraevention_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_KesPraevention_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KesPraevention] DROP CONSTRAINT [FK_KesPraevention_XUser];
GO
IF OBJECT_ID(N'[log].[FK_UserSession_XUser]', 'F') IS NOT NULL
    ALTER TABLE [log].[UserSession] DROP CONSTRAINT [FK_UserSession_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_VmKlientenbudget_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VmKlientenbudget] DROP CONSTRAINT [FK_VmKlientenbudget_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_VmKlientenbudget_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VmKlientenbudget] DROP CONSTRAINT [FK_VmKlientenbudget_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_VmPosition_VmKlientenbudget]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VmPosition] DROP CONSTRAINT [FK_VmPosition_VmKlientenbudget];
GO
IF OBJECT_ID(N'[dbo].[FK_VmPosition_VmPositionsart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VmPosition] DROP CONSTRAINT [FK_VmPosition_VmPositionsart];
GO
IF OBJECT_ID(N'[dbo].[FK_XClass_XModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XClass] DROP CONSTRAINT [FK_XClass_XModul];
GO
IF OBJECT_ID(N'[dbo].[FK_XLOV_XModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XLOV] DROP CONSTRAINT [FK_XLOV_XModul];
GO
IF OBJECT_ID(N'[dbo].[FK_XLOVCode_XLOV]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XLOVCode] DROP CONSTRAINT [FK_XLOVCode_XLOV];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_User_XOrgUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit_User] DROP CONSTRAINT [FK_XOrgUnit_User_XOrgUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_User_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit_User] DROP CONSTRAINT [FK_XOrgUnit_User_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_XModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit] DROP CONSTRAINT [FK_XOrgUnit_XModul];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_XOrgUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit] DROP CONSTRAINT [FK_XOrgUnit_XOrgUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_XUser_ChiefID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit] DROP CONSTRAINT [FK_XOrgUnit_XUser_ChiefID];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_XUser_RechtsdienstUserID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit] DROP CONSTRAINT [FK_XOrgUnit_XUser_RechtsdienstUserID];
GO
IF OBJECT_ID(N'[dbo].[FK_XOrgUnit_XUser_RepresentativeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XOrgUnit] DROP CONSTRAINT [FK_XOrgUnit_XUser_RepresentativeID];
GO
IF OBJECT_ID(N'[dbo].[FK_XRight_XClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XRight] DROP CONSTRAINT [FK_XRight_XClass];
GO
IF OBJECT_ID(N'[dbo].[FK_XTask_BaPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XTask] DROP CONSTRAINT [FK_XTask_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_XTask_FaLeistung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XTask] DROP CONSTRAINT [FK_XTask_FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FK_XTask_XUser_Bearbeitung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XTask] DROP CONSTRAINT [FK_XTask_XUser_Bearbeitung];
GO
IF OBJECT_ID(N'[dbo].[FK_XTask_XUser_Erledigt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XTask] DROP CONSTRAINT [FK_XTask_XUser_Erledigt];
GO
IF OBJECT_ID(N'[dbo].[FK_XTaskAutoGenerated_XTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XTaskAutoGenerated] DROP CONSTRAINT [FK_XTaskAutoGenerated_XTask];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_UserGroup_XUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser_UserGroup] DROP CONSTRAINT [FK_XUser_UserGroup_XUser];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_UserGroup_XUserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser_UserGroup] DROP CONSTRAINT [FK_XUser_UserGroup_XUserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_XModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser] DROP CONSTRAINT [FK_XUser_XModul];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_XUser_ChiefID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser] DROP CONSTRAINT [FK_XUser_XUser_ChiefID];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_XUser_PrimaryUserID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser] DROP CONSTRAINT [FK_XUser_XUser_PrimaryUserID];
GO
IF OBJECT_ID(N'[dbo].[FK_XUser_XUser_SachbearbeiterID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUser] DROP CONSTRAINT [FK_XUser_XUser_SachbearbeiterID];
GO
IF OBJECT_ID(N'[dbo].[FK_XUserGroup_Right_XClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUserGroup_Right] DROP CONSTRAINT [FK_XUserGroup_Right_XClass];
GO
IF OBJECT_ID(N'[dbo].[FK_XUserGroup_Right_XRight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUserGroup_Right] DROP CONSTRAINT [FK_XUserGroup_Right_XRight];
GO
IF OBJECT_ID(N'[dbo].[FK_XUserGroup_Right_XUserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[XUserGroup_Right] DROP CONSTRAINT [FK_XUserGroup_Right_XUserGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BaAdresse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaAdresse];
GO
IF OBJECT_ID(N'[dbo].[BaBank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaBank];
GO
IF OBJECT_ID(N'[dbo].[BaGemeinde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaGemeinde];
GO
IF OBJECT_ID(N'[dbo].[BaGesundheit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaGesundheit];
GO
IF OBJECT_ID(N'[dbo].[BaInstitution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[BaLand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaLand];
GO
IF OBJECT_ID(N'[dbo].[BaPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaPerson];
GO
IF OBJECT_ID(N'[dbo].[BaPerson_BaInstitution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaPerson_BaInstitution];
GO
IF OBJECT_ID(N'[dbo].[BaPerson_Relation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaPerson_Relation];
GO
IF OBJECT_ID(N'[dbo].[BaPLZ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaPLZ];
GO
IF OBJECT_ID(N'[dbo].[BaZahlungsweg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaZahlungsweg];
GO
IF OBJECT_ID(N'[dbo].[BDELeistungsart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BDELeistungsart];
GO
IF OBJECT_ID(N'[dbo].[BDEPensum_XUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BDEPensum_XUser];
GO
IF OBJECT_ID(N'[dbo].[BDESollStundenProJahr_XUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BDESollStundenProJahr_XUser];
GO
IF OBJECT_ID(N'[dbo].[FaAktennotizen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaAktennotizen];
GO
IF OBJECT_ID(N'[dbo].[FaDokumentAblage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaDokumentAblage];
GO
IF OBJECT_ID(N'[dbo].[FaDokumentAblage_BaPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaDokumentAblage_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FaDokumente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaDokumente];
GO
IF OBJECT_ID(N'[dbo].[FaKategorisierung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaKategorisierung];
GO
IF OBJECT_ID(N'[dbo].[FaKategorisierungEksProdukt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaKategorisierungEksProdukt];
GO
IF OBJECT_ID(N'[dbo].[FaLeistung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaLeistung];
GO
IF OBJECT_ID(N'[dbo].[FaLeistungArchiv]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaLeistungArchiv];
GO
IF OBJECT_ID(N'[dbo].[FaLeistungUserHist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaLeistungUserHist];
GO
IF OBJECT_ID(N'[dbo].[FaLeistungZugriff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaLeistungZugriff];
GO
IF OBJECT_ID(N'[dbo].[FaPendenzgruppe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaPendenzgruppe];
GO
IF OBJECT_ID(N'[dbo].[FaPhase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaPhase];
GO
IF OBJECT_ID(N'[dbo].[FaWeisung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaWeisung];
GO
IF OBJECT_ID(N'[dbo].[FaWeisung_BaPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaWeisung_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[FaWeisungProtokoll]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FaWeisungProtokoll];
GO
IF OBJECT_ID(N'[dbo].[FbBuchung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FbBuchung];
GO
IF OBJECT_ID(N'[dbo].[FbKonto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FbKonto];
GO
IF OBJECT_ID(N'[dbo].[FbPeriode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FbPeriode];
GO
IF OBJECT_ID(N'[dbo].[FsDienstleistung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FsDienstleistung];
GO
IF OBJECT_ID(N'[dbo].[FsDienstleistung_FsDienstleistungspaket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket];
GO
IF OBJECT_ID(N'[dbo].[FsDienstleistungspaket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FsDienstleistungspaket];
GO
IF OBJECT_ID(N'[dbo].[FsReduktion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FsReduktion];
GO
IF OBJECT_ID(N'[dbo].[FsReduktionMitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FsReduktionMitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[HistoryVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HistoryVersion];
GO
IF OBJECT_ID(N'[dbo].[KesArtikel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesArtikel];
GO
IF OBJECT_ID(N'[dbo].[KesAuftrag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesAuftrag];
GO
IF OBJECT_ID(N'[dbo].[KesAuftrag_BaPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesAuftrag_BaPerson];
GO
IF OBJECT_ID(N'[dbo].[KesDokument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesDokument];
GO
IF OBJECT_ID(N'[dbo].[KesMandatsfuehrendePerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesMandatsfuehrendePerson];
GO
IF OBJECT_ID(N'[dbo].[KesMassnahme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesMassnahme];
GO
IF OBJECT_ID(N'[dbo].[KesMassnahme_KesArtikel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesMassnahme_KesArtikel];
GO
IF OBJECT_ID(N'[dbo].[KesMassnahmeBericht]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesMassnahmeBericht];
GO
IF OBJECT_ID(N'[dbo].[KesPraevention]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KesPraevention];
GO
IF OBJECT_ID(N'[dbo].[VmKlientenbudget]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VmKlientenbudget];
GO
IF OBJECT_ID(N'[dbo].[VmPosition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VmPosition];
GO
IF OBJECT_ID(N'[dbo].[VmPositionsart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VmPositionsart];
GO
IF OBJECT_ID(N'[dbo].[XClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XClass];
GO
IF OBJECT_ID(N'[dbo].[XConfig]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XConfig];
GO
IF OBJECT_ID(N'[dbo].[XDBVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XDBVersion];
GO
IF OBJECT_ID(N'[dbo].[XDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XDocument];
GO
IF OBJECT_ID(N'[dbo].[XIcon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XIcon];
GO
IF OBJECT_ID(N'[dbo].[XLOV]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XLOV];
GO
IF OBJECT_ID(N'[dbo].[XLOVCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XLOVCode];
GO
IF OBJECT_ID(N'[dbo].[XModul]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XModul];
GO
IF OBJECT_ID(N'[dbo].[XOrgUnit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XOrgUnit];
GO
IF OBJECT_ID(N'[dbo].[XOrgUnit_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XOrgUnit_User];
GO
IF OBJECT_ID(N'[dbo].[XRight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XRight];
GO
IF OBJECT_ID(N'[dbo].[XTask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XTask];
GO
IF OBJECT_ID(N'[dbo].[XTaskAutoGenerated]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XTaskAutoGenerated];
GO
IF OBJECT_ID(N'[dbo].[XUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XUser];
GO
IF OBJECT_ID(N'[dbo].[XUser_UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XUser_UserGroup];
GO
IF OBJECT_ID(N'[dbo].[XUserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XUserGroup];
GO
IF OBJECT_ID(N'[dbo].[XUserGroup_Right]', 'U') IS NOT NULL
    DROP TABLE [dbo].[XUserGroup_Right];
GO
IF OBJECT_ID(N'[log].[UserSession]', 'U') IS NOT NULL
    DROP TABLE [log].[UserSession];
GO
IF OBJECT_ID(N'[KiSSModelStoreContainer].[FaFall]', 'U') IS NOT NULL
    DROP TABLE [KiSSModelStoreContainer].[FaFall];
GO
IF OBJECT_ID(N'[KiSSModelStoreContainer].[vwBaKlientensystemPerson]', 'U') IS NOT NULL
    DROP TABLE [KiSSModelStoreContainer].[vwBaKlientensystemPerson];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BaAdresse'
CREATE TABLE [dbo].[BaAdresse] (
    [BaAdresseID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NULL,
    [BaInstitutionID] int  NULL,
    [PlatzierungInstID] int  NULL,
    [VmMandantID] int  NULL,
    [VmPriMaID] int  NULL,
    [KaBetriebID] int  NULL,
    [KaBetriebKontaktID] int  NULL,
    [BaLandID] int  NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [Gesperrt] bit  NOT NULL,
    [AdresseCode] int  NULL,
    [CareOf] varchar(200)  NULL,
    [Zusatz] varchar(200)  NULL,
    [ZuhandenVon] varchar(200)  NULL,
    [Strasse] varchar(100)  NULL,
    [HausNr] varchar(10)  NULL,
    [Postfach] varchar(100)  NULL,
    [PostfachOhneNr] bit  NOT NULL,
    [PLZ] varchar(10)  NULL,
    [Ort] varchar(50)  NULL,
    [OrtschaftCode] int  NULL,
    [Kanton] varchar(10)  NULL,
    [Bezirk] varchar(100)  NULL,
    [Bemerkung] varchar(max)  NULL,
    [PlatzierungsartCode] int  NULL,
    [WohnStatusCode] int  NULL,
    [WohnungsgroesseCode] int  NULL,
    [MigrationKA] int  NULL,
    [VerID] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [BaAdresseTS] binary(8)  NOT NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'BaPerson'
CREATE TABLE [dbo].[BaPerson] (
    [BaPersonID] int IDENTITY(1,1) NOT NULL,
    [Titel] varchar(50)  NULL,
    [Name] varchar(100)  NOT NULL,
    [FruehererName] varchar(100)  NULL,
    [Vorname] varchar(100)  NOT NULL,
    [Vorname2] varchar(100)  NULL,
    [Geburtsdatum] datetime  NULL,
    [Sterbedatum] datetime  NULL,
    [AHVNummer] varchar(16)  NULL,
    [Versichertennummer] varchar(18)  NULL,
    [HaushaltVersicherungsNummer] varchar(18)  NULL,
    [NNummer] varchar(20)  NULL,
    [BFFNummer] varchar(20)  NULL,
    [GeschlechtCode] int  NULL,
    [KonfessionCode] int  NULL,
    [ZivilstandCode] int  NULL,
    [ZivilstandDatum] datetime  NULL,
    [HeimatgemeindeBaGemeindeID] int  NULL,
    [NationalitaetCode] int  NULL,
    [AuslaenderStatusCode] int  NULL,
    [AuslaenderStatusGueltigBis] datetime  NULL,
    [InGemeindeSeit] datetime  NULL,
    [InCHSeitGeburt] bit  NOT NULL,
    [ImKantonSeit] datetime  NULL,
    [ImKantonSeitGeburt] bit  NOT NULL,
    [Telefon_P] varchar(100)  NULL,
    [Telefon_G] varchar(100)  NULL,
    [MobilTel] varchar(100)  NULL,
    [Fax] varchar(100)  NULL,
    [EMail] varchar(100)  NULL,
    [SprachCode] int  NULL,
    [Unterstuetzt] bit  NULL,
    [Fiktiv] bit  NOT NULL,
    [Testperson] bit  NOT NULL,
    [NavigatorZusatz] varchar(30)  NULL,
    [Bemerkung] varchar(max)  NULL,
    [BaPersonTS] binary(8)  NOT NULL,
    [VerID] int  NULL,
    [SichtbarSDFlag] bit  NOT NULL,
    [PersonSichtbarSDFlag] bit  NOT NULL,
    [ZuzugKtPLZ] varchar(10)  NULL,
    [ZuzugKtOrt] varchar(50)  NULL,
    [ZuzugKtKanton] varchar(10)  NULL,
    [ZuzugKtOrtCode] int  NULL,
    [ZuzugKtLandCode] int  NULL,
    [ZuzugKtDatum] datetime  NULL,
    [ZuzugKtSeitGeburt] bit  NULL,
    [ZuzugGdePLZ] varchar(10)  NULL,
    [ZuzugGdeOrt] varchar(50)  NULL,
    [ZuzugGdeKanton] varchar(10)  NULL,
    [ZuzugGdeOrtCode] int  NULL,
    [ZuzugGdeLandCode] int  NULL,
    [ZuzugGdeDatum] datetime  NULL,
    [ZuzugGdeSeitGeburt] bit  NULL,
    [UntWohnsitzPLZ] varchar(10)  NULL,
    [UntWohnsitzOrt] varchar(50)  NULL,
    [UntWohnsitzKanton] varchar(10)  NULL,
    [UntWohnsitzOrtCode] int  NULL,
    [UntWohnsitzLandCode] int  NULL,
    [WegzugPLZ] varchar(10)  NULL,
    [WegzugOrt] varchar(50)  NULL,
    [WegzugKanton] varchar(10)  NULL,
    [WegzugOrtCode] int  NULL,
    [WegzugLandCode] int  NULL,
    [WegzugDatum] datetime  NULL,
    [ErteilungVA] datetime  NULL,
    [ZEMISNummer] varchar(20)  NULL,
    [MigrationKA] int  NULL,
    [AktiveKopfQuote] bit  NULL,
    [CAusweisDatum] datetime  NULL,
    [Einrichtpauschale] decimal(19,4)  NULL,
    [EinrichtungspauschaleCode] int  NULL,
    [Kopfquote_BaInstitutionID] int  NULL,
    [KopfquoteAbDatum] datetime  NULL,
    [KopfquoteBisDatum] datetime  NULL,
    [PassiveKopfQuote] bit  NULL,
    [PauschaleAktualDatum] datetime  NULL,
    [ProjNr] int  NULL,
    [Sprachpauschale] decimal(19,4)  NULL,
    [VerstaendigungSprachCode] int  NULL,
    [KeinSerienbrief] bit  NOT NULL,
    [StatusPersonCode] int  NULL,
    [ZIPNr] int  NULL,
    [KantonaleReferenznummer] varchar(50)  NULL,
    [HeimatgemeindeCode] int  NULL,
    [HeimatgemeindeCodes] varchar(255)  NULL,
    [ReligionCode] int  NULL,
    [MobilTel1] varchar(100)  NULL,
    [MobilTel2] varchar(100)  NULL,
    [AlphaAktiv] bit  NULL,
    [DeutschVerstehenCode] int  NULL,
    [WichtigerHinweisCode] int  NULL,
    [WohnsitzWieBaPersonID] int  NULL,
    [AufenthaltWieBaInstitutionID] int  NULL,
    [ErwerbssituationCode] int  NULL,
    [GrundTeilzeitarbeit1Code] int  NULL,
    [GrundTeilzeitarbeit2Code] int  NULL,
    [ErwerbsBrancheCode] int  NULL,
    [ErlernterBerufCode] int  NULL,
    [BerufCode] int  NULL,
    [HoechsteAusbildungCode] int  NULL,
    [AbgebrocheneAusbildungCode] int  NULL,
    [ArbeitSpezFaehigkeiten] varchar(max)  NULL,
    [KbKostenstelleID] int  NULL,
    [InCHSeit] datetime  NULL,
    [PUAnzahlVerlustscheine] int  NULL,
    [PUKrankenkasse] varchar(50)  NULL,
    [PraemienuebernahmeVon] datetime  NULL,
    [PraemienuebernahmeBis] datetime  NULL,
    [PersonOhneLeistung] bit  NOT NULL,
    [HCMCFluechtling] bit  NOT NULL,
    [StellensuchendCode] int  NULL,
    [ResoNr] int  NULL,
    [NEAnmeldung] datetime  NULL,
    [ALK] bit  NOT NULL,
    [AndereSVLeistungen] varchar(max)  NULL,
    [Anrede] varchar(100)  NULL,
    [AusbildungCode] int  NULL,
    [Behinderungsart2Code] int  NULL,
    [BemerkungenAdresse] varchar(max)  NULL,
    [BemerkungenSV] varchar(max)  NULL,
    [BeruflicheMassnahmeIV] bit  NOT NULL,
    [Briefanrede] varchar(100)  NULL,
    [BSVBehinderungsartCode] int  NULL,
    [BVGRente] bit  NOT NULL,
    [DebitorNr] int  NULL,
    [DebitorUpdate] datetime  NULL,
    [EigenerMietvertrag] bit  NOT NULL,
    [ErgaenzungsLeistungen] bit  NOT NULL,
    [HauptBehinderungsartCode] int  NULL,
    [HELBAb] datetime  NULL,
    [HELBAnmeldung] datetime  NULL,
    [HELBEntscheid] datetime  NULL,
    [HELBEntscheidCode] int  NULL,
    [HilfslosenEntschaedigungCode] int  NULL,
    [IntensivPflegeZuschlagCode] int  NULL,
    [IVBerechtigungAnfangsStatusCode] int  NULL,
    [IVBerechtigungErsterEntscheidAb] datetime  NULL,
    [IVBerechtigungErsterEntscheidCode] int  NULL,
    [IVBerechtigungZweiterEntscheidAb] datetime  NULL,
    [IVBerechtigungZweiterEntscheidCode] int  NULL,
    [IVGrad] int  NULL,
    [IVHilfsmittel] bit  NOT NULL,
    [IVTaggeld] bit  NOT NULL,
    [KontoFuehrung] bit  NOT NULL,
    [KorrespondenzSpracheCode] int  NULL,
    [KTG] bit  NOT NULL,
    [LaufendeVollmachtErlaubnis] bit  NOT NULL,
    [ManuelleAnrede] bit  NOT NULL,
    [MedizinischeMassnahmeIV] bit  NOT NULL,
    [Mehrfachbehinderung] bit  NOT NULL,
    [MietdepotPI] bit  NOT NULL,
    [RentenstufeCode] int  NULL,
    [Sozialhilfe] bit  NOT NULL,
    [UVGRente] bit  NOT NULL,
    [UVGTaggeld] bit  NOT NULL,
    [visdat36Area] varchar(255)  NULL,
    [visdat36ID] varchar(6)  NULL,
    [VormundMassnahmenCode] int  NULL,
    [VormundPI] bit  NOT NULL,
    [WichtigerHinweis] varchar(1000)  NULL,
    [WohnstatusCode] int  NULL,
    [ZeigeDetails] bit  NOT NULL,
    [ZeigeTelGeschaeft] bit  NOT NULL,
    [ZeigeTelMobil] bit  NOT NULL,
    [ZeigeTelPrivat] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [HELBKeinAntrag] bit  NOT NULL,
    [IstFamiliennachzug] bit  NOT NULL,
    [WittwenWittwerWaisenrente] bit  NOT NULL,
    [Assistenzbeitrag] bit  NOT NULL,
    [IvVerfuegteAssistenzberatung] int  NULL
);
GO

-- Creating table 'XDBVersion'
CREATE TABLE [dbo].[XDBVersion] (
    [XDBVersionID] int IDENTITY(1,1) NOT NULL,
    [MajorVersion] int  NOT NULL,
    [MinorVersion] int  NOT NULL,
    [Build] int  NOT NULL,
    [Revision] int  NOT NULL,
    [VersionDate] datetime  NOT NULL,
    [SQLServerVersionInfo] varchar(500)  NOT NULL,
    [ChangesSinceLastVersion] varchar(max)  NULL,
    [BackwardCompatibleDownToClientVersion] varchar(20)  NOT NULL,
    [Description] varchar(500)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XDBVersionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FsDienstleistung'
CREATE TABLE [dbo].[FsDienstleistung] (
    [FsDienstleistungID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [StandardAufwand] decimal(19,4)  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FsDienstleistungTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FsDienstleistung_FsDienstleistungspaket'
CREATE TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] (
    [FsDienstleistung_FsDienstleistungspaketID] int IDENTITY(1,1) NOT NULL,
    [FsDienstleistungID] int  NOT NULL,
    [FsDienstleistungspaketID] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FsDienstleistung_FsDienstleistungspaketTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaLeistung'
CREATE TABLE [dbo].[FaLeistung] (
    [FaLeistungID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [ModulID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [GemeindeCode] int  NULL,
    [LeistungsartCode] int  NULL,
    [EroeffnungsGrundCode] int  NULL,
    [AbschlussGrundCode] int  NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [Bemerkung] varchar(max)  NULL,
    [IkSchuldnerStatusCode] int  NULL,
    [IkAufenthaltsartCode] int  NULL,
    [IkHatUnterstuetzung] bit  NOT NULL,
    [IkIstRentenbezueger] bit  NOT NULL,
    [IkSchuldnerMahnen] bit  NOT NULL,
    [IkEinnahmenQuoteCode] int  NULL,
    [IkDatumRechtskraft] datetime  NULL,
    [IkInkassoBemuehungCode] int  NULL,
    [IkVerjaehrungAm] datetime  NULL,
    [IkLeistungStatusCode] int  NULL,
    [IkDatumForderungstitel] datetime  NULL,
    [IkRueckerstattungTypCode] int  NULL,
    [IkForderungTitelCode] int  NULL,
    [SchuldnerBaPersonID] int  NULL,
    [IkErreichungsGradCode] int  NULL,
    [OldUnitID] int  NULL,
    [FaLeistungTS] binary(8)  NOT NULL,
    [VmAuftragCode] int  NULL,
    [FaFallID] int  NOT NULL,
    [FaProzessCode] int  NULL,
    [Bezeichnung] varchar(50)  NULL,
    [KaProzessCode] int  NULL,
    [KaEpqJob] bit  NULL,
    [MigrationKA] int  NULL,
    [FaAufnahmeartCode] int  NULL,
    [FaKontaktveranlasserCode] int  NULL,
    [PscdVertragsgegenstandID] bigint  NULL,
    [SachbearbeiterID] int  NULL,
    [MigBemerkung] varchar(200)  NULL,
    [MigHerkunftCode] int  NULL,
    [MigAlteFallNr] int  NULL,
    [VUFaFallID] int  NULL,
    [visdat36Area] varchar(255)  NULL,
    [visdat36FALLID] varchar(6)  NULL,
    [visdat36LEISTUNGID] varchar(6)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaTeilleistungserbringerCodes] varchar(255)  NULL
);
GO

-- Creating table 'FaPhase'
CREATE TABLE [dbo].[FaPhase] (
    [FaPhaseID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NULL,
    [FsDienstleistungspaketID_Zugewiesen] int  NULL,
    [FsDienstleistungspaketID_Bedarf] int  NULL,
    [FaPhaseCode] int  NOT NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [AbschlussGrundCode] int  NULL,
    [Bemerkung] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaPhaseTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FsDienstleistungspaket'
CREATE TABLE [dbo].[FsDienstleistungspaket] (
    [FsDienstleistungspaketID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FsDienstleistungspaketTS] binary(8)  NOT NULL,
    [MaximaleLaufzeit] decimal(19,4)  NULL
);
GO

-- Creating table 'XUser'
CREATE TABLE [dbo].[XUser] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [ChiefID] int  NULL,
    [PrimaryUserID] int  NULL,
    [PermissionGroupID] int  NULL,
    [GrantPermGroupID] int  NULL,
    [XProfileID] int  NULL,
    [ModulID] int  NULL,
    [SachbearbeiterID] int  NULL,
    [MitarbeiterNr] varchar(50)  NULL,
    [LogonName] varchar(200)  NOT NULL,
    [PasswordHash] varchar(30)  NULL,
    [FirstName] varchar(200)  NULL,
    [LastName] varchar(200)  NOT NULL,
    [ShortName] varchar(10)  NULL,
    [IsLocked] bit  NOT NULL,
    [IsUserAdmin] bit  NOT NULL,
    [IsUserBIAGAdmin] bit  NOT NULL,
    [IsMandatsTraeger] bit  NOT NULL,
    [GenderCode] int  NULL,
    [Geburtstag] datetime  NULL,
    [LanguageCode] int  NULL,
    [Phone] varchar(100)  NULL,
    [PhoneOffice] varchar(100)  NULL,
    [PhoneIntern] varchar(100)  NULL,
    [PhonePrivat] varchar(100)  NULL,
    [EMail] varchar(100)  NULL,
    [UserProfileCode] int  NULL,
    [Funktion] varchar(100)  NULL,
    [Bemerkungen] varchar(1000)  NULL,
    [Text1] varchar(2000)  NULL,
    [Text2] varchar(2000)  NULL,
    [JobPercentage] float  NULL,
    [HoursPerYearForCaseMgmt] int  NULL,
    [Eintrittsdatum] datetime  NULL,
    [Austrittsdatum] datetime  NULL,
    [LohntypCode] int  NULL,
    [Kostentraeger] int  NULL,
    [Kostenart] int  NULL,
    [MigHerkunft] varchar(50)  NULL,
    [MigMAKuerzel] varchar(50)  NULL,
    [MigUserFix] bit  NOT NULL,
    [visdat36Area] varchar(255)  NULL,
    [visdat36SourceFile] varchar(255)  NULL,
    [visdat36ID] varchar(50)  NULL,
    [visdat36Name] varchar(255)  NULL,
    [VerID] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XUserTS] binary(8)  NOT NULL,
    [PhoneMobile] varchar(100)  NULL,
    [Fax] varchar(100)  NULL,
    [RoleTitleCode] int  NULL,
    [QualificationTitleCode] int  NULL,
    [KeinBDEExport] bit  NOT NULL,
    [WeitereKostentraeger] varchar(500)  NULL
);
GO

-- Creating table 'HistoryVersion'
CREATE TABLE [dbo].[HistoryVersion] (
    [VerID] int IDENTITY(1,1) NOT NULL,
    [VersionDate] datetime  NOT NULL,
    [HostName] varchar(100)  NOT NULL,
    [SystemUser] varchar(100)  NOT NULL,
    [AppName] varchar(100)  NOT NULL,
    [dbUser] nvarchar(128)  NOT NULL,
    [SessionID] int  NOT NULL,
    [AppUser] varchar(100)  NULL,
    [UserAction] varchar(1000)  NULL
);
GO

-- Creating table 'BDELeistungsart'
CREATE TABLE [dbo].[BDELeistungsart] (
    [BDELeistungsartID] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] varchar(200)  NOT NULL,
    [BezeichnungTID] int  NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [SortKey] int  NULL,
    [KlientErfassungCode] int  NULL,
    [AnzahlCode] int  NULL,
    [ArtikelNr] varchar(50)  NULL,
    [LeistungsartTypCode] int  NOT NULL,
    [KostenartCode] int  NULL,
    [KTRStandard] varchar(20)  NULL,
    [KTRIV] varchar(20)  NULL,
    [KTRAHV] varchar(20)  NULL,
    [KTRNichtberechtigte] varchar(20)  NULL,
    [Beschreibung] varchar(1000)  NULL,
    [AuswDienstleistungCode] int  NULL,
    [AuswFakturaCode] int  NULL,
    [AuswProduktCode] int  NULL,
    [AuswPIAuftragCode] int  NULL,
    [BDELeistungsartTS] binary(8)  NOT NULL,
    [VerID] int  NULL
);
GO

-- Creating table 'BDEPensum_XUser'
CREATE TABLE [dbo].[BDEPensum_XUser] (
    [BDEPensum_XUserID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [PensumProzent] int  NOT NULL,
    [ManualEdit] bit  NOT NULL,
    [BDEPensum_XUserTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FsReduktion'
CREATE TABLE [dbo].[FsReduktion] (
    [FsReduktionID] int IDENTITY(1,1) NOT NULL,
    [BDELeistungsartID] int  NULL,
    [Name] varchar(255)  NOT NULL,
    [StandardAufwand] decimal(19,4)  NOT NULL,
    [AbhaengigVonBG] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FsReduktionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FsReduktionMitarbeiter'
CREATE TABLE [dbo].[FsReduktionMitarbeiter] (
    [FsReduktionMitarbeiterID] int IDENTITY(1,1) NOT NULL,
    [FsReduktionID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Monat] int  NOT NULL,
    [Jahr] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FsReduktionMitarbeiterTS] binary(8)  NOT NULL,
    [OriginalReduktionZeit] decimal(19,4)  NOT NULL,
    [AngepassteReduktionZeit] decimal(19,4)  NULL
);
GO

-- Creating table 'FaFall'
CREATE TABLE [dbo].[FaFall] (
    [FaFallID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [BaPersonID] int  NOT NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL
);
GO

-- Creating table 'vwBaKlientensystemPerson'
CREATE TABLE [dbo].[vwBaKlientensystemPerson] (
    [FaFallID] int  NOT NULL,
    [BaPersonID] int  NOT NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL
);
GO

-- Creating table 'BaBank'
CREATE TABLE [dbo].[BaBank] (
    [BaBankID] int IDENTITY(1,1) NOT NULL,
    [LandCode] int  NULL,
    [Name] varchar(70)  NOT NULL,
    [Zusatz] varchar(50)  NULL,
    [Strasse] varchar(50)  NULL,
    [PLZ] varchar(10)  NULL,
    [Ort] varchar(50)  NULL,
    [ClearingNr] varchar(15)  NOT NULL,
    [ClearingNrNeu] varchar(15)  NULL,
    [FilialeNr] int  NOT NULL,
    [HauptsitzBCL] varchar(15)  NULL,
    [PCKontoNr] varchar(50)  NULL,
    [GueltigAb] datetime  NOT NULL,
    [SicUpdated] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [BaBankTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BaInstitution'
CREATE TABLE [dbo].[BaInstitution] (
    [BaInstitutionID] int IDENTITY(1,1) NOT NULL,
    [OrgUnitID] int  NULL,
    [InstitutionNr] varchar(20)  NULL,
    [BaInstitutionArtCode] int  NULL,
    [Aktiv] bit  NOT NULL,
    [Debitor] bit  NOT NULL,
    [Kreditor] bit  NOT NULL,
    [KeinSerienbrief] bit  NOT NULL,
    [ManuelleAnrede] bit  NOT NULL,
    [Anrede] varchar(100)  NULL,
    [Briefanrede] varchar(100)  NULL,
    [Titel] varchar(100)  NULL,
    [Name] varchar(500)  NULL,
    [Vorname] varchar(100)  NULL,
    [GeschlechtCode] int  NULL,
    [Telefon] varchar(100)  NULL,
    [Telefon2] varchar(100)  NULL,
    [Telefon3] varchar(100)  NULL,
    [Fax] varchar(100)  NULL,
    [EMail] varchar(100)  NULL,
    [Homepage] varchar(100)  NULL,
    [SprachCode] int  NULL,
    [Bemerkung] varchar(max)  NULL,
    [Creator] varchar(50)  NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NULL,
    [Modified] datetime  NOT NULL,
    [BaInstitutionTS] binary(8)  NOT NULL,
    [InstitutionName] varchar(100)  NULL,
    [InstitutionTypCode] int  NULL,
    [BaFreigabeStatusCode] int  NULL,
    [DefinitivUserID] int  NULL,
    [DefinitivDatum] datetime  NULL,
    [ErstelltUserID] int  NULL,
    [ErstelltDatum] datetime  NULL,
    [MutiertUserID] int  NULL,
    [MutiertDatum] datetime  NULL
);
GO

-- Creating table 'BaLand'
CREATE TABLE [dbo].[BaLand] (
    [BaLandID] int IDENTITY(1,1) NOT NULL,
    [Text] varchar(200)  NOT NULL,
    [TextFR] varchar(200)  NOT NULL,
    [TextIT] varchar(200)  NOT NULL,
    [TextEN] varchar(200)  NOT NULL,
    [Iso2Code] varchar(2)  NULL,
    [Iso3Code] varchar(3)  NULL,
    [BFSCode] int  NULL,
    [SortKey] int  NULL,
    [SAPCode] varchar(20)  NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [BaLandTS] binary(8)  NOT NULL,
    [BFSDelivered] bit  NOT NULL
);
GO

-- Creating table 'XUserGroup_Right'
CREATE TABLE [dbo].[XUserGroup_Right] (
    [UserGroup_RightID] int IDENTITY(1,1) NOT NULL,
    [UserGroupID] int  NOT NULL,
    [RightID] int  NULL,
    [MaskName] varchar(100)  NULL,
    [MayInsert] bit  NOT NULL,
    [MayUpdate] bit  NOT NULL,
    [MayDelete] bit  NOT NULL,
    [XUserGroup_RightTS] binary(8)  NOT NULL,
    [QueryName] varchar(100)  NULL,
    [ClassName] varchar(255)  NULL,
    [XClassID] int  NULL
);
GO

-- Creating table 'BaZahlungsweg'
CREATE TABLE [dbo].[BaZahlungsweg] (
    [BaZahlungswegID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NULL,
    [BaInstitutionID] int  NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NULL,
    [EinzahlungsscheinCode] int  NULL,
    [BaBankID] int  NULL,
    [BankKontoNummer] varchar(50)  NULL,
    [IBANNummer] varchar(50)  NULL,
    [PostKontoNummer] varchar(20)  NULL,
    [ReferenzNummer] varchar(50)  NULL,
    [AdresseName] varchar(35)  NULL,
    [AdresseName2] varchar(35)  NULL,
    [AdresseStrasse] varchar(35)  NULL,
    [AdresseHausNr] varchar(35)  NULL,
    [AdressePostfach] varchar(35)  NULL,
    [AdressePLZ] varchar(10)  NULL,
    [AdresseOrt] varchar(25)  NULL,
    [AdresseLandCode] int  NULL,
    [BaZahlwegModulStdCodes] varchar(20)  NULL,
    [BaZahlungswegTS] binary(8)  NOT NULL
);
GO

-- Creating table 'VmPositionsart'
CREATE TABLE [dbo].[VmPositionsart] (
    [VmPositionsartID] int IDENTITY(1,1) NOT NULL,
    [VmKategorieCode] int  NOT NULL,
    [VmPositionsartTypCode] int  NULL,
    [IstTemplate] bit  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [SortKey] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [VmPositionsartTS] binary(8)  NOT NULL
);
GO

-- Creating table 'VmKlientenbudget'
CREATE TABLE [dbo].[VmKlientenbudget] (
    [VmKlientenbudgetID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [VmKlientenbudgetStatusCode] int  NOT NULL,
    [GueltigAb] datetime  NOT NULL,
    [VmKlientenbudgetMutationsgrundCode] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [VmKlientenbudgetTS] binary(8)  NOT NULL
);
GO

-- Creating table 'VmPosition'
CREATE TABLE [dbo].[VmPosition] (
    [VmPositionID] int IDENTITY(1,1) NOT NULL,
    [VmKlientenbudgetID] int  NOT NULL,
    [VmPositionsartID] int  NOT NULL,
    [IstImportiert] bit  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Bemerkung] varchar(1000)  NULL,
    [DatumSaldoPer] datetime  NULL,
    [Saldo] decimal(19,4)  NULL,
    [BetragMonatlich] decimal(19,4)  NULL,
    [BetragJaehrlich] decimal(19,4)  NULL,
    [SortKey] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [VmPositionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FbBuchung'
CREATE TABLE [dbo].[FbBuchung] (
    [FbBuchungID] int IDENTITY(1,1) NOT NULL,
    [FbPeriodeID] int  NOT NULL,
    [BuchungTypCode] int  NOT NULL,
    [Code] varchar(10)  NULL,
    [BelegNr] varchar(15)  NOT NULL,
    [BelegNrPos] int  NOT NULL,
    [BuchungsDatum] datetime  NOT NULL,
    [SollKtoNr] int  NULL,
    [HabenKtoNr] int  NULL,
    [Betrag] decimal(19,4)  NOT NULL,
    [Text] varchar(200)  NOT NULL,
    [ValutaDatum] datetime  NULL,
    [Zahlungsfrist] int  NULL,
    [BuchungStatusCode] int  NULL,
    [FbDauerauftragID] int  NULL,
    [ErfassungsDatum] datetime  NULL,
    [UserID] int  NULL,
    [FbZahlungswegID] int  NULL,
    [PCKontoNr] varchar(50)  NULL,
    [BankKontoNr] varchar(50)  NULL,
    [ZahlungsArtCode] int  NULL,
    [ReferenzNummer] varchar(50)  NULL,
    [Zahlungsgrund] varchar(200)  NULL,
    [Name] varchar(100)  NULL,
    [Zusatz] varchar(50)  NULL,
    [Strasse] varchar(200)  NULL,
    [PLZ] varchar(8)  NULL,
    [Ort] varchar(50)  NULL,
    [FbBuchungTS] binary(8)  NOT NULL,
    [IBAN] varchar(50)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [ValutaDatumOriginal] datetime  NULL
);
GO

-- Creating table 'FbKonto'
CREATE TABLE [dbo].[FbKonto] (
    [FbKontoID] int IDENTITY(1,1) NOT NULL,
    [FbPeriodeID] int  NULL,
    [KontoKlasseCode] int  NOT NULL,
    [KontoTypCode] int  NOT NULL,
    [KontoNr] int  NOT NULL,
    [KontoName] varchar(100)  NOT NULL,
    [EroeffnungsSaldo] decimal(19,4)  NOT NULL,
    [SaldoGruppeName] varchar(20)  NULL,
    [FbDTAZugangID] int  NULL,
    [FbKontoTS] binary(8)  NOT NULL,
    [FbDepotNr] varchar(20)  NULL,
    [EroeffnungsSaldoModifier] varchar(50)  NULL,
    [EroeffnungsSaldoModified] datetime  NULL,
    [EroeffnungsSaldoCreator] varchar(50)  NULL,
    [EroeffnungsSaldoCreated] datetime  NULL,
    [EroeffnungsSaldo_AtCreation] decimal(19,4)  NULL
);
GO

-- Creating table 'FbPeriode'
CREATE TABLE [dbo].[FbPeriode] (
    [FbPeriodeID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [PeriodeVon] datetime  NOT NULL,
    [PeriodeBis] datetime  NOT NULL,
    [PeriodeStatusCode] int  NOT NULL,
    [FbTeamID] int  NULL,
    [JournalablageortCode] int  NULL,
    [FbPeriodeTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaAktennotizen'
CREATE TABLE [dbo].[FaAktennotizen] (
    [FaAktennotizID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NULL,
    [Datum] datetime  NULL,
    [Zeit] datetime  NULL,
    [FaDauerCode] int  NULL,
    [FaGespraechsStatusCode] int  NULL,
    [FaThemaCodes] varchar(255)  NULL,
    [FaGespraechstypCode] int  NULL,
    [Kontaktpartner] varchar(200)  NULL,
    [AlimentenstelleTypCode] int  NULL,
    [Stichwort] varchar(200)  NULL,
    [InhaltRTF] varchar(max)  NULL,
    [Vertraulich] bit  NOT NULL,
    [BesprechungThema1] bit  NULL,
    [BesprechungThema2] bit  NULL,
    [BesprechungThema3] bit  NULL,
    [BesprechungThema4] bit  NULL,
    [BesprechungThemaText1] varchar(200)  NULL,
    [BesprechungThemaText2] varchar(200)  NULL,
    [BesprechungThemaText3] varchar(200)  NULL,
    [BesprechungThemaText4] varchar(200)  NULL,
    [BesprechungZiel1] varchar(200)  NULL,
    [BesprechungZiel2] varchar(200)  NULL,
    [BesprechungZiel3] varchar(200)  NULL,
    [BesprechungZiel4] varchar(200)  NULL,
    [BesprechungZielGrad1] int  NULL,
    [BesprechungZielGrad2] int  NULL,
    [BesprechungZielGrad3] int  NULL,
    [BesprechungZielGrad4] int  NULL,
    [FaKontaktartCode] int  NULL,
    [Pendenz1] varchar(200)  NULL,
    [Pendenz2] varchar(200)  NULL,
    [Pendenz3] varchar(200)  NULL,
    [Pendenz4] varchar(200)  NULL,
    [PendenzErledigt1] bit  NULL,
    [PendenzErledigt2] bit  NULL,
    [PendenzErledigt3] bit  NULL,
    [PendenzErledigt4] bit  NULL,
    [IsDeleted] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaAktennotizTS] binary(8)  NOT NULL,
    [BaPersonIDs] varchar(200)  NULL
);
GO

-- Creating table 'FaDokumente'
CREATE TABLE [dbo].[FaDokumente] (
    [FaDokumenteID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [BaPersonID_LT] int  NULL,
    [BaPersonID_Adressat] int  NULL,
    [BaInstitutionID_Adressat] int  NULL,
    [VmPriMaID_Adressat] int  NULL,
    [UserID_Absender] int  NULL,
    [UserID_VisumBeantragtDurch] int  NULL,
    [UserID_VisumBeantragtBei] int  NULL,
    [UserID_VisiertDurch] int  NULL,
    [UserID_EkVisumUser] int  NULL,
    [DocumentID] int  NULL,
    [DocumentID_Merkblatt] int  NULL,
    [DatumErstellung] datetime  NULL,
    [StatusCode] int  NULL,
    [PendenzDatum] datetime  NULL,
    [PendenzErledigt] bit  NULL,
    [VmErbDienstCode] int  NULL,
    [FaDauerCode] int  NULL,
    [Stichwort] varchar(200)  NULL,
    [EingangAusgang] int  NULL,
    [ThemaCode] int  NULL,
    [VisumBeantragtDatum] datetime  NULL,
    [VisiertDatum] datetime  NULL,
    [EkStatusCode] int  NULL,
    [EkLaufNr] int  NULL,
    [EkKW] int  NULL,
    [EkJahr] int  NULL,
    [EkVisumDatum] datetime  NULL,
    [Bemerkung] varchar(500)  NULL,
    [FaThemaCodes] varchar(200)  NULL,
    [Vertraulich] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [IstBericht] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaDokumenteTS] binary(8)  NOT NULL,
    [BaPersonIDs] varchar(200)  NULL
);
GO

-- Creating table 'FaWeisung'
CREATE TABLE [dbo].[FaWeisung] (
    [FaWeisungID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID_Creator] int  NOT NULL,
    [UserID_VerantwortlichRD] int  NULL,
    [UserID_VerantwortlichSAR] int  NULL,
    [XTaskID_SAR] int  NULL,
    [StatusCode] int  NOT NULL,
    [WeisungsartCode] int  NOT NULL,
    [Betreff] varchar(100)  NOT NULL,
    [Ausganslage] varchar(max)  NULL,
    [Auflage] varchar(max)  NULL,
    [KonsequenzCodeAngedroht] int  NOT NULL,
    [KuerzungGBAngedroht] int  NOT NULL,
    [TerminWeisung] datetime  NULL,
    [XDocumentID_Weisung] int  NULL,
    [TerminMahnung1] datetime  NULL,
    [XDocumentID_Mahnung1] int  NULL,
    [TerminMahnung2] datetime  NULL,
    [XDocumentID_Mahnung2] int  NULL,
    [TerminMahnung3] datetime  NULL,
    [XDocumentID_Mahnung3] int  NULL,
    [DatumVerfuegung] datetime  NULL,
    [XDocumentID_Verfuegung] int  NULL,
    [KonsequenzCodeVerfuegt] int  NULL,
    [KonsequenzDatumVon] datetime  NULL,
    [KonsequenzDatumBis] datetime  NULL,
    [KuerzungGBVerfuegt] int  NULL,
    [KuerzungDatumVon] datetime  NULL,
    [KuerzungDatumBis] datetime  NULL,
    [WeisungVerschoben] bit  NOT NULL,
    [WeisungErfuellt] bit  NOT NULL,
    [CanDelete] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaWeisungTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XTask'
CREATE TABLE [dbo].[XTask] (
    [XTaskID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NULL,
    [FaFallID] int  NULL,
    [FaLeistungID] int  NULL,
    [UserID_Erledigt] int  NULL,
    [UserID_InBearbeitung] int  NULL,
    [FaAktennotizID] int  NULL,
    [FaDokumenteID] int  NULL,
    [TaskTypeCode] int  NULL,
    [TaskStatusCode] int  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [StartDate] datetime  NULL,
    [ExpirationDate] datetime  NULL,
    [DoneDate] datetime  NULL,
    [Subject] varchar(100)  NULL,
    [TaskDescription] varchar(2500)  NULL,
    [SenderID] int  NULL,
    [TaskSenderCode] int  NULL,
    [ReceiverID] int  NULL,
    [TaskReceiverCode] int  NULL,
    [ResponseText] varchar(2500)  NULL,
    [TaskResponseCode] int  NULL,
    [JumpToPath] varchar(1500)  NULL,
    [XTaskTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XDocument'
CREATE TABLE [dbo].[XDocument] (
    [DocumentID] int IDENTITY(1,1) NOT NULL,
    [DateCreation] datetime  NOT NULL,
    [UserID_Creator] int  NULL,
    [DateLastSave] datetime  NOT NULL,
    [UserID_LastSave] int  NULL,
    [FileBinary] varbinary(max)  NOT NULL,
    [DocFormatCode] int  NULL,
    [FileExtension] varchar(10)  NULL,
    [DocReadOnly] bit  NOT NULL,
    [DocTemplateID] int  NULL,
    [XDocumentTS] binary(8)  NOT NULL,
    [DocTypeCode] int  NULL,
    [DocTemplateName] varchar(255)  NULL,
    [CheckOut_UserID] int  NULL,
    [CheckOut_Date] datetime  NULL,
    [CheckOut_Filename] varchar(max)  NULL,
    [CheckOut_Machine] varchar(max)  NULL,
    [UserID_LastRead] int  NULL,
    [DateLastRead] datetime  NULL,
    [KesDokumentKesDokumentID] int  NULL
);
GO

-- Creating table 'FaWeisungProtokoll'
CREATE TABLE [dbo].[FaWeisungProtokoll] (
    [FaWeisungProtokollID] int IDENTITY(1,1) NOT NULL,
    [FaWeisungID] int  NOT NULL,
    [Aktion] varchar(100)  NULL,
    [Bemerkung] varchar(200)  NULL,
    [Termin] datetime  NULL,
    [Verantwortlich] varchar(50)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaWeisung_ProtokollTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaPendenzgruppe'
CREATE TABLE [dbo].[FaPendenzgruppe] (
    [FaPendenzgruppeID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Beschreibung] varchar(500)  NULL,
    [FaPendenzgruppeTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaWeisung_BaPerson'
CREATE TABLE [dbo].[FaWeisung_BaPerson] (
    [FaWeisung_BaPersonID] int IDENTITY(1,1) NOT NULL,
    [FaWeisungID] int  NOT NULL,
    [BaPersonID] int  NOT NULL,
    [FaWeisung_BaPersonTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaKategorisierung'
CREATE TABLE [dbo].[FaKategorisierung] (
    [FaKategorisierungID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Datum] datetime  NOT NULL,
    [FaKategorisierungEksProduktID] int  NULL,
    [FaKategorisierungEksOptionCode] int  NULL,
    [FaKategorisierungKiStatusCode] int  NULL,
    [FaKategorisierungIntakeCode] int  NULL,
    [FaKategorisierungKooperationCode] int  NULL,
    [FaKategorisierungRessourcenCode] int  NULL,
    [FaKategorisierungAbschlussgrundCode] int  NULL,
    [Abschlussdatum] datetime  NULL,
    [Begruendung] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaKategorisierungTS] binary(8)  NOT NULL,
    [FaKategorieCode] int  NULL
);
GO

-- Creating table 'FaKategorisierungEksProdukt'
CREATE TABLE [dbo].[FaKategorisierungEksProdukt] (
    [FaKategorisierungEksProduktID] int IDENTITY(1,1) NOT NULL,
    [OrgUnitID] int  NOT NULL,
    [Text] varchar(100)  NOT NULL,
    [ShortText] varchar(50)  NOT NULL,
    [Frist] int  NULL,
    [FaKategorisierungEksProduktFristTypCode] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaKategorisierungEksProduktTS] binary(8)  NOT NULL,
    [FaKategorieCode] int  NOT NULL
);
GO

-- Creating table 'FaLeistungUserHist'
CREATE TABLE [dbo].[FaLeistungUserHist] (
    [FaLeistungUserHistID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [DatumVon] datetime  NOT NULL,
    [DatumBis] datetime  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaLeistungUserHistTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaLeistungArchiv'
CREATE TABLE [dbo].[FaLeistungArchiv] (
    [FaLeistungArchivID] int IDENTITY(1,1) NOT NULL,
    [ArchiveID] int  NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [ArchivNr] varchar(100)  NULL,
    [CheckIn] datetime  NOT NULL,
    [CheckOut] datetime  NULL,
    [CheckInUserID] int  NOT NULL,
    [CheckOutUserID] int  NULL,
    [FaLeistungArchivTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XConfig'
CREATE TABLE [dbo].[XConfig] (
    [XConfigID] int IDENTITY(1,1) NOT NULL,
    [XNamespaceExtensionID] int  NULL,
    [KeyPath] varchar(500)  NOT NULL,
    [System] bit  NOT NULL,
    [DatumVon] datetime  NULL,
    [ValueCode] int  NOT NULL,
    [LOVName] varchar(100)  NULL,
    [Description] varchar(1000)  NULL,
    [ValueBit] bit  NULL,
    [OriginalValueBit] bit  NULL,
    [ValueDateTime] datetime  NULL,
    [OriginalValueDateTime] datetime  NULL,
    [ValueDecimal] decimal(18,0)  NULL,
    [OriginalValueDecimal] decimal(18,0)  NULL,
    [ValueInt] int  NULL,
    [OriginalValueInt] int  NULL,
    [ValueMoney] decimal(19,4)  NULL,
    [OriginalValueMoney] decimal(19,4)  NULL,
    [ValueVarchar] varchar(max)  NULL,
    [OriginalValueVarchar] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XConfigTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BaGemeinde'
CREATE TABLE [dbo].[BaGemeinde] (
    [BaGemeindeID] int  NOT NULL,
    [PLZ] int  NULL,
    [Name] varchar(100)  NOT NULL,
    [NameTID] int  NULL,
    [BezirkCode] int  NULL,
    [BezirkName] varchar(100)  NULL,
    [BezirkNameTID] int  NULL,
    [Kanton] varchar(2)  NULL,
    [BFSCode] int  NULL,
    [BaGemeindeTS] binary(8)  NOT NULL,
    [NameLang] varchar(150)  NULL,
    [GemeindeEintragArt] int  NULL,
    [GemeindeStatus] int  NULL,
    [GemeindeAufnahmeNummer] int  NULL,
    [GemeindeAufnahmeModus] int  NULL,
    [GemeindeAufnahmeDatum] datetime  NULL,
    [GemeindeAufhebungNummer] int  NULL,
    [GemeindeAufhebungModus] int  NULL,
    [GemeindeAufhebungDatum] datetime  NULL,
    [GemeindeAenderungDatum] datetime  NULL,
    [GemeindeHistorisierungID] int  NULL,
    [BezirkNameLang] varchar(150)  NULL,
    [BezirkEintragArt] int  NULL,
    [BezirkAufnahmeNummer] int  NULL,
    [BezirkAufnahmeModus] int  NULL,
    [BezirkAufnahmeDatum] datetime  NULL,
    [BezirkAufhebungNummer] int  NULL,
    [BezirkAufhebungModus] int  NULL,
    [BezirkAufhebungDatum] datetime  NULL,
    [BezirkAenderungDatum] datetime  NULL,
    [KantonID] int  NULL,
    [KantonNameLang] varchar(100)  NULL,
    [BFSDelivered] bit  NULL
);
GO

-- Creating table 'BaPLZ'
CREATE TABLE [dbo].[BaPLZ] (
    [BaPLZID] int IDENTITY(1,1) NOT NULL,
    [PLZ] int  NOT NULL,
    [PLZ6] int  NULL,
    [PLZSuffix] int  NULL,
    [Name] varchar(100)  NOT NULL,
    [NameTID] int  NULL,
    [Kanton] varchar(2)  NOT NULL,
    [SortKey] int  NOT NULL,
    [BFSCode] int  NOT NULL,
    [System] bit  NOT NULL,
    [BaPLZTS] binary(8)  NOT NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [ONRP] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL
);
GO

-- Creating table 'XClass'
CREATE TABLE [dbo].[XClass] (
    [XClassID] int IDENTITY(1,1) NOT NULL,
    [ClassName] varchar(255)  NOT NULL,
    [ModulID] int  NOT NULL,
    [MaskName] varchar(100)  NULL,
    [BaseType] varchar(500)  NOT NULL,
    [ClassCode] int  NULL,
    [ClassTID] int  NULL,
    [PropertiesXML] varchar(max)  NULL,
    [Designer] int  NOT NULL,
    [Description] varchar(max)  NULL,
    [CodeGenerated] varchar(max)  NULL,
    [Resource] varbinary(max)  NULL,
    [Assembly] varbinary(max)  NULL,
    [Branch] varchar(128)  NULL,
    [BuildNr] int  NOT NULL,
    [System] bit  NOT NULL,
    [CheckOut_UserID] int  NULL,
    [CheckOut_Date] datetime  NULL,
    [NamespaceExtension] varchar(50)  NULL,
    [XClassTS] binary(8)  NOT NULL,
    [ClassNameViewModel] varchar(255)  NULL
);
GO

-- Creating table 'XRight'
CREATE TABLE [dbo].[XRight] (
    [RightID] int IDENTITY(1,1) NOT NULL,
    [XClassID] int  NOT NULL,
    [ClassName] varchar(255)  NOT NULL,
    [RightName] varchar(100)  NOT NULL,
    [UserText] varchar(255)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XRightTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XUserGroup'
CREATE TABLE [dbo].[XUserGroup] (
    [UserGroupID] int IDENTITY(1,1) NOT NULL,
    [UserGroupName] varchar(100)  NOT NULL,
    [UserGroupNameTID] int  NULL,
    [OnlyAdminVisible] bit  NOT NULL,
    [Description] varchar(max)  NULL,
    [DescriptionTID] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XUserGroupTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XOrgUnit'
CREATE TABLE [dbo].[XOrgUnit] (
    [OrgUnitID] int IDENTITY(1,1) NOT NULL,
    [ParentID] int  NULL,
    [ModulID] int  NULL,
    [ChiefID] int  NULL,
    [RechtsdienstUserID] int  NULL,
    [RepresentativeID] int  NULL,
    [StellvertreterID] int  NULL,
    [XProfileID] int  NULL,
    [ItemName] varchar(100)  NOT NULL,
    [OEItemTypCode] int  NULL,
    [ParentPosition] int  NULL,
    [Kostenstelle] int  NULL,
    [Mandantennummer] int  NULL,
    [StundenLohnlaufNr] int  NULL,
    [LeistungLohnlaufNr] int  NULL,
    [Sammelkonto] int  NULL,
    [PCKonto] varchar(100)  NULL,
    [AD_Abteilung] varchar(2000)  NULL,
    [Logo] varchar(max)  NULL,
    [Adressat] varchar(2000)  NULL,
    [Adresse] varchar(2000)  NULL,
    [AdresseKGS] varchar(100)  NULL,
    [AdresseAbteilung] varchar(100)  NULL,
    [AdresseStrasse] varchar(100)  NULL,
    [Postfach] varchar(100)  NULL,
    [PostfachOhneNr] bit  NOT NULL,
    [AdresseHausNr] varchar(10)  NULL,
    [AdressePLZ] varchar(10)  NULL,
    [AdresseOrt] varchar(50)  NULL,
    [Phone] varchar(100)  NULL,
    [Telefon] varchar(100)  NULL,
    [Fax] varchar(100)  NULL,
    [EMail] varchar(100)  NULL,
    [WWW] varchar(100)  NULL,
    [Internet] varchar(100)  NULL,
    [UserProfileCode] int  NULL,
    [Text1] varchar(2000)  NULL,
    [Text2] varchar(2000)  NULL,
    [Text3] varchar(2000)  NULL,
    [Text4] varchar(2000)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [VerID] int  NULL,
    [XOrgUnitTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XOrgUnit_User'
CREATE TABLE [dbo].[XOrgUnit_User] (
    [XOrgUnit_UserID] int IDENTITY(1,1) NOT NULL,
    [OrgUnitID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [OrgUnitMemberCode] int  NOT NULL,
    [MayInsert] bit  NOT NULL,
    [MayUpdate] bit  NOT NULL,
    [MayDelete] bit  NOT NULL,
    [VerID] int  NULL,
    [XOrgUnit_UserTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BaGesundheit'
CREATE TABLE [dbo].[BaGesundheit] (
    [BaGesundheitID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [Jahr] int  NOT NULL,
    [KVGOrganisationID] int  NULL,
    [KVGKontaktPerson] varchar(100)  NULL,
    [KVGKontaktTelefon] varchar(100)  NULL,
    [KVGMitgliedNr] varchar(50)  NULL,
    [KVGVersichertSeit] datetime  NULL,
    [KVGGrundPraemie] decimal(19,4)  NULL,
    [KVGUnfallPraemie] decimal(19,4)  NULL,
    [KVGGesundFoerdPraemie] decimal(19,4)  NULL,
    [KVGZuschussBetrag] decimal(19,4)  NULL,
    [KVGUmweltabgabeBetrag] decimal(19,4)  NULL,
    [KVGPraemie] decimal(19,4)  NULL,
    [KVGFranchise] decimal(19,4)  NULL,
    [KVGZahlungsPeriodeCode] int  NULL,
    [VVGOrganisationID] int  NULL,
    [VVGKontaktPerson] varchar(100)  NULL,
    [VVGKontaktTelefon] varchar(100)  NULL,
    [VVGMitgliedNr] varchar(50)  NULL,
    [VVGVersichertSeit] datetime  NULL,
    [VVGPraemie] decimal(19,4)  NULL,
    [VVGFranchise] decimal(19,4)  NULL,
    [VVGZahlungsPeriodeCode] int  NULL,
    [VVGZusaetzeRTF] varchar(2000)  NULL,
    [ZuschussInAbklaerungFlag] bit  NULL,
    [IVEingliederungsmassnahmeCode] int  NULL,
    [PflegeDurchCode] int  NULL,
    [PflegebeduerftigFlag] bit  NULL,
    [DatumVon] datetime  NULL,
    [ASVSAbmeldung] datetime  NULL,
    [ASVSAnmeldung] datetime  NULL,
    [Bemerkung] varchar(max)  NULL,
    [AbtretungKK] bit  NOT NULL,
    [EVAZDatum] datetime  NULL,
    [ZahnarztBaInstitutionID] int  NULL,
    [BaGesundheitTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaLeistungZugriff'
CREATE TABLE [dbo].[FaLeistungZugriff] (
    [FaLeistungZugriffID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [DarfMutieren] bit  NOT NULL,
    [FaLeistungZugriffTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BDESollStundenProJahr_XUser'
CREATE TABLE [dbo].[BDESollStundenProJahr_XUser] (
    [BDESollStundenProJahr_XUserID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Jahr] int  NOT NULL,
    [JanuarStd] decimal(19,4)  NOT NULL,
    [FebruarStd] decimal(19,4)  NOT NULL,
    [MaerzStd] decimal(19,4)  NOT NULL,
    [AprilStd] decimal(19,4)  NOT NULL,
    [MaiStd] decimal(19,4)  NOT NULL,
    [JuniStd] decimal(19,4)  NOT NULL,
    [JuliStd] decimal(19,4)  NOT NULL,
    [AugustStd] decimal(19,4)  NOT NULL,
    [SeptemberStd] decimal(19,4)  NOT NULL,
    [OktoberStd] decimal(19,4)  NOT NULL,
    [NovemberStd] decimal(19,4)  NOT NULL,
    [DezemberStd] decimal(19,4)  NOT NULL,
    [TotalStd] decimal(19,4)  NOT NULL,
    [ManualEdit] bit  NOT NULL,
    [BDESollStundenProJahr_XUserTS] binary(8)  NOT NULL,
    [VerID] int  NULL
);
GO

-- Creating table 'XUser_UserGroup'
CREATE TABLE [dbo].[XUser_UserGroup] (
    [XUser_UserGroupID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [UserGroupID] int  NOT NULL,
    [XUser_UserGroupTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XLOV'
CREATE TABLE [dbo].[XLOV] (
    [XLOVID] int IDENTITY(1,1) NOT NULL,
    [LOVName] varchar(100)  NOT NULL,
    [Description] varchar(500)  NULL,
    [System] bit  NOT NULL,
    [Expandable] bit  NOT NULL,
    [ModulID] int  NULL,
    [LastUpdated] datetime  NULL,
    [Translatable] bit  NOT NULL,
    [NameValue1] varchar(100)  NULL,
    [NameValue2] varchar(100)  NULL,
    [NameValue3] varchar(100)  NULL,
    [XLOVTS] binary(8)  NOT NULL
);
GO

-- Creating table 'UserSession'
CREATE TABLE [dbo].[UserSession] (
    [UserSessionID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [LogonName] varchar(200)  NOT NULL,
    [LoginDatum] datetime  NOT NULL,
    [LogoutDatum] datetime  NULL,
    [UserName] varchar(200)  NULL,
    [UserDomainName] varchar(200)  NULL,
    [MachineName] varchar(50)  NULL,
    [ClientVersion] varchar(50)  NULL,
    [WindowsVersion] varchar(50)  NULL,
    [DotNetVersion] varchar(50)  NULL,
    [AufloesungBreite] int  NULL,
    [AufloesungHoehe] int  NULL,
    [OfficeVersionWord] varchar(50)  NULL,
    [OfficeVersionExcel] varchar(50)  NULL,
    [OfficeVersionOutlook] varchar(50)  NULL,
    [CultureInfo] varchar(50)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [UserSessionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XLOVCode'
CREATE TABLE [dbo].[XLOVCode] (
    [XLOVCodeID] int IDENTITY(1,1) NOT NULL,
    [XLOVID] int  NOT NULL,
    [LOVName] varchar(100)  NOT NULL,
    [Code] int  NOT NULL,
    [Text] varchar(200)  NOT NULL,
    [TextTID] int  NULL,
    [SortKey] int  NULL,
    [ShortText] varchar(20)  NULL,
    [ShortTextTID] int  NULL,
    [BFSCode] int  NULL,
    [Value1] varchar(2000)  NULL,
    [Value1TID] int  NULL,
    [Value2] varchar(255)  NULL,
    [Value2TID] int  NULL,
    [Value3] varchar(255)  NULL,
    [Value3TID] int  NULL,
    [Description] varchar(1000)  NULL,
    [LOVCodeName] varchar(200)  NULL,
    [IsActive] bit  NOT NULL,
    [System] bit  NOT NULL,
    [XLOVCodeTS] binary(8)  NOT NULL
);
GO

-- Creating table 'FaDokumentAblage'
CREATE TABLE [dbo].[FaDokumentAblage] (
    [FaDokumentAblageID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [BaPersonID_Adressat] int  NULL,
    [BaInstitutionID_Adressat] int  NULL,
    [FaDokumentAblageInhaltCode] int  NULL,
    [DatumErstellung] datetime  NULL,
    [DatumGueltigVon] datetime  NULL,
    [DatumGueltigBis] datetime  NULL,
    [Stichwort] varchar(max)  NULL,
    [Bemerkung] varchar(max)  NULL,
    [DocumentID] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaDokumentAblageTS] binary(8)  NOT NULL,
    [FaThemaDokAblageCodes] varchar(250)  NULL
);
GO

-- Creating table 'FaDokumentAblage_BaPerson'
CREATE TABLE [dbo].[FaDokumentAblage_BaPerson] (
    [FaDokumentAblage_BaPersonID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [FaDokumentAblageID] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [FaDokumentAblage_BaPersonTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BaPerson_Relation'
CREATE TABLE [dbo].[BaPerson_Relation] (
    [BaPerson_RelationID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID_1] int  NOT NULL,
    [BaPersonID_2] int  NOT NULL,
    [BaRelationID] int  NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [Bemerkung] varchar(max)  NULL,
    [BaPerson_RelationTS] binary(8)  NOT NULL
);
GO

-- Creating table 'BaPerson_BaInstitution'
CREATE TABLE [dbo].[BaPerson_BaInstitution] (
    [BaPerson_BaInstitutionID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [BaInstitutionID] int  NOT NULL,
    [BaInstitutionKontaktID] int  NULL,
    [BaInstitutionTypID] int  NULL,
    [Bemerkung] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [BaPerson_BaInstitutionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XTaskAutoGenerated'
CREATE TABLE [dbo].[XTaskAutoGenerated] (
    [XTaskAutoGeneratedID] int IDENTITY(1,1) NOT NULL,
    [XTaskID] int  NOT NULL,
    [ReferenceTable] varchar(100)  NULL,
    [ReferenceID] int  NULL,
    [XTaskAutoGeneratedTypeCode] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [XTaskAutoGeneratedTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XIcon'
CREATE TABLE [dbo].[XIcon] (
    [XIconID] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Icon] varbinary(max)  NULL,
    [XIconTS] binary(8)  NOT NULL
);
GO

-- Creating table 'XModul'
CREATE TABLE [dbo].[XModul] (
    [ModulID] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [ShortName] varchar(10)  NULL,
    [SortKey] int  NULL,
    [NameSpace] varchar(255)  NULL,
    [DB_Prefix] varchar(10)  NULL,
    [ModulTree] bit  NOT NULL,
    [Description] varchar(max)  NULL,
    [System] bit  NOT NULL,
    [XModulTS] binary(8)  NOT NULL,
    [Licensed] bit  NOT NULL
);
GO

-- Creating table 'KesAuftrag'
CREATE TABLE [dbo].[KesAuftrag] (
    [KesAuftragID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [DatumAuftrag] datetime  NULL,
    [DocumentID_Auftrag] int  NULL,
    [UserID] int  NULL,
    [DatumFrist] datetime  NULL,
    [KesAuftragMelderCode] int  NULL,
    [KesAuftragDurchCode] int  NULL,
    [Anlass] varchar(max)  NULL,
    [Auftrag] varchar(max)  NULL,
    [AbschlussDatum] datetime  NULL,
    [KesAuftragAbschlussgrundCode] int  NULL,
    [DocumentID_BeschlussRueckmeldung] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesAuftragTS] binary(8)  NOT NULL,
    [KesAuftragAbklaerungsartCode] int  NULL
);
GO

-- Creating table 'KesPraevention'
CREATE TABLE [dbo].[KesPraevention] (
    [KesPraeventionID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [UserID] int  NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [KesPraeventionsartCode] int  NULL,
    [KesPraeventionsabschlussCode] int  NULL,
    [Bemerkung] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesPraeventionTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesAuftrag_BaPerson'
CREATE TABLE [dbo].[KesAuftrag_BaPerson] (
    [KesAuftrag_BaPersonID] int IDENTITY(1,1) NOT NULL,
    [BaPersonID] int  NOT NULL,
    [KesAuftragID] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesAuftrag_BaPersonTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesMassnahme_KesArtikel'
CREATE TABLE [dbo].[KesMassnahme_KesArtikel] (
    [KesMassnahme_KesArtikelID] int IDENTITY(1,1) NOT NULL,
    [KesMassnahmeID] int  NOT NULL,
    [KesArtikelID] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesMassnahme_KesArtikelTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesArtikel'
CREATE TABLE [dbo].[KesArtikel] (
    [KesArtikelID] int IDENTITY(1,1) NOT NULL,
    [CodeKokes] varchar(7)  NOT NULL,
    [Artikel] varchar(50)  NOT NULL,
    [Absatz] varchar(50)  NULL,
    [Ziffer] varchar(50)  NULL,
    [Gesetz] varchar(50)  NOT NULL,
    [Bezeichnung] varchar(max)  NULL,
    [KesMassnahmeTypCode] int  NOT NULL,
    [IsMassnahmeGebunden] bit  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesArtikelTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesMassnahme'
CREATE TABLE [dbo].[KesMassnahme] (
    [KesMassnahmeID] int IDENTITY(1,1) NOT NULL,
    [FaLeistungID] int  NOT NULL,
    [IsKS] bit  NOT NULL,
    [DocumentID_Errichtungsbeschluss] int  NULL,
    [DocumentID_Aufhebungsbeschluss] int  NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [KesAufgabenbereichCodes] varchar(255)  NULL,
    [KesIndikationCodes] varchar(255)  NULL,
    [Auftragstext] varchar(max)  NULL,
    [Bemerkung] varchar(max)  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesMassnahmeTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesMandatsfuehrendePerson'
CREATE TABLE [dbo].[KesMandatsfuehrendePerson] (
    [KesMandatsfuehrendePersonID] int IDENTITY(1,1) NOT NULL,
    [KesMassnahmeID] int  NOT NULL,
    [DatumMandatVon] datetime  NULL,
    [DatumMandatBis] datetime  NULL,
    [DocumentID_Ernennungsurkunde] int  NULL,
    [UserID] int  NULL,
    [KesBeistandsartCode] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesMandatsfuehrendePersonTS] binary(8)  NOT NULL,
    [DatumVorgeschlagenAm] datetime  NULL,
    [DatumRechnungsfuehrungVon] datetime  NULL,
    [DatumRechnungsfuehrungBis] datetime  NULL
);
GO

-- Creating table 'KesMassnahmeBericht'
CREATE TABLE [dbo].[KesMassnahmeBericht] (
    [KesMassnahmeBerichtID] int IDENTITY(1,1) NOT NULL,
    [KesMassnahmeID] int  NOT NULL,
    [KesMassnahmeGeschaeftsartCode] int  NULL,
    [DatumVon] datetime  NULL,
    [DatumBis] datetime  NULL,
    [Bemerkung] varchar(max)  NULL,
    [DocumentID_Bericht] int  NULL,
    [DocumentID_Versand] int  NULL,
    [DocumentID_BeschlussKESB] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesMassnahmeBerichtTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesMassnahmeAuftrag'
CREATE TABLE [dbo].[KesMassnahmeAuftrag] (
    [KesMassnahmeAuftragID] int IDENTITY(1,1) NOT NULL,
    [KesMassnahmeID] int  NOT NULL,
    [DocumentID_Beschluss] int  NULL,
    [BeschlussVom] datetime  NULL,
    [ErledigungBis] datetime  NULL,
    [Auftrag] varchar(max)  NULL,
    [KesMassnahmeGeschaeftsartCode] int  NULL,
    [DocumentID_Bericht] int  NULL,
    [DocumentID_Versand] int  NULL,
    [DocumentID_BeschlussKESB] int  NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesMassnahmeAuftragTS] binary(8)  NOT NULL
);
GO

-- Creating table 'KesDokument'
CREATE TABLE [dbo].[KesDokument] (
    [KesDokumentID] int IDENTITY(1,1) NOT NULL,
    [KesAuftragID] int  NOT NULL,
    [UserID] int  NULL,
    [BaPersonID_Adressat] int  NULL,
    [BaInstitutionID_Adressat] int  NULL,
    [Stichwort] varchar(max)  NULL,
    [KesDokumentResultatCode] int  NULL,
    [XDocumentID_Dokument] int  NULL,
    [XDocumentID_Versand] int  NULL,
    [KesDokumentTypCode] int  NOT NULL,
    [Creator] varchar(50)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modifier] varchar(50)  NOT NULL,
    [Modified] datetime  NOT NULL,
    [KesDokumentTS] binary(8)  NOT NULL,
    [XDocumentDocumentID] int  NULL,
    [XDocumentDocumentID1] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BaAdresseID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [PK_BaAdresse]
    PRIMARY KEY CLUSTERED ([BaAdresseID] ASC);
GO

-- Creating primary key on [BaPersonID] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [PK_BaPerson]
    PRIMARY KEY CLUSTERED ([BaPersonID] ASC);
GO

-- Creating primary key on [XDBVersionID] in table 'XDBVersion'
ALTER TABLE [dbo].[XDBVersion]
ADD CONSTRAINT [PK_XDBVersion]
    PRIMARY KEY CLUSTERED ([XDBVersionID] ASC);
GO

-- Creating primary key on [FsDienstleistungID] in table 'FsDienstleistung'
ALTER TABLE [dbo].[FsDienstleistung]
ADD CONSTRAINT [PK_FsDienstleistung]
    PRIMARY KEY CLUSTERED ([FsDienstleistungID] ASC);
GO

-- Creating primary key on [FsDienstleistung_FsDienstleistungspaketID] in table 'FsDienstleistung_FsDienstleistungspaket'
ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket]
ADD CONSTRAINT [PK_FsDienstleistung_FsDienstleistungspaket]
    PRIMARY KEY CLUSTERED ([FsDienstleistung_FsDienstleistungspaketID] ASC);
GO

-- Creating primary key on [FaLeistungID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [PK_FaLeistung]
    PRIMARY KEY CLUSTERED ([FaLeistungID] ASC);
GO

-- Creating primary key on [FaPhaseID] in table 'FaPhase'
ALTER TABLE [dbo].[FaPhase]
ADD CONSTRAINT [PK_FaPhase]
    PRIMARY KEY CLUSTERED ([FaPhaseID] ASC);
GO

-- Creating primary key on [FsDienstleistungspaketID] in table 'FsDienstleistungspaket'
ALTER TABLE [dbo].[FsDienstleistungspaket]
ADD CONSTRAINT [PK_FsDienstleistungspaket]
    PRIMARY KEY CLUSTERED ([FsDienstleistungspaketID] ASC);
GO

-- Creating primary key on [UserID] in table 'XUser'
ALTER TABLE [dbo].[XUser]
ADD CONSTRAINT [PK_XUser]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [VerID] in table 'HistoryVersion'
ALTER TABLE [dbo].[HistoryVersion]
ADD CONSTRAINT [PK_HistoryVersion]
    PRIMARY KEY CLUSTERED ([VerID] ASC);
GO

-- Creating primary key on [BDELeistungsartID] in table 'BDELeistungsart'
ALTER TABLE [dbo].[BDELeistungsart]
ADD CONSTRAINT [PK_BDELeistungsart]
    PRIMARY KEY CLUSTERED ([BDELeistungsartID] ASC);
GO

-- Creating primary key on [BDEPensum_XUserID] in table 'BDEPensum_XUser'
ALTER TABLE [dbo].[BDEPensum_XUser]
ADD CONSTRAINT [PK_BDEPensum_XUser]
    PRIMARY KEY CLUSTERED ([BDEPensum_XUserID] ASC);
GO

-- Creating primary key on [FsReduktionID] in table 'FsReduktion'
ALTER TABLE [dbo].[FsReduktion]
ADD CONSTRAINT [PK_FsReduktion]
    PRIMARY KEY CLUSTERED ([FsReduktionID] ASC);
GO

-- Creating primary key on [FsReduktionMitarbeiterID] in table 'FsReduktionMitarbeiter'
ALTER TABLE [dbo].[FsReduktionMitarbeiter]
ADD CONSTRAINT [PK_FsReduktionMitarbeiter]
    PRIMARY KEY CLUSTERED ([FsReduktionMitarbeiterID] ASC);
GO

-- Creating primary key on [FaFallID] in table 'FaFall'
ALTER TABLE [dbo].[FaFall]
ADD CONSTRAINT [PK_FaFall]
    PRIMARY KEY CLUSTERED ([FaFallID] ASC);
GO

-- Creating primary key on [FaFallID], [BaPersonID] in table 'vwBaKlientensystemPerson'
ALTER TABLE [dbo].[vwBaKlientensystemPerson]
ADD CONSTRAINT [PK_vwBaKlientensystemPerson]
    PRIMARY KEY CLUSTERED ([FaFallID], [BaPersonID] ASC);
GO

-- Creating primary key on [BaBankID] in table 'BaBank'
ALTER TABLE [dbo].[BaBank]
ADD CONSTRAINT [PK_BaBank]
    PRIMARY KEY CLUSTERED ([BaBankID] ASC);
GO

-- Creating primary key on [BaInstitutionID] in table 'BaInstitution'
ALTER TABLE [dbo].[BaInstitution]
ADD CONSTRAINT [PK_BaInstitution]
    PRIMARY KEY CLUSTERED ([BaInstitutionID] ASC);
GO

-- Creating primary key on [BaLandID] in table 'BaLand'
ALTER TABLE [dbo].[BaLand]
ADD CONSTRAINT [PK_BaLand]
    PRIMARY KEY CLUSTERED ([BaLandID] ASC);
GO

-- Creating primary key on [UserGroup_RightID] in table 'XUserGroup_Right'
ALTER TABLE [dbo].[XUserGroup_Right]
ADD CONSTRAINT [PK_XUserGroup_Right]
    PRIMARY KEY CLUSTERED ([UserGroup_RightID] ASC);
GO

-- Creating primary key on [BaZahlungswegID] in table 'BaZahlungsweg'
ALTER TABLE [dbo].[BaZahlungsweg]
ADD CONSTRAINT [PK_BaZahlungsweg]
    PRIMARY KEY CLUSTERED ([BaZahlungswegID] ASC);
GO

-- Creating primary key on [VmPositionsartID] in table 'VmPositionsart'
ALTER TABLE [dbo].[VmPositionsart]
ADD CONSTRAINT [PK_VmPositionsart]
    PRIMARY KEY CLUSTERED ([VmPositionsartID] ASC);
GO

-- Creating primary key on [VmKlientenbudgetID] in table 'VmKlientenbudget'
ALTER TABLE [dbo].[VmKlientenbudget]
ADD CONSTRAINT [PK_VmKlientenbudget]
    PRIMARY KEY CLUSTERED ([VmKlientenbudgetID] ASC);
GO

-- Creating primary key on [VmPositionID] in table 'VmPosition'
ALTER TABLE [dbo].[VmPosition]
ADD CONSTRAINT [PK_VmPosition]
    PRIMARY KEY CLUSTERED ([VmPositionID] ASC);
GO

-- Creating primary key on [FbBuchungID] in table 'FbBuchung'
ALTER TABLE [dbo].[FbBuchung]
ADD CONSTRAINT [PK_FbBuchung]
    PRIMARY KEY CLUSTERED ([FbBuchungID] ASC);
GO

-- Creating primary key on [FbKontoID] in table 'FbKonto'
ALTER TABLE [dbo].[FbKonto]
ADD CONSTRAINT [PK_FbKonto]
    PRIMARY KEY CLUSTERED ([FbKontoID] ASC);
GO

-- Creating primary key on [FbPeriodeID] in table 'FbPeriode'
ALTER TABLE [dbo].[FbPeriode]
ADD CONSTRAINT [PK_FbPeriode]
    PRIMARY KEY CLUSTERED ([FbPeriodeID] ASC);
GO

-- Creating primary key on [FaAktennotizID] in table 'FaAktennotizen'
ALTER TABLE [dbo].[FaAktennotizen]
ADD CONSTRAINT [PK_FaAktennotizen]
    PRIMARY KEY CLUSTERED ([FaAktennotizID] ASC);
GO

-- Creating primary key on [FaDokumenteID] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [PK_FaDokumente]
    PRIMARY KEY CLUSTERED ([FaDokumenteID] ASC);
GO

-- Creating primary key on [FaWeisungID] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [PK_FaWeisung]
    PRIMARY KEY CLUSTERED ([FaWeisungID] ASC);
GO

-- Creating primary key on [XTaskID] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [PK_XTask]
    PRIMARY KEY CLUSTERED ([XTaskID] ASC);
GO

-- Creating primary key on [DocumentID] in table 'XDocument'
ALTER TABLE [dbo].[XDocument]
ADD CONSTRAINT [PK_XDocument]
    PRIMARY KEY CLUSTERED ([DocumentID] ASC);
GO

-- Creating primary key on [FaWeisungProtokollID] in table 'FaWeisungProtokoll'
ALTER TABLE [dbo].[FaWeisungProtokoll]
ADD CONSTRAINT [PK_FaWeisungProtokoll]
    PRIMARY KEY CLUSTERED ([FaWeisungProtokollID] ASC);
GO

-- Creating primary key on [FaPendenzgruppeID] in table 'FaPendenzgruppe'
ALTER TABLE [dbo].[FaPendenzgruppe]
ADD CONSTRAINT [PK_FaPendenzgruppe]
    PRIMARY KEY CLUSTERED ([FaPendenzgruppeID] ASC);
GO

-- Creating primary key on [FaWeisung_BaPersonID] in table 'FaWeisung_BaPerson'
ALTER TABLE [dbo].[FaWeisung_BaPerson]
ADD CONSTRAINT [PK_FaWeisung_BaPerson]
    PRIMARY KEY CLUSTERED ([FaWeisung_BaPersonID] ASC);
GO

-- Creating primary key on [FaKategorisierungID] in table 'FaKategorisierung'
ALTER TABLE [dbo].[FaKategorisierung]
ADD CONSTRAINT [PK_FaKategorisierung]
    PRIMARY KEY CLUSTERED ([FaKategorisierungID] ASC);
GO

-- Creating primary key on [FaKategorisierungEksProduktID] in table 'FaKategorisierungEksProdukt'
ALTER TABLE [dbo].[FaKategorisierungEksProdukt]
ADD CONSTRAINT [PK_FaKategorisierungEksProdukt]
    PRIMARY KEY CLUSTERED ([FaKategorisierungEksProduktID] ASC);
GO

-- Creating primary key on [FaLeistungUserHistID] in table 'FaLeistungUserHist'
ALTER TABLE [dbo].[FaLeistungUserHist]
ADD CONSTRAINT [PK_FaLeistungUserHist]
    PRIMARY KEY CLUSTERED ([FaLeistungUserHistID] ASC);
GO

-- Creating primary key on [FaLeistungArchivID] in table 'FaLeistungArchiv'
ALTER TABLE [dbo].[FaLeistungArchiv]
ADD CONSTRAINT [PK_FaLeistungArchiv]
    PRIMARY KEY CLUSTERED ([FaLeistungArchivID] ASC);
GO

-- Creating primary key on [XConfigID] in table 'XConfig'
ALTER TABLE [dbo].[XConfig]
ADD CONSTRAINT [PK_XConfig]
    PRIMARY KEY CLUSTERED ([XConfigID] ASC);
GO

-- Creating primary key on [BaGemeindeID] in table 'BaGemeinde'
ALTER TABLE [dbo].[BaGemeinde]
ADD CONSTRAINT [PK_BaGemeinde]
    PRIMARY KEY CLUSTERED ([BaGemeindeID] ASC);
GO

-- Creating primary key on [BaPLZID] in table 'BaPLZ'
ALTER TABLE [dbo].[BaPLZ]
ADD CONSTRAINT [PK_BaPLZ]
    PRIMARY KEY CLUSTERED ([BaPLZID] ASC);
GO

-- Creating primary key on [XClassID] in table 'XClass'
ALTER TABLE [dbo].[XClass]
ADD CONSTRAINT [PK_XClass]
    PRIMARY KEY CLUSTERED ([XClassID] ASC);
GO

-- Creating primary key on [RightID] in table 'XRight'
ALTER TABLE [dbo].[XRight]
ADD CONSTRAINT [PK_XRight]
    PRIMARY KEY CLUSTERED ([RightID] ASC);
GO

-- Creating primary key on [UserGroupID] in table 'XUserGroup'
ALTER TABLE [dbo].[XUserGroup]
ADD CONSTRAINT [PK_XUserGroup]
    PRIMARY KEY CLUSTERED ([UserGroupID] ASC);
GO

-- Creating primary key on [OrgUnitID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [PK_XOrgUnit]
    PRIMARY KEY CLUSTERED ([OrgUnitID] ASC);
GO

-- Creating primary key on [XOrgUnit_UserID] in table 'XOrgUnit_User'
ALTER TABLE [dbo].[XOrgUnit_User]
ADD CONSTRAINT [PK_XOrgUnit_User]
    PRIMARY KEY CLUSTERED ([XOrgUnit_UserID] ASC);
GO

-- Creating primary key on [BaGesundheitID] in table 'BaGesundheit'
ALTER TABLE [dbo].[BaGesundheit]
ADD CONSTRAINT [PK_BaGesundheit]
    PRIMARY KEY CLUSTERED ([BaGesundheitID] ASC);
GO

-- Creating primary key on [FaLeistungZugriffID] in table 'FaLeistungZugriff'
ALTER TABLE [dbo].[FaLeistungZugriff]
ADD CONSTRAINT [PK_FaLeistungZugriff]
    PRIMARY KEY CLUSTERED ([FaLeistungZugriffID] ASC);
GO

-- Creating primary key on [BDESollStundenProJahr_XUserID] in table 'BDESollStundenProJahr_XUser'
ALTER TABLE [dbo].[BDESollStundenProJahr_XUser]
ADD CONSTRAINT [PK_BDESollStundenProJahr_XUser]
    PRIMARY KEY CLUSTERED ([BDESollStundenProJahr_XUserID] ASC);
GO

-- Creating primary key on [XUser_UserGroupID] in table 'XUser_UserGroup'
ALTER TABLE [dbo].[XUser_UserGroup]
ADD CONSTRAINT [PK_XUser_UserGroup]
    PRIMARY KEY CLUSTERED ([XUser_UserGroupID] ASC);
GO

-- Creating primary key on [XLOVID] in table 'XLOV'
ALTER TABLE [dbo].[XLOV]
ADD CONSTRAINT [PK_XLOV]
    PRIMARY KEY CLUSTERED ([XLOVID] ASC);
GO

-- Creating primary key on [UserSessionID] in table 'UserSession'
ALTER TABLE [dbo].[UserSession]
ADD CONSTRAINT [PK_UserSession]
    PRIMARY KEY CLUSTERED ([UserSessionID] ASC);
GO

-- Creating primary key on [XLOVCodeID] in table 'XLOVCode'
ALTER TABLE [dbo].[XLOVCode]
ADD CONSTRAINT [PK_XLOVCode]
    PRIMARY KEY CLUSTERED ([XLOVCodeID] ASC);
GO

-- Creating primary key on [FaDokumentAblageID] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [PK_FaDokumentAblage]
    PRIMARY KEY CLUSTERED ([FaDokumentAblageID] ASC);
GO

-- Creating primary key on [FaDokumentAblage_BaPersonID] in table 'FaDokumentAblage_BaPerson'
ALTER TABLE [dbo].[FaDokumentAblage_BaPerson]
ADD CONSTRAINT [PK_FaDokumentAblage_BaPerson]
    PRIMARY KEY CLUSTERED ([FaDokumentAblage_BaPersonID] ASC);
GO

-- Creating primary key on [BaPerson_RelationID] in table 'BaPerson_Relation'
ALTER TABLE [dbo].[BaPerson_Relation]
ADD CONSTRAINT [PK_BaPerson_Relation]
    PRIMARY KEY CLUSTERED ([BaPerson_RelationID] ASC);
GO

-- Creating primary key on [BaPerson_BaInstitutionID] in table 'BaPerson_BaInstitution'
ALTER TABLE [dbo].[BaPerson_BaInstitution]
ADD CONSTRAINT [PK_BaPerson_BaInstitution]
    PRIMARY KEY CLUSTERED ([BaPerson_BaInstitutionID] ASC);
GO

-- Creating primary key on [XTaskAutoGeneratedID] in table 'XTaskAutoGenerated'
ALTER TABLE [dbo].[XTaskAutoGenerated]
ADD CONSTRAINT [PK_XTaskAutoGenerated]
    PRIMARY KEY CLUSTERED ([XTaskAutoGeneratedID] ASC);
GO

-- Creating primary key on [XIconID] in table 'XIcon'
ALTER TABLE [dbo].[XIcon]
ADD CONSTRAINT [PK_XIcon]
    PRIMARY KEY CLUSTERED ([XIconID] ASC);
GO

-- Creating primary key on [ModulID] in table 'XModul'
ALTER TABLE [dbo].[XModul]
ADD CONSTRAINT [PK_XModul]
    PRIMARY KEY CLUSTERED ([ModulID] ASC);
GO

-- Creating primary key on [KesAuftragID] in table 'KesAuftrag'
ALTER TABLE [dbo].[KesAuftrag]
ADD CONSTRAINT [PK_KesAuftrag]
    PRIMARY KEY CLUSTERED ([KesAuftragID] ASC);
GO

-- Creating primary key on [KesPraeventionID] in table 'KesPraevention'
ALTER TABLE [dbo].[KesPraevention]
ADD CONSTRAINT [PK_KesPraevention]
    PRIMARY KEY CLUSTERED ([KesPraeventionID] ASC);
GO

-- Creating primary key on [KesAuftrag_BaPersonID] in table 'KesAuftrag_BaPerson'
ALTER TABLE [dbo].[KesAuftrag_BaPerson]
ADD CONSTRAINT [PK_KesAuftrag_BaPerson]
    PRIMARY KEY CLUSTERED ([KesAuftrag_BaPersonID] ASC);
GO

-- Creating primary key on [KesMassnahme_KesArtikelID] in table 'KesMassnahme_KesArtikel'
ALTER TABLE [dbo].[KesMassnahme_KesArtikel]
ADD CONSTRAINT [PK_KesMassnahme_KesArtikel]
    PRIMARY KEY CLUSTERED ([KesMassnahme_KesArtikelID] ASC);
GO

-- Creating primary key on [KesArtikelID] in table 'KesArtikel'
ALTER TABLE [dbo].[KesArtikel]
ADD CONSTRAINT [PK_KesArtikel]
    PRIMARY KEY CLUSTERED ([KesArtikelID] ASC);
GO

-- Creating primary key on [KesMassnahmeID] in table 'KesMassnahme'
ALTER TABLE [dbo].[KesMassnahme]
ADD CONSTRAINT [PK_KesMassnahme]
    PRIMARY KEY CLUSTERED ([KesMassnahmeID] ASC);
GO

-- Creating primary key on [KesMandatsfuehrendePersonID] in table 'KesMandatsfuehrendePerson'
ALTER TABLE [dbo].[KesMandatsfuehrendePerson]
ADD CONSTRAINT [PK_KesMandatsfuehrendePerson]
    PRIMARY KEY CLUSTERED ([KesMandatsfuehrendePersonID] ASC);
GO

-- Creating primary key on [KesMassnahmeBerichtID] in table 'KesMassnahmeBericht'
ALTER TABLE [dbo].[KesMassnahmeBericht]
ADD CONSTRAINT [PK_KesMassnahmeBericht]
    PRIMARY KEY CLUSTERED ([KesMassnahmeBerichtID] ASC);
GO

-- Creating primary key on [KesMassnahmeAuftragID] in table 'KesMassnahmeAuftrag'
ALTER TABLE [dbo].[KesMassnahmeAuftrag]
ADD CONSTRAINT [PK_KesMassnahmeAuftrag]
    PRIMARY KEY CLUSTERED ([KesMassnahmeAuftragID] ASC);
GO

-- Creating primary key on [KesDokumentID] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [PK_KesDokument]
    PRIMARY KEY CLUSTERED ([KesDokumentID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BaPersonID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [FK_BaAdresse_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaAdresse_BaPerson'
CREATE INDEX [IX_FK_BaAdresse_BaPerson]
ON [dbo].[BaAdresse]
    ([BaPersonID]);
GO

-- Creating foreign key on [FsDienstleistungID] in table 'FsDienstleistung_FsDienstleistungspaket'
ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket]
ADD CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung]
    FOREIGN KEY ([FsDienstleistungID])
    REFERENCES [dbo].[FsDienstleistung]
        ([FsDienstleistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung'
CREATE INDEX [IX_FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung]
ON [dbo].[FsDienstleistung_FsDienstleistungspaket]
    ([FsDienstleistungID]);
GO

-- Creating foreign key on [BaPersonID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaLeistung_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistung_BaPerson'
CREATE INDEX [IX_FK_FaLeistung_BaPerson]
ON [dbo].[FaLeistung]
    ([BaPersonID]);
GO

-- Creating foreign key on [SchuldnerBaPersonID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaLeistung_SchuldnerBaPerson]
    FOREIGN KEY ([SchuldnerBaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistung_SchuldnerBaPerson'
CREATE INDEX [IX_FK_FaLeistung_SchuldnerBaPerson]
ON [dbo].[FaLeistung]
    ([SchuldnerBaPersonID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaPhase'
ALTER TABLE [dbo].[FaPhase]
ADD CONSTRAINT [FK_FaPhase_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaPhase_FaLeistung'
CREATE INDEX [IX_FK_FaPhase_FaLeistung]
ON [dbo].[FaPhase]
    ([FaLeistungID]);
GO

-- Creating foreign key on [FsDienstleistungspaketID_Bedarf] in table 'FaPhase'
ALTER TABLE [dbo].[FaPhase]
ADD CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Bedarf]
    FOREIGN KEY ([FsDienstleistungspaketID_Bedarf])
    REFERENCES [dbo].[FsDienstleistungspaket]
        ([FsDienstleistungspaketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaPhase_FsDienstleistungspaket_Bedarf'
CREATE INDEX [IX_FK_FaPhase_FsDienstleistungspaket_Bedarf]
ON [dbo].[FaPhase]
    ([FsDienstleistungspaketID_Bedarf]);
GO

-- Creating foreign key on [FsDienstleistungspaketID_Zugewiesen] in table 'FaPhase'
ALTER TABLE [dbo].[FaPhase]
ADD CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Zugewiesen]
    FOREIGN KEY ([FsDienstleistungspaketID_Zugewiesen])
    REFERENCES [dbo].[FsDienstleistungspaket]
        ([FsDienstleistungspaketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaPhase_FsDienstleistungspaket_Zugewiesen'
CREATE INDEX [IX_FK_FaPhase_FsDienstleistungspaket_Zugewiesen]
ON [dbo].[FaPhase]
    ([FsDienstleistungspaketID_Zugewiesen]);
GO

-- Creating foreign key on [FsDienstleistungspaketID] in table 'FsDienstleistung_FsDienstleistungspaket'
ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket]
ADD CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket]
    FOREIGN KEY ([FsDienstleistungspaketID])
    REFERENCES [dbo].[FsDienstleistungspaket]
        ([FsDienstleistungspaketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket'
CREATE INDEX [IX_FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket]
ON [dbo].[FsDienstleistung_FsDienstleistungspaket]
    ([FsDienstleistungspaketID]);
GO

-- Creating foreign key on [UserID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaLeistung_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistung_XUser'
CREATE INDEX [IX_FK_FaLeistung_XUser]
ON [dbo].[FaLeistung]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'FaPhase'
ALTER TABLE [dbo].[FaPhase]
ADD CONSTRAINT [FK_FaPhase_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaPhase_XUser'
CREATE INDEX [IX_FK_FaPhase_XUser]
ON [dbo].[FaPhase]
    ([UserID]);
GO

-- Creating foreign key on [ChiefID] in table 'XUser'
ALTER TABLE [dbo].[XUser]
ADD CONSTRAINT [FK_XUser_XUser_ChiefID]
    FOREIGN KEY ([ChiefID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_XUser_ChiefID'
CREATE INDEX [IX_FK_XUser_XUser_ChiefID]
ON [dbo].[XUser]
    ([ChiefID]);
GO

-- Creating foreign key on [PrimaryUserID] in table 'XUser'
ALTER TABLE [dbo].[XUser]
ADD CONSTRAINT [FK_XUser_XUser_PrimaryUserID]
    FOREIGN KEY ([PrimaryUserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_XUser_PrimaryUserID'
CREATE INDEX [IX_FK_XUser_XUser_PrimaryUserID]
ON [dbo].[XUser]
    ([PrimaryUserID]);
GO

-- Creating foreign key on [SachbearbeiterID] in table 'XUser'
ALTER TABLE [dbo].[XUser]
ADD CONSTRAINT [FK_XUser_XUser_SachbearbeiterID]
    FOREIGN KEY ([SachbearbeiterID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_XUser_SachbearbeiterID'
CREATE INDEX [IX_FK_XUser_XUser_SachbearbeiterID]
ON [dbo].[XUser]
    ([SachbearbeiterID]);
GO

-- Creating foreign key on [UserID] in table 'BDEPensum_XUser'
ALTER TABLE [dbo].[BDEPensum_XUser]
ADD CONSTRAINT [FK_BDEPensum_XUser_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BDEPensum_XUser_XUser'
CREATE INDEX [IX_FK_BDEPensum_XUser_XUser]
ON [dbo].[BDEPensum_XUser]
    ([UserID]);
GO

-- Creating foreign key on [BDELeistungsartID] in table 'FsReduktion'
ALTER TABLE [dbo].[FsReduktion]
ADD CONSTRAINT [FK_FsReduktion_BDELeistungsart]
    FOREIGN KEY ([BDELeistungsartID])
    REFERENCES [dbo].[BDELeistungsart]
        ([BDELeistungsartID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FsReduktion_BDELeistungsart'
CREATE INDEX [IX_FK_FsReduktion_BDELeistungsart]
ON [dbo].[FsReduktion]
    ([BDELeistungsartID]);
GO

-- Creating foreign key on [FsReduktionID] in table 'FsReduktionMitarbeiter'
ALTER TABLE [dbo].[FsReduktionMitarbeiter]
ADD CONSTRAINT [FK_FsReduktionMitarbeiter_FsReduktion]
    FOREIGN KEY ([FsReduktionID])
    REFERENCES [dbo].[FsReduktion]
        ([FsReduktionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FsReduktionMitarbeiter_FsReduktion'
CREATE INDEX [IX_FK_FsReduktionMitarbeiter_FsReduktion]
ON [dbo].[FsReduktionMitarbeiter]
    ([FsReduktionID]);
GO

-- Creating foreign key on [UserID] in table 'FsReduktionMitarbeiter'
ALTER TABLE [dbo].[FsReduktionMitarbeiter]
ADD CONSTRAINT [FK_FsReduktionMitarbeiter_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FsReduktionMitarbeiter_XUser'
CREATE INDEX [IX_FK_FsReduktionMitarbeiter_XUser]
ON [dbo].[FsReduktionMitarbeiter]
    ([UserID]);
GO

-- Creating foreign key on [SachbearbeiterID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaLeistung_SachbearbeiterID]
    FOREIGN KEY ([SachbearbeiterID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistung_SachbearbeiterID'
CREATE INDEX [IX_FK_FaLeistung_SachbearbeiterID]
ON [dbo].[FaLeistung]
    ([SachbearbeiterID]);
GO

-- Creating foreign key on [BaInstitutionID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [FK_BaAdresse_BaInstitution]
    FOREIGN KEY ([BaInstitutionID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaAdresse_BaInstitution'
CREATE INDEX [IX_FK_BaAdresse_BaInstitution]
ON [dbo].[BaAdresse]
    ([BaInstitutionID]);
GO

-- Creating foreign key on [PlatzierungInstID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [FK_BaAdresse_BaInstitution_PlatzierungInstID]
    FOREIGN KEY ([PlatzierungInstID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaAdresse_BaInstitution_PlatzierungInstID'
CREATE INDEX [IX_FK_BaAdresse_BaInstitution_PlatzierungInstID]
ON [dbo].[BaAdresse]
    ([PlatzierungInstID]);
GO

-- Creating foreign key on [Kopfquote_BaInstitutionID] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaInstitution]
    FOREIGN KEY ([Kopfquote_BaInstitutionID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaInstitution'
CREATE INDEX [IX_FK_BaPerson_BaInstitution]
ON [dbo].[BaPerson]
    ([Kopfquote_BaInstitutionID]);
GO

-- Creating foreign key on [BaLandID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [FK_BaAdresse_BaLand]
    FOREIGN KEY ([BaLandID])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaAdresse_BaLand'
CREATE INDEX [IX_FK_BaAdresse_BaLand]
ON [dbo].[BaAdresse]
    ([BaLandID]);
GO

-- Creating foreign key on [LandCode] in table 'BaBank'
ALTER TABLE [dbo].[BaBank]
ADD CONSTRAINT [FK_BaBank_BaLand]
    FOREIGN KEY ([LandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaBank_BaLand'
CREATE INDEX [IX_FK_BaBank_BaLand]
ON [dbo].[BaBank]
    ([LandCode]);
GO

-- Creating foreign key on [NationalitaetCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaLand_NationalitaetCode]
    FOREIGN KEY ([NationalitaetCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaLand_NationalitaetCode'
CREATE INDEX [IX_FK_BaPerson_BaLand_NationalitaetCode]
ON [dbo].[BaPerson]
    ([NationalitaetCode]);
GO

-- Creating foreign key on [UntWohnsitzLandCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaLand_UntWohnsitzLandCode]
    FOREIGN KEY ([UntWohnsitzLandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaLand_UntWohnsitzLandCode'
CREATE INDEX [IX_FK_BaPerson_BaLand_UntWohnsitzLandCode]
ON [dbo].[BaPerson]
    ([UntWohnsitzLandCode]);
GO

-- Creating foreign key on [WegzugLandCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaLand_WegzugLandCode]
    FOREIGN KEY ([WegzugLandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaLand_WegzugLandCode'
CREATE INDEX [IX_FK_BaPerson_BaLand_WegzugLandCode]
ON [dbo].[BaPerson]
    ([WegzugLandCode]);
GO

-- Creating foreign key on [ZuzugGdeLandCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaLand_ZuzugGdeLandCode]
    FOREIGN KEY ([ZuzugGdeLandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaLand_ZuzugGdeLandCode'
CREATE INDEX [IX_FK_BaPerson_BaLand_ZuzugGdeLandCode]
ON [dbo].[BaPerson]
    ([ZuzugGdeLandCode]);
GO

-- Creating foreign key on [ZuzugKtLandCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaLand_ZuzugKtLandCode]
    FOREIGN KEY ([ZuzugKtLandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaLand_ZuzugKtLandCode'
CREATE INDEX [IX_FK_BaPerson_BaLand_ZuzugKtLandCode]
ON [dbo].[BaPerson]
    ([ZuzugKtLandCode]);
GO

-- Creating foreign key on [BaPersonID] in table 'FaFall'
ALTER TABLE [dbo].[FaFall]
ADD CONSTRAINT [FK_BaPersonFaFall]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPersonFaFall'
CREATE INDEX [IX_FK_BaPersonFaFall]
ON [dbo].[FaFall]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaFallID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaFallFaLeistung]
    FOREIGN KEY ([FaFallID])
    REFERENCES [dbo].[FaFall]
        ([FaFallID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaFallFaLeistung'
CREATE INDEX [IX_FK_FaFallFaLeistung]
ON [dbo].[FaLeistung]
    ([FaFallID]);
GO

-- Creating foreign key on [BaBankID] in table 'BaZahlungsweg'
ALTER TABLE [dbo].[BaZahlungsweg]
ADD CONSTRAINT [FK_BaZahlungsweg_BaBank]
    FOREIGN KEY ([BaBankID])
    REFERENCES [dbo].[BaBank]
        ([BaBankID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaZahlungsweg_BaBank'
CREATE INDEX [IX_FK_BaZahlungsweg_BaBank]
ON [dbo].[BaZahlungsweg]
    ([BaBankID]);
GO

-- Creating foreign key on [BaInstitutionID] in table 'BaZahlungsweg'
ALTER TABLE [dbo].[BaZahlungsweg]
ADD CONSTRAINT [FK_BaZahlungsweg_BaInstitution]
    FOREIGN KEY ([BaInstitutionID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaZahlungsweg_BaInstitution'
CREATE INDEX [IX_FK_BaZahlungsweg_BaInstitution]
ON [dbo].[BaZahlungsweg]
    ([BaInstitutionID]);
GO

-- Creating foreign key on [AdresseLandCode] in table 'BaZahlungsweg'
ALTER TABLE [dbo].[BaZahlungsweg]
ADD CONSTRAINT [FK_BaZahlungsweg_BaLand]
    FOREIGN KEY ([AdresseLandCode])
    REFERENCES [dbo].[BaLand]
        ([BaLandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaZahlungsweg_BaLand'
CREATE INDEX [IX_FK_BaZahlungsweg_BaLand]
ON [dbo].[BaZahlungsweg]
    ([AdresseLandCode]);
GO

-- Creating foreign key on [BaPersonID] in table 'BaZahlungsweg'
ALTER TABLE [dbo].[BaZahlungsweg]
ADD CONSTRAINT [FK_BaZahlungsweg_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaZahlungsweg_BaPerson'
CREATE INDEX [IX_FK_BaZahlungsweg_BaPerson]
ON [dbo].[BaZahlungsweg]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'VmKlientenbudget'
ALTER TABLE [dbo].[VmKlientenbudget]
ADD CONSTRAINT [FK_VmKlientenbudget_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VmKlientenbudget_FaLeistung'
CREATE INDEX [IX_FK_VmKlientenbudget_FaLeistung]
ON [dbo].[VmKlientenbudget]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'VmKlientenbudget'
ALTER TABLE [dbo].[VmKlientenbudget]
ADD CONSTRAINT [FK_VmKlientenbudget_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VmKlientenbudget_XUser'
CREATE INDEX [IX_FK_VmKlientenbudget_XUser]
ON [dbo].[VmKlientenbudget]
    ([UserID]);
GO

-- Creating foreign key on [VmKlientenbudgetID] in table 'VmPosition'
ALTER TABLE [dbo].[VmPosition]
ADD CONSTRAINT [FK_VmPosition_VmKlientenbudget]
    FOREIGN KEY ([VmKlientenbudgetID])
    REFERENCES [dbo].[VmKlientenbudget]
        ([VmKlientenbudgetID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VmPosition_VmKlientenbudget'
CREATE INDEX [IX_FK_VmPosition_VmKlientenbudget]
ON [dbo].[VmPosition]
    ([VmKlientenbudgetID]);
GO

-- Creating foreign key on [VmPositionsartID] in table 'VmPosition'
ALTER TABLE [dbo].[VmPosition]
ADD CONSTRAINT [FK_VmPosition_VmPositionsart]
    FOREIGN KEY ([VmPositionsartID])
    REFERENCES [dbo].[VmPositionsart]
        ([VmPositionsartID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VmPosition_VmPositionsart'
CREATE INDEX [IX_FK_VmPosition_VmPositionsart]
ON [dbo].[VmPosition]
    ([VmPositionsartID]);
GO

-- Creating foreign key on [BaPersonID] in table 'FbPeriode'
ALTER TABLE [dbo].[FbPeriode]
ADD CONSTRAINT [FK_FbPeriode_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FbPeriode_BaPerson'
CREATE INDEX [IX_FK_FbPeriode_BaPerson]
ON [dbo].[FbPeriode]
    ([BaPersonID]);
GO

-- Creating foreign key on [FbPeriodeID] in table 'FbBuchung'
ALTER TABLE [dbo].[FbBuchung]
ADD CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBPERIOD]
    FOREIGN KEY ([FbPeriodeID])
    REFERENCES [dbo].[FbPeriode]
        ([FbPeriodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FBBUCHUN_REFERENCE_FBPERIOD'
CREATE INDEX [IX_FK_FBBUCHUN_REFERENCE_FBPERIOD]
ON [dbo].[FbBuchung]
    ([FbPeriodeID]);
GO

-- Creating foreign key on [UserID] in table 'FbBuchung'
ALTER TABLE [dbo].[FbBuchung]
ADD CONSTRAINT [FK_FbBuchung_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FbBuchung_XUser'
CREATE INDEX [IX_FK_FbBuchung_XUser]
ON [dbo].[FbBuchung]
    ([UserID]);
GO

-- Creating foreign key on [FbPeriodeID] in table 'FbKonto'
ALTER TABLE [dbo].[FbKonto]
ADD CONSTRAINT [FK_FbKonto_FbPeriode]
    FOREIGN KEY ([FbPeriodeID])
    REFERENCES [dbo].[FbPeriode]
        ([FbPeriodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FbKonto_FbPeriode'
CREATE INDEX [IX_FK_FbKonto_FbPeriode]
ON [dbo].[FbKonto]
    ([FbPeriodeID]);
GO

-- Creating foreign key on [UserID] in table 'BaAdresse'
ALTER TABLE [dbo].[BaAdresse]
ADD CONSTRAINT [FK_BaAdresse_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaAdresse_XUser'
CREATE INDEX [IX_FK_BaAdresse_XUser]
ON [dbo].[BaAdresse]
    ([UserID]);
GO

-- Creating foreign key on [BaInstitutionID_Adressat] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_BaInstitution_Adressat]
    FOREIGN KEY ([BaInstitutionID_Adressat])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_BaInstitution_Adressat'
CREATE INDEX [IX_FK_FaDokumente_BaInstitution_Adressat]
ON [dbo].[FaDokumente]
    ([BaInstitutionID_Adressat]);
GO

-- Creating foreign key on [BaPersonID_Adressat] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_BaPerson_Adressat]
    FOREIGN KEY ([BaPersonID_Adressat])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_BaPerson_Adressat'
CREATE INDEX [IX_FK_FaDokumente_BaPerson_Adressat]
ON [dbo].[FaDokumente]
    ([BaPersonID_Adressat]);
GO

-- Creating foreign key on [BaPersonID_LT] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_BaPerson_LT]
    FOREIGN KEY ([BaPersonID_LT])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_BaPerson_LT'
CREATE INDEX [IX_FK_FaDokumente_BaPerson_LT]
ON [dbo].[FaDokumente]
    ([BaPersonID_LT]);
GO

-- Creating foreign key on [BaPersonID] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTask_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTask_BaPerson'
CREATE INDEX [IX_FK_XTask_BaPerson]
ON [dbo].[XTask]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaAktennotizen'
ALTER TABLE [dbo].[FaAktennotizen]
ADD CONSTRAINT [FK_FaAktennotizen_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaAktennotizen_FaLeistung'
CREATE INDEX [IX_FK_FaAktennotizen_FaLeistung]
ON [dbo].[FaAktennotizen]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'FaAktennotizen'
ALTER TABLE [dbo].[FaAktennotizen]
ADD CONSTRAINT [FK_FaAktennotizen_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaAktennotizen_XUser'
CREATE INDEX [IX_FK_FaAktennotizen_XUser]
ON [dbo].[FaAktennotizen]
    ([UserID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_FaLeistung'
CREATE INDEX [IX_FK_FaDokumente_FaLeistung]
ON [dbo].[FaDokumente]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID_Absender] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_XUser_Absender]
    FOREIGN KEY ([UserID_Absender])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_XUser_Absender'
CREATE INDEX [IX_FK_FaDokumente_XUser_Absender]
ON [dbo].[FaDokumente]
    ([UserID_Absender]);
GO

-- Creating foreign key on [UserID_EkVisumUser] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_XUser_EkVisumUserID]
    FOREIGN KEY ([UserID_EkVisumUser])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_XUser_EkVisumUserID'
CREATE INDEX [IX_FK_FaDokumente_XUser_EkVisumUserID]
ON [dbo].[FaDokumente]
    ([UserID_EkVisumUser]);
GO

-- Creating foreign key on [UserID_VisiertDurch] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_XUser_VisiertDurchID]
    FOREIGN KEY ([UserID_VisiertDurch])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_XUser_VisiertDurchID'
CREATE INDEX [IX_FK_FaDokumente_XUser_VisiertDurchID]
ON [dbo].[FaDokumente]
    ([UserID_VisiertDurch]);
GO

-- Creating foreign key on [UserID_VisumBeantragtBei] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtBeiID]
    FOREIGN KEY ([UserID_VisumBeantragtBei])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_XUser_VisumBeantragtBeiID'
CREATE INDEX [IX_FK_FaDokumente_XUser_VisumBeantragtBeiID]
ON [dbo].[FaDokumente]
    ([UserID_VisumBeantragtBei]);
GO

-- Creating foreign key on [UserID_VisumBeantragtDurch] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumente_XUser_VisumBeantragtDurchID]
    FOREIGN KEY ([UserID_VisumBeantragtDurch])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumente_XUser_VisumBeantragtDurchID'
CREATE INDEX [IX_FK_FaDokumente_XUser_VisumBeantragtDurchID]
ON [dbo].[FaDokumente]
    ([UserID_VisumBeantragtDurch]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_FaWeisung_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_FaLeistung'
CREATE INDEX [IX_FK_FaWeisung_FaLeistung]
ON [dbo].[FaWeisung]
    ([FaLeistungID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTask_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTask_FaLeistung'
CREATE INDEX [IX_FK_XTask_FaLeistung]
ON [dbo].[XTask]
    ([FaLeistungID]);
GO

-- Creating foreign key on [XTaskID_SAR] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_FaWeisung_XTask]
    FOREIGN KEY ([XTaskID_SAR])
    REFERENCES [dbo].[XTask]
        ([XTaskID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_XTask'
CREATE INDEX [IX_FK_FaWeisung_XTask]
ON [dbo].[FaWeisung]
    ([XTaskID_SAR]);
GO

-- Creating foreign key on [UserID_Creator] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_FaWeisung_XUser_Creator]
    FOREIGN KEY ([UserID_Creator])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_XUser_Creator'
CREATE INDEX [IX_FK_FaWeisung_XUser_Creator]
ON [dbo].[FaWeisung]
    ([UserID_Creator]);
GO

-- Creating foreign key on [UserID_VerantwortlichRD] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichRD]
    FOREIGN KEY ([UserID_VerantwortlichRD])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_XUser_VerantwortlichRD'
CREATE INDEX [IX_FK_FaWeisung_XUser_VerantwortlichRD]
ON [dbo].[FaWeisung]
    ([UserID_VerantwortlichRD]);
GO

-- Creating foreign key on [UserID_VerantwortlichSAR] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichSAR]
    FOREIGN KEY ([UserID_VerantwortlichSAR])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_XUser_VerantwortlichSAR'
CREATE INDEX [IX_FK_FaWeisung_XUser_VerantwortlichSAR]
ON [dbo].[FaWeisung]
    ([UserID_VerantwortlichSAR]);
GO

-- Creating foreign key on [UserID_InBearbeitung] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTask_XUser_Bearbeitung]
    FOREIGN KEY ([UserID_InBearbeitung])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTask_XUser_Bearbeitung'
CREATE INDEX [IX_FK_XTask_XUser_Bearbeitung]
ON [dbo].[XTask]
    ([UserID_InBearbeitung]);
GO

-- Creating foreign key on [UserID_Erledigt] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTask_XUser_Erledigt]
    FOREIGN KEY ([UserID_Erledigt])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTask_XUser_Erledigt'
CREATE INDEX [IX_FK_XTask_XUser_Erledigt]
ON [dbo].[XTask]
    ([UserID_Erledigt]);
GO

-- Creating foreign key on [DocumentID] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_XDocumentFaDokumente]
    FOREIGN KEY ([DocumentID])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocumentFaDokumente'
CREATE INDEX [IX_FK_XDocumentFaDokumente]
ON [dbo].[FaDokumente]
    ([DocumentID]);
GO

-- Creating foreign key on [XDocumentID_Weisung] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_XDocument_FaWeisung]
    FOREIGN KEY ([XDocumentID_Weisung])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocument_FaWeisung'
CREATE INDEX [IX_FK_XDocument_FaWeisung]
ON [dbo].[FaWeisung]
    ([XDocumentID_Weisung]);
GO

-- Creating foreign key on [XDocumentID_Mahnung1] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_XDocument_FaWeisung_Mahnung1]
    FOREIGN KEY ([XDocumentID_Mahnung1])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocument_FaWeisung_Mahnung1'
CREATE INDEX [IX_FK_XDocument_FaWeisung_Mahnung1]
ON [dbo].[FaWeisung]
    ([XDocumentID_Mahnung1]);
GO

-- Creating foreign key on [XDocumentID_Mahnung2] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_XDocument_FaWeisung_Mahnung2]
    FOREIGN KEY ([XDocumentID_Mahnung2])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocument_FaWeisung_Mahnung2'
CREATE INDEX [IX_FK_XDocument_FaWeisung_Mahnung2]
ON [dbo].[FaWeisung]
    ([XDocumentID_Mahnung2]);
GO

-- Creating foreign key on [XDocumentID_Mahnung3] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_XDocument_FaWeisung_Mahnung3]
    FOREIGN KEY ([XDocumentID_Mahnung3])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocument_FaWeisung_Mahnung3'
CREATE INDEX [IX_FK_XDocument_FaWeisung_Mahnung3]
ON [dbo].[FaWeisung]
    ([XDocumentID_Mahnung3]);
GO

-- Creating foreign key on [XDocumentID_Verfuegung] in table 'FaWeisung'
ALTER TABLE [dbo].[FaWeisung]
ADD CONSTRAINT [FK_XDocument_FaWeisung_Verfuegung]
    FOREIGN KEY ([XDocumentID_Verfuegung])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocument_FaWeisung_Verfuegung'
CREATE INDEX [IX_FK_XDocument_FaWeisung_Verfuegung]
ON [dbo].[FaWeisung]
    ([XDocumentID_Verfuegung]);
GO

-- Creating foreign key on [FaWeisungID] in table 'FaWeisungProtokoll'
ALTER TABLE [dbo].[FaWeisungProtokoll]
ADD CONSTRAINT [FK_FaWeisungProtokoll_FaWeisung]
    FOREIGN KEY ([FaWeisungID])
    REFERENCES [dbo].[FaWeisung]
        ([FaWeisungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisungProtokoll_FaWeisung'
CREATE INDEX [IX_FK_FaWeisungProtokoll_FaWeisung]
ON [dbo].[FaWeisungProtokoll]
    ([FaWeisungID]);
GO

-- Creating foreign key on [BaPersonID] in table 'FaWeisung_BaPerson'
ALTER TABLE [dbo].[FaWeisung_BaPerson]
ADD CONSTRAINT [FK_FaWeisung_BaPerson_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_BaPerson_BaPerson'
CREATE INDEX [IX_FK_FaWeisung_BaPerson_BaPerson]
ON [dbo].[FaWeisung_BaPerson]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaWeisungID] in table 'FaWeisung_BaPerson'
ALTER TABLE [dbo].[FaWeisung_BaPerson]
ADD CONSTRAINT [FK_FaWeisung_BaPerson_FaWeisung]
    FOREIGN KEY ([FaWeisungID])
    REFERENCES [dbo].[FaWeisung]
        ([FaWeisungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaWeisung_BaPerson_FaWeisung'
CREATE INDEX [IX_FK_FaWeisung_BaPerson_FaWeisung]
ON [dbo].[FaWeisung_BaPerson]
    ([FaWeisungID]);
GO

-- Creating foreign key on [BaPersonID] in table 'FaKategorisierung'
ALTER TABLE [dbo].[FaKategorisierung]
ADD CONSTRAINT [FK_FaKategorisierung_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaKategorisierung_BaPerson'
CREATE INDEX [IX_FK_FaKategorisierung_BaPerson]
ON [dbo].[FaKategorisierung]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaKategorisierungEksProduktID] in table 'FaKategorisierung'
ALTER TABLE [dbo].[FaKategorisierung]
ADD CONSTRAINT [FK_FaKategorisierung_FaKategorisierungEksProdukt]
    FOREIGN KEY ([FaKategorisierungEksProduktID])
    REFERENCES [dbo].[FaKategorisierungEksProdukt]
        ([FaKategorisierungEksProduktID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaKategorisierung_FaKategorisierungEksProdukt'
CREATE INDEX [IX_FK_FaKategorisierung_FaKategorisierungEksProdukt]
ON [dbo].[FaKategorisierung]
    ([FaKategorisierungEksProduktID]);
GO

-- Creating foreign key on [UserID] in table 'FaKategorisierung'
ALTER TABLE [dbo].[FaKategorisierung]
ADD CONSTRAINT [FK_FaKategorisierung_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaKategorisierung_XUser'
CREATE INDEX [IX_FK_FaKategorisierung_XUser]
ON [dbo].[FaKategorisierung]
    ([UserID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaLeistungUserHist'
ALTER TABLE [dbo].[FaLeistungUserHist]
ADD CONSTRAINT [FK_FaLeistungUserHist_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungUserHist_FaLeistung'
CREATE INDEX [IX_FK_FaLeistungUserHist_FaLeistung]
ON [dbo].[FaLeistungUserHist]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'FaLeistungUserHist'
ALTER TABLE [dbo].[FaLeistungUserHist]
ADD CONSTRAINT [FK_FaLeistungUserHist_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungUserHist_XUser'
CREATE INDEX [IX_FK_FaLeistungUserHist_XUser]
ON [dbo].[FaLeistungUserHist]
    ([UserID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaLeistungArchiv'
ALTER TABLE [dbo].[FaLeistungArchiv]
ADD CONSTRAINT [FK_FaLeistungArchiv_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungArchiv_FaLeistung'
CREATE INDEX [IX_FK_FaLeistungArchiv_FaLeistung]
ON [dbo].[FaLeistungArchiv]
    ([FaLeistungID]);
GO

-- Creating foreign key on [CheckInUserID] in table 'FaLeistungArchiv'
ALTER TABLE [dbo].[FaLeistungArchiv]
ADD CONSTRAINT [FK_FaLeistungArchiv_XUser]
    FOREIGN KEY ([CheckInUserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungArchiv_XUser'
CREATE INDEX [IX_FK_FaLeistungArchiv_XUser]
ON [dbo].[FaLeistungArchiv]
    ([CheckInUserID]);
GO

-- Creating foreign key on [CheckOutUserID] in table 'FaLeistungArchiv'
ALTER TABLE [dbo].[FaLeistungArchiv]
ADD CONSTRAINT [FK_FaLeistungArchiv_XUser1]
    FOREIGN KEY ([CheckOutUserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungArchiv_XUser1'
CREATE INDEX [IX_FK_FaLeistungArchiv_XUser1]
ON [dbo].[FaLeistungArchiv]
    ([CheckOutUserID]);
GO

-- Creating foreign key on [DocumentID_Merkblatt] in table 'FaDokumente'
ALTER TABLE [dbo].[FaDokumente]
ADD CONSTRAINT [FK_FaDokumenteXDocument]
    FOREIGN KEY ([DocumentID_Merkblatt])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumenteXDocument'
CREATE INDEX [IX_FK_FaDokumenteXDocument]
ON [dbo].[FaDokumente]
    ([DocumentID_Merkblatt]);
GO

-- Creating foreign key on [HeimatgemeindeBaGemeindeID] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaGemeinde]
    FOREIGN KEY ([HeimatgemeindeBaGemeindeID])
    REFERENCES [dbo].[BaGemeinde]
        ([BaGemeindeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaGemeinde'
CREATE INDEX [IX_FK_BaPerson_BaGemeinde]
ON [dbo].[BaPerson]
    ([HeimatgemeindeBaGemeindeID]);
GO

-- Creating foreign key on [HeimatgemeindeCode] in table 'BaPerson'
ALTER TABLE [dbo].[BaPerson]
ADD CONSTRAINT [FK_BaPerson_BaGemeinde_HeimatgemeindeCode]
    FOREIGN KEY ([HeimatgemeindeCode])
    REFERENCES [dbo].[BaGemeinde]
        ([BaGemeindeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaGemeinde_HeimatgemeindeCode'
CREATE INDEX [IX_FK_BaPerson_BaGemeinde_HeimatgemeindeCode]
ON [dbo].[BaPerson]
    ([HeimatgemeindeCode]);
GO

-- Creating foreign key on [XClassID] in table 'XUserGroup_Right'
ALTER TABLE [dbo].[XUserGroup_Right]
ADD CONSTRAINT [FK_XUserGroup_Right_XClass]
    FOREIGN KEY ([XClassID])
    REFERENCES [dbo].[XClass]
        ([XClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUserGroup_Right_XClass'
CREATE INDEX [IX_FK_XUserGroup_Right_XClass]
ON [dbo].[XUserGroup_Right]
    ([XClassID]);
GO

-- Creating foreign key on [XClassID] in table 'XRight'
ALTER TABLE [dbo].[XRight]
ADD CONSTRAINT [FK_XRight_XClass]
    FOREIGN KEY ([XClassID])
    REFERENCES [dbo].[XClass]
        ([XClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XRight_XClass'
CREATE INDEX [IX_FK_XRight_XClass]
ON [dbo].[XRight]
    ([XClassID]);
GO

-- Creating foreign key on [RightID] in table 'XUserGroup_Right'
ALTER TABLE [dbo].[XUserGroup_Right]
ADD CONSTRAINT [FK_XUserGroup_Right_XRight]
    FOREIGN KEY ([RightID])
    REFERENCES [dbo].[XRight]
        ([RightID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUserGroup_Right_XRight'
CREATE INDEX [IX_FK_XUserGroup_Right_XRight]
ON [dbo].[XUserGroup_Right]
    ([RightID]);
GO

-- Creating foreign key on [UserGroupID] in table 'XUserGroup_Right'
ALTER TABLE [dbo].[XUserGroup_Right]
ADD CONSTRAINT [FK_XUserGroup_Right_XUserGroup]
    FOREIGN KEY ([UserGroupID])
    REFERENCES [dbo].[XUserGroup]
        ([UserGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUserGroup_Right_XUserGroup'
CREATE INDEX [IX_FK_XUserGroup_Right_XUserGroup]
ON [dbo].[XUserGroup_Right]
    ([UserGroupID]);
GO

-- Creating foreign key on [OrgUnitID] in table 'BaInstitution'
ALTER TABLE [dbo].[BaInstitution]
ADD CONSTRAINT [FK_BaInstitution_XOrgUnit]
    FOREIGN KEY ([OrgUnitID])
    REFERENCES [dbo].[XOrgUnit]
        ([OrgUnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaInstitution_XOrgUnit'
CREATE INDEX [IX_FK_BaInstitution_XOrgUnit]
ON [dbo].[BaInstitution]
    ([OrgUnitID]);
GO

-- Creating foreign key on [OrgUnitID] in table 'FaKategorisierungEksProdukt'
ALTER TABLE [dbo].[FaKategorisierungEksProdukt]
ADD CONSTRAINT [FK_FaKategorisierungEksProdukt_XOrgUnit]
    FOREIGN KEY ([OrgUnitID])
    REFERENCES [dbo].[XOrgUnit]
        ([OrgUnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaKategorisierungEksProdukt_XOrgUnit'
CREATE INDEX [IX_FK_FaKategorisierungEksProdukt_XOrgUnit]
ON [dbo].[FaKategorisierungEksProdukt]
    ([OrgUnitID]);
GO

-- Creating foreign key on [OrgUnitID] in table 'XOrgUnit_User'
ALTER TABLE [dbo].[XOrgUnit_User]
ADD CONSTRAINT [FK_XOrgUnit_User_XOrgUnit]
    FOREIGN KEY ([OrgUnitID])
    REFERENCES [dbo].[XOrgUnit]
        ([OrgUnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_User_XOrgUnit'
CREATE INDEX [IX_FK_XOrgUnit_User_XOrgUnit]
ON [dbo].[XOrgUnit_User]
    ([OrgUnitID]);
GO

-- Creating foreign key on [ParentID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [FK_XOrgUnit_XOrgUnit]
    FOREIGN KEY ([ParentID])
    REFERENCES [dbo].[XOrgUnit]
        ([OrgUnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_XOrgUnit'
CREATE INDEX [IX_FK_XOrgUnit_XOrgUnit]
ON [dbo].[XOrgUnit]
    ([ParentID]);
GO

-- Creating foreign key on [ChiefID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [FK_XOrgUnit_XUser_ChiefID]
    FOREIGN KEY ([ChiefID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_XUser_ChiefID'
CREATE INDEX [IX_FK_XOrgUnit_XUser_ChiefID]
ON [dbo].[XOrgUnit]
    ([ChiefID]);
GO

-- Creating foreign key on [RechtsdienstUserID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [FK_XOrgUnit_XUser_RechtsdienstUserID]
    FOREIGN KEY ([RechtsdienstUserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_XUser_RechtsdienstUserID'
CREATE INDEX [IX_FK_XOrgUnit_XUser_RechtsdienstUserID]
ON [dbo].[XOrgUnit]
    ([RechtsdienstUserID]);
GO

-- Creating foreign key on [RepresentativeID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [FK_XOrgUnit_XUser_RepresentativeID]
    FOREIGN KEY ([RepresentativeID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_XUser_RepresentativeID'
CREATE INDEX [IX_FK_XOrgUnit_XUser_RepresentativeID]
ON [dbo].[XOrgUnit]
    ([RepresentativeID]);
GO

-- Creating foreign key on [UserID] in table 'XOrgUnit_User'
ALTER TABLE [dbo].[XOrgUnit_User]
ADD CONSTRAINT [FK_XOrgUnit_User_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_User_XUser'
CREATE INDEX [IX_FK_XOrgUnit_User_XUser]
ON [dbo].[XOrgUnit_User]
    ([UserID]);
GO

-- Creating foreign key on [ZahnarztBaInstitutionID] in table 'BaGesundheit'
ALTER TABLE [dbo].[BaGesundheit]
ADD CONSTRAINT [FK_BaGesundheit_BaInstitution]
    FOREIGN KEY ([ZahnarztBaInstitutionID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaGesundheit_BaInstitution'
CREATE INDEX [IX_FK_BaGesundheit_BaInstitution]
ON [dbo].[BaGesundheit]
    ([ZahnarztBaInstitutionID]);
GO

-- Creating foreign key on [KVGOrganisationID] in table 'BaGesundheit'
ALTER TABLE [dbo].[BaGesundheit]
ADD CONSTRAINT [FK_BaGesundheit_BaInstitution_KVG]
    FOREIGN KEY ([KVGOrganisationID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaGesundheit_BaInstitution_KVG'
CREATE INDEX [IX_FK_BaGesundheit_BaInstitution_KVG]
ON [dbo].[BaGesundheit]
    ([KVGOrganisationID]);
GO

-- Creating foreign key on [VVGOrganisationID] in table 'BaGesundheit'
ALTER TABLE [dbo].[BaGesundheit]
ADD CONSTRAINT [FK_BaGesundheit_BaInstitution_VVG]
    FOREIGN KEY ([VVGOrganisationID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaGesundheit_BaInstitution_VVG'
CREATE INDEX [IX_FK_BaGesundheit_BaInstitution_VVG]
ON [dbo].[BaGesundheit]
    ([VVGOrganisationID]);
GO

-- Creating foreign key on [BaPersonID] in table 'BaGesundheit'
ALTER TABLE [dbo].[BaGesundheit]
ADD CONSTRAINT [FK_BaGesundheit_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaGesundheit_BaPerson'
CREATE INDEX [IX_FK_BaGesundheit_BaPerson]
ON [dbo].[BaGesundheit]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaLeistungZugriff'
ALTER TABLE [dbo].[FaLeistungZugriff]
ADD CONSTRAINT [FK_FaLeistungZugriff_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungZugriff_FaLeistung'
CREATE INDEX [IX_FK_FaLeistungZugriff_FaLeistung]
ON [dbo].[FaLeistungZugriff]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'FaLeistungZugriff'
ALTER TABLE [dbo].[FaLeistungZugriff]
ADD CONSTRAINT [FK_FaLeistungZugriff_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistungZugriff_XUser'
CREATE INDEX [IX_FK_FaLeistungZugriff_XUser]
ON [dbo].[FaLeistungZugriff]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'BDESollStundenProJahr_XUser'
ALTER TABLE [dbo].[BDESollStundenProJahr_XUser]
ADD CONSTRAINT [FK_BDESollStundenProJahr_XUser_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BDESollStundenProJahr_XUser_XUser'
CREATE INDEX [IX_FK_BDESollStundenProJahr_XUser_XUser]
ON [dbo].[BDESollStundenProJahr_XUser]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'XUser_UserGroup'
ALTER TABLE [dbo].[XUser_UserGroup]
ADD CONSTRAINT [FK_XUser_UserGroup_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_UserGroup_XUser'
CREATE INDEX [IX_FK_XUser_UserGroup_XUser]
ON [dbo].[XUser_UserGroup]
    ([UserID]);
GO

-- Creating foreign key on [UserGroupID] in table 'XUser_UserGroup'
ALTER TABLE [dbo].[XUser_UserGroup]
ADD CONSTRAINT [FK_XUser_UserGroup_XUserGroup]
    FOREIGN KEY ([UserGroupID])
    REFERENCES [dbo].[XUserGroup]
        ([UserGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_UserGroup_XUserGroup'
CREATE INDEX [IX_FK_XUser_UserGroup_XUserGroup]
ON [dbo].[XUser_UserGroup]
    ([UserGroupID]);
GO

-- Creating foreign key on [ReceiverID] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTaskXUser]
    FOREIGN KEY ([ReceiverID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTaskXUser'
CREATE INDEX [IX_FK_XTaskXUser]
ON [dbo].[XTask]
    ([ReceiverID]);
GO

-- Creating foreign key on [ReceiverID] in table 'XTask'
ALTER TABLE [dbo].[XTask]
ADD CONSTRAINT [FK_XTaskFaPendenzgruppe]
    FOREIGN KEY ([ReceiverID])
    REFERENCES [dbo].[FaPendenzgruppe]
        ([FaPendenzgruppeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTaskFaPendenzgruppe'
CREATE INDEX [IX_FK_XTaskFaPendenzgruppe]
ON [dbo].[XTask]
    ([ReceiverID]);
GO

-- Creating foreign key on [UserID] in table 'FaFall'
ALTER TABLE [dbo].[FaFall]
ADD CONSTRAINT [FK_XUserFaFall]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUserFaFall'
CREATE INDEX [IX_FK_XUserFaFall]
ON [dbo].[FaFall]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserSession'
ALTER TABLE [dbo].[UserSession]
ADD CONSTRAINT [FK_UserSession_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSession_XUser'
CREATE INDEX [IX_FK_UserSession_XUser]
ON [dbo].[UserSession]
    ([UserID]);
GO

-- Creating foreign key on [XLOVID] in table 'XLOVCode'
ALTER TABLE [dbo].[XLOVCode]
ADD CONSTRAINT [FK_XLOVCode_XLOV]
    FOREIGN KEY ([XLOVID])
    REFERENCES [dbo].[XLOV]
        ([XLOVID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XLOVCode_XLOV'
CREATE INDEX [IX_FK_XLOVCode_XLOV]
ON [dbo].[XLOVCode]
    ([XLOVID]);
GO

-- Creating foreign key on [BaInstitutionID_Adressat] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [FK_FaDokumentAblage_BaInstitution]
    FOREIGN KEY ([BaInstitutionID_Adressat])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_BaInstitution'
CREATE INDEX [IX_FK_FaDokumentAblage_BaInstitution]
ON [dbo].[FaDokumentAblage]
    ([BaInstitutionID_Adressat]);
GO

-- Creating foreign key on [BaPersonID_Adressat] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [FK_FaDokumentAblage_BaPerson]
    FOREIGN KEY ([BaPersonID_Adressat])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_BaPerson'
CREATE INDEX [IX_FK_FaDokumentAblage_BaPerson]
ON [dbo].[FaDokumentAblage]
    ([BaPersonID_Adressat]);
GO

-- Creating foreign key on [FaLeistungID] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [FK_FaDokumentAblage_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_FaLeistung'
CREATE INDEX [IX_FK_FaDokumentAblage_FaLeistung]
ON [dbo].[FaDokumentAblage]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [FK_FaDokumentAblage_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_XUser'
CREATE INDEX [IX_FK_FaDokumentAblage_XUser]
ON [dbo].[FaDokumentAblage]
    ([UserID]);
GO

-- Creating foreign key on [BaPersonID] in table 'FaDokumentAblage_BaPerson'
ALTER TABLE [dbo].[FaDokumentAblage_BaPerson]
ADD CONSTRAINT [FK_FaDokumentAblage_BaPerson_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_BaPerson_BaPerson'
CREATE INDEX [IX_FK_FaDokumentAblage_BaPerson_BaPerson]
ON [dbo].[FaDokumentAblage_BaPerson]
    ([BaPersonID]);
GO

-- Creating foreign key on [FaDokumentAblageID] in table 'FaDokumentAblage_BaPerson'
ALTER TABLE [dbo].[FaDokumentAblage_BaPerson]
ADD CONSTRAINT [FK_FaDokumentAblage_BaPerson_FaDokumentAblage]
    FOREIGN KEY ([FaDokumentAblageID])
    REFERENCES [dbo].[FaDokumentAblage]
        ([FaDokumentAblageID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaDokumentAblage_BaPerson_FaDokumentAblage'
CREATE INDEX [IX_FK_FaDokumentAblage_BaPerson_FaDokumentAblage]
ON [dbo].[FaDokumentAblage_BaPerson]
    ([FaDokumentAblageID]);
GO

-- Creating foreign key on [BaPersonID_1] in table 'BaPerson_Relation'
ALTER TABLE [dbo].[BaPerson_Relation]
ADD CONSTRAINT [FK_BaPerson_Relation_BaPerson1]
    FOREIGN KEY ([BaPersonID_1])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_Relation_BaPerson1'
CREATE INDEX [IX_FK_BaPerson_Relation_BaPerson1]
ON [dbo].[BaPerson_Relation]
    ([BaPersonID_1]);
GO

-- Creating foreign key on [BaPersonID_2] in table 'BaPerson_Relation'
ALTER TABLE [dbo].[BaPerson_Relation]
ADD CONSTRAINT [FK_BaPerson_Relation_BaPerson2]
    FOREIGN KEY ([BaPersonID_2])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_Relation_BaPerson2'
CREATE INDEX [IX_FK_BaPerson_Relation_BaPerson2]
ON [dbo].[BaPerson_Relation]
    ([BaPersonID_2]);
GO

-- Creating foreign key on [DocumentID] in table 'FaDokumentAblage'
ALTER TABLE [dbo].[FaDokumentAblage]
ADD CONSTRAINT [FK_XDocumentFaDokumentAblage]
    FOREIGN KEY ([DocumentID])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XDocumentFaDokumentAblage'
CREATE INDEX [IX_FK_XDocumentFaDokumentAblage]
ON [dbo].[FaDokumentAblage]
    ([DocumentID]);
GO

-- Creating foreign key on [BaInstitutionID] in table 'BaPerson_BaInstitution'
ALTER TABLE [dbo].[BaPerson_BaInstitution]
ADD CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitution]
    FOREIGN KEY ([BaInstitutionID])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaInstitution_BaInstitution'
CREATE INDEX [IX_FK_BaPerson_BaInstitution_BaInstitution]
ON [dbo].[BaPerson_BaInstitution]
    ([BaInstitutionID]);
GO

-- Creating foreign key on [BaPersonID] in table 'BaPerson_BaInstitution'
ALTER TABLE [dbo].[BaPerson_BaInstitution]
ADD CONSTRAINT [FK_BaPerson_BaInstitution_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BaPerson_BaInstitution_BaPerson'
CREATE INDEX [IX_FK_BaPerson_BaInstitution_BaPerson]
ON [dbo].[BaPerson_BaInstitution]
    ([BaPersonID]);
GO

-- Creating foreign key on [XTaskID] in table 'XTaskAutoGenerated'
ALTER TABLE [dbo].[XTaskAutoGenerated]
ADD CONSTRAINT [FK_XTaskAutoGenerated_XTask]
    FOREIGN KEY ([XTaskID])
    REFERENCES [dbo].[XTask]
        ([XTaskID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XTaskAutoGenerated_XTask'
CREATE INDEX [IX_FK_XTaskAutoGenerated_XTask]
ON [dbo].[XTaskAutoGenerated]
    ([XTaskID]);
GO

-- Creating foreign key on [ModulID] in table 'FaLeistung'
ALTER TABLE [dbo].[FaLeistung]
ADD CONSTRAINT [FK_FaLeistung_XModul]
    FOREIGN KEY ([ModulID])
    REFERENCES [dbo].[XModul]
        ([ModulID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaLeistung_XModul'
CREATE INDEX [IX_FK_FaLeistung_XModul]
ON [dbo].[FaLeistung]
    ([ModulID]);
GO

-- Creating foreign key on [ModulID] in table 'XClass'
ALTER TABLE [dbo].[XClass]
ADD CONSTRAINT [FK_XClass_XModul]
    FOREIGN KEY ([ModulID])
    REFERENCES [dbo].[XModul]
        ([ModulID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XClass_XModul'
CREATE INDEX [IX_FK_XClass_XModul]
ON [dbo].[XClass]
    ([ModulID]);
GO

-- Creating foreign key on [ModulID] in table 'XLOV'
ALTER TABLE [dbo].[XLOV]
ADD CONSTRAINT [FK_XLOV_XModul]
    FOREIGN KEY ([ModulID])
    REFERENCES [dbo].[XModul]
        ([ModulID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XLOV_XModul'
CREATE INDEX [IX_FK_XLOV_XModul]
ON [dbo].[XLOV]
    ([ModulID]);
GO

-- Creating foreign key on [ModulID] in table 'XOrgUnit'
ALTER TABLE [dbo].[XOrgUnit]
ADD CONSTRAINT [FK_XOrgUnit_XModul]
    FOREIGN KEY ([ModulID])
    REFERENCES [dbo].[XModul]
        ([ModulID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XOrgUnit_XModul'
CREATE INDEX [IX_FK_XOrgUnit_XModul]
ON [dbo].[XOrgUnit]
    ([ModulID]);
GO

-- Creating foreign key on [ModulID] in table 'XUser'
ALTER TABLE [dbo].[XUser]
ADD CONSTRAINT [FK_XUser_XModul]
    FOREIGN KEY ([ModulID])
    REFERENCES [dbo].[XModul]
        ([ModulID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_XUser_XModul'
CREATE INDEX [IX_FK_XUser_XModul]
ON [dbo].[XUser]
    ([ModulID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'KesAuftrag'
ALTER TABLE [dbo].[KesAuftrag]
ADD CONSTRAINT [FK_KesAuftrag_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesAuftrag_FaLeistung'
CREATE INDEX [IX_FK_KesAuftrag_FaLeistung]
ON [dbo].[KesAuftrag]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'KesAuftrag'
ALTER TABLE [dbo].[KesAuftrag]
ADD CONSTRAINT [FK_KesAuftrag_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesAuftrag_XUser'
CREATE INDEX [IX_FK_KesAuftrag_XUser]
ON [dbo].[KesAuftrag]
    ([UserID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'KesPraevention'
ALTER TABLE [dbo].[KesPraevention]
ADD CONSTRAINT [FK_KesPraevention_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesPraevention_FaLeistung'
CREATE INDEX [IX_FK_KesPraevention_FaLeistung]
ON [dbo].[KesPraevention]
    ([FaLeistungID]);
GO

-- Creating foreign key on [UserID] in table 'KesPraevention'
ALTER TABLE [dbo].[KesPraevention]
ADD CONSTRAINT [FK_KesPraevention_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesPraevention_XUser'
CREATE INDEX [IX_FK_KesPraevention_XUser]
ON [dbo].[KesPraevention]
    ([UserID]);
GO

-- Creating foreign key on [BaPersonID] in table 'KesAuftrag_BaPerson'
ALTER TABLE [dbo].[KesAuftrag_BaPerson]
ADD CONSTRAINT [FK_KesAuftrag_BaPerson_BaPerson]
    FOREIGN KEY ([BaPersonID])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesAuftrag_BaPerson_BaPerson'
CREATE INDEX [IX_FK_KesAuftrag_BaPerson_BaPerson]
ON [dbo].[KesAuftrag_BaPerson]
    ([BaPersonID]);
GO

-- Creating foreign key on [KesAuftragID] in table 'KesAuftrag_BaPerson'
ALTER TABLE [dbo].[KesAuftrag_BaPerson]
ADD CONSTRAINT [FK_KesAuftrag_BaPerson_KesAuftrag]
    FOREIGN KEY ([KesAuftragID])
    REFERENCES [dbo].[KesAuftrag]
        ([KesAuftragID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesAuftrag_BaPerson_KesAuftrag'
CREATE INDEX [IX_FK_KesAuftrag_BaPerson_KesAuftrag]
ON [dbo].[KesAuftrag_BaPerson]
    ([KesAuftragID]);
GO

-- Creating foreign key on [KesArtikelID] in table 'KesMassnahme_KesArtikel'
ALTER TABLE [dbo].[KesMassnahme_KesArtikel]
ADD CONSTRAINT [FK_KesMassnahme_KesArtikel_KesArtikel]
    FOREIGN KEY ([KesArtikelID])
    REFERENCES [dbo].[KesArtikel]
        ([KesArtikelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMassnahme_KesArtikel_KesArtikel'
CREATE INDEX [IX_FK_KesMassnahme_KesArtikel_KesArtikel]
ON [dbo].[KesMassnahme_KesArtikel]
    ([KesArtikelID]);
GO

-- Creating foreign key on [FaLeistungID] in table 'KesMassnahme'
ALTER TABLE [dbo].[KesMassnahme]
ADD CONSTRAINT [FK_KesMassnahme_FaLeistung]
    FOREIGN KEY ([FaLeistungID])
    REFERENCES [dbo].[FaLeistung]
        ([FaLeistungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMassnahme_FaLeistung'
CREATE INDEX [IX_FK_KesMassnahme_FaLeistung]
ON [dbo].[KesMassnahme]
    ([FaLeistungID]);
GO

-- Creating foreign key on [KesMassnahmeID] in table 'KesMassnahme_KesArtikel'
ALTER TABLE [dbo].[KesMassnahme_KesArtikel]
ADD CONSTRAINT [FK_KesMassnahme_KesArtikel_KesMassnahme]
    FOREIGN KEY ([KesMassnahmeID])
    REFERENCES [dbo].[KesMassnahme]
        ([KesMassnahmeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMassnahme_KesArtikel_KesMassnahme'
CREATE INDEX [IX_FK_KesMassnahme_KesArtikel_KesMassnahme]
ON [dbo].[KesMassnahme_KesArtikel]
    ([KesMassnahmeID]);
GO

-- Creating foreign key on [KesMassnahmeID] in table 'KesMandatsfuehrendePerson'
ALTER TABLE [dbo].[KesMandatsfuehrendePerson]
ADD CONSTRAINT [FK_KesMandatsfuehrendePerson_KesMassnahme]
    FOREIGN KEY ([KesMassnahmeID])
    REFERENCES [dbo].[KesMassnahme]
        ([KesMassnahmeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMandatsfuehrendePerson_KesMassnahme'
CREATE INDEX [IX_FK_KesMandatsfuehrendePerson_KesMassnahme]
ON [dbo].[KesMandatsfuehrendePerson]
    ([KesMassnahmeID]);
GO

-- Creating foreign key on [UserID] in table 'KesMandatsfuehrendePerson'
ALTER TABLE [dbo].[KesMandatsfuehrendePerson]
ADD CONSTRAINT [FK_KesMandatsfuehrendePerson_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMandatsfuehrendePerson_XUser'
CREATE INDEX [IX_FK_KesMandatsfuehrendePerson_XUser]
ON [dbo].[KesMandatsfuehrendePerson]
    ([UserID]);
GO

-- Creating foreign key on [KesMassnahmeID] in table 'KesMassnahmeBericht'
ALTER TABLE [dbo].[KesMassnahmeBericht]
ADD CONSTRAINT [FK_KesMassnahmeBericht_KesMassnahme]
    FOREIGN KEY ([KesMassnahmeID])
    REFERENCES [dbo].[KesMassnahme]
        ([KesMassnahmeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMassnahmeBericht_KesMassnahme'
CREATE INDEX [IX_FK_KesMassnahmeBericht_KesMassnahme]
ON [dbo].[KesMassnahmeBericht]
    ([KesMassnahmeID]);
GO

-- Creating foreign key on [KesMassnahmeID] in table 'KesMassnahmeAuftrag'
ALTER TABLE [dbo].[KesMassnahmeAuftrag]
ADD CONSTRAINT [FK_KesMassnahmeAuftrag_KesMassnahme]
    FOREIGN KEY ([KesMassnahmeID])
    REFERENCES [dbo].[KesMassnahme]
        ([KesMassnahmeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesMassnahmeAuftrag_KesMassnahme'
CREATE INDEX [IX_FK_KesMassnahmeAuftrag_KesMassnahme]
ON [dbo].[KesMassnahmeAuftrag]
    ([KesMassnahmeID]);
GO

-- Creating foreign key on [BaInstitutionID_Adressat] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_BaInstitution_Adressat]
    FOREIGN KEY ([BaInstitutionID_Adressat])
    REFERENCES [dbo].[BaInstitution]
        ([BaInstitutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_BaInstitution_Adressat'
CREATE INDEX [IX_FK_KesDokument_BaInstitution_Adressat]
ON [dbo].[KesDokument]
    ([BaInstitutionID_Adressat]);
GO

-- Creating foreign key on [BaPersonID_Adressat] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_BaPerson_Adressat]
    FOREIGN KEY ([BaPersonID_Adressat])
    REFERENCES [dbo].[BaPerson]
        ([BaPersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_BaPerson_Adressat'
CREATE INDEX [IX_FK_KesDokument_BaPerson_Adressat]
ON [dbo].[KesDokument]
    ([BaPersonID_Adressat]);
GO

-- Creating foreign key on [KesAuftragID] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_KesAuftrag]
    FOREIGN KEY ([KesAuftragID])
    REFERENCES [dbo].[KesAuftrag]
        ([KesAuftragID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_KesAuftrag'
CREATE INDEX [IX_FK_KesDokument_KesAuftrag]
ON [dbo].[KesDokument]
    ([KesAuftragID]);
GO

-- Creating foreign key on [UserID] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_XUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[XUser]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_XUser'
CREATE INDEX [IX_FK_KesDokument_XUser]
ON [dbo].[KesDokument]
    ([UserID]);
GO

-- Creating foreign key on [XDocumentDocumentID] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_XDocument_Versand]
    FOREIGN KEY ([XDocumentDocumentID])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_XDocument_Versand'
CREATE INDEX [IX_FK_KesDokument_XDocument_Versand]
ON [dbo].[KesDokument]
    ([XDocumentDocumentID]);
GO

-- Creating foreign key on [XDocumentDocumentID1] in table 'KesDokument'
ALTER TABLE [dbo].[KesDokument]
ADD CONSTRAINT [FK_KesDokument_XDocument_Dokument]
    FOREIGN KEY ([XDocumentDocumentID1])
    REFERENCES [dbo].[XDocument]
        ([DocumentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KesDokument_XDocument_Dokument'
CREATE INDEX [IX_FK_KesDokument_XDocument_Dokument]
ON [dbo].[KesDokument]
    ([XDocumentDocumentID1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------