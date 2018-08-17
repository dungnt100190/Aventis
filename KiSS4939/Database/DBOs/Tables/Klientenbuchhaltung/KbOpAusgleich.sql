CREATE TABLE [dbo].[KbOpAusgleich](
	[KbOpAusgleichID] [int] IDENTITY(1,1) NOT NULL,
	[OpBuchungID] [int] NOT NULL,
	[AusgleichBuchungID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[KbOpAusgleichTS] [timestamp] NOT NULL,
	[_mig_AiZahlungVsForderungID] [int] NULL,
 CONSTRAINT [PK_KbOpAusgleich] PRIMARY KEY CLUSTERED 
(
	[KbOpAusgleichID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO


CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_AusgleichBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[AusgleichBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_OpBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[OpBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_OpBuchungID_KbOpAusgleichID_AusgleichBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[OpBuchungID] ASC,
	[KbOpAusgleichID] ASC,
	[AusgleichBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbOpAusgleich Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbOpAusgleich', @level2type=N'COLUMN',@level2name=N'KbOpAusgleichID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbOpAusgleich_KbBuchung) => KbBuchung.KbBuchungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbOpAusgleich', @level2type=N'COLUMN',@level2name=N'OpBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbOpAusgleich_KbBuchung1) => KbBuchung.KbBuchungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbOpAusgleich', @level2type=N'COLUMN',@level2name=N'AusgleichBuchungID'
GO

ALTER TABLE [dbo].[KbOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbOpAusgleich_KbBuchung] FOREIGN KEY([OpBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbOpAusgleich] CHECK CONSTRAINT [FK_KbOpAusgleich_KbBuchung]
GO

ALTER TABLE [dbo].[KbOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbOpAusgleich_KbBuchung1] FOREIGN KEY([AusgleichBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbOpAusgleich] CHECK CONSTRAINT [FK_KbOpAusgleich_KbBuchung1]
GO