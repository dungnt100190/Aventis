CREATE TABLE [dbo].[KgZahlungseingang](
	[KgZahlungseingangID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[Debitor] [varchar](200) NULL,
	[KgKontoID] [int] NULL,
	[Betrag] [money] NULL,
	[Mitteilung] [varchar](600) NULL,
	[PscdKontoKlient] [varchar](50) NULL,
	[PscdKontoauszug] [varchar](20) NULL,
	[PscdKontoauszugPos] [int] NULL,
	[Bemerkung] [text] NULL,
	[KgZahlungseingangArtCode] [int] NULL,
	[Ausgeglichen] [bit] NOT NULL CONSTRAINT [DF_KgZahlungseingang_Ausgeglichen]  DEFAULT ((0)),
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[KgZahlungseingangTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgZahlungseingang] PRIMARY KEY CLUSTERED 
(
	[KgZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgZahlungseingang_BaInstitutionID]    Script Date: 11/23/2011 16:05:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgZahlungseingang_BaInstitutionID] ON [dbo].[KgZahlungseingang] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgZahlungseingang_BaPersonID]    Script Date: 11/23/2011 16:05:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgZahlungseingang_BaPersonID] ON [dbo].[KgZahlungseingang] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgZahlungseingang_KgKontoID]    Script Date: 11/23/2011 16:05:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgZahlungseingang_KgKontoID] ON [dbo].[KgZahlungseingang] 
(
	[KgKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[KgZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KgZahlungseingang_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[KgZahlungseingang] CHECK CONSTRAINT [FK_KgZahlungseingang_BaInstitution]
GO
ALTER TABLE [dbo].[KgZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KgZahlungseingang_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KgZahlungseingang] CHECK CONSTRAINT [FK_KgZahlungseingang_BaPerson]
GO
ALTER TABLE [dbo].[KgZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KgZahlungseingang_KgKonto] FOREIGN KEY([KgKontoID])
REFERENCES [dbo].[KgKonto] ([KgKontoID])
GO
ALTER TABLE [dbo].[KgZahlungseingang] CHECK CONSTRAINT [FK_KgZahlungseingang_KgKonto]