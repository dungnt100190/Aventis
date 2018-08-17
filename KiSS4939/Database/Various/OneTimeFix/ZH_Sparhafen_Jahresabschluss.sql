DECLARE @Abschlussdatum DATETIME
SET @Abschlussdatum = '20121231'

DELETE FROM dbo.KgSparhafenAbschluss WHERE BDatum = @Abschlussdatum


/* Daten vom vorangegangenen Import löschen
begin tran

select * from KgBuchung
where KgBuchungID in (select KgBuchungID from KgSparhafenAbschluss)

delete KgBuchung
where KgBuchungID in (select KgBuchungID from KgSparhafenAbschluss)

rollback
commit
*/


--drop table KgSparhafenAbschluss
--CREATE TABLE [dbo].[KgSparhafenAbschluss](
--	[KgSparhafenAbschlussID] [int] IDENTITY(1,1) NOT NULL,
--	[KtoNr] [varchar](20) NULL,
--	[Klient] [varchar](100) NULL,
--	[Geburt] [varchar](10) NULL,
--	[BDatum] [datetime] NULL,
--	[Text] [varchar](100) NULL,
--	[Betrag] [money] NULL,
--	[Code] [int] NULL,
--	[Name] [varchar](50) NULL,
--	[Vorname] [varchar](50) NULL,
--	[NameMitUmlaut] [varchar](50) NULL,
--	[VornameMitUmlaut] [varchar](50) NULL,
--	[Geburtsdatum] [datetime] NULL,
--	[Geburtsjahr] [int] NULL,
--	[BaPersonID] [int] NULL,
--	[TeilKtoNr] [varchar](10) NULL,
--	[KgBuchungID] [int] NULL,
--	[Fehlermeldung] [varchar](2000) NULL,
--	[ungueltig] [bit] NOT NULL DEFAULT ((0)),
--PRIMARY KEY CLUSTERED 
--(
--	[KgSparhafenAbschlussID] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
--) ON [PRIMARY]


---- INSERT STATEMENTS HERE (werden von ZH aufgefüllt!)
/*
INSERT [KgSparhafenAbschluss] ([KtoNr], [Klient], [Geburt], [BDatum], [Text], [Betrag], [Code], [Name], [Vorname], [NameMitUmlaut], [VornameMitUmlaut], [Geburtsdatum], [Geburtsjahr], [BaPersonID], [TeilKtoNr], [KgBuchungID], [Fehlermeldung], [ungueltig]) VALUES ( N'8051159476' ,  N'A PORTA, THOMAS', NULL,'20121231',  N'ZINS' ,29.90 , 1,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  0 )
INSERT [KgSparhafenAbschluss] ([KtoNr], [Klient], [Geburt], [BDatum], [Text], [Betrag], [Code], [Name], [Vorname], [NameMitUmlaut], [VornameMitUmlaut], [Geburtsdatum], [Geburtsjahr], [BaPersonID], [TeilKtoNr], [KgBuchungID], [Fehlermeldung], [ungueltig]) VALUES ( N'8051191916' ,  N'ABDERHALDEN, BRUNO', NULL,'20121231',  N'ZINS' ,21.35 , 1,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  0 )
...
*/


----------------------------------------------------------------------------------
-- Nachbearbeitung der Daten.
----------------------------------------------------------------------------------
-- Name, Vorname, NameMitUmlaut, VornameMitUmlaut, Geburtstag und Geburtsjahr, TeilKtoNr erzeugen
update KgSparhafenAbschluss
set    Name         = substring(Klient, 1,charindex(',',Klient) - 1),
       Vorname      = substring(Klient, charindex(',',Klient) + 1, 100),
       Geburtsdatum = case when substring(Geburt,5,4) <> '0000' then convert(datetime,Geburt) end,
       Geburtsjahr  = case when substring(Geburt,5,4) = '0000' then convert(int,substring(Geburt,1,4)) end,
       TeilKtoNr    = substring(KtoNr,5,3) + '.' + substring(KtoNr,8,3) 
where charindex(',',Klient) > 0 AND BDatum = @Abschlussdatum


-- oe ae ue in Umlaute wandeln
update KgSparhafenAbschluss
set    NameMitUmlaut    = replace(replace(replace(Name,'ue','ü'),'ae','ä'),'oe','ö'),
       VornameMitUmlaut = replace(replace(replace(Vorname,'ue','ü'),'ae','ä'),'oe','ö')
WHERE  BDatum = @Abschlussdatum


-- BaPersonID: Matching Name, Geburtsdatum
update SPA
set    BaPersonID = PRS.BaPersonID
from   KgSparhafenAbschluss SPA
       inner join dbo.BaPerson  PRS on PRS.Name like '%' + SPA.Name + '%' and
                                   PRS.Geburtsdatum = SPA.Geburtsdatum
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum


-- BaPersonID: Matching NameMitUmlaut, Geburtsdatum
update SPA
set    BaPersonID = PRS.BaPersonID
from   dbo.KgSparhafenAbschluss SPA
       inner join dbo.BaPerson  PRS on replace(replace(PRS.Name,'é','e'),'ç','c') like '%' + SPA.NameMitUmlaut + '%' and
                                   PRS.Geburtsdatum = SPA.Geburtsdatum
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum


-- BaPersonID: Matching Name, Vorname, Geburtsjahr
update SPA
set    BaPersonID = PRS.BaPersonID
from   dbo.KgSparhafenAbschluss SPA
       inner join dbo.BaPerson PRS on PRS.Name like '%' + SPA.Name + '%' and
                                  PRS.Vorname like '%' + SPA.Vorname + '%' and
                                  year(PRS.Geburtsdatum) = SPA.Geburtsjahr
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum


-- BaPersonID: Matching NameMitUmlaut, VornameMitUmlaut, Geburtsjahr
update SPA
set    BaPersonID = PRS.BaPersonID
from   dbo.KgSparhafenAbschluss SPA
       inner join dbo.BaPerson PRS on replace(replace(PRS.Name,'é','e'),'ç','c') like '%' + SPA.NameMitUmlaut + '%' and
                                  replace(replace(PRS.Vorname,'é','e'),'ç','c') like '%' + SPA.VornameMitUmlaut + '%' and
                                  year(PRS.Geburtsdatum) = SPA.Geburtsjahr
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum


-- BaPersonID: Matching Name oder NameMitUmlaut, mit K-Leistung
update SPA
set    BaPersonID = PRS.BaPersonID
from   dbo.KgSparhafenAbschluss SPA
       inner join dbo.BaPerson PRS on (replace(replace(PRS.Name,'é','e'),'ç','c') like '%' + SPA.Name + '%' or
                                   replace(replace(PRS.Name,'é','e'),'ç','c') like '%' + SPA.NameMitUmlaut + '%') 
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum and
       exists(select 1 from FaLeistung where FaProzessCode = 500 and BaPersonID = PRS.BaPersonID)

	   
-- BaPersonID: ähnlicher Name und ähnlicher Vorname
update SPA
set    BaPersonID = PRS.BaPersonID
from   dbo.KgSparhafenAbschluss SPA
       inner join dbo.BaPerson PRS on soundex(PRS.Name) = soundex(SPA.Name) and
                                  soundex(PRS.Vorname) = soundex(SPA.Vorname)
where  SPA.BaPersonID is null AND BDatum = @Abschlussdatum and
       exists(select 1 from FaLeistung where FaProzessCode = 500 and BaPersonID = PRS.BaPersonID)


-- Doppelte zuweisungen Löschen, diese müssen manuell eruiert werden
UPDATE SPA1
  SET BaPersonID = NULL
-- SELECT SPA1.Klient, SPA2.Klient    
FROM dbo.KgSparhafenAbschluss SPA1
  INNER JOIN dbo.KgSparhafenAbschluss SPA2 ON SPA2.BaPersonID = SPA1.BaPersonID
WHERE SPA1.BDatum = @Abschlussdatum AND
      SPA1.BaPersonID IS NOT NULL  AND
      SPA2.BDatum = @Abschlussdatum AND
      SPA2.BaPersonID IS NOT NULL  AND
      SPA1.Klient != SPA2.Klient 
      
	  
-- hardcodierte Zuweisung

/* Kandidaten aufgrund matching TeilKtoNr
select PRS.BaPersonID,SPA.Klient,PRS.Name, PRS.Vorname, KTO.KontoName
from   KgSparhafenAbschluss SPA
       inner join KgKonto   KTO on KTO.Kontoname like '%' + SPA.TeilKtoNr + '%'
       inner join KgPeriode PER on PER.KgPeriodeID = KTO.KgPeriodeID
       inner join FaLeistung LEI on LEI.FaLeistungID = PER.FaLeistungID
       inner join BaPerson   PRS on PRS.BaPersonID = LEI.BaPersonID
where SPA.BaPersonID is null
*/


----------------------------------------------------------------------------------
-- Manuelle Anpassungen (werden von ZH aufgefüllt!)
----------------------------------------------------------------------------------
/*
UPDATE KgSparhafenAbschluss set BaPersonID = 143705 where BDatum = @Abschlussdatum AND Klient = 'AMEKOTON, SEFENYA';
UPDATE KgSparhafenAbschluss set BaPersonID = 139995 where BDatum = @Abschlussdatum AND Klient = 'BORRECA, GIUSEPPE';
UPDATE KgSparhafenAbschluss set BaPersonID = 140106 where BDatum = @Abschlussdatum AND Klient = 'CALAME-DROZ-DIT-BUSSET, ELISAB';
UPDATE KgSparhafenAbschluss set BaPersonID = 171677 where BDatum = @Abschlussdatum AND Klient = 'DEJAN, FRANCESCA';
...
*/

/* Kandidaten aufgrund matching Geburtstag oder Geburtsjahr
select PRS.BaPersonID,SPA.Klient,PRS.Name, PRS.Vorname
from   KgSparhafenAbschluss SPA
       inner join BaPerson   PRS on (PRS.Geburtsdatum = SPA.Geburtsdatum or
                                     year(PRS.Geburtsdatum) = year(SPA.Geburtsdatum))
where SPA.BaPersonID is null and
      exists(select 1 from FaLeistung where FaProzessCode = 500 and BaPersonID = PRS.BaPersonID)
order by SPA.Klient, PRS.Name

-- Kandidaten aufgrund matching Teilnamen
select PRS.BaPersonID,SPA.Klient,PRS.Name, PRS.Vorname
from   KgSparhafenAbschluss SPA
       inner join BaPerson   PRS on ((substring(PRS.Name, 1,2) = substring(SPA.Name, 1,2) and 
									 substring(PRS.Vorname, 1,2) = substring(SPA.Vorname, 1,2)) OR 
									 (substring(PRS.Name, 1,2) = substring(SPA.NameMitUmlaut, 1,2) and 
									 substring(PRS.Vorname, 1,2) = substring(SPA.VornameMitUmlaut, 1,2)))
where SPA.BaPersonID is null and
      exists(select 1 from FaLeistung where FaProzessCode = 500 and BaPersonID = PRS.BaPersonID)
order by SPA.Klient, PRS.Name

*/


----------------------------------------------------------------------------------
-- Controlling
----------------------------------------------------------------------------------

-- Einträge ohne Personen-Mapping
SELECT *
FROM dbo.KgSparhafenAbschluss
WHERE BaPersonID is null AND BDatum = @Abschlussdatum
ORDER BY Klient

UPDATE dbo.KgSparhafenAbschluss
SET    Fehlermeldung = 'Keine passende KiSS-Mandant/int gefunden'
WHERE  BaPersonID is null AND BDatum = @Abschlussdatum

-- Loop über alle Buchungen


----------------------------------------------------------------------------------
-- Buchungen erstellen
----------------------------------------------------------------------------------

DECLARE @KgSparhafenAbschlussID INT
  
DECLARE C CURSOR FOR
  SELECT KgSparhafenAbschlussID
  FROM   dbo.KgSparhafenAbschluss
  WHERE  BaPersonID is not null AND BDatum = @Abschlussdatum
  ORDER BY Klient

OPEN C
FETCH NEXT FROM C INTO @KgSparhafenAbschlussID
WHILE @@fetch_status = 0 BEGIN
  EXEC spKgSparhafenAbschlussBuchung @KgSparhafenAbschlussID, null
  FETCH NEXT FROM C INTO @KgSparhafenAbschlussID
END
CLOSE C
DEALLOCATE C 


----------------------------------------------------------------------------------
-- Statistik Buchungen
----------------------------------------------------------------------------------
-- Statistik
SELECT ISNULL(Fehlermeldung,'ok'), count(*)
FROM   dbo.KgSparhafenAbschluss
WHERE  BDatum = @Abschlussdatum
GROUP BY isnull(Fehlermeldung,'ok')

SELECT *
FROM   dbo.KgSparhafenAbschluss
WHERE KgBuchungID is null AND BDatum = @Abschlussdatum


--- Falls es bei Konti doppelte Abschlussbuchungen gibt, dann ist wohl etwas schief.
/*
SELECT PRS.BaPersonId, PRS.Name, PRS.Vorname
FROM BaPerson PRS
 INNER JOIN FaLeistung LEI ON LEI.BaPersonId  = PRS.BaPersonId
 INNER JOIN KgPeriode  PER ON PER.FaLeistungId = LEI.FaLeistungId
 
WHERE PER.KgPeriodeId IN ( 
  SELECT BUC.KgPeriodeid
  FROM KgBuchung BUC
  WHERE BUC.BuchungsDatum = @Abschlussdatum
  AND BUC.KgBuchungTypCode = 3
  GROUP BY BUC.KgPeriodeId, SollKtoNr, HabenKtoNr 
  HAVING  Count(KgPeriodeId) > 1
)*/