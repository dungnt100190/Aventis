SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XModulTree]
GO
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10000, NULL, 1, 1, 134, N'Übersicht', N'CtlBaUebersicht', NULL, NULL, 1, N'-- immer genau 1 Eintrag
-- FaFallID aus dem aktuellsten Fall (egal ob offen, geschlossen oder archiviert)

-- sozheo: Wird gelöst wie bei inv. Inst. und Personen
/*
INSERT INTO #Tree (ModulTreeID, ID, ParentID, BaPersonID, FaFallID)
  SELECT top 1 
    @ModulTreeID, 
    IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), 
    NULL, 
    @BaPersonID, 
    (SELECT top 1 FaFallID FROM dbo.FaFall WITH (READUNCOMMITTED) 
     WHERE BaPersonID=@BaPersonID
     ORDER BY DatumVon desc)
*/', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10002, NULL, 1, 3, 190, N'Wohnsituation', N'CtlBaWohnsituation', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10004, NULL, 1, 4, 209, N'Involvierte Personen', N'CtlBaInvolviertePerson', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10005, NULL, 1, 2, 100, N'Klientensystem', N'CtlBaKlientensystem', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (12000, NULL, 1, 7, 2111, N'Involvierte Stellen', N'CtlBaInvolvierteStelle', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20000, NULL, 2, 1, 193, N'Sozialsystem', N'CtlSozialsystemContainer', NULL, N'ALTER TABLE #Tree ADD
  Aufnahme        datetime,
  SARName         varchar(100),
  ModulID         int,
  Vertraulich bit,
  IstAlimentenstelle bit default(0),
  SubKnotenID int', 999, N'DECLARE @tmpFallID INT
SELECT TOP 1 @tmpFallID = F.FaFallID FROM dbo.FaFall F WITH (READUNCOMMITTED)
WHERE F.baPersonID=@BaPersonID
ORDER BY CASE WHEN F.DatumBis IS NULL THEN 0 ELSE 1 END, F.DatumVon DESC

INSERT INTO #Tree 
  (ModulTreeID, ID, IconID, BaPersonID, FaFallID)
VALUES
  (@ModulTreeID, ''S'', @IconID, @BaPersonID, IsNull(@FaFallID, @tmpFallID))

--INSERT INTO #Tree (ModulTreeID, ID) VALUES (@ModulTreeID, ''S'')', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20002, NULL, 2, 3, 1201, N'Fallführung', N'CtlFaLeistung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, Name, Aufnahme, IstAlimentenstelle)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID,
    @Name,
    FLE.DatumVon,
    0
  FROM dbo.FaFall                    FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
    LEFT  JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FAL.FaFallID = IsNull(@FaFallID, FAL.FaFallID) AND
        FLE.ModulID = @ModulID AND
        FLE.FaProzessCode = 200
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20024, NULL, 2, 2, 1428, N'Fallverlaufsprotokoll', N'CtlFaFallverlaufsprotokoll', NULL, NULL, 999, N'DECLARE @tmpFallID INT
SELECT TOP 1 @tmpFallID = F.FaFallID FROM dbo.FaFall F WITH (READUNCOMMITTED)
WHERE F.baPersonID=@BaPersonID
ORDER BY CASE WHEN F.DatumBis IS NULL THEN 0 ELSE 1 END, F.DatumVon DESC

INSERT INTO #Tree (ModulTreeID, ID, IconID, BaPersonID, FaFallID)
  SELECT
    ModulTreeID = @ModulTreeID,
    ID          = IsNull(@ClassName, ''Fallverlauf''),
    IconID      = @IconID,
    BaPersonID  = @BaPersonID,
    FaFallID    = IsNull(@FaFallID, @tmpFallID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20025, NULL, 2, 4, 1230, N'Fallführung Alimentenstelle', N'CtlFaLeistung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, Name, Aufnahme, IstAlimentenstelle)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID,
    @Name,
    FLE.DatumVon,
    1
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND 
        FLE.ModulID = @ModulID AND
        FLE.FaProzessCode = 201
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30000, NULL, 3, 4, 1301, N'Wirtschaftliche Hilfe', N'CtlWhLeistung', NULL, N'ALTER TABLE #Tree ADD
  DatumVon                 datetime,
  LeistungGeschlossen      bit,
  BgFinanzplanID           int,
  BgBudgetID               int,
  MasterBudget             bit,
  BgBewilligungStatusCode  int,
  BgSpezkontoTypCode       int,
  Typ             varchar(100),
  RecordID        int,
  BgGruppeCode    int', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, Name, DatumVon, LeistungGeschlossen)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID      = CASE
                    WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0               THEN 80
                    -- aktuellster Finanzplan mit Berechn.Grundlage: 120 - GBL stat.Aufenthalt -> blaues Icon
                    WHEN FPL.WhGrundbedarfTypCode = 32019 AND ARC.FaLeistungID IS NOT NULL  THEN @IconID + 4 + 2 -- Archiviert
                    WHEN FPL.WhGrundbedarfTypCode = 32019 AND FLE.DatumBis IS NOT NULL      THEN @IconID + 4 + 1 -- Archiviert
                    WHEN FPL.WhGrundbedarfTypCode = 32019                                   THEN @IconID + 4 
                    -- "normaler" Finanzplan 
                    WHEN ARC.FaLeistungID IS NOT NULL                                       THEN @IconID + 2  -- Archiviert
                    WHEN FLE.DatumBis IS NOT NULL                                           THEN @IconID + 1  -- Abgeschlossen
                    ELSE @IconID
                  END,
    FAL.FaFallID, 
    FLE.FaLeistungID, 
    BaPersonID  = @BaPersonID,
    Name        = ''WH '' +  PRS.DisplayText, 
    FLE.DatumVon,
    LeistungGeschlossen = CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM dbo.FaFall                    FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
    OUTER APPLY ( SELECT TOP 1 WhGrundbedarfTypCode 
                  FROM BgFinanzplan FPL 
                  WHERE FPL.FaLeistungID = FLE.FaLeistungID 
                  ORDER BY IsNull(FPL.DatumVon, FPL.GeplantVon) DESC, FPL.BgFinanzplanID DESC  ) FPL
    LEFT  JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
    INNER JOIN dbo.vwPersonSimple    PRS ON PRS.BaPersonID = FLE.BaPersonID
  WHERE FAL.BaPersonID = @BaPersonID AND FAL.FaFallID = IsNull(@FaFallID, FAL.FaFallID) AND FLE.ModulID = @ModulID
    AND FLE.FaProzessCode = 300
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30003, NULL, 3, 5, 1301, N'Inkasso Rückerstattung', N'CtlIkLeistungAlbv', NULL, N'ALTER TABLE #Tree ADD    FaProzessCode int', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, 
  Name, DatumVon, FaProzessCode, LeistungGeschlossen)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, 
    @Name,
    FLE.DatumVon,
    FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 302
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30004, NULL, 3, 6, 1301, N'Verwandtenunterstützung', N'CtlIkLeistungAlbv', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, 
  Name, DatumVon, FaProzessCode, LeistungGeschlossen)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, 
    @Name,
    FLE.DatumVon,
    FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 301
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30022, NULL, 3, 7, 1301, N'Unterhaltsbeiträge + KiZu', N'CtlIkLeistungAlbv', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, 
  Name, DatumVon, FaProzessCode, LeistungGeschlossen)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, 
    @Name,
    FLE.DatumVon,
    FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 304
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30059, NULL, 3, 1, 2121, N'Kontoauszug', N'CtlWhKontoauszug', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30060, NULL, 3, 2, 1422, N'Klientenkontoabrechnung', N'CtlWhKlientenKontoabrechnung', NULL, NULL, 1, N'UPDATE #Tree
  SET FaFallID = (SELECT TOP 1 FaFallID FROM dbo.FaFall WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID ORDER BY CASE WHEN DatumBis IS NULL THEN 0 ELSE 1 END, DatumVon DESC)
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30064, NULL, 3, 3, 164, N'WV Einheiten', N'CtlWhWVEinheit', NULL, NULL, 1, N'UPDATE #Tree
  SET FaFallID = (SELECT TOP 1 FaFallID FROM dbo.FaFall WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID ORDER BY CASE WHEN DatumBis IS NULL THEN 0 ELSE 1 END, DatumVon DESC)
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40000, NULL, 4, 6, 1401, N'Rückforderung ALBV', N'CtlIkLeistungAlbv', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, 
  BaPersonID, Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 408
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40002, NULL, 4, 10, 1401, N'Rückforderung KKBB', N'CtlIkLeistungAlbv', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, 
  BaPersonID, Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END)
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 410
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40003, NULL, 4, 7, 1401, N'Rückforderung ÜbH', N'CtlIkLeistungAlbv', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, 
  BaPersonID, Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 409
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40004, NULL, 4, 5, 1401, N'Anspruchsberechnung ALBV+ÜbH', N'CtlIkLeistungUebhKkbb', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, 
  FaFallID, FaLeistungID, BaPersonID, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, FLE.BaPersonID, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END)
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 402
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40005, NULL, 4, 4, 1401, N'Überbrückungshilfe ÜbH', N'CtlIkLeistungUebhKkbb', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, 
  BaPersonID, Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 406
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40006, NULL, 4, 9, 1401, N'Anspruchsberechnung KKBB', N'CtlIkLeistungUebhKkbb', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, 
  FaFallID, FaLeistungID, BaPersonID, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, FLE.BaPersonID, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END)
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 404
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40017, NULL, 4, 8, 1401, N'KKBB', N'CtlIkLeistungUebhKkbb', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, 
  BaPersonID, Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 407
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41000, NULL, 4, 3, 1401, N'Alimenteninkasso ALBV+ALV', N'CtlIkLeistungAlbv', NULL, N'Alter table #Tree add 
  Datum datetime,
  RechtstitelID int,
  Geburtsdatum datetime,
  ProzessCode int,
  LeistungGeschlossen bit', 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID, 
  Datum, ProzessCode, LeistungGeschlossen
)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, @BaPersonID, FLE.DatumVon, FLE.FaProzessCode,
    CONVERT(BIT, CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END) 
  FROM FaFall                FAL
    INNER JOIN FaLeistung    FLE ON FLE.FaFallID = FAL.FaFallID AND
                                    FLE.FaProzessCode = 405
    LEFT  JOIN FaLeistungArchiv ARC ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41014, NULL, 4, 11, 2117, N'Kontoauszug', N'CtlIkKontoauszug', NULL, NULL, 999, N'--IF EXISTS (
--  SELECT 1 FROM FaLeistung 
--  WHERE BaPersonID = @BaPersonID 
--  AND FaProzessCode in (405,406,407,408,409,410)
--)
INSERT INTO #Tree (ModulTreeID, ID, BaPersonID, FaFallID, ProzessCode)
SELECT TOP 1 @ModulTreeID, ''Kontoauszug'', @BaPersonID, F.FaFallID, 499
FROM FaLeistung L 
LEFT JOIN FaFall F ON F.FaFallID = L.FaFallID
WHERE F.BaPersonID = @BaPersonID
  AND L.FaProzessCode in (405,406,407,408,409,410)

-- VALUES (@ModulTreeID, ''Kontoauszug'', @BaPersonID, @FaFallID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50006, NULL, 5, 2, 1501, N'Verwaltung Klientengelder', N'CtlKgLeistung', NULL, N'ALTER TABLE #Tree ADD
  KgBudgetID int, 
  KgMasterBudgetID int, 
  KgBewilligungCode int,
  Monat int,
  Jahr int,
  BewilligtVon datetime,
  BewilligtBis datetime,
  FallBaPersonID int', 999, N'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaFallID, FaLeistungID, BaPersonID,Name, FallBaPersonID)
  SELECT
    ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,
    ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID),
    IconID = CASE
      WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80
      WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert
      WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen
      ELSE @IconID
    END,
    FAL.FaFallID, FLE.FaLeistungID, FLE.BaPersonID,
    Name = CASE FLE.EroeffnungsGrundCode
           WHEN 50001 THEN ''VM: ''
           WHEN 50002 THEN ''Verm.: ''
           ELSE ''''
           END + ''Verw. Kl.gelder - '' + PRS.NameVorname,
    @BaPersonID
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaLeistung    FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
    INNER JOIN dbo.vwPerson      PRS ON PRS.BaPersonID = FLE.BaPersonID
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FAL.BaPersonID = @BaPersonID AND FLE.ModulID = @ModulCode
  ORDER BY
    CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (10001, 10005, 1, 2, 2125, N'Inaktive Person', N'CtlBaPerson', NULL, NULL, 999, N'-- alle Personen aus allen Klientensystemen von bereits geschlossenen Fällen, in welchen @BaPerson Fallträger ist
-- oder Personen, deren Mitgliedschaft abgelaufen ist 
-- ausser Personen, die bereits unter "aktive Person" eingetragen sind
-- keine Person darf doppelt erscheinen 

INSERT INTO #Tree (ModulTreeID, ID, ParentID, BaPersonID, Name, IsFallTraeger, Unterstuetzt, Age, AgeDisplay, Hinweis, Aktiv)
  SELECT DISTINCT
    @ModulTreeID,
    ''P'' + CONVERT(varchar, PRS.BaPersonID),
    ''CtlBaKlientensystem'',
    PRS.BaPersonID,
    PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
    IsFallTraeger = CASE WHEN PRS.BaPersonID = @BaPersonID THEN 1 ELSE 0 END,
    IsNull(dbo.fnUnterstuetzt(@BaPersonID, PRS.BaPersonID, GetDate()), 0),
    Age = dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(), PRS.SterbeDatum),
    AgeDisplay = CASE WHEN PRS.SterbeDatum IS NULL THEN CAST( dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(), NULL) AS varchar) END,
    Hinweis = case when PRS.WichtigerHinweisCode is not null then ''!'' end,
    Aktiv = 0
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaFallPerson  FAP WITH (READUNCOMMITTED) on FAP.FaFallID = FAL.FaFallID
    INNER JOIN dbo.BaPerson      PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = FAP.BaPersonID
  WHERE 
    FAL.BaPersonID = @BaPersonID AND
    (FAL.DatumBis IS NOT NULL OR IsNull(@FaFallID, FAL.FaFallID) <> FAL.FaFallID OR
     GetDate() < isnull(FAP.DatumVon, GetDate()) OR
     GetDate() > isnull(FAP.DatumBis, GetDate())) AND
    NOT EXISTS (SELECT 1 FROM #Tree WHERE ID = ''P'' + CONVERT(varchar, PRS.BaPersonID))
  ORDER BY IsFallTraeger desc, Age desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (11000, 10005, 1, 1, 133, N'Aktive Person', N'CtlBaPerson', NULL, N'ALTER TABLE #Tree ADD
  Unterstuetzt  bit,
  Age           int,
  AgeDisplay    varchar(10),
  IsFallTraeger bit,
  Hinweis       varchar(1),
  FaFallID_B    int,
  Aktiv         bit', 999, N'-- alle Personen des Klientensystems aus dem aktuellen, offenen Fall, in welchem @BaPerson Fallträger ist
-- Die Mitgliedschaft darf nicht abgelaufen sein (DatumVon-DatumBis)

INSERT INTO #Tree (ModulTreeID, ID, ParentID, BaPersonID, Name, IsFallTraeger, Unterstuetzt, Age, AgeDisplay, Hinweis, FaFallID_B, Aktiv)
  SELECT DISTINCT
    @ModulTreeID,
    ''P'' + CONVERT(varchar, PRS.BaPersonID),
    ''CtlBaKlientensystem'',
    PRS.BaPersonID,
    PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
    IsFallTraeger = CASE WHEN PRS.BaPersonID = @BaPersonID THEN 1 ELSE 0 END,
    isNull(dbo.fnUnterstuetzt(@BaPersonID, PRS.BaPersonID, GetDate()), 0),
    Age = dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(), PRS.SterbeDatum),
    AgeDisplay = CASE WHEN PRS.SterbeDatum IS NULL THEN CAST( dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(), NULL) AS varchar) END,
    Hinweis = case when PRS.WichtigerHinweisCode is not null then ''!'' end,
    FaFallID_B = (SELECT CASE WHEN MIN(FaFallID) = MAX(FaFallID) THEN MIN(FaFallID) ELSE NULL END
                  FROM dbo.FaFall WITH (READUNCOMMITTED)
                  WHERE BaPersonID = FAL.BaPersonID AND DatumBis IS NULL),
    Aktiv = 1
  FROM dbo.FaFall                FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.FaFallPerson  FAP WITH (READUNCOMMITTED) on FAP.FaFallID = FAL.FaFallID
    INNER JOIN dbo.BaPerson      PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = FAP.BaPersonID
  WHERE FAL.FaFallID = IsNull(@FaFallID, FAL.FaFallID)
    AND FAL.BaPersonID = @BaPersonID
    AND FAL.DatumBis IS NULL
    AND GetDate() between isnull(FAP.DatumVon,GetDate()) and isnull(FAP.DatumBis,GetDate())
  ORDER BY IsFallTraeger desc, Age desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20001, 20000, 2, 1, 0, N'Fälle', N'CtlFaSozialSystem', NULL, NULL, 999, N'DECLARE @Person TABLE (BaPersonID int PRIMARY KEY)

INSERT INTO @Person VALUES (@BaPersonID)

WHILE @@rowcount > 0 BEGIN
  INSERT @Person
    SELECT DISTINCT PRE.BaPersonID_1
    FROM @Person P
      INNER JOIN dbo.BaPerson           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID AND IsNull(PRS.Fiktiv, 0) = 0
      INNER JOIN dbo.BaPerson_Relation  PRE WITH (READUNCOMMITTED) ON PRE.BaPersonID_2 = P.BaPersonID
    WHERE NOT EXISTS (SELECT 1 FROM @Person WHERE BaPersonID = PRE.BaPersonID_1)
    UNION
    SELECT DISTINCT PRE.BaPersonID_2
    FROM @Person P
      INNER JOIN dbo.BaPerson           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID AND IsNull(PRS.Fiktiv, 0) = 0
      INNER JOIN dbo.BaPerson_Relation  PRE WITH (READUNCOMMITTED) ON PRE.BaPersonID_1 = P.BaPersonID
    WHERE NOT EXISTS (SELECT 1 FROM @Person WHERE BaPersonID = PRE.BaPersonID_2)
END

INSERT INTO #Tree (ModulTreeID, ID, ParentID, Name, Aufnahme, SARName, FaFallID, FaLeistungID, ModulID, IconID)
  SELECT DISTINCT
    @ModulTreeID,
    ''F'' + CONVERT(varchar, LST.FaLeistungID),
    ''S'',
    PRS.Name + IsNull('', '' + PRS.Vorname,''''),
    FAL.DatumVon,
    USR.LastName + IsNull('', '' + USR.FirstName,''''),
    FAL.FaFallID,
    LST.FaLeistungID,
    LST.ModulID,
    IconID = 100 * LST.ModulID + 1000 + CASE
      WHEN ARC.FaLeistungID IS NOT NULL  THEN 3  -- Archiviert
      WHEN FAL.DatumBis IS NOT NULL  THEN 2  -- Abgeschlossen
      ELSE 1
    END
  FROM @Person P
    INNER JOIN dbo.FaFall           FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = P.BaPersonID
    INNER JOIN dbo.FaLeistung       LST WITH (READUNCOMMITTED) ON LST.FaFallID = FAL.FaFallID
    LEFT  JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LST.FaLeistungID AND ARC.CheckOut IS NULL
    INNER JOIN dbo.BaPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = P.BaPersonID
    LEFT  JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.Us', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20003, 20002, 2, 13, 217, N'Aufnahmeprozess', N'CtlFaAufnahmeprozess', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID
  FROM   #Tree TRE
  LEFT OUTER JOIN dbo.FaLeistung F WITH (READUNCOMMITTED) on F.FaLeistungID=TRE.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent AND
         F.FaProzessCode=200 AND
         (EXISTS (SELECT 1 FROM dbo.FaVoranmeldung WITH (READUNCOMMITTED) WHERE FaLeistungID = TRE.FaLeistungID) OR
          EXISTS (SELECT 1 FROM dbo.FaCheckin WITH (READUNCOMMITTED)      WHERE FaLeistungID = TRE.FaLeistungID) OR
          EXISTS (SELECT 1 FROM dbo.FaAssessment WITH (READUNCOMMITTED)   WHERE FaLeistungID = TRE.FaLeistungID))', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20017, 20002, 2, 14, 1241, N'Vormundsch. Mandat', N'CtlVISMandat', NULL, N'ALTER TABLE #Tree ADD    
AktiveLeistung bit', 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, FaFallID, FaLeistungID, BaPersonID, Aufnahme, AktiveLeistung)   
SELECT      
	ModulTreeID = CASE WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 1 ELSE @ModulTreeID END,      
	ID          = IsNull(@ClassName, '''') + CONVERT(varchar, FLE.FaLeistungID) + ISNULL(CONVERT(varchar, MAS.VIS_VormschID), ''''),      
	ParentID    = TRE.ID,      
	IconID		= CASE        
					WHEN dbo.fnUserMayReadFall(@UserID, FLE.FaLeistungID) = 0 THEN 80        
					WHEN ARC.FaLeistungID IS NOT NULL  THEN @IconID + 2  -- Archiviert        
					WHEN FLE.DatumBis IS NOT NULL  THEN @IconID + 1  -- Abgeschlossen        
					ELSE @IconID		
				END,      
	Name        = PRS.Name + isnull('', '' + PRS.Vorname,''''),      
	TRE.FaFallID,       
	FLE.FaLeistungID,      
	FLE.BaPersonID,      
	ISNULL(MAS.DatumVon, FLE.DatumVon),
        AktiveLeistung = CONVERT(bit, CASE WHEN ARC.FaLeistungID IS NOT NULL OR FLE.DatumBis IS NOT NULL THEN 0 ELSE 1 END)
FROM #Tree                     TRE      
INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = TRE.FaFallID AND FLE.FaProzessCode = 210      
LEFT  JOIN dbo.VmMassnahme		 MAS WITH (READUNCOMMITTED) ON MAS.FaLeistungID = FLE.FaLeistungID
LEFT  JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL      
INNER JOIN dbo.BaPerson          PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FLE.BaPersonID    
WHERE TRE.ModulTreeID = @ModulTreeID_Parent    
ORDER BY CASE WHEN FLE.DatumBis IS NULL THEN 0 ELSE 1 END, PRS.Name + isnull('', '' + PRS.Vorname,'''') + IsNull('' - '' + MAS.ZGB, ''''), FLE.DatumVon DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (22000, 20002, 2, 12, 190, N'Lösungsprozess', N'CtlFaLoesungsprozess', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID
  FROM   #Tree TRE
  LEFT OUTER JOIN dbo.FaLeistung F WITH (READUNCOMMITTED) on F.FaLeistungID=TRE.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent AND
         F.FaProzessCode=200 AND
         (EXISTS (SELECT 1 FROM dbo.FaRessourcenpaket WITH (READUNCOMMITTED)  WHERE FaLeistungID = TRE.FaLeistungID) OR
          EXISTS (SELECT 1 FROM dbo.FaZielvereinbarung WITH (READUNCOMMITTED) WHERE FaLeistungID = TRE.FaLeistungID) OR
          EXISTS (SELECT 1 FROM dbo.FaAbklaerung WITH (READUNCOMMITTED)       WHERE FaLeistungID = TRE.FaLeistungID))', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (25000, 20002, 2, 10, 180, N'Dokumentation', NULL, N'Fa_Dok', NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''_1'', Aufnahme = NULL, SARName = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20027, 20025, 2, 1, 175, N'Aktennotizen', N'CtlFaAktennotizen', NULL, NULL, 1, N'UPDATE #Tree 
SET Vertraulich = 0, 
    IstAlimentenstelle = 1,
    Aufnahme = NULL, 
    SARName = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20030, 20025, 2, 3, 203, N'Unterlagenliste', N'CtlFaUnterlagenliste', NULL, NULL, 1, N'UPDATE #Tree 
SET Aufnahme = NULL, 
    IstAlimentenstelle = 1,
    SARName = NULL 
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20031, 20025, 2, 2, 195, N'Dokumente', N'CtlFaDokumente', NULL, NULL, 1, N'UPDATE #Tree 
SET Vertraulich = 0, 
    IstAlimentenstelle = 1,
    Aufnahme = NULL, 
    SARName = NULL 
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20036, 20025, 2, 4, 178, N'Check-in Aliment', N'CtlFaCheckinAlim', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, Aufnahme)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID,
         Aufnahme = CIN.ErstkontaktDatum
  FROM   #Tree TRE
         INNER JOIN dbo.FaCheckinAlim CIN WITH (READUNCOMMITTED) ON CIN.FaLeistungID = TRE.FaLeistungID
         LEFT JOIN dbo.FaLeistung L WITH (READUNCOMMITTED) ON L.FaLeistungID = CIN.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30001, 30000, 3, 2, 1312, N'Reguläre Wirtschaftliche Hilfe', N'CtlWhFinanzplan', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BgFinanzplanID, BgBewilligungStatusCode, BaPersonID, BgBudgetID, Name, DatumVon, LeistungGeschlossen)
  SELECT CASE SFP.WhHilfeTypCode
      WHEN 1  THEN 30002   -- Notfallzahlung
      ELSE 30001
    END, IsNull(@ClassName, '''') + CONVERT(varchar, SFP.BgFinanzPlanID), TRE.ID,
    CASE WHEN IsNull(SFP.DatumBis, SFP.GeplantBis) < GetDate() THEN 1315  -- abgelaufene Reg. WH immer mit rotem (gesperrtem) Icon
      ELSE CASE SFP.BgBewilligungStatusCode
        WHEN 1  THEN 1312  -- Vorbereitung
        WHEN 2  THEN 1312  -- Abgelehnt
        WHEN 3  THEN 1313  -- Angefragt
        WHEN 5  THEN 1314  -- Bewilligt
        WHEN 9  THEN 1315  -- Gesperrt
      END
    END,
    TRE.FaFallID, TRE.FaLeistungID, SFP.BgFinanzplanID, SFP.BgBewilligungStatusCode, TRE.BaPersonID, BBG.BgBudgetID,
    CASE SFP.WhHilfeTypCode
      WHEN 1  THEN TYP.Text
      ELSE TYP.Text + '': '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumVon, SFP.GeplantVon)) + IsNull('' - '' + dbo.fnXKurzMonatJahr(IsNull(SFP.DatumBis, SFP.GeplantBis)), '''')
    END,
    IsNull(SFP.DatumVon, SFP.GeplantVon),
    CONVERT(BIT, CASE WHEN IsNull(SFP.DatumBis, SFP.GeplantBis) < GetDate() THEN 1 ELSE 0 END) 
  FROM #Tree                 TRE
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.FaLeistungID = TRE.FaLeistungID
    LEFT  JOIN dbo.XLOVCode      TYP WITH (READUNCOMMITTED) ON TYP.LOVName = ''WhHilfeTyp'' AND TYP.Code = SFP.WhHilfeTypCode
    LEFT  JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzPlanID = SFP.BgFinanzPlanID AND BBG.Masterbudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY IsNull(SFP.DatumVon, SFP.GeplantVon) DESC, SFP.BgFinanzplanID DESC', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30002, 30000, 3, 4, 1312, N'Notfallzahlung', N'CtlWhFinanzplan', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30071, 30000, 3, 8, 1416, N'SEK-Entscheid', N'CtlWhVerfuegungen', NULL, NULL, 1, N'UPDATE #Tree
  Set DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30110, 30000, 3, 3, 1312, N'Überbrückungshilfe', N'CtlWhFinanzplan', NULL, NULL, 999, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30131, 30000, 3, 7, 1327, N'Vorabzugskonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''2'', 
      BgSpezkontoTypCode = 2,
      DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30132, 30000, 3, 6, 1328, N'Verrechnungskonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''3'', 
      BgSpezkontoTypCode = 3,
      DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30133, 30000, 3, 5, 1329, N'Ausgabekonti', N'CtlWhSpezialkonto', NULL, NULL, 1, N'UPDATE #Tree
  SET ID = ID + ''1'', 
      BgSpezkontoTypCode = 1,
      DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30037, 30003, 3, 1, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30049, 30003, 3, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30058, 30003, 3, 3, 132, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''),
       LEI.FaProzessCode
FROM   #Tree TRE
       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30005, 30004, 3, 1, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30006, 30004, 3, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30021, 30004, 3, 3, 132, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''),
       LEI.FaProzessCode
FROM   #Tree TRE
       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30023, 30022, 3, 1, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30024, 30022, 3, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30025, 30022, 3, 3, 132, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, FaProzessCode)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''),
       LEI.FaProzessCode
FROM   #Tree TRE
       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40007, 40000, 4, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40011, 40000, 4, 1, 1419, N'Inkasso Forderungen', N'CtlIkMonatszahlenEinmalig', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40013, 40000, 4, 3, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, 
  Name, Datum, LeistungGeschlossen)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null,
       TRE.LeistungGeschlossen
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40008, 40002, 4, 1, 1419, N'Inkasso Forderungen', N'CtlIkMonatszahlenEinmalig', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40009, 40002, 4, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40014, 40002, 4, 3, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, 
  Name, Datum, LeistungGeschlossen
)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null,
       TRE.LeistungGeschlossen 
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40010, 40003, 4, 1, 1419, N'Inkasso Forderungen', N'CtlIkMonatszahlenEinmalig', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40012, 40003, 4, 2, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40015, 40003, 4, 3, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, 
  Name, Datum, LeistungGeschlossen
)
SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID, @IconID,
       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null,
       TRE.LeistungGeschlossen
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40027, 40004, 4, 1, 1427, N'Berechnungen', N'CtlAmAnspruchsberechnung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40021, 40005, 4, 1, 1421, N'Rechtstitel', N'CtlIkRechtstitelUebh', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, Name, ParentID, FaFallID, FaLeistungID, 
  Datum, RechtstitelID, BaPersonID, ProzessCode, LeistungGeschlossen)
SELECT 
  @ModulTreeID, TRE.ID + ''\Rechtstitel'' + convert(varchar,RTI.IkRechtstitelID), 
  ISNULL(RTI.Bezeichnung, ''Rechtstitel UeBH''),
  TRE.ID, LEI.FaFallID, LEI.FaLeistungID, 
  RIN.RechtstitelDatumVon, RTI.IkRechtstitelID, F.BaPersonID, TRE.ProzessCode, 
  TRE.LeistungGeschlossen
FROM   #Tree TRE
  INNER JOIN FaLeistung LEI on LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN FaFall F on F.FaFallID = LEI.FaFallID
  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
  LEFT JOIN IkRechtstitelInfos RIN ON RIN.IkRechtstitelInfosID = (
    SELECT MAX(I2.IkRechtstitelInfosID) FROM IkRechtstitelInfos I2
    WHERE I2.IkRechtstitelID = RTI.IkRechtstitelID
  )
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY RTI.IkRechtstitelGueltigVon desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40022, 40005, 4, 4, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40023, 40005, 4, 3, 1417, N'Monatszahlen', N'CtlIkMonatszahlen', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40024, 40005, 4, 5, 140, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, 
  BaPersonID, FaFallID, FaLeistungID, 
  Name, Geburtsdatum, ProzessCode, LeistungGeschlossen)
SELECT distinct 
  @ModulTreeID, TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.BaPersonID), TRE.ID, 
  (SELECT TOP 1 CASE 
    WHEN GLB2.IkGlaeubigerStatusCode = 9 THEN 142
    WHEN GLB2.IkGlaeubigerStatusCode IN (1,2,3) 
    THEN GLB2.IkGlaeubigerStatusCode + 139 ELSE 140 
  END FROM IkGlaeubiger GLB2
  LEFT JOIN IkRechtstitel RTI2 ON RTI2.IkRechtstitelID = GLB2.IkRechtstitelID 
  LEFT JOIN FaLeistung LEI2 ON LEI2.FaLeistungID = RTI2.FaLeistungID 
  WHERE GLB2.BaPersonID = GLA.BaPersonID
    AND LEI2.FaLeistungID = LEI.FaLeistungID
  ORDER BY RTI2.IkRechtstitelGueltigVon DESC), -- @IconID,
  GLA.BaPersonID, LEI.FaFallID, LEI.FaLeistungID,
  Name = ''G: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), PRS.Geburtsdatum, TRE.ProzessCode,
  TRE.LeistungGeschlossen
FROM   #Tree TRE
       INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
       INNER JOIN IkGlaeubiger  GLA ON GLA.IkRechtstitelID = RTI.IkRechtstitelID 
       INNER JOIN BaPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40030, 40005, 4, 2, 2511, N'Zahlweg', N'CtlIkInterneVerrechnung', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40028, 40006, 4, 1, 1427, N'Berechnungen', N'CtlAmAnspruchsberechnung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40019, 40017, 4, 1, 1421, N'Bedingungen', N'CtlIkRechtstitelKkbb', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, 
  FaFallID, FaLeistungID, Name,
  Datum, RechtstitelID, BaPersonID, ProzessCode, LeistungGeschlossen)
SELECT 
  @ModulTreeID, TRE.ID + ''\Rechtstitel'' + convert(varchar,RTI.IkRechtstitelID ), TRE.ID,
  LEI.FaFallID, LEI.FaLeistungID, 
  ISNULL(RTI.Bezeichnung, ''Bedingung KKBB''),
  RTI.BeantragtAm, RTI.IkRechtstitelID, F.BaPersonID, TRE.ProzessCode,
  TRE.LeistungGeschlossen
FROM #Tree TRE
  INNER JOIN FaLeistung LEI on LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN FaFall F on F.FaFallID = LEI.FaFallID
  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY RTI.IkRechtstitelGueltigVon desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40020, 40017, 4, 3, 1417, N'Monatszahlen', N'CtlIkMonatszahlen', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40025, 40017, 4, 4, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, NULL, 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40026, 40017, 4, 5, 140, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, 
  BaPersonID, FaFallID, FaLeistungID, 
  Name, Geburtsdatum, ProzessCode, LeistungGeschlossen)
SELECT distinct 
  @ModulTreeID, TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.BaPersonID), TRE.ID, 
  (SELECT TOP 1 CASE 
    WHEN GLB2.IkGlaeubigerStatusCode = 9 THEN 142
    WHEN GLB2.IkGlaeubigerStatusCode IN (1,2,3) 
    THEN GLB2.IkGlaeubigerStatusCode + 139 ELSE 140 
  END FROM IkGlaeubiger GLB2
  LEFT JOIN IkRechtstitel RTI2 ON RTI2.IkRechtstitelID = GLB2.IkRechtstitelID 
  LEFT JOIN FaLeistung LEI2 ON LEI2.FaLeistungID = RTI2.FaLeistungID 
  WHERE GLB2.BaPersonID = GLA.BaPersonID
    AND LEI2.FaLeistungID = LEI.FaLeistungID
  ORDER BY RTI2.IkRechtstitelGueltigVon DESC), -- @IconID,
  GLA.BaPersonID, LEI.FaFallID, LEI.FaLeistungID,
  Name = ''G: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), PRS.Geburtsdatum, TRE.ProzessCode,
  TRE.LeistungGeschlossen 
FROM   #Tree TRE
       INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
       INNER JOIN IkGlaeubiger  GLA ON GLA.IkRechtstitelID = RTI.IkRechtstitelID 
       INNER JOIN BaPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40031, 40017, 4, 2, 2511, N'Zahlweg', N'CtlIkInterneVerrechnung', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40001, 41000, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, 
  BaPersonID, FaFallID, FaLeistungID, 
  Name, ProzessCode, LeistungGeschlossen)
SELECT distinct
  @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID, @IconID,
  LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
  Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), TRE.ProzessCode, 
  TRE.LeistungGeschlossen
FROM   #Tree TRE
       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40016, 41000, 4, 6, 164, N'Ratenplan', N'CtlIkRatenplan', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40018, 41000, 4, 5, 1417, N'Monatszahlen', N'CtlIkMonatszahlen', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40029, 41000, 4, 4, 2511, N'Zahlweg', N'CtlIkInterneVerrechnung', NULL, NULL, 1, N'UPDATE #Tree SET Datum = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41002, 41000, 4, 3, 1421, N'Rechtstitel', N'CtlIkRechtstitel', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, 
  Name,
  ParentID, FaFallID, FaLeistungID, 
  Datum, RechtstitelID, BaPersonID, ProzessCode, LeistungGeschlossen)
SELECT 
  @ModulTreeID, TRE.ID + ''\Rechtstitel'' + convert(varchar,RTI.IkRechtstitelID ), 
  ISNULL(RTI.Bezeichnung, ''Rechtstitel ALBV''),
  TRE.ID, LEI.FaFallID, LEI.FaLeistungID, 
  RIN.RechtstitelDatumVon, RTI.IkRechtstitelID, F.BaPersonID, TRE.ProzessCode,
  TRE.LeistungGeschlossen
FROM   #Tree TRE
  INNER JOIN FaLeistung LEI on LEI.FaLeistungID = TRE.FaLeistungID
  INNER JOIN FaFall F on F.FaFallID = LEI.FaFallID
  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
  LEFT JOIN IkRechtstitelInfos RIN ON RIN.IkRechtstitelInfosID = (
    SELECT MAX(I2.IkRechtstitelInfosID) FROM IkRechtstitelInfos I2
    WHERE I2.IkRechtstitelID = RTI.IkRechtstitelID
  )
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY RTI.IkRechtstitelGueltigVon desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41010, 41000, 4, 8, 140, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, IconID, 
  BaPersonID, FaFallID, FaLeistungID, 
  Name, Geburtsdatum, ProzessCode, LeistungGeschlossen)
SELECT distinct 
  @ModulTreeID, TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.BaPersonID), TRE.ID, 
  (SELECT TOP 1 CASE 
    WHEN GLB2.IkGlaeubigerStatusCode = 9 THEN 142
    WHEN GLB2.IkGlaeubigerStatusCode IN (1,2,3) 
    THEN GLB2.IkGlaeubigerStatusCode + 139 ELSE 140 
  END FROM IkGlaeubiger GLB2
  LEFT JOIN IkRechtstitel RTI2 ON RTI2.IkRechtstitelID = GLB2.IkRechtstitelID 
  LEFT JOIN FaLeistung LEI2 ON LEI2.FaLeistungID = RTI2.FaLeistungID 
  WHERE GLB2.BaPersonID = GLA.BaPersonID
    AND LEI2.FaLeistungID = LEI.FaLeistungID
  ORDER BY RTI2.IkRechtstitelGueltigVon DESC), -- @IconID,
  GLA.BaPersonID, LEI.FaFallID, LEI.FaLeistungID,
  Name = ''G: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), PRS.Geburtsdatum, TRE.ProzessCode, 
  TRE.LeistungGeschlossen
FROM   #Tree TRE
       INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
       INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
       INNER JOIN IkGlaeubiger  GLA ON GLA.IkRechtstitelID = RTI.IkRechtstitelID 
       INNER JOIN BaPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
ORDER BY PRS.Geburtsdatum desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50000, 50006, 5, 4, 176, N'Kontoplan', N'CtlKgKonto', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, @FieldList)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, @FieldList
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent AND
          EXISTS (SELECT 1 FROM dbo.KgPeriode WITH (READUNCOMMITTED) WHERE FaLeistungID = TRE.FaLeistungID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50011, 50006, 5, 5, 193, N'Perioden', N'CtlKgPeriode', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50012, 50006, 5, 1, 199, N'Kontoblatt', N'CtlKgKontoblatt', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, @FieldList)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, @FieldList
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent AND
          EXISTS (SELECT 1 FROM dbo.KgPeriode WITH (READUNCOMMITTED) WHERE FaLeistungID = TRE.FaLeistungID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50014, 50006, 5, 3, 184, N'Bilanz/Erfolg', N'CtlKgBilanzErfolg', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, @FieldList)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, @FieldList
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent AND
          EXISTS (SELECT 1 FROM dbo.KgPeriode WITH (READUNCOMMITTED) WHERE FaLeistungID = TRE.FaLeistungID)', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50017, 50006, 5, 6, 1322, N'Masterbudget', N'CtlKgBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, KgBudgetID, KgMasterBudgetID, KgBewilligungCode, Name, BewilligtVon, BewilligtBis)
SELECT @ModulTreeID, 
       TRE.ID + ''\Masterbudget'' + CONVERT(varchar, KBG.KgBudgetID), 
       TRE.ID,
       CASE KBG.KgBewilligungCode
         WHEN 1  THEN 1381  -- Vorbereitung
         WHEN 2  THEN 1381  -- Abgelehnt
         WHEN 3  THEN 1382  -- Angefragt
         WHEN 5  THEN CASE WHEN dbo.fnLastDayOf(ISNULL(KBG.BewilligtBis,GETDATE())) < dbo.fnDateOf(GETDATE())
                      THEN 1384  -- Gesperrt
                      ELSE 1383  -- Bewilligt
                      END
         WHEN 9  THEN 1384  -- Gesperrt
       END,
       TRE.FaFallID, 
       TRE.FaLeistungID, 
       TRE.BaPersonID,
       KBG.KgBudgetID, 
       null, 
       KBG.KgBewilligungCode,
       ''Masterbudget '' + isnull(''ab '' + convert(varchar, KBG.BewilligtVon, 104),''''),
       KBG.BewilligtVon,
       KBG.BewilligtBis
FROM   #Tree TRE
       INNER JOIN dbo.KgBudget KBG WITH (READUNCOMMITTED) ON KBG.FaLeistungID = TRE.FaLeistungID AND KBG.KgMasterBudgetID is null
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
ORDER BY KBG.BewilligtVon desc', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50025, 50006, 5, 2, 210, N'ZKB Dokumenten-Pool', N'CtlKgDokumentenPool', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20006, 20003, 2, 3, 178, N'Check-in', N'CtlFaCheckin', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20018, 20003, 2, 1, 0, N'X Divers', NULL, NULL, NULL, 999, N'INSERT INTO #Tree (
  ModulTreeID, ID, ParentID, 
  FaFallID, FaLeistungID, BaPersonID, Aufnahme, SubKnotenID
)
-- Voranmeldung
SELECT 
  20037,
  ''CtlFaVoranmeldung'' + CONVERT(varchar, VAN.FaVoranmeldungID), 
  TRE.ID, 
  TRE.FaFallID, 
  TRE.FaLeistungID,
  TRE.BaPersonID,
  Aufnahme = VAN.Datum,
  VAN.FaVoranmeldungID
FROM #Tree TRE
  INNER JOIN dbo.FaVoranmeldung VAN WITH (READUNCOMMITTED) ON VAN.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID_Parent

UNION ALL
-- CheckIn
SELECT 
  20006,
  ''CtlFaCheckin'' + CONVERT(varchar, CIN.FaCheckInID), 
  TRE.ID, 
  TRE.FaFallID, 
  TRE.FaLeistungID,
  TRE.BaPersonID,
  CIN.ErstkontaktDatum,
  CIN.FaCheckInID
FROM #Tree TRE
  INNER JOIN dbo.FaCheckin CIN WITH (READUNCOMMITTED) ON CIN.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID_Parent

UNION ALL
-- Assessment
SELECT 
  21000,
  ''CtlFaAssessment'' + CONVERT(varchar, ASS.FaAssessmentID), 
  TRE.ID, 
  TRE.FaFallID, 
  TRE.FaLeistungID,
  TRE.BaPersonID,
  ASS.EroeffnungDatum,
  ASS.FaAssessmentID
FROM #Tree TRE
  INNER JOIN dbo.FaAssessment ASS WITH (READUNCOMMITTED) ON ASS.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID_Parent

ORDER BY Aufnahme ASC


/*

-- Assessment Bericht
INSERT INTO #Tree 
  (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, SubKnotenID)
SELECT 
  20016,
  ''CtlFaAssessmentbericht'' + CONVERT(varchar, ASS.FaAssessmentID), 
  ''CtlFaAssessment'' + CONVERT(varchar, Ass.FaAssessmentID), 
  174,
  TRE.FaFallID, 
  TRE.FaLeistungID,
  TRE.BaPersonID,
  ASS.FaAssessmentID
FROM #Tree TRE
  INNER JOIN dbo.FaAssessment ASS WITH (READUNCOMMITTED) ON ASS.FaLeistungID = TRE.FaLeistungID
WHERE TRE.ModulTreeID = @ModulTreeID_Parent

*/', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20037, 20003, 2, 2, 208, N'Voranmeldung', N'CtlFaVoranmeldung', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (21000, 20003, 2, 4, 192, N'Assessment', N'CtlFaAssessment', NULL, NULL, 999, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20013, 20017, 2, 1, 1422, N'Massnahmen', N'CtlVISMassnahme', NULL, NULL, 999, N'
INSERT INTO #Tree (ModulTreeID, ID, ParentID, Name, FaFallID, FaLeistungID)
    SELECT 
       @ModulTreeID, 
       IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), 
       TRE.ID, 
       IsNull(MAS.ZGB, ''Massnahme/Bericht'') + '' - '' + PRS.Name + isnull('', '' + PRS.Vorname,''''),
       TRE.FaFallID, 
       TRE.FaLeistungID 
    FROM #Tree  TRE
      INNER JOIN dbo.VmMassnahme MAS WITH (READUNCOMMITTED) ON MAS.FaLeistungID = TRE.FaLeistungID 
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TRE.FaLeistungID 
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID    
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20004, 22000, 2, 1, 218, N'Ressourcenpaket', N'CtlFaRessourcenpaket', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, Aufnahme)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID,
         RP.RPIstDatumVon
  FROM   #Tree TRE
         INNER JOIN dbo.FaRessourcenpaket RP WITH (READUNCOMMITTED) ON RP.FaLeistungID = TRE.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY RP.RPIstDatumVon', 0)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20005, 22000, 2, 2, 125, N'Zielvereinbarung / Aufträge', N'CtlFaZielvereinbarung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, Aufnahme)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID,
         ZVE.DatumZielvereinbarung
  FROM   #Tree TRE
         INNER JOIN dbo.FaZielvereinbarung ZVE WITH (READUNCOMMITTED) ON ZVE.FaLeistungID = TRE.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY ZVE.DatumZielvereinbarung', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20015, 22000, 2, 3, 183, N'Abklärungsaufträge', N'CtlFaAbklaerung', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, Aufnahme)
  SELECT TOP 1
         ModulTreeID = @ModulTreeID,
         ID          = IsNull(@ClassName, '''') + CONVERT(varchar, TRE.FaLeistungID),
         ParentID    = TRE.ID,
         IconID      = @IconID,
         TRE.FaFallID, 
         TRE.FaLeistungID,
         TRE.BaPersonID,
         ABK.AuftragDatum
  FROM   #Tree TRE
         INNER JOIN dbo.FaAbklaerung ABK WITH (READUNCOMMITTED) ON ABK.FaLeistungID = TRE.FaLeistungID
  WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY ABK.AuftragDatum', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20007, 25000, 2, 3, 203, N'Unterlagenliste', N'CtlFaUnterlagenliste', NULL, NULL, 1, N'UPDATE #Tree 
SET Aufnahme = NULL, 
    IstAlimentenstelle = 0,
    SARName = NULL 
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20008, 25000, 2, 1, 175, N'Aktennotizen', N'CtlFaAktennotizen', NULL, NULL, 1, N'UPDATE #Tree 
SET Vertraulich = 0, 
    IstAlimentenstelle = 0,
    Aufnahme = NULL, 
    SARName = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20009, 25000, 2, 2, 216, N'Ressourcenkarte', N'CtlFaRessourcenkarte', N'Fa_Dok_Ressourcenkarte', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL, SARName = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20010, 25000, 2, 4, 202, N'Auflagen/Sanktionen', N'CtlFaAbmachungen', N'Fa_Dok_Abmachungen', NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL, SARName = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20011, 25000, 2, 6, 207, N'Vertrauliche Dok.', N'CtlFaDokumente', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, Vertraulich, IstAlimentenstelle, Aufnahme, SARName,FaFallID,FaLeistungID)
  SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + ''Vertraulich'' + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, 
         1,0,NULL,NULL,FaFallID,FaLeistungID
  FROM #Tree  TRE
  WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20012, 25000, 2, 5, 195, N'Dokumente', N'CtlFaDokumente', NULL, NULL, 1, N'UPDATE #Tree 
SET Vertraulich = 0, 
    IstAlimentenstelle = 0,
    Aufnahme = NULL, 
    SARName = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20032, 25000, 2, 7, 215, N'Teilleistungserbringer', N'CtlFaTeilleistungserbringer', NULL, NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL, SARName = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30007, 30001, 3, 2, 1318, N'Finanzplan Übersicht', N'CtlBgUebersicht', NULL, NULL, 1, N'UPDATE #Tree
  Set DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30019, 30001, 3, 3, 1322, N'Masterbudget', N'CtlWhBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaLeistungID, BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    TRE.FaLeistungID, BBG.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode
  FROM #Tree                 TRE
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = TRE.BgFinanzplanID
    INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30020, 30001, 3, 4, 1323, N'Monatsbudget', N'CtlWhBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaLeistungID, BgFinanzplanID, BgBudgetID, MasterBudget, BgBewilligungStatusCode, Name)
  SELECT @ModulTreeID, TRE.ID + ''\BBG'' + CONVERT(varchar, BBG.BgBudgetID), TRE.ID,
    CASE BBG.BgBewilligungStatusCode
      WHEN 1  THEN 1323  -- Vorbereitung
      WHEN 5  THEN 1324  -- Bewilligt
      WHEN 9  THEN 1325  -- Gesperrt
    END,
    TRE.FaLeistungID, BBG.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, BBG.BgBewilligungStatusCode,
    ''Budget '' + dbo.fnXKurzMonat(BBG.Monat) + '' '' + CONVERT(varchar, BBG.Jahr)
  FROM #Tree                 TRE
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = TRE.BgFinanzplanID AND SFP.BgBewilligungStatusCode >= 5
    INNER JOIN dbo.BgBudget      BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 0
  WHERE TRE.ModulTreeID = @ModulTreeID_Parent
  ORDER BY BBG.Jahr, BBG.Monat', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30062, 30001, 3, 1, 137, N'Personen im Haushalt', N'CtlWhPersonen', NULL, NULL, 1, N'UPDATE #Tree
  Set DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30063, 30002, 3, 1, 137, N'Personen', N'CtlWhNotfall', NULL, NULL, 1, N'UPDATE #Tree
  Set DatumVon = NULL
WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (50024, 50017, 5, 1, 1323, N'Monatsbudget', N'CtlKgBudget', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaFallID, FaLeistungID, BaPersonID, KgBudgetID, KgMasterBudgetID, KgBewilligungCode, Name, Monat, Jahr)
SELECT @ModulTreeID, 
       TRE.ID + ''\Monatsbudget'' + CONVERT(varchar, KBG.KgBudgetID), 
       TRE.ID, 
       CASE KBG.KgBewilligungCode
         WHEN 1  THEN 1351  -- Vorbereitung
         WHEN 5  THEN 1352  -- Bewilligt
         WHEN 9  THEN 1357  -- Gesperrt
       END,
       TRE.FaFallID, 
       TRE.FaLeistungID, 
       TRE.BaPersonID,
       KBG.KgBudgetID, 
       KBG.KgMasterBudgetID,
       KBG.KgBewilligungCode,
       ''Monatsbudget '' + dbo.fnXKurzMonat(KBG.Monat) + '' '' + CONVERT(varchar, KBG.Jahr),
       KBG.Monat,
       KBG.Jahr
FROM   #Tree TRE
       INNER JOIN dbo.KgBudget KBG WITH (READUNCOMMITTED) ON KBG.KgMasterBudgetID = TRE.KgBudgetID
WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
ORDER BY KBG.Jahr, KBG.Monat', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20016, 21000, 2, 4, 174, N'Assessmentbericht', N'CtlFaAssessmentbericht', NULL, NULL, 1, N'UPDATE #Tree SET Aufnahme = NULL, SARName = NULL WHERE ModulTreeID = @ModulTreeID', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (20014, 20005, 2, 1, 2118, N'Auswertung Zielvereinbarung/Aufträge', N'CtlFaZielvereinbarungAuswertung', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30008, 30007, 3, 14, 1319, N'F.4 - Verwandtenunterstützungspflicht', N'CtlBgFPEinnahmen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3104'', TRE.ID, TRE.BgBudgetID, 3104, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30009, 30007, 3, 11, 1319, N'E.1, C.1.2 - Einkommen und Mehrkosten', N'CtlBgFPEinnahmen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3101'', TRE.ID, TRE.BgBudgetID, 3101, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30010, 30007, 3, 13, 1319, N'F.3 - Eheliche und elterliche Unterhaltspflicht', N'CtlBgFPEinnahmen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3102'', TRE.ID, TRE.BgBudgetID, 3102, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30011, 30007, 3, 12, 1319, N'F.2 - Bevorschusste Leistungen Dritte', N'CtlBgFPEinnahmen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3103'', TRE.ID, TRE.BgBudgetID, 3103, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30012, 30007, 3, 15, 1319, N'F.5 - Wohn- und Lebensgemeinschaften', N'CtlBgFPEinnahmen', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3106'', TRE.ID, TRE.BgBudgetID, 3106, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30013, 30007, 3, 1, 1320, N'B - Grundbedarf', N'CtlBgGrundbedarf', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30014, 30007, 3, 2, 1320, N'B - Miete', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)      
SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3206'', TRE.ID, TRE.BgBudgetID, 3206, @Name      FROM #Tree  TRE      WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30015, 30007, 3, 3, 1320, N'B, C.1 - Krankenkassenprämien', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)      
SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3202'', TRE.ID, TRE.BgBudgetID, 3202, @Name      FROM #Tree  TRE      WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30016, 30007, 3, 6, 1320, N'C.2, C.3, E.1.2 Integrationszulagen und EFB', N'CtlBgFPZulagenEFB', NULL, NULL, 1, NULL, 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30017, 30007, 3, 5, 1320, N'C.1.8 - Situationsbedingte Leistungen', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3802'', TRE.ID, TRE.BgBudgetID, 3802, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30018, 30007, 3, 10, 1320, N'D, C.1.2 - Berufliche und soziale Integration und Mehrkosten', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3601'', TRE.ID, TRE.BgBudgetID, 3601, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30050, 30007, 3, 4, 1320, N'C.1.1-C.1.7 - Situationsbedingte Leistungen', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3803'', TRE.ID, TRE.BgBudgetID, 3803, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30051, 30007, 3, 8, 1320, N'D - Stationäre erzieherische Hilfen Ki/Ju', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3603'', TRE.ID, TRE.BgBudgetID, 3603, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30052, 30007, 3, 7, 1320, N'D - Ambulante erzieherische Hilfen Ki/Ju', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3602'', TRE.ID, TRE.BgBudgetID, 3602, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (30053, 30007, 3, 9, 1320, N'D - Wohn- & therapeutische Einrichtung Erw', N'CtlBgFPAusgaben', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, BgBudgetID, BgGruppeCode, Name)
    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + @ClassName + ''3604'', TRE.ID, TRE.BgBudgetID, 3604, @Name
    FROM #Tree  TRE
    WHERE ModulTreeID = @ModulTreeID_Parent', 1)
GO
COMMIT
GO