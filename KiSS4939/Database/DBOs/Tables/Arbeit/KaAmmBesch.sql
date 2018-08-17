CREATE TABLE [dbo].[KaAmmBesch](
	[KaAmmBeschID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[KaEinsatzID] [int] NOT NULL,
	[KaEinsatzplatzID] [int] NULL,
	[ZustaendigKaID] [int] NULL,
	[Monat] [int] NULL,
	[Jahr] [int] NULL,
	[ProfilCode] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[gedrucktFlag] [bit] NOT NULL,
	[KaAKZuweiserTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAmmBesch] PRIMARY KEY CLUSTERED 
(
	[KaAmmBeschID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO


CREATE NONCLUSTERED INDEX [IX_KaAmmBesch_BaPersonID] ON [dbo].[KaAmmBesch] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_KaAmmBesch_KaEinsatzID] ON [dbo].[KaAmmBesch] 
(
	[KaEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prim�rschl�ssel f�r KaAmmBesch Records (nach Prim�rschl�ssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaAmmBeschID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (FK_KaAmmBesch_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (FK_KaAmmBesch_KaEinsatz) => KaEinsatz.KaEinsatzID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Bezieht sich auf An-/Zuweisungen eines Klienten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (TODO!!!!) => KaEinsatzplatz2.KaEinsatzplatzID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaEinsatzplatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (TODO!!!) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'ZustaendigKaID'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Zust�ndiger SAR vom KA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'ZustaendigKaID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monat der AMM - Bescheinigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'Monat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jahr der AMM - Bescheinigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'Jahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ProfilCode aus KaEinsatzplatz2 (LOV KaProfil)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'ProfilCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird f�r die Suchkriterien verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'ProfilCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DatumVon aus Tabelle KaEinsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austritt oder DatumBis von KaEinsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wurde AMM - Bescheinigung gedruckt oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'gedrucktFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Flag wird auf 1 gesetzt wenn der Benutzer die AMM - Bescheinigung druckt oder eine Vorschau macht.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'gedrucktFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp f�r Tabelle KaAmmBesch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaAKZuweiserTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Name m�sste ev. mal ge�ndert werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch', @level2type=N'COLUMN',@level2name=N'KaAKZuweiserTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Leonhard Greulich' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch'
GO

EXEC sys.sp_addextendedproperty @name=N'Customer_only', @value=N'Kunde ist Kompetenzzentrum f�r Arbeit (KA). KiSS wird zusammen mit SD Bern benutzt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sammlung von Daten f�r den Ausdruck der AMM - Bescheinigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Modul KA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAmmBesch'
GO

ALTER TABLE [dbo].[KaAmmBesch]  WITH CHECK ADD  CONSTRAINT [FK_KaAmmBesch_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KaAmmBesch] CHECK CONSTRAINT [FK_KaAmmBesch_BaPerson]
GO

ALTER TABLE [dbo].[KaAmmBesch]  WITH CHECK ADD  CONSTRAINT [FK_KaAmmBesch_KaEinsatz] FOREIGN KEY([KaEinsatzID])
REFERENCES [dbo].[KaEinsatz] ([KaEinsatzID])
GO

ALTER TABLE [dbo].[KaAmmBesch] CHECK CONSTRAINT [FK_KaAmmBesch_KaEinsatz]
GO

ALTER TABLE [dbo].[KaAmmBesch]  WITH CHECK ADD  CONSTRAINT [FK_KaAmmBesch_KaEinsatzplatz] FOREIGN KEY([KaEinsatzplatzID])
REFERENCES [dbo].[KaEinsatzplatz2] ([KaEinsatzplatzID])
GO

ALTER TABLE [dbo].[KaAmmBesch] CHECK CONSTRAINT [FK_KaAmmBesch_KaEinsatzplatz]
GO

ALTER TABLE [dbo].[KaAmmBesch] ADD  CONSTRAINT [DF_KaAmmBesch_gedrucktFlag]  DEFAULT ((0)) FOR [gedrucktFlag]
GO