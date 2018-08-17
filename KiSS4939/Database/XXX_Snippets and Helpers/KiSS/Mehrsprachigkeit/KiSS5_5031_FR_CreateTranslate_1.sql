USE [KiSS_Standard_R5031_FR]
GO

-- Translate Kategorisierung
DECLARE @tid AS INTEGER=9360; 
EXEC spXSetXLangText @tid,2, 'Catégorisation',NULL,NULL,NULL,NULL,@tid OUT
GO
-- Inkasso MenuTree
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkRechtlicheMassnahmenSchuldner'        
EXEC spXSetXLangText @tid,1, 'Rechtliche Massnahmen',NULL,NULL,NULL,NULL,@tid
EXEC spXSetXLangText @tid,2, 'Mesures juridiques',NULL,NULL,NULL,NULL,@tid
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Abklärung'       
EXEC spXSetXLangText @tid,1, 'Abklärung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Clarification',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Abklärung'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Abklärung')
EXEC spXSetXLangText @tid,1, 'Abklärungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Clarifications',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Abklärung')
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Alimente'       
EXEC spXSetXLangText @tid,1, 'Alimente',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Pension alimentaire',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Alimente'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Alimente') AND ClassName = 'CtlIkRechtlicheMassnahmenInkassofall'
EXEC spXSetXLangText @tid,1, 'Rechtliche Massnahmen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mesures juridiques',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Rechtliche Massnahmen'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Alimente') AND ClassName = 'CtlIkRechtstitel'
EXEC spXSetXLangText @tid,1, 'Rechtstitel und Gläubiger',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Titre et Créancier',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Rechtstitel und Gläubiger'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Alimente') AND ClassName = 'CtlIkKontoauszug' AND Name = 'Gläubiger'
EXEC spXSetXLangText @tid,1, 'Gläubiger',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Créancier',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Gläubiger'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Alimente') AND ClassName = 'CtlIkKontoauszug' AND Name = 'Schuldner'
EXEC spXSetXLangText @tid,1, 'Schuldner',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Débiteur',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Schuldner'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Alimente') AND ClassName = 'CtlIkBetreibungenVerlustscheine'
EXEC spXSetXLangText @tid,1, 'Betreibungen, Verlustscheine',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Poursuites, Acte de défaut de biens',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Betreibungen, Verlustscheine'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Elternbeitrag'       
EXEC spXSetXLangText @tid,1, 'Elternbeitrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Contribution parentale',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Elternbeitrag'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Elternbeitrag') AND ClassName = 'CtlIkMonatszahlenVerrechnung'
EXEC spXSetXLangText @tid,1, 'Ratenplan',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Planning de versement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Ratenplan'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree WHERE ModulTreeID_Parent = (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung' AND Name = 'Elternbeitrag') AND ClassName = 'CtlIkForderungen'
EXEC spXSetXLangText @tid,1, 'Inkasso Forderungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Recouvrement créances',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ModulTreeID_Parent IN (SELECT ModulTreeID FROM dbo.XModulTree WHERE ClassName = 'CtlIkLeistung') AND Name = 'Inkasso Forderungen'
GO

DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Verwandtenbeitrag'       
EXEC spXSetXLangText @tid,1, 'Verwandtenbeitrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Contribution de parents',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Verwandtenbeitrag'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Tagesheim/Krippe'       
EXEC spXSetXLangText @tid,1, 'Foyer de jour/Krippe',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Crêche',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Tagesheim/Krippe'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Nachlass'       
EXEC spXSetXLangText @tid,1, 'Nachlass',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Remise',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Nachlass'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkLeistung' AND  Name = 'Rückerstattung POM'       
EXEC spXSetXLangText @tid,1, 'Rückerstattung POM',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Remboursement exigé',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkLeistung'  AND  Name = 'Rückerstattung POM'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE ClassName = 'CtlIkKontoauszug' AND  Name = 'Kontoauszug'       
EXEC spXSetXLangText @tid,1, 'Kontoauszug',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Extrait de compte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE ClassName = 'CtlIkKontoauszug'  AND  Name = 'Kontoauszug'
GO

-- Inkasso

-- CtlIkRechtlicheMassnahmenInkassofall
DECLARE @className AS varchar(255) = 'CtlIkRechtlicheMassnahmenInkassofall'
DECLARE @controlName AS varchar(255) = 'colDatumBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9626 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colDatumVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9627 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colIkAnzeigeTyp'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9688 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'lblTitel'
UPDATE dbo.XClassControl SET ControlTID = 547 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblEroeffnungsGrund'
UPDATE dbo.XClassControl SET ControlTID = 9529 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'edtAbschlussGrund'
UPDATE dbo.XClassControl SET ControlTID = 9529 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblAbgeschlossenAm'
UPDATE dbo.XClassControl SET ControlTID = 9560 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblEroeffnetAm'
UPDATE dbo.XClassControl SET ControlTID = 9555 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBemerkungen'
UPDATE dbo.XClassControl SET ControlTID = 9879 WHERE ClassName = @className AND ControlName = @controlName

SET @controlName = 'lblAnzeigetyp'
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Anzeigetyp',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Type de plainte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlIkRechtlicheMassnahmenSchuldner
DECLARE @className AS varchar(255) = 'CtlIkRechtlicheMassnahmenSchuldner'
DECLARE @controlName AS varchar(255) = 'colIkAnzeigeTyp'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9688 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'lblTitel'
UPDATE dbo.XClassControl SET ControlTID = 547 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblEroeffnungsGrund'
UPDATE dbo.XClassControl SET ControlTID = 9529 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblAbschlussGrund'
UPDATE dbo.XClassControl SET ControlTID = 9529 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblAbgeschlossenAm'
UPDATE dbo.XClassControl SET ControlTID = 9560 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblEroeffnetAm'
UPDATE dbo.XClassControl SET ControlTID = 9555 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBemerkungen'
UPDATE dbo.XClassControl SET ControlTID = 9879 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblAnzeigetyp'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Anzeigetyp') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblInkassofall'
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Inkassofall',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Cas encaissement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblAlleBetreibungen'     
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Alle Betreibungen von diesem Schuldner',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Toutes les poursuites de ce débiteur',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

SET @controlName = 'colBetreibungAm'     
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetreibungBetrag'     
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9434 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetreibungVon'     
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 3146 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetreibungBis'     
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 3148 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetreibungNummer'   
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Betreibungsnummer',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Numéro de procédure',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetreibungInkassoFallName'
UPDATE dbo.XClassComponent SET ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Inkassofall') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colDatumBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9626 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colDatumVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9627 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colIkAnzeigeTyp'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9688 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colInkassoFallName'
UPDATE dbo.XClassComponent SET ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Inkassofall') WHERE ClassName = @className AND ComponentName = @controlName
GO

-- TODO translate --
-- CtlIkAbklaerungen

/* -- XClassComponent
coAbklaerungsDatum
colAabklaerungsart
colAbklaerungDurch
colAuswertung
*/

/* -- XClassControl
kissLabel1
lbDatum1
lblAbklaerungDurch
lblAbklaerungsart
lblAuswertung
lblBemerkung
lblTitel
*/

-- TODO translate --
-- CtlIkBetreibungenVerlustscheine
-- CtlIkForderungen
-- CtlIkGlaeubiger
-- CtlIkKontoauszug
-- CtlIkMonatszahlenVerrechnung
-- CtlIkRechtstitel

-- TODO translate --
-- MandatsBuchaltung

-- CtlFibu

DECLARE @className AS varchar(255) = 'CtlFibu'
DECLARE @controlName AS varchar(255) = 'lblTitle'
UPDATE dbo.XClassControl SET ControlTID = 4864 WHERE ClassName = @className AND ControlName = @controlName

-- CtlFibuBuchung

UPDATE dbo.XLangText SET dbo.XLangText.Text = 'Montant' WHERE dbo.XLangText.TID = 2358 AND LanguageCode = 2

SET @className = 'CtlFibuBuchung'
SET @controlName = 'colBeleg'
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Beleg',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Justificatif',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid  WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBelegNr2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid  WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn9'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn1'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn9'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9434 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridcolumn14'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 9434 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetragHaben2'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Betrag Haben',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Montant Crédit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridcolumn6'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBetragSoll2'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Betrag Soll',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Montant Débit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn5'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 3148 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colDatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colDatum2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn10'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colSoll'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Soll',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Débit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn11'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colHaben'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Haben',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Crédit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn12'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 3146 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1737 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colStatusText'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'E-Status',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'E-Statut',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn15'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colSaldo2'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Saldo',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Solde',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn7'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn13'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn3'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colText2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colItemMandant'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Mandant',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mandant',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn8'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colGegenKtoNr2'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'GKto',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'CCpt',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'gridColumn4'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colText2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
GO

-- CtlFibuBuchung -- tpgBuchung

DECLARE @className AS varchar(255) = 'CtlFibuBuchung'
DECLARE @controlName AS varchar(255) = 'tpgBuchung'
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Buchung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Ecriture',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgKreditor'
UPDATE dbo.XClassControl SET ControlTID = 10465 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgBuchungen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Buchungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Ecritures',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgKontoHaben'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto Haben',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Compte Crédit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgKontoSoll'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto Soll',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Compte Débit',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgSuchen'
UPDATE dbo.XClassControl SET ControlTID = 3782 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgLetzteBelegNr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'eigene Buchungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'propres écritures',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblText'
UPDATE dbo.XClassControl SET ControlTID = 956 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSoll'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblHaben'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben')  WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant')  WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblDatum'
UPDATE dbo.XClassControl SET ControlTID = 1095 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBetrag'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Betrag CHF',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Montant CHF',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblCode'
UPDATE dbo.XClassControl SET ControlTID = 272  WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label10'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'M. Träger',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mandataire',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label2'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'erfasst von',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'créé par',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblGrpSaldoH'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Grp-Saldo H',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Grp-Solde C',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblGrpSaldoS'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Grp-Saldo S',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Grp-Solde D',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBelegNr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND  ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Beleg-Nr.',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Justificatif',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuBuchung -- tpgSuchen

DECLARE @className AS varchar(255) = 'CtlFibuBuchung'
DECLARE @parentControlName AS varchar(255) = 'tpgSuchen'
DECLARE @controlName AS varchar(255) = 'kissSearchTitel1'
DECLARE @tid AS INTEGER;         
UPDATE dbo.XClassControl SET ControlTID = 3836 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label32'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'M. Träger') WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label37'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label30'
UPDATE dbo.XClassControl SET ControlTID = 79 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label26'
UPDATE dbo.XClassControl SET ControlTID = 1095 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label29'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Beleg-Nr.') WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label25'
UPDATE dbo.XClassControl SET ControlTID = 956 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label23'
UPDATE dbo.XClassControl SET ControlTID = 272 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'label28'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label27'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben')  WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label24'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Betrag CHF')  WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label22'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'erfasst von') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label25'
UPDATE dbo.XClassControl SET ControlTID = 956 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTeam'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Team',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Equipe',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'kissLabel1'
UPDATE dbo.XClassControl SET ControlTID = 1737 WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
SET @controlName = 'kissLabel2'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Buchungtyp',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Type d''écriture',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ParentControl = @parentControlName AND ControlName = @controlName
GO

-- ctlFibuZahlungsWeg

DECLARE @className AS varchar(255) = 'ctlFibuZahlungsWeg'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;         
SET @controlName = 'lblZahlungsart'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Zahlungsart',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mode de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblValuta'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Valuta',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Devise',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblZahlungsgrund'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Zahlungsgrund',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Motif du paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblEinzahlungFuer'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Einzahlung für',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Paiement pour',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblName'
UPDATE dbo.XClassControl SET ControlTID = 70 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblStrasse'
UPDATE dbo.XClassControl SET ControlTID = 77 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPlzOrt'
UPDATE dbo.XClassControl SET ControlTID = 4678 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblKontoNr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto Nr',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'No Compte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBankKontoNrXtra'
UPDATE dbo.XClassControl SET ControlTID = 3734 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblReferenzNr'
UPDATE dbo.XClassControl SET ControlTID = 9458 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblInfos'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Infos',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Infos',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblFrist'
UPDATE dbo.XClassControl SET ControlTID = 1439 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblFristTage'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Tages',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Jours',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuKonto

DECLARE @className AS varchar(255) = 'CtlFibuKonto'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;
SET @controlName = 'colBis'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Periode Bis',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Période Au',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colVon'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Periode Von',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Période Du',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colTeam'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1737 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colName'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 70 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colSaldoTotal'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Saldototal',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Solde total',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colSaldoGruppeName'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Saldogruppe',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Solde groupe',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colKtoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1028 WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colKontoTyp'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Kontotyp',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Type compte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colDepotNr'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Depotnummer',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Numéro dépot',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colEroeffnungssaldo'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND  ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Vorsaldo',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Solde initial',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = @tid WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
SET @controlName = 'colFbDTAZugangID'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'e-Zugang') WHERE ClassName = @className AND dbo.XClassComponent.ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuKonto'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;         
SET @controlName = 'label10'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'M. Träger') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label40'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label1'
UPDATE dbo.XClassControl SET ControlTID = 79 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblStandardKontenplan'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Standard-Kontenplan',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Plan comptable normalisé',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabAktiven'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Aktiven',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Actifs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabPassiven'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Passiven',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Passifs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabSpezial'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Spezial',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Spécials',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabErtrag'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Ertrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Produits',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabAufwand'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Aufwand',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Dépenses',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

-- kissLabel7 -- Datum der Vorsaldo-
-- kissLabel10 -- Benutzer der Vorsaldo-
-- kissLabel12 -- Betrag der Vorsaldo-

-- kissLabel14 -- Datum der letzten
-- kissLabel16 -- Benutzer der letzten
-- kissLabel18 -- Betrag der letzten

-- kissLabel8,kissLabel9,kissLabel11 -- Ersterfassung
-- kissLabel13,kissLabel15,kissLabel17 -- Vorsaldo-Mutation

/*
kissLabel1
kissLabel2
kissLabel3
kissLabel4
kissLabel5
kissLabel6
*/
GO

-- CtlFibuPeriode

DECLARE @className AS varchar(255) = 'CtlFibuPeriode'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;
SET @controlName = 'lblTitelAuswahlMandant'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Auswahl Mandant',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Sélection client',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTitelPerioden'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Perioden') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSucheMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSucheMaTraeger'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Mandatsträger') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchePeriodeVon'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode von') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchePeriodeBis'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode bis') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPeriodeVon'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode von') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPeriodeBis'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode bis') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSucheTeam'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTeam'
UPDATE dbo.XClassControl SET ControlTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSucheJournAblOrt'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Journalablageort',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Emp. Journal',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblJournAblOrt'
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgSuchen'
UPDATE dbo.XClassControl SET ControlTID = 2630 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgListe'
UPDATE dbo.XClassControl SET ControlTID = 1752 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnUebertragen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'übertragen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'charger',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnAbschluss'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Abschluss') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnAktiv'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Aktiv / Inaktiv',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Actif / Inactif',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnSaldiVortragen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Saldi vortragen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Reporter solde',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'chkSuchePersStamm'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Suche nur im Personenstamm',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Recherche limitée aux personnes',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'chkSuchePersonMitBuchhaltung'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Suche nur Personen mit Buchhaltung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Recherche limitée aux personnes comptable',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPersonNr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'alle Perioden an Pers. Nr.',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Périodes pour Pers. No.',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuPeriode'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;
SET @controlName = 'colBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode Bis') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode Von') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandantNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1028 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1737 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colTeam'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colOrt'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 79 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStrasse'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 77 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMT'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Mandatsträger') WHERE ClassName = @className AND ComponentName = @controlName
GO

-- CtlFibuKontoblatt

DECLARE @className AS varchar(255) = 'CtlFibuKontoblatt'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;
SET @controlName = 'colBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode Bis') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT TID FROM dbo.XLangText xt WHERE xt.Text = 'Periode Von') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1737 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colID'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'PeriodeID',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'ID Periode',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colDatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 1095 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBelegNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beleg') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBetragHaben'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBetragSoll'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colSaldo'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Saldo') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colGKtoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'GKto') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKtoName'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Compte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuKontoblatt'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'tabListe'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Liste') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabSuchen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissSearchTitel1'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblOrtX'
UPDATE dbo.XClassControl SET ControlTID = 79 WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMandantX'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMTraegerX'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'M. Träger') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblDatumVonX'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Datum') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblDatumBereichPeriodenX'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, '(Datumbereich darf periodenübergreifend sein)',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, '(La période doit etre dans la plage de dates)',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblKontoNrBisX'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto-Nr. bis',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'No compte au',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblKontoVonX'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName     
EXEC spXSetXLangText @tid,1, 'Konto-Nr. von',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'No compte du',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuJournal

DECLARE @className AS varchar(255) = 'CtlFibuJournal'
DECLARE @controlName AS varchar(255) = ''

SET @controlName = 'colBelegNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beleg') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colDatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Datum') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKtoSoll'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colHaben'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = 956 WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colID'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'PeriodeID') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBis'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periode Bis') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colVon'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periode Von') WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuJournal'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabSuchen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabListe'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Liste') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'ttlSearchTitle'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchOrt'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Ort') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchMandatstraeger'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'M. Träger') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchDatumVon'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Datum') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchTeam'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSearchTeamMandantEmpty'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, '(falls Mandant leer bleibt)',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, '(si le Mandant reste vide)',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuBilanzErfolg

DECLARE @className AS varchar(255) = 'CtlFibuBilanzErfolg'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'gridColumn1'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periode Von') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'gridColumn2'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periode Bis') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'gridColumn3'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'gridColumn4'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'PeriodeID') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colEroeffnungsSaldo'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Eröffnung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Ouverture',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoName'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Kontoname',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Nom du compte',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKtoNr'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Kto-Nr.',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Cpte-No.',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKlasse'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Klasse') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colSaldo'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Saldo') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colUmsatz'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Umsatz',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Chiffre d''affaires',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colTotalZeile'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'TotalZeile',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Total ligne',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuBilanzErfolg'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgSuchen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgListe'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Liste') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'editNurMitBuchungen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'nur Konti mit Buchungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'que les comptes avec des écritures',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel1'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'per Datum',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'par date',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label37'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label30'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Ort') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label32'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'M. Träger') WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuDTAZahlungslauf

DECLARE @className AS varchar(255) = 'CtlFibuDTAZahlungsLauf'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;
SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBelegNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beleg-Nr.') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKonto'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto Nr') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoName'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kontoname') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBeguenstigter'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Beguenstigter',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Bénéficiaire',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colDTAZugang'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'EBanking Konto',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Compte EBanking',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colValuta'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Valuta Datum',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Date de valeurs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName

-- Correction
UPDATE dbo.XClassComponent SET ComponentName = 'colUebermitteln' WHERE ClassName = @className AND ComponentName = 'ColUebermitteln'

SET @controlName = 'colUebermitteln'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Auswählen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Sélectionner',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colZahlungsgrund'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Zahlungsgrund',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Motif du paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuDTAZahlungsLauf'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'kissLabel1'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'EBanking Konto') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel2'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Valutadatum bis',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Date de valeurs au',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnAlleEntfernen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Alle entfernen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Désélectionner tout',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnOK'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zahlungsauftrag generieren',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Générer l''ordre de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnSuchen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zahlungen aktualisieren',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Actualiser les paiements',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuDTAZahlungsLauf'
DECLARE @controlName AS varchar(255) = 'btnAlleEntfernen'
DECLARE @tid AS INTEGER;

SELECT @tid=MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Alle entfernen'
SELECT TOP 1 @tid=MessageTID FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName
EXEC spXSetXLangText @tid,1, 'Alle entfernen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Désélectionner tout',NULL,NULL,NULL,NULL,@tid OUT

IF NOT EXISTS(SELECT 1 FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName)
BEGIN
    INSERT dbo.XMessage(MaskName, MessageName, MessageTID, MessageCode, Context, XMessageTS)
    VALUES(@className, @controlName, @tid, 0, NULL, NULL)
END

UPDATE dbo.XMessage SET MessageTID=@tid WHERE MaskName = @className AND MessageName = @controlName

SET @controlName = 'btnAlleEntfernen1'
SELECT @tid=MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Alle auswählen'
SELECT TOP 1 @tid=MessageTID FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName
EXEC spXSetXLangText @tid,1, 'Alle auswählen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Sélectionner tout',NULL,NULL,NULL,NULL,@tid OUT

IF NOT EXISTS(SELECT 1 FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName)
BEGIN
    INSERT dbo.XMessage(MaskName, MessageName, MessageTID, MessageCode, Context, XMessageTS)
    VALUES(@className, @controlName, @tid, 0, NULL, NULL)
END

UPDATE dbo.XMessage SET MessageTID=@tid WHERE MaskName = @className AND MessageName = @controlName
GO

-- CtlFibuDTATransfer

DECLARE @className AS varchar(255) = 'CtlFibuDTATransfer'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colAuswaehlen'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'ausg.',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'sél.',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBelegNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beleg-Nr.') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBuchungsdatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Datum') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colErsteller'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Ersteller') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colJournalStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kto-Nr.') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKreditor'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beguenstigter') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colName'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'E-Zugang Name',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'E-Accès Nom',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
--colStatusCanEdit
SET @controlName = 'colTotalBetrag'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Total Betrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Montant Total',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colTransferDatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Transfer') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colValuta'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Valuta') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colValutaDatum'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Valuta') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colZahlungsgrund'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Zahlungsgrund') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'gridColumn7'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto Nr') WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuDTATransfer'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'tpgSuchen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgListe'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Liste') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissSearchTitel1'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnAlleAuswaehlen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Alle auswählen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnAlleEntfernen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Alle entfernen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnBezahlt'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Bezahlt',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Payé',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnFehlerhaft'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Fehlerhaft',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Erronné',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBank'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPostKontoNr'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Beleg-Nr.') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel1'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zahlungsauftrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Ordre de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel12'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Buchungen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel13'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Datei') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel2'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'E-Zugang') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel3'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Valutadatum',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Date de valeurs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel4'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Transferdatum',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Date de transfert',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel5'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel6'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Ersteller') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel7'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel8'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Buchung') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel9'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Übermittelte Zahlungsläufe',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Transfert des cycles de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

GO

-- CtlFibuDTAZugang

DECLARE @className AS varchar(255) = 'CtlFibuDTAZugang'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colBank'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Finanz Institut',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Institution financière',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto Nr') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colName'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Name') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colVertragNr'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Vertrag Nummer',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Numéro de contrat',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuDTAZugang'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'lblFinanzInstitut'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Bank') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblKontoNr'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto Nr') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblName'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Name') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPostBank'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Post/Bank',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Poste/Banque',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTeam'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblVertragNr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Vertrag Nr',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Contrat No',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuDTAZugang'
DECLARE @controlName AS varchar(255) = 'radioGroupPostBank1'
DECLARE @tid AS INTEGER;

SELECT @tid=MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Post'
SELECT TOP 1 @tid=MessageTID FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName
EXEC spXSetXLangText @tid,1, 'Post',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Poste',NULL,NULL,NULL,NULL,@tid OUT

IF NOT EXISTS(SELECT 1 FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName)
BEGIN
    INSERT dbo.XMessage(MaskName, MessageName, MessageTID, MessageCode, Context, XMessageTS)
    VALUES(@className, @controlName, @tid, 0, NULL, NULL)
END

UPDATE dbo.XMessage SET MessageTID=@tid WHERE MaskName = @className AND MessageName = @controlName

SET @controlName = 'radioGroupPostBank0'
SELECT @tid=MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Bank'
SELECT TOP 1 @tid=MessageTID FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName
EXEC spXSetXLangText @tid,1, 'Bank',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Banque',NULL,NULL,NULL,NULL,@tid OUT

IF NOT EXISTS(SELECT 1 FROM dbo.XMessage WHERE MaskName = @className AND MessageName = @controlName)
BEGIN
    INSERT dbo.XMessage(MaskName, MessageName, MessageTID, MessageCode, Context, XMessageTS)
    VALUES(@className, @controlName, @tid, 0, NULL, NULL)
END

UPDATE dbo.XMessage SET MessageTID=@tid WHERE MaskName = @className AND MessageName = @controlName
GO

-- CtlFibuBuchungCode

DECLARE @className AS varchar(255) = 'CtlFibuBuchungCode'
DECLARE @controlName AS varchar(255)
DECLARE @tid AS INTEGER;

SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colCode'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Code') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKtoHabenNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKtoSollNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMitarbeiter'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mitarbeiter/in') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ComponentName = @controlName

GO

DECLARE @className AS varchar(255) = 'CtlFibuBuchungCode'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'label1'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mitarbeiter/in') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label4'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label40'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label5'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label7'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'label8'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag CHF') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblCode'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Code') WHERE ClassName = @className AND ControlName = @controlName

GO

-- CtlFibuDauerauftrag

DECLARE @className AS varchar(255) = 'CtlFibuDauerauftrag'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colListeBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeHaben'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeSoll'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeTeam'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListePeriodizitaet'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Periodizität',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Périodicité',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colListeLetzteAusfuehrung'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Letzte Ausf.',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Dernière Exec.',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName

GO


DECLARE @className AS varchar(255) = 'CtlFibuDauerauftrag'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'tpgSuchen'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tpgListe'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Liste') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabKreditor'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kreditor') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'tabDauerauftrag'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Dauerauftrag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Ordre perma.',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnDaAusfuehren'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Alle Daueraufträge ausführen (max einmal täglich!)',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Exécuter tous les ordres permanents (max une fois par jour!)',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissSearchTitel1'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'searchTitle'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Suchen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBetrag'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag CHF') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblDANr'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'DA-Nr',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'OP-No',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblDokument'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Dokument') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblGueltigBis'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Gültig bis') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblGueltigVon'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Gültig von') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblHaben'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblKreditor'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kreditor') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSoll'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMonatstag'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Monatstag(e)',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Jour du mois',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'chkVorWochenende'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Vor Wochenende',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Avant le week-end',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPeriodizitaet'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periodizität') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenDatumBis'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Gültig bis') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenDatumVon'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Gültig von') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenSoll'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenHaben'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenText'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblText'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenTeam'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Team') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'edtNurAktiveX'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'nur aktive') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuchenPeriodizitaet'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Periodizität') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblWochentag'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Wochentag',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Jour de la semaine',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

GO

-- CtlFibuBuchungskreis

DECLARE @className AS varchar(255) = 'CtlFibuBuchungskreis'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colBetrag'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Betrag') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colHaben'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Haben') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMandant'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Mandant') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colSoll'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Soll') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStatus'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colText'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Text') WHERE ClassName = @className AND ComponentName = @controlName
GO

DECLARE @className AS varchar(255) = 'CtlFibuBuchungskreis'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'kissLabel1'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Buchungskreis',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Cycle comptable',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel2'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Buchungsdatum',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Date d''écriture',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnVerbuchen'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Buchungskreis verbuchen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Enregistrer cycle comptable',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

GO

-- CtlFibuTeam

DECLARE @className AS varchar(255) = 'CtlFibuTeam'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colDepot'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Depot',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Dépot',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colFbTeamID'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Team-Nr',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Equipe-No',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colName'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Name') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colStandard'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Standard') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'gridColumn1'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kandidaten') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colUser'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Teammitglieder',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Membres de l''équipe',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName

GO

-- CtlFibuBelegNr

DECLARE @className AS varchar(255) = 'CtlFibuBelegNr'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colMandant'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'MandantIn',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mandant(e)',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBelegNrCode'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'BelegNr-Typ',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Code justificatif',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBereichBis'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Bereich bis',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Plage à',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colBereichVon'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Bereich von',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Plage de',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colNaechsteBelegNr'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Nächste Nr',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'No suivant',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colPraefix'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'Präfix',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Préfixe',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colUser'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'MitarbeiterIn',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Collaborateur(trice)',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName

GO

-- CtlFibuBelegNr

DECLARE @className AS varchar(255) = 'CtlFibuBelegNr'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'lblBelegNrTyp'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'BelegNr-Typ') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBelegNrVon'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'BelegNr-Bereich',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Plage-Justificatif',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMandant'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'MandantIn') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblMitarbeiter'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'MitarbeiterIn') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblNaechsterBelegNr'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Nächste Nr') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPraefix'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Präfix') WHERE ClassName = @className AND ControlName = @controlName
GO

-- CtlFibuIbanGenerieren

DECLARE @className AS varchar(255) = 'CtlFibuIbanGenerieren'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'colBCL'
SELECT TOP 1 @tid= ComponentTID FROM dbo.XClassComponent WHERE ClassName = @className AND ComponentName = @controlName     
EXEC spXSetXLangText @tid,1, 'BCL',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'BCL',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassComponent SET ComponentTID = @tid WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colKontoNr'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Konto') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colNameEmpfaenger'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Kreditor') WHERE ClassName = @className AND ComponentName = @controlName
SET @controlName = 'colMessage'
UPDATE dbo.XClassComponent SET dbo.XClassComponent.ComponentTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Fehler') WHERE ClassName = @className AND ComponentName = @controlName

GO

DECLARE @className AS varchar(255) = 'CtlFibuIbanGenerieren'
DECLARE @controlName AS varchar(255) = ''
DECLARE @tid AS INTEGER;

SET @controlName = 'btnCancel'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Abbrechen') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnGotoKreditor'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zu Kreditor springen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Aller au créditeur',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'btnStart'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'IBAN generieren',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Générer IBAN',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'edtAktiv'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Aktiv') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'grpGenerate'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Generieren',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Générer',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'grpKorrektur'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Korrektur Zahlungsweg',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Correction méthode de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'grpMessage'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Ausgabe Zahlungswege',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Edition méthode de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'grpStatusAmount'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Status') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'kissLabel7'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Zahlungsart') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBank'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Bank') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblBankKontoNr'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'Bankkonto-Nr') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblFailC'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Generierung nicht möglich',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Génération impossible',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblIBAN'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'IBAN') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblPostKontoNr'
UPDATE dbo.XClassControl SET ControlTID = (SELECT MIN(TID) FROM dbo.XLangText xt WHERE xt.Text = 'PostKonto-Nr') WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblSuccessC'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'IBAN generiert',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'IBAN généré',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTodo'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Anzahl zu generieren',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Nombre à générer',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblTotalC'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zahlungswege ohne IBAN',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Méthode de paiement sans IBAN',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName
SET @controlName = 'lblZahlungsfrist'
SELECT TOP 1 @tid= ControlTID FROM dbo.XClassControl WHERE ClassName = @className AND ControlName = @controlName
EXEC spXSetXLangText @tid,1, 'Zahlungsfrist',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Délai de paiement',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XClassControl SET ControlTID = @tid WHERE ClassName = @className AND ControlName = @controlName

GO
