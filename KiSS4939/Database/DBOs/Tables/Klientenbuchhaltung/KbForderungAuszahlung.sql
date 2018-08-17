/****** Object:  Table [dbo].[KbForderungAuszahlung]    Script Date: 11/18/2010 16:26:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KbForderungAuszahlung](
	[KbForderungAuszahlungID] [int] IDENTITY(1,1) NOT NULL,
	[KbBuchungID_Auszahlung] [int] NOT NULL,
	[KbBuchungID_Forderung] [int] NOT NULL,
	[KbOpAusgleichID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbForderungAuszahlungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbForderungAuszahlung] PRIMARY KEY CLUSTERED 
(
	[KbForderungAuszahlungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbForderungAuszahlung_KbBuchungID_Auszahlung]    Script Date: 11/18/2010 16:26:03 ******/
CREATE NONCLUSTERED INDEX [IX_KbForderungAuszahlung_KbBuchungID_Auszahlung] ON [dbo].[KbForderungAuszahlung] 
(
	[KbBuchungID_Auszahlung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_KbForderungAuszahlung_KbBuchungID_Forderung]    Script Date: 11/18/2010 16:26:03 ******/
CREATE NONCLUSTERED INDEX [IX_KbForderungAuszahlung_KbBuchungID_Forderung] ON [dbo].[KbForderungAuszahlung] 
(
	[KbBuchungID_Forderung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle KbForderungAuszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'KbForderungAuszahlungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Auszahlungsbuchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'KbBuchungID_Auszahlung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Forderungsbuchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'KbBuchungID_Forderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des OpAusgleiches' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'KbOpAusgleichID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung', @level2type=N'COLUMN',@level2name=N'KbForderungAuszahlungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um die Verbindung zwischen den Forderungen und Auszahlungen zu haben.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbForderungAuszahlung'
GO

ALTER TABLE [dbo].[KbForderungAuszahlung]  WITH CHECK ADD  CONSTRAINT [FK_KbForderungAuszahlung_KbBuchung_Auszahlung] FOREIGN KEY([KbBuchungID_Auszahlung])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbForderungAuszahlung] CHECK CONSTRAINT [FK_KbForderungAuszahlung_KbBuchung_Auszahlung]
GO

ALTER TABLE [dbo].[KbForderungAuszahlung]  WITH CHECK ADD  CONSTRAINT [FK_KbForderungAuszahlung_KbBuchung_Forderung] FOREIGN KEY([KbBuchungID_Forderung])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbForderungAuszahlung] CHECK CONSTRAINT [FK_KbForderungAuszahlung_KbBuchung_Forderung]
GO

ALTER TABLE [dbo].[KbForderungAuszahlung]  WITH CHECK ADD  CONSTRAINT [FK_KbForderungAuszahlung_KbOpAusgleich] FOREIGN KEY([KbOpAusgleichID])
REFERENCES [dbo].[KbOpAusgleich] ([KbOpAusgleichID])
GO

ALTER TABLE [dbo].[KbForderungAuszahlung] CHECK CONSTRAINT [FK_KbForderungAuszahlung_KbOpAusgleich]
GO

ALTER TABLE [dbo].[KbForderungAuszahlung] ADD  CONSTRAINT [DF_KbForderungAuszahlung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbForderungAuszahlung] ADD  CONSTRAINT [DF_KbForderungAuszahlung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


