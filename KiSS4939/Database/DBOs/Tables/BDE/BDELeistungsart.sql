CREATE TABLE [dbo].[BDELeistungsart](
	[BDELeistungsartID] [int] IDENTITY(1,1) NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[SortKey] [int] NULL,
	[KlientErfassungCode] [int] NULL,
	[AnzahlCode] [int] NULL,
	[ArtikelNr] [varchar](50) NULL,
	[LeistungsartTypCode] [int] NOT NULL CONSTRAINT [DF_BDELeistungsart_LeistungsartTypCode]  DEFAULT ((1)),
	[KostenartCode] [int] NULL,
	[KTRStandard] [varchar](20) NULL,
	[KTRIV] [varchar](20) NULL,
	[KTRAHV] [varchar](20) NULL,
	[KTRNichtberechtigte] [varchar](20) NULL,
	[Beschreibung] [varchar](1000) NULL,
	[AuswDienstleistungCode] [int] NULL,
	[AuswFakturaCode] [int] NULL,
	[AuswProduktCode] [int] NULL,
	[AuswPIAuftragCode] [int] NULL,
	[BDELeistungsartTS] [timestamp] NOT NULL,
	[VerID] [int] NULL,
 CONSTRAINT [PK_BDELeistungsart] PRIMARY KEY CLUSTERED 
(
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BDELeistungsart_AuswDienstleistungCode]    Script Date: 03/16/2010 08:45:31 ******/
CREATE NONCLUSTERED INDEX [IX_BDELeistungsart_AuswDienstleistungCode] ON [dbo].[BDELeistungsart] 
(
	[AuswDienstleistungCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BDELeistungsart_BDELeistungsartID_AuswDienstleistungCode]    Script Date: 03/16/2010 08:45:31 ******/
CREATE NONCLUSTERED INDEX [IX_BDELeistungsart_BDELeistungsartID_AuswDienstleistungCode] ON [dbo].[BDELeistungsart] 
(
	[BDELeistungsartID] ASC,
	[AuswDienstleistungCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Trigger [dbo].[trHist_BDELeistungsart]    Script Date: 03/16/2010 08:45:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_BDELeistungsart]
  ON [dbo].[BDELeistungsart]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BDELeistungsart] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [BDELeistungsartID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [BDELeistungsartID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[BDELeistungsartID], DEL.[BDELeistungsartID]), TBL.VerID,
      CASE WHEN (INS.[BDELeistungsartID] IS NULL) THEN 3 WHEN (DEL.[BDELeistungsartID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[BDELeistungsartID] = INS.[BDELeistungsartID]
      LEFT       JOIN [Hist_BDELeistungsart]  TBL ON TBL.[BDELeistungsartID] = DEL.[BDELeistungsartID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[BDELeistungsartID] IS NULL) OR (DEL.[BDELeistungsartID] IS NULL)
      OR CHECKSUM(INS.[BDELeistungsartID], INS.[Bezeichnung], INS.[BezeichnungTID], INS.[DatumVon], INS.[DatumBis], INS.[SortKey], INS.[KlientErfassungCode], INS.[AnzahlCode], INS.[ArtikelNr], INS.[LeistungsartTypCode], INS.[KostenartCode], INS.[KTRStandard], INS.[KTRIV], INS.[KTRAHV], INS.[KTRNichtberechtigte], INS.[Beschreibung], INS.[AuswDienstleistungCode], INS.[AuswFakturaCode], INS.[AuswProduktCode], INS.[AuswPIAuftragCode])
      <> CHECKSUM(TBL.[BDELeistungsartID], TBL.[Bezeichnung], TBL.[BezeichnungTID], TBL.[DatumVon], TBL.[DatumBis], TBL.[SortKey], TBL.[KlientErfassungCode], TBL.[AnzahlCode], TBL.[ArtikelNr], TBL.[LeistungsartTypCode], TBL.[KostenartCode], TBL.[KTRStandard], TBL.[KTRIV], TBL.[KTRAHV], TBL.[KTRNichtberechtigte], TBL.[Beschreibung], TBL.[AuswDienstleistungCode], TBL.[AuswFakturaCode], TBL.[AuswProduktCode], TBL.[AuswPIAuftragCode])



  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BDELeistungsart]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BDELeistungsartID] = TBL.[BDELeistungsartID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BDELeistungsart]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BDELeistungsartID] = TBL.[BDELeistungsartID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BDELeistungsart ([BDELeistungsartID], [Bezeichnung], [BezeichnungTID], [DatumVon], [DatumBis], [SortKey], [KlientErfassungCode], [AnzahlCode], [ArtikelNr], [LeistungsartTypCode], [KostenartCode], [KTRStandard], [KTRIV], [KTRAHV], [KTRNichtberechtigte], [Beschreibung], [AuswDienstleistungCode], [AuswFakturaCode], [AuswProduktCode], [AuswPIAuftragCode], VerID)
      SELECT TBL.[BDELeistungsartID], TBL.[Bezeichnung], TBL.[BezeichnungTID], TBL.[DatumVon], TBL.[DatumBis], TBL.[SortKey], TBL.[KlientErfassungCode], TBL.[AnzahlCode], TBL.[ArtikelNr], TBL.[LeistungsartTypCode], TBL.[KostenartCode], TBL.[KTRStandard], TBL.[KTRIV], TBL.[KTRAHV], TBL.[KTRNichtberechtigte], TBL.[Beschreibung], TBL.[AuswDienstleistungCode], TBL.[AuswFakturaCode], TBL.[AuswProduktCode], TBL.[AuswPIAuftragCode], @VerID
      FROM [BDELeistungsart]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDELeistungsartID] = TBL.[BDELeistungsartID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BDELeistungsart]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BDELeistungsartID] = TBL.[BDELeistungsartID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END
