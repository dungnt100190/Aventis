CREATE TABLE [dbo].[VmBewertung](
	[VmBewertungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[VmMandatstypCode] [int] NULL,
	[VmKriterienCodes] [varchar](100) NULL,
	[VmKriterienListe] [varchar](100) NULL,
	[UserID] [int] NULL,
	[VmFallgewichtungStichtagCode] [int] NOT NULL,
	[VmFallgewichtungJahr] [int] NOT NULL,
	[VmMandatstypBewilligtCode] [int] NULL,
	[ProduktID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmBewertungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmBewertung] PRIMARY KEY CLUSTERED 
(
	[VmBewertungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmBewertung_FaLeistungID] ON [dbo].[VmBewertung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_VmBewertung_UserID] ON [dbo].[VmBewertung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmBewertung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBewertung', @level2type=N'COLUMN',@level2name=N'VmBewertungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmBewertung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBewertung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmBewertung_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBewertung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[VmBewertung]  WITH CHECK ADD  CONSTRAINT [FK_VmBewertung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmBewertung] CHECK CONSTRAINT [FK_VmBewertung_FaLeistung]
GO

ALTER TABLE [dbo].[VmBewertung]  WITH CHECK ADD  CONSTRAINT [FK_VmBewertung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmBewertung] CHECK CONSTRAINT [FK_VmBewertung_XUser]
GO

ALTER TABLE [dbo].[VmBewertung] ADD  CONSTRAINT [DF__VmBewertu__VmFal__4B03CA61]  DEFAULT ((1)) FOR [VmFallgewichtungStichtagCode]
GO

ALTER TABLE [dbo].[VmBewertung] ADD  CONSTRAINT [DF__VmBewertu__VmFal__4BF7EE9A]  DEFAULT ((1)) FOR [VmFallgewichtungJahr]
GO