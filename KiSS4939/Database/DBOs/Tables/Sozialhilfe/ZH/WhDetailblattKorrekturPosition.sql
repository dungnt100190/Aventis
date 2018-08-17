CREATE TABLE [dbo].[WhDetailblattKorrekturPosition](
	[WhDetailblattKorrekturPositionID] [int] IDENTITY(1,1) NOT NULL,
	[WhDetailblattID] [int] NOT NULL,
	[WhDetailblattKorrekturVorzeichenCode] [int] NOT NULL,
	[BgKategorieCode] [int] NOT NULL,
	[BgKostenartID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Korrekturtext] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WhDetailblattKorrekturPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhDetailblattKorrekturPosition] PRIMARY KEY CLUSTERED 
(
	[WhDetailblattKorrekturPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhDetailblattKorrekturPosition_WhDetailblattID]    Script Date: 07/25/2012 11:33:10 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblattKorrekturPosition_WhDetailblattID] ON [dbo].[WhDetailblattKorrekturPosition] 
(
	[WhDetailblattID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für WhDetailblattKorrekturPosition Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'WhDetailblattKorrekturPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_WhDetailblattKorrekturPosition_WhDetailblatt) => WhDetailblattID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'WhDetailblattID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV WhDetailblattKorrekturVorzeichen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'WhDetailblattKorrekturVorzeichenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BgKategorieCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'BgKategorieCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_WhDetailblattKorrekturPosition_BgKostenart) => BgKostenartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der Korrektur Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung zur Korrektur Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Korrekturtext'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition', @level2type=N'COLUMN',@level2name=N'WhDetailblattKorrekturPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen für Ergänzungen einers Detailblatts einer Klientenkontoabrechnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblattKorrekturPosition'
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition]  WITH CHECK ADD  CONSTRAINT [FK_WhDetailblattKorrekturPosition_WhDetailblatt] FOREIGN KEY([WhDetailblattID])
REFERENCES [dbo].[WhDetailblatt] ([WhDetailblattID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition]  WITH CHECK ADD  CONSTRAINT [FK_WhDetailblattKorrekturPosition_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition] CHECK CONSTRAINT [FK_WhDetailblattKorrekturPosition_BgKostenart]
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition] CHECK CONSTRAINT [FK_WhDetailblattKorrekturPosition_WhDetailblatt]
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition] ADD  CONSTRAINT [DF_WhDetailblattKorrekturPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WhDetailblattKorrekturPosition] ADD  CONSTRAINT [DF_WhDetailblattKorrekturPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

