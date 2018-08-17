SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM XModulTree
GO
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (10000, NULL, 1, 1, 134, 'Klientensystem', 'CtlBaKlientensystem', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (10001, NULL, 1, 2, 133, 'Person', 'CtlBaStammdaten', NULL, 'ALTER TABLE #Tree ADD
  Unterstuetzt  bit,
  Age           int', 999, 'INSERT INTO #Tree (ModulTreeID, ID, Name, BaPersonID, Unterstuetzt, Age)
  SELECT ModulTreeID  = @ModulTreeID,
         ID           = ''P'' + CONVERT(VARCHAR, BaPersonID),
         Name         = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
         BaPersonID   = PRS.BaPersonID,
         Unterstuetzt = CASE WHEN PRS.BaPersonID = @BaPersonID THEN 1 
                             ELSE ISNULL(PRS.Unterstuetzt, 0) 
                        END,
         Age          = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE()))
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
  WHERE BaPersonID = @BaPersonID OR 
        BaPersonID IN (SELECT BaPersonID_1 
                       FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                       WHERE BaPersonID_2 = @BaPersonID
                       
                       UNION
                       
                       SELECT BaPersonID_2 
                       FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                       WHERE BaPersonID_1 = @BaPersonID)
  ORDER BY CASE WHEN PRS.BaPersonID = @BaPersonID THEN 0 
                ELSE 1 
           END, Age DESC', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (10002, NULL, 1, 3, 191, 'Institutionen, Fachpersonen', 'CtlBaInstitutionenFachpersonen', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20000, NULL, 2, 1, 100, 'Sozialsystem', 'CtlFaSozialsystemContainer', NULL, 'ALTER TABLE #Tree ADD
  Aufnahme        DATETIME,
  SARName         VARCHAR(100),
  ModulID         INT,
  Abschluss       DATETIME', 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20002, NULL, 2, 2, 177, 'Übersicht', 'CtlFaUebersichtsgrafik', NULL, NULL, 1, NULL, 0)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20003, NULL, 2, 3, 183, 'Journal', 'CtlFaJournal', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20004, NULL, 2, 4, 5008, 'Erfasste Leistungen', 'CtlFaLeistungKlient', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20005, NULL, 2, 5, 180, 'Dokumentation', 'CtlFaDokumentation', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20011, NULL, 2, 6, 1201, 'Fallverlauf', 'CtlFaBeratungsperiode', NULL, 'ALTER TABLE #Tree ADD
  DatumBis DATETIME,
  UserMayReadFall BIT', 999, 'INSERT INTO #Tree (ModulTreeID, ID, IconID, FaLeistungID, BaPersonID, Aufnahme, SARName, Abschluss, DatumBis, UserMayReadFall, ModulID)
  SELECT ModulTreeID     = @ModulTreeID,
         ID              = @ClassName + CONVERT(VARCHAR, LEI.FaLeistungID),
         IconID          = CASE WHEN ARC.FaLeistungID IS NOT NULL THEN 1003 + 100 * LEI.ModulID  -- Archiviert
                                WHEN LEI.DatumBis     IS NOT NULL THEN 1002 + 100 * LEI.ModulID  -- Abgeschlossen
                                ELSE 1001 + 100 * LEI.ModulID
                           END,
         FaLeistungID    = LEI.FaLeistungID,
         BaPersonID      = @BaPersonID,
         Aufnahme        = LEI.DatumVon,
         SARName         = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
         Abschluss       = LEI.DatumBis,
         DatumBis        = LEI.DatumBis,
         UserMayReadFall = dbo.fnUserMayReadFall(@UserID, LEI.FaLeistungID),
         ModulID         = 2
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    LEFT JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND 
                                                                 ARC.CheckOut IS NULL
    LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
  WHERE LEI.BaPersonID = @BaPersonID AND 
        LEI.ModulID = @ModulID
  ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN 0 
                ELSE 1 
           END, LEI.DatumVon DESC, LEI.FaLeistungID DESC', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20006, 20005, 2, 1, 5007, 'Situationsbeschreibung', 'CtlFaSituationsbeschreibung', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20007, 20005, 2, 2, 5009, 'Aktennotizen', 'CtlFaAktennotizen', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20008, 20005, 2, 3, 5010, 'Abmachungen', 'CtlFaAbmachungen', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20009, 20005, 2, 4, 1417, 'Dokumente', 'CtlFaDokumente', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20010, 20005, 2, 6, 5006, 'Dokumente Gesuchverwaltung', 'CtlFaFinanzgesuche', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20021, 20005, 2, 7, 5001, 'Betreuungsinfo', 'CtlFaBetreuungsinfo', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20024, 20005, 2, 5, 5006, 'Gesuchverwaltung', 'CtlGvGesuchverwaltung', NULL, NULL, 1, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (30000, 20011, 2, 2, 1301, 'Sozialberatung', 'CtlFaBeratungsperiode', NULL, NULL, 999, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (40000, 20011, 2, 3, 1401, 'Case Management', 'CtlFaBeratungsperiode', NULL, NULL, 999, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (50000, 20011, 2, 4, 1501, 'Begleitetes Wohnen', 'CtlFaBeratungsperiode', NULL, NULL, 999, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (60000, 20011, 2, 5, 1601, 'Entlastungsdienst', 'CtlFaBeratungsperiode', NULL, NULL, 999, NULL, 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (70000, 20011, 2, 1, 1701, 'Intake', 'CtlFaIntake', NULL, NULL, 999, 'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, FaLeistungID, BaPersonID, Aufnahme, SARName, Abschluss, DatumBis, UserMayReadFall, ModulID)
  SELECT ModulTreeID     = LEI.ModulID * 10000,
         ID              = ''LEI'' + CONVERT(VARCHAR, LEI.FaLeistungID),
         ParentID        = (SELECT TOP 1 TRE.ID
                            FROM #Tree TRE
                            WHERE TRE.ModulTreeID = @ModulTreeID_Parent AND 
                                  TRE.FaLeistungID < LEI.FaLeistungID
                            ORDER BY LEI.FaLeistungID DESC),
         IconID          = CASE WHEN ARC.FaLeistungID IS NOT NULL  THEN 1003 + 100 * LEI.ModulID  -- Archiviert
                                WHEN LEI.DatumBis     IS NOT NULL  THEN 1002 + 100 * LEI.ModulID  -- Abgeschlossen
                                ELSE 1001 + 100 * LEI.ModulID
                           END,
         FaLeistungID    = LEI.FaLeistungID, 
         BaPersonID      = @BaPersonID,
         Aufnahme        = LEI.DatumVon,
         SARName         = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
         Abschluss       = LEI.DatumBis,
         DatumBis        = LEI.DatumBis,
         UserMayReadFall = dbo.fnUserMayReadFall(@UserID, LEI.FaLeistungID),
         ModulID         = LEI.ModulID
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
      LEFT JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND 
                                                                   ARC.CheckOut IS NULL
      LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
  WHERE LEI.BaPersonID = @BaPersonID AND 
        LEI.ModulID > 2
  ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN 0 
                ELSE 1 
           END, LEI.DatumVon DESC, LEI.FaLeistungID DESC', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20012, 30000, 2, 1, 126, 'Zielvereinbarungen', 'CtlSbZielvereinbarung', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20016, 30000, 2, 2, 127, 'Evaluation', 'CtlSbEvaluation', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20013, 40000, 2, 1, 126, 'Zielvereinbarungen', 'CtlCmZielvereinbarung', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20017, 40000, 2, 2, 127, 'Evaluation', 'CtlCmEvaluation', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20001, 50000, 2, 1, 126, 'Einsatzvereinbarung', 'CtlBwEinsatzvereinbarung', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20015, 50000, 2, 2, 5002, 'Auswertung', 'CtlBwAuswertungOrganisation', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20019, 50000, 2, 3, 5003, 'Einsätze', 'CtlEinsatz', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20020, 60000, 2, 1, 126, 'Einsatzvereinbarung', 'CtlEdEinsatzvereinbarung', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20022, 60000, 2, 2, 5002, 'Auswertungsdaten', 'CtlEdAuswertungsdaten', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, MaskName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active) VALUES (20023, 60000, 2, 3, 5003, 'Einsätze', 'CtlEinsatz', NULL, NULL, 1, 'UPDATE TRE
SET Aufnahme  = NULL, 
    SARName   = NULL, 
    Abschluss = NULL
FROM #Tree TRE
WHERE TRE.ModulTreeID = @ModulTreeID', 1)
COMMIT
