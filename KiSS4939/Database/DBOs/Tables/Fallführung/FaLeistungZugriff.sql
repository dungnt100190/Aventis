CREATE TABLE [dbo].[FaLeistungZugriff](
	[FaLeistungZugriffID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DarfMutieren] [bit] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[FaLeistungZugriffTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaLeistungZugriff] PRIMARY KEY CLUSTERED 
(
	[FaLeistungZugriffID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_FaLeistungZugriff_FaLeistungID]    Script Date: 01/22/2015 08:27:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistungZugriff_FaLeistungID] ON [dbo].[FaLeistungZugriff] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaLeistungZugriff_UserID]    Script Date: 01/22/2015 08:27:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistungZugriff_UserID] ON [dbo].[FaLeistungZugriff] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaLeistungZugriff_UserID_FaLeistungID]    Script Date: 01/22/2015 08:27:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistungZugriff_UserID_FaLeistungID] ON [dbo].[FaLeistungZugriff] 
(
	[UserID] ASC
)
INCLUDE ( [FaLeistungID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FaLeistungZugriff Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'COLUMN',@level2name=N'FaLeistungZugriffID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaLeistungZugriff_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaLeistungZugriff_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gastrechtsgültigkeit DatumVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gastrechtsgültigkeit DatumBis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

ALTER TABLE [dbo].[FaLeistungZugriff]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungZugriff_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaLeistungZugriff] CHECK CONSTRAINT [FK_FaLeistungZugriff_FaLeistung]
GO

ALTER TABLE [dbo].[FaLeistungZugriff]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungZugriff_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaLeistungZugriff] CHECK CONSTRAINT [FK_FaLeistungZugriff_XUser]
GO

ALTER TABLE [dbo].[FaLeistungZugriff]  WITH NOCHECK ADD  CONSTRAINT [CK_FaLeistungZugriffFaLeistungUserIntegrity] CHECK  (([dbo].[fnFaCKFaLeistungZugriffFaLeistungUserIntegrity]([FaLeistungZugriffID],[FaLeistungID],[UserID],[DatumVon],[DatumBis])=(0)))
GO

ALTER TABLE [dbo].[FaLeistungZugriff] CHECK CONSTRAINT [CK_FaLeistungZugriffFaLeistungUserIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid FaLeistungZugriff records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungZugriff', @level2type=N'CONSTRAINT',@level2name=N'CK_FaLeistungZugriffFaLeistungUserIntegrity'
GO

ALTER TABLE [dbo].[FaLeistungZugriff] ADD  CONSTRAINT [DF_FaLeistungZugriff_DarfMutieren]  DEFAULT ((0)) FOR [DarfMutieren]
GO


