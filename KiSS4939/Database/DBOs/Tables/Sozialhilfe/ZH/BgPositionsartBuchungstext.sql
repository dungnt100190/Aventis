CREATE TABLE [dbo].[BgPositionsartBuchungstext](
	[BgPositionsartBuchungstextID] [int] IDENTITY(1,1) NOT NULL,
	[BgPositionsartID] [int] NOT NULL,
	[BgPositionsartID_UseText] [int] NULL,
	[Buchungstext] [varchar](100) NULL,
	[Standardwert] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BgPositionsartBuchungstextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgPositionsartBuchungstext] PRIMARY KEY CLUSTERED 
(
	[BgPositionsartBuchungstextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BgPositionsartBuchungstext_BgPositionsartID]    Script Date: 03/22/2012 10:24:00 ******/
CREATE NONCLUSTERED INDEX [IX_BgPositionsartBuchungstext_BgPositionsartID] ON [dbo].[BgPositionsartBuchungstext] 
(
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'BgPositionsartBuchungstextID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf der BgPositionsart für welche den Buchungstext gesetzt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'BgPositionsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf der BgPositionsart in welcher den Buchungstext definiert ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'BgPositionsartID_UseText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstext für eine Positionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Buchungstext'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zum definieren ob diesen Eintrag der Standard-Buchungstext ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Standardwert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext', @level2type=N'COLUMN',@level2name=N'BgPositionsartBuchungstextTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um Buchungstextvorschläge pro Positionsart zu speichern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgPositionsartBuchungstext'
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsartBuchungstext_BgPositionsart] FOREIGN KEY([BgPositionsartID])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext] CHECK CONSTRAINT [FK_BgPositionsartBuchungstext_BgPositionsart]
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext]  WITH CHECK ADD  CONSTRAINT [FK_BgPositionsartBuchungstext_BgPositionsart_UseText] FOREIGN KEY([BgPositionsartID_UseText])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext] CHECK CONSTRAINT [FK_BgPositionsartBuchungstext_BgPositionsart_UseText]
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext] ADD  CONSTRAINT [DF_BgPositionsartBuchungstext_Standardwert]  DEFAULT ((0)) FOR [Standardwert]
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext] ADD  CONSTRAINT [DF_BgPositionsartBuchungstext_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BgPositionsartBuchungstext] ADD  CONSTRAINT [DF_BgPositionsartBuchungstext_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

