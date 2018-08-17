CREATE TABLE [dbo].[BaRechnungsadresse](
	[BaRechnungsadresseID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DienstleistungCode] [int] NOT NULL,
	[AdresseName] [varchar](200) NOT NULL,
	[AdresseZusatz] [varchar](200) NULL,
	[AdresseStrasse] [varchar](100) NULL,
	[AdresseHausNr] [varchar](10) NULL,
	[AdressePostfach] [varchar](100) NULL,
	[AdressePLZ] [varchar](10) NULL,
	[AdresseOrt] [varchar](50) NULL,
	[AdresseOrtCode] [int] NULL,
	[AdresseKanton] [varchar](10) NULL,
	[AdresseBezirk] [varchar](100) NULL,
	[AdresseLandCode] [int] NULL,
	[Bemerkungen] [text] NULL,
	[BaRechnungsadresseTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaRechnungsadresse] PRIMARY KEY CLUSTERED 
(
	[BaRechnungsadresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaRechnungsadresse_AdresseLandCode] ON [dbo].[BaRechnungsadresse] 
(
	[AdresseLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BaRechnungsadresse_BaPersonID] ON [dbo].[BaRechnungsadresse] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BaRechnungsadresse_BaPersonID_BaRechnungsadresseID] ON [dbo].[BaRechnungsadresse] 
(
	[BaPersonID] ASC,
	[BaRechnungsadresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BaRechnungsadresse_BaPersonID_DienstleistungCode__AddCols] ON [dbo].[BaRechnungsadresse] 
(
	[BaPersonID] ASC,
	[DienstleistungCode] ASC
)
INCLUDE ( [AdresseName],
[AdresseZusatz],
[AdresseStrasse],
[AdresseHausNr],
[AdressePostfach],
[AdressePLZ],
[AdresseOrt],
[AdresseKanton],
[AdresseBezirk],
[AdresseLandCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaRechnungsadresse]  WITH CHECK ADD  CONSTRAINT [FK_BaRechnungsadresse_BaLand] FOREIGN KEY([AdresseLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaRechnungsadresse] CHECK CONSTRAINT [FK_BaRechnungsadresse_BaLand]
GO

ALTER TABLE [dbo].[BaRechnungsadresse]  WITH CHECK ADD  CONSTRAINT [FK_BaRechnungsadresse_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaRechnungsadresse] CHECK CONSTRAINT [FK_BaRechnungsadresse_BaPerson]
GO