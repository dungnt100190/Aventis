CREATE TABLE [dbo].[BgFinanzplan_BaPerson](
	[BgFinanzplanID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[IstUnterstuetzt] [bit] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[KbKostenstelleID] [int] NULL,
	[KbKostenstelleID_KVG] [int] NULL,
	[ShNrmVerrechnungsbasisID] [int] NOT NULL,
	[PrsNummerKanton] [varchar](10) NULL,
	[PrsNummerHeimat] [varchar](10) NULL,
	[NrmVerrechnungVon] [datetime] NULL,
	[NrmVerrechnungBis] [datetime] NULL,
	[NrmVerrechnungsAnteilCode] [int] NULL,
	[IstAuslandCh] [bit] NOT NULL,
	[AuslandChVon] [datetime] NULL,
	[AuslandChBis] [datetime] NULL,
	[AuslandChMeldungAm] [datetime] NULL,
	[AuslandChReferenzNrBund] [varchar](50) NULL,
	[BurgergemeindeID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[BgFinanzplan_BaPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgFinanzplan_BaPerson] PRIMARY KEY CLUSTERED 
(
	[BgFinanzplanID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BaPerson] ON [dbo].[BgFinanzplan_BaPerson] 
(
	[BaPersonID] ASC,
	[IstUnterstuetzt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BaPerson_BaPersonID] ON [dbo].[BgFinanzplan_BaPerson] 
(
	[BaPersonID] ASC,
	[BgFinanzplanID] ASC,
	[IstUnterstuetzt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_BgFinanzplan) => BgFinanzplan.BgFinanzplanID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'BgFinanzplanID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_ShFinanzPlan_BaPerson_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_BaZahlungsweg) => BaZahlungsweg.BaZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_KbKostenstelle) => KbKostenstelle.KbKostenstelleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'KbKostenstelleID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_KbKostenstelle_KVG) => KbKostenstelle.KbKostenstelleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'KbKostenstelleID_KVG'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_ShNrmVerrechnungsbasis) => ShNrmVerrechnungsbasis.ShNrmVerrechnungsbasisID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'ShNrmVerrechnungsbasisID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgFinanzplan_BaPerson_ShBurgergemeinde) => ShBurgergemeinde.BurgergemeindeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgFinanzplan_BaPerson', @level2type=N'COLUMN',@level2name=N'BurgergemeindeID'
GO


GO


GO


GO


GO


GO


GO


GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BaGemeinde] FOREIGN KEY([BurgergemeindeID])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BaGemeinde]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BaPerson]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BaZahlungsweg]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_BgFinanzplan]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_KbKostenstelle] FOREIGN KEY([KbKostenstelleID])
REFERENCES [dbo].[KbKostenstelle] ([KbKostenstelleID])
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_KbKostenstelle]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_BaPerson_KbKostenstelle_KVG] FOREIGN KEY([KbKostenstelleID_KVG])
REFERENCES [dbo].[KbKostenstelle] ([KbKostenstelleID])
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] CHECK CONSTRAINT [FK_BgFinanzplan_BaPerson_KbKostenstelle_KVG]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] ADD  CONSTRAINT [DF_BgFinanzplan_BaPerson_IstUnterstuetzt]  DEFAULT ((1)) FOR [IstUnterstuetzt]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] ADD  CONSTRAINT [DF_BgFinanzplan_BaPerson_ShNrmVerrechnungsbasisID]  DEFAULT ((1)) FOR [ShNrmVerrechnungsbasisID]
GO

ALTER TABLE [dbo].[BgFinanzplan_BaPerson] ADD  CONSTRAINT [DF_BgFinanzplan_BaPerson_IstAuslandCh]  DEFAULT ((0)) FOR [IstAuslandCh]
GO