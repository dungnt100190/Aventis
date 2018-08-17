CREATE TABLE [dbo].[FbDTAJournal](
	[FbDTAJournalID] [int] IDENTITY(1,1) NOT NULL,
	[FilePath] [varchar](512) NOT NULL,
	[TotalBetrag] [money] NOT NULL,
	[TransferDatum] [datetime] NULL,
	[FbDTAZugangID] [int] NULL,
	[PaymentMessageID] [VARCHAR](35) NULL,
	[UserID] [int] NOT NULL,
	[Transferiert] [bit] NOT NULL,
	[Zahlungsdaten] [varchar](max) NULL,
	[FbDTAJournalTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbDTAJournal] PRIMARY KEY CLUSTERED 
(
	[FbDTAJournalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbDTAJournal_FbDTAZugangID]    Script Date: 07/23/2014 07:35:12 ******/
CREATE NONCLUSTERED INDEX [IX_FbDTAJournal_FbDTAZugangID] ON [dbo].[FbDTAJournal] 
(
	[FbDTAZugangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbDTAJournal_UserID]    Script Date: 07/23/2014 07:35:12 ******/
CREATE NONCLUSTERED INDEX [IX_FbDTAJournal_UserID] ON [dbo].[FbDTAJournal] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbDTAJournal Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDTAJournal', @level2type=N'COLUMN',@level2name=N'FbDTAJournalID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbDTAJournal_FbDTAZugang) => FbDTAZugang.FbDTAZugangID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDTAJournal', @level2type=N'COLUMN',@level2name=N'FbDTAZugangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbDTAJournal_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDTAJournal', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MessageID in ISO 20022 Zahlungsdatei' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDTAJournal', @level2type=N'COLUMN',@level2name=N'PaymentMessageID'
GO

ALTER TABLE [dbo].[FbDTAJournal]  WITH CHECK ADD  CONSTRAINT [FK_FbDTAJournal_FbDTAZugang] FOREIGN KEY([FbDTAZugangID])
REFERENCES [dbo].[FbDTAZugang] ([FbDTAZugangID])
GO

ALTER TABLE [dbo].[FbDTAJournal] CHECK CONSTRAINT [FK_FbDTAJournal_FbDTAZugang]
GO

ALTER TABLE [dbo].[FbDTAJournal]  WITH CHECK ADD  CONSTRAINT [FK_FbDTAJournal_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FbDTAJournal] CHECK CONSTRAINT [FK_FbDTAJournal_XUser]
GO

ALTER TABLE [dbo].[FbDTAJournal] ADD  CONSTRAINT [DF_FbDTAJournal_Transferiert]  DEFAULT ((0)) FOR [Transferiert]
GO
