CREATE TABLE [dbo].[FaDokumentAblage_BaPerson](
	[FaDokumentAblage_BaPersonID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[FaDokumentAblageID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaDokumentAblage_BaPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaDokumentAblage_BaPerson] PRIMARY KEY CLUSTERED 
(
	[FaDokumentAblage_BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_FaDokumentAblage_BaPerson_BaPersonID_FaDokumentID] UNIQUE NONCLUSTERED 
(
	[BaPersonID] ASC,
	[FaDokumentAblageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_BaPerson_BaPersonID] ON [dbo].[FaDokumentAblage_BaPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_BaPerson_FaDokumentAblageID] ON [dbo].[FaDokumentAblage_BaPerson] 
(
	[FaDokumentAblageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_BaPerson_FaDokumentAblageID_BaPersonID] ON [dbo].[FaDokumentAblage_BaPerson] 
(
	[FaDokumentAblageID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'FaDokumentAblage_BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle BaPerson, Spalte BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle FaKodumentAblage, Spalte FaDokumentAblageID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'FaDokumentAblageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripiton', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optmistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson', @level2type=N'COLUMN',@level2name=N'FaDokumentAblage_BaPersonTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Scrumteam 1 und 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle von BaPerson und FaDokumentAblage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Fallführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage_BaPerson'
GO

ALTER TABLE [dbo].[FaDokumentAblage_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_BaPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaDokumentAblage_BaPerson] CHECK CONSTRAINT [FK_FaDokumentAblage_BaPerson_BaPerson]
GO

ALTER TABLE [dbo].[FaDokumentAblage_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_BaPerson_FaDokumentAblage] FOREIGN KEY([FaDokumentAblageID])
REFERENCES [dbo].[FaDokumentAblage] ([FaDokumentAblageID])
GO

ALTER TABLE [dbo].[FaDokumentAblage_BaPerson] CHECK CONSTRAINT [FK_FaDokumentAblage_BaPerson_FaDokumentAblage]
GO