CREATE TABLE [dbo].[BaSicherheitsleistung](
	[BaSicherheitsleistungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[AuszahlungAm] [datetime] NULL,
	[RueckzahlungAm] [datetime] NULL,
	[BaMieteSicherheitsleistungArtCode] [int] NULL,
	[ObjektStrasseCode] [int] NULL,
	[ObjektStrasse] [varchar](100) NULL,
	[ObjektHausNr] [varchar](10) NULL,
	[ObjektPLZ] [varchar](50) NULL,
	[ObjektOrt] [varchar](50) NULL,
	[BaInstitutionID] [int] NULL,
	[BaBankID] [int] NULL,
	[KontoNummer] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[Bemerkungen] [varchar](500) NULL,
	[MigDarlehenID] [int] NULL,
	[neu] [bit] NOT NULL CONSTRAINT [DF_BaSicherheitsleistung_Migriert]  DEFAULT ((1)),
	[Geloescht] [bit] NOT NULL CONSTRAINT [DF_BaSicherheitsleistung_Gelöscht]  DEFAULT ((0)),
 CONSTRAINT [PK_BaSicherheitsleistung] PRIMARY KEY CLUSTERED 
(
	[BaSicherheitsleistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaSicherheitsleistung_BaBankID]    Script Date: 11/23/2011 10:46:31 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistung_BaBankID] ON [dbo].[BaSicherheitsleistung] 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaSicherheitsleistung_BaInstitutionID]    Script Date: 11/23/2011 10:46:31 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistung_BaInstitutionID] ON [dbo].[BaSicherheitsleistung] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaSicherheitsleistung_BaPersonID]    Script Date: 11/23/2011 10:46:31 ******/
CREATE NONCLUSTERED INDEX [IX_BaSicherheitsleistung_BaPersonID] ON [dbo].[BaSicherheitsleistung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaSicherheitsleistung]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistung_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistung] CHECK CONSTRAINT [FK_BaSicherheitsleistung_BaBank]
GO
ALTER TABLE [dbo].[BaSicherheitsleistung]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistung_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistung] CHECK CONSTRAINT [FK_BaSicherheitsleistung_BaInstitution]
GO
ALTER TABLE [dbo].[BaSicherheitsleistung]  WITH CHECK ADD  CONSTRAINT [FK_BaSicherheitsleistung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaSicherheitsleistung] CHECK CONSTRAINT [FK_BaSicherheitsleistung_BaPerson]