SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XBookmark]
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AA', N'Abklärung Auswertung', 1, N'SELECT <TableColumn>
FROM   vwTmAbklaerung
WHERE  FaAbklaerungID = {FaAbklaerungID}', N'Abklärung Auswertung (diverse Textmarken)', N'vwTmAbklaerung', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Abrechnung', N'W Klientenabrechnung', 1, N'SELECT <TableColumn>
FROM   vwTmAbrechnung
WHERE  WhAbrechnungID = {WhAbrechnungID}', NULL, N'vwTmAbrechnung', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbrechnungAusgabenTabelle', N'W Klientenabrechnung', 1, N'SELECT
	LA,
	NextCell = null,
	LAText,
	NextCell = null,
	Replace(Convert(varchar(20), -Betrag, 1), '','', ''''''''),
	NextCell = null
FROM dbo.fnWhAbrechnung({WhDetailblattID}, ''A'')', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbrechnungEinnahmenTabelle', N'W Klientenabrechnung', 1, N'SELECT
	LA,
	NextCell = null,
	LAText,
	NextCell = null,
	Replace(Convert(varchar(20), Betrag, 1), '','', ''''''''),
	NextCell = null
FROM dbo.fnWhAbrechnung({WhDetailblattID}, ''E'')', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbrechnungPersonenTabelle', N'W Klientenabrechnung', 1, N'DECLARE @WhDetailblattID int, @WhAbrechnungID int, @FaFallID int
SET @WhDetailblattID = {WhDetailblattID}
SET @WhAbrechnungID = {WhAbrechnungID}
SET @FaFallID = {FaFallID}
--SET @WhDetailblattID = 50
--SET @WhAbrechnungID = 2
--SET @FaFallID = 3

IF @WhDetailblattID >= 0 BEGIN
  SELECT
	[Name] = PER.Name,
	NextCell = null,
	Vorname = PER.Vorname,
	NextCell = null,
	GebDatum = PER.Geburtsdatum,
	NextCell = null,
	FallNr = @FaFallID,
	NextCell = null,
	PersonenNr = PER.BaPersonID,
	NextCell = null
  FROM WhDetailblatt_BaPerson DBP
	INNER JOIN WhDetailblatt DET ON DET.WhDetailblattID = DBP.WhDetailblattID
	INNER JOIN VwPerson PER ON PER.BaPersonID = DBP.BaPersonID
  WHERE DBP.WhDetailblattID = @WhDetailblattID AND DBP.Inkl = 1

END
ELSE BEGIN
  SELECT
	[Name] = PER.Name,
	NextCell = null,
	Vorname = PER.Vorname,
	NextCell = null,
	GebDatum = PER.Geburtsdatum,
	NextCell = null,
	FallNr = @FaFallID,
	NextCell = null,
	PersonenNr = PER.BaPersonID,
	NextCell = null
  FROM VwPerson PER
	INNER JOIN (SELECT BaPersonID
	FROM WhDetailblatt DET
		INNER JOIN WhDetailblatt_BaPerson DBP ON DBP.WhDetailblattID = DET.WhDetailblattID AND DBP.Inkl = 1
	WHERE DET.WhAbrechnungID = @WhAbrechnungID
	GROUP BY BaPersonID
	) AS SUB ON SUB.BaPersonID = PER.BaPersonID
END', N'Füllt eine Tabelle mit dem Namen, Vorname, Geburtsdatum, Fall-Nr. und Personen-Nr. für diejenigen Personen, die in dem Abrechnungsblatt vorkommen.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbrechnungZusammenzugTabelle', N'W Klientenabrechnung', 1, N'DECLARE @WhAbrechnungID int
SET @WhAbrechnungID = {WhAbrechnungID}
--SET @WhAbrechnungID = 11
--select * from whabrechnung
--select * from whdetailblatt

SELECT 
 BlattTyp = blattTyp,
 NextCell = NULL,
 Ausgaben = Replace(Convert(varchar(20), -Ausgaben, 1), '','', ''''''''),
 NextCell = NULL,
 Einnahmen = Replace(Convert(varchar(20), Einnahmen, 1), '','', ''''''''),
 NextCell = NULL,
 Klientenguthaben = Replace(Convert(varchar(20), Klientenguthaben, 1), '','', ''''''''),
 NextCell = NULL,
 GuthabenSOD = Replace(Convert(varchar(20), GuthabenSOD, 1), '','', ''''''''),
 NextCell = NULL
FROM
(SELECT
 WhDetailblattID,
 BlattTyp 	  = ''Detailblatt '' + convert(varchar(12), DatumVon, 104) + '' - '' + convert(varchar(12), DatumBis, 104),
 Einnahmen 	  = DET.TotalEinnahmen,
 Ausgaben 	  = DET.TotalAusgaben, -- DET.TotalAusgaben ist negativ
 KlientenGuthaben = CASE WHEN DET.TotalEinnahmen > -DET.TotalAusgaben THEN DET.TotalEinnahmen + DET.TotalAusgaben ELSE $0.00 END,
 GuthabenSOD 	  = CASE WHEN DET.TotalEinnahmen < -DET.TotalAusgaben THEN -DET.TotalAusgaben - DET.TotalEinnahmen ELSE $0.00 END,
 DatumVon 	  = DET.DatumVon
FROM WhDetailblatt DET
WHERE WhAbrechnungID = @WhAbrechnungID

UNION
-- Ergänzungsblätter
SELECT
 WhDetailblattID,
 BlattTyp  	  = ''Ergänzungsblatt '' + convert(varchar(12), DatumVon, 104) + '' - '' + convert(varchar(12), DatumBis, 104),
 Einnahmen 	  = null, -- vom Benutzer auszufüllen
 Ausgaben  	  = null, -- vom Benutzer auszufüllen
 Klientenguthaben = null, -- vom Benutzer auszufüllen
 GuthabenSOD 	  = null, -- vom Benutzer auszufüllen
 DatumVon  	  = DET.DatumVon
FROM WhDetailblatt DET
WHERE WhAbrechnungID = @WhAbrechnungID AND
	DET.ErgaenzungsblattDokumentID IS NOT NULL
) AS SUB
ORDER BY WhDetailblattID, BlattTyp, DatumVon', N'Füllt eine Tabelle mit dem BlattTyp (Detailblatt oder Ergänzungsblatt), der Ausgabe, Einnahme und dem resultierenden Ergebnis.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbsenderAdresseEinzeilig', N'Absender', 1, N'declare @ID int
set @ID = {Absender}
if @ID < 0
  select replace(convert(varchar(2000),OrgEinheitAdresseFeld), char(13) + char(10), '', '') from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseEinzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseEinzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift einzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbsenderAdresseEinzOhneStdZH', N'Absender', 1, N'declare @ID int
set @ID = {Absender}
if @ID < 0
  select replace(
        replace(convert(varchar(2000),OrgEinheitAdresseFeld), char(13) + char(10), '', ''),
        ''Stadt Zürich, '',
        '''')
  from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseEinzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseEinzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift einzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbsenderAdresseMehrzeilig', N'Absender', 1, N'declare @ID int
set @ID = {Absender}
if @ID < 0
  select OrgEinheitAdresseFeld from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseMehrzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseMehrzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift mehrzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AbsenderName', N'Absender', 1, N'declare @ID int
set @ID = {Absender}
if @ID < 0
  select VornameName from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select VornameName from vwTmPerson where PersonenNr = @ID
else
  select InstitutionName from vwTmInstitution where InstitutionNr = @ID', N'Name des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatAdresseEinzeilig', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select replace(convert(varchar(2000),OrgEinheitAdresseFeld), char(13) + char(10), '', '') from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseEinzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseEinzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift einzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatAdresseEinzOhneStdZH', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select replace(
        replace(convert(varchar(2000),OrgEinheitAdresseFeld), char(13) + char(10), '', ''),
        ''Stadt Zürich, '',
        '''')
  from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseEinzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseEinzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift einzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatAdresseMehrzeilig', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select OrgEinheitAdresseFeld from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select WohnsitzAdresseMehrzeilig from vwTmPerson where PersonenNr = @ID
else
  select AdresseMehrzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift mehrzeilig des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatFax', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select OrgEinheitFax from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select NULL
else
  select Fax from vwTmInstitution where InstitutionNr = @ID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatFrauHerrAdresseMehrzeilig', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select OrgEinheitAdresseFeld from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select 
  isnull (CASE PRS.Geschlecht
	    WHEN ''männlich'' THEN ''Herr'' + char(13) + char(10) 
	    WHEN ''weiblich'' THEN ''Frau'' + char(13) + char(10) 
	    ELSE null
	  END,'''')
	 +  WohnsitzAdresseMehrzeilig from vwTmPerson PRS where PersonenNr = @ID
else
  select AdresseMehrzeilig from vwTmInstitution where InstitutionNr = @ID', N'Anschrift mehrzeilig des Klienten mit Anrede, der Institution oder des Mitarbeiters', NULL, NULL, 0, 0)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatGeehrteFrauHerr', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select case isnull(GenderCode,0)
         when 1 then ''Sehr geehrter Herr''
         when 2 then ''Sehr geehrte Frau''
         else ''geehrte Damen und Herren''
         end
  from XUser where UserID = -@ID
else if @ID < 500000
  select case isnull(GeschlechtCode,0)
         when 1 then ''Sehr geehrter Herr''
         when 2 then ''Sehr geehrte Frau''
         else ''geehrte/r Frau/Herr''
         end
  from BaPerson where BaPersonID = @ID
else
  select ''Sehr geehrte Damen und Herren''', N'"geehrte Frau","geehrter Herr" oder "geehrte Damen und Herren", je nach Herkunft (Person, MA, Institution) und Geschlecht des Adressaten', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatGeehrteFrauHerrName', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select case isnull(USR.GenderCode,0)
         when 1 then ''Sehr geehrter Herr '' + VTU.Name
         when 2 then ''Sehr geehrte Frau '' + VTU.Name
         else ''Sehr geehrte Damen und Herren''
         end
  from XUser USR
  left join vwTmUser VTU on VTU.BenutzerNr = USR.UserID
  where USR.UserID = -@ID
else if @ID < 500000
  select case isnull(PER.GeschlechtCode,0)
         when 1 then ''Sehr geehrter Herr '' + PER.Name
         when 2 then ''Sehr geehrte Frau '' + PER.Name
         else ''Sehr geehrte Damen und Herren''
         end
  from BaPerson PER
  left join vwTmPerson VTP on VTP.PersonenNr = PER.BaPersonID
  where PER.BaPersonID = @ID
else
  select ''Sehr geehrte Damen und Herren''', N'"geehrte Frau","geehrter Herr" oder "geehrte Damen und Herren", je nach Herkunft (Person, MA, Institution) und Geschlecht des Adressaten', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatName', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select Name from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select Name from vwTmPerson where PersonenNr = @ID
else
  select InstitutionName from vwTmInstitution where InstitutionNr = @ID', N'Name des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatNameVorname', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select VornameName from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select VornameName from vwTmPerson where PersonenNr = @ID
else
  select InstitutionName from vwTmInstitution where InstitutionNr = @ID', N'Name des Klienten, der Institution oder des Mitarbeiters', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AdressatVorname', N'Adressat', 1, N'declare @ID int
set @ID = {Adressat}
if @ID < 0
  select Vorname from vwTmUser where BenutzerNr = -@ID
else if @ID < 500000
  select Vorname from vwTmPerson where PersonenNr = @ID
else
  select InstitutionName from vwTmInstitution where InstitutionNr = @ID', N'Vorname des Klienten oder des Mitarbeiters
Name der Institution', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Adresse', N'Leistungsentscheid', 1, N'SELECT  TOP 1 Adresse = RTrim(LTrim(PRS.WohnsitzStrasseHausNr + '', '' + PRS.WohnsitzPLZOrt))
FROM    BgFinanzPlan_BaPerson SPP
        INNER JOIN vwPerson   PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE   SPP.BgFinanzPlanID = {BgFinanzplanID} 
AND SPP.IstUnterstuetzt = 1', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ALBVKopf', N'Alimente', 1, N'select
        Spalte1 = AmAnspruchsberechnung.BerechnungDatumAb,
        NextCell = null,
        Spalte2 = AmAnspruchsberechnung.Bezeichnung,
        NextCell = null,
        Spalte3 = vwPerson.Vorname + ''  '' + vwPerson.Name,
	NextCell = null,
	NextCell = null,
	NextCell = null,
	Spalte4 = vwPerson.WohnsitzStrasseHausNr,
	NextCell = null,
	NextCell = null,
	NextCell = null,
	Spalte5 = vwPerson.WohnsitzPLZOrt

FROM         FaLeistung INNER JOIN
                      AmAnspruchsberechnung ON FaLeistung.FaLeistungID = AmAnspruchsberechnung.FaLeistungID INNER JOIN
                      vwPerson ON FaLeistung.BaPersonID = vwPerson.BaPersonID
WHERE     AmAnspruchsberechnung.AmAnspruchsberechnungID = {ID}', N'Kopfdaten der ALBV Berechnung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ALBVVariante', N'Alimente', 1, N'SELECT Spalte1 = BerechnungsStatus,
       NextCell = null,
       NextCell = null,
       NextCell = null,
       Spalte2 = BerechnungsTyp,
       NextCell = null,
       NextCell = null,
       NextCell = null,
       Spalte3 = Einkommensvariante
 FROM vwTmAmAnspruchsberechnung
WHERE AmAnspruchsberechnungID = {ID}', N'Varianten der Berechnung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AlleFallNr', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @DatVon DATETIME
SET @Result = ''''

DECLARE csrTLErbringer CURSOR FOR
	SELECT	DISTINCT FaFallID, DatumVon
	FROM    FaFallPerson
	WHERE   BaPersonID = {FT}
	AND	FaFallID <> {FaFallID}
	AND	(DatumBis is null or DatumBis < GetDate())
	ORDER BY  DatumVon DESC

   	OPEN csrTLErbringer
	WHILE 1 = 1 BEGIN
		FETCH NEXT FROM csrTLErbringer INTO @Value, @DatVon
		IF NOT @@FETCH_STATUS = 0 BREAK

		IF NOT @Result = '''' BEGIN
			SET @Result = @Result + '', '' 		
		END ELSE BEGIN
			SET @Result = '', ''
		END

		SET @Result = @Result + ISNULL(@Value, '''')
	END
CLOSE csrTLErbringer
DEALLOCATE csrTLErbringer

SELECT @Result', N'Alle FallNr (ohne FT FallNr). Kommagetrennt in einer Zeile.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AM', N'Assessment', 1, N'SELECT <TableColumn>
FROM   vwTmAssessment
WHERE  FaAssessmentID = {FaAssessmentID}', N'Assessment (diverse Textmarken)', N'vwTmAssessment', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmAnspruchsberechnungALBV', N'Alimente', 1, N'select
  Style = case
    --when POS.AmAbPositionsartID in (10,30,60,80,130,160,180,200,220,250,270,280,300,500,720,730,740) then ''KissTitel''
    when Pos.ParentID IS NULL OR POS.AmAbPositionsartID in (720,740) then ''KissTitel''
    else ''KissText''
  end,
  Spalte1 = case
    --when AB.EinkommensvarianteCode = 1 then ''ALBV: '' 
    when POS.AmAbPositionsartID = 500 and KND.BerechtigtCode = 1 then ''ALBV: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    when POS.AmAbPositionsartID = 500 and KND.BerechtigtCode = 2 then ''UeBH: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    when POS.AmAbPositionsartID = 500 and KND.BerechtigtCode = 3 then ''KKBB: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    else POS.Text
  end,
  NextCell = null,

  Style = ''KissBetrag'',
  Spalte2 = case
    when POS.AmAbPositionsartID in (272) then replace(convert(varchar, POS.Wert2, 1), '','', '''''''')
    when POS.AmAbPositionsartID in (276) then replace(convert(varchar, POS.Wert3, 1), '','', '''''''')
    when POS.Format2 = ''N2'' then left (convert(varchar,POS.Wert2,2),len(convert(varchar,POS.Wert2,2))-2)
    else left (convert(varchar,POS.Wert2,2),len(convert(varchar,POS.Wert2,2))-5)
  end,
  NextCell = null,

  Style = ''KissText'',
  Spalte3 = POS.Mengeneinheit2,
  NextCell = null,

  Style = ''KissBetrag'',
  Spalte4 = replace(convert(varchar,POS.Wert1,1),'','',''''''''),
  NextCell = null,

  -- ??warum werden die Totale nicht gedruckt sozhew
  Style = case
    when POS.AmAbPositionsartID in (13,44,69,84,145,169,184,206,249,259,271,275,288,531,720,730,740) then ''KissTotal''
    else ''KissBetrag''
  end,
  Spalte6 = case
    when POS.AmAbPositionsartID in (276) then null
    else replace(convert(varchar,POS.Wert3,1),'','','''''''')
  end,
  NextCell = null

from AmAbPosition POS
  --left outer join AmAbPositionsart ART on ART.AmAbPositionsartID = POS.AmAbPositionsartID
  left outer join AmAbKind KND on KND.AmAbKindID=POS.AmAbKindID
  left outer join AmAnspruchsberechnung AB on AB.AmAnspruchsberechnungID=POS.AmAnspruchsberechnungID
  left outer join BaPerson PRS on PRS.BaPersonID=KND.BaPersonID

where POS.AmAnspruchsberechnungID = {ID} and
  (isNull(POS.Wert3,-1) <> 0 or POS.AmAbPositionsartID in (44,69,81,82,84,206,249,255,256,259,271,275,282,283,250,259,500,526,531,740) )
order by
  -- 1. Feld für Sortierung
  case
    when POS.Sortierung1 = ''Y'' then ''X'' + PRS.Name + Isnull('' '' + PRS.Vorname, '''')
    when POS.Sortierung1 = ''K'' then ''K'' + PRS.Name + Isnull('' '' + PRS.Vorname, '''')
    else POS.Sortierung1
  end,
  -- 2. Feld für Sortierung
  POS.Sortierung2', N'Zum Ausdruckn der Anspruchsberechnung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmAnspruchsberechnungKKBB', N'Alimente', 1, N'select
  Style = case
    --when POS.AmAbPositionsartID in (3010,3030,3060,3080,3130,3160,3180,3200,3220,3250,3270,3280) then ''KissTitel''
    --else ''KissText''
     when Pos.ParentID IS NULL OR POS.AmAbPositionsartID in (3290) then ''KissTitel''
     else ''KissText''
  end,
  Spalte1 = case
    when POS.AmAbPositionsartID = 500 and KND.BerechtigtCode = 1 then ''ALBV: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    when POS.AmAbPositionsartID = 500 and KND.BerechtigtCode = 2 then ''UeBH: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    when POS.AmAbPositionsartID = 3280 and KND.BerechtigtCode = 3 then ''KKBB: '' + PRS.Name + ISNULL('' '' + PRS.Vorname, '''')
    else POS.Text
  end,
  NextCell = null,

  Style = ''KissBetrag'',
  Spalte2 = case
    when POS.AmAbPositionsartID in (3272) then replace(convert(varchar, POS.Wert2, 1), '','', '''''''')
    when POS.AmAbPositionsartID in (3276) then replace(convert(varchar, POS.Wert3, 1), '','', '''''''')
    when POS.Format2 = ''N2'' then left (convert(varchar,POS.Wert2,2),len(convert(varchar,POS.Wert2,2))-2)
    else left (convert(varchar,POS.Wert2,2),len(convert(varchar,POS.Wert2,2))-5)
  end,
  NextCell = null,

  Style = ''KissText'',
  Spalte3 = POS.Mengeneinheit2,
  NextCell = null,

  Style = ''KissBetrag'',
  Spalte4 = replace(convert(varchar,POS.Wert1,1),'','',''''''''),
  NextCell = null,

  Style = case
    when POS.AmAbPositionsartID in (3025,3044,3075,3084,3145,3175,3184,3215,3249,3259,3271,3276,3290) then ''KissTotal''
    else ''KissBetrag''
  end,
  Spalte6 = case
    when POS.AmAbPositionsartID in (3276) then null
    else replace(convert(varchar,POS.Wert3,1),'','','''''''')
  end,
  NextCell = null

from AmAbPosition POS
  --left outer join AmAbPositionsart ART on ART.AmAbPositionsartID = POS.AmAbPositionsartID
  left outer join AmAbKind KND on KND.AmAbKindID=POS.AmAbKindID
  left outer join BaPerson PRS on PRS.BaPersonID=KND.BaPersonID

where POS.AmAnspruchsberechnungID = {ID} and
  (isNull(POS.Wert3,-1) <> 0 or POS.AmAbPositionsartID in (3145,3175,3180,3181,3182,3184,3215,3220,3245,3249,3255,3256,3259,3280,3271,3290) )
order by
  -- 1. Feld für Sortierung
  case
    when POS.Sortierung1 = ''Y'' then ''X'' + PRS.Name + Isnull('' '' + PRS.Vorname, '''')
    when POS.Sortierung1 = ''K'' then ''K'' + PRS.Name + Isnull('' '' + PRS.Vorname, '''')
    else POS.Sortierung1
  end,
  -- 2. Feld für Sortierung
  POS.Sortierung2', N'Zum Ausdruckn der Anspruchsberechnung', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegung', N'Alimente', 2, N'SELECT <TableColumn>
FROM   vwTmVerfuegung
WHERE  AmVerfuegungID = {AmVerfuegungID}', NULL, N'vwTmVerfuegung', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungAlbvUebh', N'Alimente', 1, N'SELECT 
  Spalte1 = isnull(N.Vorname + '' '','''') + N.Name,
  NextCell = null,
  Spalte5 = CONVERT(VARCHAR, A.BerechnungDatumAb, 104),
  NextCell = null,
  Spalte6 = left (convert(varchar,P.Wert3,2),len(convert(varchar,P.Wert3,2))-2),
  NextCell = null
FROM AmAnspruchsberechnung A
LEFT JOIN AmAbKind K ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
LEFT JOIN AmAbPosition P ON P.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID 
  AND P.AmAbKindID = K.AmAbKindID 
  AND P.AmAbPositionsartID = 730
LEFT JOIN vwPerson N ON N.BaPersonID = K.BaPersonID
WHERE K.BerechtigtCode IN (1,2)
  AND A.AmVerfuegungID = {AmVerfuegungID}
order by A.BerechnungDatumAb asc, N.Name, N.Vorname', N'Textmarke für Ausdruck Verfügung ALBV/UeBH', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungAlbvUebhOhneDatum', N'Alimente', 1, N'SELECT 
  Spalte1 = isnull(N.Vorname + '' '','''') + N.Name,
  NextCell = null,
  Spalte2 = left (convert(varchar,P.Wert3,2),len(convert(varchar,P.Wert3,2))-2),
  NextCell = null
FROM AmAnspruchsberechnung A
LEFT JOIN AmAbKind K ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
LEFT JOIN AmAbPosition P ON P.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID 
  AND P.AmAbKindID = K.AmAbKindID 
  AND P.AmAbPositionsartID = 730
LEFT JOIN vwPerson N ON N.BaPersonID = K.BaPersonID
WHERE K.BerechtigtCode IN (1,2)
  AND A.AmVerfuegungID = {AmVerfuegungID}
order by A.BerechnungDatumAb asc, N.Name, N.Vorname', N'Textmarke für Ausdruck Verfügung ALBV/UeBH', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungAlbvUebhSumme', N'Alimente', 1, N'SELECT 
  
  Spalte1 = CONVERT(VARCHAR, A.BerechnungDatumAb, 104),
  NextCell = NULL,
  Spalte2 = ( 
    SELECT LEFT(CONVERT(VARCHAR,SUM(P.Wert3),2),LEN(CONVERT(VARCHAR,SUM(P.Wert3),2))-2)
    FROM AmAbPosition P 
    LEFT JOIN AmAbKind K ON K.AmAbKindID = P.AmAbKindID
    WHERE P.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
      AND K.BerechtigtCode IN (1,2)
      AND P.AmAbPositionsartID = 730
  ),
  NextCell = NULL
FROM AmAnspruchsberechnung A
LEFT JOIN AmVerfuegung V ON V.AmVerfuegungID = A.AmVerfuegungID
WHERE A.AmVerfuegungID = {AmVerfuegungID}
ORDER BY A.BerechnungDatumAb, A.AmAnspruchsberechnungID', N'Textmarke für Ausdruck Verfügung ALBV/UeBH', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungKinder', N'Alimente', 1, N'SELECT 
  Spalte1 = isnull(N.Vorname + '' '','''') + N.Name, 
  NextCell = null,
  Spalte3 = max(CONVERT(VARCHAR, N.Geburtsdatum, 104)),
  NextCell = null,
  Spalte4 = max(case when N.NationalitaetCode = 147 then N.HeimatOrt else N.Nationalitaet end),
  NextCell = null
FROM AmAnspruchsberechnung A
LEFT JOIN AmAbKind K ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
LEFT JOIN AmAbPosition P ON P.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID 
  AND P.AmAbKindID = K.AmAbKindID 
  AND P.AmAbPositionsartID = 730
LEFT JOIN vwPerson N ON N.BaPersonID = K.BaPersonID
WHERE K.BerechtigtCode IN (1,2)
  AND A.AmVerfuegungID = {AmVerfuegungID}
group by N.Geburtsdatum,N.Vorname,N.Name
order by N.Geburtsdatum asc', N'Textmarke für Ausdruck Verfügung ALBV/UeBH Kinder, GebDatum, Heimatort/Land', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungKinderKKBB', N'Alimente', 1, N'SELECT 
  Spalte1 = isnull(N.Vorname + '' '','''') + N.Name, 
  NextCell = null,
  Spalte3 = max(CONVERT(VARCHAR, N.Geburtsdatum, 104)),
  NextCell = null,
  Spalte4 = max(case when N.NationalitaetCode = 147 then N.HeimatOrt else N.Nationalitaet end),
  NextCell = null
FROM AmAnspruchsberechnung A
LEFT JOIN AmAbKind K ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
LEFT JOIN vwPerson N ON N.BaPersonID = K.BaPersonID
WHERE K.BerechtigtCode IN (3,9)
  AND A.AmVerfuegungID = {AmVerfuegungID}
group by N.Geburtsdatum,N.Vorname,N.Name
order by N.Geburtsdatum asc', N'Textmarke für Ausdruck Verfügung ALBV/UeBH Kinder, GebDatum, Heimatort/Land', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AmVerfuegungKkbb', N'Alimente', 1, N'SELECT 
  Spalte1 = CONVERT(VARCHAR, A.BerechnungDatumAb, 104),
  NextCell = null,
  Spalte2 = left (convert(varchar,P.Wert3,2),len(convert(varchar,P.Wert3,2))-2),
  NextCell = null
FROM AmAnspruchsberechnung A
LEFT JOIN AmAbKind K ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
LEFT JOIN AmAbPosition P ON P.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID 
  AND P.AmAbPositionsartID = 3290
LEFT JOIN vwPerson N ON N.BaPersonID = K.BaPersonID
WHERE K.BerechtigtCode = 3
  AND A.AmVerfuegungID = {AmVerfuegungID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizAlleTabelle', N'Aktennotiz', 1, N'declare @Suchkriterien varchar(max)
declare @IDList table (AutoID int identity(1,1), FaAktennotizID int)
declare @Idx int
declare @FaAktennotizID  varchar(10)

set @Suchkriterien = {SelectedIdList}

set @Idx = 1
while @Idx <= len(@Suchkriterien) begin
  -- nicht numerische Zeichen überspringen
  while @Idx <= len(@Suchkriterien) and not SubString(@Suchkriterien,@Idx,1) between ''0'' and ''9'' begin
    set @Idx = @Idx + 1
  end

  -- FaAktennotizID aufbauen
  set @FaAktennotizID = ''''
  while @Idx <= len(@Suchkriterien) AND SubString(@Suchkriterien,@Idx,1) between ''0'' and ''9'' begin
    set @FaAktennotizID = @FaAktennotizID + SubString(@Suchkriterien,@Idx,1)
    set @Idx = @Idx + 1
  end

  if @FaAktennotizID <> '''' insert @IDList (FaAktennotizID) values (@FaAktennotizID)
end

select Datum          = convert(varchar,ANO.Datum,104) + char(13) + char(10) +
                        isNull(USR.LogonName,''''),
       NextCell       = null,
       Kontaktpartner = isNull(ANO.Kontaktpartner,'''') + char(13) + char(10) +
                        isNull(TYP.Text,''''),
       NextCell       = null,
       Stichworte     = ANO.Stichwort,
       NextCell       = null,
       InhaltRTF      = ANO.InhaltRTF,
       NextCell       = null
from   FaAktennotizen ANO
       inner join @IDList  T   on T.FaAktennotizID = ANO.FaAktennotizID
       left  join XUser    USR on USR.UserID = ANO.UserID
       left  join XLOVCode TYP on TYP.LOVName = ''FaGespraechstyp'' and
                                  TYP.Code = ANO.FaGespraechstypCode
order by T.AutoID', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizDatum', N'Aktennotiz', 1, N'select convert(varchar,Datum,104)
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizDatumZeit', N'Aktennotiz', 1, N'select convert(varchar,Datum,104) + isNull('' / '' + substring(convert(varchar, Zeit, 108),1,5),'''')
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizDauer', N'Aktennotiz', 1, N'select LOV.Text
from   FaAktennotizen ANO
       left  join XLOVCode LOV on LOV.LOVName = ''FaDauer'' and
                                  LOV.Code = ANO.FaDauerCode
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizGespraechstyp', N'Aktennotiz', 1, N'select TYP.Text
from   FaAktennotizen ANO
       left  join XLOVCode TYP on TYP.LOVName = ''FaGespraechstyp'' and
                                  TYP.Code = ANO.FaGespraechstypCode
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizInhalt', N'Aktennotiz', 3, N'select InhaltRTF
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizKontaktpartner', N'Aktennotiz', 1, N'select Kontaktpartner
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizMitarbeiter', N'Aktennotiz', 1, N'select USR.LogonName
from   FaAktennotizen ANO
       left join XUser USR on USR.UserID = ANO.UserID
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizStatus', N'Aktennotiz', 1, N'select STA.Text
from   FaAktennotizen ANO
       left  join XLOVCode STA on STA.LOVName = ''FaGespraechsStatus'' and
                                  STA.Code = ANO.FaGespraechsStatusCode
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizStichworte', N'Aktennotiz', 1, N'select Stichwort
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizSuchkriterien', N'Aktennotiz', 1, N'SELECT {SearchValues}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ANotizZeit', N'Aktennotiz', 1, N'select substring(convert(varchar, Zeit, 108),1,5)
from   FaAktennotizen
where  FaAktennotizID = {FaAktennotizID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Ar', N'Arbeit', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmArbeit
WHERE  BaPersonID = {BaPersonID}
ORDER BY DatumVon DESC', N'Person Arbeit (diverse Textmarken)', N'vwTmArbeit', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ArLT', N'Arbeit', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmArbeit
WHERE  BaPersonID = {BaPersonID}
AND    DatumBis is not NULL
ORDER BY DatumBis DESC', N'Person Arbeit Letzte Tätigkeit (diverse Textmarken)', N'vwTmArbeit', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'AS', N'Auflagen / Sanktionen', 1, N'SELECT <TableColumn>
FROM   vwTmAbmachungen
WHERE  FaAbmachungID = {FaAbmachungID}', N'Auflagen / Sanktionen (diverse Textmarken)', N'vwTmAbmachungen', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BaFA', N'Basis', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmAlteFallNr
WHERE  BaPersonID = {BaPersonID}
ORDER BY DatumVon DESC', N'Basis Alte Fall Nr (diverse Textmarken)', N'vwTmAlteFallNr', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BaWV', N'Basis', 1, N'SELECT TOP 1 <TableColumn>
FROM   vwTmWVCode
WHERE  BaPersonID = {BaPersonID}
ORDER BY DatumVon DESC', N'Basis WV Code (diverse Textmarken)', N'vwTmWVCode', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BK', N'Briefkopf', 1, N'DECLARE @ID int
SET @ID = {Absender}

IF @ID >= 0 
   SET @ID = -{LeistungUserID}
ELSE
   SET @ID = -{UserID}

SELECT <TableColumn>
FROM   vwTmBriefkopf
WHERE  BenutzerNr = -@ID', N'Div. Textmarken für Briefkopf.', N'vwTmBriefkopf', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Bp', N'Betroffene Person', 1, N'SELECT <TableColumn>
FROM   dbo.vwTmPerson
WHERE  BaPersonID = {BetrPersonID}', N'Fallträger (diverse Textmarken)', N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpAufenthaltAdresse', N'Betroffene Person', 1, N'select top 1
       isNull(AdressZusatz + '', '','''') +
       isNull(Strasse + isNull('' '' + HausNr,'''') + '', '','''') +
       isNull(PLZ + '' '','''') + Ort
from   BaAdresse
where  BaPersonID = {BetrPersonID} and
       AdresseCode = 2 and
       getdate() between isNull(DatumVon,getdate()) and isNull(DatumBis,getdate())', N'aktueller Aufenthaltsort: Institution Adresse (Strasse HausNr, PLZ Ort)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpAufenthaltInstitutionName', N'Betroffene Person', 1, N'select top 1 InstitutionName
from   BaAdresse
where  BaPersonID = {BetrPersonID} and
       AdresseCode = 2 and
       getdate() between isNull(DatumVon,getdate()) and isNull(DatumBis,getdate())', N'aktueller Aufenthaltsort: InstitutionName', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpBankZKBKLVm', N'Betroffene Person', 1, N'select top 1 ZAH.BankKontoNummer + isNull('' ('' + convert(varchar,BNK.ClearingNr) + '')'','''')
from   KgPeriode PER
       inner join FaLeistung    LEI on LEI.FaLeistungID = PER.FaLeistungID
       inner join BaZahlungsweg ZAH on ZAH.BaZahlungswegID = PER.BaZahlungswegID
       left  join BaBank        BNK on BNK.BaBankID = ZAH.BaBankID
where  LEI.BaPersonID = {BetrPersonID}
order by PER.PeriodeVon desc', N'Verwaltung Kliententgelder: ZKB Kontokorrent-KontoNr des Mandanten (KontoNr/ClearingNr)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpBankZKBKLVmIBAN', N'Betroffene Person', 1, N'select top 1 ZAH.IBANNummer
from   KgPeriode PER
       inner join FaLeistung    LEI on LEI.FaLeistungID = PER.FaLeistungID
       inner join BaZahlungsweg ZAH on ZAH.BaZahlungswegID = PER.BaZahlungswegID
       left  join BaBank        BNK on BNK.BaBankID = ZAH.BaBankID
where  LEI.BaPersonID = {BetrPersonID}
order by PER.PeriodeVon desc', N'Verwaltung Kliententgelder: ZKB IBAN-Nr des Kontokorrent-Kontos des Mandanten', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpKinderGleicherHaushalt', N'Betroffene Person', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 0)', N'Auflistung aller Kinder im gleichen Haushalt.
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpKinderLeibliche', N'Betroffene Person', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 1)', N'Auflistung leibliche Kinder
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpVmMassnahmeBeschlussVom', N'Betroffene Person', 1, N'select top 1 Convert(varchar, MSN.DatumVon, 104)
from   VmMassnahme MSN
       inner join FaLeistung LEI on LEI.FaLeistungID = MSN.FaLeistungID
where  LEI.BaPersonID = {BetrPersonID}
order by MSN.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpVmMassnahmeMandatstyp', N'Betroffene Person', 1, N'select top 1 MSN.Mandatstyp
from   VmMassnahme MSN
       inner join FaLeistung LEI on LEI.FaLeistungID = MSN.FaLeistungID
where  LEI.BaPersonID = {BetrPersonID}
order by MSN.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpVmMassnahmeVISFallNr', N'Betroffene Person', 1, N'select top 1 MSN.VIS_VormschID
from   VmMassnahme MSN
       inner join FaLeistung LEI on LEI.FaLeistungID = MSN.FaLeistungID
where  LEI.BaPersonID = {BetrPersonID}
order by MSN.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpVmMassnahmeZGB', N'Betroffene Person', 1, N'select top 1 ZGB
from   VmMassnahme MSN
       inner join FaLeistung LEI on LEI.FaLeistungID = MSN.FaLeistungID
where  LEI.BaPersonID = {BetrPersonID}
order by MSN.DatumVon desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpWohnsitzAdresseGesperrt', N'Betroffene Person', 1, N'SELECT TOP 1 
  BpWohnsitzAdresseGesperrt = ''Adresssperre vorhanden!''
FROM dbo.BaAdresse  WITH (READUNCOMMITTED)
WHERE BaPersonID = {BetrPersonID}
  AND AdresseCode = 1 /* Wohnsitz */
  AND AdresseGesperrt = 1
  AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
ORDER BY DatumVon DESC', N'Gesperrte Wohnsitzadresse: Adressesperre vorhanden!', NULL, NULL, 0, 0)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BpWVCode', N'Betroffene Person', 1, N'select top 1 LOV.ShortText
from   BaWVCode BWV
       left join XLOVCode LOV on LOV.LOVName = ''BaWVCode'' and
                                 LOV.Code = WVCode
where  BWV.BaPersonID =  {BetrPersonID} 
  and  BWV.BaWVStatusCode = 1 -- richtig
  and GETDATE() between ISNULL(BWV.DatumVon, GETDATE()) and ISNULL(BWV.DatumBis, GETDATE())
order by DatumVon desc', N'aktueller/zuletzt gültiger WVCode (Kurzform) der betroffenen Person', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BriefkopfAdresse', N'Briefkopf', 1, N'DECLARE @ID int
SET @ID = {Absender}

IF @ID >= 0 OR @ID IS NULL
	SET @ID = -{UserID}

SELECT OrgEinheitAdresseFeld
FROM   vwTmUser
WHERE  BenutzerNr = -@ID', N'Adresse im Briefkopf', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BriefkopfLogo', N'Briefkopf', 3, N'DECLARE @ID int
SET @ID = {Absender}

IF @ID >= 0 OR @ID IS NULL
	SET @ID = -{UserID}

SELECT OrgEinheitLogoMitFMT
FROM   vwTmUser
WHERE  BenutzerNr = -@ID', N'Das Logo des Briefkopf', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BriefkopfTelFaxWWW', N'Briefkopf', 1, N'DECLARE @ID int
SET @ID = {Absender}

IF @ID >= 0 OR @ID IS NULL
	SET @ID = -{UserID}

SELECT OrgEinheitTelFaxWWW
FROM   vwTmUser
WHERE  BenutzerNr = -@ID', N'Telefonnummer und Faxnummer der Stelle, sowie die Internetadresse der Dienstabteilung resp. Sozialzentren', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BudgetblattAbzuegeTabelle', N'W Budgetblatt', 1, N'-- Abzüge
DECLARE @BgBudgetID int
SET @BgBudgetID = {BgBudgetID}
DECLARE @OhneZukuenftigeLeistungen bit
SET @OhneZukuenftigeLeistungen = {OHNEZUKUENFTIGELEISTUNGEN}
-- SET @BgBudgetID = 113340

DECLARE @GetDate datetime
SELECT @GetDate = CASE WHEN BBG.MasterBudget = 1
                  THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(GetDate(), IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                  ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                  END
FROM   dbo.BgBudget BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
WHERE  BBG.BgBudgetID = @BgBudgetID

SELECT 
 Dri = CASE WHEN BPO.VerwaltungSD = 1 THEN ''SOD'' ELSE ''KL'' END,
 NextCell = NULL,
 Buchungstext = ISNULL(BPO.Buchungstext, BKA.Name),
 NextCell = NULL,
 Parkiert = '''', -- Einnahmen sind nie im Ausgabenkonto parkiert
 NextCell = NULL,
 NameVorname = COALESCE(PRS.NameVorname, ''Unterstützte Personen''),
 NextCell = NULL,
 Replace(Convert(varchar(20), BPO.BetragBudget, 1), '','', ''''''''),
 NextCell = NULL
 
FROM dbo.VwBgPosition BPO
       INNER JOIN dbo.BgBudget                 BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
       LEFT  JOIN dbo.vwPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BPO.BaPersonID
       INNER JOIN dbo.BgFinanzplan             FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
       INNER JOIN dbo.FaLeistung               LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
       LEFT  JOIN dbo.BgAuszahlungPerson       BAP WITH(READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH(READUNCOMMITTED)
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                       ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
       LEFT  JOIN   (SELECT BUC.BgBudgetID, BUK.BgPositionID,
                            Status       = MAX(BUC.KbBuchungStatusCode),
                            StatusMin    = MIN(BUC.KbBuchungStatusCode),
                            AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                     FROM   dbo.KbBuchungKostenart BUK WITH(READUNCOMMITTED)
                            LEFT OUTER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                     GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID AND STA.BgPositionID = BPO.BgPositionID
	LEFT JOIN dbo.BgPositionsart 	BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID 
	LEFT JOIN dbo.BgKostenart 	BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BPA.BgKostenartID
WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 1 AND -- Einnahmen
	BPO.BgBewilligungStatusCode not in (2,9) AND -- Bewilligung abgelehnt, gesperrt, wird aber nachdem erstellen der Belege nicht weiter nachgeführt
	BPO.BetragBudget <> 0 AND
	(STA.Status IS NULL OR STA.Status NOT IN (7, 15)) AND
	(STA.StatusMin IS NULL OR STA.StatusMin NOT IN (7, 15)) AND -- gesperrt, abgelehnt
	CASE WHEN BDG.MasterBudget = 0 OR @OhneZukuenftigeLeistungen = 0 OR
		COALESCE(BPO.DatumVon, FPL.DatumVon, FPL.GeplantVon) <= dbo.fnMAX(@GetDate, IsNull(FPL.DatumVon, FPL.GeplantVon)) THEN 1
	ELSE 0
	END = 1 AND
	CASE WHEN BDG.MasterBudget = 1 THEN 
		CASE WHEN (FPL.BgBewilligungStatusCode < 5 OR BPO.BgBewilligungStatusCode = 5 OR BPO.BgKategorieCode = 1)-- Ausgaben müssen (bis jetzt) nicht bewilligt werden
			AND COALESCE(BPO.DatumBis, FPL.DatumBis, FPL.GeplantBis) >= @GetDate THEN 1	-- Im bewilligten Master-Budget sollen nur bewilligte Positionen angezeigt werden, die nicht in der Vergangenheit liegen
		ELSE 0
		END
	ELSE	1
        END = 1
ORDER BY BKA.KontoNr ASC', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BudgetblattBedarfTabelle', N'W Budgetblatt', 1, N'-- Bedarf
DECLARE @BgBudgetID int
SET @BgBudgetID = {BgBudgetID}
DECLARE @OhneZukuenftigeLeistungen bit
SET @OhneZukuenftigeLeistungen = {OHNEZUKUENFTIGELEISTUNGEN}
-- SET @BgBudgetID = 113340

DECLARE @GetDate datetime
SELECT @GetDate = CASE WHEN BBG.MasterBudget = 1
                  THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(GetDate(), IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                  ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                  END
FROM   dbo.BgBudget BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
WHERE  BBG.BgBudgetID = @BgBudgetID

SELECT 
 Dri = CASE WHEN BPO.BgSpezkontoID IS NOT NULL THEN ''KL''
	-- Anforderung: Bei Ausgaben aus dem Ausgabenkonto wird
	-- immer der Klient als Empfänger angenommen.
	WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN ''D'' ELSE ''KL'' END,
 NextCell = NULL,
 Buchungstext = ISNULL(BPO.Buchungstext, BKA.Name),
 NextCell = NULL,
 Parkiert = CASE WHEN BPO.BgSpezkontoID IS NOT NULL THEN ''Ausg'' ELSE '''' END,
 NextCell = NULL,
 NameVorname = COALESCE(PRS.NameVorname, ''Unterstützte Personen''),
 NextCell = NULL,
 Replace(Convert(varchar(20), BPO.BetragBudget, 1), '','', ''''''''),
 NextCell = NULL
 
FROM dbo.VwBgPosition BPO
       INNER JOIN dbo.BgBudget                 BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
       LEFT  JOIN dbo.vwPerson 	               PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BPO.BaPersonID
       INNER JOIN dbo.BgFinanzplan             FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
       INNER JOIN dbo.FaLeistung               LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
       LEFT  JOIN dbo.BgAuszahlungPerson       BAP WITH(READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH(READUNCOMMITTED)
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                       ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
       LEFT  JOIN   (SELECT BUC.BgBudgetID, BUK.BgPositionID,
                            Status       = MAX(BUC.KbBuchungStatusCode),
                            StatusMin    = MIN(BUC.KbBuchungStatusCode),
                            AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                     FROM   dbo.KbBuchungKostenart BUK WITH(READUNCOMMITTED)
                            LEFT OUTER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                     GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID AND STA.BgPositionID = BPO.BgPositionID
	LEFT JOIN dbo.BgPositionsart 	BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID 
	LEFT JOIN dbo.BgKostenart 	BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BPA.BgKostenartID
WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (2, 100) AND -- Ausgaben
	BPO.BgBewilligungStatusCode not in (2,9) AND -- Bewilligung abgelehnt, gesperrt
	BPO.BetragBudget <> 0 AND
	(STA.Status IS NULL OR STA.Status NOT IN (7, 15)) AND
	(STA.StatusMin IS NULL OR STA.StatusMin NOT IN (7, 15)) AND  -- gesperrt, abgelehnt
	CASE WHEN BDG.MasterBudget = 0 OR @OhneZukuenftigeLeistungen = 0 OR
		COALESCE(BPO.DatumVon, FPL.DatumVon, FPL.GeplantVon) <= dbo.fnMAX(@GetDate, IsNull(FPL.DatumVon, FPL.GeplantVon)) THEN 1
	ELSE 0
	END = 1 AND
	CASE WHEN BDG.MasterBudget = 1 THEN 
		CASE WHEN (FPL.BgBewilligungStatusCode < 5 OR BPO.BgBewilligungStatusCode = 5)
			AND COALESCE(BPO.DatumBis, FPL.DatumBis, FPL.GeplantBis) >= @GetDate THEN 1	-- Im bewilligten Master-Budget sollen nur bewilligte Positionen angezeigt werden, die nicht in der Vergangenheit liegen
		ELSE 0
		END
	ELSE	1
        END = 1
ORDER BY BKA.KontoNr ASC', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BudgetblattMonatJahr', N'W Budgetblatt', 1, N'SELECT MonatJahr = dbo.fnxmonat(BGB.Monat) + '' '' + CONVERT(varchar(4),BGB.Jahr)
FROM BgBudget BGB
WHERE BGB.BgBudgetID = {BgBudgetID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BudgetblattUnterstuetztePersonenTabelle', N'W Budgetblatt', 1, N'SELECT
 NameGeburtsdatum = BPA.Name + '' '' + BPA.Vorname + '', '' + Convert(VARCHAR, BPA.Geburtsdatum, 104),
 NextCell = NULL
FROM BgBudget BDG
--	INNER JOIN BgFinanzplan BGF ON BDG.BgFinanzplanID = BGF.BgFinanzplanID
	INNER JOIN BgFinanzplan_BaPerson BFB ON BFB.BgFinanzplanID = BDG.BgFinanzplanID AND BFB.IstUnterstuetzt = 1
	INNER JOIN BaPerson BPA ON BFB.BaPersonID = BPA.BaPersonID
WHERE BDG.BgBudgetID = {BgBudgetID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'BudgetblattVerrechnungTabelle', N'W Budgetblatt', 1, N'-- Verrechnung
DECLARE @BgBudgetID int
SET @BgBudgetID = {BgBudgetID}
DECLARE @OhneZukuenftigeLeistungen bit
SET @OhneZukuenftigeLeistungen = {OHNEZUKUENFTIGELEISTUNGEN}
-- SET @BgBudgetID = 113340

DECLARE @GetDate datetime
SELECT @GetDate = CASE WHEN BBG.MasterBudget = 1
                  THEN dbo.fnDateOf(CONVERT(datetime, dbo.fnMIN(dbo.fnMAX(GetDate(), IsNull(BFP.DatumVon, BFP.GeplantVon)), IsNull(BFP.DatumBis, BFP.GeplantBis))))
                  ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                  END
FROM   dbo.BgBudget BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
WHERE  BBG.BgBudgetID = @BgBudgetID

SELECT 
	Dri = CASE WHEN KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NULL THEN ''D'' ELSE ''KL'' END,
	NextCell = NULL,
	Buchungstext = COALESCE(BPO.Buchungstext, BPA.Name, BSK.NameSpezkonto) + IsNull('' ('' + PRS.NameVorname + '')'', ''''),
	NextCell = NULL,
	Parkiert = '''', -- Verrechnungen sind nie auf dem Ausgabenkonto parkiert
	NextCell = NULL,
	NameVorname = COALESCE(PRS.NameVorname, ''''),
	NextCell = NULL,
	Replace(Convert(varchar(20), BPO.BetragBudget, 1), '','', ''''''''),
	NextCell = NULL
 
FROM dbo.VwBgPosition BPO
       INNER JOIN dbo.BgBudget			BDG WITH(READUNCOMMITTED) ON BDG.BgBudgetID = BPO.BgBudgetID
       LEFT  JOIN dbo.vwPerson 			PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = BPO.BaPersonID
       INNER JOIN dbo.BgFinanzplan		FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
       INNER JOIN dbo.FaLeistung		LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
       LEFT  JOIN dbo.BgAuszahlungPerson	BAP WITH(READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID AND
                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                               FROM   dbo.BgAuszahlungPerson WITH(READUNCOMMITTED)
                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                               ORDER BY
                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                      WHEN BaPersonID = LEI.BaPersonID THEN 3
                                                                                       ELSE 4
                                                                                 END)
       LEFT  JOIN dbo.vwKreditor		KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
       LEFT  JOIN dbo.BgSpezkonto		BSK WITH(READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
       LEFT  JOIN dbo.BgPositionsart		BPA WITH(READUNCOMMITTED) ON BPA.BgPositionsartID = COALESCE(BPO.BgPositionsartID,BSK.BgPositionsartID)
       LEFT  JOIN   (SELECT BUC.BgBudgetID, BUK.BgPositionID,
                            Status       = MAX(BUC.KbBuchungStatusCode),
                            StatusMin    = MIN(BUC.KbBuchungStatusCode),
                            AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                     FROM   dbo.KbBuchungKostenart BUK WITH(READUNCOMMITTED)
                            LEFT OUTER JOIN dbo.KbBuchung BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = BUK.KbBuchungID
                     GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID AND STA.BgPositionID = BPO.BgPositionID
	LEFT JOIN dbo.BgKostenart 	BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BSK.BgKostenartID
WHERE BPO.BgBudgetID = {BgBudgetID} AND BPO.BgKategorieCode = 3 AND -- Verrechnungen
	BPO.BgBewilligungStatusCode not in (2,9) AND -- Bewilligung abgelehnt, gesperrt
	BPO.BetragBudget <> 0 AND
	(STA.Status IS NULL OR STA.Status NOT IN (7, 15)) AND
	(STA.StatusMin IS NULL OR STA.StatusMin NOT IN (7, 15)) AND  -- gesperrt, abgelehnt
	CASE WHEN BDG.MasterBudget = 0 OR @OhneZukuenftigeLeistungen = 0 OR
		COALESCE(BPO.DatumVon, FPL.DatumVon, FPL.GeplantVon) <= dbo.fnMAX(@GetDate, IsNull(FPL.DatumVon, FPL.GeplantVon)) THEN 1
	ELSE 0
	END = 1 AND
	CASE WHEN BDG.MasterBudget = 1 THEN 
		CASE WHEN (FPL.BgBewilligungStatusCode < 5 OR BPO.BgBewilligungStatusCode = 5)
			AND COALESCE(BPO.DatumBis, FPL.DatumBis, FPL.GeplantBis) >= @GetDate THEN 1	-- Im bewilligten Master-Budget sollen nur bewilligte Positionen angezeigt werden, die nicht in der Vergangenheit liegen
		ELSE 0
		END
	ELSE	1
        END = 1
ORDER BY BKA.KontoNr', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'CH', N'Checkin', 1, N'SELECT <TableColumn>
FROM   vwTmCheckin
WHERE  FaCheckinID = {FaCheckinID}', N'Textmarke für FaCheckin', N'vwTmCheckin', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumBewilligungErteilt', N'Leistungsentscheid', 1, N'SELECT Top 1 BBW.Datum
FROM   BgBewilligung BBW
WHERE  BBW.BgFinanzplanID = {BgFinanzplanID}
AND BBW.BgBudgetID IS NULL  
AND BBW.BgBewilligungCode = 2
ORDER BY BBW.Datum desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeute', N'Andere', 1, N'select convert(varchar,getdate(),104)', N'Format 06.04.2004', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'DatumHeute2', N'Andere', 1, N'select convert(varchar,day(getdate())) + ''. '' +
       dbo.fnXMonat(month(getdate())) + '' '' +
       convert(varchar,year(getdate()))', N'Format 6. Dezember 2004', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Detail', N'W Klientenabrechnung', 1, N'SELECT <TableColumn>
FROM   vwTmAbrechnungDetail
WHERE  WhDetailblattID = {WhDetailblattID}', NULL, N'vwTmAbrechnungDetail', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'EKDatumLetzteRefPruefung', N'EK Entscheid', 1, N'SELECT CONVERT(VARCHAR(10),MAX(DatumRef.Datum),104) FROM
(
SELECT 
MAX(Datum) AS DATUM
FROM FaJournal
WHERE FaLeistungid = {FaLeistungID} 
AND ManuellerEintrag = 0
AND (CONVERT(VARCHAR(50),text) LIKE ''Finanzplan #[0-9]%visiert durch Referentin'' OR
     CONVERT(VARCHAR(50),text) LIKE ''Finanzplan #[0-9]%, Referentin'')
     
UNION
SELECT  
MAX(Datum) AS DATUM
FROM FaJournal
WHERE FaFallID = {FaFallID} 
AND CONVERT(VARCHAR(50),text) LIKE ''LE von Ref.%''
) DatumRef', N'Sucht den letzten Eintrag der ReferentInnenprüfung aus dem Fallverlauf
26.08.09 sozstu', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'EKGrund', N'EK Entscheid', 1, N'SELECT 
CASE 
	WHEN Code = 28 THEN ''Bitte hier genauen Grund angeben!''
	ELSE [Text]
END
	
FROM xLOVCode
WHERE LOVName LIKE ''WhVerfuegungGrund'' AND Code = {WhVerfuegungGrundCode}', N'EK Grund aus Maske - SEK-Entscheid
8.2.2011 sozstu', NULL, NULL, 0, 0)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Ersatzeinkommen', N'Basis', 1, N'SELECT dbo.fnTmErsatzeinkommen({BaPersonID})', N'Liste mit Zeilenumbruch.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Fall', N'Fall', 1, N'SELECT <TableColumn>
FROM vwTmFall
WHERE FallNummer = {FaFallID}', NULL, N'VwTmFall', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FallAlleAktivenPersonen', N'Fall', 1, N'SELECT 
		PTemp.BaPersonID,
		NextCell = NULL,
		PTemp.NameVorname,
		NextCell = NULL,
		CONVERT(VARCHAR(10),PTemp.Gebdat,104),
		NextCell = NULL
FROM 
	(SELECT 
			P.BaPersonID,
			P.Name + '' '' + P.Vorname AS NameVorname, 
			P.Geburtsdatum As GebDat,
			Sort	 = 1
	FROM BaPerson P
	JOIN FaFall F ON P.BaPersonid = F.BaPersonid
	WHERE F.FaFallID = {FaFallID}
	UNION
	SELECT  
			P.BaPersonID,
			P.Name + '' '' + P.Vorname, 
			P.Geburtsdatum,
			Sort	 = 0
	FROM BaPerson P 
	JOIN FaFallPerson FAP ON P.BaPersonid = FAP.BaPersonID
	WHERE
		FAP.Datumbis IS NULL
	AND PersonOhneLeistung = 0
	AND FAP.FaFallid = {FaFallID}
	AND FAP.BaPersonID NOT IN (Select BaPersonID FROM FaFAll WHERE FaFallID = {FaFallID})) PTemp

ORDER BY PTemp.Sort DESC,PTemp.GebDat ASC', N'Alle aktiven Personen des aktuellen Falls als Tabelle', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FallProfil', N'Fall', 1, N'SELECT dbo.fnGetFunktionsProfil({FaFallID})', N'Textmarke zeigt das Profil an, dem ein Fall zugeordnet wird. (Ein Fall kann nur einem Profil zugeordnet werden. Der Fall, nicht die Person wird dem Profil zugeordnet.)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FPAnzUnterstuetzePersonenKinder', N'Finanzplan', 1, N'--Ausgabeformat: x/x

DECLARE @FP int

--neuester FP visiert
SET @FP = (	SELECT TOP 1 BgFinanzplanID FROM dbo.BgFinanzplan
			WHERE BgBewilligungStatusCode = 5 AND FaLeistungID = {FaLeistungID}
			GROUP BY BgFinanzplanID, DatumVon
			ORDER BY DatumVon DESC)

IF @FP IS NULL
BEGIN  
	--neuester FP restliche
	SET @FP = (	SELECT TOP 1 BgFinanzplanID FROM dbo.BgFinanzplan
				WHERE FaLeistungID = {FaLeistungID}
				GROUP BY BgFinanzplanID, DatumVon
				ORDER BY DatumVon DESC)
END

IF @FP IS NOT NULL
BEGIN
	-- unterstützte Personenzahl aus Finanzplan
	DECLARE @PersU Varchar(2)  --Anzahl Personen im FP
	DECLARE @KindU Varchar(2)  --Anzahl Kinder im FP

	SET @PersU =	(SELECT COUNT(*) FROM dbo.BgFinanzplan_BaPerson FPP
					JOIN dbo.vwPerson P ON FPP.BaPersonID = P.BaPersonID
					WHERE FPP.IstUnterstuetzt = 1
					AND BgFinanzplanID = @FP)

	SET @KindU =	(SELECT COUNT(*) FROM dbo.BgFinanzplan_BaPerson FPP
					JOIN dbo.vwPerson P ON FPP.BaPersonID = P.BaPersonID
					WHERE FPP.IstUnterstuetzt = 1 AND P.[Alter] < 18
					AND BgFinanzplanID = @FP)

	SELECT @PersU + ''/'' + @KindU as ''AnzPersKind''
END

/* ----------------------------------------------
	ohne Finanzplan, Personen aus Klientensystem
*/ ----------------------------------------------
IF @FP IS NULL
BEGIN
	SELECT CONVERT(VARCHAR(2),AnzAktivePersMitLeistung) + ''/'' + CONVERT(VARCHAR(2),AnzAktiveKinderMitLeistung) 
	FROM vwTmFall
	WHERE Fallnummer = {FaFallID}
END', N'Abfrage für Anzahl Personen/Kinder aus Finanzplan oder Fall
1. neuester visierter FP - aus aktueller Leistung
2. ohne visierter,  neuster FP egal welcher Status - aus aktueller Leistung
3. ohne FP, gemäss Klientensystem - aus aktuellem Fall
26.08.2009 sozstu', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Ft', N'Klient FT', 1, N'SELECT <TableColumn>
FROM   vwTmPerson
WHERE  BaPersonID = {FT}', N'Fallträger (diverse Textmarken)', N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FtKinderGleicherHaushalt', N'Klient FT', 1, N'SELECT dbo.fnTmKinder({FT}, ''NamenVornamenJahrHeimat'', 1, 0)', N'Auflistung aller Kinder im gleichen Haushalt.
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'FtKinderLeibliche', N'Klient FT', 1, N'SELECT dbo.fnTmKinder({FT}, ''NamenVornamenJahrHeimat'', 1, 1)', N'Auflistung leibliche Kinder
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'GvGesuch', N'Gesuchverwaltung', 1, N'SELECT <TableColumn>
FROM dbo.vwTmGvGesuch
WHERE GvGesuchID = {GvGesuchID};', N'Stellt diverse Textmarken für ein Gesuch zur Verfügung.', N'vwTmGvGesuch', 27, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Haushaltsgroesse', N'Leistungsentscheid', 1, N'SELECT CASE WHEN count(*) = 1 
         THEN convert(varchar, count(*)) + '' Person''
         ELSE convert(varchar, count(*)) + '' Personen''
       END
FROM   BgFinanzPlan_BaPerson 
WHERE  BgFinanzPlanID = {BgFinanzplanID}
--AND    IstUnterstuetzt = 1  --auskommentiert 17.09.08 sozstu', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolviertePersonenAktiv', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrAktInvPersonen CURSOR FOR

SELECT FAL.FaFallID,
	   CASE WHEN INV.Vorname is null or INV.Vorname = '''' THEN '''' ELSE INV.Vorname END
       + CASE WHEN INV.Name is null or INV.Name = '''' THEN '''' ELSE '', '' + INV.Name END
       + CASE WHEN dbo.fnLOVText(''BaRolle'', INV.RolleCode) is null or dbo.fnLOVText(''BaRolle'', INV.RolleCode) = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaRolle'', INV.RolleCode) END
       + CASE WHEN INV.RolleBemerkung is null or INV.RolleBemerkung = '''' THEN '''' ELSE '', '' + INV.RolleBemerkung END
       + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) END
       + CASE WHEN INV.DatumBis is null or INV.DatumBis = '''' THEN '''' ELSE '' - '' + Convert(varchar, IsNull(INV.DatumBis, null), 104) END
FROM   FaFall FAL
       INNER JOIN FaInvolviertePerson INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN BaPerson            PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID in (SELECT	DISTINCT FaFallID
			FROM    FaFallPerson
			WHERE   BaPersonID = {FT}
			AND	FaFallID <> {FaFallID}
			AND	(DatumBis is null or DatumBis < GetDate()))
ORDER BY INV.DatumBis, INV.DatumVon DESC, INV.Name ASC

SET @oldFallNr = 0

OPEN csrAktInvPersonen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrAktInvPersonen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

	IF NOT @oldFallNr = @actFallNr BEGIN
		SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
		SET @oldFallNr = @actFallNr
	END

    IF NOT @Result = '''' BEGIN 		
		SET @Result = @Result + CHAR(13) + CHAR(10)		
	END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrAktInvPersonen
DEALLOCATE csrAktInvPersonen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Personen Aktiv', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolviertePersonenFT', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrAktInvPersonen CURSOR FOR

SELECT FAL.FaFallID,
       CASE WHEN INV.Vorname is null or INV.Vorname = '''' THEN '''' ELSE INV.Vorname END
       + CASE WHEN INV.Name is null or INV.Name = '''' THEN '''' ELSE '', '' + INV.Name END
       + CASE WHEN dbo.fnLOVText(''BaRolle'', INV.RolleCode) is null or dbo.fnLOVText(''BaRolle'', INV.RolleCode) = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaRolle'', INV.RolleCode) END
       + CASE WHEN INV.RolleBemerkung is null or INV.RolleBemerkung = '''' THEN '''' ELSE '', '' + INV.RolleBemerkung END
       + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) END
       + CASE WHEN INV.DatumBis is null or INV.DatumBis = '''' THEN '''' ELSE '' - '' + Convert(varchar, IsNull(INV.DatumBis, null), 104) END
FROM   FaFall FAL
       INNER JOIN FaInvolviertePerson INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN BaPerson            PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID = isnull({FaFallID},FAL.FaFallID)
ORDER BY INV.DatumBis, INV.DatumVon DESC, INV.Name ASC

SET @oldFallNr = 0

OPEN csrAktInvPersonen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrAktInvPersonen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
	SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
        SET @oldFallNr = @actFallNr
    END

    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrAktInvPersonen
DEALLOCATE csrAktInvPersonen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Personen FT', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolviertePersonenNichtAktiv', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrAktInvPersonen CURSOR FOR

SELECT FAL.FaFallID,
	   CASE WHEN INV.Vorname is null or INV.Vorname = '''' THEN '''' ELSE INV.Vorname END
       + CASE WHEN INV.Name is null or INV.Name = '''' THEN '''' ELSE '', '' + INV.Name END
       + CASE WHEN dbo.fnLOVText(''BaRolle'', INV.RolleCode) is null or dbo.fnLOVText(''BaRolle'', INV.RolleCode) = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaRolle'', INV.RolleCode) END
       + CASE WHEN INV.RolleBemerkung is null or INV.RolleBemerkung = '''' THEN '''' ELSE '', '' + INV.RolleBemerkung END
       + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) END
       + CASE WHEN INV.DatumBis is null or INV.DatumBis = '''' THEN '''' ELSE '' - '' + Convert(varchar, IsNull(INV.DatumBis, null), 104) END
FROM   FaFall FAL
       INNER JOIN FaInvolviertePerson INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN BaPerson            PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID in (SELECT	DISTINCT FaFallID
			FROM    FaFallPerson
			WHERE   BaPersonID = {FT}
			AND	FaFallID <> {FaFallID}
			AND	DatumBis is not null AND DatumBis > GetDate())
ORDER BY INV.DatumBis, INV.DatumVon DESC, INV.Name ASC

SET @oldFallNr = 0

OPEN csrAktInvPersonen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrAktInvPersonen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

	IF NOT @oldFallNr = @actFallNr BEGIN
		SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
		SET @oldFallNr = @actFallNr
	END

    IF NOT @Result = '''' BEGIN 		
		SET @Result = @Result + CHAR(13) + CHAR(10)		
	END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrAktInvPersonen
DEALLOCATE csrAktInvPersonen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Personen Nicht Aktiv', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolvierteStellenAktiv', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrInvStellen CURSOR FOR

SELECT FAL.FaFallID,
	   IsNull(INS.InstitutionName, '''')
       + CASE WHEN INS.InstitutionTypCode is null or INS.InstitutionTypCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionTyp'', INS.InstitutionTypCode) END
	   + CASE WHEN INV.InstitutionZusatzCode is null or INV.InstitutionZusatzCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionZusatz'', INV.InstitutionZusatzCode) END
	   + CASE WHEN INV.Ansprechperson is null or INV.Ansprechperson = '''' THEN '''' ELSE '', '' + INV.Ansprechperson END
	   + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) + ''-'' END
	   + IsNull(Convert(varchar, IsNull(INV.DatumBis, null), 104), '''')
FROM   FaFall FAL
       INNER JOIN FaInvolvierteInstitution INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwInstitution            INS ON INS.BaInstitutionID = INV.BaInstitutionID
       LEFT  JOIN BaPerson                 PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID in (SELECT	DISTINCT FaFallID
			FROM    FaFallPerson
			WHERE   BaPersonID = {FT}
			AND	FaFallID <> {FaFallID}
			AND	(DatumBis is null or DatumBis < GetDate()))
ORDER BY INV.DatumBis, INV.DatumVon DESC, INS.InstitutionName ASC

SET @oldFallNr = 0

OPEN csrInvStellen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvStellen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
		SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
		SET @oldFallNr = @actFallNr
	END

    IF NOT @Result = '''' BEGIN 		
		SET @Result = @Result + CHAR(13) + CHAR(10)		
	END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvStellen
DEALLOCATE csrInvStellen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Stellen Aktiv', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolvierteStellenFT', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrInvStellen CURSOR FOR

SELECT FAL.FaFallID,
	   IsNull(INS.InstitutionName, '''')
       + CASE WHEN INS.InstitutionTypCode is null or INS.InstitutionTypCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionTyp'', INS.InstitutionTypCode) END
	   + CASE WHEN INV.InstitutionZusatzCode is null or INV.InstitutionZusatzCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionZusatz'', INV.InstitutionZusatzCode) END
	   + CASE WHEN INV.Ansprechperson is null or INV.Ansprechperson = '''' THEN '''' ELSE '', '' + INV.Ansprechperson END
	   + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) + ''-'' END
	   + IsNull(Convert(varchar, IsNull(INV.DatumBis, null), 104), '''')
FROM   FaFall FAL
       INNER JOIN FaInvolvierteInstitution INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwInstitution            INS ON INS.BaInstitutionID = INV.BaInstitutionID
       LEFT  JOIN BaPerson                 PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID = IsNull({FaFallID},FAL.FaFallID)
ORDER BY INV.DatumBis, INV.DatumVon DESC, INS.InstitutionName ASC

SET @oldFallNr = 0

OPEN csrInvStellen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvStellen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
		SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
		SET @oldFallNr = @actFallNr
	END

    IF NOT @Result = '''' BEGIN 		
		SET @Result = @Result + CHAR(13) + CHAR(10)		
	END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvStellen
DEALLOCATE csrInvStellen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Stellen FT', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvolvierteStellenNichtAktiv', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
SET @Result = ''''

DECLARE csrInvStellen CURSOR FOR

SELECT FAL.FaFallID,
	   IsNull(INS.InstitutionName, '''')
       + CASE WHEN INS.InstitutionTypCode is null or INS.InstitutionTypCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionTyp'', INS.InstitutionTypCode) END
	   + CASE WHEN INV.InstitutionZusatzCode is null or INV.InstitutionZusatzCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionZusatz'', INV.InstitutionZusatzCode) END
	   + CASE WHEN INV.Ansprechperson is null or INV.Ansprechperson = '''' THEN '''' ELSE '', '' + INV.Ansprechperson END
	   + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) + ''-'' END
	   + IsNull(Convert(varchar, IsNull(INV.DatumBis, null), 104), '''')
FROM   FaFall FAL
       INNER JOIN FaInvolvierteInstitution INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwInstitution            INS ON INS.BaInstitutionID = INV.BaInstitutionID
       LEFT  JOIN BaPerson                 PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.BaPersonID = {FT}
AND    FAL.FaFallID in (SELECT	DISTINCT FaFallID
			FROM    FaFallPerson
			WHERE   BaPersonID = {FT}
			AND	FaFallID <> {FaFallID}
			AND	DatumBis is not null AND DatumBis > GetDate())
ORDER BY INV.DatumBis, INV.DatumVon DESC, INS.InstitutionName ASC

SET @oldFallNr = 0

OPEN csrInvStellen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvStellen INTO @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
		SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
		SET @oldFallNr = @actFallNr
	END

    IF NOT @Result = '''' BEGIN 		
		SET @Result = @Result + CHAR(13) + CHAR(10)		
	END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvStellen
DEALLOCATE csrInvStellen

SELECT @Result', N'Liste mit Zeilenumbruch. Involvierte Stellen Nicht Aktiv', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvPersAktuellNameRolleAdresseTel', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
SET @Result = ''''

DECLARE csrInvPers CURSOR FOR
SELECT CASE WHEN PRS.VornameName is null or PRS.VornameName = '''' THEN '''' ELSE PRS.VornameName END
       + CASE WHEN dbo.fnLOVText(''BaRolle'', INV.RolleCode) is null or dbo.fnLOVText(''BaRolle'', INV.RolleCode) = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaRolle'', INV.RolleCode) END
       + CASE WHEN INV.Adresse is null or INV.Adresse = '''' THEN '''' ELSE '', '' + replace(INV.Adresse, CHAR(13) + CHAR(10), '', '') END
	   + CASE WHEN INV.Telefon_P is null or INV.Telefon_P = '''' THEN '''' ELSE '', '' + INV.Telefon_P END
	   + CASE WHEN INV.MobilTel1 is null or INV.MobilTel1 = '''' THEN '''' ELSE '', '' + INV.MobilTel1 END
       + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', seit '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) END
FROM   FaFall FAL
       INNER JOIN FaInvolviertePerson INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwPerson            PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.FaFallID = {FaFallID}
AND INV.DatumBis is null
ORDER BY INV.DatumVon DESC, INV.Name ASC

OPEN csrInvPers

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvPers INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvPers
DEALLOCATE csrInvPers

SELECT @Result', N'Liste mit den aktuellen Involvierten Personen.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvPersAlleNameRolleAdresseTel', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
SET @Result = ''''

DECLARE csrInvPers CURSOR FOR
SELECT CASE WHEN PRS.VornameName is null or PRS.VornameName = '''' THEN '''' ELSE PRS.VornameName END
       + CASE WHEN dbo.fnLOVText(''BaRolle'', INV.RolleCode) is null or dbo.fnLOVText(''BaRolle'', INV.RolleCode) = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaRolle'', INV.RolleCode) END
       + CASE WHEN INV.Adresse is null or INV.Adresse = '''' THEN '''' ELSE '', '' + replace(INV.Adresse, CHAR(13) + CHAR(10), '', '') END
	   + CASE WHEN INV.Telefon_P is null or INV.Telefon_P = '''' THEN '''' ELSE '', '' + INV.Telefon_P END
	   + CASE WHEN INV.MobilTel1 is null or INV.MobilTel1 = '''' THEN '''' ELSE '', '' + INV.MobilTel1 END
       + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) + ''-'' END
       + CASE WHEN INV.DatumBis is null or INV.DatumBis = '''' THEN '''' ELSE Convert(varchar, IsNull(INV.DatumBis, null), 104) END
FROM   FaFall FAL
       INNER JOIN FaInvolviertePerson INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwPerson            PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.FaFallID = {FaFallID}
ORDER BY INV.DatumBis, INV.DatumVon DESC, INV.Name ASC

OPEN csrInvPers

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvPers INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvPers
DEALLOCATE csrInvPers

SELECT @Result', N'Liste mit allen Involvierten Personen.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvStellenAktuellNameAdresseTel', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
SET @Result = ''''

DECLARE csrInvStellen CURSOR FOR
SELECT IsNull(INS.InstitutionName, '''')
       + CASE WHEN INS.InstitutionTypCode is null or INS.InstitutionTypCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionTyp'', INS.InstitutionTypCode) END
	   + CASE WHEN INV.Ansprechperson is null or INV.Ansprechperson = '''' THEN '''' ELSE '', '' + INV.Ansprechperson END
	   + CASE WHEN INS.Adresse is null or INS.Adresse = '''' THEN '''' ELSE '', '' + INS.Adresse END
	   + CASE WHEN INS.Telefon is null or INS.Telefon = '''' THEN '''' ELSE '', '' + INS.Telefon END
	   + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', seit '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) END	
FROM   FaFall FAL
       INNER JOIN FaInvolvierteInstitution INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwInstitution            INS ON INS.BaInstitutionID = INV.BaInstitutionID
       LEFT  JOIN BaPerson                 PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.FaFallID = {FaFallID}
AND INV.DatumBis is null
ORDER BY INV.DatumVon DESC, INS.InstitutionName ASC

OPEN csrInvStellen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvStellen INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvStellen
DEALLOCATE csrInvStellen

SELECT @Result', N'Liste mit den aktuellen Involvierten Stellen.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'InvStellenAlleNameAdresseTel', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
SET @Result = ''''

DECLARE csrInvStellen CURSOR FOR
SELECT IsNull(INS.InstitutionName, '''')
       + CASE WHEN INS.InstitutionTypCode is null or INS.InstitutionTypCode = '''' THEN '''' ELSE '', '' + dbo.fnLOVText(''BaInstitutionTyp'', INS.InstitutionTypCode) END
	   + CASE WHEN INV.Ansprechperson is null or INV.Ansprechperson = '''' THEN '''' ELSE '', '' + INV.Ansprechperson END
	   + CASE WHEN INS.Adresse is null or INS.Adresse = '''' THEN '''' ELSE '', '' + INS.Adresse END
	   + CASE WHEN INS.Telefon is null or INS.Telefon = '''' THEN '''' ELSE '', '' + INS.Telefon END
	   + CASE WHEN INV.DatumVon is null or INV.DatumVon = '''' THEN '''' ELSE '', '' + Convert(varchar, IsNull(INV.DatumVon, null), 104) + ''-'' END
	   + IsNull(Convert(varchar, IsNull(INV.DatumBis, null), 104), '''')
FROM   FaFall FAL
       INNER JOIN FaInvolvierteInstitution INV ON INV.FaFallID = FAL.FaFallID
       LEFT  JOIN vwInstitution            INS ON INS.BaInstitutionID = INV.BaInstitutionID
       LEFT  JOIN BaPerson                 PRS ON PRS.BaPersonID = INV.BaPersonID
WHERE  FAL.FaFallID = {FaFallID}
ORDER BY INV.DatumBis, INV.DatumVon DESC, INS.InstitutionName ASC

OPEN csrInvStellen

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrInvStellen INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csrInvStellen
DEALLOCATE csrInvStellen

SELECT @Result', N'Liste mit allen Involvierten Stellen.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Klientensystem', N'Basis', 1, N'SELECT dbo.fnTmKlientensystem({FT}, {FaFallID})', N'Liste mit Zeilenumbruch.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KM', N'Kinds Mutter', 1, N'SELECT <TableColumn>
FROM dbo.vwTmPerson
WHERE BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1 
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED) 
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 2
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)', N'Kindsmutter', N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KMAr', N'Kinds Mutter', 1, N'SELECT TOP 1 <TableColumn>
FROM dbo.vwTmArbeit
WHERE  BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1 
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED)
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 2
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)
ORDER BY DatumVon DESC', N'Kindsmutter Arbeit (diverse Textmarken)', N'vwTmArbeit', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KMFallNr', N'Kinds Mutter', 1, N'SELECT TOP 1 FAL.FaFallID
FROM   dbo.FaFall FAL WITH(READUNCOMMITTED)
WHERE  FAL.BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED)
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 2
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)
ORDER BY FAL.DatumVon DESC', N'Kindsmutter FallNr', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KMKinderGleicherHaushalt', N'Kinds Mutter', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 0)', N'Auflistung aller Kinder im gleichen Haushalt.
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KMKinderLeibliche', N'Kinds Mutter', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 1)', N'Auflistung leibliche Kinder
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KV', N'Kinds Vater', 1, N'SELECT <TableColumn>
FROM dbo.vwTmPerson
WHERE BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1 
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED) 
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 1
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)', N'Kindsvater', N'vwTmPerson', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KVAr', N'Kinds Vater', 1, N'SELECT TOP 1 <TableColumn>
FROM dbo.vwTmArbeit
WHERE  BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1 
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED)
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 1
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)
ORDER BY DatumVon DESC', N'Kindsvater Arbeit (diverse Textmarken)', N'vwTmArbeit', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KVFallNr', N'Kinds Vater', 1, N'SELECT TOP 1 FAL.FaFallID
FROM   dbo.FaFall FAL WITH(READUNCOMMITTED)
WHERE  FAL.BaPersonID = (
  SELECT TOP 1 PRR.BaPersonID_1
  FROM dbo.BaPerson_Relation PRR WITH(READUNCOMMITTED)
  LEFT JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = PRR.BaPersonID_1
  WHERE PRR.BaPersonID_2 = {BetrPersonID}
  AND PRR.BaRelationID = 1
  AND PRS.GeschlechtCode = 1
  AND EXISTS (
    SELECT FP.FaFallPersonID FROM dbo.FaFallPerson FP WITH(READUNCOMMITTED) 
    WHERE FP.FaFallID = {FaFallID}
      AND PRR.BaPersonID_1 = FP.BaPersonID
  )
  ORDER BY PRR.DatumVon DESC
)
ORDER BY FAL.DatumVon DESC', N'Kindsvater FallNr', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KVKinderGleicherHaushalt', N'Kinds Vater', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 0)', N'Auflistung aller Kinder im gleichen Haushalt.
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'KVKinderLeibliche', N'Kinds Vater', 1, N'SELECT dbo.fnTmKinder({BetrPersonID}, ''NamenVornamenJahrHeimat'', 1, 1)', N'Auflistung leibliche Kinder
Name Vorname, Geburtsdatum, Heimatzugehörigkeit, Aufenthaltsort (Zeilenumbruch)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LE', N'Leistungsentscheid', 2, N'SELECT <TableColumn>
FROM   fnTmWhLeistungsentscheid ({BgFinanzplanID})', NULL, N'fnTmWhLeistungsentscheid', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LEAktiveKinderFall', N'Leistungsentscheid', 1, N'SELECT 
	NameVorname = P.Name + '' '' + P.Vorname,
	NextCell    = null,
	GebDat      = CONVERT(VARCHAR(10),P.Geburtsdatum,104),
	NextCell    = null,
	CASE 
	  WHEN dbo.fnBaRelation(F.BaPersonID, P.BaPersonID) = ''Tochter / Adoptivtochter'' THEN ''Eigenes Kind''
	  WHEN dbo.fnBaRelation(F.BaPersonID, P.BaPersonID) = ''Sohn / Adoptivsohn'' THEN ''Eigenes Kind''
	END,
	NextCell    = null,
	NextCell    = null
FROM FaFallPerson FAP
JOIN vwPerson P ON FAP.BaPersonID = P.BaPersonID
JOIN FaFall F ON FAP.FaFallID = F.FaFallID
WHERE
    FAP.FaFallID = {FaFallID}
AND PersonOhneLeistung = 0
AND P.[Alter] < 18
AND FAP.DatumBis is null

UNION ALL
SELECT 
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null

UNION ALL
SELECT 
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null,
	NextCell    = null

ORDER BY 1 DESC', N'Auflistung der Kinder des aktiven Falles in Tabellenform mit 2. Leerzeilen
Wird im Dokument "Erneuerung LE - Zusatzblatt für Kinder" verwendet', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LeistungTLErbringerAktiv', N'Fall', 1, N'SELECT dbo.fnTmTLErbringer({FT},{FaFallID}, ''AKTIV'')', N'Liste der Teilleistungserbringer. Aktive Fälle.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LeistungTLErbringerFT', N'Fall', 1, N'SELECT dbo.fnTmTLErbringer({FT},{FaFallID}, ''FT'')', N'Liste der Teilleistungserbringer. Aktueller Fall.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LeistungTLErbringerNichtAktiv', N'Fall', 1, N'SELECT dbo.fnTmTLErbringer({FT},{FaFallID}, ''NICHTAKTIV'')', N'Liste der Teilleistungserbringer. Nicht Aktive Fälle.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LEMonatBudgetTabelle', N'Leistungsentscheid', 1, N'DECLARE @BgBudgetID  int,
        @GetDate     datetime

SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM   BgBudget
WHERE  BgFinanzPlanID = {BgFinanzplanID}
AND MasterBudget = 1

DECLARE @Positionen  TABLE (id int identity, LA varchar(10), Text varchar(100), BetragAus money, BetragEin money)

-- Ausgaben / Kürzungen
INSERT INTO @Positionen (LA, Text, BetragAus, BetragEin)
  SELECT TMP.KontoNr,
         TMP.Buchungstext,
         CASE WHEN BgKategorieCode = 2 THEN TMP.Betrag
              ELSE -TMP.Betrag
         END,
         NULL
  FROM   dbo.fnWhGetFinanzplanDetail(@BgBudgetID, @GetDate)  TMP
         INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE  BgKategorieCode IN (2, 4) AND -- Ausgaben / Kürzungen 
         TMP.Betrag != $0.00

-- Einnahmen
INSERT INTO @Positionen (LA, Text, BetragAus, BetragEin)
  SELECT TMP.KontoNr, TMP.Buchungstext, NULL, TMP.Betrag
  FROM   dbo.fnWhGetFinanzplanDetail(@BgBudgetID, @GetDate)  TMP
         INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE  BgKategorieCode = 1 AND
         TMP.Betrag != $0.00

-- Output
SELECT LA, 
       NextCell  = null,
       RTrim(LTrim(POS.Text)), 
       NextCell  = null,
       Betrag    = isNull(CONVERT(varchar, LTrim(STR(POS.BetragAus, 19, 2))), ''''),
       NextCell  = null,
       BetragEin = isNull(CONVERT(varchar, LTrim(STR(POS.BetragEin, 19, 2))), ''''),
       NextCell  = null,
       '''',
       NextCell  = null
FROM @Positionen  POS', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'LEUntPersonenTabelle', N'Leistungsentscheid', 1, N'SELECT '''',
       NextCell          = null,
       PersNr            = PRS.BaPersonID,
       NextCell          = null,
       Name              = PRS.Name,
       NextCell          = null,
       Vorname           = PRS.Vorname,
       NextCell          = null,
       PRS.Geburtsdatum,
       NextCell          = null
FROM   BgFinanzPlan_BaPerson SPP
       INNER JOIN vwPerson   PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE  SPP.BgFinanzPlanID = {BgFinanzplanID} AND
       SPP.IstUnterstuetzt = 1', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaAbs', N'MA Absender', 1, N'DECLARE @ID int
SET @ID = {Absender}

IF @ID >= 0 OR @ID IS NULL
	SET @ID = -{LeistungUserID}

SELECT <TableColumn>
FROM   vwTmUser
WHERE  BenutzerNr = -@ID', N'Absender MA', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaAktLeistung', N'MA Aktuelle Leistung', 1, N'declare @VmUserID int

select top 1 @VmUserID = UserID
from   FaLeistung

where  FaFallID = {FaFallID} and
       FaProzessCode = 210 and
       {ProzessCode} = 200
order by DatumVon desc

select <TableColumn>
from   vwTmUser
where  BenutzerNr = isNull(@VmUserID,{LeistungUserID})', N'Mitarbeiter der aktuellen Leistung.', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaAng', N'MA angemeldet', 1, N'SELECT <TableColumn>
FROM   vwTmUser
WHERE  BenutzerNr = {UserID}', N'Angemeldeter Benutzer/MA (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaAngNeueTextmarke', N'MA angemeldet', 1, N'SELECT ''Neue Textmarke''', N'Angemeldeter Benutzer/MA (diverse Textmarken)', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaFaA', N'MA Leistung FaA', 1, N'declare @VmUserID int

select top 1 @VmUserID = UserID
from   FaLeistung
where  FaFallID = {FaFallID} and
       FaProzessCode = 201
order by DatumVon desc

select <TableColumn>
from   vwTmUser
where  BenutzerNr = isNull(@VmUserID,{FallUserID})', N'Mitarbeiter Leistung F Alimente (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaFall', N'MA Fall', 1, N'SELECT <TableColumn>
FROM   vwTmUser
WHERE  BenutzerNr = {FallUserID}', N'Fallverantwortlicher MA (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaKg', N'MA Leistung K', 1, N'declare @VmUserID int

select top 1 @VmUserID = UserID
from   FaLeistung
where  FaFallID = {FaFallID} and
       FaProzessCode = 500
order by DatumVon desc

select <TableColumn>
from   vwTmUser
where  BenutzerNr = isNull(@VmUserID,{FallUserID})', N'Mitarbeiter Leistung Klientengelder (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaVm', N'MA Leistung Vm', 1, N'DECLARE @VmUserID INT;

SELECT TOP 1 @VmUserID = UserID
FROM dbo.FaLeistung         LEI WITH (READUNCOMMITTED)
  LEFT JOIN dbo.VmMassnahme MAS WITH (READUNCOMMITTED) ON MAS.FaLeistungID = LEI.FaLeistungID
WHERE FaFallID = {FaFallID} 
  AND FaProzessCode = 210
ORDER BY ISNULL(MAS.DatumVon, LEI.DatumVon) DESC;

SELECT <TableColumn>
FROM dbo.vwTmUser
WHERE BenutzerNr = ISNULL(@VmUserID,{FallUserID});', N'Mitarbeiter Leistung KES-Massnahme (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'MaWh', N'MA Leistung Wh', 1, N'declare @VmUserID int

select top 1 @VmUserID = UserID
from   FaLeistung
where  FaFallID = {FaFallID} and
       FaProzessCode = 300
order by DatumVon desc

select <TableColumn>
from   vwTmUser
where  BenutzerNr = isNull(@VmUserID,{FallUserID})', N'Mitarbeiter Leistung wirtschaftliche Hilfe (diverse Textmarken)', N'vwTmUser', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'PersonBewilligungErteilt', N'Leistungsentscheid', 1, N'SELECT Top 1 IsNull(ABS.FirstName, '''') + IsNull('' '' + ABS.LastName, '''')
FROM BgBewilligung BBW
     INNER JOIN XUser  ABS ON ABS.UserID = BBW.UserID
WHERE BBW.BgFinanzplanID = {BgFinanzplanID}
AND BBW.BgBudgetID IS NULL  
AND BBW.BgBewilligungCode = 2
ORDER BY BBW.Datum desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'PersonKurzBewilligungErteilt', N'Leistungsentscheid', 1, N'SELECT Top 1 IsNull(ABS.ShortName, '''')
FROM BgBewilligung BBW
     INNER JOIN XUser  ABS ON ABS.UserID = BBW.UserID
WHERE BBW.BgFinanzplanID = {BgFinanzplanID}
AND BBW.BgBudgetID IS NULL  
AND BBW.BgBewilligungCode = 2
ORDER BY BBW.Datum desc', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'RK', N'Ressourcenkarte', 1, N'SELECT <TableColumn>
FROM   vwTmRessourcenkarte
WHERE  FaRessourcenkarteID = {FaRessourcenkarteID}', N'Ressourcenkarte (diverse Textmarken)', N'vwTmRessourcenkarte', NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'SAimFallAktiv', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
DECLARE @minProzess INT
SET @Result = ''''

DECLARE csr CURSOR FOR

SELECT	
MinProzess = min(LEI.FaProzessCode),
LEI.FaFallID,
Name = CASE WHEN USR.FirstName is null or USR.FirstName = '''' THEN '''' ELSE USR.FirstName END
		+ CASE WHEN USR.LastName is null or USR.LastName = '''' THEN '''' ELSE '', '' + USR.LastName END
		+ CASE WHEN USR.Funktion is null or USR.Funktion = '''' THEN '''' ELSE '', '' + USR.Funktion END
		+ CASE WHEN USR.OrgUnit is null or USR.OrgUnit = '''' THEN '''' ELSE '', '' + USR.OrgUnit END
FROM	FaLeistung LEI
	LEFT JOIN vwUser USR ON USR.UserID = LEI.UserID
WHERE	LEI.FaFallID IN (SELECT DISTINCT FaFallID
					 FROM   FaFallPerson
					 WHERE  BaPersonID = {FT}
					 AND	FaFallID <> {FaFallID}
					 AND	(DatumBis is null or DatumBis < GetDate()))
GROUP BY LEI.FaFallID,
  CASE WHEN USR.FirstName is null or USR.FirstName = '''' THEN '''' ELSE USR.FirstName END
		+ CASE WHEN USR.LastName is null or USR.LastName = '''' THEN '''' ELSE '', '' + USR.LastName END
		+ CASE WHEN USR.Funktion is null or USR.Funktion = '''' THEN '''' ELSE '', '' + USR.Funktion END
		+ CASE WHEN USR.OrgUnit is null or USR.OrgUnit = '''' THEN '''' ELSE '', '' + USR.OrgUnit END
ORDER BY FaFallID, MinProzess asc

SET @oldFallNr = 0

OPEN csr

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csr INTO @minProzess, @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
	SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
        SET @oldFallNr = @actFallNr
    END

    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csr
DEALLOCATE csr

SELECT @Result', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'SAimFallFT', N'Fall', 1, N'DECLARE @Result VARCHAR(5000)
DECLARE @Value VARCHAR(200)
DECLARE @actFallNr INT
DECLARE @oldFallNr INT
DECLARE @minProzess INT
SET @Result = ''''

DECLARE csr CURSOR FOR

SELECT	
MinProzess = min(LEI.FaProzessCode),
LEI.FaFallID,
Name = CASE WHEN USR.FirstName is null or USR.FirstName = '''' THEN '''' ELSE USR.FirstName END
		+ CASE WHEN USR.LastName is null or USR.LastName = '''' THEN '''' ELSE '', '' + USR.LastName END
		+ CASE WHEN USR.Funktion is null or USR.Funktion = '''' THEN '''' ELSE '', '' + USR.Funktion END
		+ CASE WHEN USR.OrgUnit is null or USR.OrgUnit = '''' THEN '''' ELSE '', '' + USR.OrgUnit END
FROM	FaLeistung LEI
	LEFT JOIN vwUser USR ON USR.UserID = LEI.UserID
WHERE	LEI.FaFallID IN (SELECT DISTINCT FaFallID
					 FROM   FaFallPerson
					 WHERE  BaPersonID = {FT}
					 AND	FaFallID = {FaFallID}
					 AND	(DatumBis is null or DatumBis < GetDate()))
GROUP BY LEI.FaFallID,
  CASE WHEN USR.FirstName is null or USR.FirstName = '''' THEN '''' ELSE USR.FirstName END
		+ CASE WHEN USR.LastName is null or USR.LastName = '''' THEN '''' ELSE '', '' + USR.LastName END
		+ CASE WHEN USR.Funktion is null or USR.Funktion = '''' THEN '''' ELSE '', '' + USR.Funktion END
		+ CASE WHEN USR.OrgUnit is null or USR.OrgUnit = '''' THEN '''' ELSE '', '' + USR.OrgUnit END
ORDER BY FaFallID, MinProzess asc

SET @oldFallNr = 0

OPEN csr

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csr INTO @minProzess, @actFallNr, @Value
    IF NOT @@FETCH_STATUS = 0 BREAK

    IF NOT @oldFallNr = @actFallNr BEGIN
	SET @Result = @Result + ''Fall-Nr.: '' + CONVERT(varchar, @actFallNr)
        SET @oldFallNr = @actFallNr
    END

    IF NOT @Result = '''' BEGIN 		
	SET @Result = @Result + CHAR(13) + CHAR(10)		
    END
    SET @Result = @Result + ISNULL(@Value, '''')
  END

CLOSE csr
DEALLOCATE csr

SELECT @Result', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VMVISBerichtBis', N'KES-Massnahmen', 1, N'SELECT {DatumBis}', N'Feld ''Berichtsperiode bis'' des Beistands / Beiständin oder Vormunds/Vormundin im VIS, benötigt für die Kommunikation mit dem KESB-Team', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VMVISBerichtsart', N'KES-Massnahmen', 1, N'SELECT {Berichtsart}', N'Feld ''Berichtsart'' des Beistands / Beiständin oder Vormunds/Vormundin im VIS, benötigt für die Kommunikation mit dem KESB-Team', NULL, NULL, 0, 0)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VMVISBerichtVon', N'KES-Massnahmen', 1, N'SELECT {DatumVon}', N'Feld ''Berichtsperiode von'' des Beistands / Beiständin oder Vormunds/Vormundin im VIS, benötigt für die Kommunikation mit dem KESB-Team', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'VMVISMandID', N'KES-Massnahmen', 1, N'SELECT {VMVISMandID}', N'VIS MandID: Fremdschlüssel auf die Berichtsperiode des Beistands / Beiständin oder Vormunds/Vormundin im VIS, benötigt für die Kommunikation mit dem KESB-Team', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WIKKontoauszugPerson', N'WIK Kontoauszug', 1, N'SELECT PER.NameVorname + '' (Fall '' + CONVERT(varchar(15), LEI.FaFallID) + '' - '' + USR.LogonName + '')''
FROM vwPerson PER
  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = {FaLeistungID}
  INNER JOIN vwUser USR ON USR.UserID = LEI.UserID
WHERE PER.BaPersonID = {SchuldnerBaPersonID}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WIKKontoauszugSuchPeriode', N'WIK Kontoauszug', 1, N'DECLARE @FaFallID int,
	@datumVon datetime,
	@datumBis datetime,
	@forderungsart int,
	@schuldnerBaPersonID int,
	@glaeubigerBaPersonID int,
	@faLeistungID int,
	@wik bit

SET 	@FaFallID = {FaFallID}
SET	@datumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET	@datumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET	@forderungsart = CASE WHEN {ForderungsArt} = 0 THEN NULL ELSE {ForderungsArt} END
SET	@schuldnerBaPersonID = CASE WHEN {SchuldnerBaPersonID} = 0 THEN NULL ELSE {SchuldnerBaPersonID} END
SET	@glaeubigerBaPersonID = CASE WHEN {GlaeubigerBaPersonID} = 0 THEN NULL ELSE {GlaeubigerBaPersonID} END
SET	@faLeistungID = {FaLeistungID}
SET	@wik = {WIK}

if @DatumVon IS NULL OR @DatumBis IS NULL BEGIN
	SELECT  @DatumVon = CASE WHEN @DatumVon IS NULL THEN MIN(Datum) ELSE @DatumVon END,
		@DatumBis = CASE WHEN @DatumBis IS NULL THEN MAX(Datum) ELSE @DatumBis END
	FROM dbo.fnIkKontoauszug(@FaFallID, @datumVon , @datumBis , @forderungsart, @schuldnerBaPersonID, @glaeubigerBaPersonID, @faLeistungID, @wik)
END

SELECT ''von '' + Convert(varchar(15), @DatumVon, 104) + '' bis '' + Convert(varchar(15), @DatumBis, 104)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WIKKontoauszugTabelle', N'WIK Kontoauszug', 1, N'DECLARE @FaFallID int,
	@datumVon datetime,
	@datumBis datetime,
	@forderungsart int,
	@schuldnerBaPersonID int,
	@glaeubigerBaPersonID int,
	@faLeistungID int,
	@wik bit

SET 	@FaFallID = {FaFallID}
SET	@datumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET	@datumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET	@forderungsart = CASE WHEN {ForderungsArt} = 0 THEN NULL ELSE {ForderungsArt} END
SET	@schuldnerBaPersonID = CASE WHEN {SchuldnerBaPersonID} = 0 THEN NULL ELSE {SchuldnerBaPersonID} END
SET	@glaeubigerBaPersonID = CASE WHEN {GlaeubigerBaPersonID} = 0 THEN NULL ELSE {GlaeubigerBaPersonID} END
SET	@faLeistungID = {FaLeistungID}
SET	@wik = {WIK}

DECLARE @tmp TABLE
(
	DatumsText varchar(30),
	Datum dateTime,
	BuchungsText varchar(300),
	BetragSollText varchar(15),
	BetragSoll money,
	BetragHabenText varchar(15),
	BetragHaben money,
	Saldo money
)

INSERT INTO @tmp
SELECT -- Vorsaldo
	DatumsText = ''Vorsaldo'',
	Datum = NULL,
	Buchungstext = '''',
	BetragSollText = replace(convert(varchar(15), BetragSoll, 1), '','', ''''''''),
	BetragSoll = NULL,
	BetragHabenText = replace(convert(varchar(15), BetragHaben, 1), '','', ''''''''),
	BetragHaben = NULL,
	Saldo = Saldo
FROM (SELECT Saldo = SUM(ISNULL(BetragSoll, $0.00) - ISNULL(BetragHaben, $0.00)), BetragSoll = SUM(ISNULL(BetragSoll, $0.00)), BetragHaben = SUM(ISNULL(BetragHaben, $0.00))
		 FROM dbo.fnIkKontoauszug(@FaFallID, NULL, @datumBis , @forderungsart, @schuldnerBaPersonID, @glaeubigerBaPersonID, @faLeistungID, @wik)
		 WHERE Datum < @DatumVon) SAL
WHERE @DatumVon IS NOT NULL

INSERT INTO @tmp
SELECT
	DatumsText = convert(varchar(15), Datum, 104),
	Datum,
	Buchungstext = [Text],
	replace(convert(varchar(15), BetragSoll, 1), '','', ''''''''),
	BetragSoll,
	replace(convert(varchar(15), BetragHaben, 1), '','', ''''''''),
	BetragHaben,
	NULL
FROM dbo.fnIkKontoauszug(@FaFallID, @datumVon, @datumBis , @forderungsart, @schuldnerBaPersonID, @glaeubigerBaPersonID, @faLeistungID, @wik)
ORDER BY Datum


DECLARE @Saldo money
SELECT @Saldo = Saldo
FROM @tmp
WHERE DatumsText = ''Vorsaldo''
SET @Saldo = ISNULL(@Saldo, $0.00)

UPDATE @tmp SET @Saldo = Saldo = @Saldo + ISNULL(BetragSoll, $0.00) - ISNULL(BetragHaben, $0.00) WHERE DatumsText <> ''Vorsaldo''

SELECT
	DatumsText,
	NextCell = NULL,
	Buchungstext,
	NextCell = NULL,
	BetragSollText,
	NextCell = NULL,
	BetragHabenText,
	NextCell = NULL,
	replace(convert(varchar(15), Saldo, 1), '','', ''''''''),
	NextCell = null
FROM
@tmp', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WIKKontoauszugTotal', N'WIK Kontoauszug', 1, N'DECLARE @FaFallID int,
	@datumVon datetime,
	@datumBis datetime,
	@forderungsart int,
	@schuldnerBaPersonID int,
	@glaeubigerBaPersonID int,
	@faLeistungID int,
	@wik bit

SET 	@FaFallID = {FaFallID}
SET	@datumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET	@datumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET	@forderungsart = CASE WHEN {ForderungsArt} = 0 THEN NULL ELSE {ForderungsArt} END
SET	@schuldnerBaPersonID = CASE WHEN {SchuldnerBaPersonID} = 0 THEN NULL ELSE {SchuldnerBaPersonID} END
SET	@glaeubigerBaPersonID = CASE WHEN {GlaeubigerBaPersonID} = 0 THEN NULL ELSE {GlaeubigerBaPersonID} END
SET	@faLeistungID = {FaLeistungID}
SET	@wik = {WIK}

SELECT
	replace(convert(varchar(15), SUM(BetragSoll), 1), '','', ''''''''),
	NextCell = null,
	replace(convert(varchar(15), SUM(BetragHaben), 1), '','', ''''''''),
	NextCell = null,
	replace(convert(varchar(15), SUM(ISNULL(BetragSoll, $0.00) - ISNULL(BetragHaben, $0.00)), 1), '','', ''''''''),
	NextCell = null
FROM dbo.fnIkKontoauszug(@FaFallID, NULL, @datumBis , @forderungsart, @schuldnerBaPersonID, @glaeubigerBaPersonID, @faLeistungID, @wik)', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugDatumsSuchart', N'W Kontoauszug', 1, N'SELECT {DatumsSuchart}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugEA', N'W Kontoauszug', 1, N'DECLARE @InklProleist bit, @InklVermittlungsfall bit, @InklGruen bit, @InklRot bit, @InklStorno bit
DECLARE @FallBaPersonID int, @BaPersonID int, @KbKontoZeitraumCode int, @DatumVon datetime, @DatumBis datetime
DECLARE @Buchungstext varchar(100), @LAList varchar(2000), @Verdichtet bit

SET @FallBaPersonID = {FallBaPersonID}
SET @InklProLeist = {InklProleist}
SET @InklVermittlungsfall = {InklVermittlungsfall}
SET @InklGruen = {InklGruen}
SET @InklRot = {InklRot}
SET @InklStorno = {InklStorno}
SET @BaPersonID = CASE WHEN {BaPersonID} = 0 THEN NULL ELSE {BaPersonID} END
SET @KbKontoZeitraumCode = {KbKontoZeitraumCode}
SET @DatumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET @DatumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET @Buchungstext = CASE WHEN {Buchungstext} = ''-'' THEN NULL ELSE {Buchungstext} END
SET @LAList = CASE WHEN {LAList} = ''-'' THEN NULL ELSE {LAList} END
SET @Verdichtet = {Verdichtet}

--SET @FallBaPersonID = 204580
--SET @InklProLeist = 0
--SET @InklVermittlungsfall = 0
--SET @InklGruen = 0
--SET @InklRot = 0
--SET @InklStorno = 0
--SET @BaPersonID = NULL
--SET @KbKontoZeitraumCode = 3
--SET @DatumVon = NULL 
--SET @DatumBis = NULL
--SET @Buchungstext = NULL
--SET @LAList = NULL
--SET @Verdichtet = 0


SELECT
	Einnahmen = Replace(Convert(varchar(20), SUM(CASE WHEN EA = ''E'' THEN AUS.BetragEffektiv ELSE $0.00 END), 1), '','', ''''''''),
	NextCell = NULL,
	Ausgaben = Replace(Convert(varchar(20), SUM(CASE WHEN EA = ''A'' THEN -AUS.BetragEffektiv ELSE $0.00 END), 1), '','', '''''''')
FROM dbo.fnWhKontoauszug(@FallBaPersonID,
  @BaPersonID,
  @KbKontoZeitraumCode,
  @DatumVon,
  @DatumBis,
  @Buchungstext,
  @LAList,
  @Verdichtet,
  @InklProLeist,
  @InklVermittlungsfall,
  @InklGruen,
  @InklRot,
  @InklStorno,
  NULL,-- EA
  0 -- Klientenkontoabrechnungsmodus
  ) AUS 
WHERE AUS.Verdichtet = @Verdichtet', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugKlient', N'W Kontoauszug', 1, N'DECLARE @InklProleist bit, @InklVermittlungsfall bit, @InklGruen bit, @InklRot bit, @InklStorno bit
DECLARE @FallBaPersonID int, @BaPersonID int, @KbKontoZeitraumCode int, @DatumVon datetime, @DatumBis datetime
DECLARE @Buchungstext varchar(100), @LAList varchar(2000)

SET @FallBaPersonID = {FallBaPersonID}
SET @InklProLeist = {InklProleist}
SET @InklVermittlungsfall = {InklVermittlungsfall}
SET @InklGruen = {InklGruen}
SET @InklRot = {InklRot}
SET @InklStorno = {InklStorno}
SET @BaPersonID = CASE WHEN {BaPersonID} = 0 THEN NULL ELSE {BaPersonID} END
SET @KbKontoZeitraumCode = {KbKontoZeitraumCode}
SET @DatumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET @DatumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET @Buchungstext = CASE WHEN {Buchungstext} = ''-'' THEN NULL ELSE {Buchungstext} END
SET @LAList = CASE WHEN {LAList} = ''-'' THEN NULL ELSE {LAList} END

--SET @FallBaPersonID = 204580
--SET @InklProLeist = 0
--SET @InklVermittlungsfall = 0
--SET @InklGruen = 0
--SET @InklRot = 0
--SET @InklStorno = 0
--SET @BaPersonID = NULL
--SET @KbKontoZeitraumCode = 3
--SET @DatumVon = NULL 
--SET @DatumBis = NULL
--SET @Buchungstext = NULL
--SET @LAList = NULL

DECLARE @Personen varchar(2000)
SET @Personen = ''''

DECLARE @PersonenTabelle table
(
	Klient varchar(200),
	BaPersonID int
)

INSERT INTO @PersonenTabelle
SELECT DISTINCT Klient, BaPersonID 
FROM dbo.fnWhKontoauszug(@FallBaPersonID,
  @BaPersonID,
  @KbKontoZeitraumCode,
  @DatumVon,
  @DatumBis,
  @Buchungstext,
  @LAList,
  0, -- Zum Personen finden keine verdichtete Darstellung verwenden!
  @InklProLeist,
  @InklVermittlungsfall,
  @InklGruen,
  @InklRot,
  @InklStorno,
  NULL, -- EA
  0 -- Klientenkontoabrechnungsmodus
  ) KON

SELECT @Personen = @Personen + Klient + '' PN-Nr. '' + CONVERT(varchar(12), BaPersonID) + '', '' 
FROM @PersonenTabelle

IF LEN(@Personen) > 1 BEGIN
	SET @Personen = SUBSTRING(@Personen, 1, LEN(@Personen) - 1)
END

SELECT @Personen
', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugLeistungsarten', N'W Kontoauszug', 1, N'SELECT {Leistungsarten}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugSaldo', N'W Kontoauszug', 1, N'DECLARE @InklProleist bit, @InklVermittlungsfall bit, @InklGruen bit, @InklRot bit, @InklStorno bit
DECLARE @FallBaPersonID int, @BaPersonID int, @KbKontoZeitraumCode int, @DatumVon datetime, @DatumBis datetime
DECLARE @Buchungstext varchar(100), @LAList varchar(2000), @Verdichtet bit

SET @FallBaPersonID = {FallBaPersonID}
SET @InklProLeist = {InklProleist}
SET @InklVermittlungsfall = {InklVermittlungsfall}
SET @InklGruen = {InklGruen}
SET @InklRot = {InklRot}
SET @InklStorno = {InklStorno}
SET @BaPersonID = CASE WHEN {BaPersonID} = 0 THEN NULL ELSE {BaPersonID} END
SET @KbKontoZeitraumCode = {KbKontoZeitraumCode}
SET @DatumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET @DatumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET @Buchungstext = CASE WHEN {Buchungstext} = ''-'' THEN NULL ELSE {Buchungstext} END
SET @LAList = CASE WHEN {LAList} = ''-'' THEN NULL ELSE {LAList} END
SET @Verdichtet = {Verdichtet}

--SET @FallBaPersonID = 204580
--SET @InklProLeist = 0
--SET @InklVermittlungsfall = 0
--SET @InklGruen = 0
--SET @InklRot = 0
--SET @InklStorno = 0
--SET @BaPersonID = NULL
--SET @KbKontoZeitraumCode = 3
--SET @DatumVon = NULL 
--SET @DatumBis = NULL
--SET @Buchungstext = NULL
--SET @LAList = NULL
--SET @Verdichtet = 0


SELECT Replace(Convert(varchar(20), SUM(AUS.BetragEffektiv), 1), '','', '''''''')
FROM dbo.fnWhKontoauszug(@FallBaPersonID,
  @BaPersonID,
  @KbKontoZeitraumCode,
  @DatumVon,
  @DatumBis,
  @Buchungstext,
  @LAList,
  @Verdichtet,
  @InklProLeist,
  @InklVermittlungsfall,
  @InklGruen,
  @InklRot,
  @InklStorno,
  NULL, -- EA
  0 -- Klientenkontoabrechnungsmodus
  ) AUS
WHERE AUS.Verdichtet = @Verdichtet', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugSuchparameter', N'W Kontoauszug', 1, N'SELECT {Suchparameter}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugSuchperiode', N'W Kontoauszug', 1, N'SELECT {Suchperiode}', NULL, NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'WKontoauszugTabelle', N'W Kontoauszug', 1, N'DECLARE @InklProleist bit, @InklVermittlungsfall bit, @InklGruen bit, @InklRot bit, @InklStorno bit
DECLARE @FallBaPersonID int, @BaPersonID int, @KbKontoZeitraumCode int, @DatumVon datetime, @DatumBis datetime
DECLARE @Buchungstext varchar(100), @LAList varchar(2000), @Verdichtet bit

SET @FallBaPersonID = {FallBaPersonID}
SET @InklProLeist = {InklProleist}
SET @InklVermittlungsfall = {InklVermittlungsfall}
SET @InklGruen = {InklGruen}
SET @InklRot = {InklRot}
SET @InklStorno = {InklStorno}
SET @BaPersonID = CASE WHEN {BaPersonID} = 0 THEN NULL ELSE {BaPersonID} END
SET @KbKontoZeitraumCode = {KbKontoZeitraumCode}
SET @DatumVon = CASE WHEN {DatumVon} = 0 THEN NULL ELSE {DatumVon} END
SET @DatumBis = CASE WHEN {DatumBis} = 0 THEN NULL ELSE {DatumBis} END
SET @Buchungstext = CASE WHEN {Buchungstext} = ''-'' THEN NULL ELSE {Buchungstext} END
SET @LAList = CASE WHEN {LAList} = ''-'' THEN NULL ELSE {LAList} END
SET @Verdichtet = {Verdichtet}

--SET @FallBaPersonID = 204580
--SET @InklProLeist = 0
--SET @InklVermittlungsfall = 0
--SET @InklGruen = 0
--SET @InklRot = 0
--SET @InklStorno = 0
--SET @BaPersonID = NULL
--SET @KbKontoZeitraumCode = 3
--SET @DatumVon = NULL 
--SET @DatumBis = NULL
--SET @Buchungstext = NULL
--SET @LAList = NULL
--SET @Verdichtet = 0

DECLARE @saldo money
SET @saldo = 0
DECLARE @tmp Table(
	VerwPeriodeVon datetime,
	VerwPeriodeBis datetime,
	DatumEffektiv datetime,
	AnzahlBelege int,
	BgBudgetName varchar(60),
	LA varchar(10),
	Splitting char,
	Buchungstext varchar(100),
	Klient varchar(100),
	Einnahmen money,
	Ausgaben money,
	EinnahmenEffektiv money,
	AusgabenEffektiv money,
	S char,
	D char,
	Bar char,
	Doc varchar(10),
	ValutaDatum datetime,
	Status varchar(20),
	BelegNr varchar(20),
	Saldo money
)


INSERT INTO @tmp
SELECT
	VerwPeriodeVon,
	VerwPeriodeBis,
	DatumEffektiv,
	AnzahlBelege,
	CASE WHEN BDG.Monat > 9 THEN '''' else ''0'' END + convert(varchar(2), BDG.Monat) + ''.'' + Substring(CONVERT(varchar(4), BDG.Jahr), 3, 2),
	LA,
	Splitting,
	Buchungstext,
	PER.NameVorname,
	Einnahmen = CASE WHEN EA = ''E'' THEN
			CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN AUS.BetragEffektiv ELSE AUS.Betrag END
		    END,
	Ausgaben = CASE WHEN EA = ''A'' THEN
			CASE WHEN KbBuchungStatusCode = 6 or KbBuchungStatusCode = 10 THEN -AUS.BetragEffektiv ELSE -AUS.Betrag END
		   END,
	EinnahmenEffektiv = CASE WHEN EA = ''E'' THEN AUS.BetragEffektiv END,
	AusgabenEffektiv = CASE WHEN EA = ''A'' THEN AUS.BetragEffektiv END,
	S,
	D,
	Bar,
	Doc,
	ValutaDatum,
	[Status] = LOV.ShortText,
	BelegNr,
	Saldo = NULL
FROM dbo.fnWhKontoauszug(@FallBaPersonID,
  @BaPersonID,
  @KbKontoZeitraumCode,
  @DatumVon,
  @DatumBis,
  @Buchungstext,
  @LAList,
  @Verdichtet,
  @InklProLeist,
  @InklVermittlungsfall,
  @InklGruen,
  @InklRot,
  @InklStorno,
  NULL, -- EA
  0 -- Klientenkontoabrechnungsmodus
  ) AUS -- EA
  LEFT JOIN XLOVCode LOV ON LOV.Code = AUS.KbBuchungstatusCode AND LOV.LOVName = ''KbBuchungsStatus''
  LEFT JOIN VwPersonSimple PER ON PER.BaPersonID = AUS.BaPersonID
  LEFT JOIN BgBudget BDG ON BDG.BgBudgetID = AUS.BgBudgetID
WHERE AUS.Verdichtet = @Verdichtet AND
         (Betrag100 <> 0 OR AnzahlBelege > 1)
ORDER BY VerwPeriodeVon DESC, VerwPeriodeBis DESC, LA ASC

UPDATE @tmp
SET @saldo = Saldo = @saldo + ISNULL(EinnahmenEffektiv, $0.00) + ISNULL(AusgabenEffektiv, $0.00)
FROM @tmp

SELECT
	VerwPeriodeVon = Convert(varchar(10), VerwPeriodeVon, 4),
	NextCell = null,
	VerwPeriodeBis = Convert(varchar(10), VerwPeriodeBis, 4),
	NextCell = null,
	DatumEffektiv = Convert(varchar(10), DatumEffektiv, 4),
	NextCell = null,
	BgBudgetName,
	NextCell = null,
	LA,
	NextCell = null,
	Buchungstext,
	NextCell = null,
	Klient,
	NextCell = null,
	Einnahmen = Replace(Convert(varchar(20), Einnahmen, 1), '','', ''''''''),
	NextCell = null,
	Ausgaben = Replace(Convert(varchar(20), Ausgaben, 1), '','', ''''''''),
	NextCell = null,
	Saldo = Replace(Convert(varchar(20), Saldo, 1), '','', ''''''''),
	NextCell = null,
	S,
	NextCell = null,
	D,
	NextCell = null,
	Bar,
	NextCell = null,
	ValutaDatum = Convert(varchar(10), ValutaDatum, 4),
	NextCell = null,
	[Status],
	NextCell = null,
	BelegNr,
	NextCell = null
FROM @tmp', N'Daten des Kontoauszugs', NULL, NULL, 0, 1)
GO
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'Zahlinfo', N'Basis', 1, N'SELECT dbo.fnTmZahlinfo({BaPersonID})', N'Liste mit Zeilenumbruch.', NULL, NULL, 0, 1)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZahlinfoIBAN', N'Basis', 1, N'SELECT dbo.fnTmZahlinfoIBAN ({BaPersonID})', N'Auflistung der gültigen Zahlinfos unter Angabe der IBAN-Nummer
erstellt 05.05.2010 sozstu', NULL, NULL, 0, 0)
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZahlinfoIBANShort', N'Basis', 1, N'SELECT dbo.fnTmZahlinfoIBANShort ({BaPersonID})', N'Auflistung der gültigen Zahlinfos unter Angabe der IBAN-Nummer - Kurzversion
erstellt 05.05.2010 sozstu', NULL, NULL, 0, 0)
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
INSERT INTO [XBookmark] ([BookmarkName], [Category], [BookmarkCode], [SQL], [Description], [TableName], [ModulID], [AlwaysVisible], [System]) VALUES (N'ZV', N'Zielvereinbarung', 1, N'SELECT <TableColumn>
FROM   vwTmZielvereinbarung
WHERE  FaZielvereinbarungID = {FaZielvereinbarungID}', N'Zielvereinbarung / Aufträge (diverse Textmarken)', N'vwTmZielvereinbarung', NULL, 0, 1)
GO
COMMIT
GO