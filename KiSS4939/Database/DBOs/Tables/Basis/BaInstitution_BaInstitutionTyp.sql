CREATE TABLE [dbo].[BaInstitution_BaInstitutionTyp](
	[BaInstitution_BaInstitutionTypID] [int] IDENTITY(1,1) NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[BaInstitutionTypID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaInstitution_BaInstitutionTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitution_BaInstitutionTyp] PRIMARY KEY CLUSTERED 
(
	[BaInstitution_BaInstitutionTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1],
 CONSTRAINT [UK_BaInstitution_BaInstitutionTyp_BaInstitutionID_BaInstitutionTypID] UNIQUE NONCLUSTERED 
(
	[BaInstitutionID] ASC,
	[BaInstitutionTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaInstitution_BaInstitutionTyp_BaInstitutionTypID_BaInstitutionID] ON [dbo].[BaInstitution_BaInstitutionTyp] 
(
	[BaInstitutionTypID] ASC
)
INCLUDE ( [BaInstitutionID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaInstitution_BaInstitutionTyp Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitution_BaInstitutionTypID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaInstitution.BaInstitutionID, Institution, welche einen Typ zugewiesen erhalten soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaInstitutionTyp.BaInstitutionTypID, Zuweisung eines Typen zu einer Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitutionTypID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp', @level2type=N'COLUMN',@level2name=N'BaInstitution_BaInstitutionTypTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Samuel Psota, Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle, um einer BaInstitution 0..n verschiedene BaInstitutionTyp-en zuzuweisen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution_BaInstitutionTyp'
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitution_BaInstitutionTyp_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp] CHECK CONSTRAINT [FK_BaInstitution_BaInstitutionTyp_BaInstitution]
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitution_BaInstitutionTyp_BaInstitutionTyp] FOREIGN KEY([BaInstitutionTypID])
REFERENCES [dbo].[BaInstitutionTyp] ([BaInstitutionTypID])
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp] CHECK CONSTRAINT [FK_BaInstitution_BaInstitutionTyp_BaInstitutionTyp]
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp] ADD  CONSTRAINT [DF_BaInstitution_BaInstitutionTyp_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaInstitution_BaInstitutionTyp] ADD  CONSTRAINT [DF_BaInstitution_BaInstitutionTyp_Modified]  DEFAULT (getdate()) FOR [Modified]
GO