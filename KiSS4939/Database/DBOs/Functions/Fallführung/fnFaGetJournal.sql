SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetJournal;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Collect data to display within FaJournal
    @BaPersonID:     The BaPersonID to use for getting data
    @UserID:         The UserID to use for getting data
    @LanguageCode:   The language code to use for ML-texts
    @CurrentGetDate: The date to use to get address of institution
  -
  RETURNS: The collected entries used to display within FaJournal
=================================================================================================
  TEST:    SELECT * FROM dbo.fnFaGetJournal(333, 2, 1, GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetJournal
(
  @BaPersonID INT, 
  @UserID INT, 
  @LanguageCode INT, 
  @CurrentGetDate DATETIME
)
RETURNS @Result TABLE
(
  [ID$] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [Datum] DATETIME,
  [Typ] VARCHAR(100),
  [TypCode] INT NOT NULL,
  [Modul] VARCHAR(100),
  [ModulID] INT,
  [Autor] VARCHAR(255),
  [Titel] VARCHAR(255),
  [Text] VARCHAR(MAX),
  [ThemenCodes] VARCHAR(255),
  [DocumentID] INT,
  [SortUserID] INT
)
AS
BEGIN
  ------------------------------------------------------------------------------
  -- Aktennotizen (FaJournalTyp = 1)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, ThemenCodes, SortUserID)
    SELECT Datum       = AKT.Datum,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 1, @LanguageCode),
           TypCode     = 1,
           Modul       = dbo.fnGetLOVMLText('FaModulDienstleistungen', AKT.DienstleistungCode, @LanguageCode),
           ModulID     = AKT.DienstleistungCode + 2,   -- transpose from one LOV to other
           Autor       = dbo.fnGetLastFirstName(AKT.UserID, NULL, NULL),
           Titel       = AKT.Stichworte,
           Text        = CONVERT(VARCHAR(MAX), AKT.Inhalt),
           ThemenCodes = AKT.ThemenCodes,
           SortUserID  = AKT.UserID
    FROM dbo.FaAktennotizen AKT WITH (READUNCOMMITTED)
    WHERE AKT.BaPersonID = @BaPersonID;
  
  ------------------------------------------------------------------------------
  -- Abmachungen (FaJournalTyp = 2)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, ThemenCodes, SortUserID)
    SELECT Datum       = ABM.Erstellung,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 2, @LanguageCode),
           TypCode     = 2,
           Modul       = dbo.fnGetLOVMLText('FaModulDienstleistungen', ABM.DienstleistungCode, @LanguageCode),
           ModulID     = ABM.DienstleistungCode + 2,   -- transpose from one LOV to other
           Autor       = dbo.fnGetLastFirstName(ABM.UserID, NULL, NULL),
           Titel       = ABM.Stichworte,
           Text        = CONVERT(VARCHAR(MAX), ABM.Text),
           ThemenCodes = ABM.ThemenCodes,
           SortUserID  = ABM.UserID
    FROM dbo.FaAbmachungen ABM WITH (READUNCOMMITTED)
    WHERE ABM.BaPersonID = @BaPersonID;
  
  ------------------------------------------------------------------------------
  -- Dokumente (FaJournalTyp = 3)
  ------------------------------------------------------------------------------
  /* 
  INFO:
  FaDokumentAdressTyp  1  Benutzer
  FaDokumentAdressTyp  2  Klient/in
  FaDokumentAdressTyp  3  Institution
  */
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, ThemenCodes, DocumentID, SortUserID)
    SELECT Datum       = DOK.Datum,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 3, @LanguageCode),
           TypCode     = 3,
           Modul       = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOK.DienstleistungCode, @LanguageCode),
           ModulID     = DOK.DienstleistungCode + 2,   -- transpose from one LOV to other
           Autor       = CASE 
                           WHEN DOK.AutorAdressTypCode = 1 THEN dbo.fnGetLastFirstName(DOK.AutorID, NULL, NULL)
                           WHEN DOK.AutorAdressTypCode = 2 THEN dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname)
                           WHEN DOK.AutorAdressTypCode = 3 THEN (SELECT ISNULL(dbo.fnGetLastFirstName(NULL, INS.Name, INS.Vorname), '') + 
                                                                        ISNULL(', ' + ADR.Zusatz, '') + 
                                                                        ISNULL(', ' + ADR.Ort, '')
                                                                 FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
                                                                   LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, @CurrentGetDate)
                                                                 WHERE INS.BaInstitutionID = DOK.AutorID)
                           ELSE ''
                         END,
           Titel       = DOK.Stichworte,
           Text        = CONVERT(VARCHAR(MAX), DOK.Bemerkungen),
           ThemenCodes = DOK.ThemenCodes,
           DocumentID  = DOK.DokumentDocID,
           SortUserID  = CASE 
                           WHEN DOK.AutorAdressTypCode = 1 THEN DOK.AutorID
                           ELSE -1
                         END
    FROM dbo.FaDokumente DOK WITH (READUNCOMMITTED)
      LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DOK.AutorID
    WHERE DOK.BaPersonID = @BaPersonID;
  
  ------------------------------------------------------------------------------
  -- Finanzgesuche (FaJournalTyp = 4)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, SortUserID)
    SELECT Datum       = FGS.Datum,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 4, @LanguageCode),
           TypCode     = 4,
           Modul       = dbo.fnGetLOVMLText('FaModulDienstleistungen', FGS.DienstleistungCode, @LanguageCode),
           ModulID     = FGS.DienstleistungCode + 2,   -- transpose from one LOV to other
           Autor       = dbo.fnGetLastFirstName(FGS.UserID, NULL, NULL),
           Titel       = dbo.fnGetLOVMLText('FaGesuchDokumenttyp', FGS.DokumenttypCode, @LanguageCode),
           Text        = CONVERT(VARCHAR(MAX), FGS.Bemerkungen),
           SortUserID  = FGS.UserID
    FROM dbo.FaFinanzgesuche FGS WITH (READUNCOMMITTED)
    WHERE FGS.BaPersonID = @BaPersonID;
  
  ------------------------------------------------------------------------------
  -- Falleröffnung (FaJournalTyp = 5)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, SortUserID)
    SELECT Datum       = LEI.DatumVon,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 5, @LanguageCode),
           TypCode     = 5,
           Modul       = dbo.fnGetLOVMLText('Modul', LEI.ModulID, @LanguageCode),
           ModulID     = LEI.ModulID,
           Autor       = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           Titel       = NULL,
           Text        = CONVERT(VARCHAR(MAX), LEI.Bemerkung),
           SortUserID  = LEI.UserID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID 
      AND LEI.ModulID = 2;   -- Fallverlauf
  
  ------------------------------------------------------------------------------
  -- Fallabschluss (FaJournalTyp = 6)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, SortUserID)
    SELECT Datum       = LEI.DatumBis,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 6, @LanguageCode),
           TypCode     = 6,
           Modul       = dbo.fnGetLOVMLText('Modul', LEI.ModulID, @LanguageCode),
           ModulID     = LEI.ModulID,
           Autor       = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           Titel       = NULL,
           Text        = CONVERT(VARCHAR(MAX), LEI.Bemerkung),
           SortUserID  = LEI.UserID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID 
      AND LEI.ModulID = 2  -- Fallverlauf
      AND LEI.DatumBis IS NOT NULL;
  
  ------------------------------------------------------------------------------
  -- Phaseneröffnung (FaJournalTyp = 7)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, ThemenCodes, DocumentID, SortUserID)
    SELECT Datum       = LEI.DatumVon,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 7, @LanguageCode),
           TypCode     = 7,
           Modul       = CASE LEI.ModulID 
                           WHEN 31 THEN dbo.fnGetMLTextFromName('CtlFaModulTree', 'TextDienstleistungWD', @LanguageCode) + dbo.fnLOVMLText('FaModulDienstleistungen', LEI.FaModulDienstleistungenCode, @LanguageCode) 
                           ELSE dbo.fnGetLOVMLText('Modul', LEI.ModulID, @LanguageCode)
                         END,
           ModulID     = LEI.ModulID,
           Autor       = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           Titel       = CASE 
                           WHEN LEI.ModulID = 7 THEN dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, @LanguageCode)
                           ELSE NULL
                         END,
           Text        = CASE 
                           WHEN LEI.ModulID = 7 THEN CONVERT(VARCHAR(MAX), FAI.Anlass)
                           ELSE CONVERT(VARCHAR(MAX), LEI.Bemerkung)
                         END,
           ThemenCodes = CASE 
                           WHEN LEI.ModulID = 7 THEN FAI.AnlassthemenCodes
                           ELSE NULL
                         END,
           DocumentID  = CASE 
                           WHEN LEI.ModulID = 7 THEN FAI.IntakeProtokollDocID
                           ELSE NULL
                         END,
           SortUserID  = LEI.UserID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
      LEFT JOIN dbo.FaIntake FAI WITH (READUNCOMMITTED) ON FAI.FaLeistungID = LEI.FaLeistungID
    WHERE LEI.BaPersonID = @BaPersonID 
      AND LEI.ModulID <> 2;   -- other modules
  
  ------------------------------------------------------------------------------
  -- Phasenabschluss (FaJournalTyp = 8)
  ------------------------------------------------------------------------------
  INSERT INTO @Result (Datum, Typ, TypCode, Modul, ModulID, Autor, Titel, Text, ThemenCodes, DocumentID, SortUserID)
    SELECT Datum       = LEI.DatumBis,
           Typ         = dbo.fnGetLOVMLText('FaJournalTyp', 8, @LanguageCode),
           TypCode     = 8,
           Modul       = CASE LEI.ModulID 
                           WHEN 31 THEN dbo.fnGetMLTextFromName('CtlFaModulTree', 'TextDienstleistungWD', @LanguageCode) + dbo.fnLOVMLText('FaModulDienstleistungen', LEI.FaModulDienstleistungenCode, @LanguageCode) 
                           ELSE dbo.fnGetLOVMLText('Modul', LEI.ModulID, @LanguageCode)
                         END,
           ModulID     = LEI.ModulID,
           Autor       = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           Titel       = CASE 
                           WHEN LEI.ModulID = 7 THEN dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, @LanguageCode)
                           ELSE NULL
                         END,
           Text        = CASE 
                           WHEN LEI.ModulID = 7 THEN CONVERT(VARCHAR(MAX), FAI.Anlass)
                           ELSE CONVERT(VARCHAR(MAX), LEI.Bemerkung)
                         END,
           ThemenCodes = CASE 
                           WHEN LEI.ModulID = 7 THEN FAI.AnlassthemenCodes
                           ELSE NULL
                         END,
           DocumentID  = CASE 
                           WHEN LEI.ModulID = 7 THEN FAI.IntakeProtokollDocID
                           ELSE NULL
                         END,
           SortUserID  = LEI.UserID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
      LEFT JOIN dbo.FaIntake FAI WITH (READUNCOMMITTED) ON FAI.FaLeistungID = LEI.FaLeistungID
    WHERE LEI.BaPersonID = @BaPersonID 
      AND LEI.ModulID <> 2  -- other modules
      AND LEI.DatumBis IS NOT NULL;
  
  ------------------------------------------------------------------------------
  -- prepare data for sorting 
  -- (entries of current user have more importance than others --> sort by userid)
  ------------------------------------------------------------------------------
  UPDATE @Result
  SET SortUserID = NULL
  WHERE SortUserID <> @UserID;
  
  ------------------------------------------------------------------------------
  -- done
  ------------------------------------------------------------------------------
  RETURN;
END;
GO