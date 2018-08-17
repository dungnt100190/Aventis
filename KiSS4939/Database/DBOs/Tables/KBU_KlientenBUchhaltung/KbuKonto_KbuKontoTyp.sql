CREATE TABLE [dbo].[KbuKonto_KbuKontoTyp](
	[KbuKonto_KbuKontoTypID] [int] IDENTITY(1,1) NOT NULL,
	[KbuKontoID] [int] NOT NULL,
	[KbuKontoTypCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuKonto_KbuKontoTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuKonto_KbuKontoTyp] PRIMARY KEY CLUSTERED 
(
	[KbuKonto_KbuKontoTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbuKonto_KbuKontoTyp_KbuKontoID]    Script Date: 08/05/2011 09:08:02 ******/
CREATE NONCLUSTERED INDEX [IX_KbuKonto_KbuKontoTyp_KbuKontoID] ON [dbo].[KbuKonto_KbuKontoTyp] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'KbuKonto_KbuKontoTypID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle KbuKonto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wert aus LOV KbuKontoTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'KbuKontoTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp', @level2type=N'COLUMN',@level2name=N'KbuKonto_KbuKontoTypTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Samuel Psota' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle um einem KbuKonto einen Typ zuweisen zu können.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Kbu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto_KbuKontoTyp'
GO

ALTER TABLE [dbo].[KbuKonto_KbuKontoTyp]  WITH CHECK ADD  CONSTRAINT [FK_KbuKonto_KbuKontoTyp_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[KbuKonto_KbuKontoTyp] CHECK CONSTRAINT [FK_KbuKonto_KbuKontoTyp_KbuKonto]
GO

ALTER TABLE [dbo].[KbuKonto_KbuKontoTyp] ADD  CONSTRAINT [DF_KbuKonto_KbuKontoTyp_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuKonto_KbuKontoTyp] ADD  CONSTRAINT [DF_KbuKonto_KbuKontoTyp_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
