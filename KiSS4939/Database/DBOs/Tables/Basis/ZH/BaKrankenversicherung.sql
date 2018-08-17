CREATE TABLE [dbo].[BaKrankenversicherung](
	[BaKrankenversicherungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[GesetzesGrundlageCode] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BaInstitutionID] [int] NULL,
	[MitgliedNr] [varchar](50) NULL,
	[Praemie] [money] NOT NULL,
	[Franchise] [money] NULL,
	[BezahltDurchCode] [int] NULL,
	[KKAdministrationSoD] [bit] NULL,
	[KVGPraemienVerbilligung] [bit] NULL,
	[KVGPraemienVerbillBetrag] [money] NULL,
	[KVGPraemienVerbillZahlungAnCode] [int] NULL,
	[UnfallEinschluss] [bit] NULL,
	[Zahnversicherung] [bit] NULL,
	[Taggeldversicherung] [bit] NULL,
	[TaggeldversicherungBetrag] [money] NULL,
	[Bemerkung] [text] NULL,
	[BaKrankenversicherungTS] [timestamp] NOT NULL,
	[GanzeSchweiz] [bit] NULL,
 CONSTRAINT [PK_BaKrankenversicherung] PRIMARY KEY CLUSTERED 
(
	[BaKrankenversicherungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaKrankenversicherung_GesetzesGrundlageCode_BaPersonID_BaKrankenversicherungID_BaInstitutionID_DatumVon]    Script Date: 03/22/2012 11:00:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaKrankenversicherung_GesetzesGrundlageCode_BaPersonID_BaKrankenversicherungID_BaInstitutionID_DatumVon] ON [dbo].[BaKrankenversicherung] 
(
	[GesetzesGrundlageCode] ASC,
	[BaPersonID] ASC,
	[BaKrankenversicherungID] ASC,
	[BaInstitutionID] ASC,
	[DatumVon] ASC
)
INCLUDE ( [DatumBis]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaKrankenversicherung_BaInstitutionID]    Script Date: 03/22/2012 11:00:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaKrankenversicherung_BaInstitutionID] ON [dbo].[BaKrankenversicherung] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaKrankenversicherung_BaPersonID]    Script Date: 03/22/2012 11:00:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaKrankenversicherung_BaPersonID] ON [dbo].[BaKrankenversicherung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaKrankenversicherung]  WITH CHECK ADD  CONSTRAINT [FK_BaKrankenversicherung_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaKrankenversicherung] CHECK CONSTRAINT [FK_BaKrankenversicherung_BaInstitution]
GO

ALTER TABLE [dbo].[BaKrankenversicherung]  WITH CHECK ADD  CONSTRAINT [FK_BaKrankenversicherung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaKrankenversicherung] CHECK CONSTRAINT [FK_BaKrankenversicherung_BaPerson]
GO

