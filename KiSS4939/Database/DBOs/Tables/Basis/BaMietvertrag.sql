CREATE TABLE [dbo].[BaMietvertrag](
	[BaMietvertragID] [int] IDENTITY(1,1) NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Mietkosten] [money] NULL,
	[Nebenkosten] [money] NULL,
	[KostenanteilUE] [money] NULL,
	[Mietdepot] [money] NULL,
	[BaInstitutionID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[BaPersonID] [int] NULL,
	[MieteAbgetreten] [bit] NULL,
	[GarantieBis] [datetime] NULL,
	[BaMietvertragTS] [timestamp] NOT NULL,
	[Mietzinsgarantie] [money] NULL,
 CONSTRAINT [PK_BaMietvertrag] PRIMARY KEY CLUSTERED 
(
	[BaMietvertragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]
GO
CREATE NONCLUSTERED INDEX [IX_BaMietvertrag_BaInstitutionID] ON [dbo].[BaMietvertrag] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO
CREATE NONCLUSTERED INDEX [IX_BaMietvertrag_BaPersonID] ON [dbo].[BaMietvertrag] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaMietvertrag Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'BaMietvertragID'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum von des Mietvertrages. Miete ab auf CtlHaushalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis des Mietvertrages. Miete bis auf CtlHaushalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mietkosten gemäss Mietvertrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'Mietkosten'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nebenkosten gemäss Mietvertrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'Nebenkosten'
GO

GO
EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'TODO?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'KostenanteilUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenanteil der Unterstützungseinheit des Mietvertrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'KostenanteilUE'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag des Mietdepots des Mietvertrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'Mietdepot'
GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaMietvertrag_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO
EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Vermieter auf CtlHaushalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld zum Mietvertrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO
EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'RTF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaMietvertrag_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

GO

GO

GO

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einer Person können 0:n Mietverträge zugeordnet werden.   Die Maske CtlHaushalt unterstützt bisher jedoch nur die Erfassung eines Mietvertrages!  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaMietvertrag'
GO
ALTER TABLE [dbo].[BaMietvertrag]  WITH CHECK ADD  CONSTRAINT [FK_BaMietvertrag_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[BaMietvertrag] CHECK CONSTRAINT [FK_BaMietvertrag_BaInstitution]
GO
ALTER TABLE [dbo].[BaMietvertrag]  WITH CHECK ADD  CONSTRAINT [FK_BaMietvertrag_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaMietvertrag] CHECK CONSTRAINT [FK_BaMietvertrag_BaPerson]
GO
