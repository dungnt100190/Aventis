-- =============================================
-- Tabelle WshKategorie_KbuKonto und WshKontoAttribut füllen
-- Erstellt Grundkonfiguration und putzt bestehendes Weg!
-- =============================================


DECLARE @SysDate DATETIME;
SET @SysDate = GETDATE();

DECLARE @SysUser VARCHAR(50);
SELECT TOP 1 @SysUser = LogonName 
FROM dbo.XUser 
WHERE UserID = dbo.fnXGetSystemUserID();


------------------------------------------------
-- Daten vom Excel in temporäre Tabelle abfüllen
-- Excel mittels copy paste vom Anforderungsdokument
-- 7482 erstellt.
------------------------------------------------

DECLARE @Steuerung TABLE 
( 
    KOA VARCHAR(200), --Beispiel "110"
    
    Ausgabe VARCHAR(3), -- Die 5 Wshkategorien
    Einname VARCHAR(3),
    Sanktion VARCHAR(3),
    Verrechnung VARCHAR(3),
    Rueckerstattung VARCHAR(3),
    
    IstLeistungWsh VARCHAR(3),
    IstLeistungWshStationaer VARCHAR(3),
    IstMonatsbudgetAktiv VARCHAR(3),
    IstGrundbudgetAktiv VARCHAR(3),
    
    Betrifft VARCHAR(500),   
    
    Quoting VARCHAR(500)             
);

/*
Folgende Spalte für Excel
= "INSERT INTO @Steuerung"
& "("
&  "KOA,"
&  "Ausgabe,"
&  "Einname,"
&  "Sanktion,"
&  "Verrechnung,"
&  "Rueckerstattung,"
&  "IstLeistungWsh,"
&  "IstLeistungWshStationaer,"
&  "IstGrundbudgetAktiv,"
&  "IstMonatsbudgetAktiv,"
&  "Betrifft,"
&  "Quoting"
& ")"
& "VALUES"
& "("
&    "'" & A2 & "',"
&    "'" & C2 & "', "
&    "'" & D2 & "', "
&    "'" & E2 & "', "
&    "'" & F2 & "', "
&    "'" & G2 & "', "
&    "'" & H2 & "', "
&    "'" & I2 & "', "
&    "'" & J2 & "', "
&    "'" & K2 & "', "
&    "'" & L2 & "', "
&    "'" & M2 & "' "
& ");"
*/

INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('110','x', 's', 'x', 'x', '', 'x', ' x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('120','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('121','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('125','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('126','x', '', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('127','x', '', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('128','x', '', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('129','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('130','x', 's', '', 'x', '', 'x', '', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('131','x', 's', '', '', '', 'x', '', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('140','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('141','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('142','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('143','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('150','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('151','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('152','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('160','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('170','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('210','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('211','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('212','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('213','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('215','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('216','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('220','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('221','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('222','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('230','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('231','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('232','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('233','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('235','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('240','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('241','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('242','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('260','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('261','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('310','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('311','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('313','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('314','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('315','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('320','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('321','x', 's', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('330','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('331','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('332','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('333','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('334','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('340','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('341','x', 's', '', '', '', 'x', '', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('350','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('351','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('352','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('353','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('359','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('360','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('361','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('362','x', 's', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('370','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('371','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('380','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('381','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('390','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('391','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('392','x', 's', 'x', 'x', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('410','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('411','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('420','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('430','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('440','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('450','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('460','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('465','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('470','x', 's', '', '', '', 'x', '', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('473','x', 's', '', '', '', 'x', '', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('475','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('476','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('','', '', '', '', '', '', '', '', '', '', '' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('480','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('481','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('482','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('510','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('511','x', 's', '', '', '', '', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('512','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('515','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('520','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('521','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('522','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('523','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('530','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('531','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('532','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('540','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('550','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('560','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('561','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('562','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('570','x', 's', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('590','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('591','x', 's', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('710','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('711','s', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('720','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('721','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('722','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('723','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('724','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('725','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('726','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('730','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('731','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('732','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('733','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('734','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('735','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('736','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('740','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('741','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('742','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('743','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('744','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('750','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('751','s', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('752','s', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('753','s', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('754','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('755','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('756','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('757','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('758','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('760','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('762','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('763','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('764','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('780','', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('798','x', '', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('810','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('811','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('812','s', 'x', '', '', '', 'x', 'x', '', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('814','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('817','s', 'x', '', '', '', 'x', 'x', '', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('818','s', 'x', '', '', '', 'x', 'x', '', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('819','s', 'x', '', '', '', '', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('820','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('821','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('822','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('830','s', 'x', '', '', '', 'x', 'x', '', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('831','s', 'x', '', '', '', 'x', 'x', '', '', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('833','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('834','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('850','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('851','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('852','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('853','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('854','', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('855','s', 'x', '', '', '', 'x', 'x', 'x', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('860','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('861','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('862','', 'x', '', '', '', 'x', 'x', '', '', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('863','', 'x', '', '', 'x', 'x', 'x', 'x', '', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('864','', 'x', '', '', 'x', 'x', 'x', 'x', '', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('865','', 'x', '', '', 'x', 'x', 'x', 'x', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('870','', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('871','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('872','', 'x', '', '', 'x', 'x', 'x', 'x', '', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('873','', 'x', '', '', 'x', 'x', 'x', 'x', '', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('874','', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('875','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('876','', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('877','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('880','', 'x', '', '', '', 'x', 'x', '', 'x', 'Person, zwingend', 'Nein' );
INSERT INTO @Steuerung(KOA,Ausgabe,Einname,Sanktion,Verrechnung,Rueckerstattung,IstLeistungWsh,IstLeistungWshStationaer,IstGrundbudgetAktiv,IstMonatsbudgetAktiv,Betrifft,Quoting)VALUES('881','', 'x', '', '', '', 'x', 'x', '', 'x', 'UE, immer', 'Ja' );



----------------------------------------------------------
-- Zieltabellen füllen. Mit Cursor über Einträge iterieren
----------------------------------------------------------
-- Wegen doppelzeilen leere Einträge löschen
DELETE FROM @Steuerung WHERE KOA = '';

-- Existierende Einträge in WshKategorie_KbuKonto löschen
DELETE FROM WshKategorie_KbuKonto;

-- Existierende Einträge in WshKontoAttribut löschen
DELETE FROM WshKontoAttribut;

DECLARE STEUERUNGCURSOR CURSOR FAST_FORWARD FOR
  SELECT 
    KOA,
    Ausgabe,
    Einname,
    Sanktion,
    Verrechnung,
    Rueckerstattung,
    IstLeistungWsh,
    IstLeistungWshStationaer,
    IstMonatsbudgetAktiv,
    IstGrundbudgetAktiv,
    Betrifft,
    Quoting
  FROM @Steuerung;
  
DECLARE @SteuerungKOA VARCHAR(200);
DECLARE @SteuerungAusgabe VARCHAR(3);
DECLARE @SteuerungEinname VARCHAR(3);
DECLARE @SteuerungSanktion VARCHAR(3);
DECLARE @SteuerungVerrechnung VARCHAR(3);
DECLARE @SteuerungRueckerstattung VARCHAR(3);
DECLARE @SteuerungLeistungWsh VARCHAR(3);
DECLARE @SteuerungLeistungWshStationaer VARCHAR(3);
DECLARE @SteuerungIstMonatsbudgetAktiv VARCHAR(3);
DECLARE @SteuerungIstGrundbudgetAktiv VARCHAR(3);
DECLARE @SteuerungBetrifft VARCHAR(500);
DECLARE @SteuerungQuoting VARCHAR(500);


DECLARE @WshKategorieAusgabeID INT;
DECLARE @WshKategorieEinnahmeID INT;
DECLARE @WshKategorieSanktionID INT;
DECLARE @WshKategorieVerrechnungID INT;
DECLARE @WshKategorieRueckerstattungID INT;

DECLARE @LeistungWsh BIT;
DECLARE @LeistungWshStationaer BIT;
DECLARE @IstMonatsbudgetAktiv BIT;
DECLARE @IstGrundbudgetAktiv BIT;
DECLARE @SysEditMode_Betrifft INT;

-- Die IDs der Kategorien
SET @WshKategorieAusgabeID = 1;
SET @WshKategorieEinnahmeID = 2;
SET @WshKategorieSanktionID = 3;
SET @WshKategorieVerrechnungID = 4;
SET @WshKategorieRueckerstattungID = 5;

-- Iteration über alle Einträge  
OPEN STEUERUNGCURSOR
WHILE (1=1) BEGIN
  FETCH NEXT FROM STEUERUNGCURSOR INTO @SteuerungKOA, 
                                       @SteuerungAusgabe,
                                       @SteuerungEinname,
                                       @SteuerungSanktion,
                                       @SteuerungVerrechnung,
                                       @SteuerungRueckerstattung,
                                       @SteuerungLeistungWsh,
                                       @SteuerungLeistungWshStationaer,
                                       @SteuerungIstMonatsbudgetAktiv,
                                       @SteuerungIstGrundbudgetAktiv,
                                       @SteuerungBetrifft,
                                       @SteuerungQuoting
  
  IF @@FETCH_STATUS < 0 BREAK;
  
  PRINT('Füge KOA ' + @SteuerungKOA + ' hinzu');
  
  DECLARE @WshKategorien TABLE
  (
    WshKategorieID INT,
    NurMitSpezialrecht BIT
  );
  
  --Zur sicherheit inhalt löschen
  DELETE FROM @WshKategorien;
  
  --WshKategorie Ausgabe
  IF @SteuerungAusgabe LIKE '%x%' OR @SteuerungAusgabe LIKE '%X%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieAusgabeID, 0);
  END 
  IF @SteuerungAusgabe LIKE '%s%' OR @SteuerungAusgabe LIKE '%S%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieAusgabeID, 1);
  END;
  
  --WshKategorie Einnahme
  IF @SteuerungEinname LIKE '%x%' OR @SteuerungEinname LIKE '%X%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieEinnahmeID, 0);
  END 
  IF @SteuerungEinname LIKE '%s%' OR @SteuerungEinname LIKE '%S%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieEinnahmeID, 1);
  END;
  
  --WshKategorie Sanktion
  IF @SteuerungSanktion LIKE '%x%' OR @SteuerungSanktion LIKE '%X%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieSanktionID, 0);
  END 
  IF @SteuerungSanktion LIKE '%s%' OR @SteuerungSanktion LIKE '%S%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieSanktionID, 1);
  END;
  
  --WshKategorie Verrechnung
  IF @SteuerungVerrechnung LIKE '%x%' OR @SteuerungVerrechnung LIKE '%X%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieVerrechnungID, 0);
  END 
  IF @SteuerungVerrechnung LIKE '%s%' OR @SteuerungVerrechnung LIKE '%S%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieVerrechnungID, 1);
  END;
  
  
  --WshKategorie Rückerstattung
  IF @SteuerungRueckerstattung LIKE '%x%' OR @SteuerungRueckerstattung LIKE '%X%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieRueckerstattungID, 0);
  END;

  IF @SteuerungRueckerstattung LIKE '%s%' OR @SteuerungRueckerstattung LIKE '%S%'
  BEGIN 
    INSERT INTO @WshKategorien (WshKategorieID, NurMitSpezialrecht) VALUES (@WshKategorieRueckerstattungID, 1);
  END;
  
  --LeistungWsh
  IF @SteuerungLeistungWsh LIKE '%x%' OR @SteuerungLeistungWsh LIKE '%X%'
  BEGIN 
    SET @LeistungWsh = 1;
  END 
  ELSE 
  BEGIN
    SET @LeistungWsh = 0;
  END;
    
  --LeistungWshStationaer
  IF @SteuerungLeistungWshStationaer LIKE '%x%' OR @SteuerungLeistungWshStationaer LIKE '%X%'
  BEGIN 
    SET @LeistungWshStationaer = 1;
  END 
  ELSE 
  BEGIN
    SET @LeistungWshStationaer = 0;
  END;
  
  --MonatsbudgetAktiv
  IF @SteuerungIstMonatsbudgetAktiv LIKE '%x%' OR @SteuerungIstMonatsbudgetAktiv LIKE '%X%'
  BEGIN 
    SET @IstMonatsbudgetAktiv = 1;
  END 
  ELSE 
  BEGIN
    SET @IstMonatsbudgetAktiv = 0;
  END;
    
  --GrundbudgetAktiv
  IF @SteuerungIstGrundbudgetAktiv LIKE '%x%' OR @SteuerungIstGrundbudgetAktiv LIKE '%X%'
  BEGIN 
    SET @IstGrundbudgetAktiv = 1;
  END 
  ELSE 
  BEGIN
    SET @IstGrundbudgetAktiv = 0;
  END;
    
  -- SysEditMode          
  IF @SteuerungBetrifft LIKE '%UE%'
  BEGIN
    SET @SysEditMode_Betrifft = 3 -- readonly.
  END
  ELSE
  BEGIN
    SET @SysEditMode_Betrifft = 2 -- required
  END;
    
  
  -- Tabelle WshKategorie_KbuKonto füllen
  INSERT INTO dbo.WshKategorie_KbuKonto 
  (
    KbuKontoID, 
    WshKategorieID, 
    NurMitSpezialrecht, 
    Creator, 
    Created, 
    Modifier, 
    Modified
  )
  SELECT 
    KTO.KbuKontoID, 
    KAT.WshKategorieID, 
    KAT.NurMitSpezialrecht, --NurMitSpezialrecht
    @SysUser, 
    @SysDate, 
    @SysUser, 
    @SysDate
  FROM dbo.KbuKonto KTO
    CROSS JOIN @WshKategorien KAT -- Kartesisches Produkt mit @WshKategorien
  WHERE KTO.KontoNr = @SteuerungKOA  
    AND NOT EXISTS(SELECT TOP 1 1 
                   FROM dbo.WshKategorie_KbuKonto XX
                   WHERE XX.KbuKontoID = KTO.KbuKontoID 
                     AND XX.WshKategorieID = KAT.WshKategorieID);    
  
  
  -- Eintrag in Tabelle KbuKontoAttribut
  INSERT INTO dbo.WshKontoAttribut
  (
    KbuKontoID,
    IstGrundbudgetAktiv,
    IstMonatsbudgetAktiv,
    IstLeistungWsh,
    IstLeistungWshStationaer,
    SysEditModeCode_BetrifftPerson,
    Creator,
    Created,
    Modifier,
    Modified    
  )
  SELECT   
    KTO.KbuKontoID, --KbuKontoID
    @IstGrundbudgetAktiv,   --IstGrundbudgetAktiv
    @IstMonatsbudgetAktiv,   --IstMonatsbudgetAktiv
    @LeistungWsh,   --IstLeistungWsh,
    @LeistungWshStationaer,   --IstLeistungWshStationaer,
    @SysEditMode_Betrifft,   --SysEditModeCode_BetrifftPerson
    @SysUser, 
    @SysDate, 
    @SysUser, 
    @SysDate
  FROM dbo.KbuKonto KTO
  WHERE KTO.KontoNr = @SteuerungKOA;
    
END;