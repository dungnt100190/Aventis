SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XBookmark]
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklPhasen', N'Abklärung', 1, N'SELECT <TableColumn>
FROM   vwTmAbklPhasen
WHERE  KaAKPhasenID = {KaAKPhasenID}', N'Diverse Textmarken für Abklärung Phasen', N'vwTmAbklPhasen', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklPhasenKursDatumBisAkt', N'Abklärung', 1, N'
  SELECT ISNULL(Convert(VARCHAR(15), KUE.DatumBis, 104), '''')
  FROM KaAKPhasen AKP
    LEFT JOIN KaKurserfassung KUE ON KUE.KaKurserfassungID = AKP.KursID
    LEFT JOIN KaKurs KUR ON KUR.KaKursID = KUE.KursID
  WHERE AKP.KaAKPhasenID = (SELECT TOP 1 KaAKPhasenID
                            FROM KaAKPhasen
                            WHERE FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                  FROM FaLeistung
                                                  WHERE ModulID = 7
                                                    AND FaProzessCode = 701
                                                    AND BaPersonID = {BaPersonID}
                                                  ORDER BY DatumVon DESC)
                            ORDER BY Datum DESC)', N'Aktueller Eintrag in Abklärung->Phasen!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklPhasenKursDatumVonAkt', N'Abklärung', 1, N'
  SELECT ISNULL(Convert(VARCHAR(15), KUE.DatumVon, 104), '''')
  FROM KaAKPhasen AKP
    LEFT JOIN KaKurserfassung KUE ON KUE.KaKurserfassungID = AKP.KursID
    LEFT JOIN KaKurs KUR ON KUR.KaKursID = KUE.KursID
  WHERE AKP.KaAKPhasenID = (SELECT TOP 1 KaAKPhasenID
                            FROM KaAKPhasen
                            WHERE FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                  FROM FaLeistung
                                                  WHERE ModulID = 7
                                                    AND FaProzessCode = 701
                                                    AND BaPersonID = {BaPersonID}
                                                  ORDER BY DatumVon DESC)
                            ORDER BY Datum DESC)', N'Aktueller Eintrag in Abklärung->Phasen!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwAdresseMehrzeilig', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select OKO.Vorname + '' '' + OKO.Name + char(13) + char(10) +
       isNull(ORG.AdressZusatz + char(13) + char(10),'''') +
         isNull(ORG.StrasseHausNr + char(13) + char(10),'''') +
         isNull(ORG.PLZOrt, '''')	
  from   BaInstitutionKontakt OKO
   left join vwInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID
  where OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select PRS.VornameName + char(13) + char(10) +
         isNull(PRS.WohnsitzAdressZusatz + char(13) + char(10),'''') +
         isNull(PRS.WohnsitzStrasseHausNr + char(13) + char(10),'''') +
         isNull(PRS.WohnsitzPLZOrt, '''')
  from   vwPerson PRS	
  where  PRS.BaPersonID = -@KontaktID - 100000
else
  select USR.Firstname + '' '' + USR.Lastname + char(13) + char(10),
   AdressatRTF = OUN.Adressat
  from   XUser USR
  left join XOrgUnit_User OUU on OUU.UserID = USR.UserID AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  left join XOrgUnit OUN on OUN.OrgUnitID = OUU.OrgUnitID
  where  USR.UserID = -@KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwAnmeldung', N'Abklärung', 1, N'SELECT	Anmeldung = dbo.fnLOVText(''KaAbklärungZuwAnmeld'', AnmeldungCode)
FROM	KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE FAL.BaPersonID = {BaPersonID}
          AND FAL.ModulID = 7
          AND FAL.FaProzessCode = 701
          ORDER BY FAL.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwBerater', N'Abklärung', 1, N'SELECT	Berater = CASE WHEN AKZ.BeraterID < 0 THEN XUR.LastName + IsNull('' '' + XUR.FirstName,'''') ELSE OKO.Name + isNull('', '' + OKO.Vorname,'''') END
FROM	KaAKZuweiser AKZ
  LEFT JOIN BaInstitutionKontakt OKO	on OKO.BaInstitutionKontaktID = AKZ.BeraterID
  LEFT JOIN XUser XUR on XUR.UserID = -AKZ.BeraterID
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE FAL.BaPersonID = {BaPersonID}
          AND FAL.ModulID = 7
          AND FAL.FaProzessCode = 701
                      ORDER BY FAL.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwDatumErf', N'Abklärung', 1, N'SELECT	DatumErfassung = IsNull(Convert(varchar, AKZ.Erfassung, 104), '' '')
FROM	KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE FAL.BaPersonID = {BaPersonID}
          AND FAL.ModulID = 7
          AND FAL.FaProzessCode = 701
                      ORDER BY FAL.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwFrauHerr', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select case
         when OKO.Anrede like ''%frau%'' then ''Frau ''
         when OKO.Anrede like ''%herr%'' then ''Herr ''
         else ''Frau/Herr ''
         end
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select case PRS.GeschlechtCode
         when 1 then ''Herr ''
         when 2 then ''Frau ''
         else ''Frau/Herr ''
         end
  from   BaPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select case USR.GenderCode
         when 1 then ''Herr ''
         when 2 then ''Frau ''
         else ''Frau/Herr ''
         end
  from   XUser USR
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwGeehrterFrauHerr', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select case
         when OKO.Anrede like ''%frau%'' then ''Sehr geehrte Frau ''
         when OKO.Anrede like ''%herr%'' then ''Sehr geehrter Herr ''
         else ''Sehr geehrte/r Frau/Herr ''
         end +
         OKO.Name
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select case PRS.GeschlechtCode
         when 1 then ''Sehr geehrter Herr ''
         when 2 then ''Sehr geehrte Frau ''
         else ''Sehr geehrte/-r Frau/Herr ''
         end +
   PRS.Name
  from   BaPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select case USR.GenderCode
         when 1 then ''Sehr geehrter Herr ''
         when 2 then ''Sehr geehrte Frau ''
         else ''Sehr geehrte/-r Frau/Herr ''
         end +
   USR.LastName
  from   XUser USR
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwInstitution', N'Abklärung', 1, N'SELECT	Institution = CASE WHEN AKZ.InstitutionID < 0 THEN ORG1.ItemName ELSE ORG.Name END
FROM	KaAKZuweiser AKZ
  LEFT JOIN BaInstitution ORG	on ORG.BaInstitutionID = AKZ.InstitutionID
  LEFT JOIN XOrgUnit ORG1 on ORG1.OrgUnitID = -AKZ.InstitutionID
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE FAL.BaPersonID = {BaPersonID}
          AND FAL.ModulID = 7
          AND FAL.FaProzessCode = 701
                      ORDER BY FAL.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwNameVorname', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select OKO.Name + IsNull('' '' + OKO.Vorname, '''')
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select PRS.Name + IsNull('' '' + PRS.Vorname, '''')
  from   BaPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select USR.LastName + IsNull('' '' + USR.FirstName, '''')
  from   XUser USR
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwNameVornameMitKomma', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select OKO.Name + IsNull('', '' + OKO.Vorname, '''')
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select PRS.Name + IsNull('', '' + PRS.Vorname, '''')
  from   BaPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select USR.LastName + IsNull('', '' + USR.FirstName, '''')
  from   XUser USR
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVAbschluss', N'Abklärung', 1, N'SELECT	Berufsabschluss = dbo.fnLOVText(''Beruf'', DAA.ErlernterBerufCode)
FROM	KaEinsatz KAE
  LEFT JOIN BaArbeitAusbildung DAA on DAA.BaPersonID = KAE.BaPersonID						
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVBeschGrad', N'Abklärung', 1, N'SELECT	Beschaeftigungsgrad = IsNull(BeschGrad, '' '')
FROM	KaEinsatz KAE
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVDauerBis', N'Abklärung', 1, N'SELECT	DauerBis = IsNull(Convert(varchar, DatumBis, 104), '' '')
FROM	KaEinsatz KAE
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVDauerVon', N'Abklärung', 1, N'SELECT	DauerVon = IsNull(Convert(varchar, DatumVon, 104), '' '')
FROM	KaEinsatz KAE
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVFachbereich', N'Abklärung', 1, N'SELECT	Fachbereich = KEP.Name
FROM	KaEinsatz KAE
  LEFT JOIN KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID						
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwRAVRahmenfristBis', N'Abklärung', 1, N'SELECT	Rahmenfrist = IsNull(Convert(varchar, RahmenfristBis, 104), '' '')
FROM	KaEinsatz KAE
WHERE	KAE.BaPersonID = {BaPersonID}
AND	KAE.DatumBis = (SELECT MAX(DatumBis) FROM KaEinsatz WHERE BaPersonID = KAE.BaPersonID)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbklZuwVornameName', N'Abklärung', 1, N'DECLARE @KontaktID INT

SELECT @KontaktID = AKZ.BeraterID
FROM KaAKZuweiser AKZ
WHERE AKZ.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
          FROM FaLeistung FAL
          WHERE BaPersonID = {BaPersonID}
          AND ModulID = 7
          AND FaProzessCode = 701
          AND DatumBis is NULL)

if @KontaktID > 1
  select IsNull(OKO.Vorname, '''') + IsNull('' '' + OKO.Name, '''')
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select IsNull(PRS.Vorname, '''') + IsNull('' '' + PRS.Name, '''')
  from   BaPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select IsNull(USR.FirstName, '''') + IsNull('' '' + USR.LastName, '''')
  from   XUser USR
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatAdresseEinzeilig', N'Adressat', 1, N'DECLARE @AdressatId INT;
DECLARE @CrLf VARCHAR(10);

SET @AdressatId = {AdressatID};
SET @CrLf = '', '';

IF (@AdressatId > 0)
BEGIN
  -- person
  SELECT ISNULL(Anrede + @CrLf, '''') + 
         CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
           WHEN 3 THEN ISNULL(AufenthaltWohnortAdrEinzeilig, '''')
           ELSE ISNULL(WohnsitzAdresseEinzeilig, '''')
         END
  FROM dbo.vwTmPerson WITH (READUNCOMMITTED)
  WHERE BaPersonID = @AdressatId;
END
ELSE IF (@AdressatId BETWEEN -199999 AND -100000)
BEGIN
  -- prima
  SELECT ISNULL(PRM.Titel + @CrLf, '''') +
         ISNULL(PRM.Vorname + '' '', '''') + ISNULL(Name, '''') + @CrLf +
         ISNULL(ADR.Zusatz + @CrLf, '''') +
         ISNULL(ADR.Strasse + '' '', '''') + ISNULL(ADR.HausNr, '''') + @CrLf +
         ISNULL(ADR.PLZ + '' '', '''') + ISNULL(ADR.Ort, '''')
  FROM dbo.VmPriMa         PRM
   LEFT JOIN dbo.BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID
                              AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())
  WHERE PRM.VmPriMaID = -@AdressatId - 100000;
END
else
BEGIN
  -- institution
  SELECT INS.AdresseEinzeilig
  FROM dbo.vwTmInstitution INS
  WHERE INS.BaInstitutionID = -@AdressatId;
END;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatAdresseMehrzeilig', N'Adressat', 1, N'DECLARE @AdressatId INT;
DECLARE @CrLf VARCHAR(10);

SET @AdressatId = {AdressatID};
SET @CrLf = CHAR(13) + CHAR(10);

IF (@AdressatId > 0)
BEGIN
  -- person
  SELECT ISNULL(Anrede + @CrLf, '''') + 
         CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
           WHEN 3 THEN ISNULL(AufenthaltWohnortAdrMehrzeilig, '''')
           ELSE ISNULL(WohnsitzAdresseMehrzeilig, '''')
         END
  FROM dbo.vwTmPerson WITH (READUNCOMMITTED)
  WHERE BaPersonID = @AdressatId;
END
ELSE IF (@AdressatId BETWEEN -199999 AND -100000)
BEGIN
  -- prima
  SELECT ISNULL(PRM.Titel + @CrLf, '''') +
         ISNULL(PRM.Vorname + '' '', '''') + ISNULL(Name, '''') + @CrLf +
         ISNULL(ADR.Zusatz + @CrLf, '''') +
         ISNULL(ADR.Strasse + '' '', '''') + ISNULL(ADR.HausNr, '''') + @CrLf +
         ISNULL(ADR.PLZ + '' '', '''') + ISNULL(ADR.Ort, '''')
  FROM dbo.VmPriMa         PRM
   LEFT JOIN dbo.BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID
                              AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())
  WHERE PRM.VmPriMaID = -@AdressatId - 100000;
END
else
BEGIN
  -- institution
  SELECT INS.AdresseMehrzeilig
  FROM dbo.vwTmInstitution INS
  WHERE INS.BaInstitutionID = -@AdressatId;
END;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatErsteZeile', N'Adressat', 1, N'if {AdressatID} > 0
  SELECT PRS.Vorname + '' '' + PRS.Name
  FROM   BaPerson PRS
  WHERE  PRS.BaPersonID = {AdressatID}

else if {AdressatID} between -199999 and -100000
  SELECT PRM.Vorname + '' '' + PRM.Name
  FROM   VmPriMa PRM
  WHERE  PRM.VmPriMaID = - {AdressatID} - 100000

else
  SELECT ORG.Name
  FROM   BaInstitution ORG
  WHERE  ORG.BaInstitutionID = - {AdressatID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatGeehrteFrauHerr', N'Adressat', 1, N'if {AdressatID} > 0 begin
  select case GeschlechtCode
         when 1 then ''geehrter Herr ''
         when 2 then ''geehrte Frau ''
         else ''geehrte/-r Frau/Herr ''
         end +
         PRS.Name
  from   BaPerson PRS
  where  PRS.BaPersonID = {AdressatID}
end else
  select ''geehrte Damen und Herren''', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatOrt', N'Adressat', 1, N'
DECLARE @AdressatId INT;
SET @AdressatId = {AdressatID};

IF @AdressatId > 0
    SELECT 
      CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
        WHEN 3 THEN ISNULL(AufenthaltOrt, ISNULL(WohnsitzOrt, ''''))
        ELSE        ISNULL(WohnsitzOrt, '''')
      END 
    FROM   vwPerson    
    WHERE  BaPersonID = @AdressatId;  
ELSE IF @AdressatId between -199999 and -100000
    SELECT ISNULL(ADR.Ort, '''')    
    FROM   VmPriMa              PRM
      LEFT  JOIN BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID                                
        AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())    
    WHERE   PRM.VmPriMaID = - @AdressatId - 100000;
ELSE
    SELECT ISNULL(PLZOrt, '''')    
    FROM   vwInstitution    
    WHERE  BaInstitutionID = - @AdressatId;
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatPLZ', N'Adressat', 1, N'
DECLARE @AdressatId INT;
SET @AdressatId = {AdressatID};

IF @AdressatId > 0
    SELECT 
      CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
        WHEN 3 THEN ISNULL(AufenthaltPLZ, ISNULL(WohnsitzPLZ,''''))
        ELSE        ISNULL(WohnsitzPLZ,'''')
      END    
    FROM   vwPerson    
    WHERE  BaPersonID = @AdressatId    
ELSE IF @AdressatId between -199999 and -100000
    SELECT ISNULL(ADR.PLZ, '''')
    FROM   VmPriMa PRM    
      LEFT  JOIN BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID
        AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())
    WHERE  PRM.VmPriMaID = - @AdressatId - 100000    
ELSE
    SELECT ISNULL(PLZ, '''')    
    FROM   vwInstitution     
    WHERE  BaInstitutionID = - @AdressatId
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatPLZOrt', N'Adressat', 1, N'
DECLARE @AdressatId INT;
SET @AdressatId = {AdressatID};
    
IF @AdressatId > 0
    SELECT 
      CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
        WHEN 3 THEN dbo.fnIsNullOrEmpty(AufenthaltPLZOrt, WohnsitzPLZOrt, NULL, NULL)
        ELSE        dbo.fnIsNullOrEmpty(WohnsitzPLZOrt, NULL, NULL, NULL)
      END      
    FROM   vwPerson    
    WHERE  BaPersonID = @AdressatId    
ELSE IF @AdressatId between -199999 and -100000
    SELECT IsNull(ADR.PLZ + '' '', '''') + IsNull(ADR.Ort, '''')    
    FROM  VmPriMa PRM    
      LEFT  JOIN BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID
        AND GetDate() BETWEEN IsNull(ADR.DatumVon, GetDate()) AND IsNull(ADR.DatumBis, GetDate())    
    WHERE  PRM.VmPriMaID = - @AdressatId - 100000    
ELSE
    SELECT IsNull(PLZOrt, '''')    
    FROM   vwInstitution     
    WHERE  BaInstitutionID = - @AdressatId
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatStrasse', N'Adressat', 1, N'
DECLARE @AdressatId INT;
SET @AdressatId = {AdressatID};

IF @AdressatId > 0
    SELECT 
      CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
        WHEN 3 THEN dbo.fnIsNullOrEmpty(AufenthaltStrasseHausNr, WohnsitzStrasseHausNr, NULL, NULL)
        ELSE        dbo.fnIsNullOrEmpty(WohnsitzStrasseHausNr, NULL, NULL, NULL)
      END       
    FROM   vwPerson    
    WHERE  BaPersonID = @AdressatId    
ELSE IF @AdressatId between -199999 and -100000
    SELECT ISNULL(ADR.Strasse + '' '', '''') + ISNULL(ADR.HausNr, '''')    
    FROM   VmPriMa PRM    
      LEFT  JOIN BaAdresse ADR ON ADR.VmPriMaID = PRM.VmPriMaID  
        AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())    
    WHERE  PRM.VmPriMaID = - @AdressatId - 100000    
ELSE
    SELECT ISNULL(StrasseHausNr, '''')    
    FROM   vwInstitution     
    WHERE  BaInstitutionID = - @AdressatId
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatZusatzzeile', N'Adressat', 1, N'
DECLARE @AdressatId INT;
SET @AdressatId = {AdressatID};

IF @AdressatId > 0
    SELECT 
      CASE dbo.fnXConfig(''System\Textmarken\AdressatAdresse'', GETDATE())
        WHEN 3 THEN ISNULL(AufenthaltAdressZusatz, ISNULL(WohnsitzAdressZusatz,''''))
        ELSE        ISNULL(WohnsitzAdressZusatz,'''')
      END 
    FROM   vwPerson    
    WHERE  BaPersonID = @AdressatId    
ELSE IF @AdressatId between -199999 and -100000
    SELECT ISNULL(ADR.Zusatz,'''')    
    FROM   VmPriMa PRM    
      LEFT  JOIN BaAdresse      ADR ON ADR.VmPriMaID = PRM.VmPriMaID
        AND GETDATE() BETWEEN ISNULL(ADR.DatumVon, GETDATE()) AND ISNULL(ADR.DatumBis, GETDATE())    
    WHERE PRM.VmPriMaID = - @AdressatId - 100000    
ELSE
    SELECT ISNULL(Zusatz,'''')    
    FROM   vwInstitution     
    WHERE  BaInstitutionID = - @AdressatId
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiBezeichnung', N'Inkasso', 1, N'DECLARE @Text VARCHAR(500);
SET @Text = '''';

SELECT @Text = @Text + Bezeichnung + CHAR(13) + CHAR(10)
FROM dbo.FaLeistung WITH (READUNCOMMITTED)
WHERE FaProzessCode = 401 -- Alimente
  AND Bezeichnung IS NOT NULL
  AND ISNULL(DatumBis, ''99990101'') >= GETDATE()
  AND BaPersonID = {BaPersonID}
ORDER BY DatumVon DESC;

IF (LEN(@Text) > 0)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 1);', N'Bezeichnung Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiDetailsForderungen', N'Inkasso', 1, N'DECLARE @Text VARCHAR(4000);
SET @Text = '''';

SELECT @Text = @Text + RTT.Bemerkung + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10)
FROM dbo.IkRechtstitel      RTT WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
  AND RTT.Bemerkung IS NOT NULL
  AND LEI.FaProzessCode = 401 -- Alimente
  AND LEI.BaPersonID = {BaPersonID}
ORDER BY LEI.DatumVon DESC;

IF (LEN(@Text) > 2)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 3);', N'Feld "Details zu den Forderungen" in Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiGlaeubiger', N'Inkasso', 1, N'DECLARE @Personen TABLE (BaPersonID INT);
DECLARE @Text VARCHAR(500);
SET @Text = '''';

INSERT INTO @Personen
SELECT DISTINCT
  GLB.BaPersonID
FROM dbo.IkGlaeubiger          GLB WITH (READUNCOMMITTED)
  INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.IkRechtstitelID = GLB.IkRechtstitelID
  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
  AND LEI.FaProzessCode = 401 -- Alimente
  AND LEI.BaPersonID = {BaPersonID};

SELECT 
  @Text = @Text + dbo.fnGetLastFirstName(PRS.BaPersonID, PRS.Name, PRS.Vorname) + ISNULL('' ('' + CONVERT(VARCHAR, PRS.Geburtsdatum, 104) + ''); '', '''')
FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
WHERE PRS.BaPersonID IN (SELECT BaPersonID FROM @Personen)
ORDER BY PRS.Name ASC;

SELECT SUBSTRING(@Text, 0, LEN(@Text));', N'Liste aller Gläubiger in Alimenteninkasso (separiert durch '';'')', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiGlaeubigerDetailliert', N'Inkasso', 1, N'DECLARE @Text VARCHAR(4000);
SET @Text = '''';

SELECT @Text = @Text +
  NameVorname
  + ISNULL('', geb. '' + CONVERT(VARCHAR, Geburtsdatum, 104), '''')
  + ISNULL(ISNULL('', von '' + Heimatort + '' '', '', '') + Nationalitaet, '''')
  + ISNULL('', '' + Wohnsitz, '''')
  + CHAR(13) + CHAR(10)
FROM dbo.vwPerson WITH (READUNCOMMITTED)
WHERE BaPersonID IN (SELECT GLB.BaPersonID
                     FROM dbo.IkGlaeubiger          GLB WITH (READUNCOMMITTED)
                       INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.IkRechtstitelID = GLB.IkRechtstitelID
                       INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
                     WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
                       AND LEI.FaProzessCode = 401 -- Alimente
                       AND LEI.BaPersonID = {BaPersonID});

IF (LEN(@Text) > 0)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 1);', N'Detaillierte Liste der Gläubiger in Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiInfoGerichtRechtstitel', N'Inkasso', 1, N'DECLARE @Text VARCHAR(500);
SET @Text = '''';

SELECT @Text = @Text + RTT.RechtstitelInfo + CHAR(13) + CHAR(10)
FROM dbo.IkRechtstitel      RTT WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
  AND LEI.FaProzessCode = 401 -- Alimente
  AND RTT.RechtstitelInfo IS NOT NULL
  AND LEI.BaPersonID = {BaPersonID}
ORDER BY LEI.DatumVon DESC;

IF (LEN(@Text) > 0)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 1);', N'Feld "Info/Gericht, Rechtstitel" in Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiKreditor', N'Inkasso', 1, N'DECLARE @Text VARCHAR(4000);
SET @Text = '''';

SELECT @Text = @Text + KRD.KreditorMehrzeilig + CHAR(13) + CHAR(10)
FROM dbo.vwKreditor            KRD WITH (READUNCOMMITTED)
  INNER JOIN dbo.IkGlaeubiger  GLB WITH (READUNCOMMITTED) ON GLB.BaZahlungswegID = KRD.BaZahlungswegID
  INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.IkRechtstitelID = GLB.IkRechtstitelID
  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
  AND LEI.FaProzessCode = 401 -- Alimente
  AND ISNULL(LEI.DatumBis, ''99990101'') >= GETDATE()
  AND KRD.KreditorMehrzeilig IS NOT NULL
  AND LEI.BaPersonID = {BaPersonID}
ORDER BY LEI.DatumVon DESC;

IF (LEN(@Text) > 0)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 1);', N'Feld "Kreditor" in Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AiZahlungsinformation', N'Inkasso', 1, N'DECLARE @Text VARCHAR(4000);
SET @Text = '''';

SELECT @Text = @Text + KRD.ZahlungswegMehrZeilig + CHAR(13) + CHAR(10)
FROM dbo.vwKreditor            KRD WITH (READUNCOMMITTED)
  INNER JOIN dbo.IkGlaeubiger  GLB WITH (READUNCOMMITTED) ON GLB.BaZahlungswegID = KRD.BaZahlungswegID
  INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.IkRechtstitelID = GLB.IkRechtstitelID
  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = RTT.FaLeistungID
WHERE ISNULL(RTT.IkRechtstitelGueltigBis, ''99990101'') >= GETDATE()
  AND LEI.FaProzessCode = 401 -- Alimente
  AND KRD.ZahlungswegMehrZeilig IS NOT NULL
  AND LEI.BaPersonID = {BaPersonID}
ORDER BY LEI.DatumVon DESC;

IF (LEN(@Text) > 0)
  SELECT SUBSTRING(@Text, 0, LEN(@Text) - 1);', N'Feld "Zahlungsinformation" in Alimenteninkasso', NULL, 4, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AllgIntegBildung', N'Allgemein', 1, N'SELECT <TableColumn>
FROM   vwTmAllgemein
WHERE  KaIntegBildungID = {KaIntegBildungID}', N'Diverse Textmarken für Allgemein Integrierte Bildung', N'vwTmAllgemein', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssExtern', N'Assessment', 1, N'SELECT AufgExtern
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssIntern', N'Assessment', 1, N'SELECT AufgIntern
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssKandDockInJa', N'Assessment', 1, N'SELECT CASE WHEN KandDokIn = 1 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0)END
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssKandDockInNein', N'Assessment', 1, N'SELECT CASE WHEN KandDokIn = 0 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0)END
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssNichtAufgen', N'Assessment', 1, N'SELECT NichtAufgFlag
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssNiveauBasis', N'Assessment', 1, N'SELECT AufgBasis
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssNiveauElementar', N'Assessment', 1, N'SELECT AufgElementar
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AssProjektGef', N'Assessment', 1, N'SELECT ProjGefaehrFlag
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Für CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisAngabenHaushalt', N'Basis', 1, N'DECLARE @GetDate DATETIME;
DECLARE @BaPersonID INT;

SET @GetDate = GETDATE();
SET @BaPersonID = {BaPersonID};

CREATE TABLE #work
(
  OrderID INT IDENTITY(1,1) PRIMARY KEY,
  BaPersonID INT,
  Beziehung VARCHAR(75)
);

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID);

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID,
         CASE
           WHEN GeschlechtCode = 1 THEN NameMale
           WHEN GeschlechtCode = 2 THEN NameFemale
           ELSE NameGeneric
         END
  FROM (SELECT BaPersonID = BaPersonID_1,
               DPR1.BaRelationID,
               NameGeneric = NameGenerisch1,
               NameMale = NameMaennlich1,
               NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2,
               DPR2.BaRelationID,
               NameGenerisch2,
               NameMaennlich2,
               NameWeiblich2
        FROM dbo.BaPerson_Relation  DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID;

SELECT
  PRS.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS2.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS3.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS2.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS3.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.InCHseit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.InCHseit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.InCHseit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  ''Antragsteller'', NEXTCELL = NULL, NEXTCELL = NULL,
  TMP2.Beziehung, NEXTCELL = NULL, NEXTCELL = NULL,
  TMP3.Beziehung
FROM vwPerson  PRS
  LEFT JOIN #work      TMP2 ON TMP2.OrderID = 2
  LEFT JOIN vwPerson   PRS2 ON PRS2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work      TMP3 ON TMP3.OrderID = 3
  LEFT JOIN vwPerson   PRS3 ON PRS3.BaPersonID = TMP3.BaPersonID
WHERE PRS.BaPersonID = @BaPersonID;

DROP TABLE #work;', N'Angaben zu allen im Haushalt lebenden Personen (1. - 3. Person)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisAngabenHaushaltErgaenzung', N'Basis', 1, N'DECLARE @GetDate DATETIME;
DECLARE @BaPersonID INT;

SET @GetDate = GETDATE()
SET @BaPersonID = {BaPersonID};

CREATE TABLE #work
(
  OrderID INT IDENTITY(1, 1) PRIMARY KEY,
  BaPersonID INT,
  Beziehung VARCHAR(75)
);

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID);

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID,
         CASE
           WHEN GeschlechtCode = 1 THEN NameMale
           WHEN GeschlechtCode = 2 THEN NameFemale
           ELSE NameGeneric
         END
  FROM (SELECT BaPersonID = BaPersonID_1,
               DPR1.BaRelationID,
               NameGeneric = NameGenerisch1,
               NameMale = NameMaennlich1,
               NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2,
               DPR2.BaRelationID,
               NameGenerisch2,
               NameMaennlich2,
               NameWeiblich2
        FROM dbo.BaPerson_Relation  DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN dbo.vwPerson   PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID
  
SELECT
  PRS.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Name, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Vorname, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.Geburtsdatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Heimatort, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS2.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Zivilstand'',PRS3.ZivilstandCode), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Nationalitaet, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS2.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVTExt(''Aufenthaltsstatus'',PRS3.AuslaenderStatusCode), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.Telefon_P, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.MobilTel, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.EMail, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.InGemeindeSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  PRS.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS2.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  PRS3.ZuzugGdeOrt, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.ImKantonSeit,104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.InCHSeit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS2.InCHSeit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS3.InCHSeit, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  TMP1.Beziehung, NEXTCELL = NULL, NEXTCELL = NULL,
  TMP2.Beziehung, NEXTCELL = NULL, NEXTCELL = NULL,
  TMP3.Beziehung
FROM #work TMP1
  LEFT JOIN dbo.vwPerson PRS  ON PRS.BaPersonID = TMP1.BaPersonID
  LEFT JOIN #work        TMP2 ON TMP2.OrderID = 5
  LEFT JOIN dbo.vwPerson PRS2 ON PRS2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work        TMP3 ON TMP3.OrderID = 6
  LEFT JOIN dbo.vwPerson PRS3 ON PRS3.BaPersonID = TMP3.BaPersonID
WHERE TMP1.OrderID = 4;

DROP TABLE #work;', N'Angaben zu allen im Haushalt lebenden Personen (4. - 6. Person)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisAngabenNichtHaushalt', N'Basis', 1, N'DECLARE @GetDate DATETIME
DECLARE @BaPersonID INT

SET @GetDate = GetDate()
SET @BaPersonID = {BaPersonID}

SELECT  
  ISNULL(PRS.NameVorname, '''') + ISNULL('', '' + PRS.WohnsitzStrasseHausNr, '''') + ISNULL('', '' + PRS.WohnsitzOrt, ''''), NEXTCELL = NULL, NEXTCELL = NULL, 
  PRS.AHVNummer, NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,PRS.Geburtsdatum, 104), NEXTCELL = NULL
FROM (SELECT BaPersonID = BaPersonID_1
        FROM dbo.BaPerson_Relation DPR1 WITH (READUNCOMMITTED)         
        WHERE BaPersonID_2 = @BaPersonID AND BaRelationID IN (1, 8, 17)
        UNION
        SELECT BaPersonID_2
        FROM dbo.BaPerson_Relation DPR2 WITH (READUNCOMMITTED)         
        WHERE BaPersonID_1 = @BaPersonID AND BaRelationID IN (1, 8, 17)
       ) TMP
  INNER JOIN vwPerson PRS ON PRS.BaPersonID = TMP.BaPersonID  
WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) <> 1', N'Angaben zu den Eltern und/oder Kinder der gesuchstellenden Personen (nicht im gleichen Haushalt)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisErwerbsituation', N'Basis', 1, N'DECLARE @GetDate DATETIME
DECLARE @BaPersonID INT

SET @GetDate = GetDate()
SET @BaPersonID = {BaPersonID}

CREATE TABLE #work (OrderID int identity(1,1) primary key, BaPersonID int, Beziehung varchar(75))

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID)

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID, CASE WHEN GeschlechtCode = 1 THEN NameMale WHEN GeschlechtCode = 2 THEN NameFemale ELSE NameGeneric END
  FROM (SELECT BaPersonID = BaPersonID_1, DPR1.BaRelationID, NameGeneric = NameGenerisch1, NameMale = NameMaennlich1, NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2, DPR2.BaRelationID, NameGenerisch2, NameMaennlich2, NameWeiblich2
        FROM dbo.BaPerson_Relation   DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation  DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID

SELECT
  dbo.fnLOVText(''Erwerbssituation'',DAA.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Erwerbssituation'',DAA2.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Erwerbssituation'',DAA3.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beschaeftigungsgrad'',DAA.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beschaeftigungsgrad'',DAA2.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beschaeftigungsgrad'',DAA3.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL,
  DAA.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL, DAA2.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL, DAA3.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Grundteilzeit'', DAA.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Grundteilzeit'',DAA2.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Grundteilzeit'',DAA3.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL,
--  dbo.fnLOVText(''Branche'', DAA.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Branche'',DAA2.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Branche'',DAA3.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beruf'', DAA.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA2.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA3.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beruf'', DAA.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA2.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA3.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL,
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DAA.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DAA2.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DAA3.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Ausbildungstyp'', DAA.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Ausbildungstyp'', DAA2.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Ausbildungstyp'', DAA3.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,DAA.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA2.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA3.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,DAA.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA2.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA3.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL
  
FROM dbo.BaArbeitAusbildung DAA WITH (READUNCOMMITTED)
  LEFT JOIN #work      		  TMP2 ON TMP2.OrderID = 2
  LEFT JOIN dbo.BaArbeitAusbildung DAA2 WITH (READUNCOMMITTED) ON DAA2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work      		  TMP3 ON TMP3.OrderID = 3
  LEFT JOIN dbo.BaArbeitAusbildung DAA3 WITH (READUNCOMMITTED) ON DAA3.BaPersonID = TMP3.BaPersonID
WHERE DAA.BaPersonID = @BaPersonID

DROP TABLE #work', N'Erwerbsituation (1. - 3. Person) im gleichen Haushalt', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisErwerbsituationErgaenzung', N'Basis', 1, N'DECLARE @GetDate DATETIME
DECLARE @BaPersonID INT

SET @GetDate = GetDate()
SET @BaPersonID = {BaPersonID}

CREATE TABLE #work (OrderID int identity(1,1) primary key, BaPersonID int, Beziehung varchar(75))

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID)

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID, CASE WHEN GeschlechtCode = 1 THEN NameMale WHEN GeschlechtCode = 2 THEN NameFemale ELSE NameGeneric END
  FROM (SELECT BaPersonID = BaPersonID_1, DPR1.BaRelationID, NameGeneric = NameGenerisch1, NameMale = NameMaennlich1, NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2, DPR2.BaRelationID, NameGenerisch2, NameMaennlich2, NameWeiblich2
        FROM dbo.BaPerson_Relation   DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation  DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID

SELECT
  dbo.fnLOVText(''Erwerbssituation'',DAA.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Erwerbssituation'',DAA2.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Erwerbssituation'',DAA3.ErwerbssituationStatus1Code), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beschaeftigungsgrad'',DAA.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beschaeftigungsgrad'',DAA2.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beschaeftigungsgrad'',DAA3.BeschaeftigungsGradCode), NEXTCELL = NULL, NEXTCELL = NULL,
  DAA.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL, DAA2.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL, DAA3.Arbeitszeit, NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Grundteilzeit'', DAA.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Grundteilzeit'',DAA2.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Grundteilzeit'',DAA3.GrundTeilzeitarbeit1Code), NEXTCELL = NULL, NEXTCELL = NULL,
--  dbo.fnLOVText(''Branche'', DAA.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Branche'',DAA2.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Branche'',DAA3.BrancheCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beruf'', DAA.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA2.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA3.ErlernterBerufCode), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Beruf'', DAA.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA2.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Beruf'',DAA3.BerufCode), NEXTCELL = NULL, NEXTCELL = NULL,
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DAA.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DAA2.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DAA3.BaInstitutionID), NEXTCELL = NULL, NEXTCELL = NULL,
  dbo.fnLOVText(''Ausbildungstyp'', DAA.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Ausbildungstyp'', DAA2.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL, dbo.fnLOVText(''Ausbildungstyp'', DAA3.HoechsteAusbildungCode), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,DAA.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA2.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA3.StempelDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL,
  CONVERT(VARCHAR,DAA.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA2.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL, CONVERT(VARCHAR,DAA3.AusgesteuertDatum, 104), NEXTCELL = NULL, NEXTCELL = NULL
  
FROM #work  TMP1
  LEFT JOIN dbo.BaArbeitAusbildung DAA  WITH (READUNCOMMITTED) ON DAA.BaPersonID = TMP1.BaPersonID 
  LEFT JOIN #work      		  TMP2 ON TMP2.OrderID = 5
  LEFT JOIN dbo.BaArbeitAusbildung DAA2 WITH (READUNCOMMITTED) ON DAA2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work      		  TMP3 ON TMP3.OrderID = 6
  LEFT JOIN dbo.BaArbeitAusbildung DAA3 WITH (READUNCOMMITTED) ON DAA3.BaPersonID = TMP3.BaPersonID
WHERE TMP1.OrderID = 4  

DROP TABLE #work', N'Erwerbsituation (4. - 6. Person) im gleichen Haushalt', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisKrankenversicherung', N'Basis', 1, N'DECLARE @GetDate DATETIME
DECLARE @BaPersonID INT

SET @GetDate = GetDate()
SET @BaPersonID = {BaPersonID}

CREATE TABLE #work (OrderID int identity(1,1) primary key, BaPersonID int, Beziehung varchar(75))

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID)

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID, CASE WHEN GeschlechtCode = 1 THEN NameMale WHEN GeschlechtCode = 2 THEN NameFemale ELSE NameGeneric END
  FROM (SELECT BaPersonID = BaPersonID_1, DPR1.BaRelationID, NameGeneric = NameGenerisch1, NameMale = NameMaennlich1, NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2, DPR2.BaRelationID, NameGenerisch2, NameMaennlich2, NameWeiblich2
        FROM dbo.BaPerson_Relation   DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation  DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID

SELECT
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DGS.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DGS2.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DGS3.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL,
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DGS.VVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DGS2.VVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DGS3.VVGOrganisationID)    
FROM dbo.BaGesundheit        DGS  WITH (READUNCOMMITTED)
  LEFT JOIN #work      	     TMP2 ON TMP2.OrderID = 2
  LEFT JOIN dbo.BaGesundheit DGS2 WITH (READUNCOMMITTED) ON DGS2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work      	     TMP3 ON TMP3.OrderID = 3
  LEFT JOIN dbo.BaGesundheit DGS3 WITH (READUNCOMMITTED) ON DGS3.BaPersonID = TMP3.BaPersonID
WHERE DGS.BaPersonID = @BaPersonID

DROP TABLE #work', N'1. - 3. Person', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BasisKrankenversicherungErgaenzung', N'Basis', 1, N'DECLARE @GetDate DATETIME
DECLARE @BaPersonID INT

SET @GetDate = GetDate()
SET @BaPersonID = {BaPersonID}

CREATE TABLE #work (OrderID int identity(1,1) primary key, BaPersonID int, Beziehung varchar(75))

INSERT INTO #work (BaPersonID) VALUES (@BaPersonID)

INSERT INTO #work (BaPersonID, Beziehung)
  SELECT TMP.BaPersonID, CASE WHEN GeschlechtCode = 1 THEN NameMale WHEN GeschlechtCode = 2 THEN NameFemale ELSE NameGeneric END
  FROM (SELECT BaPersonID = BaPersonID_1, DPR1.BaRelationID, NameGeneric = NameGenerisch1, NameMale = NameMaennlich1, NameFemale = NameWeiblich1
        FROM dbo.BaPerson_Relation  DPR1 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation DRE1 WITH (READUNCOMMITTED) ON DRE1.BaRelationID = DPR1.BaRelationID
        WHERE BaPersonID_2 = @BaPersonID
        UNION
        SELECT BaPersonID_2, DPR2.BaRelationID, NameGenerisch2, NameMaennlich2, NameWeiblich2
        FROM dbo.BaPerson_Relation   DPR2 WITH (READUNCOMMITTED)
          INNER JOIN dbo.BaRelation  DRE2 WITH (READUNCOMMITTED) ON DRE2.BaRelationID = DPR2.BaRelationID
        WHERE BaPersonID_1 = @BaPersonID
       ) TMP
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.BaRelation DRE WITH (READUNCOMMITTED) ON DRE.BaRelationID = TMP.BaRelationID
  WHERE dbo.fnGleicherHaushalt(@BaPersonID, TMP.BaPersonID, @GetDate) = 1
  ORDER BY CASE WHEN TMP.BaRelationID IN (13, 14, 15) THEN 0 ELSE 1 END, TMP.BaPersonID

SELECT
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DGS.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DGS2.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DGS3.KVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL,
  (SELECT ORG1.Name FROM dbo.BaInstitution ORG1 WITH (READUNCOMMITTED) WHERE ORG1.BaInstitutionID = DGS.VVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG2.Name FROM dbo.BaInstitution ORG2 WITH (READUNCOMMITTED) WHERE ORG2.BaInstitutionID = DGS2.VVGOrganisationID), NEXTCELL = NULL, NEXTCELL = NULL, 
  (SELECT ORG3.Name FROM dbo.BaInstitution ORG3 WITH (READUNCOMMITTED) WHERE ORG3.BaInstitutionID = DGS3.VVGOrganisationID)    
FROM #work  TMP1
  LEFT JOIN dbo.BaGesundheit DGS  WITH (READUNCOMMITTED) ON DGS.BaPersonID = TMP1.BaPersonID
  LEFT JOIN #work      	     TMP2 ON TMP2.OrderID = 5
  LEFT JOIN dbo.BaGesundheit DGS2 WITH (READUNCOMMITTED) ON DGS2.BaPersonID = TMP2.BaPersonID
  LEFT JOIN #work      	     TMP3 ON TMP3.OrderID = 6
  LEFT JOIN dbo.BaGesundheit DGS3 WITH (READUNCOMMITTED) ON DGS3.BaPersonID = TMP3.BaPersonID
WHERE TMP1.OrderID = 4

DROP TABLE #work', N'4. - 6. Person', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Benutzer', N'angemeldete/r Benutzer/in', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmUser
WHERE  UserID = {UserId}', N'Diverse Textmarken für den angemeldeten Benutzer', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerAbteilungText1', N'angemeldete/r Benutzer/in', 3, N'select top 1 ORG.Text1
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {UserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerAbteilungText2', N'angemeldete/r Benutzer/in', 3, N'select top 1 ORG.Text2
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {UserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerAbteilungText3', N'angemeldete/r Benutzer/in', 3, N'select top 1 ORG.Text3
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {UserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerAbteilungText4', N'angemeldete/r Benutzer/in', 3, N'select top 1 ORG.Text4
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {UserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerText1', N'angemeldete/r Benutzer/in', 3, N'select Text1
from   XUser
where  UserId = {UserId}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BenutzerText2', N'angemeldete/r Benutzer/in', 3, N'select Text2
from   XUser
where  UserId = {UserId}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Betrieb', N'KA Betrieb', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmKaBetrieb
WHERE  KaBetriebDokumentID = {KaBetriebDokumentID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske->Dokumente" verwendet werden!', N'vwTmKaBetrieb', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebAllgemein', N'KA Betrieb', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmKaBetrieb
WHERE  KaBetriebID = {KaBetriebID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!', N'vwTmKaBetrieb', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebAllgemeinBemerkung', N'KA Betrieb', 3, N'SELECT TOP 1 BET.Bemerkung
FROM   dbo.KaBetrieb BET  WITH (READUNCOMMITTED)
WHERE  KaBetriebID = {KaBetriebID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebAllgemeinEinsatzplatzTabelle', N'KA Betrieb', 1, N'SELECT 
  Bezeichnung,
  NextCell      = null,
  CASE WHEN Aktiv = 1 THEN ''Ja'' ELSE ''Nein'' END,
  NextCell      = null,
  KaProgramm = dbo.fnLOVText(''KaVermittlungProgramm'', KaProgrammCode),
  NextCell      = null,
  GesamtPensum,
  NextCell      = null
FROM dbo.KaEinsatzplatz WITH (READUNCOMMITTED)
WHERE KaBetriebID = {KaBetriebID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!
Ist eine Tabelle mit den Einsatzplätzen (Bezeichnung, Aktiv, KA-Programm, Pensum)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebAllgemeinKontaktTabelle', N'KA Betrieb', 1, N'SELECT 
  KON.Name,
  NextCell      = null,
  KON.Vorname,
  NextCell      = null,
  KON.Funktion,
  NextCell      = null,
  KON.Telefon,
  NextCell      = null,
  KON.TelefonMobil,
  NextCell      = null,
  KON.Fax,
  NextCell      = null,
  KON.EMail,
  NextCell      = null
FROM dbo.KaBetriebKontakt KON WITH (READUNCOMMITTED)
WHERE KON.KaBetriebID = {KaBetriebID}
AND KON.Aktiv = 1', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!
Ist eine Tabelle mit den aktiven Kontakten (Name, Vorname, Funktion, Telefon, Telefon Mobil, Fax, EMail)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebGesamterVerlauf', N'KA Betrieb', 1, N'SELECT
  Datum         = ''Datum: '' + convert(varchar, BES.Datum),
  Text1         = char(13) + char(10) + char(13) + char(10),
  Kontaktperson = ''Kontaktperson: '' + BEK.Name + IsNull('', '' + BEK.Vorname, ''''),
  Text2         = char(13) + char(10) + char(13) + char(10),
  Autor         = ''Autor: '' + USR.LastName + IsNull('', '' + USR.FirstName, ''''),
  Text3         = char(13) + char(10) + char(13) + char(10),
  Stichwort     = ''Stichwort: '' + BES.Stichwort,
  Text4         = char(13) + char(10) + char(13) + char(10),
  InhaltRTF     = BES.Inhalt,
  Text5         = char(13) + char(10) + char(13) + char(10)
FROM dbo.KaBetriebBesprechung     BES WITH (READUNCOMMITTED)
   LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = BES.AutorID
   LEFT JOIN dbo.KaBetriebKontakt BEK WITH (READUNCOMMITTED) ON BEK.KaBetriebKontaktID = BES.KontaktPersonID
WHERE BES.KaBetriebID = {KaBetriebID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!
Verlauf (Datum, Kontaktperson, Autor, Stichwort, Inhalt)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebVerlauf', N'KA Betrieb', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmKaBetriebVerlauf
WHERE  KaBetriebBesprechungID = {KaBetriebBesprechungID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske->Verlauf" verwendet werden!', N'vwTmKaBetriebVerlauf', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebVerlaufInhalt', N'KA Betrieb', 3, N'SELECT TOP 1 BES.Inhalt
FROM dbo.KaBetriebBesprechung BES WITH (READUNCOMMITTED)
WHERE  KaBetriebBesprechungID = {KaBetriebBesprechungID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske->Verlauf" verwendet werden!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BetriebVerlaufTabelle', N'KA Betrieb', 1, N'SELECT 
  BES.Datum,
  NextCell      = null,
  Kontaktperson = BEK.Name + IsNull('', '' + BEK.Vorname, ''''),
  NextCell      = null,
  Autor         = USR.LastName + IsNull('', '' + USR.FirstName, ''''),
  NextCell      = null,
  BES.Stichwort,
  NextCell      = null,
  InhaltRTF     = BES.Inhalt,
  NextCell      = null
FROM dbo.KaBetriebBesprechung     BES WITH (READUNCOMMITTED)
   LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = BES.AutorID
   LEFT JOIN dbo.KaBetriebKontakt BEK WITH (READUNCOMMITTED) ON BEK.KaBetriebKontaktID = BES.KontaktPersonID
WHERE BES.KaBetriebID = {KaBetriebID}', N'Kann nur in "KA Einsatzorte -> Betriebemaske" verwendet werden!
Ist eine Tabelle mit dem Verlauf (Datum, Kontaktperson, Autor, Stichwort, Inhalt)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeute', N'Andere', 1, N'select convert(varchar,getdate(),104)', N'Format 06.04.2004', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeute2', N'Andere', 1, N'select convert(varchar,day(getdate())) + ''. '' +
       dbo.fnXMonat(month(getdate())) + '' '' +
       convert(varchar,year(getdate()))', N'Format 6. Dezember 2004', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Ein', N'Vermittlung', 1, N'SELECT <TableColumn>
FROM   vwTmVermittlungEinsatz
WHERE  KaVermittlungVorschlagID = {KaVermittlungVorschlagId}', N'Div. Textmarken für Vermittlung Einsatz (QJ, BI, BIP, SI)
Nur verwendbar in den Masken Einsätze/Stellen!', N'vwTmVermittlungEinsatz', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Einsatzplatz', N'KA Einsatzplatz', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmKaEinsatzplatz
WHERE  KaEinsatzplatzID = {KaEinsatzplatzID}', N'Kann nur in "KA Einsatzorte -> Einsatzplätze" verwendet werden!', N'vwTmKaEinsatzplatz', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAktennotizen', N'Fallführung', 1, N'SELECT <TableColumn>
FROM dbo.vwTmFaAktennotizen
WHERE FaAktennotizID = {FaAktennotizID}', N'Diverse Textmarken für Aktennotizen', N'vwTmFaAktennotizen', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAnlassproblemeLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAnlassprobleme'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessArbeitLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessArbeit'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessArbeitLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessArbeit'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessBezhngLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessBezhng'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessBezhngLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessBezhng'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessFinLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessFin'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessFinLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessFin'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessGesLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessGes'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessGesLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessGes'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessHaeuslGLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessHaeuslG'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessHaeuslGLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessHaeuslG'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessKindswLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessKindsw'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessKindswLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessKindsw'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessRechtlAbklLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessRechtlAbkl'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessRechtlAbklLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessRechtlAbkl'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessRueckkLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessRueckk'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessRueckkLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessRueckk'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessVerhLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessVerh'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessVerhLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessVerh'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessWohnenLetztePhase', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 2
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaAusstattungRessWohnen'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaAusstattungRessWohnenLetztesIntake', N'Fallführung', 1, N'select Top 1 VAL.Value
FROM FaLeistung       LST
  INNER JOIN FaPhase  PHA ON PHA.FaLeistungID = LST.FaLeistungID AND
                                   PHA.FaPhaseCode = 1
       left  join DynaValue VAL on VAL.FaPhaseID = PHA.FaPhaseID and
                                   VAL.DynaFieldID = (select DynaFieldID
                                                      from   DynaField
                                                      where  FieldName = ''FaIntAusstattungRessWohnen'')
where  LST.BaPersonID = {BaPersonID} and
       LST.ModulID = 2
order by PHA.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichDatumBis', N'Fachbereich', 1, N'SELECT Convert(Varchar, ZuteilungBis, 104)
FROM KaZuteilFachbereich
WHERE KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichDatumBisAktuell', N'Fachbereich', 1, N'SELECT Convert(Varchar, MAX(ZuteilungBis), 104)
FROM KaZuteilFachbereich
WHERE BaPersonID = {BaPersonID}', N'Aktuellster Eintrag ''Datum bis'' in Zuteilung Fachbereich', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichDatumVon', N'Fachbereich', 1, N'SELECT Convert(Varchar, ZuteilungVon, 104)
FROM KaZuteilFachbereich
WHERE KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichDatumVonAktuell', N'Fachbereich', 1, N'SELECT Convert(Varchar, MAX(ZuteilungVon), 104)
FROM KaZuteilFachbereich
WHERE BaPersonID = {BaPersonID}', N'Aktuellster Eintrag ''Datum von'' in Zuteilung Fachbereich', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachbereich', N'Fachbereich', 1, N'SELECT dbo.fnLOVText(''KAFachbereich'', ZFB.FachbereichID)
FROM KaZuteilFachbereich ZFB
WHERE ZFB.KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachbereichAktuell', N'Fachbereich', 1, N'SELECT dbo.fnLOVText(''KAFachbereich'', ZFB.FachbereichID)
FROM KaZuteilFachbereich ZFB	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterIn', N'Fachbereich', 1, N'SELECT XUR.LastName + isNull('' '' + XUR.FirstName,'''')
FROM KaZuteilFachbereich ZFB
  LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID
WHERE ZFB.KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterInAktuell', N'Fachbereich', 1, N'SELECT XUR.LastName + isNull('' '' + XUR.FirstName,'''')
FROM KaZuteilFachbereich ZFB
   LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterInTel', N'Fachbereich', 1, N'SELECT XUR.Phone
FROM KaZuteilFachbereich ZFB
  LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID
WHERE ZFB.KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterInTelAktuell', N'Fachbereich', 1, N'SELECT XUR.Phone
FROM KaZuteilFachbereich ZFB
   LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterInVorNamAktuell', N'Fachbereich', 1, N'SELECT XUR.FirstName + isNull('' '' + XUR.LastName,'''')
FROM KaZuteilFachbereich ZFB
   LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichFachleiterInVorName', N'Fachbereich', 1, N'SELECT XUR.FirstName + isNull('' '' + XUR.LastName,'''')
FROM KaZuteilFachbereich ZFB
  LEFT JOIN XUser XUR	on XUR.UserID = ZFB.FachleitungID
WHERE ZFB.KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichMaxDatum', N'Fachbereich', 1, N'SELECT Convert(Varchar, MAX(ZuteilungBis), 104)
FROM KaZuteilFachbereich
WHERE BaPersonID = {BaPersonID}
AND ZuteilungBis >= (SELECT min(FAL.DatumVon)
         FROM FaLeistung FAL
         WHERE FAL.DatumBis is NULL
         AND ModulID = 7
         AND (FaProzessCode > 700 OR FaProzessCode is NULL))', N'Aktuellstes ''Datum bis'' innerhalb der offenen Phase.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichMinDatum', N'Fachbereich', 1, N'SELECT Convert(Varchar, MIN(ZuteilungVon), 104)
FROM KaZuteilFachbereich
WHERE BaPersonID = {BaPersonID}
AND ZuteilungBis >= (SELECT min(FAL.DatumVon)
         FROM FaLeistung FAL
         WHERE FAL.DatumBis is NULL
         AND ModulID = 7
         AND (FaProzessCode > 700 OR FaProzessCode is NULL))', N'Ältestes ''Datum von'' innerhalb der offenen Phase.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichNiveau', N'Fachbereich', 1, N'SELECT dbo.fnLOVText(''KaQjNiveau'', NiveauCode)
FROM KaZuteilFachbereich
WHERE KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichNiveauAktuell', N'Fachbereich', 1, N'SELECT dbo.fnLOVText(''KaQjNiveau'', ZFB.NiveauCode)
FROM KaZuteilFachbereich ZFB	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichZustaendigKA', N'Fachbereich', 1, N'SELECT XUR.LastName + isNull('' '' + XUR.FirstName,'''')
FROM KaZuteilFachbereich ZFB
  LEFT JOIN XUser XUR	on XUR.UserID = ZFB.ZustaendigKaID
WHERE ZFB.KaZuteilFachbereichID = {KaZuteilFachbereichID}', N'Eintrag von aktuell selektierter Zeile in Tabelle. Nur in ZuteilungFachbereich!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FachbereichZustaendigKAAktuell', N'Fachbereich', 1, N'SELECT XUR.LastName + isNull('' '' + XUR.FirstName,'''')
FROM KaZuteilFachbereich ZFB
   LEFT JOIN XUser XUR	on XUR.UserID = ZFB.ZustaendigKaID	
WHERE ZFB.BaPersonID = {BaPersonID}
AND ZFB.ZuteilungVon = (SELECT MAX(KAZ.ZuteilungVon)
        FROM KaZuteilFachbereich KAZ
        WHERE KAZ.BaPersonID = ZFB.BaPersonID)', N'Aktuellster Eintrag in Zuteilung Fachbereich.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaDokBesprAlle', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = ''Datum: '' + CONVERT(VARCHAR(10), AKT.Datum, 104) + ''  '',
  Kontaktpartner = ''Kontaktpartner: '' + AKT.Kontaktpartner,
  Text1	= char(13) + char(10) + char(13) + char(10),
  AKT.InhaltRTF,
  Text2	= char(13) + char(10) + char(13) + char(10),
  GridRowID = AKT.FaAktennotizID
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', N'Alle Besprechungen der aktuellen Maske
Kolonnen: Datum, Kontaktpartner, Inhalt', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaDokBesprAlleBSS', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = ''Datum: '' + CONVERT(VARCHAR(10), AKT.Datum, 104) + ''  '',
  Kontaktpartner = ''Kontaktpartner: '' + AKT.Kontaktpartner,
  Text1	= char(13) + char(10) + char(13) + char(10),
  AKT.InhaltRTF,
  Text2	= char(13) + char(10) + char(13) + char(10)
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', N'Spezielle Textmarke für BSS!
Alle Besprechungen der aktuellen Maske
Kolonnen: Datum, Kontaktpartner, Inhalt', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaDokBesprAlleTabelle', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = CONVERT(VARCHAR(10), AKT.Datum, 104),
  NextCell = NULL,
  Kontaktpartner = AKT.Kontaktpartner,
  NextCell = NULL,
  AKT.InhaltRTF,
  NextCell = NULL
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaDokBesprAlleTabelleBSS', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = CONVERT(VARCHAR(10), AKT.Datum, 104),
  NextCell = NULL,
  Kontaktpartner = AKT.Kontaktpartner,
  NextCell = NULL,
  AKT.Stichwort,
  NextCell = NULL,
  AKT.InhaltRTF,
  NextCell = NULL
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', N'Spezielle Textmarke für BSS!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaDokumente', N'Fallführung', 1, N'SELECT <TableColumn>
FROM dbo.vwTmFaDokumente
WHERE FaDokumenteID = {FaDokumenteID}', N'Diverse Textmarken für Dokumente', N'vwTmFaDokumente', 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaInvolvierteStellenWOH', N'Fallführung', 1, N'begin

declare @Involviert1FldID    int, @Involviert2FldID    int, @Involviert3FldID    int
declare @InvolviertMit1FldID int, @InvolviertMit2FldID int, @InvolviertMit3FldID int

declare @Involviert1    varchar(200), @Involviert2    varchar(200), @Involviert3    varchar(200)
declare @InvolviertMit1 varchar(200), @InvolviertMit2 varchar(200), @InvolviertMit3 varchar(200)

select top 1 @Involviert1FldID    = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvol1''
select top 1 @Involviert2FldID    = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvol2''
select top 1 @Involviert3FldID    = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvol3''
select top 1 @InvolviertMit1FldID = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvolMit1''
select top 1 @InvolviertMit2FldID = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvolMit2''
select top 1 @InvolviertMit3FldID = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaBeratungsplanInvolMit3''

select @Involviert1FldID,@Involviert2FldID,@Involviert3FldID,@InvolviertMit1FldID,@InvolviertMit2FldID,@InvolviertMit3FldID

set @Involviert1 = (select top 1 dbo.fnLOVText(''FaInvolvierteStelle'',convert(int,Value))
                    from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @Involviert1FldID and GridRowID = 1)
set @Involviert2 = (select top 1 dbo.fnLOVText(''FaInvolvierteStelle'',convert(int,Value))
                    from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @Involviert2FldID and GridRowID = 1)
set @Involviert3 = (select top 1 dbo.fnLOVText(''FaInvolvierteStelle'',convert(int,Value))
                    from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @Involviert3FldID and GridRowID = 1)

set @InvolviertMit1 = (select top 1 convert(varchar(200),Value)
                       from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @InvolviertMit1FldID and GridRowID = 1)
set @InvolviertMit2 = (select top 1 convert(varchar(200),Value)
                       from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @InvolviertMit2FldID and GridRowID = 1)
set @InvolviertMit3 = (select top 1 convert(varchar(200),Value)
                       from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @InvolviertMit3FldID and GridRowID = 1)

declare @Text varchar(2000)

set @Text = ''''

if @InvolviertMit1 is not null  set @Text = @Text + isnull(@Involviert1 + '' mit '','''') + @InvolviertMit1 + char(13) + char(10)
if @InvolviertMit2 is not null  set @Text = @Text + isnull(@Involviert2 + '' mit '','''') + @InvolviertMit2 + char(13) + char(10)
if @InvolviertMit3 is not null  set @Text = @Text + isnull(@Involviert3 + '' mit '','''') + @InvolviertMit3 + char(13) + char(10)

select @Text

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaOffeneAbmachungenTabelleWOH', N'Fallführung', 1, N'begin

declare @Abmachungen table
(
  GridRowID      int,
  Datum          sql_variant,
  PerDatum       sql_variant,
  Stichwort      sql_variant,
  Erledigt       sql_variant,
  Personen       sql_variant,
  PersonenListe  varchar(4000)
)

declare @DatumFldID int
declare @PerDatumFldID int
declare @StichwortFldID int
declare @ErledigtFldID int
declare @PersonenFldID int

select top 1 @DatumFldID     = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaDokAbmDatum''
select top 1 @PerDatumFldID  = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaDokAbmPerDatum''
select top 1 @StichwortFldID = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaDokAbmStichwort''
select top 1 @ErledigtFldID  = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaDokAbmErledi''
select top 1 @PersonenFldID  = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaDokAbmBetPers''

insert @Abmachungen (GridRowID)
select distinct GridRowID
from   dbo.DynaValue V WITH (READUNCOMMITTED)
       inner join dbo.DynaField F WITH (READUNCOMMITTED) on F.DynaFieldID = V.DynaFieldID
where  V.FaLeistungID = {FaLeistungID} and
       F.Maskname = ''Fa_Dok_Abmachungen''
order by GridRowID

update @Abmachungen
set    Datum     = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaLeistungID = {FaLeistungID} and DynaFieldID = @DatumFldID and GridRowID = ABM.GridRowID),
       PerDatum  = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaLeistungID = {FaLeistungID} and DynaFieldID = @PerDatumFldID and GridRowID = ABM.GridRowID),
       Stichwort = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaLeistungID = {FaLeistungID} and DynaFieldID = @StichwortFldID and GridRowID = ABM.GridRowID),
       Erledigt  = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaLeistungID = {FaLeistungID} and DynaFieldID = @ErledigtFldID and GridRowID = ABM.GridRowID),
       Personen  = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaLeistungID = {FaLeistungID} and DynaFieldID = @PersonenFldID and GridRowID = ABM.GridRowID)
from   @Abmachungen ABM

delete @Abmachungen
where  convert(bit,Erledigt) = 1

declare @GridRowID int
declare @Personen  varchar(2000)
declare @Person    varchar(10)
declare @Text      varchar(100)
declare @Liste     varchar(1000)
declare @Idx       int

declare c cursor for
select GridRowID, convert(varchar(2000),Personen)
from @Abmachungen
where Personen is not null

open c
fetch c into @GridRowID, @Personen
while @@fetch_status = 0
begin

  SET @Liste = ''''
  SET @Idx = 1
  WHILE @Idx <= LEN(@Personen) BEGIN
    -- nicht numerische Zeichen überspringen
    WHILE @Idx <= LEN(@Personen) AND NOT SUBSTRING(@Personen,@Idx,1) BETWEEN ''0'' AND ''9'' BEGIN
      SET @Idx = @Idx + 1
    END

    -- Code aufbauen
    SET @Person = ''''
    WHILE @Idx <= LEN(@Personen) AND SUBSTRING(@Personen,@Idx,1) BETWEEN ''0'' AND ''9'' BEGIN
      SET @Person = @Person + SUBSTRING(@Personen,@Idx,1)
      SET @Idx = @Idx + 1
    END

    IF @Person <> '''' BEGIN
      SELECT @Text = isNull(VornameName,'''') FROM vwPerson WHERE BaPersonID = CONVERT(int,@Person)
      IF @Text is not null BEGIN
        IF @Liste <> '''' SET @Liste = @Liste + '',''
        SET @Liste = @Liste + @Text
      END
    END
  END

  UPDATE @Abmachungen
  SET    PersonenListe = @Liste
  WHERE  GridRowID = @GridRowID

  fetch c into @GridRowID, @Personen
end
close c
deallocate c

select NextCell = null,
       convert(varchar, Datum, 104),
       NextCell = null,
       convert(varchar, PerDatum, 104),
       NextCell = null,
       convert(varchar(200), Stichwort),
       NextCell = null,
       convert(varchar(4000), PersonenListe),
       NextCell = null
from   @Abmachungen

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaPhaseDatumBis', N'Fallführung', 1, N'SELECT CONVERT(VARCHAR, DatumBis, 104)
FROM   dbo.FaPhase WITH (READUNCOMMITTED)
WHERE  FaPhaseID = {FaPhaseID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaPhaseDatumVon', N'Fallführung', 1, N'SELECT CONVERT(VARCHAR, DatumVon, 104)
FROM   dbo.FaPhase WITH (READUNCOMMITTED)
WHERE  FaPhaseID = {FaPhaseID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungen', N'Fallführung', 1, N'begin

create table #Ziele
(
  GridRowID      int,
  Ziel           sql_variant,
  Thema          sql_variant,
  Kriterium      sql_variant,
  LeistungDritte sql_variant,
  LeistungKlient sql_variant,
  Dienstleistung varchar(4000)
)

declare @ZielFldID int
declare @ThemaFldID int
declare @KriteriumFldID int
declare @LeistungDritteFldID int
declare @LeistungKlientFldID int

declare @DienstlFinanzFldID int
declare @DienstlArbeitFldID int
declare @DienstlUkftFldID int
declare @DienstlVernetzFldID int
declare @DienstlBeratFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielZiel''
select top 1 @ThemaFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielThema''
select top 1 @KriteriumFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielKritIndi''
select top 1 @LeistungDritteFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielLeistDritte''
select top 1 @LeistungKlientFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielLeistKlient''

select top 1 @DienstlFinanzFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslFinHilf''
select top 1 @DienstlArbeitFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslArbeit''
select top 1 @DienstlUkftFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslUnterkunf''
select top 1 @DienstlVernetzFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslVernetz''
select top 1 @DienstlBeratFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslBerat''


insert #Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Beratung_Zielvereinbarungen''
order by GridRowID

update #Ziele
set    Ziel =           (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Thema =          (select top 1 LOV.Text
                         from   DynaValue VAL
                                inner join XLOVCode LOV on LOV.LOVName = ''FaThema'' and LOV.Code = VAL.Value
                         where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ThemaFldID and VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @KriteriumFldID and GridRowID = ZIE.GridRowID),
       LeistungDritte = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungDritteFldID and GridRowID = ZIE.GridRowID),
       LeistungKlient = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungKlientFldID and GridRowID = ZIE.GridRowID)
from   #Ziele ZIE

declare @GridRowID int
declare @DienstlFinanz  varchar(2000)
declare @DienstlArbeit  varchar(2000)
declare @DienstlUkft    varchar(2000)
declare @DienstlVernetz varchar(2000)
declare @DienstlBerat   varchar(2000)
declare @D              varchar(4000)

declare cDienstl cursor for
select GridRowID from #Ziele

open cDienstl
fetch cDienstl into @GridRowID
while @@fetch_status = 0
begin
  set @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlFinanzFldID and GridRowID = @GridRowID))
  set @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlArbeitFldID and GridRowID = @GridRowID))
  set @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlUkftFldID and GridRowID = @GridRowID))
  set @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlVernetzFldID and GridRowID = @GridRowID))
  set @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlBeratFldID and GridRowID = @GridRowID))

  set @D = @DienstlFinanz

  if Len(@DienstlArbeit) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlArbeit
  end

  if Len(@DienstlUkft) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D  + @DienstlUkft
  end

  if Len(@DienstlVernetz) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlVernetz
  end

  if Len(@DienstlBerat) > 0  begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlBerat
  end

  update #Ziele
  set    Dienstleistung = @D
  where  GridRowID = @GridRowID

  fetch cDienstl into @GridRowID
end
close cDienstl
deallocate cDienstl

select Style = ''KissZiel'',
       Ziel,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Thema,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Kriterium,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NewParagraph = null,
       NewParagraph = null

from   #Ziele

drop table #ziele
end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenErreichGrad', N'Fallführung', 1, N'begin

declare @Ziele table
(
  GridRowID       int,
  Ziel            sql_variant,
  Erreichungsgrad sql_variant
)

declare @ZielFldID int
declare @ErreichungsgradFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielZiel''
select top 1 @ErreichungsgradFldID = DynaFieldID from DynaField where  FieldName = ''FaAuswertungZielGrad''

insert @Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Beratung_Zielvereinbarungen''
order by GridRowID

update @Ziele
set    Ziel            = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Erreichungsgrad = (select top 1 LOV.Text
                          from   DynaValue VAL
                                 inner join XLOVCode LOV on LOV.LOVName = ''FaZielErreichungsgrad'' and LOV.Code = VAL.Value
                          where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ErreichungsgradFldID and VAL.GridRowID = ZIE.GridRowID)
from   @Ziele ZIE

select ''Ziel: '' + isNull(convert(varchar(1000),Ziel),''''),
       NewParagraph = null,
       ''Erreichungsgrad:'' + isNull(convert(varchar(100),Erreichungsgrad),''''),
       NewParagraph = null,
       NewParagraph = null
from   @Ziele

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenErreichGradTabelle', N'Fallführung', 1, N'begin

declare @Ziele table
(
  GridRowID       int,
  Ziel            sql_variant,
  Erreichungsgrad sql_variant
)

declare @ZielFldID int
declare @ErreichungsgradFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielZiel''
select top 1 @ErreichungsgradFldID = DynaFieldID from DynaField where  FieldName = ''FaAuswertungZielGrad''

insert @Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Beratung_Zielvereinbarungen''
order by GridRowID

update @Ziele
set    Ziel            = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Erreichungsgrad = (select top 1 LOV.Text
                          from   DynaValue VAL
                                 inner join XLOVCode LOV on LOV.LOVName = ''FaZielErreichungsgrad'' and LOV.Code = VAL.Value
                          where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ErreichungsgradFldID and VAL.GridRowID = ZIE.GridRowID)
from   @Ziele ZIE

select Ziel,
       NextCell = null,
       Erreichungsgrad,
       NextCell = null
from   @Ziele

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenTabelle', N'Fallführung', 1, N'begin

create table #Ziele
(
  GridRowID      int,
  Ziel           sql_variant,
  Thema          sql_variant,
  Kriterium      sql_variant,
  LeistungDritte sql_variant,
  LeistungKlient sql_variant,
  Dienstleistung varchar(4000)
)

declare @ZielFldID int
declare @ThemaFldID int
declare @KriteriumFldID int
declare @LeistungDritteFldID int
declare @LeistungKlientFldID int

declare @DienstlFinanzFldID int
declare @DienstlArbeitFldID int
declare @DienstlUkftFldID int
declare @DienstlVernetzFldID int
declare @DienstlBeratFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielZiel''
select top 1 @ThemaFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielThema''
select top 1 @KriteriumFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielKritIndi''
select top 1 @LeistungDritteFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielLeistDritte''
select top 1 @LeistungKlientFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinZielLeistKlient''

select top 1 @DienstlFinanzFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslFinHilf''
select top 1 @DienstlArbeitFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslArbeit''
select top 1 @DienstlUkftFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslUnterkunf''
select top 1 @DienstlVernetzFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslVernetz''
select top 1 @DienstlBeratFldID = DynaFieldID from DynaField where  FieldName = ''FaZielvereinDienslBerat''


insert #Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Beratung_Zielvereinbarungen''
order by GridRowID

update #Ziele
set    Ziel =           (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Thema =          (select top 1 LOV.Text
                         from   DynaValue VAL
                                inner join XLOVCode LOV on LOV.LOVName = ''FaThema'' and LOV.Code = VAL.Value
                         where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ThemaFldID and VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @KriteriumFldID and GridRowID = ZIE.GridRowID),
       LeistungDritte = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungDritteFldID and GridRowID = ZIE.GridRowID),
       LeistungKlient = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungKlientFldID and GridRowID = ZIE.GridRowID)
from   #Ziele ZIE

declare @GridRowID int
declare @DienstlFinanz  varchar(2000)
declare @DienstlArbeit  varchar(2000)
declare @DienstlUkft    varchar(2000)
declare @DienstlVernetz varchar(2000)
declare @DienstlBerat   varchar(2000)
declare @D              varchar(4000)

declare cDienstl cursor for
select GridRowID from #Ziele

open cDienstl
fetch cDienstl into @GridRowID
while @@fetch_status = 0
begin
  set @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlFinanzFldID and GridRowID = @GridRowID))
  set @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlArbeitFldID and GridRowID = @GridRowID))
  set @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlUkftFldID and GridRowID = @GridRowID))
  set @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlVernetzFldID and GridRowID = @GridRowID))
  set @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlBeratFldID and GridRowID = @GridRowID))

  set @D = @DienstlFinanz

  if Len(@DienstlArbeit) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlArbeit
  end

  if Len(@DienstlUkft) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D  + @DienstlUkft
  end

  if Len(@DienstlVernetz) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlVernetz
  end

  if Len(@DienstlBerat) > 0  begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlBerat
  end

  update #Ziele
  set    Dienstleistung = @D
  where  GridRowID = @GridRowID

  fetch cDienstl into @GridRowID
end
close cDienstl
deallocate cDienstl

select Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = null,

       Style = ''KissZiel'',
       Ziel,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = null,

       Style = ''KissMemo'',
       Thema,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = null,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen SD:'',
       NextCell = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null

from   #Ziele

drop table #ziele
end', N'Zielvereinbarungen in Tabellenform
', NULL, NULL, 0, 1)
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenTabelleAllg', N'Fallführung', 1, N'BEGIN

CREATE TABLE #Ziele
(
  GridRowID      INT,
  Ziel           SQL_VARIANT,
  Thema          SQL_VARIANT,
  Kriterium      SQL_VARIANT,
  LeistungDritte SQL_VARIANT,
  LeistungKlient SQL_VARIANT,
  Dienstleistung VARCHAR(4000)
)

DECLARE @ZielFldID INT
DECLARE @ThemaFldID INT
DECLARE @KriteriumFldID INT
DECLARE @LeistungDritteFldID INT
DECLARE @LeistungKlientFldID INT

DECLARE @DienstlFinanzFldID INT
DECLARE @DienstlArbeitFldID INT
DECLARE @DienstlUkftFldID INT
DECLARE @DienstlVernetzFldID INT
DECLARE @DienstlBeratFldID INT

DECLARE @FaPhaseID INT

SELECT TOP 1 @FaPhaseID = PHA.FaPhaseID
FROM   dbo.FaPhase PHA WITH (READUNCOMMITTED)
WHERE  PHA.FaLeistungID =
        (SELECT TOP 1 LEI.FaLeistungID
         FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
         WHERE LEI.BaPersonID = {BaPersonID}
         AND   LEI.ModulID = 2
         ORDER BY DatumVon DESC)
AND    PHA.FaPhaseCode = 2 -- Beratungsphase
ORDER BY PHA.DatumVon DESC

SELECT TOP 1 @ZielFldID           = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinZielZiel''
SELECT TOP 1 @ThemaFldID          = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinZielThema''
SELECT TOP 1 @KriteriumFldID      = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinZielKritIndi''
SELECT TOP 1 @LeistungDritteFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinZielLeistDritte''
SELECT TOP 1 @LeistungKlientFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinZielLeistKlient''

SELECT TOP 1 @DienstlFinanzFldID  = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinDienslFinHilf''
SELECT TOP 1 @DienstlArbeitFldID  = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinDienslArbeit''
SELECT TOP 1 @DienstlUkftFldID    = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinDienslUnterkunf''
SELECT TOP 1 @DienstlVernetzFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinDienslVernetz''
SELECT TOP 1 @DienstlBeratFldID   = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaZielvereinDienslBerat''


INSERT #Ziele (GridRowID)
SELECT DISTINCT GridRowID
FROM   dbo.DynaValue V WITH (READUNCOMMITTED)
   INNER JOIN dbo.DynaField F WITH (READUNCOMMITTED) ON F.DynaFieldID = V.DynaFieldID
WHERE  V.FaPhaseID = @FaPhaseID
AND    F.Maskname = ''Fa_Beratung_Zielvereinbarungen''
ORDER BY GridRowID

UPDATE #Ziele
SET    Ziel =           (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @ZielFldID AND GridRowID = ZIE.GridRowID),
       Thema =          (SELECT TOP 1 LOV.Text
                         FROM   dbo.DynaValue VAL WITH (READUNCOMMITTED)
                                INNER JOIN XLOVCode LOV ON LOV.LOVName = ''FaThema'' AND LOV.Code = VAL.Value
                         WHERE  VAL.FaPhaseID = @FaPhaseID AND VAL.DynaFieldID = @ThemaFldID AND VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @KriteriumFldID AND GridRowID = ZIE.GridRowID),
       LeistungDritte = (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @LeistungDritteFldID AND GridRowID = ZIE.GridRowID),
       LeistungKlient = (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @LeistungKlientFldID AND GridRowID = ZIE.GridRowID)
FROM   #Ziele ZIE

DECLARE @GridRowID int
DECLARE @DienstlFinanz  VARCHAR(2000)
DECLARE @DienstlArbeit  VARCHAR(2000)
DECLARE @DienstlUkft    VARCHAR(2000)
DECLARE @DienstlVernetz VARCHAR(2000)
DECLARE @DienstlBerat   VARCHAR(2000)
DECLARE @D              VARCHAR(4000)

DECLARE cDienstl CURSOR FOR
SELECT GridRowID FROM #Ziele

OPEN cDienstl
FETCH cDienstl INTO @GridRowID
WHILE @@fetch_status = 0
BEGIN
  SET @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlFinanzFldID AND GridRowID = @GridRowID))
  SET @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlArbeitFldID AND GridRowID = @GridRowID))
  SET @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlUkftFldID AND GridRowID = @GridRowID))
  SET @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlVernetzFldID AND GridRowID = @GridRowID))
  SET @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlBeratFldID AND GridRowID = @GridRowID))

  SET @D = @DienstlFinanz

  IF Len(@DienstlArbeit) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlArbeit
  END

  IF Len(@DienstlUkft) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D  + @DienstlUkft
  END

  IF Len(@DienstlVernetz) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlVernetz
  END

  IF Len(@DienstlBerat) > 0  BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlBerat
  END

  UPDATE #Ziele
  SET    Dienstleistung = @D
  WHERE  GridRowID = @GridRowID

  FETCH cDienstl INTO @GridRowID
END
CLOSE cDienstl
DEALLOCATE cDienstl

SELECT Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = null,

       Style = ''KissZiel'',
       Ziel,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = null,

       Style = ''KissMemo'',
       Thema,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = null,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen SD:'',
       NextCell = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null

FROM   #Ziele

DROP TABLE #ziele
END', N'Zielvereinbarungen in Tabellenform. Textmarke wird mit Personen Nr. (BaPersonID) aufgerufen.
Es wird die aktuellste Beratungsphase genommen!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenTabelleBSS', N'Fallführung', 2, N'BEGIN

CREATE TABLE #Ziele
(
  GridRowID      INT,
  Ziel           SQL_VARIANT,
  Thema          SQL_VARIANT,
  Kriterium      SQL_VARIANT,
  LeistungDritte SQL_VARIANT,
  LeistungKlient SQL_VARIANT,
  Mittel         SQL_VARIANT
);

DECLARE @ZielFldID INT;
DECLARE @ThemaFldID INT;
DECLARE @KriteriumFldID INT;
DECLARE @MittelFldID INT;
DECLARE @LeistungDritteFldID INT;
DECLARE @LeistungKlientFldID INT;

SELECT TOP 1 @ZielFldID           = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielZiel'';
SELECT TOP 1 @ThemaFldID          = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielThema'';
SELECT TOP 1 @KriteriumFldID      = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielKritIndi'';
SELECT TOP 1 @MittelFldID         = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielMittel'';
SELECT TOP 1 @LeistungDritteFldID = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielLeistDritte'';
SELECT TOP 1 @LeistungKlientFldID = DynaFieldID FROM DynaField WHERE FieldName = ''FaZielvereinZielLeistKlient'';


INSERT #Ziele (GridRowID)
SELECT DISTINCT GridRowID
FROM   DynaValue VAL
       INNER JOIN DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
WHERE  VAL.FaPhaseID = {FaPhaseID} AND
       FLD.Maskname = ''Fa_Beratung_Zielvereinbarungen''
ORDER BY GridRowID;

UPDATE #Ziele
SET    Ziel =           (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @ZielFldID AND GridRowID = ZIE.GridRowID),
       Thema =          (SELECT TOP 1 LOV.Text
                         FROM   DynaValue VAL
                                INNER JOIN XLOVCode LOV on LOV.LOVName = ''FaThema'' AND LOV.Code = VAL.Value
                         WHERE  VAL.FaPhaseID = {FaPhaseID} AND VAL.DynaFieldID = @ThemaFldID AND VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @KriteriumFldID AND GridRowID = ZIE.GridRowID),
       Mittel =         (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @MittelFldID AND GridRowID = ZIE.GridRowID),
       LeistungDritte = (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @LeistungDritteFldID AND GridRowID = ZIE.GridRowID),
       LeistungKlient = (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @LeistungKlientFldID AND GridRowID = ZIE.GridRowID)
FROM   #Ziele ZIE;


SELECT Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = NULL,

       Style = ''KissZiel'',
       Ziel,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Thema,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Mittel, Verfahren, Massnahmen:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Mittel,
       NextCell = NULL
FROM   #Ziele;

DROP TABLE #Ziele;
END;', N'Beratungsphase Zielvereinbarungen
Zielsetzung, Thema, Kriterium/Indikator, Leistungen Dritte, Leistungen Klient, Mittel/Verfahren/Massnahmen', NULL, 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinbarungenTabelleWOH', N'Fallführung', 1, N'begin

declare @Ziele table
(
  GridRowID      int,
  Ziel           sql_variant,
  Thema          sql_variant,
  Kriterium      sql_variant,
  Mittel         sql_variant
)

declare @ZielFldID int
declare @ThemaFldID int
declare @KriteriumFldID int
declare @MittelFldID int

select top 1 @ZielFldID      = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaZielvereinZielZiel''
select top 1 @ThemaFldID     = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaZielvereinZielThema''
select top 1 @KriteriumFldID = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaZielvereinZielKriterium''
select top 1 @MittelFldID    = DynaFieldID from dbo.DynaField WITH (READUNCOMMITTED) where  FieldName = ''FaZielvereinZielMittel''

insert @Ziele (GridRowID)
select distinct GridRowID
from   dbo.DynaValue V WITH (READUNCOMMITTED)
       inner join dbo.DynaField F WITH (READUNCOMMITTED) on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Beratung_Beratungsplan_Ziele''
order by GridRowID

update @Ziele
set    Ziel =      (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Thema =     (select top 1 LOV.Text
                    from   dbo.DynaValue VAL WITH (READUNCOMMITTED)
                           inner join dbo.XLOVCode LOV WITH (READUNCOMMITTED) on LOV.LOVName = ''FaThema'' and LOV.Code = VAL.Value
                    where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ThemaFldID and VAL.GridRowID = ZIE.GridRowID),
       Kriterium = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @KriteriumFldID and GridRowID = ZIE.GridRowID),
       Mittel    = (select top 1 Value from dbo.DynaValue WITH (READUNCOMMITTED) where FaPhaseID = {FaPhaseID} and DynaFieldID = @MittelFldID and GridRowID = ZIE.GridRowID)
from   @Ziele ZIE

select Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = null,

       Style = ''KissZiel'',
       Ziel,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = null,

       Style = ''KissMemo'',
       Thema,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Kriterium:'',
       NextCell = null,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Mittel:'',
       NextCell = null,

       Style = ''KissMemo'',
       Mittel,
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null

from   @Ziele

end', N'FF Gemeinden', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntake', N'Fallführung', 1, N'begin

create table #Ziele
(
  GridRowID      int,
  Ziel           sql_variant,
  Thema          sql_variant,
  Kriterium      sql_variant,
  LeistungDritte sql_variant,
  LeistungKlient sql_variant,
  Dienstleistung varchar(4000)
)

declare @ZielFldID int
declare @ThemaFldID int
declare @KriteriumFldID int
declare @LeistungDritteFldID int
declare @LeistungKlientFldID int

declare @DienstlFinanzFldID int
declare @DienstlArbeitFldID int
declare @DienstlUkftFldID int
declare @DienstlVernetzFldID int
declare @DienstlBeratFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielZiel''
select top 1 @ThemaFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielThema''
select top 1 @KriteriumFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielKritIndi''
select top 1 @LeistungDritteFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielLeistDritte''
select top 1 @LeistungKlientFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielLeistKlient''

select top 1 @DienstlFinanzFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslFinHilf''
select top 1 @DienstlArbeitFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslArbeit''
select top 1 @DienstlUkftFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslUnterkunf''
select top 1 @DienstlVernetzFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslVernetz''
select top 1 @DienstlBeratFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslBerat''


insert #Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Intake_Zielvereinbarungen''
order by GridRowID

update #Ziele
set    Ziel =           (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Thema =          (select top 1 LOV.Text
                         from   DynaValue VAL
                                inner join XLOVCode LOV on LOV.LOVName = ''FaThema'' and LOV.Code = VAL.Value
                         where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ThemaFldID and VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @KriteriumFldID and GridRowID = ZIE.GridRowID),
       LeistungDritte = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungDritteFldID and GridRowID = ZIE.GridRowID),
       LeistungKlient = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungKlientFldID and GridRowID = ZIE.GridRowID)
from   #Ziele ZIE

declare @GridRowID int
declare @DienstlFinanz  varchar(2000)
declare @DienstlArbeit  varchar(2000)
declare @DienstlUkft    varchar(2000)
declare @DienstlVernetz varchar(2000)
declare @DienstlBerat   varchar(2000)
declare @D              varchar(4000)

declare cDienstl cursor for
select GridRowID from #Ziele

open cDienstl
fetch cDienstl into @GridRowID
while @@fetch_status = 0
begin
  set @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlFinanzFldID and GridRowID = @GridRowID))
  set @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlArbeitFldID and GridRowID = @GridRowID))
  set @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlUkftFldID and GridRowID = @GridRowID))
  set @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlVernetzFldID and GridRowID = @GridRowID))
  set @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlBeratFldID and GridRowID = @GridRowID))

  set @D = @DienstlFinanz

  if Len(@DienstlArbeit) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlArbeit
  end

  if Len(@DienstlUkft) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D  + @DienstlUkft
  end

  if Len(@DienstlVernetz) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlVernetz
  end

  if Len(@DienstlBerat) > 0  begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlBerat
  end

  update #Ziele
  set    Dienstleistung = @D
  where  GridRowID = @GridRowID

  fetch cDienstl into @GridRowID
end
close cDienstl
deallocate cDienstl

select Style = ''KissZiel'',
       Ziel,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Thema,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Kriterium,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NewParagraph = null,
       NewParagraph = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen:'',
       NewParagraph = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NewParagraph = null,
       NewParagraph = null

from   #Ziele

drop table #ziele
end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntakeErreichGrad', N'Fallführung', 1, N'begin

declare @Ziele table
(
  GridRowID       int,
  Ziel            sql_variant,
  Erreichungsgrad sql_variant
)

declare @ZielFldID int
declare @ErreichungsgradFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielZiel''
select top 1 @ErreichungsgradFldID = DynaFieldID from DynaField where  FieldName = ''FaIntAuswertungZielGrad''

insert @Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Intake_Zielvereinbarungen''
order by GridRowID

update @Ziele
set    Ziel            = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Erreichungsgrad = (select top 1 LOV.Text
                          from   DynaValue VAL
                                 inner join XLOVCode LOV on LOV.LOVName = ''FaZielErreichungsgrad'' and LOV.Code = VAL.Value
                          where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ErreichungsgradFldID and VAL.GridRowID = ZIE.GridRowID)
from   @Ziele ZIE

select ''Ziel: '' + isNull(convert(varchar(1000),Ziel),''''),
       NewParagraph = null,
       ''Erreichungsgrad:'' + isNull(convert(varchar(100),Erreichungsgrad),''''),
       NewParagraph = null,
       NewParagraph = null
from   @Ziele

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntakeErreichGradTabelle', N'Fallführung', 1, N'begin

declare @Ziele table
(
  GridRowID       int,
  Ziel            sql_variant,
  Erreichungsgrad sql_variant
)

declare @ZielFldID int
declare @ErreichungsgradFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielZiel''
select top 1 @ErreichungsgradFldID = DynaFieldID from DynaField where  FieldName = ''FaIntAuswertungZielGrad''

insert @Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Intake_Zielvereinbarungen''
order by GridRowID

update @Ziele
set    Ziel            = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Erreichungsgrad = (select top 1 LOV.Text
                          from   DynaValue VAL
                                 inner join XLOVCode LOV on LOV.LOVName = ''FaZielErreichungsgrad'' and LOV.Code = VAL.Value
                          where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ErreichungsgradFldID and VAL.GridRowID = ZIE.GridRowID)
from   @Ziele ZIE

select Ziel,
       NextCell = null,
       Erreichungsgrad,
       NextCell = null
from   @Ziele

end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntakeTabelle', N'Fallführung', 1, N'begin

create table #Ziele
(
  GridRowID      int,
  Ziel           sql_variant,
  Thema          sql_variant,
  Kriterium      sql_variant,
  LeistungDritte sql_variant,
  LeistungKlient sql_variant,
  Dienstleistung varchar(4000)
)

declare @ZielFldID int
declare @ThemaFldID int
declare @KriteriumFldID int
declare @LeistungDritteFldID int
declare @LeistungKlientFldID int

declare @DienstlFinanzFldID int
declare @DienstlArbeitFldID int
declare @DienstlUkftFldID int
declare @DienstlVernetzFldID int
declare @DienstlBeratFldID int

select top 1 @ZielFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielZiel''
select top 1 @ThemaFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielThema''
select top 1 @KriteriumFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielKritIndi''
select top 1 @LeistungDritteFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielLeistDritte''
select top 1 @LeistungKlientFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinZielLeistKlient''

select top 1 @DienstlFinanzFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslFinHilf''
select top 1 @DienstlArbeitFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslArbeit''
select top 1 @DienstlUkftFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslUnterkunf''
select top 1 @DienstlVernetzFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslVernetz''
select top 1 @DienstlBeratFldID = DynaFieldID from DynaField where  FieldName = ''FaIntZielvereinDienslBerat''


insert #Ziele (GridRowID)
select distinct GridRowID
from   DynaValue V
       inner join DynaField F on F.DynaFieldID = V.DynaFieldID
where  V.FaPhaseID = {FaPhaseID} and
       F.Maskname = ''Fa_Intake_Zielvereinbarungen''
order by GridRowID

update #Ziele
set    Ziel =           (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @ZielFldID and GridRowID = ZIE.GridRowID),
       Thema =          (select top 1 LOV.Text
                         from   DynaValue VAL
                                inner join XLOVCode LOV on LOV.LOVName = ''FaThema'' and LOV.Code = VAL.Value
                         where  VAL.FaPhaseID = {FaPhaseID} and VAL.DynaFieldID = @ThemaFldID and VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @KriteriumFldID and GridRowID = ZIE.GridRowID),
       LeistungDritte = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungDritteFldID and GridRowID = ZIE.GridRowID),
       LeistungKlient = (select top 1 Value from DynaValue where FaPhaseID = {FaPhaseID} and DynaFieldID = @LeistungKlientFldID and GridRowID = ZIE.GridRowID)
from   #Ziele ZIE

declare @GridRowID int
declare @DienstlFinanz  varchar(2000)
declare @DienstlArbeit  varchar(2000)
declare @DienstlUkft    varchar(2000)
declare @DienstlVernetz varchar(2000)
declare @DienstlBerat   varchar(2000)
declare @D              varchar(4000)

declare cDienstl cursor for
select GridRowID from #Ziele

open cDienstl
fetch cDienstl into @GridRowID
while @@fetch_status = 0
begin
  set @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlFinanzFldID and GridRowID = @GridRowID))
  set @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlArbeitFldID and GridRowID = @GridRowID))
  set @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlUkftFldID and GridRowID = @GridRowID))
  set @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlVernetzFldID and GridRowID = @GridRowID))
  set @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (select top 1 convert(varchar(100),Value) from DynaValue
                         where FaPhaseID = {FaPhaseID} and DynaFieldID = @DienstlBeratFldID and GridRowID = @GridRowID))

  set @D = @DienstlFinanz

  if Len(@DienstlArbeit) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlArbeit
  end

  if Len(@DienstlUkft) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D  + @DienstlUkft
  end

  if Len(@DienstlVernetz) > 0 begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlVernetz
  end

  if Len(@DienstlBerat) > 0  begin
    if Len(@D) > 0 set @D = @D + '',''
    set @D = @D + @DienstlBerat
  end

  update #Ziele
  set    Dienstleistung = @D
  where  GridRowID = @GridRowID

  fetch cDienstl into @GridRowID
end
close cDienstl
deallocate cDienstl

select Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = null,

       Style = ''KissZiel'',
       Ziel,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = null,

       Style = ''KissMemo'',
       Thema,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = null,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen SD:'',
       NextCell = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null

from   #Ziele

drop table #ziele
end', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntakeTabelleAllg', N'Fallführung', 1, N'BEGIN

CREATE TABLE #Ziele
(
  GridRowID      INT,
  Ziel           SQL_VARIANT,
  Thema          SQL_VARIANT,
  Kriterium      SQL_VARIANT,
  LeistungDritte SQL_VARIANT,
  LeistungKlient SQL_VARIANT,
  Dienstleistung VARCHAR(4000)
)

DECLARE @ZielFldID INT
DECLARE @ThemaFldID INT
DECLARE @KriteriumFldID INT
DECLARE @LeistungDritteFldID INT
DECLARE @LeistungKlientFldID INT

DECLARE @DienstlFinanzFldID INT
DECLARE @DienstlArbeitFldID INT
DECLARE @DienstlUkftFldID INT
DECLARE @DienstlVernetzFldID INT
DECLARE @DienstlBeratFldID INT

DECLARE @FaPhaseID INT

SELECT TOP 1 @FaPhaseID = PHA.FaPhaseID
FROM   dbo.FaPhase PHA WITH (READUNCOMMITTED)
WHERE  PHA.FaLeistungID =
        (SELECT TOP 1 LEI.FaLeistungID
         FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
         WHERE LEI.BaPersonID = {BaPersonID}
         AND   LEI.ModulID = 2
         ORDER BY DatumVon DESC)
AND    PHA.FaPhaseCode = 1 -- Intakephase
ORDER BY PHA.DatumVon DESC

SELECT TOP 1 @ZielFldID           = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinZielZiel''
SELECT TOP 1 @ThemaFldID          = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinZielThema''
SELECT TOP 1 @KriteriumFldID      = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinZielKritIndi''
SELECT TOP 1 @LeistungDritteFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinZielLeistDritte''
SELECT TOP 1 @LeistungKlientFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinZielLeistKlient''

SELECT TOP 1 @DienstlFinanzFldID  = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinDienslFinHilf''
SELECT TOP 1 @DienstlArbeitFldID  = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinDienslArbeit''
SELECT TOP 1 @DienstlUkftFldID    = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinDienslUnterkunf''
SELECT TOP 1 @DienstlVernetzFldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinDienslVernetz''
SELECT TOP 1 @DienstlBeratFldID   = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE  FieldName = ''FaIntZielvereinDienslBerat''


INSERT #Ziele (GridRowID)
SELECT DISTINCT GridRowID
FROM   dbo.DynaValue V WITH (READUNCOMMITTED)
   INNER JOIN dbo.DynaField F WITH (READUNCOMMITTED) ON F.DynaFieldID = V.DynaFieldID
WHERE  V.FaPhaseID = @FaPhaseID
AND    F.Maskname = ''Fa_Intake_Zielvereinbarungen''
ORDER BY GridRowID

UPDATE #Ziele
SET    Ziel =           (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @ZielFldID AND GridRowID = ZIE.GridRowID),
       Thema =          (SELECT TOP 1 LOV.Text
                         FROM   dbo.DynaValue VAL WITH (READUNCOMMITTED)
                                INNER JOIN dbo.XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.LOVName = ''FaThema'' AND LOV.Code = VAL.Value
                         WHERE  VAL.FaPhaseID = @FaPhaseID AND VAL.DynaFieldID = @ThemaFldID AND VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @KriteriumFldID AND GridRowID = ZIE.GridRowID),
       LeistungDritte = (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @LeistungDritteFldID AND GridRowID = ZIE.GridRowID),
       LeistungKlient = (SELECT TOP 1 Value FROM dbo.DynaValue WITH (READUNCOMMITTED) WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @LeistungKlientFldID AND GridRowID = ZIE.GridRowID)
FROM   #Ziele ZIE

DECLARE @GridRowID INT
DECLARE @DienstlFinanz  VARCHAR(2000)
DECLARE @DienstlArbeit  VARCHAR(2000)
DECLARE @DienstlUkft    VARCHAR(2000)
DECLARE @DienstlVernetz VARCHAR(2000)
DECLARE @DienstlBerat   VARCHAR(2000)
DECLARE @D              VARCHAR(4000)

DECLARE cDienstl CURSOR FOR
SELECT GridRowID FROM #Ziele

OPEN cDienstl
FETCH cDienstl INTO @GridRowID
WHILE @@fetch_status = 0
BEGIN
  SET @DienstlFinanz  = dbo.fnLOVTextListe(''FaLeistungenFinanziell'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlFinanzFldID AND GridRowID = @GridRowID))
  SET @DienstlArbeit  = dbo.fnLOVTextListe(''FaLeistungenArbeit'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlArbeitFldID AND GridRowID = @GridRowID))
  SET @DienstlUkft    = dbo.fnLOVTextListe(''FaLeistungenUnterkunft'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlUkftFldID AND GridRowID = @GridRowID))
  SET @DienstlVernetz = dbo.fnLOVTextListe(''FaLeistungenVernetzung'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlVernetzFldID AND GridRowID = @GridRowID))
  SET @DienstlBerat   = dbo.fnLOVTextListe(''FaLeistungenBeratung'',
                        (SELECT TOP 1 CONVERT(VARCHAR(100),Value) FROM dbo.DynaValue WITH (READUNCOMMITTED)
                         WHERE FaPhaseID = @FaPhaseID AND DynaFieldID = @DienstlBeratFldID AND GridRowID = @GridRowID))

  SET @D = @DienstlFinanz

  IF Len(@DienstlArbeit) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlArbeit
  END

  IF Len(@DienstlUkft) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D  + @DienstlUkft
  END

  IF Len(@DienstlVernetz) > 0 BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlVernetz
  END

  IF Len(@DienstlBerat) > 0  BEGIN
    IF Len(@D) > 0 SET @D = @D + '',''
    SET @D = @D + @DienstlBerat
  END

  UPDATE #Ziele
  SET    Dienstleistung = @D
  WHERE  GridRowID = @GridRowID

  FETCH cDienstl INTO @GridRowID
END
CLOSE cDienstl
DEALLOCATE cDienstl

SELECT Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = null,

       Style = ''KissZiel'',
       Ziel,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = null,

       Style = ''KissMemo'',
       Thema,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = null,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = null,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = null,

       Style = ''KissFixtext'',
       ''Dienstleistungen SD:'',
       NextCell = null,

       Style = ''KissMemo'',
       Dienstleistung,
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null,

       Style = ''KissLeereZelle'',
       '' '',
       NextCell = null

FROM   #Ziele

DROP TABLE #ziele
END', N'Textmarke wird mit Personen Nr. (BaPersonID) aufgerufen.
Es wird die aktuellste Intakephase genommen!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FaZielvereinIntakeTabelleBSS', N'Fallführung', 2, N'BEGIN

CREATE TABLE #Ziele
(
  GridRowID      INT,
  Ziel           SQL_VARIANT,
  Thema          SQL_VARIANT,
  Kriterium      SQL_VARIANT,
  LeistungDritte SQL_VARIANT,
  LeistungKlient SQL_VARIANT,
  Mittel         SQL_VARIANT
);

DECLARE @ZielFldID INT;
DECLARE @ThemaFldID INT;
DECLARE @KriteriumFldID INT;
DECLARE @MittelFldID INT;
DECLARE @LeistungDritteFldID INT;
DECLARE @LeistungKlientFldID INT;

SELECT TOP 1 @ZielFldID           = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielZiel'';
SELECT TOP 1 @ThemaFldID          = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielThema'';
SELECT TOP 1 @KriteriumFldID      = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielKritIndi'';
SELECT TOP 1 @MittelFldID         = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielMittel'';
SELECT TOP 1 @LeistungDritteFldID = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielLeistDritte'';
SELECT TOP 1 @LeistungKlientFldID = DynaFieldID FROM DynaField WHERE FieldName = ''FaIntZielvereinZielLeistKlient'';


INSERT #Ziele (GridRowID)
SELECT DISTINCT GridRowID
FROM   DynaValue VAL
       INNER JOIN DynaField FLD on FLD.DynaFieldID = VAL.DynaFieldID
WHERE  VAL.FaPhaseID = {FaPhaseID} AND
       FLD.Maskname = ''Fa_Intake_Zielvereinbarungen''
ORDER BY GridRowID;

UPDATE #Ziele
SET    Ziel =           (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @ZielFldID AND GridRowID = ZIE.GridRowID),
       Thema =          (SELECT TOP 1 LOV.Text
                         FROM   DynaValue VAL
                                INNER JOIN XLOVCode LOV on LOV.LOVName = ''FaThema'' AND LOV.Code = VAL.Value
                         WHERE  VAL.FaPhaseID = {FaPhaseID} AND VAL.DynaFieldID = @ThemaFldID AND VAL.GridRowID = ZIE.GridRowID),
       Kriterium =      (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @KriteriumFldID AND GridRowID = ZIE.GridRowID),
       Mittel =         (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @MittelFldID AND GridRowID = ZIE.GridRowID),
       LeistungDritte = (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @LeistungDritteFldID AND GridRowID = ZIE.GridRowID),
       LeistungKlient = (SELECT TOP 1 Value FROM DynaValue WHERE FaPhaseID = {FaPhaseID} AND DynaFieldID = @LeistungKlientFldID AND GridRowID = ZIE.GridRowID)
FROM   #Ziele ZIE;


SELECT Style = ''KissZielFixtext'',
       ''Zielsetzung:'',
       NextCell = NULL,

       Style = ''KissZiel'',
       Ziel,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Thema:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Thema,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Kriterium/Indikator:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Kriterium,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Leistungen Dritte:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       LeistungDritte,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Leistungen Klient:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       LeistungKlient,
       NextCell = NULL,

       Style = ''KissFixtext'',
       ''Mittel, Verfahren, Massnahmen:'',
       NextCell = NULL,

       Style = ''KissMemo'',
       Mittel,
       NextCell = NULL
FROM   #Ziele;

DROP TABLE #Ziele;
END;', N'Intake Zielvereinbarungen
Zielsetzung, Thema, Kriterium/Indikator, Leistungen Dritte, Leistungen Klient, Mittel/Verfahren/Massnahmen', NULL, 2, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragBankKtoNr', N'Mandatsbuchhaltung', 1, N'select ZAH.BankKontoNr
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragBankName', N'Mandatsbuchhaltung', 1, N'SELECT BNK.Name
FROM   FbDauerauftrag     DAU
  LEFT JOIN FbZahlungsweg ZAH ON ZAH.FbZahlungswegID = DAU.FbZahlungswegID
  LEFT JOIN BaBank        BNK ON BNK.BaBankID = ZAH.BaBankID
WHERE  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragBetrag', N'Mandatsbuchhaltung', 1, N'select convert(varchar,DAU.Betrag,1)
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragBuchungstext', N'Mandatsbuchhaltung', 1, N'select DAU.Text
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragGueltigBis', N'Mandatsbuchhaltung', 1, N'select convert(varchar, DAU.DatumBis,104)
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragGueltigVon', N'Mandatsbuchhaltung', 1, N'select convert(varchar, DAU.DatumVon,104)
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragKreditorName', N'Mandatsbuchhaltung', 1, N'select KRE.Name
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
       left join FbKreditor    KRE on KRE.FbKreditorID = ZAH.FbKreditorID
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragKreditorPLZOrt', N'Mandatsbuchhaltung', 1, N'select isNull(KRE.PLZ + '' '','''') + KRE.Ort
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
       left join FbKreditor    KRE on KRE.FbKreditorID = ZAH.FbKreditorID
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragKreditorStrasse', N'Mandatsbuchhaltung', 1, N'select KRE.Strasse
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
       left join FbKreditor    KRE on KRE.FbKreditorID = ZAH.FbKreditorID
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragMonatstag1', N'Mandatsbuchhaltung', 1, N'select convert(varchar,DAU.Monatstag1) + ''.''
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragMonatstag2', N'Mandatsbuchhaltung', 1, N'select convert(varchar,DAU.Monatstag2) + ''.''
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragNr', N'Mandatsbuchhaltung', 1, N'select {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragPCKonto', N'Mandatsbuchhaltung', 1, N'select ZAH.PCKontoNr
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragPeriodizitaet', N'Mandatsbuchhaltung', 1, N'select PER.Text
from   FbDauerauftrag DAU
       left join XLOVCode      PER on PER.LOVName = ''ZahlungsPeriode'' and
                                      PER.Code = DAU.PeriodizitaetCode
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragReferenznummer', N'Mandatsbuchhaltung', 1, N'select DAU.ReferenzNummer
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragZahlungsart', N'Mandatsbuchhaltung', 1, N'select ART.Text
from   FbDauerauftrag DAU
       left join FbZahlungsweg ZAH on ZAH.FbZahlungswegID = DAU.FbZahlungswegID
       left join XLOVCode      ART on ART.LOVName = ''FbZahlungsartCode'' and
                                      ART.Code = ZAH.ZahlungsartCode
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FbDauerauftragZahlungsgrund', N'Mandatsbuchhaltung', 1, N'select DAU.Zahlungsgrund
from   FbDauerauftrag DAU
where  FbDauerauftragID = {FbDauerauftragID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Institution', N'Institution', 1, N'SELECT <TableColumn> FROM vwTmInstitution  WHERE BaInstitutionID = {InstitutionId}', NULL, N'vwTmInstitution', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterAnrede', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        case XUR2.GenderCode
           when 1 then ''Herr''
           when 2 then ''Frau''
           else ''''
       end
    else
        isNull(OKO.Anrede, '''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterAnredeName', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        case XUR2.GenderCode
           when 1 then ''Herr''
           when 2 then ''Frau''
           else ''''
       end
       + isNull('' '' + XUR2.LastName, '''')
    else
        isNull(OKO.Anrede + isNull('' '' + OKO.Name,''''), '''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"
Herr/Frau Name', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterAnredeNameAkku', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        case XUR2.GenderCode
           when 1 then ''Herrn''
           when 2 then ''Frau''
           else ''''
       end
       + isNull('' '' + XUR2.LastName, '''')
    else
        isNull(OKO.Anrede + CASE WHEN OKO.Anrede = ''Herr'' THEN ''n'' ELSE '''' END, '''') + isNull('' '' + OKO.Name,'''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"
Herrn/Frau Name', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterGeehrtePlusAnrede', N'KA', 1, N'SELECT TOP 1    
ZuweiserAnzeige =      
  CASE WHEN KAE.ZuweiserID < 0 THEN          
    CASE XUR2.GenderCode             
      WHEN 1 THEN ''Sehr geehrter Herr''             
      WHEN 2 THEN ''Sehr geehrte Frau''             
      ELSE ''''         
    END      
  ELSE          
    CASE 
      WHEN OKO.Anrede LIKE ''Herr%'' THEN ''Sehr geehrter Herr''               
      WHEN OKO.Anrede LIKE ''Frau%'' THEN ''Sehr geehrte Frau''          
      ELSE              ''''          
    END     
  END  
  FROM KaEinsatz KAE   
    LEFT JOIN KaEinsatzplatz2 KEP ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
    LEFT JOIN BaInstitution ORG ON ORG.BaInstitutionID = KAE.ALKasseID   
    LEFT JOIN KaZuteilFachbereich PRZ ON PRZ.BaPersonID = {BaPersonID} 
                                     AND PRZ.ZuteilungBis = (SELECT MAX(PRZ1.ZuteilungBis) 
                                                             FROM KaZuteilFachbereich PRZ1 
                                                             WHERE PRZ1.BaPersonID = PRZ.BaPersonID)   
    LEFT JOIN XUser     XUR ON XUR.UserID = PRZ.ZustaendigKaID    
    LEFT JOIN BaInstitutionKontakt OKO ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID   
    LEFT JOIN BaInstitution ORG1 ON ORG1.BaInstitutionID =  OKO.BaInstitutionID       
    LEFT JOIN FaLeistung    FAL   ON FAL.FaLeistungID = {FaLeistungID}   
    LEFT JOIN XUser     XUR1 ON XUR1.UserID = FAL.UserID    
    LEFT JOIN XUser     XUR2 ON XUR2.UserID = -KAE.ZuweiserID   
    LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID       
                               AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)   
    LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID    
    LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID  
WHERE   KAE.BaPersonID = {BaPersonID}
ORDER BY KAE.DatumBis DESC', N'Für "KA QE Einladung Intake"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterInfo', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        case XUR2.GenderCode
           when 1 then ''Herr''
           when 2 then ''Frau''
           else ''''
       end
       + isNull('' '' + XUR2.FirstName, '''') + isNull('' '' + XUR2.LastName, '''') + isNull('', '' + XOU.ItemName, '''')
    else
        isNull(OKO.Anrede, '''') + isNull('' '' + OKO.Vorname, '''') + isNull('' '' + OKO.Name,'''') + isNull('', '' + ORG1.Name, '''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID	
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"
Herr/Frau Vorname Name, Ort', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterInfoHerrn', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        case XUR2.GenderCode
           when 1 then ''Herrn''
           when 2 then ''Frau''
           else ''''
       end
       + isNull('' '' + XUR2.FirstName, '''') + isNull('' '' + XUR2.LastName, '''') + isNull('', '' + XOU.ItemName, '''')
    else
        isNull(OKO.Anrede + CASE WHEN OKO.Anrede = ''Herr'' THEN ''n'' ELSE '''' END, '''') + isNull('' '' + OKO.Vorname, '''') + isNull('' '' + OKO.Name,'''') + isNull('', '' + ORG1.Name, '''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"
Herrn/Frau Vorname Name, Ort', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterName', N'KA', 1, N'SELECT TOP 1    
  ZuweiserAnzeige =      
    CASE WHEN KAE.ZuweiserID < 0 THEN          
      isNull(XUR2.LastName, '''')      
    ELSE          
      isNull(OKO.Name,'''')      
    END  
FROM KaEinsatz KAE   
  LEFT JOIN KaEinsatzplatz2 KEP ON KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID   
  LEFT JOIN BaInstitution ORG ON ORG.BaInstitutionID = KAE.ALKasseID   
  LEFT JOIN KaZuteilFachbereich PRZ ON PRZ.BaPersonID = {BaPersonID} 
                                   AND PRZ.ZuteilungBis = (SELECT MAX(PRZ1.ZuteilungBis) 
                                                           FROM KaZuteilFachbereich PRZ1 
                                                           WHERE PRZ1.BaPersonID = PRZ.BaPersonID)   
  LEFT JOIN XUser     XUR ON XUR.UserID = PRZ.ZustaendigKaID    
  LEFT JOIN BaInstitutionKontakt OKO ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID   
  LEFT JOIN BaInstitution ORG1 ON ORG1.BaInstitutionID =  OKO.BaInstitutionID       
  LEFT JOIN FaLeistung    FAL   ON FAL.FaLeistungID = {FaLeistungID}   
  LEFT JOIN XUser     XUR1 ON XUR1.UserID = FAL.UserID    
  LEFT JOIN XUser     XUR2 ON XUR2.UserID = -KAE.ZuweiserID   
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID       
                             AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)   
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID    
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID  
WHERE   KAE.BaPersonID = {BaPersonID}
ORDER BY KAE.DatumBis DESC', N'Für "KA QE Einladung Intake"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterOrt', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
       isNull(XOU.ItemName, '''')
    else
       isNull(ORG1.Name, '''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KABeraterVornameName', N'KA', 1, N'SELECT top 1
  ZuweiserAnzeige =
    case when KAE.ZuweiserID < 0 then
        isNull(XUR2.FirstName, '''') + isNull('' '' + XUR2.LastName, '''')
    else
        isNull(OKO.Vorname, '''') + isNull('' '' + OKO.Name,'''')
    end
FROM KaEinsatz KAE
  left join KaEinsatzplatz2 KEP	on KAE.KaEinsatzplatzID = KEP.KaEinsatzplatzID
  left join BaInstitution ORG	on ORG.BaInstitutionID = KAE.ALKasseID
  left join KaZuteilFachbereich PRZ on PRZ.BaPersonID = {BaPersonID} and
           PRZ.ZuteilungBis = (select max(PRZ1.ZuteilungBis) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID)
  left join XUser			  XUR	on XUR.UserID = PRZ.ZustaendigKaID	
  left join BaInstitutionKontakt OKO on OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  left join BaInstitution ORG1	on ORG1.BaInstitutionID =  OKO.BaInstitutionID							left join FaLeistung		  FAL   on FAL.FaLeistungID = {FaLeistungID}
  left join XUser			  XUR1	on XUR1.UserID = FAL.UserID	
  left join XUser			  XUR2	on XUR2.UserID = -KAE.ZuweiserID
  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KAE.ZuweiserID
          AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID	
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = KAE.BaPersonID
WHERE   KAE.BaPersonID = {BaPersonID}', N'Für "KA QE Einladung Intake"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQGespStattgef', N'KA', 1, N'SELECT KeinKontakt = Convert(bit, CASE WHEN IntakeCodes like ''%4%'' THEN 1 ELSE 0 END)
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', N'Checkbox EPQ->Intake "Gespräch stattgefunden".', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQIntakeGrund', N'KA', 1, N'SELECT IntakeGrund = dbo.fnLOVTextListe(''KaQEEPQIntakeGrund'', IntakeCodes)
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', N'Grund (Kommagetrennt) aus EPQ->Intake', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQKeinKontakt', N'KA', 1, N'SELECT KeinKontakt = Convert(bit, CASE WHEN IntakeCodes like ''%1%'' THEN 1 ELSE 0 END)
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', N'Checkbox EPQ->Intake "kein Kontakt aufgenommen".', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQNichtErsch', N'KA', 1, N'SELECT KeinKontakt = Convert(bit, CASE WHEN IntakeCodes like ''%2%'' THEN 1 ELSE 0 END)
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', N'Checkbox EPQ->Intake "nicht erschienen".', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerDatum', N'KA', 1, N'SELECT convert(varchar, FeinzielDat, 104)
FROM KaQEEPQZielvereinb
WHERE KaQEEPQZielvereinbID =
  (SELECT max(KaQEEPQZielvereinbID)
   FROM KaQEEPQZielvereinb
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVereinbarung', N'KA', 1, N'SELECT 	convert(varchar, FeinzielDat, 104),
  NextCell = null,
  Feinziel,
  NextCell = null,
  ErreichenBis,
  NextCell = null,
  MessungZielerreichung,
  NextCell = null,
  Ergebnis,
  NextCell = null
FROM KaQEEPQZielvereinb
WHERE FaLeistungID = {FaLeistungID}', N'Tabelle für QE EPQ Zielvereinbarungen', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVereinbarungVerl', N'KA', 1, N'SELECT 	convert(varchar, FeinzielDat, 104),
  NextCell = null,
  Feinziel,
  NextCell = null,
  ErreichenBis,
  NextCell = null,
  MessungZielerreichung,
  NextCell = null,
  Ergebnis,
  NextCell = null
FROM KaQEEPQZielvereinbVerl
WHERE FaLeistungID = {FaLeistungID}', N'Tabelle für QE EPQ Zielvereinbarungen Verlängerung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerErgebnis', N'KA', 1, N'SELECT ErgebnisRTF = Ergebnis
FROM KaQEEPQZielvereinb
WHERE KaQEEPQZielvereinbID =
  (SELECT max(KaQEEPQZielvereinbID)
   FROM KaQEEPQZielvereinb
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerErreichenBis', N'KA', 1, N'SELECT ErreichenBis
FROM KaQEEPQZielvereinb
WHERE KaQEEPQZielvereinbID =
  (SELECT max(KaQEEPQZielvereinbID)
   FROM KaQEEPQZielvereinb
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerFeinziel', N'KA', 1, N'SELECT FeinzielRTF = Feinziel
FROM KaQEEPQZielvereinb
WHERE KaQEEPQZielvereinbID =
  (SELECT max(KaQEEPQZielvereinbID)
   FROM KaQEEPQZielvereinb
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerIndivZieleRAV', N'KA', 1, N'SELECT IndivZieleRTF = IndivZieleRAV
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlDatum', N'KA', 1, N'SELECT convert(varchar, FeinzielDat, 104)
FROM KaQEEPQZielvereinbVerl
WHERE KaQEEPQZielvereinbVerlID =
  (SELECT max(KaQEEPQZielvereinbVerlID)
   FROM KaQEEPQZielvereinbVerl
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlErgebnis', N'KA', 1, N'SELECT ErgebnisRTF = Ergebnis
FROM KaQEEPQZielvereinbVerl
WHERE KaQEEPQZielvereinbVerlID =
  (SELECT max(KaQEEPQZielvereinbVerlID)
   FROM KaQEEPQZielvereinbVerl
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlErreichenBis', N'KA', 1, N'SELECT ErreichenBis
FROM KaQEEPQZielvereinbVerl
WHERE KaQEEPQZielvereinbVerlID =
  (SELECT max(KaQEEPQZielvereinbVerlID)
   FROM KaQEEPQZielvereinbVerl
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlFeinziel', N'KA', 1, N'SELECT FeinzielRTF = Feinziel
FROM KaQEEPQZielvereinbVerl
WHERE KaQEEPQZielvereinbVerlID =
  (SELECT max(KaQEEPQZielvereinbVerlID)
   FROM KaQEEPQZielvereinbVerl
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlIndivZieleRAV', N'KA', 1, N'SELECT IndivZieleRTF = IndivZieleRAVVerl
FROM KaQEEPQ
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerVerlZielerreichung', N'KA', 1, N'SELECT MessungZielerreichungRTF = MessungZielerreichung
FROM KaQEEPQZielvereinbVerl
WHERE KaQEEPQZielvereinbVerlID =
  (SELECT max(KaQEEPQZielvereinbVerlID)
   FROM KaQEEPQZielvereinbVerl
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAEPQZielVerZielerreichung', N'KA', 1, N'SELECT MessungZielerreichungRTF = MessungZielerreichung
FROM KaQEEPQZielvereinb
WHERE KaQEEPQZielvereinbID =
  (SELECT max(KaQEEPQZielvereinbID)
   FROM KaQEEPQZielvereinb
   WHERE FaLeistungID = {FaLeistungID})', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KaQJAssessDatum', N'Assessment', 1, N'SELECT DatumAssessment
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Datum aus Assessment', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KaQJAssessNichtAufgen', N'Assessment', 1, N'SELECT NichtAufgGrund
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Grund für "nicht Aufgenommen"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KaQJAssessProjGefährdet', N'Assessment', 1, N'SELECT ProjGefaehrGrund
  FROM dbo.KaQJPZAssessment
  WHERE FaLeistungID = {FaLeistungID};', N'Grund für "Projekt Gefährdet"', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJBeurteilung', N'KA', 1, N'SELECT TOP 1 Beurteilung = CASE KPZ.BeurteilungID
        WHEN 1 THEN ''erreicht''
        WHEN 2 THEN ''optimieren''
        WHEN 3 THEN ''nicht erreicht''
        ELSE ''''
         END
FROM KaQJPZZielvereinbarung KPZ
WHERE KPZ.FaLeistungID = {FaLeistungID}
AND KPZ.ZielDatum = (SELECT MAX(KPZ1.ZielDatum)
         FROM KaQJPZZielvereinbarung KPZ1
         WHERE KPZ1.FaLeistungID = KPZ.FaLeistungID)
ORDER BY KPZ.KaQJPZZielvereinbarungID DESC', N'Beurteilung aus Prozess->Zielvereinbarung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBAndereFlag', N'KA', 1, N'SELECT	Andere = Convert(bit, CASE WHEN IsNull(LOV.Value1, IsNull(LOV1.Value1, '''')) = ''andere'' THEN 1 ELSE 0 END)
FROM	KaQJPZSchlussbericht SBR
  LEFT JOIN KaQJProzess KAP ON KAP.FaLeistungID = SBR.FaLeistungID	
  LEFT JOIN XLOVCode    LOV ON LOV.LOVName = ''KaQjGrundProgEnde'' AND KAP.ProgEndeCode = LOV.Code						
  LEFT JOIN XLOVCode    LOV1 ON LOV1.LOVName = ''KaQjGrundProgAbbruch'' AND KAP.AbbruchCode = LOV1.Code	
WHERE	SBR.FaLeistungID = {FaLeistungID}', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBArbeitsFlag', N'KA', 1, N'SELECT	Arbeitslos = Convert(bit, CASE WHEN IsNull(LOV.Value1, IsNull(LOV1.Value1, '''')) = ''arbeitslos'' THEN 1 ELSE 0 END)
FROM	KaQJPZSchlussbericht SBR
  LEFT JOIN KaQJProzess KAP ON KAP.FaLeistungID = SBR.FaLeistungID	
  LEFT JOIN XLOVCode    LOV ON LOV.LOVName = ''KaQjGrundProgEnde'' AND KAP.ProgEndeCode = LOV.Code						
  LEFT JOIN XLOVCode    LOV1 ON LOV1.LOVName = ''KaQjGrundProgAbbruch'' AND KAP.AbbruchCode = LOV1.Code	
WHERE	SBR.FaLeistungID = {FaLeistungID}', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBArbeitsorganisation', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', AOrganisationCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBArbeitsqualitaet', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', AQualitaetCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBArbeitstempo', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', ATempoCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBAuftreten', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', AuftretenCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBAusdauer', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', AusdauerCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBBemAbsenzen', N'KA', 1, N'SELECT BemAbsenzenRTF = BemAbsenzen
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBBemBildung', N'KA', 1, N'SELECT BemBildungRTF = BemBildung
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBBemEmpfehlung', N'KA', 1, N'SELECT BemEmpfehlungRTF = BemEmpfehlung
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBBemKompetenz', N'KA', 1, N'SELECT BemKompetenzRTF = BemKompetenz
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBBemZielvereinbarung', N'KA', 1, N'SELECT BemZielvereinbarungRTF = BemZielvereinbarung
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBDeutschFlag', N'KA', 1, N'DECLARE @exist BIT

SELECT  @exist = Convert(bit, IsNull(DeutschFlag, 0))
FROM 	KaQJPZSchlussbericht	
WHERE	FaLeistungID = {FaLeistungID}

SELECT Deutsch = Convert(bit, IsNull(@exist, 0))', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBEingVermittel', N'KA', 1, N'DECLARE @exist BIT

SELECT  @exist = Convert(bit, IsNull(EingVermittelbarFlag, 0))
FROM 	KaQJPZSchlussbericht	
WHERE	FaLeistungID = {FaLeistungID}

SELECT EingVermittelbar = Convert(bit, IsNull(@exist, 0))', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBEingVermittelbarGruende', N'KA', 1, N'SELECT EingVermittelbarRTF = EingVermittelbar
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBErscheinung', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', ErscheinungCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBFlexibilitaet', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', FlexibilitaetCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBFranzFlag', N'KA', 1, N'DECLARE @exist BIT

SELECT  @exist = Convert(bit, IsNull(FranzFlag, 0))
FROM 	KaQJPZSchlussbericht	
WHERE	FaLeistungID = {FaLeistungID}

SELECT Franz = Convert(bit, IsNull(@exist, 0))', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBKommunikation', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', KommunikationCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBKritikfaehig', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', KritikfaehigCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBLandessprache', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', LandesspracheCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBLernfaehigkeit', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', LernfaehigkeitCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBMotivation', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', MotivationCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBOrdnung', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', OrdnungCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBPuenktlich', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', PuenktlichCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBSelbstaendig', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', SelbstaendigCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBSorgfalt', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', SorgfaltCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBStelleFlag', N'KA', 1, N'SELECT	Stellenantritt = Convert(bit, CASE WHEN IsNull(LOV.Value1, IsNull(LOV1.Value1, '''')) = ''Stellenantritt'' THEN 1 ELSE 0 END)
FROM	KaQJPZSchlussbericht SBR
  LEFT JOIN KaQJProzess KAP ON KAP.FaLeistungID = SBR.FaLeistungID	
  LEFT JOIN XLOVCode    LOV ON LOV.LOVName = ''KaQjGrundProgEnde'' AND KAP.ProgEndeCode = LOV.Code						
  LEFT JOIN XLOVCode    LOV1 ON LOV1.LOVName = ''KaQjGrundProgAbbruch'' AND KAP.AbbruchCode = LOV1.Code	
WHERE	SBR.FaLeistungID = {FaLeistungID}', N'CheckBox!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBTeamfaehig', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', TeamfaehigCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJSBZuverlaessig', N'KA', 1, N'SELECT dbo.fnLOVText(''KaQjBerichtCodes'', ZuverlaessigCode)
FROM KaQJPZSchlussbericht
WHERE FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJZielvereinbarung', N'KA', 1, N'SELECT  Ziel = VereinbartesZiel,
        NextCell = null,
  Erreichen = ErreichenBis,
        NextCell = null,
  Kriterien = KriterienPruefen,
        NextCell = null
FROM  KaQJPZZielvereinbarung
WHERE FaLeistungID = {FaLeistungID}
ORDER BY ZielDatum DESC', N'Tabelle für Prozess->Zielvereinbarung (Memofelder)
VereinbartesZiel, ErreichenBis, KriterienPruefen', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KAQJZielvereinbarungInklBeurteilung', N'KA', 1, N'SELECT  Ziel = VereinbartesZiel,
        NextCell = null,
  Erreichen = ErreichenBis,
        NextCell = null,
  Kriterien = KriterienPruefen,
        NextCell = null,
        Beurteilung = CASE BeurteilungID
      WHEN 1 THEN ''erreicht''
      WHEN 2 THEN ''optimieren''
      WHEN 3 THEN ''nicht erreicht''
      ELSE ''''
          END,
        NextCell = null
FROM  KaQJPZZielvereinbarung
WHERE FaLeistungID = {FaLeistungID}
ORDER BY ZielDatum DESC', N'Tabelle für Prozess->Zielvereinbarung (Memofelder)
VereinbartesZiel, ErreichenBis, KriterienPruefen, Beurteilung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KinderNamenVornamenGeburtInCH', N'Kinder', 1, N'SELECT KinderNamenVornamenGeburtInCH = dbo.fnTmKinder({BaPersonId}, ''NamenVornamenGeburtInCH'', 1)', N'Listet Namen, Vornamen, Geburtsdatum und InCHSeit der Kinder einer Person auf, mit Zeilenumbruch', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KinderNamenVornamenJahr', N'Kinder', 1, N'SELECT KinderNamenVornamenJahr = dbo.fnTmKinder( {BaPersonID}, ''NamenVornamenJahr'', 1)', N'Listet alle Namen, Vornamen und Geburtsdatum der Kinder einer Person auf, mit Zeileumbruch, z.B.:  Muster Markus (11.07.1995)  Muster Ursula (13.08.1997)   Muster Peter (04.07.1999)', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KinderVornamenAlterKomma', N'Kinder', 1, N'SELECT KinderVornamenAlterKomma = dbo.fnTmKinder( {BaPersonID}, ''VornamenAlter'', 0)', N'Listet alle Vornamen und Alter der Kinder einer Person auf, Komma getrennt, z.B.:  "Markus (16), Ursula (14), Peter (9)"', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KinderVornamenJahrgangKomma', N'Kinder', 1, N'SELECT KinderVornamenJahrgangKomma = dbo.fnTmKinder( {BaPersonID}, ''VornamenJahrgang'', 0)', N'Listet alle Vornamen und Jahrgänge der Kinder einer Person auf, Komma getrennt, z.B.:  "Markus (1995), Ursula (1997), Peter (1999)"', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KinderVornamenKomma', N'Kinder', 1, N'SELECT KinderVornamenKomma = dbo.fnTmKinder( {BaPersonID}, ''Vornamen'', 0)', N'Listet alle Vornamen der Kinder einer Person auf, Komma getrennt, z.B.:  "Markus, Ursula, Peter"', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Klient', N'Klient', 1, N'SELECT <TableColumn>
FROM   vwTmPerson
WHERE  BaPersonID = {BaPersonID}', N'Diverse Textmarken für Klient', N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientBesuchteKurse', N'Klient', 1, N'DECLARE @ChkFieldID1 INT
DECLARE @LblFieldID1 INT
DECLARE @ChkFieldID2 INT
DECLARE @LblFieldID2 INT
DECLARE @ChkFieldID3 INT
DECLARE @LblFieldID3 INT
DECLARE @ChkFieldID4 INT
DECLARE @LblFieldID4 INT
DECLARE @ChkFieldID5 INT
DECLARE @LblFieldID5 INT
DECLARE @ChkFieldID6 INT
DECLARE @LblFieldID6 INT
DECLARE @ChkFieldID7 INT
DECLARE @LblFieldID7 INT
DECLARE @ChkFieldID8 INT
DECLARE @LblFieldID8 INT
DECLARE @ChkFieldID9 INT
DECLARE @LblFieldID9 INT
DECLARE @ChkFieldID10 INT
DECLARE @LblFieldID10 INT

EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildBewerb'', @ChkFieldID1 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''lblBewerbungskurs'', @LblFieldID1 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildInformatik'', @ChkFieldID2 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''lblInformatikkurs'', @LblFieldID2 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildVideo'', @ChkFieldID3 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''lblBildVideo'', @LblFieldID3 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildAllgWissen'', @ChkFieldID4 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''lblBildAllgWissen'', @LblFieldID4 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText1'', @ChkFieldID5 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText1'', @LblFieldID5 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText2'', @ChkFieldID6 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText2'', @LblFieldID6 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText3'', @ChkFieldID7 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText3'', @LblFieldID7 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText4'', @ChkFieldID8 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText4'', @LblFieldID8 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText5'', @ChkFieldID9 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText5'', @LblFieldID9 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''KaQJBildText6'', @ChkFieldID10 OUT
EXEC dbo.spGetDynaFldIDfromTextmarke ''txtKaQJBildText6'', @LblFieldID10 OUT

SELECT	Val1 = CASE WHEN Convert(bit, DV1.Value) = 1 THEN ''- '' + DF1.DisplayText + char(13) + char(10) ELSE '''' END,
  Val2 = CASE WHEN Convert(bit, DV2.Value) = 1 THEN ''- '' + DF2.DisplayText + char(13) + char(10) ELSE '''' END,
  Val3 = CASE WHEN Convert(bit, DV3.Value) = 1 THEN ''- '' + DF3.DisplayText + char(13) + char(10) ELSE '''' END,
  Val4 = CASE WHEN Convert(bit, DV4.Value) = 1 THEN ''- '' + DF4.DisplayText + char(13) + char(10) ELSE '''' END,
  Val5 = CASE WHEN Convert(bit, DV5.Value) = 1 THEN ''- '' + Convert(varchar, DV6.Value) + char(13) + char(10) ELSE '''' END,
  Val6 = CASE WHEN Convert(bit, DV7.Value) = 1 THEN ''- '' + Convert(varchar, DV8.Value) + char(13) + char(10) ELSE '''' END,
  Val7 = CASE WHEN Convert(bit, DV9.Value) = 1 THEN ''- '' + Convert(varchar, DV10.Value) + char(13) + char(10) ELSE '''' END,
  Val8 = CASE WHEN Convert(bit, DV11.Value) = 1 THEN ''- '' + Convert(varchar, DV12.Value) + char(13) + char(10) ELSE '''' END,
  Val9 = CASE WHEN Convert(bit, DV13.Value) = 1 THEN ''- '' + Convert(varchar, DV14.Value) + char(13) + char(10) ELSE '''' END,
  Val10 = CASE WHEN Convert(bit, DV15.Value) = 1 THEN ''- '' + Convert(varchar, DV16.Value) + char(13) + char(10) ELSE '''' END
FROM 	DynaValue DV1	
   LEFT JOIN DynaField DF1 ON DF1.DynaFieldID = @LblFieldID1 	
   LEFT JOIN DynaValue DV2 ON DV2.DynaFieldID = @ChkFieldID2
        AND DV2.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaField DF2 ON DF2.DynaFieldID = @LblFieldID2	
   LEFT JOIN DynaValue DV3 ON DV3.DynaFieldID = @ChkFieldID3
        AND DV3.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaField DF3 ON DF3.DynaFieldID = @LblFieldID3
   LEFT JOIN DynaValue DV4 ON DV4.DynaFieldID = @ChkFieldID4
        AND DV4.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaField DF4 ON DF4.DynaFieldID = @LblFieldID4
   LEFT JOIN DynaValue DV5 ON DV5.DynaFieldID = @ChkFieldID5
        AND DV5.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV6 ON DV6.DynaFieldID = @LblFieldID5
        AND DV6.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV7 ON DV7.DynaFieldID = @ChkFieldID6
        AND DV7.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV8 ON DV8.DynaFieldID = @LblFieldID6
        AND DV8.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV9 ON DV9.DynaFieldID = @ChkFieldID7
        AND DV9.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV10 ON DV10.DynaFieldID = @LblFieldID7
         AND DV10.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV11 ON DV11.DynaFieldID = @ChkFieldID8
         AND DV11.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV12 ON DV12.DynaFieldID = @LblFieldID8
         AND DV12.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV13 ON DV13.DynaFieldID = @ChkFieldID9
         AND DV13.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV14 ON DV14.DynaFieldID = @LblFieldID9
         AND DV14.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV15 ON DV15.DynaFieldID = @ChkFieldID10
         AND DV15.FaLeistungID = DV1.FaLeistungID
   LEFT JOIN DynaValue DV16 ON DV16.DynaFieldID = @LblFieldID10
         AND DV16.FaLeistungID = DV1.FaLeistungID
WHERE	DV1.DynaFieldID = @ChkFieldID1
AND	DV1.FaLeistungID = (SELECT TOP 1 FAL.FaLeistungID
      FROM FaLeistung FAL
      WHERE FAL.BaPersonID = {BaPersonID}
      AND FAL.ModulID = 7
      AND FAL.FaProzessCode = 703
      AND FAL.DatumBis is NULL)', N'Liste der besuchten Kurse in KA QJ Bildung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientGesamterVerlauf', N'Klient', 1, N'declare @FaLeistungID int
declare @DatumFldID int
declare @PartnerFldID int
declare @RTFFldID int
declare @AutorFldID int
declare @StichwortFldID int


set @DatumFldID   = (select DynaFieldID from DynaField where FieldName = ''KaAllgVerlaufDatum'')
set @PartnerFldID = (select DynaFieldID from DynaField where FieldName = ''KaAllgVerlaufKontaktperson'')
set @RTFFldID     = (select DynaFieldID from DynaField where FieldName = ''KaAllgVerlaufInhalt'')
set @AutorFldID = (select DynaFieldID from DynaField where FieldName = ''KaAllgVerlaufAutor'')
set @StichwortFldID = (select DynaFieldID from DynaField where FieldName = ''KaAllgVerlaufStichwort'')


select @FaLeistungID = FAL.FaLeistungID
from FaLeistung FAL
where FAL.ModulID = 7
and FAL.FaProzessCode = 700
and FAL.BaPersonID = {BaPersonID}


select Datum          = ''Datum: '' + convert(varchar,DV1.Value,104) + ''  '',
       Kontaktpartner = ''Kontaktperson: '' + convert(varchar(100),DV2.Value),
       Text1          = char(13) + char(10) + char(13) + char(10),
       Autor	      = ''Autor: '' + isNull(XUR.FirstName, '''') + isNull('' '' + XUR.LastName, ''''),
       Text2          = char(13) + char(10) + char(13) + char(10),
       Stichwort      = ''Stichwort: '' + Convert(varchar, DV5.Value),
       Text3          = char(13) + char(10) + char(13) + char(10),
       InhaltRTF      = DV3.ValueText,
       Text4          = char(13) + char(10) + char(13) + char(10)
from   (select distinct GridRowID from DynaValue where FaLeistungId = @FaLeistungID) GR
       left join DynaValue DV1 on DV1.FaLeistungID = @FaLeistungID and DV1.DynaFieldID = @DatumFldID and DV1.GridRowID = GR.GridRowID
       left join DynaValue DV2 on DV2.FaLeistungID = @FaLeistungID and DV2.DynaFieldID = @PartnerFldID and DV2.GridRowID = GR.GridRowID
       left join DynaValue DV3 on DV3.FaLeistungID = @FaLeistungID and DV3.DynaFieldID = @RTFFldID and DV3.GridRowID = GR.GridRowID
       left join DynaValue DV4 on DV4.FaLeistungID = @FaLeistungID and DV4.DynaFieldID = @AutorFldID and DV4.GridRowID = GR.GridRowID
       left join XUser	   XUR on XUR.UserID = Convert(int, isNull(DV4.Value, -1))
       left join DynaValue DV5 on DV5.FaLeistungID = @FaLeistungID and DV5.DynaFieldID = @StichwortFldID and DV5.GridRowID = GR.GridRowID
where  not (DV1.Value is null and DV2.Value is null and DV3.Value is null)
order by convert(datetime,DV1.Value,104) --GR.GridRowID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientGeschw', N'KlientGeschwister', 1, N'DECLARE @text VARCHAR(MAX);
SET @text = '''';

SELECT @text = @text + <TableColumn> + '', ''
FROM dbo.fnTmGeschwister({BaPersonID}) GES
  INNER JOIN dbo.vwTmPerson            PRS ON PRS.BaPersonID = GES.BaPersonID;

IF (LEN(@text) > 0)
BEGIN
  SELECT SUBSTRING(@text, 0, LEN(@text));
END;', N'Diverse Textmarken für die Geschwister eines Klienten; kommasepariert bei mehreren Geschwistern.', N'vwTmPerson', 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientGeschwister', N'KlientGeschwister', 1, N'SELECT VornameName + '', '' + PRS.Geburtsdatum,
       NewParagraph = NULL
FROM dbo.fnTmGeschwister({BaPersonID}) GES
  INNER JOIN dbo.vwTmPerson            PRS ON PRS.BaPersonID = GES.BaPersonID;', N'Auflistung der Geschwister mit Vorname Name, Geburtsdatum; die ältesten zuoberst.', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientInstitutionen', N'Klient', 1, N'SELECT ORG.Name
  + ISNULL('', '' + ORG.AdressZusatz,'''') 
  + ISNULL('', '' + ORG.StrasseHausNr,'''') 
  + ISNULL('', '' + ORG.PLZOrt,'''') 
  + ISNULL('', '' + ORG.Telefon,''''),         
  NewParagraph = null  
FROM dbo.BaPerson_BaInstitution DPO         
  INNER JOIN vwInstitution			ORG ON ORG.BaInstitutionID = DPO.BaInstitutionID         
WHERE  DPO.BaPersonID = {BaPersonID}
ORDER BY Org.Name', N'Liste der Institutionen, die direkt mit dem Klienten in Bezug stehen', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientInstitutionenAllePersonen', N'Klient', 1, N'SELECT ORG.Name
  + ISNULL('', '' + ORG.AdressZusatz,'''') 
  + ISNULL('', '' + ORG.StrasseHausNr,'''') 
  + ISNULL('', '' + ORG.PLZOrt,'''') 
  + ISNULL('', '' + ORG.Telefon,''''),         
  NewParagraph = NULL  
FROM dbo.BaPerson_BaInstitution DPO         
  INNER JOIN vwInstitution      ORG ON ORG.BaInstitutionID = DPO.BaInstitutionID         
WHERE  DPO.BaPersonID IN (SELECT BaPersonID_2 
                          FROM BaPerson_Relation DRE 
                          WHERE DRE.BaPersonID_1 = {BaPersonID}   
                          UNION          
                          SELECT BaPersonID_1 
                          FROM BaPerson_Relation DRE 
                          WHERE DRE.BaPersonID_2 = {BaPersonID}   
                          UNION          
                          SELECT {BaPersonID})  
ORDER BY Org.Name', N'Liste der Institutionen des ganzen Klientensystems', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientKAErlernterBeruf', N'Klient', 1, N'DECLARE @FieldID1 INT

EXEC dbo.spGetDynaFldIDfromTextmarke ''KaAusbErlerntBeruf'', @FieldID1 OUT

SELECT	Beruf = dbo.fnLOVText(''KaBecoErlernterBeruf'', Convert(VARCHAR, DV1.Value))
FROM 	DynaValue DV1	
WHERE	DV1.DynaFieldID = @FieldID1
AND	DV1.FaLeistungID = (SELECT FAL.FaLeistungID
    FROM FaLeistung FAL
    WHERE BaPersonID = {BaPersonID}
    AND ModulID = 7
    AND FaProzessCode = 700)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientKAVorbildung', N'Klient', 1, N'DECLARE @FieldID1 INT

EXEC dbo.spGetDynaFldIDfromTextmarke ''KaAusbVorb'', @FieldID1 OUT

SELECT	Beruf = dbo.fnLOVText(''KaAusbildungVorbildung'', Convert(VARCHAR, DV1.Value))
FROM 	DynaValue DV1	
WHERE	DV1.DynaFieldID = @FieldID1
AND	DV1.FaLeistungID = (SELECT FAL.FaLeistungID
    FROM FaLeistung FAL
    WHERE BaPersonID = {BaPersonID}
    AND ModulID = 7
    AND FaProzessCode = 700)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientKlientensystem', N'Klient', 1, N'select PRS.Name + isNull('' '' + PRS.Vorname,'''') + '', '' +
       case when DRE.BaPersonID_1 = {BaPersonID}
       then case PRS.GeschlechtCode
            when 1 then DRL.NameMaennlich2
            when 2 then DRL.NameWeiblich2
            else DRL.NameGenerisch2
            end
       else case PRS.GeschlechtCode
            when 1 then DRL.NameMaennlich1
            when 2 then DRL.NameWeiblich1
            else DRL.NameGenerisch1
            end
       end +
       isNull('', '' + PRS.WohnsitzStrasseHausNr,'''') +
       isNull('', '' + PRS.WohnsitzPLZOrt,'''') +
       isNull('', '' + isNull(PRS.Telefon_P,PRS.Telefon_G),''''),
       NewParagraph = null
from   BaPerson_Relation DRE
       left join vwPerson        PRS on (PRS.BaPersonID = DRE.BaPersonID_1 and DRE.BaPersonID_2 = {BaPersonID}) or
                                         (PRS.BaPersonID = DRE.BaPersonID_2 and DRE.BaPersonID_1 = {BaPersonID})
       left join BaRelation      DRL on DRL.BaRelationID = DRE.BaRelationID
where  DRE.BaPersonID_1 = {BaPersonID} or DRE.BaPersonID_2 = {BaPersonID}', N'Name Vorname, Beziehung, TelefonP', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientMutter', N'KlientMutter', 1, N'SELECT TOP 1 VTM.<TableColumn>
FROM BaPerson_Relation   DPR
  INNER JOIN BaPerson    PRS ON PRS.BaPersonID = DPR.BaPersonID_1 AND PRS.GeschlechtCode = 2
  LEFT  JOIN vwTmPerson  VTM ON VTM.BaPersonID = PRS.BaPersonID
WHERE DPR.BaPersonID_2 = {BaPersonID} AND DPR.BaRelationID = 1', NULL, N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientMutterNameVornameWohnsitzOrt', N'KlientMutter', 1, N'SELECT TOP 1 PRS.Name + ISNULL('', '' + PRS.Vorname, '''') + ISNULL('' - '' + ADR.Ort, '''')
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1 AND
                              PRS.GeschlechtCode = 2
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID AND
                              ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientMutterPLZOrt', N'KlientMutter', 1, N'SELECT TOP 1 ISNULL(ADR.PLZ + '' '', '''') + ADR.Ort
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1 AND
                              PRS.GeschlechtCode = 2
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID AND
                              ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientMutterStrasseNr', N'KlientMutter', 1, N'SELECT TOP 1 ADR.Strasse + ISNULL('' '' + ADR.HausNr, '''')
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1
                          AND PRS.GeschlechtCode = 2
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID
                          AND ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientUnterstuetztePersonen', N'Klient', 1, N'DECLARE @BaPersonID INT;
SET @BaPersonID = {BaPersonID};

DECLARE @Personen TABLE (
  Name VARCHAR(100) NOT NULL
);

INSERT INTO @Personen
  SELECT Vorname + '' '' + Name
  FROM dbo.BaPerson WITH (READUNCOMMITTED)
  WHERE BaPersonID = @BaPersonID
UNION ALL
  SELECT DISTINCT PRS.Vorname + '' '' + PRS.Name
  FROM dbo.BaPerson                     PRS WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaPerson_Relation    REL WITH (READUNCOMMITTED)
                                         ON (REL.BaPersonID_1 = PRS.BaPersonID AND
                                             REL.BaPersonID_2 = @BaPersonID)
                                         OR (REL.BaPersonID_2 = PRS.BaPersonID AND
                                             REL.BaPersonID_1 = @BaPersonID)
    LEFT JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED)
                                         ON FPP.BaPersonID = PRS.BaPersonID
    LEFT JOIN dbo.BgFinanzplan          FPL WITH (READUNCOMMITTED)
                                         ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
  WHERE PRS.Unterstuetzt = 1
     OR (FPP.IstUnterstuetzt = 1 AND ISNULL(FPL.DatumBis, ''99990101'') > GETDATE());

DECLARE @Result VARCHAR(5000);
SET @Result = '''';
SELECT @Result = @Result + Name + '', ''
FROM @Personen;

IF (LEN(@Result) > 2)
BEGIN
  SELECT SUBSTRING(@Result, 0, LEN(@Result));
END;', N'Vorname Name aller unterstützten Personen (inkl. Fallträger)', NULL, 1, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientVater', N'KlientVater', 1, N'SELECT TOP 1 VTM.<TableColumn>
FROM BaPerson_Relation   DPR
  INNER JOIN BaPerson    PRS ON PRS.BaPersonID = DPR.BaPersonID_1 AND PRS.GeschlechtCode = 1
  LEFT  JOIN vwTmPerson  VTM ON VTM.BaPersonID = PRS.BaPersonID
WHERE DPR.BaPersonID_2 = {BaPersonID} AND DPR.BaRelationID = 1', NULL, N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientVaterNameVornameWohnsitzOrt', N'KlientVater', 1, N'SELECT TOP 1 PRS.Name + ISNULL('', '' + PRS.Vorname, '''') + ISNULL('' - '' + ADR.Ort, '''')
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1
                          AND PRS.GeschlechtCode = 1
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID
                          AND ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientVaterPLZOrt', N'KlientVater', 1, N'SELECT TOP 1 ISNULL(ADR.PLZ + '' '', '''') + ADR.Ort
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1
                          AND PRS.GeschlechtCode = 1
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID
                          AND ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KlientVaterStrasseNr', N'KlientVater', 1, N'SELECT TOP 1 ADR.Strasse + ISNULL('' '' + ADR.HausNr,'''')
FROM BaPerson_Relation BPR
  INNER JOIN BaPerson  PRS ON PRS.BaPersonID = BPR.BaPersonID_1
                          AND PRS.GeschlechtCode = 1
  LEFT  JOIN BaAdresse ADR ON ADR.BaPersonID = PRS.BaPersonID
                          AND ADR.AdresseCode = 1
WHERE BPR.BaPersonid_2 = {BaPersonID}
  AND BPR.BaRelationID = 1
ORDER BY ADR.DatumVon DESC;', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KontaktpersonAdresseMehrzeilig', N'Kontaktperson', 1, N'if {KontaktID} > 1
  select OKO.Vorname + '' '' + OKO.Name + char(13) + char(10) +
   isNull(ORG.AdressZusatz + char(13) + char(10),'''') +
         isNull(ORG.StrasseHausNr + char(13) + char(10),'''') +
         isNull(ORG.PLZOrt, '''')	
  from   BaInstitutionKontakt OKO
   left join vwInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID
  where OKO.BaInstitutionKontaktID = {KontaktID}
else if {KontaktID} between -199999 and -100000
  select PRS.Vorname + '' '' + PRS.Name + char(13) + char(10) +
         isNull(PRS.WohnsitzAdressZusatz + char(13) + char(10),'''') +
         isNull(PRS.WohnsitzStrasseHausNr + char(13) + char(10),'''') +
         isNull(PRS.WohnsitzPLZOrt, '''')
  from   vwPerson PRS
  where  PRS.BaPersonID = - {KontaktID} - 100000
else
  select USR.Firstname + '' '' + USR.Lastname + char(13) + char(10),
   AdressatRTF = OUN.Adressat
  from   XUser USR
  left join XOrgUnit_User OUU on OUU.UserID = USR.UserID AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  left join XOrgUnit OUN on OUN.OrgUnitID = OUU.OrgUnitID
  where  USR.UserID = - {KontaktID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KontaktpersonGeehrterFrauHerr', N'Kontaktperson', 1, N'if {KontaktID} > 1
  select case
         when OKO.Anrede like ''%frau%'' then ''Sehr geehrte Frau ''
         when OKO.Anrede like ''%herr%'' then ''Sehr geehrter Herr ''
         else ''Sehr geehrte/r Frau/Herr ''
         end +
         OKO.Name
  from   BaInstitutionKontakt OKO	
  where  OKO.BaInstitutionKontaktID = {KontaktID}
else if {KontaktID} between -199999 and -100000
  select case PRS.GeschlechtCode
         when 1 then ''Sehr geehrter Herr ''
         when 2 then ''Sehr geehrte Frau ''
         else ''Sehr geehrte/-r Frau/Herr ''
         end +
   PRS.Name
  from   BaPerson PRS	
  where  PRS.BaPersonID = - {KontaktID} - 100000
else
  select case USR.GenderCode
         when 1 then ''Sehr geehrter Herr ''
         when 2 then ''Sehr geehrte Frau ''
         else ''Sehr geehrte/-r Frau/Herr ''
         end +
   USR.LastName
  from   XUser USR
  where  USR.UserID = - {KontaktID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Pro', N'Vermittlung', 1, N'SELECT <TableColumn>
FROM   vwTmVermittlungProfil
WHERE  KaVermittlungProfilID = {KaVermittlungProfilId}', N'Div. Textmarken für Vermittlung Profil (QJ, BI, BIP, SI)
Nur verwendbar in den Masken Vermittlungsprofil!', N'vwTmVermittlungProfil', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VereinbarungAbmachungen', N'Vereinbarung', 1, N'select QJV.Abmachungen
from   KaQJVereinbarung QJV
where  QJV.KaQJVereinbarungID = {KaQJVereinbarungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VereinbarungGrundZiel', N'Vereinbarung', 1, N'select QJV.GrundZiel
from   KaQJVereinbarung QJV
where  QJV.KaQJVereinbarungID = {KaQJVereinbarungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Vermittlung', N'Vermittlung', 1, N'SELECT <TableColumn>
FROM dbo.vwTmKaVermittlung
WHERE BaPersonID = {BaPersonID};', N'Diverse Textmarken für KA Vermittlung.
Allgemein verwendbar (Liefert nur Daten von aktiven Leistungen).', N'vwTmKaVermittlung', 7, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAbkAntraegeWOH', N'Vormundschaft', 1, N'SELECT NEXTCELL = NULL, V01.Value, NEXTCELL = NULL, IsNull(CONVERT(varchar(2000), XLC.Value1) + '' '', ''''), V02.Value, NEXTCELL = NULL
FROM dbo.fnDynaValue_GridRowID(''Vm_Massnahme_Abklärung_Bericht_Antrag'', {FaLeistungID}, NULL)  ROW
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkNrAntrag'', {FaLeistungID}, NULL)                       V01 ON V01.GridRowID = ROW.GridRowID
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkAntrag'', {FaLeistungID}, NULL)                         V02 ON V02.GridRowID = ROW.GridRowID
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkAntragStandart'', {FaLeistungID}, NULL)                 V03 ON V03.GridRowID = ROW.GridRowID
  LEFT JOIN XLOVCode                                                                           XLC ON XLC.LOVName = ''VmAbkAntragStandart'' AND XLC.Code = CONVERT(int, V03.Value)
ORDER BY V01.Value', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAbkErwaegungWOH', N'Vormundschaft', 1, N'SELECT NEXTCELL = NULL, V01.Value, NEXTCELL = NULL, IsNull(CONVERT(varchar(2000), XLC.Value1) + '' '', ''''), V02.Value, NEXTCELL = NULL
FROM dbo.fnDynaValue_GridRowID(''Vm_Massnahme_Abklärung_Behördliches_Erw'', {FaLeistungID}, NULL)  ROW
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkNrErwägung'', {FaLeistungID}, NULL)                       V01 ON V01.GridRowID = ROW.GridRowID
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkErwägung'', {FaLeistungID}, NULL)                         V02 ON V02.GridRowID = ROW.GridRowID
  LEFT JOIN dbo.fnDynaValue_Value(''VmAbkErwägungStandart'', {FaLeistungID}, NULL)                 V03 ON V03.GridRowID = ROW.GridRowID
  LEFT JOIN XLOVCode                                                                         XLC ON XLC.LOVName = ''VmAbkStandartErwägung'' AND XLC.Code = CONVERT(int, V03.Value)
ORDER BY V01.Value', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAbkInvolPersWOH', N'Vormundschaft', 1, N'SELECT Name, '', '' + Vorname, '', '' + convert(varchar, Geburtsdatum, 104), '', '' + Heimatort, '', '' + ZIV.Text, NEXTCELL = NULL, NEXTCELL = NULL
FROM dbo.fnDynaValue_Value(''VmAbkInvolPers'', {FaLeistungID}, NULL)  VAL
  INNER JOIN vwPerson     PRS ON '','' + CONVERT(varchar(500), VAL.Value) + '','' LIKE ''%,'' + CONVERT(varchar, PRS.BaPersonID) + '',%''
  LEFT  JOIN dbo.XLOVCode ZIV WITH (READUNCOMMITTED) ON ZIV.LOVName = ''Zivilstand'' AND ZIV.Code = PRS.ZivilstandCode', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAdoptionBesprAlle', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = ''Datum: '' + CONVERT(VARCHAR(10), AKT.Datum, 104),
  Kontaktpartner = ''Kontaktpartner: '' + AKT.Kontaktpartner,
  Text1 = char(13) + char(10) + char(13) + char(10),
  AKT.InhaltRTF,
  Text2 = char(13) + char(10) + char(13) + char(10)
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', N'Alle Besprechungen der aktuellen Maske
Kolonnen: Datum, Kontaktpartner, Inhalt', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAdoptionBesprAlleTabelle', N'Fallführung', 1, N'declare @DatumVon datetime
declare @DatumBis datetime
declare @Stichwort varchar(200)

set @DatumVon = NULL
set @DatumBis = NULL
set @Stichwort = NULL

IF {SEARCHDATUMVON} != N''0'' SET @DatumVon = CONVERT(DATETIME, {SEARCHDATUMVON})
IF {SEARCHDATUMBIS} != N''0'' SET @DatumBis = CONVERT(DATETIME, {SEARCHDATUMBIS})
IF {SEARCHSTICHWORT} != N''0'' SET @Stichwort = CONVERT(varchar(200), {SEARCHSTICHWORT})

SELECT
  Datum = CONVERT(VARCHAR(10), AKT.Datum, 104),
  NextCell = null,
  AKT.Kontaktpartner,
  NextCell = null,
  AKT.InhaltRTF,
  NextCell = null
FROM dbo.FaAktennotizen AKT
WHERE AKT.FaLeistungID = {FaLeistungID}
  AND (dbo.fnXCodeListsHaveMatch(AKT.FaThemaCodes, {ThemenFilter}) = 1 OR {FilterAktiv} = 0)
  AND (({SEARCHDELETEDFILTER} = CONVERT(INT, AKT.IsDeleted)) OR 
        {SEARCHDELETEDFILTER} = 2)
  AND (@DatumVon IS NULL OR AKT.Datum >= @DatumVon)
  AND (@DatumBis IS NULL OR AKT.Datum <= @DatumBis)
  AND ({SEARCHKONTAKTART} = 0 OR AKT.FaKontaktartCode = {SEARCHKONTAKTART})
  AND ({SEARCHUSERID} = 0 OR AKT.UserID = {SEARCHUSERID})
  AND (@Stichwort IS NULL OR AKT.Stichwort LIKE @Stichwort)
ORDER BY AKT.FaAktennotizID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAntragEKSK', N'Vormundschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmAntragEKSK
WHERE VmAntragEKSKID = {VmAntragEKSKID}', N'Diverse Textmarken für Antrag EKSK', N'vwTmVmAntragEKSK', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAuftragStatEltsorgeAktuell', N'Vormundschaft', 1, N'DECLARE @FieldID1 INT
EXEC dbo.spGetDynaFldIDfromTextmarke ''VmAuftragStatEltSorge'', @FieldID1 OUT

SELECT dbo.fnLOVText(''VmStatEltSorge'', CONVERT(INT, IsNull(DV1.Value, 0)))
FROM   dbo.DynaValue DV1 WITH (READUNCOMMITTED)
WHERE  DV1.DynaFieldID = @FieldID1
AND	   DV1.FaLeistungID = (SELECT TOP 1 FaLeistungID
                           FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           WHERE  LEI.BaPersonID = {BaPersonID}
                           AND    LEI.ModulID = 5
                           AND    LEI.FaProzessCode = 505
                           ORDER BY LEI.DatumVon DESC)', N'Es wird der aktuellste Auftrag Jugendamt berücksichtigt!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmAuftragStatObhutAktuell', N'Vormundschaft', 1, N'DECLARE @FieldID1 INT
EXEC dbo.spGetDynaFldIDfromTextmarke ''VmAuftragStatObhut'', @FieldID1 OUT

SELECT dbo.fnLOVText(''VmStatObhut'', CONVERT(INT, IsNull(DV1.Value, 0)))
FROM   dbo.DynaValue DV1 WITH (READUNCOMMITTED)
WHERE  DV1.DynaFieldID = @FieldID1
AND	   DV1.FaLeistungID = (SELECT TOP 1 FaLeistungID
                           FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                           WHERE  LEI.BaPersonID = {BaPersonID}
                           AND    LEI.ModulID = 5
                           AND    LEI.FaProzessCode = 505
                           ORDER BY LEI.DatumVon DESC)', N'Es wird der aktuellste Auftrag Jugendamt berücksichtigt!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErb', N'Erbschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmErblasser
WHERE FaLeistungID = {FaLeistungID};', N'Diverse Textmarken für Erblasser', N'vwTmErblasser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbDienstNotar', N'Erbschaft', 1, N'SELECT TOP 1 ORG.Name
FROM VmErbschaftsdienst VED
  LEFT JOIN BaInstitution ORG on ORG.BaInstitutionID = VED.InventarNotarID
WHERE FaLeistungID = {FaLeistungID}
AND VED.InventarNotarID IS NOT NULL
ORDER BY VmErbschaftsdienstID DESC', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbEaErben', N'Erbschaft', 1, N'select Code         = ErbCodierung,
       NextCell     = null,
       Text         = IsNull(isNull(Titel, Titel2) + '', '', '''') +
                      isnull(Anrede + '' '','''') + isnull(Vornamen + '' '','''') + isnull(FamilienNamen,'''') +
                      isnull('', geb. '' + Geburtsdatum,'''') +
                      isnull('', '' + Strasse,'''') + isnull('', '' + Ort,'''') + isnull('', '' + Land,'''') +
                      isnull('', '' + Ergaenzung,''''),
       NextCell     = null,
       Anteil       = convert(varchar,ErbanteilDividend) + ''/'' + convert(varchar,ErbanteilDivisor),
       NextCell     = null
from   VmErbe
where  VmErbschaftsdienstID = {VmErbschaftsdienstID}
order by Position', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdBezirkNr', N'Erbschaft', 1, N'select BezirkNr
from   VmSiegelung
where  VmSiegelungID = {VmSiegelungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdErben', N'Erbschaft', 1, N'select DelNextField = null,
       Style    = ''KissErbenLevel'' + convert(varchar,isnull(Level,0)),
       Text     = isNull(Titel,
                  isnull(Anrede + '' '','''') + isnull(Vornamen + '' '','''') + isnull(FamilienNamen,'''') +
                  isnull('', '' + Geburtsdatum,'''') +
                  isnull('', '' + Strasse,'''') + isnull('', '' + Ort,'''') + isnull('', '' + Land,'''') +
                  isnull('', '' + Ergaenzung,'''')),
       NextCell = null
from   VmErbe
where  VmSiegelungID = {VmSiegelungID}
order by Position', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdErben2', N'Erbschaft', 1, N'select Style    = ''KissErbenLevel'' + convert(varchar,isnull(Level,0)),
       Text     = isNull(Titel,
                  isnull(Anrede + '' '','''') + isnull(Vornamen + '' '','''') + isnull(FamilienNamen,'''') +
                  isnull('', '' + Geburtsdatum,'''') +
                  isnull('', '' + Strasse,'''') + isnull('', '' + Ort,'''') + isnull('', '' + Land,'''') +
                  isnull('', '' + Ergaenzung,'''')),
       NextCell = null
from   VmErbe
where  VmSiegelungID = {VmSiegelungID}
order by Position', N'wie VmErbSdErben, aber ohne überschreiben einer vorgegebenen Tabelle', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdErledigt', N'Erbschaft', 1, N'select Sdabgeschlossen
from   VmSiegelung
where  VmSiegelungID = {VmSiegelungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdKontrollNr', N'Erbschaft', 1, N'select top 1
       isnull(convert(varchar,BezirkNr),''?'') + ''-'' +
       isnull(convert(varchar,LaufNr),''???'') + ''-'' +
       isnull(right(convert(varchar,Jahr),2),''????'')
from   FaLeistung FAL
       inner join VmSiegelung SIE on SIE.FaLeistungID = FAL.FaLeistungID
where  FAL.FaLeistungID = {FaLeistungID}
order by FAL.DatumVon desc, SIE.Siegelungsdatum desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbSdNotar', N'Erbschaft', 1, N'SELECT TOP 1 ORG.Name
FROM VmSiegelung VSD
  LEFT JOIN BaInstitution ORG on ORG.BaInstitutionID = VSD.NotarID
WHERE FaLeistungID = {FaLeistungID}
AND VSD.NotarID IS NOT NULL
ORDER BY VmSiegelungID DESC', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdErben', N'Erbschaft', 1, N'select Status       = TestamentEroeffnungStatus,
       NextCell     = null,
       Nr           = TestamentEroeffnungNr,
       NextCell     = null,
       Text         = isNull(Titel,
                      isnull(Anrede + '' '','''') + isnull(Vornamen + '' '','''') + isnull(FamilienNamen,'''') +
                      isnull('', '' + Geburtsdatum,'''') +
                      isnull('', '' + Strasse,'''') + isnull('', '' + Ort,'''') + isnull('', '' + Land,'''') +
                      isnull('', '' + Ergaenzung,'''') +
                      isnull(char(13) + char(10) + ''Zustelladresse: '' + Kontaktadresse,'''')),
       NextCell     = null,
       Versanddatum = convert(varchar,TestamentEroeffnungVersandDatum,104),
       NextCell     = null,
       Versandart   = TestamentEroeffnungVersandart,
       NextCell     = null
from   VmErbe
where  VmTestamentID = {VmTestamentID}
order by Position', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdEroeffnungAbgeschlossen', N'Erbschaft', 1, N'SELECT CONVERT(VARCHAR, EroeffnungAbgeschlossenDatum, 104)
FROM   VmTestament
WHERE  VmTestamentID = {VmTestamentID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdKopieAn', N'Erbschaft', 1, N'select KopieAnCodes
from   VmTestament
where  VmTestamentID = {VmTestamentID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLaufNr', N'Erbschaft', 1, N'select LaufNr
from   VmTestament
where  FaLeistungID = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLaufNrBesch', N'Erbschaft', 1, N'select LaufNr
from   VmTestament
where  VmTestamentID = {VmTestamentID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungen', N'Erbschaft', 1, N'select Datum        = convert(varchar,VerfuegungsDatum,104),
       NextCell     = null,
       Eroeffnet    = convert(varchar,EroeffnungsDatum,104),
       NextCell     = null,
       Text         = VerfuegungText,
       NextCell     = null,
       NextCell     = null,
       NextCell     = null
from   VmTestamentVerfuegung
where  VmTestamentID = (SELECT VTM.VmTestamentID FROM VmTestament VTM WHERE VTM.FaLeistungID = {FaLeistungID})
order by VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenAnzSeiten', N'Erbschaft', 1, N'SELECT AnzSeiten
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = (SELECT VTM.VmTestamentID FROM VmTestament VTM WHERE VTM.FaLeistungID = {FaLeistungID})
ORDER BY VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenAnzSeitenBesch', N'Erbschaft', 1, N'SELECT SUM(AnzSeiten)
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = {VmTestamentID}
', NULL, NULL, 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenBesch', N'Erbschaft', 1, N'select Datum        = convert(varchar,VerfuegungsDatum,104),
       NextCell     = null,
       Eroeffnet    = convert(varchar,EroeffnungsDatum,104),
       NextCell     = null,
       Text         = VerfuegungText,
       NextCell     = null,
       NextCell     = null,
       NextCell     = null
from   VmTestamentVerfuegung VTV
where  VTV.VmTestamentID = {VmTestamentID}
order by VTV.VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenEroeffnung', N'Erbschaft', 1, N'SELECT CONVERT(VARCHAR, EroeffnungsDatum, 104)
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = (SELECT VTM.VmTestamentID FROM VmTestament VTM WHERE VTM.FaLeistungID = {FaLeistungID})
ORDER BY VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenEroeffnungBesch', N'Erbschaft', 1, N'SELECT CONVERT(VARCHAR, EroeffnungsDatum, 104)
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = {VmTestamentID}
ORDER BY VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenVerfuegung', N'Erbschaft', 1, N'SELECT CONVERT(VARCHAR, VerfuegungsDatum, 104)
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = (SELECT VTM.VmTestamentID FROM VmTestament VTM WHERE VTM.FaLeistungID = {FaLeistungID})
ORDER BY VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErbTdLetztwVerfuegungenVerfuegungBesch', N'Erbschaft', 1, N'SELECT CONVERT(VARCHAR, VerfuegungsDatum, 104)
FROM   VmTestamentVerfuegung
WHERE  VmTestamentID = {VmTestamentID}
ORDER BY VerfuegungsDatum', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmErnennungsDatum', N'Vormundschaft', 1, N'select convert(varchar,Ernennung,104)
from   VmErnennung
where  VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmGefaehrdungsMeldung', N'Vormundschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmGefaehrdungsMeldung
WHERE VmGefaehrdungsMeldungID = {VmGefaehrdungsMeldungID}', N'Diverse Textmarken für Gefährdungsmeldungen', N'vwTmVmGefaehrdungsMeldung', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmJugendStatEltsorge_Test', N'Vormundschaft', 1, N'DECLARE @FieldID1 INT
EXEC dbo.spGetDynaFldIDfromTextmarke ''VmAuftragStatEltSorge'', @FieldID1 OUT

SELECT dbo.fnLOVTextListe(''VmStatEltSorge'', Convert(VARCHAR(100), DV1.Value))
FROM FaLeistung LEI
  LEFT JOIN DynaValue DV1 ON DV1.DynaFieldID = @FieldID1 AND DV1.FaLeistungID = LEI.FaLeistungID
WHERE LEI.FaProzessCode = 505
AND LEI.BaPersonID = {BaPersonID}', N'Nur für Testzweck!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmJugendStatObhut_Test', N'Vormundschaft', 1, N'DECLARE @FieldID1 INT
EXEC dbo.spGetDynaFldIDfromTextmarke ''VmAuftragStatObhut'', @FieldID1 OUT

SELECT dbo.fnLOVTextListe(''VmStatObhut'', Convert(VARCHAR(100), DV1.Value))
FROM FaLeistung LEI
  LEFT JOIN DynaValue DV1 ON DV1.DynaFieldID = @FieldID1 AND DV1.FaLeistungID = LEI.FaLeistungID
WHERE LEI.FaProzessCode = 505
AND LEI.BaPersonID = {BaPersonID}', N'Nur für Testzweck!', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteBerPeriodeBis', N'Vormundschaft', 1, N'select top 1 convert(varchar,BER.BerichtsperiodeBis,104)
from   VmBericht BER
       inner join FaLeistung FAL on FAL.FaLeistungID = BER.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by BER.BerichtsperiodeBis desc', N'Letzte (jüngste) Berichtsperiode: Datum bis', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteBerPeriodeEntsch', N'Vormundschaft', 1, N'SELECT TOP 1 CONVERT(varchar,BER.Entschaedigung)
  FROM   VmBericht BER
         INNER JOIN FaLeistung FAL ON FAL.FaLeistungID = BER.FaLeistungID
  WHERE  FAL.BaPersonID = {BaPersonID}
  ORDER BY BER.BerichtsperiodeBis DESC', N'Letzte (jüngste) Berichtsperiode: Entschädigung', NULL, 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteBerPeriodeVon', N'Vormundschaft', 1, N'select top 1 convert(varchar,BER.BerichtsperiodeVon,104)
from   VmBericht BER
       inner join FaLeistung FAL on FAL.FaLeistungID = BER.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by BER.BerichtsperiodeVon desc', N'Letzte (jüngste) Berichtsperiode: Datum von', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeAufhebung', N'Vormundschaft', 1, N'select top 1 convert(varchar,MAS.DatumBis,104)
from   VmMassnahme MAS
       inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by MAS.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeBeschlussVom', N'Vormundschaft', 1, N'select top 1 convert(varchar,MAS.DatumVon,104)
from   VmMassnahme MAS
       inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by MAS.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTAHVNummer', N'Vormundschaft', 1, N'SELECT VPM.AHVNummer
FROM dbo.VmMassnahme         VMN WITH (READUNCOMMITTED)
  LEFT  JOIN dbo.VmErnennung VEN WITH (READUNCOMMITTED) 
                          ON VEN.VmMassnahmeID = VMN.VmMassnahmeID
                         AND VEN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                  FROM VmErnennung
                                                  WHERE  VmMassnahmeID = VMN.VmMassnahmeID
                                                  ORDER BY Ernennung DESC)
  LEFT  JOIN dbo.VmPriMa     VPM  WITH (READUNCOMMITTED)
                          ON VPM.VmPriMaID = VEN.VmPriMaID
WHERE VMN.VmMassnahmeID = (SELECT TOP 1 MAS.VmMassnahmeID
                           FROM VmMassnahme MAS
                             INNER JOIN FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
                           WHERE  FAL.BaPersonID = {BaPersonID}
                           ORDER BY MAS.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTEmail', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then USR.EMail
       else VPM.EMail
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTErnennung', N'Vormundschaft', 1, N'select convert(varchar,VEN.Ernennung,104)
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTGeburtsdatum', N'Vormundschaft', 1, N'SELECT VPM.Geburtsdatum
FROM dbo.VmMassnahme         VMN WITH (READUNCOMMITTED)
  LEFT  JOIN dbo.VmErnennung VEN WITH (READUNCOMMITTED) 
                          ON VEN.VmMassnahmeID = VMN.VmMassnahmeID
                         AND VEN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                  FROM VmErnennung
                                                  WHERE  VmMassnahmeID = VMN.VmMassnahmeID
                                                  ORDER BY Ernennung DESC)
  LEFT  JOIN dbo.VmPriMa     VPM  WITH (READUNCOMMITTED)
                          ON VPM.VmPriMaID = VEN.VmPriMaID
WHERE VMN.VmMassnahmeID = (SELECT TOP 1 MAS.VmMassnahmeID
                           FROM VmMassnahme MAS
                             INNER JOIN FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
                           WHERE  FAL.BaPersonID = {BaPersonID}
                           ORDER BY MAS.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTNachname', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then USR.LastName
       else VPM.Name
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTName', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then isnull(USR.FirstName + '' '','''') + USR.LastName
       else isnull(VPM.Vorname + '' '','''') + VPM.Name
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTPLZOrt', N'Vormundschaft', 1, N'select isNull(ADR.PLZ + '' '','''') + ADR.Ort
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTStrasseNr', N'Vormundschaft', 1, N'select ADR.Strasse + isNull('' '' + ADR.HausNr,'''')
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTTelefonG', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then USR.Phone
       else VPM.Telefon_G
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTTelefonMobil', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then null
       else VPM.MobilTel
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTTelefonP', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then null
       else VPM.Telefon_P
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
       left  join BaAdresse       ADR  on ADR.VmPriMaID = VPM.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTVersichertennummer', N'Vormundschaft', 1, N'SELECT VPM.Versichertennummer
FROM dbo.VmMassnahme         VMN WITH (READUNCOMMITTED)
  LEFT  JOIN dbo.VmErnennung VEN WITH (READUNCOMMITTED) 
                          ON VEN.VmMassnahmeID = VMN.VmMassnahmeID
                         AND VEN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                  FROM VmErnennung
                                                  WHERE  VmMassnahmeID = VMN.VmMassnahmeID
                                                  ORDER BY Ernennung DESC)
  LEFT  JOIN dbo.VmPriMa     VPM  WITH (READUNCOMMITTED)
                          ON VPM.VmPriMaID = VEN.VmPriMaID
WHERE VMN.VmMassnahmeID = (SELECT TOP 1 MAS.VmMassnahmeID
                           FROM VmMassnahme MAS
                             INNER JOIN FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
                           WHERE  FAL.BaPersonID = {BaPersonID}
                           ORDER BY MAS.DatumVon DESC)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeMTVorname', N'Vormundschaft', 1, N'select case when USR.UserID is not null
       then isnull(USR.FirstName,'''')
       else isnull(VPM.Vorname,'''')
       end
from   VmMassnahme VMN
       left  join VmErnennung      VEN  on VEN.VmMassnahmeID = VMN.VmMassnahmeID and
                                           VEN.VmErnennungID = (select top 1 VmErnennungID
                                                                from   VmErnennung
                                                                where  VmMassnahmeID = VMN.VmMassnahmeID
                                                                order by Ernennung desc)
       left  join XUser            USR  on USR.UserID = VEN.UserID
       left  join VmPriMa          VPM  on VPM.VmPriMaID = VEN.VmPriMaID
where  VMN.VmMassnahmeID =
         (select top 1 MAS.VmMassnahmeID
          from   VmMassnahme MAS
                 inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
          where  FAL.BaPersonID = {BaPersonID}
          order by MAS.DatumVon desc)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeZGBArtikel', N'Vormundschaft', 1, N'select top 1 Replace(dbo.fnLOVTextListe(''VmZGB'',MAS.ZGBCodes),'' ZGB'','''')
from   VmMassnahme MAS
       inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by MAS.DatumVon desc', N'Artikelnummern der ZGB Artikel der lezten (=jüngsten) Massnahme (es können mehrere sein)
Kontext: alle Masken mit aktuellem Klient (zB. Korrespondenz)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmLetzteMassnahmeZGBBez', N'Vormundschaft', 1, N'declare @Codes varchar(100)

select top 1 @Codes = MAS.ZGBCodes
from   VmMassnahme MAS
       inner join FaLeistung FAL on FAL.FaLeistungID = MAS.FaLeistungID
where  FAL.BaPersonID = {BaPersonID}
order by MAS.DatumVon desc

if @Codes is null
  select null
else begin
  declare @Code  varchar(5)
  declare @Text  varchar(100)
  declare @Liste varchar(1000)
  declare @Idx   int

  set @Liste = ''''
  set @Idx = 1
  while @Idx <= LEN(@Codes) begin
    -- nicht numerische Zeichen überspringen
    while @Idx <= LEN(@Codes) and not substring(@Codes,@Idx,1) between ''0'' and ''9'' begin
      set @Idx = @Idx + 1
    end

    -- Code aufbauen
    set @Code = ''''
    while @Idx <= len(@Codes) and substring(@Codes,@Idx,1) between ''0'' and ''9'' begin
      set @Code = @Code + substring(@Codes,@Idx,1)
      set @Idx = @Idx + 1
    end

    if @Code <> '''' begin
      select @Text = Value1 from XLOVCode where LOVName = ''VmZGB'' and Code = convert(int,@Code)
      if @Text is not null begin
        if @Liste <> '''' set @Liste = @Liste + '',''
        set @Liste = @Liste + @Text
      end
    end
  end
  select @Liste
end', N'Bezeichnungen der ZGB Artikel der lezten (=jüngsten) Massnahme (es können mehrere sein)
Kontext: alle Masken mit aktuellem Klient (zB. Korrespondenz)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerAHVNummer', N'Vormundschaft', 1, N'SELECT PMA.AHVNummer
FROM dbo.VmErnennung     ERN WITH (READUNCOMMITTED)
  INNER JOIN dbo.VmPriMa PMA WITH (READUNCOMMITTED) ON PMA.VmPrimaID = ERN.VmPrimaID
WHERE VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerAnrede', N'Vormundschaft', 1, N'SELECT CASE WHEN ERN.VmPrimaID IS NULL
            THEN CASE USR.GenderCode
                      WHEN 1 THEN ''Herr''
                      WHEN 2 THEN ''Frau''
                      ELSE ''''
                 END
            ELSE PMA.Titel
            END
FROM FaLeistung FAL
INNER JOIN VmMassnahme MSN ON MSN.FaLeistungID = FAL.FaLeistungID
                              AND MSN.VmMassnahmeID = (SELECT TOP 1 MAS.VmMassnahmeID
                   FROM   VmMassnahme MAS
                                                       INNER JOIN FaLeistung FAL ON FAL.FaLeistungID = MAS.FaLeistungID
                                                       WHERE  FAL.FaLeistungID = {FaLeistungID}
                                                       ORDER BY MAS.DatumVon DESC)
INNER JOIN VmErnennung ERN ON ERN.VmMassnahmeID = MSN.VmMassnahmeID
            AND ERN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                                FROM   VmErnennung
                                                                WHERE  VmMassnahmeID = MSN.VmMassnahmeID
                                                                ORDER BY Ernennung DESC)
LEFT JOIN VmPriMa PMA on PMA.VmPrimaID = ERN.VmPrimaID
LEFT JOIN XUser   USR on USR.UserID = ERN.UserID
WHERE FAL.FaLeistungid  = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerGeburtsdatum', N'Vormundschaft', 1, N'SELECT PMA.Geburtsdatum
FROM dbo.VmErnennung     ERN WITH (READUNCOMMITTED)
  INNER JOIN dbo.VmPriMa PMA WITH (READUNCOMMITTED) ON PMA.VmPrimaID = ERN.VmPrimaID
WHERE VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerName', N'Vormundschaft', 1, N'select case when ERN.VmPrimaID is null
       then USR.LastName
       else PMA.Name
       end
from   VmErnennung ERN
       left join VmPriMa PMA on PMA.VmPrimaID = ERN.VmPrimaID
       left join XUser   USR on USR.UserID = ERN.UserID
where  VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerVersichertennummer', N'Vormundschaft', 1, N'SELECT PMA.Versichertennummer
FROM dbo.VmErnennung     ERN WITH (READUNCOMMITTED)
  INNER JOIN dbo.VmPriMa PMA WITH (READUNCOMMITTED) ON PMA.VmPrimaID = ERN.VmPrimaID
WHERE VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerVorname', N'Vormundschaft', 1, N'select case when ERN.VmPrimaID is null
       then USR.FirstName
       else PMA.Vorname
       end
from   VmErnennung ERN
       left join VmPriMa PMA on PMA.VmPrimaID = ERN.VmPrimaID
       left join XUser   USR on USR.UserID = ERN.UserID
where  VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatstraegerVornameName', N'Vormundschaft', 1, N'select case when ERN.VmPrimaID is null
       then isNull(USR.FirstName + '' '','''') + USR.LastName
       else isNull(PMA.Vorname + '' '','''') + PMA.Name
       end
from   VmErnennung ERN
       left join VmPriMa PMA on PMA.VmPrimaID = ERN.VmPrimaID
       left join XUser   USR on USR.UserID = ERN.UserID
where  VmErnennungID = {VmErnennungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandatsträgerSehrGeehrteFrauHerr', N'Vormundschaft', 1, N'SELECT CASE WHEN ERN.VmPrimaID IS NULL
            THEN CASE USR.GenderCode
                      WHEN 1 THEN ''geehrter Herr''
                      WHEN 2 THEN ''geehrte Frau''
                      ELSE ''geehrte/-r Frau/Herr''
                 END
            ELSE CASE PMA.Titel
                      WHEN ''Herr'' THEN ''geehrter Herr''
                      WHEN ''Frau'' THEN ''geehrte Frau''
                      ELSE ''geehrte/-r Frau/Herr''
            END
       END
FROM FaLeistung FAL
INNER JOIN VmMassnahme MSN ON MSN.FaLeistungID = FAL.FaLeistungID
                              AND MSN.VmMassnahmeID = (SELECT TOP 1 MAS.VmMassnahmeID
                   FROM   VmMassnahme MAS
                                                       INNER JOIN FaLeistung FAL ON FAL.FaLeistungID = MAS.FaLeistungID
                                                       WHERE  FAL.FaLeistungID = {FaLeistungID}
                                                       ORDER BY MAS.DatumVon DESC)
INNER JOIN VmErnennung ERN ON ERN.VmMassnahmeID = MSN.VmMassnahmeID
            AND ERN.VmErnennungID = (SELECT TOP 1 VmErnennungID
                                                                FROM   VmErnennung
                                                                WHERE  VmMassnahmeID = MSN.VmMassnahmeID
                                                                ORDER BY Ernennung DESC)
LEFT JOIN VmPriMa PMA on PMA.VmPrimaID = ERN.VmPrimaID
LEFT JOIN XUser   USR on USR.UserID = ERN.UserID
WHERE FAL.FaLeistungid  = {FaLeistungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMandBericht', N'Vormundschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmMandBericht
WHERE VmMandBerichtID = {VmMandBerichtID}', N'Diverse Textmarken für Mandant Bericht.
   Wegen der Längenbeschränkung für Checkboxen wurden 
   folgende Abkürzungen definiert:
   VmMandBerichtVIP: Veränderung in Periode
   VmMandBerichtFS: Familiäre Situation
   VmMandBerichtSK: Soziale Kompetenzen
   VmMandBerichtFZ: Freizeit
   VmMandBerichtRES: Resourcen
   VmMandBerichtKL: Klient
   VmMandBerichtDR: Dritte
   VmMandBerichtI: Institutionen
   VmMandBerichtEA_C1 (u.s.w.): EinnahmenAngaben
   VmMandBerichtBV_C1(u.s.w.): Versicherungen
   VmMandBerichtBBA_C1(u.s.w.): Bericht Besondere Angaben
   VmMandBerichtAU: Abrechnung Unterschrieben
   VmMandBerichtPT: Passation Teilnahme
  ', N'vwTmVmMandBericht', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMassnahmeAufhebung', N'Vormundschaft', 1, N'select convert(varchar,DatumBis,104)
from   VmMassnahme
where  VmMassnahmeID = {VmMassnahmeID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMassnahmeBeschlussVom', N'Vormundschaft', 1, N'select convert(varchar,DatumVon,104)
from   VmMassnahme
where  VmMassnahmeID = {VmMassnahmeID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMassnahmeZGBArtikel', N'Vormundschaft', 1, N'select Replace(dbo.fnLOVTextListe(''VmZGB'',ZGBCodes),'' ZGB'','''')
from   VmMassnahme
where  VmMassnahmeID = {VmMassnahmeID}', N'Artikelnummern der ZGB Artikel (es können mehrere sein)
Kontext: Maske BS/Massnahmen', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmMassnahmeZGBBez', N'Vormundschaft', 1, N'declare @Codes varchar(100)

select @Codes = ZGBCodes
from   VmMassnahme
where  VmMassnahmeID = {VmMassnahmeID}

if @Codes is null
  select null
else begin
  declare @Code  varchar(5)
  declare @Text  varchar(100)
  declare @Liste varchar(1000)
  declare @Idx   int

  set @Liste = ''''
  set @Idx = 1
  while @Idx <= LEN(@Codes) begin
    -- nicht numerische Zeichen überspringen
    while @Idx <= LEN(@Codes) and not substring(@Codes,@Idx,1) between ''0'' and ''9'' begin
      set @Idx = @Idx + 1
    end

    -- Code aufbauen
    set @Code = ''''
    while @Idx <= len(@Codes) and substring(@Codes,@Idx,1) between ''0'' and ''9'' begin
      set @Code = @Code + substring(@Codes,@Idx,1)
      set @Idx = @Idx + 1
    end

    if @Code <> '''' begin
      select @Text = Value1 from XLOVCode where LOVName = ''VmZGB'' and Code = convert(int,@Code)
      if @Text is not null begin
        if @Liste <> '''' set @Liste = @Liste + '',''
        set @Liste = @Liste + @Text
      end
    end
  end
  select @Liste
end', N'Bezeichnungen der ZGB Artikel (es können mehrere sein)
Kontext: Maske BS/Massnahmen
', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmSachversicherung', N'Vormundschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmSachversicherung
WHERE VmSachversicherungID = {VmSachversicherungID}', N'Diverse Textmarken für Sachversicherung', N'vwTmVmSachversicherung', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmSituationsBericht', N'Vormundschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmSituationsBericht
WHERE VmSituationsBerichtID = {VmSituationsBerichtID}', N'Diverse Textmarken für Situationsbericht', N'vwTmVmSituationsBericht', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmVS', N'Vaterschaft', 1, N'SELECT <TableColumn>
FROM dbo.vwTmVmVaterschaft
WHERE FaLeistungID = {FaLeistungID};', N'Diverse Vaterschaftstextmarken.', N'vwTmVmVaterschaft', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VmVSGeschwister', N'Vaterschaft', 1, N'DECLARE @text VARCHAR(MAX);
SET @text = '''';

SELECT @text = @text + ISNULL(VMV.<TableColumn>, '''') + '', ''
FROM dbo.fnTmGeschwister({BaPersonID}) GES
  INNER JOIN dbo.vwTmVmVaterschaft     VMV ON VMV.BaPersonID = GES.BaPersonID;

IF (LEN(@text) > 0)
BEGIN
  SELECT SUBSTRING(@text, 0, LEN(@text));
END;', N'Vaterschaftstextmarken für Geschwister des Fallträgers. (Kommasepariert, absteigend nach alter der Geschwister)', N'vwTmVmVaterschaft', 5, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZLEUebersicht', N'BDE', 1, N'-- init vars
DECLARE @UserID INT
DECLARE @LanguageCode INT
DECLARE @ShownDate DATETIME
DECLARE @ColumnName VARCHAR(255)
DECLARE @ColumnDataType VARCHAR(50)

-- set vars from context
SET @UserID         = ISNULL({SelectedUserID}, -1)
SET @LanguageCode   = ISNULL({LanguageCode}, 1)
SET @ShownDate      = ISNULL({OverviewMonth}, GETDATE())
SET @ColumnName     = ISNULL(N''<TableColumn>'', '''')

-- get datatype of view-column
SELECT @ColumnDataType = TYP.name
FROM sys.views AS VEW
  INNER JOIN sys.all_columns CLM ON CLM.object_id = VEW.object_id
  LEFT OUTER JOIN sys.types  TYP  ON TYP.user_type_id = CLM.user_type_id
WHERE SCHEMA_NAME(VEW.schema_id) = N''dbo'' AND
      VEW.name = N''vwTmBDEZLEUebersicht'' AND
      CLM.name = @ColumnName

-- datatype depending handling
IF (@ColumnDataType = N''money'')
BEGIN
  -- get data rounded!
  SELECT <TableColumn> = CONVERT(DECIMAL(10, 2), <TableColumn>) -- if column is money, do round on two digits and keep them
  FROM dbo.fnBDEGetUebersicht(@UserID, dbo.fnLastDayOf(@ShownDate), @LanguageCode, 0) FCN
END
ELSE
BEGIN
  -- get data
  SELECT <TableColumn>
  FROM dbo.fnBDEGetUebersicht(@UserID, dbo.fnLastDayOf(@ShownDate), @LanguageCode, 0) FCN
END', N'Textmarken für die Übersicht der ZLE-Erfassung (ZLE-Data)
--> Benutzt Dummy-View für Spalten (vwTmBDEZLEUebersicht)', N'vwTmBDEZLEUebersicht', 20, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZLEUebersichtUser', N'BDE', 1, N'-- init vars
DECLARE @UserID INT

-- set vars from context
SET @UserID = ISNULL({SelectedUserID}, -1)

-- get data
SELECT <TableColumn>
FROM dbo.vwTmUser USR WITH (READUNCOMMITTED)
WHERE USR.UserID = @UserID', N'Textmarken für die Übersicht der ZLE-Erfassung (SelectedUser)', N'vwTmUser', 20, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungAPVNr', N'ZuAnweisung', 1, N'select APVNr = dbo.fnLOVText(''KaAPV'', KEP.APVCode)
from KaEinsatz KAE
  left join KaEinsatzplatz2 KEP on KEP.KaEinsatzplatzID = KAE.KaEinsatzplatzID
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''APV Nr.'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungAPVZusatz', N'ZuAnweisung', 1, N'select APVZusatz = dbo.fnLOVText(''KaAPVZusatz'', KAE.APVZusatzCode)
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''APV Zusatz'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungBeschGrad', N'ZuAnweisung', 1, N'select IsNull(convert(varchar, KAE.BeschGrad) + ''%'', '''')
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''Beschäftigungsgrad'' vom aktuellsten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungDatAustritt', N'ZuAnweisung', 1, N'SELECT ISNULL(CONVERT(VARCHAR, AUS.AustrittDatum, 104), '' '')  
FROM KaEinsatz KAE  
  OUTER APPLY dbo.fnKaGetAustrittDatumCode(KAE.FaLeistungID, KAE.KaEinsatzID) AUS
WHERE KAE.BaPersonID = {BaPersonID}  
  AND CONVERT(DATETIME, KAE.DatumVon, 104) = (SELECT CONVERT(DATETIME, MAX(KAE1.DatumVon), 104)           
                                              FROM KaEinsatz KAE1           
                                              WHERE KAE1.BaPersonID = {BaPersonID}
                                                AND KAE1.FaLeistungID IS NOT NULL)', N'''Datum Austritt'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungDatBis', N'ZuAnweisung', 1, N'select IsNull(Convert(varchar, KAE.DatumBis, 104), '' '')
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''Datum bis'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungDatBisAktPhase', N'ZuAnweisung', 1, N'select IsNull(Convert(varchar, MIN(KAE.DatumVon), 104), '' '')
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) > (select Convert(Datetime, MIN(FAL.DatumVon), 104)
              from FaLeistung FAL
              where FAL.ModulID = 7
              and FAL.BaPersonID = {BaPersonID}
              and FAL.DatumBis is NULL)', N'Letztes Datum der aktuellen Phase', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungDatVon', N'ZuAnweisung', 1, N'select IsNull(Convert(varchar, KAE.DatumVon, 104), '' '')
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''Datum von'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungDatVonAktPhase', N'ZuAnweisung', 1, N'SELECT ISNULL(CONVERT(VARCHAR, MIN(KAE.DatumVon), 104), '' '')
FROM dbo.KaEinsatz KAE WITH (READUNCOMMITTED)
WHERE KAE.FaLeistungID = {FaLeistungID};', N'Frühstes Datum der aktuellen Phase', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungNrALK', N'ZuAnweisung', 1, N'select ORG.InstitutionNr
from KaEinsatz KAE
  left join BaInstitution ORG on ORG.BaInstitutionID = KAE.ALKasseID
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''ALK Nr.'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungPersonenNr', N'ZuAnweisung', 1, N'select KAE.PersonenNr
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''Personen Nr.'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungRahmenfrist', N'ZuAnweisung', 1, N'select IsNull(Convert(varchar, KAE.RahmenfristBis, 104), '' '')
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})', N'''Datum Rahmenfrist'' vom aktuellesten Eintrag', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungZuweiserAdresse', N'ZuAnweisung', 1, N'DECLARE @KontaktID INT

select @KontaktID = KAE.ZuweiserID
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})

if @KontaktID > 1
  select Adresse = isNull(ORG.Name + char(13) + char(10), '''') +
       CASE WHEN AdressZusatz = '''' or AdressZusatz is NULL THEN '''' ELSE AdressZusatz + char(13) + char(10) END +
                   isnull(OKO.Vorname + isnull('' '' + OKO.Name, '''') + char(13) + char(10), '''') +
       CASE WHEN Postfach = '''' or Postfach is NULL THEN '''' ELSE Postfach + char(13) + char(10) END +
             isNull(StrasseHausNr + char(13) + char(10),'''') +
                   isNull(PLZOrt, '''')
  from   BaInstitutionKontakt OKO
  left join vwInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID	
  where  BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select Adresse = CASE WHEN WohnsitzAdressZusatz = '''' or WohnsitzAdressZusatz is NULL THEN '''' ELSE WohnsitzAdressZusatz + char(13) + char(10) END +
                   isnull(VornameName + char(13) + char(10), '''') +
       CASE WHEN WohnsitzPostfach = '''' or WohnsitzPostfach is NULL THEN '''' ELSE WohnsitzPostfach + char(13) + char(10) END +
             isNull(WohnsitzStrasseHausNr + char(13) + char(10),'''') +
                   isNull(WohnsitzPLZOrt, '''')
  from   vwPerson
  where  BaPersonID = - @KontaktID - 100000
else
  select Adresse = isnull(USR.FirstName + isnull('' '' + USR.LastName, '''') + char(13) + char(10), ''''),
                   AdressatRTF = isNull(OUN.Adressat, '''')
  from   XUser USR
  left join XOrgUnit_User OUU on OUU.UserID = USR.UserID and (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  left join XOrgUnit OUN ON OUN.OrgUnitID = OUU.OrgUnitID
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungZuweiserOrt', N'ZuAnweisung', 1, N'DECLARE @KontaktID INT

select @KontaktID = KAE.ZuweiserID
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})

if @KontaktID > 1
  select ZuweiserOrt = ORG.Name
  from   BaInstitutionKontakt OKO
  left join BaInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID	
  where  BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select ZuweiserOrt = ''''
  from   vwPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select ZuweiserOrt = OUN.ItemName
  from   XUser USR
  left join XOrgUnit_User OUU on OUU.UserID = USR.UserID and (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  left join XOrgUnit OUN ON OUN.OrgUnitID = OUU.OrgUnitID
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZuAnweisungZuwHerrFrauVornameName', N'ZuAnweisung', 1, N'DECLARE @KontaktID INT

select @KontaktID = KAE.ZuweiserID
from KaEinsatz KAE
where KAE.BaPersonID = {BaPersonID}
and Convert(Datetime, KAE.DatumVon, 104) = (select Convert(Datetime, MAX(KAE1.DatumVon), 104)
              from KaEinsatz KAE1
              where KAE1.BaPersonID = {BaPersonID})

if @KontaktID > 1
  select Anrede = isNull(OKO.Anrede + '' '', '''') +
                   isnull(OKO.Vorname + isnull('' '' + OKO.Name, ''''), '''')  	                  	
  from   BaInstitutionKontakt OKO
  left join BaInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID	
  where  BaInstitutionKontaktID = @KontaktID
else if @KontaktID between -199999 and -100000
  select Anrede = isNull(Titel + '' '', '''') +
                isnull(PRS.Vorname + isnull('' '' + PRS.Name, ''''), '''') 	
  from   vwPerson PRS	
  where  PRS.BaPersonID = - @KontaktID - 100000
else
  select Anrede = case GenderCode when 1 then ''Herr'' else ''Frau'' end
            + isnull('' '' + USR.FirstName + isnull('' '' + USR.LastName, ''''), '''')
  from   XUser USR
  left join XOrgUnit_User OUU on OUU.UserID = USR.UserID and (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  left join XOrgUnit OUN ON OUN.OrgUnitID = OUU.OrgUnitID
  where  USR.UserID = - @KontaktID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzer', N'zuständige/r Benutzer/in', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmUser
WHERE  UserID = {OwnerUserId}', N'Diverse Textmarken für den zuständigen Benutzer', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerAbteilungText1', N'zuständige/r Benutzer/in', 3, N'select top 1 ORG.Text1
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {OwnerUserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerAbteilungText2', N'zuständige/r Benutzer/in', 3, N'select top 1 ORG.Text2
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {OwnerUserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerAbteilungText3', N'zuständige/r Benutzer/in', 3, N'select top 1 ORG.Text3
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {OwnerUserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerAbteilungText4', N'zuständige/r Benutzer/in', 3, N'select top 1 ORG.Text4
from   XOrgUnit_User OUU
       left join XOrgUnit ORG on ORG.OrgUnitID = OUU.OrgUnitID
where  OUU.UserID = {OwnerUserId} and
       OUU.OrgUnitMemberCode = 2', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerText1', N'zuständige/r Benutzer/in', 3, N'select Text1
from   XUser
where  UserId = {OwnerUserId}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustBenutzerText2', N'zuständige/r Benutzer/in', 3, N'select Text2
from   XUser
where  UserId = {OwnerUserId}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZustKA', N'Einsatzplatz', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmUser
WHERE  UserID = {ZustaendigKaId}', N'Zuständiger Mitarbeiter bei Einsatzplatz KA', N'vwTmUser', NULL, 0, 1)
GO
COMMIT
GO