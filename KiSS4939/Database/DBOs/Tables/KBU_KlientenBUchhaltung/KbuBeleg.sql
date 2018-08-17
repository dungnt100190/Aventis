CREATE TABLE [dbo].[KbuBeleg](
	[KbuBelegID] [int] IDENTITY(1,1) NOT NULL,
	[UserID_BarBeleg] [int] NULL,
	[KbuZahlungseingangID] [int] NULL,
	[BelegNr] [bigint] NULL,
	[KbuBelegartCode] [int] NOT NULL,
	[KbuBelegKreisCode] [int] NULL,
	[KbuBelegstatusCode] [int] NOT NULL,
	[KbuProzessartCode] [int] NOT NULL,
	[BelegDatum] [datetime] NOT NULL,
	[ValutaDatum] [datetime] NULL,
	[Text] [varchar](200) NOT NULL,
	[BarBelegDatum] [datetime] NULL,
	[BarBezugDatum] [datetime] NULL,
	[TransferDatum] [datetime] NULL,
	[Fehlermeldung] [varchar](200) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuBelegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuBeleg] PRIMARY KEY CLUSTERED 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbuBeleg_UserID_BarBeleg] ON [dbo].[KbuBeleg] 
(
	[UserID_BarBeleg] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

CREATE NONCLUSTERED INDEX [IX_KbuBeleg_KbuZahlungseingangID] ON [dbo].[KbuBeleg] 
(
	[KbuZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Barbeleg: UserID des verantwortlichen Benutzers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'UserID_BarBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einnahme: Zahlungseingang, der mit diesem Beleg verbucht wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belegnummer der Buchung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'BelegNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belegart der Buchung (LOV KbuBelegart)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BelegartKreis der Buchung (LOV KbuBelegKreis), aus dem die BelegNr gelöst wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegKreisCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belegstatus der Buchung (LOV KbuBelegstatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegstatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prozessart der Buchung (LOV KbuProzessartCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuProzessartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Erstellung des Belegs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'BelegDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valuta-Datum des Belegs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'ValutaDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text des Belegs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Barbeleg: Datum der Kennzeichnung als Barbeleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'BarBelegDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Barbeleg: Datum des Bezugs des Barbelegs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'BarBezugDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt des erfolreichen Transfers zu einem Fremdsystem' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'TransferDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fehlermeldung zu diesem Beleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Fehlermeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg', @level2type=N'COLUMN',@level2name=N'KbuBelegTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Rolf Hesterberg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KBU Buchungstabelle (früher KbBuchung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Klientenbuchhaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBeleg'
GO

ALTER TABLE [dbo].[KbuBeleg]  WITH CHECK ADD  CONSTRAINT [FK_KbuBeleg_XUser_BarBeleg] FOREIGN KEY([UserID_BarBeleg])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[KbuBeleg] CHECK CONSTRAINT [FK_KbuBeleg_XUser_BarBeleg]
GO

ALTER TABLE [dbo].[KbuBeleg]  WITH CHECK ADD  CONSTRAINT [FK_KbuBeleg_KbuZahlungseingang] FOREIGN KEY([KbuZahlungseingangID])
REFERENCES [dbo].[KbuZahlungseingang] ([KbuZahlungseingangID])
GO
ALTER TABLE [dbo].[KbuBeleg] CHECK CONSTRAINT [FK_KbuBeleg_KbuZahlungseingang]
GO

ALTER TABLE [dbo].[KbuBeleg] ADD  CONSTRAINT [DF_KbuBeleg_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuBeleg] ADD  CONSTRAINT [DF_KbuBeleg_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


