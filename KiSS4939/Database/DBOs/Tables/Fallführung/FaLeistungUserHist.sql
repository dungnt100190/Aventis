/****** Object:  Table [dbo].[FaLeistungUserHist]    Script Date: 01/28/2013 10:42:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FaLeistungUserHist](
	[FaLeistungUserHistID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaLeistungUserHistTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaLeistungUserHist] PRIMARY KEY CLUSTERED 
(
	[FaLeistungUserHistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaLeistungUserHist_FaLeistungID]    Script Date: 01/28/2013 10:42:38 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistungUserHist_FaLeistungID] ON [dbo].[FaLeistungUserHist] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaLeistungUserHist_UserID]    Script Date: 01/28/2013 10:42:38 ******/
CREATE NONCLUSTERED INDEX [IX_FaLeistungUserHist_UserID] ON [dbo].[FaLeistungUserHist] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FaLeistungUserHist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'FaLeistungUserHistID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die dazugehörige FaLeistungID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der für den Zeitraum zuständige User.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum von welchem an der User für den Fall zuständig war.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis zu welchem der User für den Fall zuständig war.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist', @level2type=N'COLUMN',@level2name=N'FaLeistungUserHistTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen für die Darstellung der Fallübergabe in der Zeitachse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaLeistungUserHist'
GO

ALTER TABLE [dbo].[FaLeistungUserHist]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungUserHist_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaLeistungUserHist] CHECK CONSTRAINT [FK_FaLeistungUserHist_FaLeistung]
GO

ALTER TABLE [dbo].[FaLeistungUserHist]  WITH CHECK ADD  CONSTRAINT [FK_FaLeistungUserHist_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaLeistungUserHist] CHECK CONSTRAINT [FK_FaLeistungUserHist_XUser]
GO

ALTER TABLE [dbo].[FaLeistungUserHist] ADD  CONSTRAINT [DF_FaLeistungUserHist_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaLeistungUserHist] ADD  CONSTRAINT [DF_FaLeistungUserHist_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


