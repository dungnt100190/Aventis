CREATE TABLE [dbo].[KbTransfer](
	[KbBuchungID] [int] NOT NULL,
	[KbZahlungslaufID] [int] NOT NULL,
	[KbTransferStatusCode] [int] NOT NULL,
	[KbTransferTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbTransfer] PRIMARY KEY CLUSTERED 
(
	[KbBuchungID] ASC,
	[KbZahlungslaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_KbTransfer_KbZahlungslaufID_KbTransferStatusCode]    Script Date: 06/14/2012 10:56:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbTransfer_KbZahlungslaufID_KbTransferStatusCode] ON [dbo].[KbTransfer] 
(
	[KbZahlungslaufID] ASC,
	[KbTransferStatusCode] ASC
)
INCLUDE ( [KbBuchungID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbTransfer Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbTransfer', @level2type=N'COLUMN',@level2name=N'KbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbTransfer Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbTransfer', @level2type=N'COLUMN',@level2name=N'KbZahlungslaufID'
GO

ALTER TABLE [dbo].[KbTransfer]  WITH CHECK ADD  CONSTRAINT [FK_KbTransfer_KbBuchung] FOREIGN KEY([KbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbTransfer] CHECK CONSTRAINT [FK_KbTransfer_KbBuchung]
GO

ALTER TABLE [dbo].[KbTransfer]  WITH CHECK ADD  CONSTRAINT [FK_KbTransfer_KbZahlungslauf] FOREIGN KEY([KbZahlungslaufID])
REFERENCES [dbo].[KbZahlungslauf] ([KbZahlungslaufID])
GO

ALTER TABLE [dbo].[KbTransfer] CHECK CONSTRAINT [FK_KbTransfer_KbZahlungslauf]
GO

ALTER TABLE [dbo].[KbTransfer] ADD  CONSTRAINT [DF_KbTransfer_KbTransferStatusCode]  DEFAULT (1) FOR [KbTransferStatusCode]
GO


