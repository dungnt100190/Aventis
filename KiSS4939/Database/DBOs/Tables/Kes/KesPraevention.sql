CREATE TABLE [dbo].[KesPraevention](
	[KesPraeventionID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[KesPraeventionsartCode] [int] NULL,
	[KesPraeventionsabschlussCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesPraeventionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesPraevention] PRIMARY KEY CLUSTERED 
(
	[KesPraeventionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KesPraevention_FaLeistungID]    Script Date: 12/17/2013 10:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_KesPraevention_FaLeistungID] ON [dbo].[KesPraevention] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KesPraevention_UserID]    Script Date: 12/17/2013 10:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_KesPraevention_UserID] ON [dbo].[KesPraevention] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KES-Präventionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'KesPraeventionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesPraevention_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SAR, Fremdschlüssel (FK_KesPraevention_XUser) => UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Prävention' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Prävention' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Präventionsartcode aus LOV KesPraeventionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'KesPraeventionsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Präventionsabschlusscode aus LOV KesPraeventionsabschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'KesPraeventionsabschlussCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention', @level2type=N'COLUMN',@level2name=N'KesPraeventionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet Präventionen für Kindes- und Erwachsenenschutzleistungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesPraevention'
GO

ALTER TABLE [dbo].[KesPraevention]  WITH CHECK ADD  CONSTRAINT [FK_KesPraevention_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesPraevention] CHECK CONSTRAINT [FK_KesPraevention_FaLeistung]
GO

ALTER TABLE [dbo].[KesPraevention]  WITH CHECK ADD  CONSTRAINT [FK_KesPraevention_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesPraevention] CHECK CONSTRAINT [FK_KesPraevention_XUser]
GO

ALTER TABLE [dbo].[KesPraevention] ADD  CONSTRAINT [DF_KesPraevention_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesPraevention] ADD  CONSTRAINT [DF_KesPraevention_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


