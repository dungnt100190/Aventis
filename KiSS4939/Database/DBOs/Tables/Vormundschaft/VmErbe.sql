CREATE TABLE [dbo].[VmErbe](
	[VmErbeID] [int] IDENTITY(1,1) NOT NULL,
	[VmSiegelungID] [int] NULL,
	[VmTestamentID] [int] NULL,
	[VmErbschaftsdienstID] [int] NULL,
	[Position] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[Titel] [varchar](500) NULL,
	[Geburtsdatum] [varchar](40) NULL,
	[Anrede] [varchar](100) NULL,
	[FamilienNamen] [varchar](100) NULL,
	[Vornamen] [varchar](100) NULL,
	[Zusatz] [varchar](100) NULL,
	[Strasse] [varchar](100) NULL,
	[Ort] [varchar](80) NULL,
	[Land] [varchar](50) NULL,
	[Ergaenzung] [varchar](4000) NULL,
	[KontaktAdresse] [varchar](500) NULL,
	[KontaktHinzufuegen] [bit] NULL,
	[TestamentEroeffnungStatus] [varchar](10) NULL,
	[TestamentEroeffnungNr] [int] NULL,
	[TestamentEroeffnungVersandart] [varchar](5) NULL,
	[TestamentEroeffnungVersandDatum] [datetime] NULL,
	[ErbCodierung] [varchar](20) NULL,
	[ErbanteilDividend] [int] NULL,
	[ErbanteilDivisor] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmErbeTS] [timestamp] NOT NULL,
	[Titel2] [varchar](500) NULL,
 CONSTRAINT [PK_VmErbe] PRIMARY KEY CLUSTERED 
(
	[VmErbeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmErbe_VmErbschaftsdienstID] ON [dbo].[VmErbe] 
(
	[VmErbschaftsdienstID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_VmErbe_VmSiegelungID] ON [dbo].[VmErbe] 
(
	[VmSiegelungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_VmErbe_VmTestamentID] ON [dbo].[VmErbe] 
(
	[VmTestamentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmErbe Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbe', @level2type=N'COLUMN',@level2name=N'VmErbeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErbe_VmSiegelung) => VmSiegelung.VmSiegelungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbe', @level2type=N'COLUMN',@level2name=N'VmSiegelungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErbe_VmTestament) => VmTestament.VmTestamentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbe', @level2type=N'COLUMN',@level2name=N'VmTestamentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErbe_VmErbschaftsdienst) => VmErbschaftsdienst.VmErbschaftsdienstID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbe', @level2type=N'COLUMN',@level2name=N'VmErbschaftsdienstID'
GO

ALTER TABLE [dbo].[VmErbe]  WITH CHECK ADD  CONSTRAINT [FK_VmErbe_VmErbschaftsdienst] FOREIGN KEY([VmErbschaftsdienstID])
REFERENCES [dbo].[VmErbschaftsdienst] ([VmErbschaftsdienstID])
GO

ALTER TABLE [dbo].[VmErbe] CHECK CONSTRAINT [FK_VmErbe_VmErbschaftsdienst]
GO

ALTER TABLE [dbo].[VmErbe]  WITH CHECK ADD  CONSTRAINT [FK_VmErbe_VmSiegelung] FOREIGN KEY([VmSiegelungID])
REFERENCES [dbo].[VmSiegelung] ([VmSiegelungID])
GO

ALTER TABLE [dbo].[VmErbe] CHECK CONSTRAINT [FK_VmErbe_VmSiegelung]
GO

ALTER TABLE [dbo].[VmErbe]  WITH CHECK ADD  CONSTRAINT [FK_VmErbe_VmTestament] FOREIGN KEY([VmTestamentID])
REFERENCES [dbo].[VmTestament] ([VmTestamentID])
GO

ALTER TABLE [dbo].[VmErbe] CHECK CONSTRAINT [FK_VmErbe_VmTestament]
GO