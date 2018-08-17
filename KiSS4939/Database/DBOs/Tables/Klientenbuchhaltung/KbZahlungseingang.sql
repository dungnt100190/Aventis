CREATE TABLE [dbo].[KbZahlungseingang](
	[KbZahlungseingangID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[Debitor] [varchar](200) NULL,
	[KontoNr] [varchar](10) NULL,
	[Betrag] [money] NULL,
	[Mitteilung1] [varchar](100) NULL,
	[Mitteilung2] [varchar](100) NULL,
	[Mitteilung3] [varchar](100) NULL,
	[Mitteilung4] [varchar](100) NULL,
	[Bemerkung] [varchar](max) NULL,
	[Ausgeglichen] [bit] NOT NULL,
	[Freigegeben] [bit] NOT NULL,
	[ZugeteiltUserID] [int] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[KbZahlungseingangTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbZahlungseingang] PRIMARY KEY CLUSTERED 
(
	[KbZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_BaInstitutionID] ON [dbo].[KbZahlungseingang] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_BaPersonID] ON [dbo].[KbZahlungseingang] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_ErstelltUserID] ON [dbo].[KbZahlungseingang] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_MutiertUserID] ON [dbo].[KbZahlungseingang] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_KbZahlungseingang_ZugeteiltUserID] ON [dbo].[KbZahlungseingang] 
(
	[ZugeteiltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbZahlungseingang Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungseingang_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungseingang_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungseingang_ZugeteiltXUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'ZugeteiltUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungseingang_ErstelltXUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'ErstelltUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbZahlungseingang_MutiertXUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungseingang', @level2type=N'COLUMN',@level2name=N'MutiertUserID'
GO

ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_BaInstitution]
GO

ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_BaPerson]
GO

ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_ErstelltXUser] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_ErstelltXUser]
GO

ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_MutiertXUser] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_MutiertXUser]
GO

ALTER TABLE [dbo].[KbZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungseingang_ZugeteiltXUser] FOREIGN KEY([ZugeteiltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbZahlungseingang] CHECK CONSTRAINT [FK_KbZahlungseingang_ZugeteiltXUser]
GO

ALTER TABLE [dbo].[KbZahlungseingang] ADD  CONSTRAINT [DF_KbZahlungseingang_Ausgeglichen]  DEFAULT ((0)) FOR [Ausgeglichen]
GO

ALTER TABLE [dbo].[KbZahlungseingang] ADD  CONSTRAINT [DF_KbZahlungseingang_Freigegeben]  DEFAULT ((0)) FOR [Freigegeben]
GO