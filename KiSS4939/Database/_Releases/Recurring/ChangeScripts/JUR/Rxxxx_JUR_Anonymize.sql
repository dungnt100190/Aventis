-- =============================================
-- Script Template
-- =============================================
IF(N'{Env}' = N'Int' OR N';' + N'{NSExt}' + N';' LIKE N'%;RESTORE;%') --Int-Umgebung beim Kunden oder Entwicklungs-DBs
BEGIN
  -- disable history triggers
  declare @Triggername varchar(100)
  declare @Tablename varchar(100)
  declare @sql nvarchar(2000)

  -- variables for cursor replacement
  DECLARE @EntriesCount INT;
  DECLARE @EntriesIterator INT;
  DECLARE @Variable VARCHAR(255);

  DECLARE @EnabledHistoryTriggers TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    TriggerName VARCHAR(255),
    TableName VARCHAR(255),
    IsDisabled int
  );

  insert into @EnabledHistoryTriggers
  select name, object_name(parent_id), is_disabled from sys.triggers
   where  name like 'trhist%'
   and is_disabled = 0

   -- prepare vars for loop
  SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
  SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

  -------------------------------------------------------------------------------
  -- loop all entries
  -------------------------------------------------------------------------------
  WHILE (@EntriesIterator <= @EntriesCount)
  BEGIN
    -- get current entry
    SELECT @sql = 'disable trigger ' + Triggername + ' on ' + Tablename
    FROM @EnabledHistoryTriggers TMP
    WHERE TMP.ID = @EntriesIterator;
  
    exec (@sql)

    -- prepare for next entry
    SET @EntriesIterator = @EntriesIterator + 1;
  END;

  -- set <tablename>.creator and <tablename>.modifier to 'System'
  declare @Columnname varchar(100)
  declare @SchemaName varchar(5)
 
  declare cur cursor for
  select T.name, C.name, SchemaName = OBJECT_SCHEMA_NAME(T.id)
  from syscolumns C
   inner join sysobjects T on T.id = C.id
  where T.xtype = 'U'
    and C.name in ('creator','modifier')
  order by T.Name, C.Name
 
  open cur;
  fetch next from cur into @Tablename, @Columnname, @SchemaName
 
  while  @@fetch_status = 0 begin
    set @sql = 'update [' + @SchemaName + '].[' + @Tablename + '] set [' + @Columnname + '] = ''System'''
    exec (@sql)
    fetch next from cur into @Tablename, @Columnname, @SchemaName
  end
 
  close cur;
  deallocate cur;

  -- delete all History tables
  declare cur cursor for
  select name
  from sysobjects 
  where xtype = 'U'
        and name like 'Hist!_%' escape '!'
  order by Name
 
  open cur;
  fetch next from cur into @Tablename
 
  while  @@fetch_status = 0 begin
    set @sql = 'delete ' + @Tablename
    exec (@sql)
    fetch next from cur into @Tablename
  end
 
  close cur;
  deallocate cur;


    exec spXAnonymizeField 'BaAdresse','CareOf','x','','','','',''
    exec spXAnonymizeField 'BaAdresse','Zusatz','x','','','','',''
    exec spXAnonymizeField 'BaAdresse','ZuhandenVon','x','','','','',''
    exec spXAnonymizeField 'BaAdresse','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'BaAdresse','HausNr','','','{N}','1','99',''
    exec spXAnonymizeField 'BaAdresse','Postfach','','','Postfach {N}','1000','9999',''
    exec spXAnonymizeField 'BaAdresse','PLZ','','','{N}','3000','3020',''
    exec spXAnonymizeField 'BaAdresse','Ort','','Ort','','','',''
    exec spXAnonymizeField 'BaAdresse','OrtschaftCode','x','','','','',''
    exec spXAnonymizeField 'BaAdresse','Kanton','','','BE','','',''
    exec spXAnonymizeField 'BaAdresse','Bezirk','x','','','','',''
    exec spXAnonymizeField 'BaAdresse','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaArbeit','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaArbeit','Adresse','x','','','','',''
    exec spXAnonymizeField 'BaArbeitAusbildung','Bemerkung','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','KVGKontaktPerson','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','KVGKontaktTelefon','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','KVGMitgliedNr','','','{N}','10000','99999',''
    exec spXAnonymizeField 'BaGesundheit','VVGKontaktPerson','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','VVGKontaktTelefon','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','VVGMitgliedNr','','','{N}','10000','99999',''
    exec spXAnonymizeField 'BaGesundheit','VVGZusaetzeRTF','x','','','','',''
    exec spXAnonymizeField 'BaGesundheit','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaMietvertrag','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaPerson','Titel','x','','','','',''
    exec spXAnonymizeField 'BaPerson','Name','','Name','','','',''
    exec spXAnonymizeField 'BaPerson','FruehererName','x','','','','',''
    exec spXAnonymizeField 'BaPerson','Vorname','','Vorname','','','',''
    exec spXAnonymizeField 'BaPerson','Vorname2','x','','','','',''
    exec spXAnonymizeField 'BaPerson','Geburtsdatum','','','','','','x'
    exec spXAnonymizeField 'BaPerson','Sterbedatum','','','','','','x'
    exec spXAnonymizeField 'BaPerson','AHVNummer','','','XXX.XX.XXX.000','','',''
    exec spXAnonymizeField 'BaPerson','Versichertennummer','','','XXX.XXXX.XXXX.XX','','',''
    exec spXAnonymizeField 'BaPerson','HaushaltVersicherungsNummer','x','','','','',''
    exec spXAnonymizeField 'BaPerson','NNummer','','','{N}','1000000','2999999',''
    exec spXAnonymizeField 'BaPerson','BFFNummer','','','{N}','1000000','2999999',''
    exec spXAnonymizeField 'BaPerson','ZIPNr','','','{N}','1000000','2999999',''
    exec spXAnonymizeField 'BaPerson','KantonaleReferenznummer','','','{N}','1000000','2999999',''



    exec spXAnonymizeField 'BaPerson','HeimatgemeindeCode','x','','','','',''
    exec spXAnonymizeField 'BaPerson','HeimatgemeindeCodes','x','','','','',''
    exec spXAnonymizeField 'BaPerson','NationalitaetCode','x','','','','',''
    exec spXAnonymizeField 'BaPerson','ReligionCode','x','','','','',''


    exec spXAnonymizeField 'BaPerson','Telefon_P','','','031 XXX XX XX','','',''
    exec spXAnonymizeField 'BaPerson','Telefon_G','','','031 XXX XX XX','','',''
    exec spXAnonymizeField 'BaPerson','MobilTel1','','','079 XXX XX XX','','',''
    exec spXAnonymizeField 'BaPerson','MobilTel2','','','076 XXX XX XX','','',''
    exec spXAnonymizeField 'BaPerson','EMail','','','info@diartis.ch','','',''



    exec spXAnonymizeField 'BaPerson','Bemerkung','','Text','','','',''

















    exec spXAnonymizeField 'BaPerson','UntWohnsitzPLZ','x','','','','',''
    exec spXAnonymizeField 'BaPerson','UntWohnsitzOrt','x','','','','',''
    exec spXAnonymizeField 'BaPerson','UntWohnsitzKanton','x','','','','',''
    exec spXAnonymizeField 'BaPerson','UntWohnsitzLandCode','x','','','','',''
















    exec spXAnonymizeField 'BaPerson','ArbeitSpezFaehigkeiten','x','','','','',''










    exec spXAnonymizeField 'BaPerson','ResoNr','x','','','','',''

    exec spXAnonymizeField 'BaPerson','HeimatgemeindeBaGemeindeID','x','','','','',''





    exec spXAnonymizeField 'BaPerson','Behinderungsart2Code','x','','','','',''
    exec spXAnonymizeField 'BaPerson','BemerkungenAdresse','x','','','','',''
    exec spXAnonymizeField 'BaPerson','BemerkungenSV','x','','','','',''

    exec spXAnonymizeField 'BaPerson','Briefanrede','x','','','','',''













    exec spXAnonymizeField 'BaPerson','Fax','','','031 XXX XX XX','','',''




















    exec spXAnonymizeField 'BaPerson','KonfessionCode','x','','','','',''












    exec spXAnonymizeField 'BaPerson','MobilTel','','','079 XXX XX XX','','',''














    exec spXAnonymizeField 'BaPerson','visdat36Area','x','','','','',''
    exec spXAnonymizeField 'BaPerson','visdat36ID','x','','','','',''


    exec spXAnonymizeField 'BaPerson','WichtigerHinweis','x','','','','',''






    exec spXAnonymizeField 'BaPerson','ZEMISNummer','x','','','','',''

    exec spXAnonymizeField 'BaPerson_BaInstitution','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaPerson_Relation','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaWVCode','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BaWVCode','HeimatKantonNr','','','XXX.XX.XXXX','','',''
    exec spXAnonymizeField 'BaWVCode','WohnKantonNr','','','XXX.XX.XXXX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','BankKontoNummer','','','XX-XXX.XXX.X-XX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','IBANNummer','','','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','PostKontoNummer','','','30XXXXXXX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','ReferenzNummer','','','X0XXX00000000X0X0000XX0XXX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseName','','Name','','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseName2','x','','','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseStrasse','','Strasse','','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseHausNr','','','{N}','1','99',''
    exec spXAnonymizeField 'BaZahlungsweg','AdressePostfach','','','Postfach XXXX','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdressePLZ','','','{N}','1000','9999',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseOrt','','Ort','','','',''
    exec spXAnonymizeField 'BaZahlungsweg','AdresseLandCode','x','','','','',''
    exec spXAnonymizeField 'BDELeistung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BFSDossierPerson','PersonName','','VornameName','','','',''
    exec spXAnonymizeField 'BFSWert','Wert','x','','','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','Zahlungsgrund','','Text','','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','ReferenzNummer','','','X0XXX00000000X0X0000XX0XXX','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','MitteilungZeile1','','Text','','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','MitteilungZeile2','','Text','','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','MitteilungZeile3','','Text','','','',''
    exec spXAnonymizeField 'BgAuszahlungPerson','MitteilungZeile4','','Text','','','',''
    exec spXAnonymizeField 'BgBewilligung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgBudget','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgDokument','Stichwort','','DokVorlage','','','',''
    exec spXAnonymizeField 'BgFinanzplan','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgFinanzplan_BaPerson','ReferenzNummer','','','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'BgFinanzplan_BaPerson','PrsNummerKanton','','','XXX-XX.XXX','','',''
    exec spXAnonymizeField 'BgFinanzplan_BaPerson','PrsNummerHeimat','','','XXX-XX.XXX','','',''
    exec spXAnonymizeField 'BgFinanzplan_BaPerson','AuslandChReferenzNrBund','x','','','','',''
    exec spXAnonymizeField 'BgFinanzplan_BaPerson','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgPosition','Buchungstext','','Positionsart','','','',''
    exec spXAnonymizeField 'BgPosition','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgPosition','BemerkungSaldierung','','Text','','','',''
    exec spXAnonymizeField 'BgSpezkonto','NameSpezkonto','','','Spezialkonto XXX','','',''
    exec spXAnonymizeField 'BgSpezkonto','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'BgSpezkonto','AbschlussBegruendung','','Text','','','',''
    exec spXAnonymizeField 'BgSpezkontoAbschluss','Text','','Text','','','',''
    exec spXAnonymizeField 'BgZahlungsmodus','NameZahlungsmodus','','','Zahlungsmodus XXX','','',''
    exec spXAnonymizeField 'BgZahlungsmodus','ReferenzNummer','','','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'DynaValue','Value','','DynaValue','','','',''
    exec spXAnonymizeField 'DynaValue','ValueText','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Kontaktpartner','x','','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Kontaktpartner','x','','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Stichwort','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','InhaltRTF','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungThemaText1','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungThemaText2','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungThemaText3','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungThemaText4','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungZiel1','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungZiel2','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungZiel3','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','BesprechungZiel4','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Pendenz1','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Pendenz2','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Pendenz3','','Text','','','',''
    exec spXAnonymizeField 'FaAktennotizen','Pendenz4','','Text','','','',''
    exec spXAnonymizeField 'FaDokumente','Stichwort','','DokVorlage','','','',''
    exec spXAnonymizeField 'FaDokumente','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'FaKategorisierung','Begruendung','','Text','','','',''
    exec spXAnonymizeField 'FaLeistung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'FaLeistung','Bezeichnung','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','MigrationKA','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','PscdVertragsgegenstandID','','','XXXXXXXX','','',''
    exec spXAnonymizeField 'FaLeistung','MigBemerkung','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','MigHerkunftCode','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','MigAlteFallNr','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','VUFaFallID','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','visdat36Area','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','visdat36FALLID','x','','','','',''
    exec spXAnonymizeField 'FaLeistung','visdat36LEISTUNGID','x','','','','',''
    exec spXAnonymizeField 'FaPhase','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'FaWeisung','Betreff','','Text','','','',''
    exec spXAnonymizeField 'FaWeisung','Ausganslage','','Text','','','',''
    exec spXAnonymizeField 'FaWeisung','Auflage','','Text','','','',''
    exec spXAnonymizeField 'FaZeitlichePlanung','Phase1Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'FaZeitlichePlanung','Phase2Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'FaZeitlichePlanung','Phase3Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'FbBarauszahlungAuftrag','Buchungstext','','','an Klient/in','','',''
    exec spXAnonymizeField 'FbBuchung','Text','','Text','','','',''
    exec spXAnonymizeField 'FbBuchung','PCKontoNr','','','30XXXXXXX','','',''
    exec spXAnonymizeField 'FbBuchung','BankKontoNr','','','XX-XXX.XXX.X-XX','','',''
    exec spXAnonymizeField 'FbBuchung','IBAN','','','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'FbBuchung','ReferenzNummer','','','X0XXX00000000X0X0000XX0XXX','','',''
    exec spXAnonymizeField 'FbBuchung','Zahlungsgrund','','Text','','','',''
    exec spXAnonymizeField 'FbBuchung','Name','','VornameName','','','',''
    exec spXAnonymizeField 'FbBuchung','Zusatz','x','','','','',''
    exec spXAnonymizeField 'FbBuchung','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'FbBuchung','PLZ','','PLZ','','','',''
    exec spXAnonymizeField 'FbBuchung','Ort','','Ort','','','',''
    exec spXAnonymizeField 'FbDauerauftrag','Text','','Text','','','',''
    exec spXAnonymizeField 'FbDauerauftrag','ReferenzNummer','','','X0XXX00000000X0X0000XX0XXX','','',''
    exec spXAnonymizeField 'FbDauerauftrag','Zahlungsgrund','','Text','','','',''
    exec spXAnonymizeField 'FbDTAJournal','Zahlungsdaten','x','','','','',''
    exec spXAnonymizeField 'FbKonto','KontoName','','Kontoname','','','',''
    exec spXAnonymizeField 'FbKonto','FbDepotNr','','','DXX-XHK0XXX-XX','','',''
    exec spXAnonymizeField 'FbKreditor','Name','','Name','','','',''
    exec spXAnonymizeField 'FbKreditor','KurzName','','Name','','','',''
    exec spXAnonymizeField 'FbKreditor','Zusatz','x','','','','',''
    exec spXAnonymizeField 'FbKreditor','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'FbKreditor','PLZ','','PLZ','','','',''
    exec spXAnonymizeField 'FbKreditor','Ort','','Ort','','','',''
    exec spXAnonymizeField 'FbZahlungsweg','PCKontoNr','','','30XXXXXXX','','',''
    exec spXAnonymizeField 'FbZahlungsweg','BankKontoNr','','','XX-XXX.XXX.X-XX','','',''
    exec spXAnonymizeField 'FbZahlungsweg','IBAN','','','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'FbZahlungsweg','BelegBankKontoNr','','','XXXX-XXX','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','BeantragendeStelle','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Kontaktperson','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','HausNr','','','{N}','1','99',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Zusatz','x','','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','PLZ','','PLZ','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Ort','','PLZOrt','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Postfach','','','Postfach XXXX','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Telefon','','','079 XXX XX XX','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Email','','','info@diartis.ch','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','MitteilungZeile1','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','MitteilungZeile2','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','MitteilungZeile3','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','MitteilungZeile4','','Text','','','',''
    exec spXAnonymizeField 'GvAbklaerendeStelle','Zahlungsinstruktion','','Text','','','',''
    exec spXAnonymizeField 'GvAntragPosition','Bezeichnung','','Text','','','',''
    exec spXAnonymizeField 'GvAuflage','Gegenstand','','Text','','','',''
    exec spXAnonymizeField 'GvAuflage','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'GvAuflage','Erlassungsgrund','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','Zahlungsinstruktion','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','MitteilungZeile1','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','MitteilungZeile2','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','MitteilungZeile3','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','MitteilungZeile4','','Text','','','',''
    exec spXAnonymizeField 'GvAuszahlungPosition','BuchungsText','','Text','','','',''
    exec spXAnonymizeField 'GvDocument','Stichworte','','Text','','','',''
    exec spXAnonymizeField 'GvDocument','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'GvDokumenteInformation','Information','','Text','','','',''
    exec spXAnonymizeField 'GvGesuch','Begruendung','','Text','','','',''
    exec spXAnonymizeField 'GvGesuch','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'GvGesuch','BemerkungBewilligungKompetenzstufe1','','Text','','','',''
    exec spXAnonymizeField 'GvGesuch','BemerkungBewilligungKompetenzstufe2','','Text','','','',''
    exec spXAnonymizeField 'GvGesuch','Gesuchsgrund','','Text','','','',''
    exec spXAnonymizeField 'IkAbklaerung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkAnzeige','EroeffnungGrund','','Text','','','',''
    exec spXAnonymizeField 'IkAnzeige','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkBetreibung','BetreibungNummer','','Text','','','',''
    exec spXAnonymizeField 'IkBetreibung','Glaeubiger','','Text','','','',''
    exec spXAnonymizeField 'IkBetreibung','VerlustscheinNummer','','','XXXX-XXX','','',''
    exec spXAnonymizeField 'IkBetreibung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkForderung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkGlaeubiger','Ausbildung','','Text','','','',''
    exec spXAnonymizeField 'IkGlaeubiger','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkPosition','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkRatenplan','Bezeichnung','','Text','','','',''
    exec spXAnonymizeField 'IkRatenplan','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkRechtstitel','InkassoFallName','','Text','','','',''
    exec spXAnonymizeField 'IkRechtstitel','RechtstitelInfo','','Text','','','',''
    exec spXAnonymizeField 'IkRechtstitel','ElterlicheSorgeBemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkRechtstitel','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'IkVerrechnungskonto','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaAbklaerungIntake','AsdFragen','','Text','','','',''
    exec spXAnonymizeField 'KaAbklaerungIntake','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaAbklaerungVertieft','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaArbeitsrapport','AM_Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaArbeitsrapport','PM_Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaAssistenz','Einsatzplatz','','Text','','','',''
    exec spXAnonymizeField 'KaAssistenz','Stufe','','Text','','','',''
    exec spXAnonymizeField 'KaAssistenz','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaBetriebBesprechung','Stichwort','','Text','','','',''
    exec spXAnonymizeField 'KaBetriebBesprechung','Inhalt','','Text','','','',''
    exec spXAnonymizeField 'KaBetriebDokument','Stichwort','','Text','','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Titel','','Text','','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Name','','Name','','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Vorname','','Vorname','','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Telefon','','','079 XXX XX XX','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','TelefonMobil','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Fax','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','EMail','','','info@diartis.ch','','',''
    exec spXAnonymizeField 'KaBetriebKontakt','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AnwesendTeilzeit','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','Schwerpunkte','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','ProzessBemerkungenAbschluss','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AufnahmeZielsetzungenRAV','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AufnahmeErgebnisseInterview','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AufnahmeErgebnisseBewerbung','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AufnahmeErgebnisseAssessment','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','AufnahmeErgebnisseWerkstatt','','Text','','','',''
    exec spXAnonymizeField 'KaEafSozioberuflicheBilanz','InterventionenAufforderung','','Text','','','',''
    exec spXAnonymizeField 'KaEafSpezifischeErmittlung','AnwesendTeilzeit','','Text','','','',''
    exec spXAnonymizeField 'KaEafSpezifischeErmittlung','Zielsetzungen','','Text','','','',''
    exec spXAnonymizeField 'KaEafSpezifischeErmittlung','ProzessBemerkungenAbschluss','','Text','','','',''
    exec spXAnonymizeField 'KaEafSpezifischeErmittlung','InterventionenAufforderung1','','Text','','','',''
    exec spXAnonymizeField 'KaEafSpezifischeErmittlung','InterventionenAufforderung2','','Text','','','',''
    exec spXAnonymizeField 'KaIntegBildung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQ','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQ','IndivZieleRAVVerl','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQ','AustrittBemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQ','muendAuffordBem1','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQ','muendAuffordBem2','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinb','Feinziel','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinb','ErreichenBis','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinb','MessungZielerreichung','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinb','Ergebnis','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinbVerl','Feinziel','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinbVerl','ErreichenBis','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinbVerl','MessungZielerreichung','','Text','','','',''
    exec spXAnonymizeField 'KaQEEPQZielvereinbVerl','Ergebnis','','Text','','','',''
    exec spXAnonymizeField 'KaQEJobtimum','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQEJobtimum','Zusatzinfos','','Text','','','',''
    exec spXAnonymizeField 'KaQEJobtimum','muendAuffordBem1','','Text','','','',''
    exec spXAnonymizeField 'KaQEJobtimum','muendAuffordBem2','','Text','','','',''
    exec spXAnonymizeField 'KaQEJobtimum','AustrittBemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom1Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom2Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom3Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom4Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom5Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJBildung','KursCustom6Text','','Text','','','',''
    exec spXAnonymizeField 'KaQJIntake','Eintritt','','Text','','','',''
    exec spXAnonymizeField 'KaQJIntake','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaQJProzess','AndereStellen','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZAssessment','ProjGefaehrGrund','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZAssessment','NichtAufgGrund','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','BemKompetenz','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','BemBildung','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','BemZielvereinbarung','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','BemAbsenzen','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','BemEmpfehlung','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZSchlussbericht','EingVermittelbar','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZZielvereinbarung','VereinbartesZiel','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZZielvereinbarung','ErreichenBis','','Text','','','',''
    exec spXAnonymizeField 'KaQJPZZielvereinbarung','KriterienPruefen','','Text','','','',''
    exec spXAnonymizeField 'KaQJVereinbarung','GrundZiel','','Text','','','',''
    exec spXAnonymizeField 'KaQJVereinbarung','Abmachungen','','Text','','','',''
    exec spXAnonymizeField 'KaTransfer','MuendAufforderungBem1','','Text','','','',''
    exec spXAnonymizeField 'KaTransfer','MuendAufforderungBem2','','Text','','','',''
    exec spXAnonymizeField 'KaTransfer','AustrittBem','','Text','','','',''
    exec spXAnonymizeField 'KaTransferZielvereinb','Feinziel','','Text','','','',''
    exec spXAnonymizeField 'KaTransferZielvereinb','ErreichenBis','','Text','','','',''
    exec spXAnonymizeField 'KaTransferZielvereinb','Ergebnis','','Text','','','',''
    exec spXAnonymizeField 'KaVerlauf','Kontaktperson','','Text','','','',''
    exec spXAnonymizeField 'KaVerlauf','Stichwort','','Text','','','',''
    exec spXAnonymizeField 'KaVerlauf','InhaltRTF','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungBIBIP','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungEinsatz','ArbeitspensumErgaenzungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungEinsatz','BIEAZBemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungEinsatz','InizioAbschlussGrund','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungEinsatz','InizioLoesung','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungEinsatz','EinsatzBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','VermittelbarkeitBemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','GesundheitEinschraenkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','GesundheitBemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','BesondereWuensche','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','BesondereFaehigkeiten','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','ArbeitsgebietBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungProfil','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungSI','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungSIZwischenbericht','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KaVermittlungVorschlag','VorschlagBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','Text','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','Extern','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','ReferenzNummer','','','X0XXX00000000X0X0000XX0XXX','','',''
    exec spXAnonymizeField 'KbBuchung','AggregateInfo','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','FibuFehlermeldung','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','Remark','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','PCKontoNr','','Text','30XXXXXXX','','',''
    exec spXAnonymizeField 'KbBuchung','BankKontoNr','','Text','XX-XXX.XXX.X-XX','','',''
    exec spXAnonymizeField 'KbBuchung','IBAN','','Text','CHXXX00XX000XXXX0XXXX','','',''
    exec spXAnonymizeField 'KbBuchung','Zahlungsgrund','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','MitteilungZeile1','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','MitteilungZeile2','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','MitteilungZeile3','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','MitteilungZeile4','','Text','','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtName','','Name','','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtName2','x','','','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtStrasse','','Strasse','','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtHausNr','','','{N}','1','99',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtPostfach','','','Postfach - XXXX','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtPLZ','','PLZ','','','',''
    exec spXAnonymizeField 'KbBuchung','BeguenstigtOrt','','Ort','','','',''
    exec spXAnonymizeField 'KbBuchungKostenart','Buchungstext','','Kostenart','','','',''
    exec spXAnonymizeField 'KbWVEinzelposten','Buchungstext','','Kostenart','','','',''
    exec spXAnonymizeField 'KbWVEinzelposten','HeimatkantonNr','','','XXX.XX.XXXX','','',''
    exec spXAnonymizeField 'KbWVEinzelposten','WohnKantonNr','','','XXX.XX.XXXX','','',''
    exec spXAnonymizeField 'KbWVEinzelposten','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Debitor','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Mitteilung1','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Mitteilung2','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Mitteilung3','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Mitteilung4','','Text','','','',''
    exec spXAnonymizeField 'KbZahlungseingang','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KesAuftrag','Anlass','','Text','','','',''
    exec spXAnonymizeField 'KesAuftrag','Auftrag','','Text','','','',''
    exec spXAnonymizeField 'KesMassnahme','Auftragstext','','Text','','','',''
    exec spXAnonymizeField 'KesMassnahme','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'KesPraevention','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmAHVMindestbeitrag','BeitragsRechnungsJahr','','Text','','','',''
    exec spXAnonymizeField 'VmAHVMindestbeitrag','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmAntragEKSK','Antrag','','Text','','','',''
    exec spXAnonymizeField 'VmAntragEKSK','Begruendung','','Text','','','',''
    exec spXAnonymizeField 'VmAntragEKSK','Titel','','Text','','','',''
    exec spXAnonymizeField 'VmBericht','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmBeschwerdeAnfrage','Absender','','Text','','','',''
    exec spXAnonymizeField 'VmBeschwerdeAnfrage','Stichworte','','Text','','','',''
    exec spXAnonymizeField 'VmBudget','Stichworte','','Text','','','',''
    exec spXAnonymizeField 'VmBudget','Grund','','Text','','','',''
    exec spXAnonymizeField 'VmELKrankheitskosten','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmErbe','Titel','','Text','','','',''
    exec spXAnonymizeField 'VmErbe','Geburtsdatum','x','','','','',''
    exec spXAnonymizeField 'VmErbe','FamilienNamen','','Name','','','',''
    exec spXAnonymizeField 'VmErbe','Vornamen','','Vorname','','','',''
    exec spXAnonymizeField 'VmErbe','Zusatz','x','','','','',''
    exec spXAnonymizeField 'VmErbe','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'VmErbe','Ort','','PLZOrt','','','',''
    exec spXAnonymizeField 'VmErbe','Ergaenzung','','Text','','','',''
    exec spXAnonymizeField 'VmErbe','KontaktAdresse','','Text','','','',''
    exec spXAnonymizeField 'VmErbe','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmErbe','Titel2','','Text','','','',''
    exec spXAnonymizeField 'VmErblasser','TodesDatum','','','','','','x'
    exec spXAnonymizeField 'VmErblasser','TodesDatumText','','Text','','','',''
    exec spXAnonymizeField 'VmErblasser','TodesOrt','','Ort','','','',''
    exec spXAnonymizeField 'VmErblasser','AHVNummer','','','XXX.XX.XXX.000','','',''
    exec spXAnonymizeField 'VmErblasser','FamilienNamen','','Name','','','',''
    exec spXAnonymizeField 'VmErblasser','LedigName','x','','','','',''
    exec spXAnonymizeField 'VmErblasser','Vornamen','','Vorname','','','',''
    exec spXAnonymizeField 'VmErblasser','Elternnamen','','Name','','','',''
    exec spXAnonymizeField 'VmErblasser','Zivilstand','','Text','','','',''
    exec spXAnonymizeField 'VmErblasser','Geburtsdatum','x','','','','',''
    exec spXAnonymizeField 'VmErblasser','Heimatorte','x','','','','',''
    exec spXAnonymizeField 'VmErblasser','Strasse','','Strasse','','','',''
    exec spXAnonymizeField 'VmErblasser','Ort','','Ort','','','',''
    exec spXAnonymizeField 'VmErblasser','Aufenthalt','','Text','','','',''
    exec spXAnonymizeField 'VmErblasser','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmErblasser','Versichertennummer','','','XXX.XXXX.XXXX.XX','','',''
    exec spXAnonymizeField 'VmErbschaftsdienst','Massnahme','','Text','','','',''
    exec spXAnonymizeField 'VmErbschaftsdienst','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmGefaehrdungsMeldung','Ausgangslage','','Text','','','',''
    exec spXAnonymizeField 'VmGefaehrdungsMeldung','Auflagen','','Text','','','',''
    exec spXAnonymizeField 'VmGefaehrdungsMeldung','Ueberpruefung','','Text','','','',''
    exec spXAnonymizeField 'VmGefaehrdungsMeldung','Konsequenzen','','Text','','','',''
    exec spXAnonymizeField 'VmInventar','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmMandant','Name','','Name','','','',''
    exec spXAnonymizeField 'VmMandant','Vorname','','Vorname','','','',''
    exec spXAnonymizeField 'VmMandant','Geburtsdatum','','','','','','x'
    exec spXAnonymizeField 'VmMandant','HeimatgemeindeBaGemeindeID','x','','','','',''
    exec spXAnonymizeField 'VmMandant','Beruf','x','','','','',''
    exec spXAnonymizeField 'VmMandant','WertschriftenDepot','','','XXX.XXXX.XXXX.XX','','',''
    exec spXAnonymizeField 'VmMandant','AHVNummer','','Text','XXX.XX.XXX.000','','',''
    exec spXAnonymizeField 'VmMandant','Versichertennummer','','Text','XXX.XXXX.XXXX.XX','','',''
    exec spXAnonymizeField 'VmMandant','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','GrundMassnahmeText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','AuftragZielsetzungText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','Begruendung','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','NeueZieleText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','WohnenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','GesundheitText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','VerhaltenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','TaetigkeitText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','FamSituationText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','SozialeKompetenzenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','FreizeitText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','BesondereRessourcenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','HandlungenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','BesondereSchwierigkeitenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','KlientText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','DritteText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','InstitutionenText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','BelastungMandatText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','BelastungAdminText','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','EinnahmenBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','VersicherungenBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','BesondereAngabenBemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','PassationBemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmMandBericht','AntragBegruendung','','Text','','','',''
    exec spXAnonymizeField 'VmMassnahme','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmPosition','Name','','VornameName','','','',''
    exec spXAnonymizeField 'VmPosition','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmPriMa','Name','','Name','','','',''
    exec spXAnonymizeField 'VmPriMa','Vorname','','Vorname','','','',''
    exec spXAnonymizeField 'VmPriMa','Telefon_P','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'VmPriMa','Telefon_G','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'VmPriMa','MobilTel','','','076 XXX XX XX','','',''
    exec spXAnonymizeField 'VmPriMa','Fax','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'VmPriMa','EMail','','','info@diartis.ch','','',''
    exec spXAnonymizeField 'VmPriMa','Beruf','x','','','','',''
    exec spXAnonymizeField 'VmPriMa','BankName','','Text','','','',''
    exec spXAnonymizeField 'VmPriMa','BankKontoNr','','Text','XX-XXX.XXX.X-XX','','',''
    exec spXAnonymizeField 'VmPriMa','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmPriMa','AHVNummer','','','XXX.XX.XXX.000','','',''
    exec spXAnonymizeField 'VmPriMa','Versichertennummer','','','XXX.XXXX.XXXX.XX','','',''
    exec spXAnonymizeField 'VmSachversicherung','Policenummer','','','XXX-XX-XX','','',''
    exec spXAnonymizeField 'VmSachversicherung','Grundpraemie','','','XXX.X0','','',''
    exec spXAnonymizeField 'VmSachversicherung','Person','','Text','','','',''
    exec spXAnonymizeField 'VmSachversicherung','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmSchulden','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmSiegelung','KopieAndere','','Text','','','',''
    exec spXAnonymizeField 'VmSiegelung','PliQuittung','','Text','','','',''
    exec spXAnonymizeField 'VmSiegelung','MassaVerwalter','','Text','','','',''
    exec spXAnonymizeField 'VmSiegelung','RechnungsNr','','','XX-XXXXXXX','','',''
    exec spXAnonymizeField 'VmSiegelung','RechnungAn','','Text','','','',''
    exec spXAnonymizeField 'VmSiegelung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmSituationsBericht','BerichtFinanzen','','Text','','','',''
    exec spXAnonymizeField 'VmSituationsBericht','ZielPrognose','','Text','','','',''
    exec spXAnonymizeField 'VmSituationsBericht','AntragText','','Text','','','',''
    exec spXAnonymizeField 'VmSozialversicherung','Grund','','Text','','','',''
    exec spXAnonymizeField 'VmSozialversicherung','Berechnungsgrundlage','','Text','','','',''
    exec spXAnonymizeField 'VmSozialversicherung','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmSteuern','ErledigungDurch','','Text','','','',''
    exec spXAnonymizeField 'VmSteuern','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'VmTestament','EroeffnungsRechnungSAPNr','','','XXXXXXX','','',''
    exec spXAnonymizeField 'VmTestament','ZusatzRechnungSAPNr','x','','','','',''
    exec spXAnonymizeField 'VmTestament','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentBescheinigung','BescheinigungText','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentBescheinigung','SAPNr','','','XXXXXXX','','',''
    exec spXAnonymizeField 'VmTestamentBescheinigung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentVerfuegung','VerfuegungText','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentVerfuegung','ABOvorherText','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentVerfuegung','ABOnachherText','','Text','','','',''
    exec spXAnonymizeField 'VmTestamentVerfuegung','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'VmVaterschaft','AnerkennungOrt','','Ort','','','',''
    exec spXAnonymizeField 'VmVaterschaft','GeburtsmitteilungOrt','','Ort','','','',''
    exec spXAnonymizeField 'VmVaterschaft','PendenzText','','Text','','','',''
    exec spXAnonymizeField 'VmVaterschaft','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'WhASVSEintrag','Bemerkung','','Text','','','',''
    exec spXAnonymizeField 'XTask','Subject','','Pendenz','','','',''
    exec spXAnonymizeField 'XTask','TaskDescription','','Text','','','',''
    exec spXAnonymizeField 'XTask','ResponseText','','Text','','','',''
    exec spXAnonymizeField 'XUser','MitarbeiterNr','','','XXXX','','',''
    exec spXAnonymizeField 'XUser','FirstName','','Name','','','',''
    exec spXAnonymizeField 'XUser','LastName','','Vorname','','','',''
    exec spXAnonymizeField 'XUser','ShortName','','UserID','','','',''
    exec spXAnonymizeField 'XUser','Phone','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','PhoneMobile','','','078 XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','PhoneOffice','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','PhoneIntern','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','PhonePrivat','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','Fax','','','0XX XXX XX XX','','',''
    exec spXAnonymizeField 'XUser','EMail','','','info@diartis.ch','','',''
    exec spXAnonymizeField 'XUser','Bemerkungen','','Text','','','',''
    exec spXAnonymizeField 'XUser','Text1','x','','','','',''
    exec spXAnonymizeField 'Xuser','Text2','x','','','','',''
    exec spXAnonymizeField 'XUser','MigHerkunft','x','','','','',''
    exec spXAnonymizeField 'XUser','MigMAKuerzel','x','','','','',''
    exec spXAnonymizeField 'XUser','visdat36Area','x','','','','',''
    exec spXAnonymizeField 'XUser','visdat36SourceFile','x','','','','',''
    exec spXAnonymizeField 'XUser','visdat36ID','x','','','','',''
    exec spXAnonymizeField 'XUser','visdat36Name','x','','','','',''


  -- reenable triggers
  SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

  -------------------------------------------------------------------------------
  -- loop all entries
  -------------------------------------------------------------------------------
  WHILE (@EntriesIterator <= @EntriesCount)
  BEGIN
    -- get current entry
    SELECT @sql = 'enable trigger ' + Triggername + ' on ' + Tablename
    FROM @EnabledHistoryTriggers TMP
    WHERE TMP.ID = @EntriesIterator;
  
     exec (@sql)
  
    -- prepare for next entry
    SET @EntriesIterator = @EntriesIterator + 1;
  END
END;
