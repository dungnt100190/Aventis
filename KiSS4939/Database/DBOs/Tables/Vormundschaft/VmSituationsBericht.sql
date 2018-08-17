CREATE TABLE [dbo].[VmSituationsBericht](
	[VmSituationsBerichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[AntragDatum] [datetime] NULL,
	[VMTypSHAntragCode] [int] NULL,
	[FaThemaCodes] [varchar](255) NULL,
	[BerichtFinanzen] [varchar](max) NULL,
	[ZielPrognose] [varchar](max) NULL,
	[AntragText] [varchar](max) NULL,
	[DocumentID] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmSituationsBerichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSituationsBericht] PRIMARY KEY CLUSTERED 
(
	[VmSituationsBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmSituationsBericht_FaLeistungID]    Script Date: 11/15/2010 10:07:27 ******/
CREATE NONCLUSTERED INDEX [IX_VmSituationsBericht_FaLeistungID] ON [dbo].[VmSituationsBericht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmSituationsBericht_UserID]    Script Date: 11/15/2010 10:07:27 ******/
CREATE NONCLUSTERED INDEX [IX_VmSituationsBericht_UserID] ON [dbo].[VmSituationsBericht] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmSituationsBericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'VmSituationsBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Antrag Datum.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'AntragDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'VMTypShAntrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'VMTypSHAntragCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beispiele: neuer Fall, Situationsbedingte Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'VMTypSHAntragCode'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'Name des LOV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beispiele: Wohnen, Gesundheit, Verhalten u.s.w.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktuelle Situation / Finanzen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'BerichtFinanzen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zielsetzung / Prognose' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'ZielPrognose'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Beschreibung Antrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'AntragText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id des binären Dokuments.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht', @level2type=N'COLUMN',@level2name=N'VmSituationsBerichtTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vormundschaft Situationsbericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSituationsBericht'
GO

ALTER TABLE [dbo].[VmSituationsBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmSituationsBericht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmSituationsBericht] CHECK CONSTRAINT [FK_VmSituationsBericht_FaLeistung]
GO

ALTER TABLE [dbo].[VmSituationsBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmSituationsBericht_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmSituationsBericht] CHECK CONSTRAINT [FK_VmSituationsBericht_XUser]
GO

ALTER TABLE [dbo].[VmSituationsBericht] ADD  CONSTRAINT [VmSituationsBericht_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmSituationsBericht] ADD  CONSTRAINT [DF_VmSituationsBericht_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmSituationsBericht] ADD  CONSTRAINT [DF_VmSituationsBericht_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
