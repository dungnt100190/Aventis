CREATE TABLE [dbo].[KbZahlungseingang](
	[KbZahlungseingangID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[Debitor] [varchar](200) NULL,
	[Betrag] [money] NULL,
	[Mitteilung] [varchar](600) NULL,
	[Mitteilung1] [varchar](35) NULL,
	[Mitteilung2] [varchar](35) NULL,
	[Mitteilung3] [varchar](35) NULL,
	[Mitteilung4] [varchar](35) NULL,
	[PscdZahlungsstapel] [varchar](12) NULL,
	[PscdZahlungsstapelPos] [int] NULL,
	[PscdBankverrechnKto] [varchar](50) NULL,
	[Bemerkung] [text] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[KbZahlungseingangTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbZahlungseingang] PRIMARY KEY CLUSTERED 
(
	[KbZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbZahlungseingang_BaInstitutionID]    Script Date: 11/23/2011 15:59:12 ******/
CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_BaInstitutionID] ON [dbo].[KbZahlungseingang] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbZahlungseingang_BaPersonID]    Script Date: 11/23/2011 15:59:12 ******/
CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_BaPersonID] ON [dbo].[KbZahlungseingang] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_BaInstitution]
GO
ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_BaPerson]