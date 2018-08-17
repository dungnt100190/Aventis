CREATE TABLE [dbo].[VmELKrankheitskosten](
	[VmELKrankheitskostenID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DocumentID] [int] NULL,
	[Eingereicht] [datetime] NULL,
	[AbrechnungenVom] [datetime] NULL,
	[VerfuegungVom] [datetime] NULL,
	[Betrag] [money] NULL,
	[AbrechnungenBis] [datetime] NULL,
	[VerfuegungLeistung] [money] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmELKrankheitskostenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmELKrankheitskosten] PRIMARY KEY CLUSTERED 
(
	[VmELKrankheitskostenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmELKrankheitskosten_DocumentID]    Script Date: 11/26/2010 08:52:06 ******/
CREATE NONCLUSTERED INDEX [IX_VmELKrankheitskosten_DocumentID] ON [dbo].[VmELKrankheitskosten] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmELKrankheitskosten_FaLeistungID]    Script Date: 11/26/2010 08:52:06 ******/
CREATE NONCLUSTERED INDEX [IX_VmELKrankheitskosten_FaLeistungID] ON [dbo].[VmELKrankheitskosten] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'VmELKrankheitskostenID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur FaLeisgung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Docoument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eingereicht.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Eingereicht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abrechnungen vom.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'AbrechnungenVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MSDescription', @value=N'Verfügung vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'VerfuegungVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abrechnung bis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'AbrechnungenBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Leistung als Zahl' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'VerfuegungLeistung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Daensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten', @level2type=N'COLUMN',@level2name=N'VmELKrankheitskostenTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ELKrankheitskosten in Vormundschaftliche Massnahmen, Administration.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmELKrankheitskosten'
GO

ALTER TABLE [dbo].[VmELKrankheitskosten]  WITH CHECK ADD  CONSTRAINT [FK_VmELKrankheitskosten_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmELKrankheitskosten] CHECK CONSTRAINT [FK_VmELKrankheitskosten_FaLeistung]
GO

ALTER TABLE [dbo].[VmELKrankheitskosten]  WITH CHECK ADD  CONSTRAINT [FK_VmELKrankheitskosten_VmELKrankheitskosten] FOREIGN KEY([VmELKrankheitskostenID])
REFERENCES [dbo].[VmELKrankheitskosten] ([VmELKrankheitskostenID])
GO

ALTER TABLE [dbo].[VmELKrankheitskosten] CHECK CONSTRAINT [FK_VmELKrankheitskosten_VmELKrankheitskosten]
GO

ALTER TABLE [dbo].[VmELKrankheitskosten] ADD  CONSTRAINT [DF_VmELKrankheitskosten_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmELKrankheitskosten] ADD  CONSTRAINT [DF_VmELKrankheitskosten_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmELKrankheitskosten] ADD  CONSTRAINT [DF_VmELKrankheitskosten_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
