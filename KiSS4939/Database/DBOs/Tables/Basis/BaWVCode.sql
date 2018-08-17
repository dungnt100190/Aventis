CREATE TABLE [dbo].[BaWVCode](
	[BaWVCodeID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaWVCode] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[StatusCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[HeimatKantonNr] [varchar](50) NULL,
	[WohnKantonNr] [varchar](50) NULL,
	[KantonKuerzel] [varchar](50) NULL,
	[Auslandschweizer] [bit] NULL,
	[BaWVCodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaWVCode] PRIMARY KEY CLUSTERED 
(
	[BaWVCodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaWVCode_BaPersonID] ON [dbo].[BaWVCode] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaWVCode Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'BaWVCodeID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaWVCode_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Weiterverrechnungs-Code der Person (LOV BaWVCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'BaWVCode'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Gültigkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Gültigkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an ob der WV-Status gültig oder ungültig ist (LOV: BaWVStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'StatusCode'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld für zusätzliche Benutzerangaben' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer des Heimatkantons (@@TODO woher weiss man die? Keine Prüfung, kein LOV)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'HeimatKantonNr'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer des Wohnkantons  (@@TODO woher weiss man die? Keine Prüfung, kein LOV)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'WohnKantonNr'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kürzel des Kantons(@@TODO woher weiss man den? Keine Prüfung, kein LOV)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'KantonKuerzel'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob die Person Auslandschweizer ist (@@TODO: weshalb auf BaWVCode?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode', @level2type=N'COLUMN',@level2name=N'Auslandschweizer'
GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'WeiterverrechnungsCode einer Person. (@@TODO das ist nicht nach Namingkonvention!!!)    Dadurch können erbrachte Leistungen an andere Stellen (wie den Bund oder den Herkunftskanton) weiterverrechnet werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Basis, KliBu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaWVCode'
GO

ALTER TABLE [dbo].[BaWVCode]  WITH CHECK ADD  CONSTRAINT [FK_BaWVCode_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaWVCode] CHECK CONSTRAINT [FK_BaWVCode_BaPerson]
GO