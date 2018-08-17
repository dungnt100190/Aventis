/****** Object:  Table [dbo].[BgSpezkonto]    Script Date: 11/10/2010 14:58:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BgSpezkonto](
	[BgSpezkontoID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BgSpezkontoTypCode] [int] NOT NULL,
	[NameSpezkonto] [varchar](100) NOT NULL,
	[StartSaldo] [money] NOT NULL,
	[OhneEinzelzahlung] [bit] NOT NULL,
	[BetragProMonat] [money] NULL,
	[BgPositionsartID] [int] NULL,
	[ErsterMonat] [datetime] NULL,
	[BgKostenartID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[OldID] [int] NULL,
	[BgSpezkontoTS] [timestamp] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Inaktiv] [bit] NOT NULL,
	[KuerzungLaufzeitMonate] [int] NULL,
	[KuerzungAnteilGBL] [money] NULL,
	[AbschlussBegruendung] [varchar](max) NULL,
	[AbzahlungskontoRueckerstattungCode] [int] NULL,
	[AbschlussgrundCode] [int] NULL,
 CONSTRAINT [PK_BgSpezkonto] PRIMARY KEY CLUSTERED 
(
	[BgSpezkontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BgSpezkonto_BaInstitutionID]    Script Date: 11/10/2010 14:58:12 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_BaInstitutionID] ON [dbo].[BgSpezkonto] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BgSpezkonto_BaPersonID]    Script Date: 11/10/2010 14:58:12 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_BaPersonID] ON [dbo].[BgSpezkonto] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BgSpezkonto_BgKostenartID]    Script Date: 11/10/2010 14:58:12 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_BgKostenartID] ON [dbo].[BgSpezkonto] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BgSpezkonto_BgPositionsartID]    Script Date: 11/10/2010 14:58:12 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_BgPositionsartID] ON [dbo].[BgSpezkonto] 
(
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BgSpezkonto_FaLeistungID]    Script Date: 11/10/2010 14:58:12 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_FaLeistungID] ON [dbo].[BgSpezkonto] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgSpezkonto Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'BgSpezkontoID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgSpezkonto_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgSpezkonto_BgPositionsart) => BgPositionsart.BgPositionsartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'BgPositionsartID'
GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgSpezkonto_BgKostenart) => BgKostenart.BgKostenartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgSpezkonto_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgSpezkonto_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung des Abschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'AbschlussBegruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rückerstattung des Abzahlungskontos. Code aus LOV AbzahlungskontoRueckerstattung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'AbzahlungskontoRueckerstattungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlussgrund des Abzahlungskontos. Code aus LOV AbzahlungskontoAbschlussgrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkonto', @level2type=N'COLUMN',@level2name=N'AbschlussgrundCode'
GO

ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BaInstitution]
GO

ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BaPerson]
GO

ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BgKostenart]
GO

ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BgPositionsart] FOREIGN KEY([BgPositionsartID])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO

ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BgPositionsart]
GO

ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_FaLeistung]
GO

ALTER TABLE [dbo].[BgSpezkonto] ADD  CONSTRAINT [DF_BgSpezkonto_StartSaldo]  DEFAULT ((0.0000)) FOR [StartSaldo]
GO

ALTER TABLE [dbo].[BgSpezkonto] ADD  CONSTRAINT [DF_BgSpezkonto_OhneEinzelzahlung]  DEFAULT ((0)) FOR [OhneEinzelzahlung]
GO

ALTER TABLE [dbo].[BgSpezkonto] ADD  CONSTRAINT [DF_BgSpezkonto_DatumVon]  DEFAULT (getdate()) FOR [DatumVon]
GO

ALTER TABLE [dbo].[BgSpezkonto] ADD  CONSTRAINT [DF_BgSpezkonto_Inaktiv]  DEFAULT ((0)) FOR [Inaktiv]
GO


