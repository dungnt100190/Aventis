CREATE TABLE [dbo].[WshAbzug](
	[WshAbzugID] [int] IDENTITY(1,1) NOT NULL,
	[WshGrundbudgetPositionID] [int] NOT NULL,
	[MonatlichWiederholend] [bit] NOT NULL,
	[AbschlussDatum] [datetime] NULL,
	[WshAbzugAbschlussAktionCode] [int] NULL,
	[AbschlussGrund] [varchar](200) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshAbzugTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshAbzug] PRIMARY KEY CLUSTERED 
(
	[WshAbzugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_WshAbzug_WshGrundbudgetPositionID] UNIQUE NONCLUSTERED 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'WshAbzugID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Grundbudgetposition, zu der der Abzug gehört' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bestimmt, ob der Betrag monatlich verrechnet werden soll (z.B. VVG-Prämie)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'MonatlichWiederholend'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Abschlussdatum des Abzugs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'AbschlussDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Aktion, die zum Abschluss geführt hat (Fallwechsel,..)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'WshAbzugAbschlussAktionCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, der den Abschlussgrund beschreibt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'AbschlussGrund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug', @level2type=N'COLUMN',@level2name=N'WshAbzugTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Zusatztabelle für WshGrundbudgetPosition, für Abzugs-Kategorien (Rückerstattung, Verrechnung, Sanktion,..)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzug'
GO

ALTER TABLE [dbo].[WshAbzug]  WITH CHECK ADD  CONSTRAINT [FK_WshAbzug_WshGrundbudgetPosition] FOREIGN KEY([WshGrundbudgetPositionID])
REFERENCES [dbo].[WshGrundbudgetPosition] ([WshGrundbudgetPositionID])
GO

ALTER TABLE [dbo].[WshAbzug] CHECK CONSTRAINT [FK_WshAbzug_WshGrundbudgetPosition]
GO

ALTER TABLE [dbo].[WshAbzug] ADD  CONSTRAINT [DF_WshAbzug_MonatlichWiederholend]  DEFAULT ((0)) FOR [MonatlichWiederholend]
GO

ALTER TABLE [dbo].[WshAbzug] ADD  CONSTRAINT [DF_WshAbzug_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshAbzug] ADD  CONSTRAINT [DF_WshAbzug_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

