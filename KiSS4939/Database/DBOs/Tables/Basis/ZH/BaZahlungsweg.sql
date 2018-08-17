CREATE TABLE [dbo].[BaZahlungsweg](
	[BaZahlungswegID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[EinzahlungsscheinCode] [int] NULL,
	[ZahlinformationAktiv] [bit] NULL,
	[BaBankID] [int] NULL,
	[BankKontoNummer] [varchar](50) NULL,
	[IBANNummer] [varchar](50) NULL,
	[PostKontoNummer] [varchar](20) NULL,
	[ESRTeilnehmer] [varchar](100) NULL,
	[AdresseName] [varchar](35) NULL,
	[AdresseName2] [varchar](35) NULL,
	[AdresseStrasse] [varchar](35) NULL,
	[AdresseHausNr] [varchar](35) NULL,
	[AdressePostfach] [varchar](35) NULL,
	[AdressePLZ] [varchar](10) NULL,
	[AdresseOrt] [varchar](25) NULL,
	[AdresseLandCode] [int] NULL,
	[BaZahlwegModulStdCodes] [varchar](20) NULL,
	[BaZahlungswegTS] [timestamp] NOT NULL,
	[IsZkbVmKonto] [bit] NULL CONSTRAINT [DF_BaZahlungsweg_IsZkbVmKonto]  DEFAULT ((0)),
	[WMAVerwenden] [bit] NOT NULL CONSTRAINT [DF_BaZahlungsweg_WMAVerwenden]  DEFAULT ((1)),
	[BaKontoartCode] [int] NULL,
	[Verwendungszweck] [varchar](30) NULL,
	[BankKontoNummer_MT940_Format]  AS (case when [BankKontoNummer] like '11__-____.___%' then replace(replace([BankKontoNummer],'-','0'),'.','') when [BankKontoNummer] like '11__.____.___%' then ((substring([BankKontoNummer],(1),(4))+'0')+substring([BankKontoNummer],(6),(4)))+substring([BankKontoNummer],(11),(3)) when [BankKontoNummer] like '3___-_.______._%' then replace(replace([BankKontoNummer],'-',''),'.','') when [BankKontoNummer] like '3___-_.______-_%' then replace(replace([BankKontoNummer],'-',''),'.','') else [BankKontoNummer] end),
	[BaFreigabeStatusCode] [int] NULL,
	[DefinitivUserID] [int] NULL,
	[DefinitivDatum] [datetime] NULL,
	[ErstelltUserID] [int] NULL,
	[MutiertUserID] [int] NULL,
	[Creator] [VARCHAR](50) NOT NULL,
	[Created] [DATETIME] NOT NULL,
	[Modifier] [VARCHAR](50) NOT NULL,
	[Modified] [DATETIME] NOT NULL,
 CONSTRAINT [PK_BaZahlungsweg] PRIMARY KEY CLUSTERED 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaZahlungsweg_AdresseLandCode]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_AdresseLandCode] ON [dbo].[BaZahlungsweg] 
(
	[AdresseLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_BaBankID]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaBankID] ON [dbo].[BaZahlungsweg] 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_BaInstitutionID]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaInstitutionID] ON [dbo].[BaZahlungsweg] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_BankKontoNummer]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BankKontoNummer] ON [dbo].[BaZahlungsweg] 
(
	[BankKontoNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF
/****** Object:  Index [IX_BaZahlungsweg_BankKontoNummer_MT940_Format]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BankKontoNummer_MT940_Format] ON [dbo].[BaZahlungsweg] 
(
	[BankKontoNummer_MT940_Format] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_BaPersonID]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaPersonID] ON [dbo].[BaZahlungsweg] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_IBANNummer]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_IBANNummer] ON [dbo].[BaZahlungsweg] 
(
	[IBANNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaZahlungsweg_PostKontoNummer]    Script Date: 11/23/2011 11:02:07 ******/
CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_PostKontoNummer] ON [dbo].[BaZahlungsweg] 
(
	[PostKontoNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaZahlungsweg] ADD  CONSTRAINT [DF_BaZahlungswegDokument_Created]  DEFAULT (GETDATE()) FOR [Created]
GO

ALTER TABLE [dbo].[BaZahlungsweg] ADD  CONSTRAINT [DF_BaZahlungswegDokument_Modified]  DEFAULT (GETDATE()) FOR [Modified]
GO


ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO
ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaBank]
GO
ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaInstitution]
GO
ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaLand] FOREIGN KEY([AdresseLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO
ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaLand]
GO
ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaPerson]