CREATE TABLE [dbo].[KbZahlungslauf](
	[KbZahlungslaufID] [int] IDENTITY(1,1) NOT NULL,
	[KbZahlungskontoID] [int] NOT NULL,
	[PaymentMessageID] [varchar](35) NULL,
	[UserID] [int] NOT NULL,
	[FilePath] [varchar](512) NOT NULL,
	[TotalBetrag] [money] NOT NULL,
	[TransferDatum] [datetime] NULL,
	[Transferiert] [bit] NOT NULL,
	[Zahlungsdaten] [varchar](max) NOT NULL,
	[FaelligkeitDatum] [datetime] NULL,
	[KbZahlungslaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbZahlungslauf] PRIMARY KEY CLUSTERED 
(
	[KbZahlungslaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungslauf_KbZahlungskontoID] ON [dbo].[KbZahlungslauf] 
(
	[KbZahlungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungslauf_UserID] ON [dbo].[KbZahlungslauf] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbZahlungslauf Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungslauf', @level2type=N'COLUMN',@level2name=N'KbZahlungslaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungslauf_KbZahlungskonto) => KbZahlungskonto.KbZahlungskontoID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungslauf', @level2type=N'COLUMN',@level2name=N'KbZahlungskontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MessageID in ISO 20022 Zahlungsdatei' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungslauf', @level2type=N'COLUMN',@level2name=N'PaymentMessageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungslauf_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungslauf', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Fälligkeitsdatum des Zahlungseingangs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungslauf', @level2type=N'COLUMN',@level2name=N'FaelligkeitDatum'
GO

ALTER TABLE [dbo].[KbZahlungslauf]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungslauf_KbZahlungskonto] FOREIGN KEY([KbZahlungskontoID])
REFERENCES [dbo].[KbZahlungskonto] ([KbZahlungskontoID])
GO

ALTER TABLE [dbo].[KbZahlungslauf] CHECK CONSTRAINT [FK_KbZahlungslauf_KbZahlungskonto]
GO

ALTER TABLE [dbo].[KbZahlungslauf]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungslauf_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbZahlungslauf] CHECK CONSTRAINT [FK_KbZahlungslauf_XUser]
GO

ALTER TABLE [dbo].[KbZahlungslauf] ADD  CONSTRAINT [DF_KbZahlungslauf_Transferiert]  DEFAULT ((0)) FOR [Transferiert]
GO
