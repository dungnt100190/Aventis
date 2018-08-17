SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XModulTree]
GO
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10000, NULL, 1, 1, 134, N'Klientensystem', N'CtlBaHaushalt', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (11000, NULL, 1, 2, 133, N'Person', N'CtlBaPerson', NULL, N'ALTER TABLE #Tree ADD
  Unterstuetzt  bit,
  Age           int', 999, N'INSERT INTO #Tree (ModulTreeID, ID, Name, BaPersonID, Unterstuetzt, Age)
  SELECT @ModulTreeID,
    ''P'' + CONVERT(varchar, BaPersonID),
    Name + IsNull('', '' + Vorname, ''''),
    BaPersonID,
    CASE WHEN BaPersonID = @BaPersonID THEN 1 ELSE IsNull(dbo.fnUnterstuetzt(@BaPersonID, BaPersonID, GetDate()), 1) END,
    Age = CONVERT(int, ((DateDiff(dd, Geburtsdatum, GetDate()) + 0.5) / 365.25))
  FROM BaPerson PRS
  WHERE BaPersonID = @BaPersonID
    OR BaPersonID IN (SELECT BaPersonID_1 FROM BaPerson_Relation WHERE BaPersonID_2 = @BaPersonID
                       UNION
                       SELECT BaPersonID_2 FROM BaPerson_Relation WHERE BaPersonID_1 = @BaPersonID)
  ORDER BY CASE WHEN PRS.BaPersonID = @BaPersonID THEN 0 ELSE 1 END, Age DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (12000, NULL, 1, 4, 191, N'Institutionen', N'CtlBaInstitutionenFachpersonen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20000, NULL, 2, 1, 193, N'Sozialsystem', N'CtlFaSozialSystem', NULL, N'ALTER TABLE #Tree ADD
  Aufnahme        datetime,
  SARName         varchar(100),
  ModulID         int,
  FaPhaseID       int', 999, N'INSERT INTO #Tree (ModulTreeID, ID) VALUES (@ModulTreeID, ''S'')', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20002, NULL, 2, 2, 1201, N'Fallführung', N'CtlFaBeratungsperiode', NULL, NULL, 3, N'UPDATE TRE
  SET Aufnahme    = FLE.DatumVon,
      SARName     = USR.LastName + IsNull('', '' + USR.FirstName,'''')
FROM #Tree               TRE
  INNER JOIN FaLeistung  FLE ON FLE.FaLeistungID = TRE.FaLeistungID
  LEFT  JOIN XUser       USR ON USR.UserID = FLE.UserID
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20020, NULL, 2, 3, 26, N'Pendenzen', N'CtlPendenzenVerwaltung', NULL, N'ALTER TABLE #Tree 
ADD SqlFilter varchar(255)', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, SqlFilter)
  SELECT TOP 1
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, ''''),
    IconID      = @IconID,
    FAL.FaFallID, 
    FLE.FaLeistungID, 
    @BaPersonID, 
    ''1 = 1''
  FROM FaFall                    FAL
    INNER JOIN FaLeistung        FLE ON FLE.FaFallID = FAL.FaFallID
  WHERE FAL.BaPersonID = @BaPersonID 
    AND FAL.FaFallID = IsNull(@FaFallID, FAL.FaFallID) 
    AND FLE.ModulID = @ModulID
    AND FLE.DatumBis IS NULL
    AND ISNULL(FLE.FaProzessCode, 200) = 200 -- nur Fallführung berücksichtigen
  ORDER BY
    CASE WHEN FAL.DatumBis IS NULL THEN 0 ELSE 1 END, FAL.DatumVon DESC,
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30000, NULL, 3, 1, 1301, N'Sozialhilfe', N'CtlWhLeistung', NULL, N'ALTER TABLE #Tree ADD
  DatumVon                 datetime,
  Abgeschlossen            bit,
  BgFinanzplanID           int,
  BgBudgetID               int,
  MasterBudget             bit,
  BgBewilligungStatusCode  int,
  BgSpezkontoTypCode       int,
  Typ             varchar(100),
  RecordID        int', 3, N'UPDATE #Tree 
SET Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
FROM #Tree              TRE 
  INNER JOIN FaLeistung LST ON LST.FaLeistungID = TRE.FaLeistungID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40000, NULL, 4, 7, 1401, N'Elternbeitrag', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40002, NULL, 4, 2, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenSchuldner', NULL, N'Alter table #Tree add 
    Datum datetime,
    RechtstitelID int', 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40004, NULL, 4, 4, 83, N'Abklärung', N'CtlIkLeistung', NULL, N'Alter table #Tree add 
  SchuldnerName   varchar(200),
  InkassoGesperrt bit,
  FaProzessCode   int,
  Geburtsdatum datetime', 3, N'DELETE TRE
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID AND FLE.FaProzessCode <> 400

UPDATE #Tree SET FaProzessCode = 400', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40005, NULL, 4, 8, 1401, N'Rückerstattung', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40006, NULL, 4, 9, 1411, N'Verwandtenbeitrag', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40008, NULL, 4, 10, 1401, N'Tagesheim/Krippe', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40009, NULL, 4, 11, 1401, N'Nachlass', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40036, NULL, 4, 13, 2117, N'Kontoauszug', N'CtlIkKontoauszug', NULL, NULL, 999, N'IF (EXISTS (SELECT TOP 1 1 
            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
            WHERE LEI.BaPersonID = @BaPersonID 
              AND LEI.ModulID = 4
              AND LEI.FaProzessCode IS NOT NULL))
BEGIN
  INSERT INTO #Tree (ModulTreeID, ID, BaPersonID)
  VALUES (@ModulTreeID, IsNull(@ClassName, CONVERT(VARCHAR, @ModulTreeID)), @BaPersonID);
END;', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40044, NULL, 4, 12, 1401, N'Rückerstattung POM', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41000, NULL, 4, 6, 1401, N'Alimente', N'CtlIkLeistung', NULL, NULL, 3, N'DELETE TRE
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID IN (1, @ModulTreeID) AND FLE.FaProzessCode = 400


UPDATE TRE
  SET ModulTreeID = CASE FLE.FaProzessCode
        WHEN 400   THEN 40004 -- Abklärung
        WHEN 401   THEN 41000 -- Alimente
        WHEN 402   THEN 40000 -- Elternbeitrag
        WHEN 403   THEN 40005 -- Rückerstattung
        WHEN 404   THEN 40006 -- Verwandtenbeitrag
        WHEN 405   THEN 40008 -- Tagesheim/Krippe
        WHEN 406   THEN 40009 -- Nachlass
        WHEN 407   THEN 40044 -- Rückerstattung POM
        ELSE 41000            -- Alimente
    END,
    FaProzessCode = FLE.FaProzessCode
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID

UPDATE TRE
  SET Name = isNull(FLE.Bezeichnung + '' '', '''') + COALESCE(TRE.Name COLLATE DATABASE_DEFAULT, LAN.Text, MTR.Name)
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
  INNER JOIN XModulTree   MTR ON MTR.ModulTreeID = TRE.ModulTreeID
  LEFT  JOIN XLangText    LAN ON LAN.TID = MTR.NameTID AND LAN.LanguageCode = @LanguageCode', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50000, NULL, 5, 1, 1501, N'Vormundschaftliche Massnahme', N'CtlVmProzess', NULL, N'ALTER TABLE #Tree ADD  
   Zusatz varchar(50),  
   FaProzessCode int, 
   System bit,
   VmSiegelungID int,
   VmTestamentID int,
   VmErbschaftsdienstID int', 3, N'UPDATE TRE
  SET ModulTreeID = CASE FLE.FaProzessCode
        WHEN 501  THEN 50000 -- Vormundschaftliche Massnahme
        WHEN 502  THEN 50026 -- Vaterschaftsabklärung
        WHEN 503  THEN 50029 -- Erbschaft
--        WHEN 31 THEN 50029 -- Erbschaft: Siegelung
--        WHEN 32 THEN 50029 -- Erbschaft: Testament
--        WHEN 33 THEN 50029 -- Erbschaft: Erbschaftsamt
        WHEN 504  THEN 50030 -- Pflegekinderaufsicht
        WHEN 505  THEN 50031 -- Vormundschaftlicher Auftrag
        ELSE         50000 -- Vormundschaftliche Massnahme
    END,
    FaProzessCode = isNull(FLE.FaProzessCode, 0), 
    System = convert(bit, 0), -- TODO!
    Zusatz = Convert(varchar, FLE.DatumVon, 104)
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50026, NULL, 5, 2, 1501, N'Vaterschaftsabklärung', N'CtlVmProzess', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50029, NULL, 5, 3, 1501, N'Erbschaftsamt', N'CtlVmProzess', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50030, NULL, 5, 4, 1501, N'Pflegekinder', N'CtlVmProzess', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50031, NULL, 5, 5, 1501, N'Auftrag Jugendamt', N'CtlVmProzess', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60000, NULL, 6, 1, 1601, N'Asyl', N'CtlAyFall', NULL, N'ALTER TABLE #Tree ADD
  Typ             varchar(100),
  RecordID        int,
  BgBudgetID      int,
  AppCode         varchar(200) DEFAULT '''',
  DatumVon        datetime', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, Typ, FaLeistungID, BaPersonID, DatumVon)
  SELECT @ModulTreeID,
    ''FAL'' + CONVERT(varchar, FAL.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FAL.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN 1003 + 100 * FAL.ModulID  -- Archiviert
      WHEN FAL.DatumBis IS NOT NULL  THEN 1002 + 100 * FAL.ModulID  -- Abgeschlossen
      ELSE 1001 + 100 * FAL.ModulID
    END,
    ''AyFall'', FAL.FaLeistungID, FAL.BaPersonID, FAL.DatumVon
  FROM FaLeistung                FAL
    LEFT  JOIN FaLeistungArchiv  ARC ON ARC.FaLeistungID = FAL.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FAL.ModulID = @ModulID
  ORDER BY CASE WHEN FAL.DatumBis IS NULL THEN 0 ELSE 1 END, FAL.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70000, NULL, 7, 2, 1701, N'Allgemein', NULL, N'Ka_Allgemein', N'ALTER TABLE #Tree ADD
  DatVon                   datetime,
  ProzessCode              int', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, DatVon, ProzessCode)
  SELECT
    ModulTreeID = CASE FLE.FaProzessCode
                    WHEN 700 THEN 70000
                    WHEN 701 THEN 70001
                    WHEN 702 THEN 70006
                    WHEN 703 THEN 70002
                    WHEN 704 THEN 70003
                    WHEN 705 THEN 70004
                    WHEN 706 THEN 70005
                    WHEN 707 THEN 70007
                    WHEN 708 THEN 70108
                    ELSE 
                      CASE WHEN dbo.fnUserMayReadFall(@UserID, FAL.FaFallID) = 0 THEN 1 ELSE @ModulTreeID END
                  END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN (dbo.fnUserHasRight(@UserID, @ClassName) = 0 AND dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0) THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID,
    DatVon = CASE WHEN FLE.FaProzessCode BETWEEN 701 AND 720 THEN FLE.DatumVon ELSE NULL END,
    ProzessCode = FLE.FaProzessCode
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.FaProzessCode = 700 THEN 0 ELSE 1 END ASC,
    CASE WHEN FAL.DatumBis IS NULL THEN 0 ELSE 1 END, FAL.DatumVon DESC,
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70001, NULL, 7, 3, 1701, N'Abklärung', N'CtlKaProzessAK', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70002, NULL, 7, 4, 1701, N'Qualifizierung Jugend', N'CtlKaProzessQJ', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70003, NULL, 7, 5, 1701, N'Qualifizierung Erwachsene', N'CtlKaProzessQE', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70004, NULL, 7, 6, 1701, N'Vermittlung BI/BIP', N'CtlKaProzessBIBIP', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70005, NULL, 7, 7, 1701, N'Vermittlung SI', N'CtlKaProzessSI', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70006, NULL, 7, 8, 1701, N'Inizio', N'CtlKaProzessInizio', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70007, NULL, 7, 9, 1701, N'Assistenz', N'CtlKaProzessAS', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70108, NULL, 7, 10, 1701, N'Transfer', N'CtlKaTransfer', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (11001, 11000, 1, 1, 187, N'Gesundheit', N'CtlGesundheit', NULL, NULL, 1, N'UPDATE #Tree
  SET Age = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (11002, 11000, 1, 2, 172, N'Arbeit', N'CtlArbeit', NULL, NULL, 1, N'AND Unterstuetzt = 1

UPDATE #Tree
  SET Age = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20001, 20000, 2, 1, 0, N'Fälle', N'CtlFaSozialSystem', NULL, NULL, 999, N'DECLARE @Person TABLE (BaPersonID int PRIMARY KEY)

INSERT INTO @Person VALUES (@BaPersonID)

WHILE @@rowcount > 0 BEGIN
  INSERT @Person
    SELECT PRE.BaPersonID_1
    FROM @Person P
      INNER JOIN BaPerson           PRS ON PRS.BaPersonID = P.BaPersonID AND IsNull(PRS.Fiktiv, 0) = 0
      INNER JOIN BaPerson_Relation  PRE ON PRE.BaPersonID_2 = P.BaPersonID
    WHERE NOT EXISTS (SELECT * FROM @Person WHERE BaPersonID = PRE.BaPersonID_1)
    UNION
    SELECT PRE.BaPersonID_2
    FROM @Person P
      INNER JOIN BaPerson           PRS ON PRS.BaPersonID = P.BaPersonID AND IsNull(PRS.Fiktiv, 0) = 0
      INNER JOIN BaPerson_Relation  PRE ON PRE.BaPersonID_1 = P.BaPersonID
    WHERE NOT EXISTS (SELECT * FROM @Person WHERE BaPersonID = PRE.BaPersonID_2)
END

INSERT INTO #Tree (ModulTreeID, ID, ParentID, Name, Aufnahme, SARName, FaFallID, FaLeistungID, ModulID, IconID)
  SELECT DISTINCT
    @ModulTreeID,
    ''F'' + CONVERT(varchar, FLE.FaLeistungID),
    ''S'',
    PRS.Name + IsNull('', '' + PRS.Vorname,''''),
    FLE.DatumVon,
    USR.LastName + IsNull('', '' + USR.FirstName,''''),
    FLE.FaFallID,
    FLE.FaLeistungID,
    FLE.ModulID,
    IconID = 100 * FLE.ModulID + 1000 + CASE
      WHEN ARC.FaLeistungID IS NOT NULL  THEN 3  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL      THEN 2  -- Abgeschlossen
      ELSE 1
    END
  FROM @Person P
    INNER JOIN FaLeistung        FLE ON FLE.BaPersonID = P.BaPersonID
    LEFT  JOIN FaLeistungArchiv  ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
    INNER JOIN BaPerson          PRS ON PRS.BaPersonID = P.BaPersonID
    LEFT  JOIN XUser             USR ON USR.UserID = FLE.UserID
  ORDER BY FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20003, 20002, 2, 42, 180, N'Dokumentation', NULL, N'Fa_Dok', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (21000, 20002, 2, 43, 192, N'Intake', N'CtlFaBeratungsphase', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Aufnahme, SARName, FaFallID, FaLeistungID, FaPhaseID, BaPersonID)
  SELECT
    ModulTreeID = CASE
                    WHEN dbo.fnUserMayReadFall(@UserID, PHA.FaLeistungID) = 0 THEN 1 
                    WHEN PHA.FaPhaseCode = 1 THEN 21000
                    WHEN PHA.FaPhaseCode = 2 THEN 22000
                    ELSE @ModulTreeID
                  END,
    ID          = @ClassName + CONVERT(varchar, PHA.FaPhaseID),
    ParentID    = TRE.ID,
    Aufnahme    = PHA.DatumVon,
    SARName     = USR.LastName + IsNull('', '' + USR.FirstName,''''),
    TRE.FaFallID, PHA.FaLeistungID, PHA.FaPhaseID,
    BaPersonID = @BaPersonID
  FROM #Tree           TRE
    INNER JOIN FaPhase PHA ON PHA.FaLeistungID = TRE.FaLeistungID
    LEFT  JOIN XUser   USR ON USR.UserID = PHA.UserID
  WHERE TRE.BaPersonID = @BaPersonID AND 
        TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY PHA.DatumVon DESC
--  ORDER BY CASE WHEN PHA.DatumBis IS NULL THEN 0 ELSE PHA.DatumBis END DESC, PHA.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (22000, 20002, 2, 44, 190, N'Beratungsphase', N'CtlFaBeratungsphase', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (23000, 20002, 2, 45, 203, N'Kategorisierung', N'Kiss.UI.View.Fa.FaKategorisierungView.xaml', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20021, 20020, 2, 1, 31, N'fällige', N'CtlPendenzenVerwaltung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, SqlFilter)
    SELECT @ModulTreeID, 
           IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)) + ''Faellige'', 
           TRE.ID,
           TRE.FaFallID,
           TRE.FaLeistungID,
           ''TaskStatusCode IN (1, 2) AND ExpirationDate <= GetDate()''
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20022, 20020, 2, 2, 26, N'offene', N'CtlPendenzenVerwaltung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, SqlFilter)
    SELECT @ModulTreeID, 
           IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)) + ''Offene'', 
           TRE.ID, 
           TRE.FaFallID,
           TRE.FaLeistungID,
           ''TaskStatusCode IN (1, 2)''
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20023, 20020, 2, 3, 30, N'erledigte', N'CtlPendenzenVerwaltung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, SqlFilter)
    SELECT @ModulTreeID, 
           IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)) + ''Erledigte'', 
           TRE.ID,  
           TRE.FaFallID,
           TRE.FaLeistungID,
           ''TaskStatusCode IN (3)''
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30012, 30000, 3, 6, 1422, N'Klientenabrechnung', N'CtlWhKlientenabrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30100, 30000, 3, 1, 1312, N'Reguläre Sozialhilfe', N'CtlWhFinanzplan', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BgFinanzplanID, BaPersonID, BgBudgetID, Name, DatumVon, Abgeschlossen)
  SELECT @ModulTreeID, IsNull(@ClassName, '''') + CONVERT(varchar, SFP.BgFinanzPlanID), TRE.ID,
    CASE SFP.BgBewilligungStatusCode
      WHEN 1  THEN 1312  -- Vorbereitung
      WHEN 2  THEN 1312  -- Abgelehnt
      WHEN 3  THEN 1313  -- Angefragt
      WHEN 5  THEN 1314  -- Bewilligt
      WHEN 9  THEN 1315  -- Gesperrt
    END,
    TRE.FaFallID, TRE.FaLeistungID, SFP.BgFinanzplanID, TRE.BaPersonID, BBG.BgBudgetID,
    TYP.Text + '': '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumVon, SFP.GeplantVon)) + IsNull('' - '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumBis, SFP.GeplantBis)), ''''),
    IsNull(SFP.DatumVon, SFP.GeplantVon),
    Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
  FROM #Tree                 TRE
    INNER JOIN BgFinanzPlan  SFP ON SFP.FaLeistungID = TRE.FaLeistungID
    INNER JOIN FaLeistung    LST ON LST.FaLeistungID = TRE.FaLeistungID
    LEFT  JOIN XLOVCode      TYP ON TYP.LOVName = ''WhHilfeTyp'' AND TYP.Code = SFP.WhHilfeTypCode
    LEFT  JOIN BgBudget      BBG ON BBG.BgFinanzPlanID = SFP.BgFinanzPlanID AND BBG.Masterbudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY IsNull(SFP.DatumVon, SFP.GeplantVon) DESC, SFP.BgFinanzplanID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30120, 30000, 3, 7, 1428, N'Kontoauszug', N'CtlWhKontoauszug', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30131, 30000, 3, 2, 1327, N'Vorabzugskonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''2'', BgSpezkontoTypCode = 2
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30132, 30000, 3, 3, 1328, N'Abzahlungskonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''3'', BgSpezkontoTypCode = 3
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30133, 30000, 3, 4, 1329, N'Ausgabekonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''1'', BgSpezkontoTypCode = 1
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30134, 30000, 3, 5, 1335, N'Kürzungen', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''4'', BgSpezkontoTypCode = 4
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70046, 30000, 3, 8, 1321, N'ASV', N'CtlWhASVSErfassung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40001, 40000, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40003, 40000, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40007, 40000, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, N'-- Alter table #Tree add RechtstitelID int', 1, N'/*
Update #Tree set RechtstitelID = (
  select IkRechtsTitelID from IkRechtstitel
  where FaLeistungID = #Tree.FaLeistungID )
WHERE ModulTreeID = @ModulTreeID
*/', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40011, 40000, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 999, N'IF @ModulTreeID_Parent IS NULL
  INSERT INTO #Tree (ModulTreeID, ID, ParentID, BaPersonID)
    SELECT @ModulTreeID, IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), NULL, @BaPersonID
ELSE
  INSERT INTO #Tree (ModulTreeID, ID, ParentID, @FieldList)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, @FieldList
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent

UPDATE TRE
  SET FaProzessCode = FLE.FaProzessCode
FROM #Tree                TRE
  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40014, 40000, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40025, 40000, 4, 5, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
SELECT ModulTreeID = @ModulTreeID, 
       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
       ParentID    = TRE.ID,
       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
       Datum       = null,
       BaPersonID  = PRS.BaPersonID,
       LEI.FaLeistungID,
       LEI.FaProzessCode
FROM #Tree                 TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40037, 40000, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40043, 40004, 4, 1, 202, N'Abklärungen', N'CtlIkAbklaerungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40015, 40005, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40016, 40005, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40017, 40005, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40019, 40005, 4, 6, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40051, 40005, 4, 5, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40052, 40005, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40010, 40006, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40021, 40006, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40022, 40006, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40023, 40006, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40024, 40006, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40030, 40006, 4, 5, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
SELECT ModulTreeID = @ModulTreeID, 
       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
       ParentID    = TRE.ID,
       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
       Datum       = null,
       BaPersonID  = PRS.BaPersonID,
       LEI.FaLeistungID,
       LEI.FaProzessCode
FROM #Tree                 TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40039, 40006, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40013, 40008, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40026, 40008, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40027, 40008, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40028, 40008, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40029, 40008, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40038, 40008, 4, 5, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
SELECT ModulTreeID = @ModulTreeID, 
       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
       ParentID    = TRE.ID,
       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
       Datum       = null,
       BaPersonID  = PRS.BaPersonID,
       LEI.FaLeistungID,
       LEI.FaProzessCode
FROM #Tree                 TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40040, 40008, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40020, 40009, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40031, 40009, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40032, 40009, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40033, 40009, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40034, 40009, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40041, 40009, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40050, 40009, 4, 5, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
SELECT ModulTreeID = @ModulTreeID, 
       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
       ParentID    = TRE.ID,
       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
       Datum       = null,
       BaPersonID  = PRS.BaPersonID,
       LEI.FaLeistungID,
       LEI.FaProzessCode
FROM #Tree                 TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40045, 40044, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40046, 40044, 4, 3, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40047, 40044, 4, 4, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40048, 40044, 4, 5, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40049, 40044, 4, 6, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40053, 40044, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40012, 41000, 4, 3, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40035, 41000, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.NameVorname, LEI.FaProzessCode
FROM   #Tree TRE
  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN vwPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
  AND EXISTS(SELECT * FROM IkRechtstitel WHERE FaLeistungID = LEI.FaLeistungID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40042, 41000, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, N'/*
INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, RechtstitelID)
SELECT @ModulTreeID, 
       TRE.ID + ''\BetreibungenVerlustscheine'', 
       TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, 
       LEI.FaFallID, 
       LEI.FaLeistungID, 
       RTT.IkRechtstitelID
FROM   #Tree TRE
  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkRechtstitel RTT ON RTT.FaLeistungID = LEI.FaLeistungID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
--  AND EXISTS(SELECT * FROM IkRechtstitel WHERE FaLeistungID = LEI.FaLeistungID)
*/', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41002, 41000, 4, 4, 1421, N'Rechtstitel und Gläubiger', N'CtlIkRechtstitel', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, Datum, RechtstitelID)
SELECT @ModulTreeID, TRE.ID + ''\Rechtstitel'' + convert(varchar,RTI.IkRechtstitelID ), 
       TRE.ID, LEI.FaFallID, LEI.FaLeistungID, RTI.IkRechtstitelGueltigVon,
       RTI.IkRechtstitelID
FROM   #Tree TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY RTI.IkRechtstitelGueltigVon desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41010, 41000, 4, 5, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode, Geburtsdatum)
SELECT DISTINCT 
       ModulTreeID = @ModulTreeID, 
       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar, GLA.IkGlaeubigerID), 
       ParentID    = TRE.ID,
       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'' + ISNULL('' - '' + dbo.fnIkGetBaPersonForderungTyp(GLA.IkGlaeubigerID), ''''), 
       Datum       = null,
       BaPersonID  = PRS.BaPersonID,
       LEI.FaLeistungID,
       LEI.FaProzessCode,
       PRS.Geburtsdatum
FROM #Tree                 TRE
  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
  INNER JOIN IkGlaeubiger  GLA ON GLA.IkRechtstitelID = RTI.IkRechtstitelID 
  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50001, 50000, 5, 1, 207, N'Bericht und Antrag Intake EKS', NULL, N'Vm_Massnahme_Intakebericht', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50002, 50000, 5, 3, 173, N'V-Massnahmen', NULL, N'Vm_Massnahme_BS', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50004, 50000, 5, 4, 167, N'Mandatsführung', NULL, N'Vm_Massnahme_MF', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50005, 50000, 5, 5, 164, N'Administration', NULL, N'Vm_Massnahme_MF_Verwaltung', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50006, 50000, 5, 6, 211, N'Finanzen', NULL, N'Vm_Massnahme_MF_Finanzen', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50007, 50000, 5, 7, 175, N'Typisierung', N'CtlVmBewertung', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50100, 50000, 5, 2, 5034, N'KES-Massnahmen', N'CtlKesMassnahme', NULL, NULL, 1, N'UPDATE #Tree
    Set Zusatz = NULL
  WHERE ModulTreeID = @ModulTreeID;', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50027, 50026, 5, 1, 175, N'Verlauf', N'CtlVmVaterschaftVerlauf', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50028, 50026, 5, 2, 180, N'Dokumente Vaterschaft', N'CtlFaDokumente', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50032, 50029, 5, 1, 131, N'Erblasserin', N'CtlVmErblasser', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50033, 50029, 5, 2, 198, N'Dokumentation', NULL, N'Vm_Erbschaft_Dok', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50034, 50029, 5, 3, 193, N'Siegelungsdienst', N'CtlVmSiegelung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, VmSiegelungID, BaPersonID, FaProzessCode, System, Zusatz)
  SELECT
    ModulTreeID   = CASE
                      WHEN dbo.fnUserMayReadFall(@UserID, SIG.FaLeistungID) = 0 THEN 1 
                      ELSE 50034
                    END,
    ID            = @ClassName + CONVERT(varchar, SIG.VmSiegelungID),
    ParentID      = TRE.ID,
    TRE.FaFallID, 
    SIG.FaLeistungID,
    SIG.VmSiegelungID,
    BaPersonID    = @BaPersonID,
    FaProzessCode = 531,
    System = convert(bit, 0), -- TODO!
    Zusatz = IsNull(CONVERT(varchar, BezirkNr) + ''-'', '''')  + IsNull(CONVERT(varchar, LaufNr) + ''-'', '''')  + IsNull(CONVERT(varchar, Jahr), '''') 
  FROM #Tree           TRE
    INNER JOIN VmSiegelung SIG ON SIG.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.BaPersonID = @BaPersonID AND 
        TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY SIG.Jahr DESC, SIG.SiegelungsDatum DESC, SIG.VmSiegelungID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50035, 50029, 5, 4, 19, N'Testamentsdienst', N'CtlVmTestament', NULL, NULL, 999, N'INSERT INTO #Tree ([ModulTreeID], [ID], [ParentID], [FaFallID], [FaLeistungID], [VmTestamentID], [BaPersonID], [FaProzessCode], [System], [Zusatz])
  SELECT [ModulTreeID]   = CASE
                             WHEN dbo.fnUserMayReadFall(@UserID, TST.FaLeistungID) = 0 THEN 1
                             ELSE 50035
                           END,
         [ID]            = @ClassName + CONVERT(VARCHAR, TST.VmTestamentID),
         [ParentID]      = TRE.ID,
         [FaFallID]      = TRE.FaFallID,
         [FaLeistungID]  = TST.FaLeistungID,
         [VmTestamentID] = TST.VmTestamentID,
         [BaPersonID]    = @BaPersonID,
         [FaProzessCode] = 532,
         [System]        = CONVERT(BIT, 0), -- TODO!
         [Zusatz]        = ISNULL(CONVERT(VARCHAR, LaufNr) + ''-'', '''') + ISNULL(CONVERT(VARCHAR, Jahr), '''')
  FROM #Tree               TRE
    INNER JOIN VmTestament TST ON TST.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.BaPersonID = @BaPersonID
    AND TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY TST.LaufNr, TST.VmTestamentID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50036, 50029, 5, 5, 172, N'Erbschaftsdienst', N'CtlVmErbschaftsdienst', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, VmErbschaftsdienstID, BaPersonID, FaProzessCode, System, Zusatz)
  SELECT
    ModulTreeID   = CASE
                      WHEN dbo.fnUserMayReadFall(@UserID, ERB.FaLeistungID) = 0 THEN 1 
                      ELSE 50036
                    END,
    ID            = @ClassName + CONVERT(varchar, ERB.VmErbschaftsdienstID),
    ParentID      = TRE.ID,
    TRE.FaFallID, 
    ERB.FaLeistungID,
    ERB.VmErbschaftsdienstID,
    BaPersonID    = @BaPersonID,
    FaProzessCode = 533,
    System = convert(bit, 0), -- TODO!
    Zusatz = IsNull(CONVERT(varchar, LaufNr) + ''-'', '''') + IsNull(CONVERT(varchar, Jahr), '''')
  FROM #Tree                      TRE
    INNER JOIN VmErbschaftsdienst ERB ON ERB.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.BaPersonID = @BaPersonID AND TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY ERB.Jahr, ERB.LaufNr, ERB.VmErbschaftsdienstID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50037, 50031, 5, 1, 209, N'Elternrecht/NSB/Platzierung', NULL, N'Vm_Auftrag_Elternrechte', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50038, 50031, 5, 2, 196, N'Gefährdungsmeldungen', N'CtlVmGefaehrdungsmeldung', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50039, 50031, 5, 3, 177, N'Adoption', NULL, N'Vm_Auftrag_Adoption', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60002, 60000, 6, 2, 190, N'Sonderunterbringung BFM', NULL, N'Ay_Unterkunft', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60003, 60000, 6, 3, 166, N'Abschlussarbeiten', NULL, N'Ay_Abschlussarbeiten', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60004, 60000, 6, 4, 173, N'Tagesstruktur / Billette', NULL, N'Ay_Tagesstruktur', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60100, 60000, 6, 1, 165, N'Finanzielle Unterstüzung', N'CtlAyPerioden', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BaPersonID)
  SELECT @ModulTreeID, ''UPE'' + CONVERT(varchar, TRE.FaLeistungID), TRE.ID,
    ''AyPeriodeUebersicht'', TRE.FaLeistungID, TRE.BaPersonID
  FROM #Tree   TRE
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent AND IconID <> 80', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70008, 70000, 7, 1, 163, N'Ausbildung', NULL, N'Ka_Ausbildung', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70009, 70000, 7, 2, 175, N'Verlauf', N'CtlKaVerlauf', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70010, 70000, 7, 3, 195, N'Korrespondenz', NULL, N'Ka_Allgemein_Korrespondenz', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70011, 70000, 7, 4, 189, N'Zuteilung Fachbereich', N'CtlKaZuteilFachbereich', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70013, 70000, 7, 5, 186, N'Präsenzverwaltung', N'CtlKaPraesenzAllgemein', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70014, 70000, 7, 6, 213, N'Bildung / Kurse', NULL, N'Ka_Allgemein_Bildung', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70017, 70001, 7, 1, 195, N'ZuweiserIn', N'CtlKaAKZuweiser', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70018, 70001, 7, 2, 200, N'Phasen', N'CtlKaAKPhasen', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70019, 70002, 7, 1, 193, N'Übersicht', N'CtlKaQJUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70020, 70002, 7, 2, 196, N'Intake', N'CtlKaQJIntake', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70021, 70002, 7, 3, 209, N'Prozess', N'CtlKaQJProzess', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70022, 70002, 7, 4, 83, N'Vereinbarung', N'CtlKaQJVereinbarung', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70023, 70002, 7, 5, 205, N'Extern', N'CtlKaQJExterneEinsaetze', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70024, 70002, 7, 6, 213, N'Bildung', N'CtlKaQJBildung', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70029, 70003, 7, 1, 174, N'Jobtimum', N'CtlKaQEJobtimum', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70030, 70003, 7, 2, 171, N'EPQ', N'CtlKaQEEPQ', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70039, 70004, 7, 1, 172, N'Übersicht', N'CtlKaVermittlungBIBIPUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70040, 70004, 7, 2, 171, N'Prozess', N'CtlKaVermittlungBIBIPProzess', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70041, 70004, 7, 3, 201, N'Vermittlungsprofil', N'CtlKaVermittlungBIBIPVermittlungsprofil', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70043, 70004, 7, 4, 193, N'Einsätze BIP', N'CtlKaVermittlungBIBIPEinsaetzeBIP', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70045, 70004, 7, 5, 164, N'Stellen BI', N'CtlKaVermittlungBIBIPStellenBI', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70035, 70005, 7, 1, 172, N'Übersicht', N'CtlKaVermittlungSIUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70036, 70005, 7, 2, 201, N'Vermittlungsprofil', N'CtlKaVermittlungSIVermittlungsprofil', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70038, 70005, 7, 3, 193, N'Einsätze', N'CtlKaVermittlungSIEinsaetze', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70032, 70006, 7, 1, 172, N'Übersicht', N'CtlKaInizioUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70033, 70006, 7, 2, 176, N'Vermittlungsprofil', N'CtlKaInizioVermittlungsprofil', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70034, 70006, 7, 3, 192, N'Einsätze', N'CtlKaInizioEinsaetze', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70031, 70007, 7, 1, 215, N'Prozess As', N'CtlKaAssistenz', NULL, NULL, 1, N'UPDATE #Tree
  Set DatVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70047, 70108, 7, 1, 171, N'Prozess', N'CtlKaTransferProzess', NULL, NULL, 1, N'UPDATE #Tree    Set DatVon = NULL  WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20004, 20003, 2, 1, 175, N'Besprechung', N'CtlFaAktennotiz', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20005, 20003, 2, 2, 83, N'Abmachungen', NULL, N'Fa_Dok_Abmachungen', NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20006, 20003, 2, 4, 195, N'Korrespondenz', N'CtlFaDokumente', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20018, 20003, 2, 3, 83, N'Weisung', N'CtlFaWeisung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20007, 21000, 2, 1, 21, N'Anmeldung', NULL, N'Fa_Intake_Anmeldung', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20008, 21000, 2, 2, 196, N'Ausstattung', NULL, N'Fa_Intake_Beratungsplan', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20009, 21000, 2, 3, 125, N'Zielvereinbarungen', NULL, N'Fa_Intake_Zielvereinbarungen', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20010, 21000, 2, 4, 101, N'Auswertung Prozess', NULL, N'Fa_Intake_AuswertungKlient', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20011, 21000, 2, 5, 164, N'Auswertung Ziele', NULL, N'Fa_Intake_AuswertungZiele', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20012, 21000, 2, 6, 177, N'Ressourcenerschliessung', NULL, N'Fa_Intake_KantonalesReporting', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20013, 22000, 2, 1, 196, N'Ausstattung', NULL, N'Fa_Beratung_Beratungsplan', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20014, 22000, 2, 2, 125, N'Zielvereinbarung', NULL, N'Fa_Beratung_Zielvereinbarungen', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20015, 22000, 2, 3, 101, N'Auswertung Prozess', NULL, N'Fa_Beratung_AuswertungKlient', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20016, 22000, 2, 4, 164, N'Auswertung Ziele', NULL, N'Fa_Beratung_AuswertungZiele', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20017, 22000, 2, 5, 177, N'Ressourcenerschliessung', NULL, N'Fa_Beratung_KantonalesReporting', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30111, 30100, 3, 1, 137, N'Personen im Haushalt', N'CtlWhPersonen', NULL, NULL, 1, N'UPDATE #Tree
  SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30112, 30100, 3, 2, 1318, N'Finanzplan', N'CtlBgUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30118, 30100, 3, 3, 1322, N'Masterbudget', N'CtlWhBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaLeistungID, BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode, Abgeschlossen)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    TRE.FaLeistungID, BBG.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode,
    Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
  FROM #Tree                 TRE
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = TRE.BgFinanzplanID AND SFP.BgBewilligungStatusCode >= 5
    INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
    INNER JOIN FaLeistung    LST ON LST.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30119, 30100, 3, 4, 1323, N'Monatsbudget', N'CtlWhBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaLeistungID, BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode, Name, Abgeschlossen)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    CASE BBG.BgBewilligungStatusCode
      WHEN 1  THEN 1323  -- Vorbereitung
      WHEN 5  THEN 1324  -- Bewilligt
      WHEN 9  THEN 1325  -- Gesperrt
    END,
    TRE.FaLeistungID, BBG.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode,
    ''Monatsbudget '' + dbo.fnXKurzMonat(BBG.Monat) + '' '' + CONVERT(varchar, BBG.Jahr),
    Abgeschlossen = CASE WHEN LST.DatumBis IS NULL THEN 0 ELSE 1 END
  FROM #Tree                 TRE
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = TRE.BgFinanzplanID AND SFP.BgBewilligungStatusCode >= 5
    INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 0
    INNER JOIN FaLeistung    LST ON LST.FaLeistungID = TRE.FaLeistungID
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY BBG.Jahr, BBG.Monat', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40018, 41002, 4, 1, 1417, N'Monatszahlen', N'CtlIkMonatszahlen', NULL, NULL, 1, N'UPDATE #Tree SET SchuldnerName = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50003, 50002, 5, 1, 135, N'Mandant', N'CtlVmMandant', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50008, 50002, 5, 2, 194, N'Massnahmen', N'CtlVmMassnahmen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50009, 50002, 5, 3, 196, N'Register, Kontrolle', N'CtlVmRevisionen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50010, 50002, 5, 4, 177, N'Inventar', N'CtlVmInventar', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50011, 50002, 5, 5, 129, N'Zustimmungen', NULL, N'Vm_Massnahme_BS_Zustimmungen', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50012, 50002, 5, 6, 207, N'Beschwerden / Anfragen', N'CtlVmBeschwerdeAnfrage', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50013, 50002, 5, 7, 198, N'Dokumentation', NULL, NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50014, 50004, 5, 1, 19, N'Berichte', N'CtlVmMandBericht', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50015, 50004, 5, 2, 163, N'Anträge EKSK (ZGB 421, 422)', N'CtlVmAntragEksk', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50016, 50004, 5, 3, 189, N'Situationsberichte SH', N'CtlVmSituationsbericht', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50017, 50005, 5, 1, 172, N'Sozialversicherungen', N'CtlVmSozialversicherung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50018, 50005, 5, 2, 171, N'EL Krankheitskosten', N'CtlVmELKrankheitskosten', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50019, 50005, 5, 3, 173, N'AHV Mindestbeiträge', N'CtlVmAHVMindestbeitraege', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50020, 50005, 5, 4, 205, N'Sachversicherungen', N'CtlVmSachversicherung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50022, 50005, 5, 6, 176, N'taxes', N'CtlVmSteuern', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50024, 50006, 5, 3, 179, N'Schulden', N'CtlVmSchulden', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50025, 50006, 5, 4, 189, N'Barauszahlungen', N'CtlVmBarauszahlungGeplant', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50059, 50006, 5, 2, 5033, N'Budget', N'Kiss.UI.View.Vm.VmKlientenbudgetView.xaml', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50041, 50033, 5, 1, 175, N'Besprechungen', N'CtlFaAktennotiz', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50042, 50033, 5, 2, 202, N'Abmachungen', NULL, N'Fa_Dok_Abmachungen', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50043, 50033, 5, 3, 195, N'Korrespondenz', N'CtlFaDokumente', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50044, 50034, 5, 1, 134, N'Erben', N'CtlVmErbe', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50045, 50035, 5, 1, 134, N'Erben', N'CtlVmErbe', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50046, 50035, 5, 2, 19, N'Bescheinigungen', N'CtlVmTestamentBescheinigung', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50047, 50035, 5, 3, 189, N'letztwillige Verfügung', N'CtlVmTestamentVerfuegung', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50048, 50036, 5, 1, 134, N'Erben', N'CtlVmErbe', NULL, NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50049, 50036, 5, 2, 205, N'Verfügungen', NULL, N'Vm_Erbschaft_Erbschaftsdienst_Verfügung', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50050, 50036, 5, 3, 19, N'EKSK', NULL, N'Vm_Erbschaft_AntraegeEKSK', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50051, 50036, 5, 4, 211, N'Arbeiten/Fristen', NULL, N'Vm_Erbschaft_Erbschaftsdienst_Arbeiten', NULL, 1, N'UPDATE #Tree
  Set Zusatz = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50052, 50039, 5, 1, 175, N'Besprechung', N'CtlFaAktennotiz', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50053, 50039, 5, 2, 202, N'Abmachungen', NULL, N'Vm_Auftrag_Adoption_Abmachungen', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50054, 50039, 5, 3, 195, N'Korrespondenz', N'CtlFaDokumente', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60005, 60004, 6, 1, 175, N'Ressourcen', NULL, N'Ay_Tagesstruktur_Ressourcen', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60006, 60004, 6, 2, 190, N'Beschäftigung / Kurse', NULL, N'Ay_Tagesstruktur_Beschaeftigung', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60001, 60100, 6, 1, 22, N'Ein-/Austritte', NULL, N'Ay_EinAustritt', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60110, 60100, 6, 2, 1628, N'Periode', N'CtlAyPeriode', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Typ, FaLeistungID, BaPersonID, BgBudgetID, RecordID, Name, DatumVon)
  SELECT @ModulTreeID, ''SFP'' + CONVERT(varchar, SFP.BgFinanzplanID), TRE.ID,
    CASE SFP.BgBewilligungStatusCode
      WHEN 1  THEN 1628  -- Vorbereitung
      WHEN 2  THEN 1628  -- Abgelehnt
      WHEN 3  THEN 1629  -- Angefragt
      WHEN 5  THEN 1630  -- Bewilligt
      WHEN 9  THEN 1631  -- Gesperrt
    END,
    ''AyPeriode'', TRE.FaLeistungID, TRE.BaPersonID, BBG.BgBudgetID, SFP.BgFinanzplanID,
    ''Periode'' + '' '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumVon, SFP.GeplantVon)) + IsNull('' - '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumBis, SFP.GeplantBis)), ''''),
    IsNull(SFP.DatumVon, SFP.GeplantVon)
  FROM #Tree                 TRE
    INNER JOIN BgFinanzplan  SFP ON SFP.FaLeistungID = TRE.FaLeistungID
    LEFT  JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY IsNull(SFP.DatumVon, SFP.GeplantVon) DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60120, 60100, 6, 3, 1638, N'Zahlungsmodus', N'CtlAyZahlungsmodus', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60131, 60100, 6, 4, 1639, N'Vorabzugskonti', N'CtlAySpezialkonto', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BaPersonID, RecordID)
  SELECT @ModulTreeID, TRE.ID + ''\SSK2'', TRE.ID,
    ''AySpezKonto'', TRE.FaLeistungID, TRE.BaPersonID, 2
  FROM #Tree   TRE
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60132, 60100, 6, 5, 1640, N'Abzahlungskonti', N'CtlAySpezialkonto', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BaPersonID, RecordID)
  SELECT @ModulTreeID, TRE.ID + ''\SSK3'', TRE.ID,
    ''AySpezKonto'', TRE.FaLeistungID, TRE.BaPersonID, 3
  FROM #Tree   TRE
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60133, 60100, 6, 6, 1641, N'Ausgabekonti', N'CtlAySpezialkonto', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BaPersonID, RecordID)
  SELECT @ModulTreeID, TRE.ID + ''\SSK1'', TRE.ID,
    ''AySpezKonto'', TRE.FaLeistungID, TRE.BaPersonID, 1
  FROM #Tree   TRE
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70012, 70011, 7, 1, 184, N'Zu- / Anweisungen', N'CtlKaAnweisung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70015, 70014, 7, 1, 207, N'interne Bildung', N'CtlKaIntegBildung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70016, 70014, 7, 2, 188, N'externe Bildung', N'CtlKaExterneBildung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70025, 70021, 7, 1, 203, N'Assessment', N'CtlKaQJPZAssessment', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70026, 70021, 7, 2, 125, N'Zielvereinbarung', N'CtlKaQJPZZielvereinbarung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70027, 70021, 7, 3, 204, N'Zwischenbericht', NULL, N'Ka_QualifizierungJ_Prozess_Zwischenbericht', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70028, 70021, 7, 4, 206, N'Schlussbericht', N'CtlKaQJPZSchlussbericht', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (70037, 70023, 7, 1, 201, N'Vermittlungsprofil', N'CtlKaQJExternVermittlungsprofil', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30001, 30112, 3, 4, 1319, N'Vermögen und Vermögensverbrauch', N'CtlBgVermoegen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30002, 30112, 3, 5, 1320, N'Grundbedarf', N'CtlBgGrundbedarf', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30003, 30112, 3, 6, 1320, N'Wohnkosten', N'CtlBgWohnkosten', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30004, 30112, 3, 7, 1320, N'Med. Grundversorgung', N'CtlBgKrankenkasse', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30005, 30112, 3, 8, 1320, N'Zulagen / EFB', N'CtlBgZulagenEFB', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30006, 30112, 3, 9, 126, N'Situationsbedingte Leistungen', NULL, NULL, NULL, 1, N'UPDATE #Tree
  Set ID = ParentID + ''/SIL''
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30113, 30112, 3, 1, 1319, N'Erwerbseinkommen', N'CtlBgErwerbseinkommen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30114, 30112, 3, 2, 1319, N'Alimentenguthaben', N'CtlBgAlimente', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30115, 30112, 3, 3, 1319, N'Einkommen aus Versicherungsleistungen', N'CtlBgVersicherung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30007, 30006, 3, 1, 1320, N'AHV Beiträge', N'CtlBgSilAHVBeitrag', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30008, 30006, 3, 2, 1320, N'Wiedereingliederung', N'CtlBgSilWiedereingliederung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30009, 30006, 3, 3, 1320, N'Kosten von Therapie und Entzugsmassnahmen', N'CtlBgSilTherapieEntzug', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30010, 30006, 3, 4, 1320, N'Krankheits- und behinderungsbedingte Leistungen', N'CtlBgSilKrankheitBehinderungLeistung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30011, 30006, 3, 5, 1320, N'Situationsbedingte Leistungen', N'CtlBgSilSituationsbedingteLeistungen', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50040, 50013, 5, 1, 175, N'Besprechungen', N'CtlFaAktennotiz', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50055, 50013, 5, 2, 202, N'Abmachungen', NULL, N'Vm_Massnahme_BS_Dok_Abmachungen', NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50056, 50013, 5, 3, 195, N'Korrespondenz', N'CtlFaDokumente', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50057, 50025, 5, 1, 189, N'geplant', N'CtlVmBarauszahlungGeplant', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50058, 50025, 5, 2, 189, N'erfolgt', N'CtlVmBarauszahlungErfolgt', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50023, 50059, 5, 1, 195, N'Budget (alt)', N'CtlVmBudget', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60111, 60110, 6, 1, 137, N'Personen im Haushalt', N'CtlAyPersonen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BaPersonID, RecordID)
  SELECT @ModulTreeID, TRE.ID + ''\PRS'', TRE.ID,
    ''AyPersonen'', TRE.FaLeistungID, TRE.BaPersonID, TRE.RecordID
  FROM #Tree   TRE
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60118, 60110, 6, 2, 1634, N'Masterbudget', N'CtlAyBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Typ, FaLeistungID, BgBudgetID, RecordID)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    ''AyBudget_Masterbudget'', TRE.FaLeistungID, BBG.BgBudgetID, BBG.BgFinanzplanID
  FROM #Tree                 TRE
    INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = TRE.RecordID AND BBG.MasterBudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60119, 60110, 6, 3, 1635, N'Monatsbudget', N'CtlAyBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Typ, FaLeistungID, BgBudgetID, RecordID, Name)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    CASE BBG.BgBewilligungStatusCode
      WHEN 1  THEN 1635  -- Vorbereitung
      WHEN 5  THEN 1636  -- Bewilligt
      WHEN 9  THEN 1637  -- Gesperrt
    END,
    ''AyBudget_Monatsbudget'', TRE.FaLeistungID, BBG.BgBudgetID, BBG.BgFinanzplanID,
    dbo.fnXKurzMonat(BBG.Monat) + '' '' + CONVERT(varchar, BBG.Jahr)
  FROM #Tree                 TRE
    INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = TRE.RecordID AND SFP.BgBewilligungStatusCode >= 5
    INNER JOIN BgBudget      BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 0
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY BBG.Jahr DESC, BBG.Monat DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (60116, 60111, 6, 1, 1632, N'Person', N'CtlAyPerson', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Typ, FaLeistungID, BgBudgetID, BaPersonID, RecordID, Name, DatumVon)
  SELECT @ModulTreeID, TRE.ID + CONVERT(varchar, SPP.BaPersonID), TRE.ID,
    IconID = CASE WHEN SPP.IstUnterstuetzt = 1 THEN 1632 ELSE 1633 END,
    ''AyPerson'', TRE.FaLeistungID, TRE.BgBudgetID, SPP.BaPersonID, TRE.RecordID,
    PRS.Name + IsNull('', '' + PRS.Vorname, '''') + IsNull('' ('' + CAST(dbo.fnGetAge(PRS.Geburtsdatum, TRE.DatumVon) AS varchar) + '')'', ''''),
    PRS.Geburtsdatum
  FROM #Tree                           TRE
    INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = TRE.RecordID
    INNER JOIN BaPerson               PRS ON PRS.BaPersonID    = SPP.BaPersonID
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
GO
COMMIT
GO