CREATE TABLE [dbo].[BaPerson_BaInstitution](
	[BaPerson_BaInstitutionID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[BaInstitutionKontaktID] [int] NULL,
	[BaInstitutionTypID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaPerson_BaInstitutionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson_BaInstitution] PRIMARY KEY CLUSTERED 
(
	[BaPerson_BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1],
 CONSTRAINT [UK_BaPerson_BaInstitution_BaPersonID_BaInstitutionID_BaInstitutionKontaktID_BaInstitutionTypID] UNIQUE NONCLUSTERED 
(
	[BaPersonID] ASC,
	[BaInstitutionID] ASC,
	[BaInstitutionKontaktID] ASC,
	[BaInstitutionTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_BaInstitution_BaInstitutionID] ON [dbo].[BaPerson_BaInstitution] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_BaInstitution_BaInstitutionKontaktID] ON [dbo].[BaPerson_BaInstitution] 
(
	[BaInstitutionKontaktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_BaInstitution_BaInstitutionTypID] ON [dbo].[BaPerson_BaInstitution] 
(
	[BaInstitutionTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_BaInstitution_BaPersonID] ON [dbo].[BaPerson_BaInstitution] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaPerson_BaInstitution Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaPerson_BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: BaPerson_BaInstitution.BaPersonID => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: BaPerson_BaInstitution.BaInstitutionID => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: BaPerson_BaInstitution.BaInstitutionKontaktID => BaInstitutionKontakt.BaInstitutionKontaktID (optionaler Wert)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionKontaktID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: BaPerson_BaInstitution.BaInstitutionTypID => BaInstitutionTyp.BaInstitutionTypID (optionaler Wert)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionTypID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen zu der Beziehung BaPerson > BaInstitution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution', @level2type=N'COLUMN',@level2name=N'BaPerson_BaInstitutionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi (Anpassungen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle, um Institutionen einer Person zuzuordnen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Basis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_BaInstitution'
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] CHECK CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitution]
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitutionKontakt] FOREIGN KEY([BaInstitutionKontaktID])
REFERENCES [dbo].[BaInstitutionKontakt] ([BaInstitutionKontaktID])
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] CHECK CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitutionKontakt]
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitutionTyp] FOREIGN KEY([BaInstitutionTypID])
REFERENCES [dbo].[BaInstitutionTyp] ([BaInstitutionTypID])
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] CHECK CONSTRAINT [FK_BaPerson_BaInstitution_BaInstitutionTyp]
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaInstitution_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] CHECK CONSTRAINT [FK_BaPerson_BaInstitution_BaPerson]
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] ADD  CONSTRAINT [DF_BaPerson_BaInstitution_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaPerson_BaInstitution] ADD  CONSTRAINT [DF_BaPerson_BaInstitution_Modified]  DEFAULT (getdate()) FOR [Modified]
GO