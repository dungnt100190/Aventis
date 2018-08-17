CREATE TABLE [dbo].[KbZahlungskonto_XOrgUnit](
  [KbZahlungskonto_XOrgUnitID] [int] IDENTITY(1,1) NOT NULL,
  [KbZahlungskontoID] [int] NOT NULL,
  [OrgUnitID] [int] NOT NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KbZahlungskonto_XOrgUnitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbZahlungskonto_XOrgUnit] PRIMARY KEY CLUSTERED 
(
  [KbZahlungskonto_XOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KbZahlungskonto_XOrgUnit_KbZahlungskontoID] ON [dbo].[KbZahlungskonto_XOrgUnit] 
(
  [KbZahlungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KbZahlungskonto_XOrgUnit_OrgUnitID] ON [dbo].[KbZahlungskonto_XOrgUnit] 
(
  [OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu KbZahlungskonto Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'KbZahlungskontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XOrgUnit Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit', @level2type=N'COLUMN',@level2name=N'KbZahlungskonto_XOrgUnitTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle für KbZahlungskonto und XOrgUnit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto_XOrgUnit'
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungskonto_XOrgUnit_KbZahlungskonto] FOREIGN KEY([KbZahlungskontoID])
REFERENCES [dbo].[KbZahlungskonto] ([KbZahlungskontoID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit] CHECK CONSTRAINT [FK_KbZahlungskonto_XOrgUnit_KbZahlungskonto]
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_KbZahlungskonto_XOrgUnit_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit] CHECK CONSTRAINT [FK_KbZahlungskonto_XOrgUnit_XOrgUnit]
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit] ADD  CONSTRAINT [DF_KbZahlungskonto_XOrgUnit_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbZahlungskonto_XOrgUnit] ADD  CONSTRAINT [DF_KbZahlungskonto_XOrgUnit_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
